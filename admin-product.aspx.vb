Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class adminproduct_class
    Inherits basepageadmin
    Public ImageMainPath As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DBTableName = "products"
        ActionType = "PP"
        EnableDelete = True

        ClientScript.GetPostBackEventReference(Page, "")

        ImageMainPath = "Documents/" & WebLib.MerchantID & "/" & WebLib.ActionParamMMUID & "/"

        If (weblib.ActionParamMMUID & "").trim = "" Then
            response.redirect("loginmerchant.aspx")
        End If
        If Weblib.UserIsFullAdmin = False Then
            response.redirect("loginmain.aspx")
        End If

        If Page.IsPostBack = False Then

            Call WebLib.setListItemsTable(productcat3, "description", "id", "productcat3", "description", "", "custcode", "", " isnull(pc_valid,1)<>0 ", , "Please Select")
            Call WebLib.setListItemsTable(catid, "(pf_name + '-' + productcat.description)", "id", "product_filter inner join productcat on pf_uid = pc_puid ", "isnull(pf_seq,'9999'),listseq", "", "product_filter.pf_custcode", "", " isnull(pf_valid,1)<>0 and isnull(pc_valid,1)<>0  ", , "Please Select")

            catid.Text = WebLib.ActionParam1

            If WebLib.ActionUID.trim <> "" And WebLib.ActionType = ActionType Then
                uid.Value = WebLib.ActionUID.trim
                Call LoadData()
            End If


        End If


        pcode.enabled = False
        pname.enabled = False
        description.enabled = False
        priority.Enabled = True

    End Sub
    Protected Function doValidation() As Boolean

        If (pcode.Text & "").Trim = "" Then
            ShowAlert("Product Code is Mandatory")
            Return False
        End If

        If (pname.Text & "").Trim = "" Then
            ShowAlert("Product Name is Mandatory")
            Return False
        End If

        If (catid.SelectedValue = "") Then
            ShowAlert("Category is Mandatory")
            Return False
        End If
        If IsNumeric(catid.SelectedValue) = False Then
            ShowAlert("Category is Mandatory")
            Return False
        End If
        Return True
    End Function
    Public Sub savedata(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Dim insertfields, insertvalues, updatedelwhere As String
        Dim ldocno As String = ""
        Dim luid As String = ""
        Dim lType As String = ""
        Dim lError As String = ""
        Dim _logincode As String = ""

        insertfields = ""
        insertvalues = ""
        updatedelwhere = ""

        If doValidation() = False Then
            Exit Sub
        End If

        Dim lcat3 As String = ""
        lcat3 = productcat3.SelectedValue.Replace("'", "''")

        If IsNumeric(lcat3) = False Then
            lcat3 = "NULL"
        End If



        Try

            If uid.Value.Trim = "" Then
                ShowAlert("Error: " & "Data Integrity Violation. Please retry")
                Exit Sub
            Else

                lType = "E"
                insertvalues = insertvalues & "catid=" & catid.SelectedValue.Replace("'", "''")
                insertvalues = insertvalues & ",priority=" & priority.SelectedValue.Replace("'", "''")
                insertvalues = insertvalues & ",ffeature='" & WebUtils.BooleanToYN(ffeature.Checked) & "'"
                insertvalues = insertvalues & ",updateby='" & WebLib.UserCode.replace("'", "''") & "'"
                insertvalues = insertvalues & ",productcat3=" & lcat3
                insertvalues = insertvalues & ",updatedt=getdate()"
                insertvalues = insertvalues & ",pp_valid=" & WebUtils.BooleanToBit(chkactive.Checked)
                updatedelwhere = "pp_uid='" & uid.Value & "'"
            End If

            If SaveDBData(lType, DBTableName, insertfields, insertvalues, updatedelwhere, lError, "") = True Then

                ShowPrompt("Record Updated ", "admin-productlist.aspx")
            Else
                Response.Write(lError)
                ShowAlert("Error Submitting. Please Retry ")
            End If

        Catch Err As Exception
            ShowAlert("Error: " & Err.Message)
        Finally

        End Try


    End Sub

    Public Sub backpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call gotoTheback()

    End Sub
    Public Sub gotoTheback()
        Response.Redirect("admin-productlist.aspx")
    End Sub

    Protected Sub LoadData()
        Dim cn As New OleDbConnection(DBConnection)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Try
            cn.Open()
            cmd.CommandText = "Select * from " & DBTableName & " where pp_uid='" & uid.Value & "' and custcode='" & WebLib.MerchantID & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                pname.Text = dr("pname") & ""
                pcode.Text = dr("pcode") & ""
                description.Text = dr("description") & ""
                catid.Text = dr("catid") & ""
                priority.Text = dr("priority") & ""
                productcat3.Text = dr("productcat3") & ""

                ffeature.Checked = WebUtils.AnythingToBoolean(dr("ffeature") & "")
                chkactive.Checked = WebUtils.BitToBoolean(dr("pp_valid") & "")
                Exit For
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            ShowAlert("Ooops... We are encoutering heavy access. Please try again")
            Exit Sub
        End Try




    End Sub



End Class


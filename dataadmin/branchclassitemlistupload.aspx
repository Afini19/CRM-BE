<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="branchclassitemlistupload.aspx.vb" Inherits="branchclassitemlistupload_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
<link rel="stylesheet" type="text/css" href="../Datatables/datatables.min.css"/>
<script type="text/javascript" src="../Datatables/datatables.min.js"></script>

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform">
<div class="row">
    <div class="col s12 m12">
        <div class="pagetitle"><%=PageTitle%></div>
    </div>
</div>



<div class="row">
<div class="col s12 m4">
                                    <div class="file-field input-field">
                                          <div class="btn cyan darken-2">
                                            <span>File</span>
                                            <input type="file" runat="server" id="UploadedFile">
                                          </div>
                                          <div class="file-path-wrapper">
                                            <input class="file-path validate" type="text" placeholder="Select File">
                                          </div>
                                         </div>
                                         <input type="hidden" runat="server" id="filename1" />
</div>
</div>
<div class="row">
<div class="col s12 m4">
<asp:Button ID="uploadbutton" runat="server" Text="STEP 1- Upload Document" class="btn waves-effect waves-light cyan darken-2 caishbutton"  OnClick="UploadFile" />
</div>

<div class="col s12 m3">
<asp:Button ID="btnstep2" runat="server" Text="STEP 2 - Validate Data" class="btn waves-effect waves-light cyan darken-3 caishbutton"  OnClick="validatedata" />
</div>
<div class="col s12 m3">
<asp:Button ID="btnstep3" runat="server" Text="STEP 3 - Apply to LIVE" class="btn waves-effect waves-light cyan darken-4 caishbutton"  OnClick="confirmdata" />
</div>
<div class="col s12 m2">
<asp:Button ID="btnback" runat="server" Text="<< BACK" class="btn waves-effect waves-light cyan darken-4 caishbutton"  OnClick="backback" />
</div>

</div>
<div class="divider"></div>
<br />
<table id="caishtb" class="compact hover stripe cell-border nowrap order-column" width="100%">
<asp:Literal runat="server" ID="litthead"></asp:Literal>
<tbody>
<asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand" >
<ItemTemplate>
<asp:Literal ID="litTableRows" runat="server"></asp:Literal>
</ItemTemplate>
</asp:Repeater>
</tbody>
<asp:Literal runat="server" ID="littfoot"></asp:Literal>
</table>

<br />
<div class="row">
<div class="col s12 m4">
<asp:Button ID="btnclear" runat="server" Text="Clear Grid Data" class="btn waves-effect waves-light red caishbutton"  />
</div>
<div class="col s12 m3">
<asp:Button ID="btndelete" runat="server" Text="Delete Selected Row" class="btn waves-effect waves-light red darken-2 caishbutton"  OnClick="deleteline" />
</div>

</div>
       	  <asp:Repeater ID="rptPaging" runat="server">
            <ItemTemplate>
                    <asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" ><%# Container.DataItem %></asp:LinkButton>
           </ItemTemplate>
        </asp:Repeater>




      <input type="hidden" id="table1sel" runat="server" />
      <input type="hidden" id="eventtype2" runat="server" />
      <input type="hidden" id="eventtype" runat="server" />
      <input type="hidden" id="eventargs" runat="server" />
      <asp:Button ID="eventfire" runat="server" style="display:none" OnClick="eventfiresub" />

      
      
</form>
</div>
</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">  

<script language="javascript" type="text/javascript">
$(document).ready(function() {
   <asp:Literal runat="server" ID="litsettings"></asp:Literal>  
   var table = $('#caishtb').DataTable();     
    $('#caishtb tbody').on('click', 'tr', function () {
        var data = table.row( this ).data();
        $('#<%=table1sel.clientid%>').val(data[0]);
         if (data[0].trim()!="")
        {
         if ( $(this).hasClass('selected') ) {
            $(this).removeClass('selected');
         }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
          }
         }
     });
    
});
</script>
</asp:Content>  




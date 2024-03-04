<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="branchclassitemlist.aspx.vb" Inherits="branchclassitemlist_class" MasterPageFile="~/Site.Master" %>  
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
    <div class="col s12 m3">
            <br />
             <asp:Button ID="btnview" runat="server" Text="View >>" class="btn waves-effect waves-light cyan darken-3 caishbutton"  OnClick="viewdata" />
    </div>
    <div class="col s12 m3">
            <br />
             <asp:Button ID="btnmanage" runat="server" Text="Manage/Upload List" class="btn waves-effect waves-light cyan darken-4 caishbutton"  OnClick="managedata" />
    </div>

</div>


    <div class="row">

                    <div class="col s12 m3">
                    <table id="caishtb" class="<%=TableUtils.TableType%>" width="100%">
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
                    </div>

                    <div class="col s12 m9">
                    <table id="caishtb2" class="hover stripe cell-border nowrap order-column" width="100%">
                    <asp:Literal runat="server" ID="litthead2"></asp:Literal>
                    <tbody>
                    <asp:Repeater ID="rep2" runat="server" OnItemCommand="rep_ItemCommand" >
                    <ItemTemplate>
                    <asp:Literal ID="litTableRows2" runat="server"></asp:Literal>
                    </ItemTemplate>
                    </asp:Repeater>                    
                    </tbody>
                    <asp:Literal runat="server" ID="littfoot2"></asp:Literal>
                    </table>

                    </div>



  </div>
    

    


       	  <asp:Repeater ID="rptPaging" runat="server">
            <ItemTemplate>
                    <asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" ><%# Container.DataItem %></asp:LinkButton>
           </ItemTemplate>
        </asp:Repeater>

      <input type="hidden" id="table1sel" runat="server" />
      <input type="hidden" id="table2sel" runat="server" />
                 
      <input type="hidden" id="eventtype2" runat="server" />
      <input type="hidden" id="eventtype" runat="server" />
      <input type="hidden" id="eventargs" runat="server" />
      <asp:Button ID="eventfire" runat="server" style="display:none" OnClick="eventfiresub" />
            <div style="visibility:hidden">
        <asp:Button ID="cmdPrev" runat="server" Text=" << " class="form-submit" CausesValidation="false" UseSubmitBehavior="false" OnClick="cmdPrev_Click" />
        <asp:Button ID="cmdNext" runat="server" Text=" >> " class="form-submit" CausesValidation="false" UseSubmitBehavior="false" OnClick="cmdNext_Click" />
          	             
      </div>      

      
      
</form>
</div>
</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">  

<script language="javascript" type="text/javascript">
$(document).ready(function() {
<asp:Literal runat="server" ID="litsettings"></asp:Literal>
<asp:Literal runat="server" ID="litsettings2"></asp:Literal>

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
   var table2 = $('#caishtb2').DataTable();     
    $('#caishtb2 tbody').on('click', 'tr', function () {
        var data2 = table2.row( this ).data();
        $('#<%=table2sel.clientid%>').val(data2[0]);
         if (data2[0].trim()!="")
        {
         if ( $(this).hasClass('selected') ) {
            $(this).removeClass('selected');
         }
        else {
            table2.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
          }
         }

        
    });          
});
</script>
</asp:Content>  
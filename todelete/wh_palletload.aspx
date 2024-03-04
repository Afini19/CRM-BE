<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="wh_palletload.aspx.vb" Inherits="wh_palletload_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
<link rel="stylesheet" type="text/css" href="Datatables/datatables.min.css"/>
<script type="text/javascript" src="Datatables/datatables.min.js"></script>

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div>
<form id="frmform" runat="server" class="theform">
<h5><asp:Literal runat="server" ID="littitle"></asp:Literal></h5>


        <div class="row">    
            <div class="col s12 m12">
             <label for="">Pallet No : <b><asp:Literal runat="server" ID="litpalletno"></asp:Literal></b></label>
            </div>
        </div>
        <div class="row">    
            <div class="col s12 m12">
             <label for="">Location / Bin : <b><asp:Literal runat="server" ID="litlocation"></asp:Literal></b></label>
            </div>
        </div>
        <div class="row">    
            <div class="col s12 m12">
             <label for="">Branch : <%=Weblib.BranchName%></label>
            </div>
        </div>


    <div class="row">
                    <div class="col s12 m4">
                    <table id="caishtb" class="hover stripe cell-border nowrap order-column" width="100%">
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
  </div>
    

    <div class="row">    
        <div class="col s12 m2">
             <asp:Button ID="btnback" runat="server" Text="<< BACK" class="btn waves-effect waves-light cyan darken-4 caishbutton"  OnClick="backback" />
        </div>
    </div>
   

       	  <asp:Repeater ID="rptPaging" runat="server">
            <ItemTemplate>
                    <asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" ><%# Container.DataItem %></asp:LinkButton>
           </ItemTemplate>
        </asp:Repeater>

      <input type="hidden" id="table1sel" runat="server" />
      <input type="hidden" id="table1sel2" runat="server" />
      <input type="hidden" id="uid" runat="server" />                 
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
        $('#<%=table1sel2.clientid%>').val(data[1]);

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






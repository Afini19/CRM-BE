<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="selectbranch.aspx.vb" Inherits="selectbranch_class" MasterPageFile="~/SitePopup.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
<%=TableUtils.OveridingTheme()%>
</asp:Content>  

<asp:Content ID="cttopbody" ContentPlaceHolderID="topbody" runat="server">  
<!--#include File="~/navbarl4.aspx"-->
</asp:Content>  

<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
<link rel="stylesheet" type="text/css" href="../Datatables/datatables.min.css"/>
<script type="text/javascript" src="../Datatables/datatables.min.js"></script>
</asp:Content>  
<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
        <div class="caishformlist">
        <form id="frmform" runat="server" class="theform">
        <div class="pagetitle"><%=PageTitle%></div>
        <br />
        <div>
        Current Login Company : <b><%=WebLib.MerchantName%>(<%=WebLib.MerchantID%>)</b><br />
        Current Login Branch : <b><%=WebLib.BranchName%></b>
        </div>
        <div style="width:100%">
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

      <input type="hidden" id="popupparam1" runat="server" />
      <input type="hidden" id="table1sel0" runat="server" />
      <input type="hidden" id="selobj" runat="server" />
      <input type="hidden" id="eventtype2" runat="server" />
      <input type="hidden" id="eventtype" runat="server" />
      <input type="hidden" id="eventargs" runat="server" />
      <asp:Button ID="eventfire" runat="server" UseSubmitBehavior="false"  style="display:none" OnClick="eventfiresub" />
      <asp:Button ID="eventfirenorm" runat="server" UseSubmitBehavior="false"  style="display:none" OnClick="eventfiresub" />
            
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
        $('#<%=table1sel0.clientid%>').val("");
        if (data != null)
        {     
            var seldata = data[table.column('uid:name').index()] + "";
            if (seldata.trim()!="")
                {
                $('#<%=table1sel0.clientid%>').val(seldata);
                performdrill();
                }
        }
     });  
   
  $('#topnavsearchbox').on( 'keyup', function () {
    table.search($('#topnavsearchbox').val()).draw();
  } );
 });

function performdrill()
{
    $('[id*=<%=eventfirenorm.clientid%>]').click();
}

</script>
</asp:Content>  
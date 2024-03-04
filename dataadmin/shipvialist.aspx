<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="shipvialist.aspx.vb" Inherits="shipvialist_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
<%=TableUtils.OveridingTheme()%>
</asp:Content>  

<asp:Content ID="cttopbody" ContentPlaceHolderID="topbody" runat="server">  
<!--#include File="~/navbarl2.aspx"-->
<!--#include File="~/navbarleft.aspx"-->
</asp:Content>  

<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
<link rel="stylesheet" type="text/css" href="../officeonetables/officeonetables.min.css"/>
<script type="text/javascript" src="../officeonetables/officeonetables.min.js"></script>
</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform" <%=Framework_MenuLeftCSS%>>
<form id="frmform" runat="server" class="theform">

<div class="pagetitle"><%=PageTitle%></div>

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
<br />
       <input type="hidden" id="table1sel0" runat="server" />                 
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
                }
        }
     });  
   
   
  $('#topnavsearchbox').on( 'keyup', function () {
    table.search($('#topnavsearchbox').val()).draw();
  });
  
 });

</script>
</asp:Content>  
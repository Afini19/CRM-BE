<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="secrolelist.aspx.vb" Inherits="secrolelist_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
<%=TableUtils.OveridingTheme()%>
</asp:Content>  

<asp:Content ID="cttopbody" ContentPlaceHolderID="topbody" runat="server">  
<!--#include File="~/navbarl2.aspx"-->
        <div class="fixed-action-btn">
        <a class="btn-floating btn-large waves-effect waves-light cyan darken-4" onclick="$('#<%=eventtype.clientid%>').val('ADD');$('[id*=<%=eventfire.clientid%>]').click();"><i class="material-icons">add</i></a>
        </div>
</asp:Content>  

<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
        <link rel="stylesheet" type="text/css" href="<%= Page.ResolveClientUrl("~/Datatables/datatables.min.css")%>"/>
        <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Datatables/datatables.min.js")%>"></script>        
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
     <div class="col s12 m9">
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
    </div>
     <div class="col s12 m3">
     <%If Framework_StatsPage.trim <> "" Then%>
     <iframe style="display: block;width:100%;bottom:0;top:0;height:100vh" frameborder="0" allowfullscreen src="<%=Framework_StatsPage%>">

     </iframe>
     <%End If%>
     
     </div>   
    </div>

     <input type="hidden" id="table1sel" runat="server" />
     <input type="hidden" id="eventtype2" runat="server" />
     <input type="hidden" id="eventtype" runat="server" />
     <input type="hidden" id="eventargs" runat="server" />
     <asp:Button ID="eventfire" runat="server" UseSubmitBehavior="false"  style="display:none" OnClick="eventfiresub" />

</form>
</div>
</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">  

<!--Page Option Status Filter -->   
 <ul id='itemseloption' class='dropdown-content'>
    <li><a href="#!"><i class="material-icons">view_module</i>Edit Record</a></li>
    <li><a href="#!"><i class="material-icons">cloud</i>Delete Record</a></li>
  </ul>
<!-- End of DropDown -->  

<!--Page Option Status Filter -->   
   <ul id='pagedtfilteroption' class='dropdown-content' style="background-color:white">
    <li><a href="#!" onclick="$('#<%=eventtype.clientid%>').val('STATUS');$('[id*=<%=eventfire.clientid%>]').click();"><i class="material-icons">view_quilt</i>Pending</a></li>
    <li><a href="#!" onclick="$('#<%=eventtype.clientid%>').val('STATUS');$('[id*=<%=eventfire.clientid%>]').click();"><i class="material-icons">view_compact</i>Closed</a></li>
    <li><a href="#!" onclick="$('#<%=eventtype.clientid%>').val('STATUS');$('[id*=<%=eventfire.clientid%>]').click();"><i class="material-icons">view_column</i>Cancelled</a></li>
  </ul>  
<!-- End of DropDown -->  

<!--Page Option DropDown -->   
  <ul id='pageseloption' class='dropdown-content' style="background-color:white; line-height:0.8">
    <li><a href="#!" onclick="$('#<%=eventtype.clientid%>').val('ADD');$('[id*=<%=eventfire.clientid%>]').click();"><i class="material-icons">add</i>New</a></li>
    <li><a href="#!" onclick="$('#<%=eventtype.clientid%>').val('EDIT');$('[id*=<%=eventfire.clientid%>]').click();"><i class="material-icons">edit</i>Edit Selected</a></li>
<%If Framework_Back.trim <> "" Then%>
    <li class="divider" tabindex="-1"></li>
    <li><a href="<%=Framework_Back.trim%>"><i class="material-icons">keyboard_arrow_left</i>Back</a></li>
<%End If%>
  </ul>
<!-- End of DropDown -->  
  
  
  
<script language="javascript" type="text/javascript">
$(document).ready(function() {
   <asp:Literal runat="server" ID="litsettings"></asp:Literal>  
   var table = $('#caishtb').DataTable();    
   
  $('#topnavsearchbox').on( 'keyup', function () {
    table.search($('#topnavsearchbox').val()).draw();
    });
    
    $('#caishtb tbody').on('click', 'tr', function () {
        var data = table.row(this).data();
        $('#<%=table1sel.clientid%>').val(data[0]);
         if (data[0].trim()!="")
         {
 //        alert(data[table.column('templatecode:name').index()] + "");
         }         
     });    
});
</script>
</asp:Content>  
<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="voucherblast.aspx.vb" Inherits="voucherblast_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
<%=TableUtils.OveridingTheme()%>
</asp:Content>  

<asp:Content ID="cttopbody" ContentPlaceHolderID="topbody" runat="server">  
<!--#include File="~/navbarl2.aspx"-->

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
<link rel="stylesheet" type="text/css" href="../officeonetables/officeonetables.min.css"/>
<script type="text/javascript" src="../officeonetables/officeonetables.min.js"></script>
</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">

<form id="frmform" runat="server" class="theform">
    <div class="row">       
     <div class="col s12 m9">
            <div class="pagetitle"><%=PageTitle%></div>
    </div>
     <div class="col s12 m3">

     
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
<asp:Button ID="btnstep3" runat="server" Text="STEP 3 - Update to DB" class="btn waves-effect waves-light red darken-4 caishbutton"  OnClick="confirmdata" />
</div>

<div class="col s12 m2">

</div>


</div>
<div class="divider"></div>
<br />
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




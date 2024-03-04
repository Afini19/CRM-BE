<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="popup-gallery.aspx.vb" Inherits="popupgallery_class" MasterPageFile="~/SitePopup.Master" %>  

<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content> 

<asp:Content ID="cttopbody" ContentPlaceHolderID="topbody" runat="server">  
<!--#include File="~/navbarl4.aspx"-->
</asp:Content>  

<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
<link rel="stylesheet" type="text/css" href="../officeonetables/officeonetables.min.css"/>
<script type="text/javascript" src="../officeonetables/officeonetables.min.js"></script>
</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
        <div class="caishformlist">
        <form id="frmform" runat="server" class="theform">
                        <div class="pagetitle"><%=PageTitle%></div>

                  

      <input type="hidden" id="popupparam1" runat="server" />
      <input type="hidden" id="popupparam2" runat="server" />
      <input type="hidden" id="popupparam3" runat="server" />
      <input type="hidden" id="popupparam4" runat="server" />
      <input type="hidden" id="uid" runat="server" />                                                                                                                                             
      <input type="hidden" id="pns" runat="server" />
      <input type="hidden" id="table1sel0" runat="server" />
      <input type="hidden" id="partuid" runat="server" />
       <input type="hidden" id="table1sel1" runat="server" />
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
    
    });
</script>
</asp:Content>  
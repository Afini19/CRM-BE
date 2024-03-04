<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="menusplash.aspx.vb" Inherits="menusplash_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="cttopbody" ContentPlaceHolderID="topbody" runat="server">  
<!--#include File="navbarl2.aspx"-->
</asp:Content>  



<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<h5><%=PageTitle%></h5>
<br /><br />


       
<input type="hidden" id="uid" runat="server" />                                                                                                                                             
                                                                                                                                                       
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
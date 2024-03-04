<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="printgrn.aspx.vb" Inherits="printgrn_class" MasterPageFile="~/Site.Master" %>  
<%@ Register assembly="Stimulsoft.Report.Web, Version=2021.3.3.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a" namespace="Stimulsoft.Report.Web" tagprefix="cc1" %>

<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="cttopbody" ContentPlaceHolderID="topbody" runat="server">  
<!--#include File="~/navbarl2.aspx"-->
</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  

	<cc1:StiWebViewer ID="StiWebViewer1" runat="server"
		OnGetReport="StiWebViewer1_GetReport">
	</cc1:StiWebViewer>

</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
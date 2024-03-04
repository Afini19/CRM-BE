<%@ Page Title="Report.mrt - Viewer" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebApplication._Default" %>
<%@ Register assembly="Stimulsoft.Report.Web, Version=2021.3.3.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a" namespace="Stimulsoft.Report.Web" tagprefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<cc1:StiWebViewer ID="StiWebViewer1" runat="server"
		OnGetReport="StiWebViewer1_GetReport">
	</cc1:StiWebViewer>

</asp:Content>
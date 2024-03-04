<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="popup-printgrn.aspx.vb" Inherits="popupprintgrn_class" MasterPageFile="~/SitePopup.Master" %>  
<%@ Register assembly="Stimulsoft.Report.Web, Version=2021.3.3.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a" namespace="Stimulsoft.Report.Web" tagprefix="cc1" %>

<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
<%=TableUtils.OveridingTheme()%>
</asp:Content> 

<asp:Content ID="cttopbody" ContentPlaceHolderID="topbody" runat="server">  
</asp:Content>  

<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
        <form id="frmform" runat="server" class="theform">
                  
      <cc1:StiWebViewer ID="StiWebViewer1" runat="server"
		OnGetReport="StiWebViewer1_GetReport">
	</cc1:StiWebViewer>

      <input type="hidden" id="popupparam1" runat="server" />
      <input type="hidden" id="popupparam2" runat="server" />
      <input type="hidden" id="popupparam3" runat="server" />
      <input type="hidden" id="table1sel" runat="server" />
      <input type="hidden" id="uid" runat="server" />
      <input type="hidden" id="puid" runat="server" />
      <input type="hidden" id="uomuid" runat="server" />
      <input type="hidden" id="table1sel0" runat="server" />
      <input type="hidden" id="partuid" runat="server" />
      <input type="hidden" id="partname" runat="server" />
      <input type="hidden" id="partcode" runat="server" />
      <input type="hidden" id="partatt1" runat="server" />
      <input type="hidden" id="partatt2" runat="server" />
      <input type="hidden" id="partatt3" runat="server" />
      <input type="hidden" id="partexp" runat="server" />
      <input type="hidden" id="partmanual" runat="server" />

      <input type="hidden" id="table1sel1" runat="server" />
      <input type="hidden" id="selobj" runat="server" />
      <input type="hidden" id="eventtype2" runat="server" />
      <input type="hidden" id="eventtype" runat="server" />
      <input type="hidden" id="eventargs" runat="server" />
      <asp:Button ID="eventfire" runat="server" UseSubmitBehavior="false"  style="display:none" OnClick="eventfiresub" />
      <asp:Button ID="eventfirenorm" runat="server" UseSubmitBehavior="false"  style="display:none" OnClick="eventfiresub" />
            
</form>
</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">  

<script language="javascript" type="text/javascript">
$(document).ready(function() {


    });
</script>
</asp:Content>  
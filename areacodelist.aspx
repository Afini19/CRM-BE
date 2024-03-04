<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="areacodelist.aspx.vb" Inherits="areacodelist_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
<link rel="stylesheet" type="text/css" href="<%= Page.ResolveClientUrl("~/css/table.css")%>">    	
<asp:Literal ID="litTableCSS" runat="server"></asp:Literal>
</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishformlist">
<form id="frmform" runat="server" class="theform">
<h5>Area Code Maintenance</h5>

        <div class="fixed-action-btn">
      <a class="btn-floating btn-large light-blue darken-4" href="<%=PageDetail%>">
        <i class="large material-icons">mode_edit</i>
      </a>
    </div>
    	<div class="container-table100">
    	

    	
    	
	    <div class="wrap-table100">
		<div class="table">
                        <asp:Literal ID="litTableHeader" runat="server"></asp:Literal>
                        <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand" >
                        <ItemTemplate>
                        <asp:Literal ID="litTableRows" runat="server"></asp:Literal>
                        </ItemTemplate>
                        </asp:Repeater>
		</div>
		</div>
		</div>
      
      
       	  <asp:Repeater ID="rptPaging" runat="server">
            <ItemTemplate>
                    <asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" ><%# Container.DataItem %></asp:LinkButton>
           </ItemTemplate>
        </asp:Repeater>

      <input type="hidden" id="eventtype2" runat="server" />
      <input type="hidden" id="eventtype" runat="server" />
      <input type="hidden" id="eventargs" runat="server" />
      <asp:Button ID="eventfire" runat="server" style="display:none" OnClick="eventfiresub" />
            <div style="visibility:hidden">
          	             <asp:Button ID="btnADD" runat="server" Text="Add" class="form-submit" OnClick="adddata" />
        <asp:Button ID="cmdPrev" runat="server" Text=" << " class="form-submit" CausesValidation="false" UseSubmitBehavior="false" OnClick="cmdPrev_Click" />
        <asp:Button ID="cmdNext" runat="server" Text=" >> " class="form-submit" CausesValidation="false" UseSubmitBehavior="false" OnClick="cmdNext_Click" />
          	             
      </div>      

      
      
</form>
</div>
</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">  


</asp:Content>  
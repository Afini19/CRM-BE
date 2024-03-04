<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="listing.aspx.vb" Inherits="namec_list_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
<link rel="stylesheet" type="text/css" href="<%= Page.ResolveClientUrl("~/css/table.css")%>">    	
<asp:Literal ID="litTableCSS" runat="server"></asp:Literal>
</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<form id="frmform" runat="server" class="theform">
    
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
      
      
        <asp:Button ID="cmdPrev" runat="server" Text=" << " class="form-submit" CausesValidation="false" UseSubmitBehavior="false" OnClick="cmdPrev_Click" />
        <asp:Button ID="cmdNext" runat="server" Text=" >> " class="form-submit" CausesValidation="false" UseSubmitBehavior="false" OnClick="cmdNext_Click" />
       	  <asp:Repeater ID="rptPaging" runat="server">
            <ItemTemplate>
                    <asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" ><%# Container.DataItem %></asp:LinkButton>
           </ItemTemplate>
        </asp:Repeater>

      <input type="hidden" id="eventtype" runat="server" />
      <input type="hidden" id="eventargs" runat="server" />
      <asp:Button ID="eventfire" runat="server" style="display:none" OnClick="eventfiresub" />
      
      
      
</form>
</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">  


</asp:Content>  
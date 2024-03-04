<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="admin-productlist.aspx.vb" Inherits="adminproductlist_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
<link rel="stylesheet" type="text/css" href="<%= Page.ResolveClientUrl("~/css/table.css")%>">    	
<asp:Literal ID="litTableCSS" runat="server"></asp:Literal>
</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishformlist">
<form id="frmform" runat="server" class="theform">

        
        <div class="section">
        <asp:Literal runat="server" id="litfiter"></asp:Literal>
        <div class="left"><h5><%=PageTitle%></h5></div>
        <div class="right">
        <button  data-target="searchbox" class="btn waves-effect light-blue darken-3 waves-light modal-trigger" type="submit">
            <i class="material-icons">search</i>
        </button>    	
        </div>
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

<!--#include File="searchmenu/searchproduct.aspx"-->
      
</form>

<script language="javascript">
  $(document).ready(function(){
    $('.modal').modal();
  });
</script>

</div>
</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">  


</asp:Content>  
<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="menuproduct.aspx.vb" Inherits="menuproduct_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<h5><%=PageTitle%></h5>
<br /><br />

<div class="teal-text"><b>MERCHANT FEATURES</b></div><br />
<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">folder</i>
    </div>
   <div class="col s11 m11">
          <a href="productaddlist.aspx" class="waves-effect" style="text-decoration:none">
          <b>Add a New Product</b><br />
          Create a new product for my Store         
          </a>                   
    </div>
</div>
<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">folder</i>
    </div>
   <div class="col s11 m11">
          <a href="productlist.aspx" class="waves-effect" style="text-decoration:none">
          <b>View Existing Product</b><br />
          View all products created for my store        
          </a>                   
    </div>
</div>

   
<% If WebLib.UserIsFullAdmin = True Then%>
<div class="divider"></div>
<br />
<div class="teal-text"><b>PLATFORM FEATURES</b></div><br />

<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">search</i>
    </div>
   <div class="col s11 m11">
          <a href="admin-productlist.aspx" class="waves-effect" style="text-decoration:none">
          <b>Search Existing Product by Merchant</b><br />
          Search for existing product by Merchant/Code/Name and etc        
          </a>                   
    </div>
</div>

<%end if%>
       
<input type="hidden" id="uid" runat="server" />                                                                                                                                             
                                                                                                                                                       
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
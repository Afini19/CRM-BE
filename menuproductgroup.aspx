<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="menuproductgroup.aspx.vb" Inherits="menuproductgroup_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<h5><%=PageTitle%></h5>
<br /><br />


<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">folder</i>
    </div>
   <div class="col s11 m11">
          <a href="productfilterlist.aspx" class="waves-effect" style="text-decoration:none">
          <b>Product Parent Grouping</b><br />
          Top level product grouping. Will be listed on product selection screen          
          </a>                   
    </div>
</div>
<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">folder</i>
    </div>
   <div class="col s11 m11">
          <a href="productcatlist.aspx" class="waves-effect" style="text-decoration:none">
          <b>Product Main Category</b><br />
          2nd level product grouping below Product Parent Grouping. Will be listed on product selection screen          
          </a>                   
    </div>
</div>

<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">folder</i>
    </div>
   <div class="col s11 m11">
          <a href="productcatlist3.aspx" class="waves-effect" style="text-decoration:none">
          <b>Product Sub Category</b><br />
          <b>Optional</b>. Sub Categories of products. To be tagged directly to a product. Can be used for "Brand,Promotion Category" and etc.
          </a>                   
    </div>
</div>

<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">folder</i>
    </div>
   <div class="col s11 m11">
          <a href="productvariantlist.aspx" class="waves-effect" style="text-decoration:none">
          <b>Product Variant</b><br />
          <b>Optional</b>. For Product Attributes. Such as Color , Size, Packing and Types. Will appear at product creation page "VARIANT" tab.
          </a>                   
    </div>
</div>
       
<input type="hidden" id="uid" runat="server" />                                                                                                                                             
                                                                                                                                                       
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
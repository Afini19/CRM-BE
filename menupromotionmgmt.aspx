<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="menupromotionmgmt.aspx.vb" Inherits="menupromotionmgmt_class" MasterPageFile="~/Site.Master" %>  
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
          <a href="#" class="waves-effect" style="text-decoration:none">
          <b>Add-Ons</b><br />
          Customer buy Product A and pay top-up amount for Product B.        
          </a>                   
    </div>
</div>
<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">folder</i>
    </div>
   <div class="col s11 m11">
          <a href="productcatlist.aspx" class="waves-effect" style="text-decoration:none">
          <b>Discount Code</b><br />
         Provide discount in value for total purchase. By Bill Level         
          </a>                   
    </div>
</div>

<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">folder</i>
    </div>
   <div class="col s11 m11">
          <a href="productcatlist3.aspx" class="waves-effect" style="text-decoration:none">
          <b>Gift With Purchase (GWP)</b><br />
          To auto tag free items into order by purchased item. 
          </a>                   
    </div>
</div>


       
<input type="hidden" id="uid" runat="server" />                                                                                                                                             
                                                                                                                                                       
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
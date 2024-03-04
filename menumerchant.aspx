<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="menumerchant.aspx.vb" Inherits="menumerchant_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<h5><%=PageTitle%></h5>



<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">folder</i>
    </div>
   <div class="col s11 m11">
          <a href="registrationlist.aspx" class="waves-effect" style="text-decoration:none">
          <b>Merchant Registration</b><br />
          To register a merchant account       
          </a>                   
    </div>
</div>
<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">account_balance</i>
    </div>
   <div class="col s11 m11">
          <a href="banklist.aspx" class="waves-effect" style="text-decoration:none">
          <b>Bank Maintenance</b><br />
          To create bank records. To be used in merchant registration, merchant bank         
          </a>                   
    </div>
</div>

<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">add_location</i>
    </div>
   <div class="col s11 m11">
          <a href="areacodelist.aspx" class="waves-effect" style="text-decoration:none">
          <b>Area Code</b><br />
          To create the area code that is merchant is attached to. Delivery schedule time slot is based on area code
          </a>                   
    </div>
</div>

<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">view_comfy</i>
    </div>
   <div class="col s11 m11">
          <a href="areastatelist.aspx" class="waves-effect" style="text-decoration:none">
          <b>State</b><br />
          To create "state" records. For Example : Selangor, Kedah, Melaka and etc 
          </a>                   
    </div>
</div>
       
<input type="hidden" id="uid" runat="server" />                                                                                                                                             
                                                                                                                                                       
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
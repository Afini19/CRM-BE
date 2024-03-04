<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="menudelivery.aspx.vb" Inherits="menudelivery_class" MasterPageFile="~/Site.Master" %>  
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
          <a href="deliveryplist.aspx" class="waves-effect" style="text-decoration:none">
          <b>Delivery Partner</b><br />
          To register a delivery partner       
          </a>                   
    </div>
</div>
<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">alarm_on</i>
    </div>
   <div class="col s11 m11">
          <a href="deliverytslotlist.aspx" class="waves-effect" style="text-decoration:none">
          <b>Delivery Time Slot</b><br />
          To create delivery time slot by area code        
          </a>                   
    </div>
</div>

<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">local_shipping</i>
    </div>
   <div class="col s11 m11">
          <a href="#" class="waves-effect" style="text-decoration:none">
          <b>Delivery Charges</b><br />
          To define delivery charges by delivery partner
          </a>                   
    </div>
</div>

       
<input type="hidden" id="uid" runat="server" />                                                                                                                                             
                                                                                                                                                       
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
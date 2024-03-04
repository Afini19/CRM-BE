<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="menusys.aspx.vb" Inherits="menusys_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<div class="pagetitle"><%=PageTitle%></div>
<div class="divider"></div>

<br />
<div class="sectiontitle"><b>Users and Security</b></div><br />
<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">folder</i>
    </div>
   <div class="col s11 m11">
          <a href="secrolelist.aspx" class="waves-effect" style="text-decoration:none">
          <b>User Role Settings</b><br />
             Each users are are linked to a role. Access Controls are based on Role                        
          </a>                   
    </div>
</div>
<div class="row">    
    <div class="col s1 m1">
    <i class="material-icons" style="min-width:32px">folder</i>
    </div>
   <div class="col s11 m11">
          <a href="secrolelistset.aspx" class="waves-effect" style="text-decoration:none">
          <b>User Role Security Rights Matrix</b><br />
             To set matrix by role
          </a>                   
    </div>
</div>

          
<input type="hidden" id="uid" runat="server" />                                                                                                                                             
                                                                                                                                                       
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
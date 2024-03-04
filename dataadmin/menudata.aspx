<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="menudata.aspx.vb" Inherits="menudata_class" MasterPageFile="~/Site.Master" %>  
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

<div class="row">    
    <div class="col s12 m4">



        <div class="teal-text"><b>Product Maitenance</b></div><br />
         <div class="row">    
                <div class="col s1 m1">
            <i class="material-icons" style="min-width:32px">folder</i>
            </div>
           <div class="col s11 m11">
                  <a href="productlist.aspx" class="waves-effect" style="text-decoration:none">
                  <b>To Maintain Product Details</b><br />
                                             
                  </a>                   
            </div>
            </div>
            <div class="row">    
                <div class="col s1 m1">
                <i class="material-icons" style="min-width:32px">folder</i>
                </div>
               <div class="col s11 m11">
                      <a href="productpluadminlist.aspx" class="waves-effect" style="text-decoration:none">
                      <b>Product PLU/UPC Maintenance</b><br />
                         To view / maintain product PLU/UPC
                      </a>                   
                </div>
            </div>



        <br />   
        <div class="teal-text"><b>Branch Related Data</b></div><br />
         <div class="row">    
                <div class="col s1 m1">
            <i class="material-icons" style="min-width:32px">folder</i>
            </div>
           <div class="col s11 m11">
                  <a href="trackingpointslist.aspx" class="waves-effect" style="text-decoration:none">
                  <b>Tracking Points Management</b><br />
                     To upload products list by tracking points                         
                  </a>                   
            </div>
            </div>
            <div class="row">    
                <div class="col s1 m1">
                <i class="material-icons" style="min-width:32px">folder</i>
                </div>
               <div class="col s11 m11">
                      <a href="branchclassitemlist.aspx" class="waves-effect" style="text-decoration:none">
                      <b>View Article by Branch Class</b><br />
                         To view articles by branch class
                      </a>                   
                </div>
            </div>
             <div class="row">    
                <div class="col s1 m1">
                <i class="material-icons" style="min-width:32px">folder</i>
                </div>
               <div class="col s11 m11">
                      <a href="branchextlist.aspx" class="waves-effect" style="text-decoration:none">
                      <b>Branch Extended Settings</b><br />
                         To set additional branch level operation settings
                      </a>                   
                </div>
            </div>
           
         <br />   
         <div class="teal-text"><b>Warehouse Related Data</b></div><br />
         <div class="row">    
                <div class="col s1 m1">
            <i class="material-icons" style="min-width:32px">folder</i>
            </div>
           <div class="col s11 m11">
                  <a href="zonelist.aspx" class="waves-effect" style="text-decoration:none">
                  <b>Zone Master</b><br />
                     To Define Zone Codes                   
                  </a>                   
            </div>
            </div>


         <div class="row">    
                <div class="col s1 m1">
            <i class="material-icons" style="min-width:32px">folder</i>
            </div>
           <div class="col s11 m11">
                  <a href="zonesupload.aspx" class="waves-effect" style="text-decoration:none">
                  <b>Warehouse Zones and Priority</b><br />
                     To setup warehouse zones and priorities                     
                  </a>                   
            </div>
            </div>
            



    </div>
    <div class="col s12 m4">

        <div class="teal-text"><b>Global Data Updates</b></div><br />
        <div class="row">    
                <div class="col s1 m1">
            <i class="material-icons" style="min-width:32px">folder</i>
            </div>
           <div class="col s11 m11">
                  <a href="productupload.aspx" class="waves-effect" style="text-decoration:none">
                  <b>Product Global Upload</b><br />
                     To upload Product Data into System                       
                  </a>                   
            </div>
            </div>
        <div class="row">    
                <div class="col s1 m1">
            <i class="material-icons" style="min-width:32px">folder</i>
            </div>
           <div class="col s11 m11">
                  <a href="uomupload.aspx" class="waves-effect" style="text-decoration:none">
                  <b>UOM Global Upload</b><br />
                     To upload UOM Data into System                       
                  </a>                   
            </div>
            </div>
        <div class="row">    
                <div class="col s1 m1">
            <i class="material-icons" style="min-width:32px">folder</i>
            </div>
           <div class="col s11 m11">
                  <a href="pluupload.aspx" class="waves-effect" style="text-decoration:none">
                  <b>PLU Global Upload</b><br />
                     To upload PLU Data into System                       
                  </a>                   
            </div>
            </div>




         <br />
          <div class="teal-text"><b>Supplier Related Data</b></div><br />
         <div class="row">    
                <div class="col s1 m1">
            <i class="material-icons" style="min-width:32px">folder</i>
            </div>
           <div class="col s11 m11">
                  <a href="supplieritemupload.aspx" class="waves-effect" style="text-decoration:none">
                  <b>Supplier Product List Upload</b><br />
                     To upload products by supplier                         
                  </a>                   
            </div>
            </div>


    </div>
    <div class="col s12 m4">
        <%=WebMenuGeneralSet.MainMenu("")%>
        <br />
        
          <%=WebMenuFinance.Finance("")%>
        
    </div>
</div>



          
<input type="hidden" id="uid" runat="server" />                                                                                                                                             
<!--#include File="~/bottomspacing.aspx"-->
                                                                                                                                                   
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
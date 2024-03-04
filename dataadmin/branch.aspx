<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="branch.aspx.vb" Inherits="branch_class" MasterPageFile="~/Site.Master" %>  
<%@ Register Src="~/UserControls/formentry.ascx" TagPrefix="uc" TagName="AXFormEntry" %>

<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
    <asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
<link rel="stylesheet" type="text/css" href="../officeonetables/officeonetables.min.css"/>
<script type="text/javascript" src="../officeonetables/officeonetables.min.js"></script>
</asp:Content>  
<asp:Content ID="cttopbody" ContentPlaceHolderID="topbody" runat="server">  
    <!--#include File="~/navbarl3.aspx"-->
    <!--#include File="~/navbarleft.aspx"-->
    </asp:Content>  
       
    <asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
    <div class="caishform" <%=Framework_MenuLeftCSS%>>
    <form id="frmform" runat="server" class="theform2">                        
        <div class="row">       
         <div class="col s12 m9">
                <div class="pagetitle"><%=PageTitle%></div>
        </div>
         <div class="col s12 m3">

         
         </div>    
        </div>


    <div class="row">    
        <div class="col s12 m5">
                                     <div style="padding:0 0 0 0;width:50%"><uc:AXFormEntry ID="br_code" Caption="Branch Code" FieldType="text" Lookup=""  Required="true" runat="server"  /></div>                            
                                     <uc:AXFormEntry ID="br_name" Caption="Branch Name" FieldType="text" Lookup="" Required="true" runat="server"  />                            
                                     <br />                                    
                                     <uc:AXFormEntry ID="br_address1" Caption="Branch Address" FieldType="text" Lookup="" Required="true" runat="server"  />                            
                                     <uc:AXFormEntry ID="br_address2" Caption="" FieldType="text" Lookup="" Required="false" runat="server"  />                            
                                     <uc:AXFormEntry ID="br_address3" Caption="" FieldType="text" Lookup="" Required="false" runat="server"  />                            
                                     <uc:AXFormEntry ID="br_address4" Caption="" FieldType="text" Lookup="" Required="false" runat="server"  />                            
                                     <uc:AXFormEntry ID="br_attention" Caption="Attention" FieldType="text" Lookup="" Required="false" runat="server"  />                            
                                     <uc:AXFormEntry ID="br_telno" Caption="Tel No" FieldType="text" Lookup="" Required="false" runat="server"  />                            
                                     <uc:AXFormEntry ID="br_faxno" Caption="Fax No" FieldType="text" Lookup="" Required="false" runat="server"  />                            
                                     <uc:AXFormEntry ID="br_email" Caption="Email" FieldType="text" Lookup="" Required="false" runat="server"  />                            
                                    
        </div>
        <div class="col s0 m1">
        &nbsp;
        </div>
        
        <div class="col s12 m3">
        
               <%=MenuGenerator.WebPartHeader("GENERAL SETTINGS")%>

               <uc:AXFormEntry ID="br_destinationcode" Caption="Destination Code" FieldType="text" Lookup="DCODE" Required="false" runat="server"  />                            
               <uc:AXFormEntry ID="br_site" Caption="Default Site ID" FieldType="text" Lookup="SITE" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="br_class" Caption="Branch Class" FieldType="text" Lookup="BCLASS" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="br_currency" Caption="Default Currency" FieldType="text" Lookup="CURR" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="br_channel" Caption="Default Sales Channel" FieldType="text" Lookup="CHANNEL" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="br_terms" Caption="Default Sales Terms" FieldType="text" Lookup="TERMS" Required="false" runat="server"  />                            
                                    



        </div>
        <div class="col s12 m3">
        
        
               <%=MenuGenerator.WebPartHeader("LOCATION SETTINGS")%>
              
               <uc:AXFormEntry ID="br_location" Caption="Default Location" FieldType="text" Lookup="LOC" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="br_locationq" Caption="Default Quarantine Loc" FieldType="text" Lookup="LOC" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="br_locationa" Caption="Default Damage Loc" FieldType="text" Lookup="LOC" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="br_locationr" Caption="Default Return Loc" FieldType="text" Lookup="LOC" Required="true" runat="server"  />                            
              

        </div>


    </div>



           
          <input type="hidden" id="uid" runat="server" />                                                                                                                                             
          <input type="hidden" id="pns" runat="server" />
          <input type="hidden" id="table1sel" runat="server" />
      <input type="hidden" id="eventtype2" runat="server" />
      <input type="hidden" id="eventtype" runat="server" />
      <input type="hidden" id="eventargs" runat="server" />
      <asp:Button ID="eventfire" runat="server" style="display:none" OnClick="eventfiresub" />
      <asp:Button ID="eventfirenorm" runat="server"  style="display:none" OnClick="eventfiresub" />
                                                                                                                                                       
                                                                                                                                                       
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="branchext.aspx.vb" Inherits="branchext_class" MasterPageFile="~/Site.Master" %>  
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
        <div class="col s12 m3">

                    <%=MenuGenerator.WebPartHeader("LOCATION SETTINGS")%>
              
               <uc:AXFormEntry ID="br_location" Caption="Default Location" FieldType="text" Lookup="LOC" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="br_locationq" Caption="Default Quarantine Loc" FieldType="text" Lookup="LOC" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="br_locationa" Caption="Default Damage Loc" FieldType="text" Lookup="LOC" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="br_locationr" Caption="Default Return Loc" FieldType="text" Lookup="LOC" Required="true" runat="server"  />                            

                           <%=MenuGenerator.WebPartHeader("STOCK RELATED SETTINGS")%>

                            <div class="switch"><label><input type="checkbox" runat="server" id="br_lotcontrol"><span class="lever"></span>
                            Lot/Serial Enabled 
                            </label></div>                                      

                            <div class="switch"><label><input type="checkbox" runat="server" id="br_grnnoexp"><span class="lever"></span>
                            Disable Expiry  
                            </label></div>                                      
                                    
                            <div class="switch"><label><input type="checkbox" runat="server" id="br_actclass"><span class="lever"></span>
                            Enable Branch Class 
                            </label></div>                                      

                                    
        </div>
        <div class="col s12 m6">
        
                            <%=MenuGenerator.WebPartHeader("GOODS RECEIVING SETTINGS")%>

                            <div class="switch"><label><input type="checkbox" runat="server" id="br_strictarrival1"><span class="lever"></span>
                            Receiving - Must Mark Arrived Status
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="br_strictarrival2"><span class="lever"></span>
                                 Receiving - Must Enter Transporter Details / Doc Details
                            </label></div>  
                            <br />
                            <div class="switch"><label><input type="checkbox" runat="server" id="br_grnblind"><span class="lever"></span>
                            Enable Blind Receiving Mode
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="br_grnvalidate"><span class="lever"></span>
                            Enable Pallet / Ctn / Seal Check
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="br_recprompt"><span class="lever"></span>
                            Receiving Prompt Selection
                            </label></div>  
                            <br />
                            <div class="switch"><label><input type="checkbox" runat="server" id="br_itoinmode"><span class="lever"></span>
                            Inter-Branch Receiving (Manual Receiving Entry)
                            </label></div>  

                            <br />
              
                           <%=MenuGenerator.WebPartHeader("ADVANCE MODULE SETTINGS")%>
                            <div class="switch"><label><input type="checkbox" runat="server" id="br_enablepallet"><span class="lever"></span>
                            Enabled Pallet Management 
                            </label></div>  



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
<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="product.aspx.vb" Inherits="product_class" MasterPageFile="~/Site.Master" %>  
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
        <div class="col s12 m6">
                                        <%=MenuGenerator.WebPartHeader("General Details")%>

                                     <div style="padding:0 0 0 0;width:50%"><uc:AXFormEntry ID="br_code" Caption="Item Code" FieldType="text" Lookup=""  Required="true" runat="server"  /></div>                            
                                     <uc:AXFormEntry ID="br_name" Caption="Item Name" FieldType="text" Lookup="" Required="true" runat="server"  />                            
                                     <uc:AXFormEntry ID="br_address1" Caption="Description1" FieldType="text" Lookup="" Required="false" runat="server"  />                            
                                     <uc:AXFormEntry ID="br_address2" Caption="Description 2" FieldType="text" Lookup="" Required="false" runat="server"  />                            
                                            
        </div>
        <div class="col s12 m3">
                                     <%=MenuGenerator.WebPartHeader("Product Grouping")%>

                                     <uc:AXFormEntry ID="pt_department" Caption="Stock Department" FieldType="text" Lookup="LOC" Required="true" runat="server"  />                            
                                     <uc:AXFormEntry ID="pt_group" Caption="Stock Group" FieldType="text" Lookup="LOC" Required="true" runat="server"  />                            
                                     <uc:AXFormEntry ID="pt_type" Caption="Stock Type" FieldType="text" Lookup="LOC" Required="true" runat="server"  />                            
       </div>
     <div class="col s12 m3">
               <%=MenuGenerator.WebPartHeader("Lot and Issue")%>
               <uc:AXFormEntry ID="ptissuetype" Caption="Issue Type" FieldType="text" Lookup="DCODE" Required="false" runat="server"  />                            
               <div class="switch"><label><input type="checkbox" runat="server" id="br_grnvalidate"><span class="lever"></span>
               Lot/Serial Compulsory
               </label></div>  
               <br />
               <%=MenuGenerator.WebPartHeader("Warehouse Related")%>
               <uc:AXFormEntry ID="ptstoragetype" Caption="Storage Type" FieldType="text" Lookup="DCODE" Required="false" runat="server"  />                            
               <uc:AXFormEntry ID="ptshelf" Caption="Shelf Life" FieldType="text" Lookup="" Required="false" runat="server"  />                            
               <div class="switch"><label><input type="checkbox" runat="server" id="Checkbox8"><span class="lever"></span>
               High Frequency Item
               </label></div>  
               <div class="switch"><label><input type="checkbox" runat="server" id="Checkbox9"><span class="lever"></span>
               Bulk Item
               </label></div>  
               <div class="switch"><label><input type="checkbox" runat="server" id="Checkbox10"><span class="lever"></span>
               Cross-Docked Item
               </label></div>  

               

        </div>


     </div>   
    <div class="row">              
        <div class="col s12 m3">
        
               <%=MenuGenerator.WebPartHeader("Default UOM")%>
               <uc:AXFormEntry ID="pt_uom1" Caption="Base UOM" FieldType="text" Lookup="DCODE" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="pt_uom2" Caption="Sales UOM" FieldType="text" Lookup="SITE" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="pt_uom3" Caption="Purchase UOM" FieldType="text" Lookup="BCLASS" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="pt_uom4" Caption="Assembly UOM" FieldType="text" Lookup="CURR" Required="true" runat="server"  />                            
                <br />
                       
               <%=MenuGenerator.WebPartHeader("Cost Settings")%>
               <uc:AXFormEntry ID="pt_cost" Caption="Costing Method" FieldType="text" Lookup="DCODE" Required="false" runat="server"  />                            
               <uc:AXFormEntry ID="pt_base" Caption="Standard Cost" FieldType="text" Lookup="" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="pt_avg" Caption="Last Avg Cost" FieldType="text" Lookup="" Required="true" runat="server"  />                            
                <br />

        </div>
        <div class="col s12 m3">
        
        
               <%=MenuGenerator.WebPartHeader("Special Attributes")%>
                            <div class="switch"><label><input type="checkbox" runat="server" id="br_grnblind"><span class="lever"></span>
                            is Memo Item
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="Checkbox1"><span class="lever"></span>
                            Controlled Item
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="Checkbox2"><span class="lever"></span>
                            Non-Returnable Item
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="Checkbox3"><span class="lever"></span>
                            Item With Expiry
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="Checkbox4"><span class="lever"></span>
                            Central Purchase Item 
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="Checkbox5"><span class="lever"></span>
                            Enable Attribute 1
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="Checkbox6"><span class="lever"></span>
                            Enable Attribute 2
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="Checkbox7"><span class="lever"></span>
                            Enable Attribute 3
                            </label></div>  

        </div>
   
        <div class="col s12 m3">
           <%=MenuGenerator.WebPartHeader("Base Measurement")%>
               <uc:AXFormEntry ID="pt_width" Caption="Width" FieldType="text" Lookup="" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="pt_height" Caption="Height" FieldType="text" Lookup="" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="pt_thickness" Caption="Thick" FieldType="text" Lookup="" Required="true" runat="server"  />                            
            <br />            
           <%=MenuGenerator.WebPartHeader("Base Outer Measurement")%>
               <uc:AXFormEntry ID="pt_width1" Caption="Width" FieldType="text" Lookup="" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="pt_height1" Caption="Height" FieldType="text" Lookup="" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="pt_thickness1" Caption="Thick" FieldType="text" Lookup="" Required="true" runat="server"  />                            
        
        </div>
        <div class="col s12 m3">
              <%=MenuGenerator.WebPartHeader("Other Sizes")%>
               <uc:AXFormEntry ID="pt_m2" Caption="M2 Size" FieldType="text" Lookup="" Required="true" runat="server"  />                            
               <uc:AXFormEntry ID="pt_m3" Caption="M3 Size" FieldType="text" Lookup="" Required="true" runat="server"  />                            
                <br />
              <%=MenuGenerator.WebPartHeader("Product Principal")%>
               <uc:AXFormEntry ID="pt_owner" Caption="Product Owner" FieldType="text" Lookup="DCODE" Required="true" runat="server"  />                            

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
                                 
                                 
       <!--#include File="~/bottomspacing.aspx"-->
                                                                                                                      
                                                                                                                                                       
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
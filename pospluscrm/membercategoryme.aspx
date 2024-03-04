<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="membercategoryme.aspx.vb" Inherits="merbercategoryme_class" MasterPageFile="~/Site.Master" %>  
<%@ Register Src="~/UserControls/formentry.ascx" TagPrefix="uc" TagName="AXFormEntry" %>
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
<%=TableUtils.OveridingTheme()%>

</asp:Content>  

<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
<link rel="stylesheet" type="text/css" href="../officeonetables/officeonetables.min.css"/>
<script type="text/javascript" src="../officeonetables/officeonetables.min.js"></script>
</asp:Content>  


<asp:Content ID="cttopbody" ContentPlaceHolderID="topbody" runat="server">  
    <!--#include File="~/navbarl3.aspx"-->
    <!--#include File="~/navbarleftSmall.aspx"-->
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
        <div class="col s12 m4">
          <uc:AXFormEntry ID="ldc_mcode" Caption="Member Category" FieldType="text"  Lookup="CRMMCAT"  Required="true" runat="server"  />                            
          <br />
                                    Default Discount (%)<span style="color:red">*</span>
                                    <asp:TextBox id="ldc_discount" runat="server" class="form-input"></asp:TextBox>                                     
        </div>
    </div>
    <div class="row">    
        <div class="col s12 m4">
                                              <div class="switch"><label><input type="checkbox" runat="server" id="chkactive"><span class="lever"></span>
                            Active ?
                            </label></div>                                                                 
        </div>
    </div>
    
    
        <div class="row">    
        <div class="col s12 m4">
        
            <%=MenuGenerator.WebPartHeader("QUALIFICATION")%>
                                    Spending From<span style="color:red">*</span>
                                    <asp:TextBox id="ldc_from" runat="server" class="form-input"></asp:TextBox>   
                                    <br />
                                      Spending To<span style="color:red">*</span>
                                    <asp:TextBox id="ldc_to" runat="server" class="form-input"></asp:TextBox>                                                                    


                            <div class="switch"><label><input type="checkbox" runat="server" id="chkbyamt"><span class="lever"></span>
                            By Amount 
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="chkbyfreq"><span class="lever"></span>
                            By Frequency 
                            </label></div>        
                                                  
        </div>
             <div class="col s12 m4">
     <%=MenuGenerator.WebPartHeader("MAINTAINING QUALIFICATION")%>                                      
                         
                            
                               Spending from<span style="color:red">*</span>
                                   <asp:TextBox id="ldc_from1" runat="server" class="form-input"></asp:TextBox>   
                                    <br />
                                      Spending To<span style="color:red">*</span>
                                    <asp:TextBox id="ldc_to1" runat="server" class="form-input"></asp:TextBox>                                                                    


                            <div class="switch"><label><input type="checkbox" runat="server" id="chkbyamt1"><span class="lever"></span>
                            By Amount 
                            </label></div>  
                            <div class="switch"><label><input type="checkbox" runat="server" id="chkbyfreq1"><span class="lever"></span>
                            By Frequency 
                            </label></div>                               
 
 
                            <br />
                            <div class="switch"><label><input type="checkbox" runat="server" id="chkmaintain"><span class="lever"></span>
                            Enable Maintaining Control                          
                            </label></div>   
                            <br />
 
 
 
            </div>        
    </div>

        <div class="row">    
        <div class="col s12 m4">
        
            <%=MenuGenerator.WebPartHeader("POINTS COLLECTION RATE")%>
              Every Dollar Value<span style="color:red">*</span>
                                    <asp:TextBox id="ldc_pointbase" runat="server" class="form-input"></asp:TextBox>
                                    <br />
                                      Equivalent To Points<span style="color:red">*</span>
                                    <asp:TextBox id="ldc_pointrate" runat="server" class="form-input"></asp:TextBox>                                                                    
 
 
        
            <%=MenuGenerator.WebPartHeader("POINTS TO PAYMENT RATE")%>
              Every Points Value<span style="color:red">*</span>
                                    <asp:TextBox id="ldc_paypointsfrom" runat="server" class="form-input"></asp:TextBox>
                                    <br />
                                      Equivalent To Dollar Value<span style="color:red">*</span>
                                    <asp:TextBox id="ldc_paypointsto" runat="server" class="form-input"></asp:TextBox>                                                                    
 
        </div>
        
        
         
                                <div class="col s12 m4">
                                
                                        <%=MenuGenerator.WebPartHeader("CARD IMAGE")%>                                        
                                        <span style="font-size:0.9em">This image appears at the CRM</span>
                                        <div class="file-field input-field">
                                          <div class="btn light-blue">
                                            <span>File</span>
                                            <input type="file" runat="server" id="UploadedFile">
                                          </div>
                                          <div class="file-path-wrapper">
                                            <input class="file-path validate" type="text" placeholder="Select File">
                                          </div>
                                         </div>
                                         <input type="hidden" runat="server" id="filename1" />
                                         <asp:Button ID="uploadbutton" runat="server" Text="Upload Image" class="btn waves-effect waves-light grey darken-3 caishbutton" OnClick="uploadbutton_click" />
                                         <asp:Button ID="deletebutton" runat="server" Text="Delete Image" class="btn waves-effect waves-light grey darken-2 caishbutton" OnClick="deletebutton_click"  />


                                        <center>
                                        <h6>Image Preview</h6>
                                        <div>
                                        <asp:Literal runat="server" ID="litpreview"></asp:Literal>
                                        </div>
                                        </center>

                            </div>
        
        
    </div>
    
    
    <br /><br /><br /><br /><br />
    
    <br /><br /><br /><br /><br />    
    <br /><br /><br /><br /><br />
   
       
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
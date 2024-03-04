<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="membereventvoucher.aspx.vb" Inherits="membereventvoucher_class" MasterPageFile="~/Site.Master" %>  
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
        
        
            <%=MenuGenerator.WebPartHeader("VOUCHER DETAILS")%>
        
                                    Voucher Code<span style="color:red">*</span>
                                    <uc:AXFormEntry ID="vo_code" Caption="" FieldType="text" lookup="CRMVOU" Required="true" runat="server"  />                            
                        
                                     Voucher Name<span style="color:red">*</span>
                                    <uc:AXFormEntry ID="vo_name" Caption="" FieldType="text" enabled="false" Required="true" runat="server"  />                            
                        
                                                                       
                            <br />   
                            <div class="switch"><label><input type="checkbox" runat="server" id="chkactive"><span class="lever"></span>
                            Active ?
                            </label></div>     
                                                               
        </div>
    </div>
    
    
    
          <div class="row">    
        <div class="col s12 m4">
        
            <%=MenuGenerator.WebPartHeader("EVENT SETTINGS")%>
            
            
                 <div class="row">    
                 <div class="col s12 m6">
                        <uc:AXFormEntry ID="Eventcode" Caption="Event Code" FieldType="text" Lookup="CRMECODE" Required="false" runat="server"  />                            
                             <br />
        
                 
                        <uc:AXFormEntry ID="vo_datefrom" Caption="Effective From" FieldType="date" Required="true" runat="server"  />                            
                       <uc:AXFormEntry ID="vo_dateto" Caption="Effective To" FieldType="date" Required="true" runat="server"  />   

               

            </div>
            </div>
                 <br />
                    <b>Event URL</b> : <br />
                    <asp:Literal runat="server" ID="eventurl"></asp:Literal>
            
            
            
            <br /><br />
            
            
            <%=MenuGenerator.WebPartHeader("VALIDITY SETTINGS")%>
            
            
           
                
                            <div class="switch"><label><input type="checkbox" runat="server" id="vo_validate1"><span class="lever"></span>
                            Validity 1 - Before and After (Days)                            
                            </label></div>   
                            <br />
                            
                                      <div class="row">  
                                 <div class="col s12 m6">
                            <uc:AXFormEntry ID="vo_fromdays" Caption="Days from Event Date" FieldType="text" Required="false" runat="server"  />                            
                            </div>
                             <div class="col s12 m6">
                                                  <uc:AXFormEntry ID="vo_todays" Caption="Days After Event Date" FieldType="text" Required="false" runat="server"  />                          

                                 </div>
                            </div>
                            
                            
                            
                            <br />
                            
                            
                            
                            
                            <div class="switch"><label><input type="checkbox" runat="server" id="vo_validate2"><span class="lever"></span>
                            Validity 2 - By Event Month                            
                            </label></div>  
                             <br />
                            <div class="switch"><label><input type="checkbox" runat="server" id="vo_validate3"><span class="lever"></span>
                            Validity 3 - On Actual Event Date                            
                            </label></div>  
                            
                            <br />
                            
                            <div class="switch"><label><input type="checkbox" runat="server" id="vo_validate4"><span class="lever"></span>
                            Validity 4 - From and To (Date)                           
                            </label></div>   
                            <br />
                            
                            
                            <div class="row">  
                            <div class="col s12 m6">
                            <uc:AXFormEntry ID="vo_vdatefrom" Caption="From Date" FieldType="date" Required="false" runat="server"  />                            
                            </div>
                             <div class="col s12 m6">
                            <uc:AXFormEntry ID="vo_vdateto" Caption="To Date" FieldType="date" Required="false" runat="server"  />                          
                            </div>
                            </div>
                            <br />
            
            
            
                              
        </div>
        
        
            <div class="col s12 m4">
        
        
                <%=MenuGenerator.WebPartHeader("SIGN-UP")%>
        
                            <div class="switch"><label><input type="checkbox" runat="server" id="vo_redeembysignup"><span class="lever"></span>
                            Auto Issue on Sign-Up ?
                            </label></div>     
                            <br />
                            
 
                       <%=MenuGenerator.WebPartHeader("SELF REDEMPTION")%>
                            <div class="switch"><label><input type="checkbox" runat="server" id="vo_canredeem"><span class="lever"></span>
                            Can Redeemed
                            </label></div>     
                            <br />
                 
                             Redemption Points<span style="color:red">*</span>
                             <asp:TextBox id="vo_points" runat="server" class="form-input"></asp:TextBox>                                      
                                    
                         
                         <br /><br />
                         
  
                <%=MenuGenerator.WebPartHeader("COLLECTION")%>
        
                            <div class="switch"><label><input type="checkbox" runat="server" id="vo_cancollect"><span class="lever"></span>
                            Can Self-Collect (First Come First Serve)
                            </label></div>     
                            <br />                              
                             Max Qty<span style="color:red">*</span>
                             <asp:TextBox id="vo_qty" runat="server" class="form-input"></asp:TextBox>                                      
                                    
                                                  
                         
        </div>
        
        
        
             
            <div class="col s12 m4">
        
        
                <%=MenuGenerator.WebPartHeader("AUTO - DIRECT WALLET")%>
        
                            <div class="switch"><label><input type="checkbox" runat="server" id="vo_bday"><span class="lever"></span>
                            Birthday
                            </label></div>  
                            <br />
                            
                                     <div class="switch"><label><input type="checkbox" runat="server" id="vo_anniversary"><span class="lever"></span>
                           Wedding Anniversary 
                            </label></div>    
                            <br />
      <div class="switch"><label><input type="checkbox" runat="server" id="vo_valentines"><span class="lever"></span>
                            Valentines Day
                            </label></div>  
                            <br />
                                 <div class="switch"><label><input type="checkbox" runat="server" id="vo_christmas"><span class="lever"></span>
                            Christmas Day
                            </label></div>      
                               
                            <br />
                            <br />
                            
                                                        
     
         
        
                            
           </div>
        
    </div>
    
    
    
   
    

<br /><br />
<br /><br />
<br /><br />
<br /><br />
<br /><br />
<br /><br />
<br /><br />
<br /><br />
<br /><br />

    
    
    

   
           
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
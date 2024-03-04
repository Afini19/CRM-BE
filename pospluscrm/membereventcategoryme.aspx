<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="membereventcategoryme.aspx.vb" Inherits="merbereventcategoryme_class" MasterPageFile="~/Site.Master" %>  
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
    <!--#include File="~/navbarleftsmall.aspx"-->
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
        
            <%=MenuGenerator.WebPartHeader("EVENT SETTINGS")%>
            
            
                 <div class="row">    
                <div class="col s12 m6">
            <uc:AXFormEntry ID="lec_mcode" Caption="Member Category" FieldType="text"  Lookup="CRMMCAT"  Required="false" runat="server"  />                            
            <uc:AXFormEntry ID="lec_eventcode" Caption="Event Code" FieldType="text"  Lookup="CRMECODE"  Required="false" runat="server"  />                            
                    <br />
                </div>
            </div>
        
                    <div class="row">    
        <div class="col s12 m6">
                    <uc:AXFormEntry ID="lec_fromdate" Caption="Effective From" FieldType="date" Required="true" runat="server"  />                            
            
        </div>
         <div class="col s12 m6">
                   <uc:AXFormEntry ID="lec_todate" Caption="Effective To" FieldType="date" Required="true" runat="server"  />                      
        </div>
        </div>
        
        

                 <div class="row">           
 <div class="col s12 m6">                    
                                  Transaction Type<span style="color:red">*</span>
                                    <asp:TextBox id="lec_transtype" runat="server" class="form-input"></asp:TextBox>   

                                         
            </div>
            </div>
            
            
            
                              
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
        
            <%=MenuGenerator.WebPartHeader("DISCOUNT / POINTS SETTINGS")%>



                                    Default Discount (%)<span style="color:red">*</span>
                                    <asp:TextBox id="lec_discount" runat="server" class="form-input"></asp:TextBox>       
                                    
                                    <br />
     
                                 Every Dollar Value<span style="color:red">*</span>
                                    <asp:TextBox id="lec_pointbase" runat="server" class="form-input"></asp:TextBox>
                                    <br />
                                      Equivalent To Points<span style="color:red">*</span>
                                    <asp:TextBox id="lec_pointrate" runat="server" class="form-input"></asp:TextBox>                  
 

                                                                  
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
<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="exrate.aspx.vb" Inherits="exrate_class" MasterPageFile="~/Site.Master" %>  
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
        <div class="col s6 m2">
             <uc:AXFormEntry ID="exr_curr1" Caption="From Currency" FieldType="text" Lookup="CURR" Required="true" runat="server"  />                            

                                     
                                    
        </div>
    </div>
    <div class="row">    
        <div class="col s12 m2">
              <uc:AXFormEntry ID="exr_curr2" Caption="To Currency" FieldType="text" Lookup="CURR" Required="true" runat="server"  />                                                                       
        </div>
    </div>
    <div class="row">    
        <div class="col s12 m2">
         <uc:AXFormEntry ID="exr_rate" Caption="From Rate" FieldType="number" Required="true" runat="server"  />                                                                                                      
        </div>
      </div>
    <div class="row">    
        <div class="col s12 m2">
         <uc:AXFormEntry ID="exr_rate2" Caption="To Rate" FieldType="number" Required="true" runat="server"  />                                                                                                      
        </div>
      </div>
        
    
       <div class="row">    
        <div class="col s12 m2">        
            Effective From<span style="color:red">*</span>
           <input type="text" runat="server" id="exr_start_date" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />                                                                                                    
        </div>
         <div class="col s12 m2">
         
            Effective To<span style="color:red">*</span>
           <input type="text" runat="server" id="exr_end_date" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />                                                                                                    
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
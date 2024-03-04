<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="membercategory.aspx.vb" Inherits="merbercategory_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

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
        <div class="col s6 m3">
                                    Code<span style="color:red">*</span>
                                    <asp:TextBox id="cc_code" runat="server" class="form-input">
                                    
                                    </asp:TextBox>
                                     
                                    
        </div>
    </div>
    <div class="row">    
        <div class="col s12 m5">
                                     Description<span style="color:red">*</span>
                                    <asp:TextBox id="cc_name" runat="server" class="form-input">
                                    
                                    </asp:TextBox>                                 
                                    
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
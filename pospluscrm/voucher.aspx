<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="voucher.aspx.vb" Inherits="voucher_class" MasterPageFile="~/Site.Master" %>  

<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   


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
                                    <asp:TextBox id="vo_code" runat="server" class="form-input"></asp:TextBox>          
                                    
                                     Voucher Name<span style="color:red">*</span>
                                    <asp:TextBox id="vo_name" runat="server" class="form-input"></asp:TextBox>     
                                    
                                    
                            <br />   
                            <div class="switch"><label><input type="checkbox" runat="server" id="chkactive"><span class="lever"></span>
                            Active ?
                            </label></div>     
                                                               
        </div>
     
    </div>
    
    
    
    
    
    
    <div class="row">    
        <div class="col s12 m4">
        
        
                <%=MenuGenerator.WebPartHeader("SETTINGS")%>
        
                 Voucher Type<span style="color:red">*</span>
                 <asp:DropDownList runat="server" ID="vo_type">
                 <asp:ListItem Value="C">Cash Value</asp:ListItem>
                <asp:ListItem Value="P">Percentage Discount</asp:ListItem>    
                 <asp:ListItem Value="N">Non Value</asp:ListItem>                  
                 </asp:DropDownList>  
                 
                 
                 <br />
                 
                 Voucher Value<span style="color:red">*</span>
                 <asp:TextBox id="vo_amt" runat="server" class="form-input"></asp:TextBox>                                      
                                    
                         
                Max Qty<span style="color:red">*</span>
                 <asp:TextBox id="vo_qty" runat="server" class="form-input"></asp:TextBox>                               
                                                                                
        </div>
        
        
          <div class="col s12 m4">
                                
                                        <%=MenuGenerator.WebPartHeader("VOUCHER IMAGE")%>                                        
                                    
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
    
    

<br /><br /><br /><br />
<br /><br /><br /><br />

<br /><br /><br /><br />
    
    
    

   
           
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
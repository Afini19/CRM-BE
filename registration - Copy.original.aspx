<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="registration.aspx.vb" Inherits="registration_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<h5>MERCHANT REGISTRATION</h5>
<br /><br />







                         <div class="form-row">
                            
                              <div class="form-group">
                                <label for="mm_name">Merchant Name<span style="color:red">*</span>
                               </label>
                                <asp:TextBox id="mm_name" runat="server" class="form-input"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                     <div class="switch">
                                    <label>
                                      <input type="checkbox" runat="server" id="chkdefault" checked>
                                      <span class="lever"></span>
                                       Active ?
                                    </label>
                                  </div>



                            </div>

                            </div>


                         <div class="form-row">
                            <div class="form-group">
                                <label for="mm_address1">Address 1<span style="color:red">*</span></label>
                                <asp:TextBox id="mm_address1" runat="server" class="form-input"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="mm_address2">Address 2<span style="color:red"></span></label>
                                <asp:TextBox id="mm_address2" runat="server" class="form-input"></asp:TextBox>
                            </div>

                        </div>              
                         <div class="form-row">
                            <div class="form-group">
                                <label for="mm_address3">Address 3<span style="color:red"></span></label>
                                <asp:TextBox id="mm_address3" runat="server" class="form-input"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="mm_address4">Address 4<span style="color:red"></span></label>
                                <asp:TextBox id="mm_address4" runat="server" class="form-input"></asp:TextBox>
                            </div>

                        </div>              
                         <div class="form-row">
                            <div class="form-group">
                                <label for="mm_state">Area Code<span style="color:red">*</span></label>
                                <asp:DropDownList runat="server" ID="mm_area" class="form-input"></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label for="mm_state">State<span style="color:red">*</span></label>
                                <asp:DropDownList runat="server" ID="mm_state" class="form-input"></asp:DropDownList>
                            </div>

                        </div>              
                         <div class="form-row">
                             <div class="form-group">
                                <label for="mm_zipcode">Postal Code<span style="color:red">*</span></label>
                                <asp:TextBox id="mm_zipcode" runat="server" class="form-input"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="mm_email">Email Address<span style="color:red">*</span></label>
                                <asp:TextBox id="mm_email" runat="server" class="form-input"></asp:TextBox>
                            </div>
                        </div>      
                         <div class="form-row">
                            <div class="form-group">
                                <label for="mm_long">Longtitude<span style="color:red"></span></label>
                                <asp:TextBox id="mm_long" runat="server" class="form-input"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="mm_lat">Latitude<span style="color:red"></span></label>
                                <asp:TextBox id="mm_lat" runat="server" class="form-input"></asp:TextBox>
                            </div>

                        </div>      
                         <div class="form-row">
                            <div class="form-group">
                                <label for="mm_long">Login ID<span style="color:red"></span></label>
                                <asp:TextBox id="mm_loginid" runat="server" class="form-input"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="mm_lat">Password<span style="color:red"></span></label>
                                <asp:TextBox id="mm_password" runat="server" class="form-input"></asp:TextBox>
                            </div>

                        </div>      

                     <input type="hidden" id="conferenceid" runat="server" />                                                                                                                                             
                     <input type="hidden" id="uid" runat="server" />                                                                                                                                             

             <asp:Button ID="btnsave" runat="server" Text="Submit" class="form-submit" OnClick="savedata" />
             <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="form-submit" OnClick="backpage" />

             <asp:Button ID="btnDelete" runat="server" Text="Delete" class="form-submit" OnClick="deleterec" />
                                                                                                                                                              
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
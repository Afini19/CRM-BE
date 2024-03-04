<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="add.aspx.vb" Inherits="namec_add_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform">
                      <div class="form-row">
                            <div class="form-group">
                                <label for="nc_name">Contact Name</label>
                                <asp:TextBox id="nc_name" runat="server" class="form-input"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                 <label for="nc_mobileno">Mobile Number (+60128888888)</label>
                                <asp:TextBox id="nc_mobileno" name="nc_mobileno" runat="server" class="form-input"></asp:TextBox>
                               
                            </div>
                        </div>
                      <div class="form-row">
                            <div class="form-group">
                                <label for="nc_email">Contact Email</label>
                                <asp:TextBox id="nc_email" runat="server" class="form-input"></asp:TextBox>
                            </div>
                            <div class="form-group">

                            </div>                            
                        </div>

                      <div class="form-row">
                            <div class="form-group">
                                <label for="nc_company">Company Name</label>
                                <asp:TextBox id="nc_company" runat="server" class="form-input"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="last_name">Company Reg No</label>
                                <asp:TextBox id="nc_companyreg" name="last_name" runat="server" class="form-input"></asp:TextBox>
                            </div>
                        </div>


                          <div class="form-row">
                            <div class="form-radio">
                                <label for="gender">Private</label>
                                <div class="form-flex">
                                    <input type="radio" name="isprivate" value="yes" id="isprivateyes" onclick="$('#<%=nc_private.clientid%>').val('Y');" />
                                    <label for="isprivateyes">Yes</label>
                                                                       
                                    <input type="radio" name="isprivate" value="no" id="isprivateno" checked="checked" onclick="$('#<%=nc_private.clientid%>').val('N');" />
                                    <label for="isprivateno">No</label>
                                </div>
                            </div>                       
                            </div>

                                  
                        <div class="form-group">
                            <asp:Button ID="btnsave" runat="server" Text="Save" class="form-submit" OnClick="savedata" />
                            <asp:Button ID="btndelete" runat="server" Text="Delete" class="form-submit" OnClick="deletedata" Visible="false" />
                            <asp:Button ID="btnback" runat="server" Text="<< Back" class="form-submit" CausesValidation="false" UseSubmitBehavior="false" OnClick="backpage" />

                        </div>

                     <input type="hidden" id="uid" runat="server" />                                                                                                                                             
                     <input type="hidden" id="nc_private" runat="server" />    
                                                                                                                                                              
</form>
</div>                        
</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">  
<!--#include file="validations/namec.aspx" -->
</asp:Content>  
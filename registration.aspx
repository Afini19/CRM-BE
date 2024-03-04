<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="registration.aspx.vb" Inherits="registration_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<h5>MERCHANT REGISTRATION</h5>
<br />

 <div class="row">
    <div class="col s12">
      <ul class="tabs">
        <li class="tab col s6 m4"><a class="active blue-text" href="#tab1">Merchant Details</a></li>
        <li class="tab col s6 m4"><a href="#tab2" class=" blue-text">Optional Details</a></li>
        <li class="tab col s6 m4"><a href="#tab3" class=" blue-text">Business Hours</a></li>
      </ul>
    </div>
    <div id="tab1" class="col s12">
            <br />
            <div class="row">    
                <div class="col s12 m12">
                                            <label for="mm_name">Merchant Name<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="mm_name" runat="server" class="form-input"></asp:TextBox>
                                    
                </div>
            </div>
            <div class="row">    
                <div class="col s12 m6">
                                            <label for="mm_address1">Address 1<span style="color:red">*</span></label>
                                            <asp:TextBox id="mm_address1" runat="server" class="form-input"></asp:TextBox>
                </div>
               <div class="col s12 m6">
                                            <label for="mm_address2">Address 2<span style="color:red"></span></label>
                                            <asp:TextBox id="mm_address2" runat="server" class="form-input"></asp:TextBox>
                </div>
            </div>
            <div class="row">    
                <div class="col s12 m6">
                                            <label for="mm_address3">Address 3<span style="color:red"></span></label>
                                            <asp:TextBox id="mm_address3" runat="server" class="form-input"></asp:TextBox>
                </div>
               <div class="col s12 m6">
                                            <label for="mm_address4">Address 4<span style="color:red"></span></label>
                                            <asp:TextBox id="mm_address4" runat="server" class="form-input"></asp:TextBox>
                </div>
            </div>
            <div class="row">    
                <div class="col s12 m6">
                                            <label for="mm_zipcode">Postal Code<span style="color:red">*</span></label>
                                            <asp:TextBox id="mm_zipcode" runat="server" class="form-input"></asp:TextBox>
                </div>
               <div class="col s12 m6">
                                            <label for="mm_email">Email Address<span style="color:red">*</span></label>
                                            <asp:TextBox id="mm_email" runat="server" class="form-input"></asp:TextBox>
                </div>
            </div>
            <div class="row">    
                <div class="col s12 m6">
                                            <label for="mm_state">Area Code<span style="color:red">*</span></label>
                                            <asp:DropDownList runat="server" ID="mm_area" class="form-input"></asp:DropDownList>
                </div>
               <div class="col s12 m6">
                                            <label for="mm_state">State<span style="color:red">*</span></label>
                                            <asp:DropDownList runat="server" ID="mm_state" class="form-input"></asp:DropDownList>
                </div>
            </div>
   
           <div class="row">    
    <div class="col s12 m6">
                                <label for="mm_contactname">Contact Person Name<span style="color:red"></span></label>
                                <asp:TextBox id="mm_contactname" runat="server" class="form-input"></asp:TextBox>
    </div>
   <div class="col s12 m6">
                                <label for="mm_hpno">Mobile No (6012xxxxxx)<span style="color:red"></span></label>
                                <asp:TextBox id="mm_hpno" runat="server" class="form-input"></asp:TextBox>
    </div>
</div>

   
    </div>
    <div id="tab2" class="col s12">
        <br />
        <div class="row">    
    <div class="col s12 m6">
                                <label for="mm_long">Longtitude<span style="color:red"></span></label>
                                <asp:TextBox id="mm_long" runat="server" class="form-input"></asp:TextBox>
    </div>
   <div class="col s12 m6">
                                <label for="mm_lat">Latitude<span style="color:red"></span></label>
                                <asp:TextBox id="mm_lat" runat="server" class="form-input"></asp:TextBox>
    </div>
</div>
        <div class="row">    
            <div class="col s12 m6">
                                        <label for="mm_loginid">Login ID<span style="color:red"></span></label>
                                        <asp:TextBox id="mm_loginid" runat="server" class="form-input"></asp:TextBox>
             </div>
           <div class="col s12 m6">
                                        <label for="mm_password">Password<span style="color:red"></span></label>
                                        <asp:TextBox id="mm_password" runat="server" class="form-input"></asp:TextBox>
            </div>
        </div>
        <div class="row">    
            <div class="col s12 m12">
                         <div class="switch">
                                            <label>
                                              <input type="checkbox" runat="server" id="chkactive" checked>
                                              <span class="lever"></span>
                                               Active ?
                                            </label>
                        </div>              
            </div>
        </div>
        <div class="row">    
            <div class="col s12 m12">
            <div class="divider"></div>
            </div>
        </div>        

            <div class="row">    
                <div class="col s12 m6">
                                            <label for="mm_state">Bank<span style="color:red">*</span></label>
                                            <asp:DropDownList runat="server" ID="mm_bnkuid" class="form-input"></asp:DropDownList>
                </div>
               <div class="col s12 m6">
                </div>
            </div>
            <div class="row">    
                <div class="col s12 m6">
                                        <label for="mm_accname">Account Name<span style="color:red"></span></label>
                                        <asp:TextBox id="mm_bnkaccname" runat="server" class="form-input"></asp:TextBox>
                </div>
               <div class="col s12 m6">
                                        <label for="mm_long">Account No<span style="color:red"></span></label>
                                        <asp:TextBox id="mm_bnkaccno" runat="server" class="form-input"></asp:TextBox>

                </div>
            </div>


        
    </div>
  
  
      <div id="tab3" class="col s12">
Shop Open On :-

            <div class="row">    
                <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="mm_workmon" checked><span class="lever"></span>
                            Monday
                            </label></div>  

                </div>
               <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="mm_worktue" checked><span class="lever"></span>
                           Tuesday
                          </label></div>  
                </div>
               <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="mm_workwed" checked><span class="lever"></span>
                            Wednesday 
                          </label></div>  
                </div>
               <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="mm_workthur" checked><span class="lever"></span>
                            Thursday 
                          </label></div>  
                </div>

            </div>



            <div class="row">    
                <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="mm_workfri" checked><span class="lever"></span>
                            Friday
                            </label></div>  

                </div>
               <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="mm_worksat" checked><span class="lever"></span>
                           Saturday
                          </label></div>  
                </div>
               <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="mm_worksun" checked><span class="lever"></span>
                            Sunday 
                          </label></div>  
                </div>
               <div class="col s6 m3">

                </div>

            </div>            

<br /><br />
            
<h5>Vacation Settings</h5>
            
                       
            <div class="row">    
                <div class="col s6 m6">
                           <div class="switch"><label><input type="checkbox" runat="server" id="mm_shut"><span class="lever"></span>
                            Close For Business
                            </label></div>  

                </div>
         </div>                
            <div class="row">    
                <div class="col s12 m12">
                                            <label for="description">Vacation Message<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="mm_shutmsg" runat="server" class="form-input" TextMode="MultiLine" style="min-height:100px;max-height:200px;" ></asp:TextBox>
                                    
                </div>
            </div>

        </div>
  </div>
        




<div class="row">    
    <div class="col s12 m12">
        <div class="divider"></div>
    </div>
</div>

<div class="row">    
    <div class="col s12 m4">
             <asp:Button ID="btnsave" runat="server" Text="Submit" class="btn waves-effect waves-light light-blue caishbutton"  OnClick="savedata" />
    </div>
    <div class="col s12 m4">
             <asp:Button ID="btnCancel" runat="server" Text="<< Back" class="btn waves-effect waves-light light-blue caishbutton" OnClick="backpage" />
    </div>
    <div class="col s12 m4">
             <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn waves-effect waves-light deep-orange caishbutton" OnClick="deleterec" />
    </div>

</div>



       
<input type="hidden" id="uid" runat="server" />                                                                                                                                             
                                                                                                                                                       
</form>
</div>                        

   <script language="javascript" type="text/javascript">
    $(document).ready(function(){
           $('.tabs').tabs();
      });
   </script>

</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
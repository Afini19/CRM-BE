<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="emenu.aspx.vb" Inherits="emenu_class" MasterPageFile="~/Site.Master" %>  
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
    <div class="col s12">
      <ul class="tabs">
        <li class="tab col s6 m2"><a class="active blue-text" href="#tab1">Details</a></li>
        <li class="tab col s6 m2"><a href="#tab2" class=" blue-text">Media</a></li>
        <li class="tab col s6 m3"><a href="#tab5" class=" blue-text">Writeups</a></li>

      </ul>
    </div>
    <div id="tab1" class="col s12">
            <br />
            <div class="row">    
                <div class="col s12 m3">
                                            <label for="pcode">Product Code<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="pcode" runat="server" class="form-input"></asp:TextBox>                                    
                </div>
                <div class="col s12 m9">
                                           <label for="pname">Product Name<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="pname" runat="server" class="form-input"></asp:TextBox>
                 </div>

            </div>
            <div class="row">    
                <div class="col s12 m12">
                                            <label for="description">Short Description<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="description" runat="server" class="form-input"></asp:TextBox>
                                    
                </div>
            </div>
            <div class="row">    
                <div class="col s12 m6">
                                            <label for="catid">Category<span style="color:red">*</span></label>
                                            <asp:DropDownList runat="server" ID="catid" class="form-input"></asp:DropDownList>
                </div>
               <div class="col s12 m6">
                                            <label for="productcat3">Sub Category<span style="color:red"></span></label>
                                            <asp:DropDownList runat="server" ID="productcat3" class="form-input"></asp:DropDownList>

                </div>
            </div>
            <div class="row">    
                <div class="col s6 m3">
                                            <label for="sprice1">Retail Price<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="sprice1" runat="server" class="form-input"></asp:TextBox>
                </div>
               <div class="col s6 m3">
                                            <label for="sprice2">Promo Price<span style="color:red"></span>
                                           </label>
                                            <asp:TextBox id="sprice3" runat="server" class="form-input"></asp:TextBox>

                </div>
                <div class="col s6 m3">
                                            <label for="sprice2">Member Price<span style="color:red"></span>
                                           </label>
                                            <asp:TextBox id="sprice2" runat="server" class="form-input"></asp:TextBox>
                </div>
               <div class="col s6 m3">
                                            <label for="sprice4">Dealer Price<span style="color:red"></span>
                                           </label>
                                            <asp:TextBox id="sprice4" runat="server" class="form-input"></asp:TextBox>

                </div>


            </div>


            <div class="row">    
                <div class="col s6 m3">
                                            <label for="priority">List Priority<span style="color:red"></span></label>
                                            <asp:DropDownList runat="server" ID="priority" class="form-input">
                                            <asp:ListItem Value="0">Default</asp:ListItem>
                                            <asp:ListItem Value="-1">Low</asp:ListItem>
                                            <asp:ListItem Value="5">Medium</asp:ListItem>
                                            <asp:ListItem Value="9">High</asp:ListItem>
                                            </asp:DropDownList>
                </div>
               <div class="col s6 m9">
                                            <label for="ranking">List Ranking<span style="color:red"></span></label>
                                            <asp:DropDownList runat="server" ID="ranking">
                                            <asp:ListItem Value="99">No Preference</asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="7">7</asp:ListItem>
                                            <asp:ListItem Value="8">8</asp:ListItem>
                                            <asp:ListItem Value="9">9</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="11">11</asp:ListItem>
                                            <asp:ListItem Value="12">12</asp:ListItem>
                                            <asp:ListItem Value="13">13</asp:ListItem>
                                            <asp:ListItem Value="14">14</asp:ListItem>
                                            <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="16">16</asp:ListItem>
                                            <asp:ListItem Value="17">17</asp:ListItem>
                                            <asp:ListItem Value="18">18</asp:ListItem>
                                            <asp:ListItem Value="19">19</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            </asp:DropDownList>
                                            (1 - List on top, 20 - List below), Set your product listing sequence

                </div>
                <div class="col s6 m3">

                </div>
               <div class="col s6 m3">


                </div>


            </div>

            <div class="row">    
                <div class="col s12 m12">
                 <b>Behavior Settings, Mark as :-</b>
                </div>
            </div>
            <div class="row">    
                <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="ffeature"><span class="lever"></span>
                            Featured
                            </label></div>  

                </div>
               <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="fnew"><span class="lever"></span>
                           New ?
                          </label></div>  
                </div>
               <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="fvisible" checked><span class="lever"></span>
                            Visible 
                          </label></div>  
                </div>
               <div class="col s6 m3">

                </div>

            </div>
            
            
                     <div class="row">    
                <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="fpromo"><span class="lever"></span>
                            Promotion
                            </label></div>  

                </div>
               <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="fcomingsoon"><span class="lever"></span>
                            C/SOON
                          </label></div>  
                </div>
               <div class="col s6 m3">
                           <div class="switch"><label><input type="checkbox" runat="server" id="fsoldout"><span class="lever"></span>
                           Sold Out
                          </label></div>  
                </div>
               <div class="col s6 m3">
                            <div class="switch"><label><input type="checkbox" runat="server" id="chkactive" checked><span class="lever"></span>
                           Active Item 
                          </label></div>  
                </div>
            </div>

    </div>
    <div id="tab2" class="col s12">
        <br />

                            <div class="row">    
                          
                            
                                <div class="col s12 m4">
                                        <h6>Default Image</h6>
                                        <span style="font-size:0.9em">This image appears as default in the shopping cart</span>
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
                                         <asp:Button ID="uploadbutton" runat="server" Text="Upload Image" class="btn waves-effect waves-light light-blue caishbutton"  OnClick="uploadbutton_click" />
                                         <asp:Button ID="deletebutton" runat="server" Text="Delete Image" class="btn waves-effect waves-light deep-orange caishbutton"  OnClick="deletebutton_click" />


                                        <center>
                                        <h6>Image Preview</h6>
                                        <div style="width:150px; max-width:150px; height:150px; min-height:150px; border:solid 1px silver; overflow:hidden; text-align:center">
                                        <asp:Literal runat="server" ID="litpreview"></asp:Literal>
                                        </div>
                                        </center>

                            </div>
                                <div class="col s12 m4">
                                 <h6>Gallery Images</h6>
                                  <span style="font-size:0.9em">Gallery images will appear at the product detail page</span>
                                        <div class="file-field input-field">
                                          <div class="btn light-blue">
                                            <span>File</span>
                                            <input type="file" runat="server" id="UploadedFileG">
                                          </div>
                                          <div class="file-path-wrapper">
                                            <input class="file-path validate" type="text" placeholder="Select File">
                                          </div>
                                         </div>
                                         <asp:Button ID="uploadbuttong" runat="server" Text="Upload Image" class="btn waves-effect waves-light light-blue caishbutton"  OnClick="uploadbuttong_click" />
                                       <center>
                                       <img src="" class="responsive-img" />
                                        <asp:Literal runat="server" ID="litg"></asp:Literal>
                                        
                                       <div><asp:Button ID="btngdelete" runat="server" Text="Delete Selected" class="btn waves-effect waves-light deep-orange caishbutton"  OnClick="deletebuttong_click" /></div>

                                        </center>


                                </div>  

                                <div class="col s12 m4">
                                 <h6>YouTube Video</h6>
                                  <span style="font-size:0.9em">Please enter code only and not entire video url</span>
                                        <div class="input-field">
                                          <asp:TextBox id="txtvideolink" runat="server" class="form-input" placeholder="hUOUH8xuClo"></asp:TextBox> 
                                                                                    
                                      </div>
                                   <asp:Button ID="btnvideo" runat="server" Text="Save and Preview" class="btn waves-effect waves-light light-blue caishbutton"  OnClick="videolink_click" />
                                  <span style="font-size:0.9em">For Example : https://www.youtube.com/watch?v=</span><span style="color:red"><b>hUOUH8xuClo</b></span>

                                  <div class="divider"></div>
                                   <div style="width:100%; overflow:hidden">
                                   <asp:Literal ID="lityoutube" runat="server"></asp:Literal>                                   
                                   </div>
                                </div>  



                    </div>


    </div>



  
  
        <div id="tab5" class="col s12">
        <br />
       <h6>Additional Products Info.</h6><br />
       
       <CKEditor:CKEditorControl ID="descriptionadd" runat="server" Width="100%" >
                                
        </CKEditor:CKEditorControl>

       
        </div>
  
        <div id="tab3" class="col s12" style="visibility:hidden">
        <br />
       <h6>Please enter shipping related details (Optional)</h6><br />
        
            <div class="row">    
                <div class="col s12 m4">
                                            <label for="v2_deliverydays">Lead Time (days)<span style="color:red"></span>
                                           </label>
                                            <asp:TextBox id="v2_deliverydays" runat="server" class="form-input"></asp:TextBox>                                    
                </div>
                <div class="col s12 m4">
                                            <label for="weight">Weight (kg)<span style="color:red"></span>
                                           </label>
                                            <asp:TextBox id="weight" runat="server" class="form-input"></asp:TextBox>                                    
                </div>

            </div>
        <div class="row">    
                <div class="col s12 m12">
                                           <label for="v2_packagingdesc">Packaging Details<span style="color:red"></span>
                                           </label>
                                            <asp:TextBox id="v2_packagingdesc" runat="server" class="form-input"></asp:TextBox><br />
                                            
                 </div>

          </div>                        

        <div class="row">    
                <div class="col s12 m12">
                           <div class="switch"><label><input type="checkbox" runat="server" id="pp_fnondeliveryitem"><span class="lever"></span>
                            NON-DELIVERY Item (Voucher, e-Books and etc)
                          </label></div>  
                 </div>

          </div>                        
        <div class="row">    
                <div class="col s12 m12">
                           <div class="switch"><label><input type="checkbox" runat="server" id="pp_fallowselfpickup"><span class="lever"></span>
                            Allow Self-Pickup at store
                          </label></div>  
                 </div>

          </div>                        





    </div>
      <div id="tab4" class="col s12" style="visibility:hidden">
        <br />
       <h6>Product Variant and Inventory Control</h6><br />
       
                   <div class="row">    
                <div class="col s12 m12">
                 <label>
                    <input class="with-gap" name="rgvariant" id="rbv1" type="radio" runat="server" checked   />
                        <span>Default (No Variant)</span>
                    </label>

                
                </div>
             </div>
            <div class="row">    
                <div class="col s6 m6">
                                             <label for="pp_qtyc">Qty Control<span style="color:red"></span></label>
                                            <asp:DropDownList runat="server" ID="pp_qtyc" class="form-input">
                                            <asp:ListItem Value="0">Unlimited</asp:ListItem>
                                            <asp:ListItem Value="1">Until Sold Out</asp:ListItem>
                                            <asp:ListItem Value="2">Daily Qty</asp:ListItem>
                                            <asp:ListItem Value="3">Sold Out</asp:ListItem>
                                            </asp:DropDownList>                                  
                </div>
                <div class="col s6 m6">
                                            <label for="pp_qty">On Hand Qty<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="pp_qty" runat="server" class="form-input"></asp:TextBox>                                    
                </div>
                 
            </div>
             
             

              
        <div class="divider"></div>              
              
            <div class="row">    
                <div class="col s12 m12">
                 <label>
                    <input class="with-gap" name="rgvariant" id="rbv2" type="radio" runat="server" />
                        <span>Multiple Variant</span>
                    </label>

                
                </div>
             </div>

           <div style="visibility:hidden">
       
            <div class="row">    
                <div class="col s4 m2">
                                           <label for="pname">Variant<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox2" runat="server" class="form-input"></asp:TextBox>
                 </div>
                <div class="col s4 m2">
                                           <label for="pname">Unique SKU<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox3" runat="server" class="form-input"></asp:TextBox>
                 </div>
                <div class="col s4 m2">
                                           <label for="pname">Add On Price<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox4" runat="server" class="form-input"></asp:TextBox>
                 </div>
                <div class="col s6 m4">
                                             <label for="priority">Qty Control<span style="color:red"></span></label>
                                            <asp:DropDownList runat="server" ID="DropDownList1" class="form-input">
                                            <asp:ListItem Value="0">Unlimited</asp:ListItem>
                                            <asp:ListItem Value="1">Until Sold Out</asp:ListItem>
                                            <asp:ListItem Value="2">Daily Qty</asp:ListItem>
                                            <asp:ListItem Value="3">Sold Out</asp:ListItem>
                                            </asp:DropDownList>                                  
                </div>
                <div class="col s6 m2">
                                            <label for="pcode">On Hand Qty<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox1" runat="server" class="form-input"></asp:TextBox>                                    
                </div>
                 
            </div>
            <div class="row">    
                <div class="col s4 m2">
                                           <label for="pname">Variant<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox5" runat="server" class="form-input"></asp:TextBox>
                 </div>
                <div class="col s4 m2">
                                           <label for="pname">Unique SKU<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox6" runat="server" class="form-input"></asp:TextBox>
                 </div>
                <div class="col s4 m2">
                                           <label for="pname">Add On Price<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox7" runat="server" class="form-input"></asp:TextBox>
                 </div>
                <div class="col s6 m4">
                                             <label for="priority">Qty Control<span style="color:red"></span></label>
                                            <asp:DropDownList runat="server" ID="DropDownList3" class="form-input">
                                            <asp:ListItem Value="0">Unlimited</asp:ListItem>
                                            <asp:ListItem Value="1">Until Sold Out</asp:ListItem>
                                            <asp:ListItem Value="2">Daily Qty</asp:ListItem>
                                            <asp:ListItem Value="3">Sold Out</asp:ListItem>
                                            </asp:DropDownList>                                  
                </div>
                <div class="col s6 m2">
                                            <label for="pcode">On Hand Qty<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox9" runat="server" class="form-input"></asp:TextBox>                                    
                </div>
                 
            </div>
            <div class="row">    
                <div class="col s4 m2">
                                           <label for="pname">Variant<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox10" runat="server" class="form-input"></asp:TextBox>
                 </div>
                <div class="col s4 m2">
                                           <label for="pname">Unique SKU<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox11" runat="server" class="form-input"></asp:TextBox>
                 </div>
                <div class="col s4 m2">
                                           <label for="pname">Add On Price<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox12" runat="server" class="form-input"></asp:TextBox>
                 </div>
                <div class="col s6 m4">
                                             <label for="priority">Qty Control<span style="color:red"></span></label>
                                            <asp:DropDownList runat="server" ID="DropDownList4" class="form-input">
                                            <asp:ListItem Value="0">Unlimited</asp:ListItem>
                                            <asp:ListItem Value="1">Until Sold Out</asp:ListItem>
                                            <asp:ListItem Value="2">Daily Qty</asp:ListItem>
                                            <asp:ListItem Value="3">Sold Out</asp:ListItem>
                                            </asp:DropDownList>                                  
                </div>
                <div class="col s6 m2">
                                            <label for="pcode">On Hand Qty<span style="color:red">*</span>
                                           </label>
                                            <asp:TextBox id="TextBox13" runat="server" class="form-input"></asp:TextBox>                                    
                </div>
                 
            </div>
</div>


    </div>
  
  </div>
        





    
     
    
    
          <input type="hidden" id="guuid" runat="server" />      
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

   <script language="javascript" type="text/javascript">
    $(document).ready(function(){
           $('.tabs').tabs();
            $('.materialboxed').materialbox();
           $('.modal').modal();    
      });

    function _deleteGallery(UUID)
    {
        document.getElementById("<%=guuid.ClientID%>").value = UUID ;   
    }

      
      
   </script>

</asp:Content>  
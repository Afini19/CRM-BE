<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="admin-product.aspx.vb" Inherits="adminproduct_class" MasterPageFile="~/Site.Master" %>  
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<h5>PRODUCT DETAILS</h5>
<br />

 <div class="row">
    <div class="col s12">
      <ul class="tabs">
        <li class="tab col s6 m2"><a class="active blue-text" href="#tab1">Details</a></li>
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
                                            <label for="priority">List Priority<span style="color:red"></span></label>
                                            <asp:DropDownList runat="server" ID="priority" class="form-input">
                                            <asp:ListItem Value="0">Default</asp:ListItem>
                                            <asp:ListItem Value="-1">Low</asp:ListItem>
                                            <asp:ListItem Value="5">Medium</asp:ListItem>
                                            <asp:ListItem Value="9">High</asp:ListItem>
                                            </asp:DropDownList>
                </div>
               <div class="col s6 m9">

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
                            <div class="switch"><label><input type="checkbox" runat="server" id="chkactive" checked><span class="lever"></span>
                           Active Item 
                          </label></div>  
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
</div>


<input type="hidden" id="uid" runat="server" />                                                                                                                                             
<input type="hidden" id="guuid" runat="server" />            
</form>
</div>                        


   <script language="javascript" type="text/javascript">
    $(document).ready(function(){
           $('.tabs').tabs();
            $('.materialboxed').materialbox();
           $('.modal').modal();    
      });
   </script>

</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  

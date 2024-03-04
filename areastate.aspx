<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="areastate.aspx.vb" Inherits="areastate_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<h5>AREA STATE MAINTENANCE</h5>
<br /><br />


<div class="row">    
    <div class="col s12 m6">
                                <label for="ms_code">State Code<span style="color:red">*</span></label>
                                <asp:TextBox id="ms_code" runat="server" class="form-input"></asp:TextBox>
    </div>
   <div class="col s12 m6">

    </div>
</div>

<div class="row">    
    <div class="col s12 m12">
                                <label for="ms_name">State Name<span style="color:red">*</span>
                               </label>
                                <asp:TextBox id="ms_name" runat="server" class="form-input"></asp:TextBox>
                        
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
    <div class="col s12 m4">
             <asp:Button ID="btnsave" runat="server" Text="Submit" class="btn waves-effect waves-light light-blue darken-4 caishbutton"  OnClick="savedata" />
    </div>
    <div class="col s12 m4">
             <asp:Button ID="btnCancel" runat="server" Text="<< Back" class="btn waves-effect waves-light light-blue darken-4 caishbutton" OnClick="backpage" />
    </div>
    <div class="col s12 m4">
             <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn waves-effect waves-light deep-orange darken-4 caishbutton" OnClick="deleterec" />
    </div>

</div>



       
<input type="hidden" id="uid" runat="server" />                                                                                                                                             
                                                                                                                                                       
</form>
</div>                        



</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">



</asp:Content>  
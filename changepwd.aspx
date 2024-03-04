<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="changepwd.aspx.vb" Inherits="changepwd_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<h5>CHANGE PASSWORD</h5>
<br /><br />


<div class="row">    
    <div class="col s12 m6">
                                <label for="mac_code">Current Password<span style="color:red">*</span></label>
                                <asp:TextBox id="mm_loginpwdold" runat="server" TextMode="Password" class="form-input"></asp:TextBox>
    </div>
   <div class="col s12 m6">

    </div>
</div>
<div class="row">    
    <div class="col s12 m6">

    <br />                        
    </div>
</div>

<div class="row">    
    <div class="col s12 m6">
                                <label for="mac_name">New Password<span style="color:red">*</span>
                               </label>
                                <asp:TextBox id="mm_loginpwdnew" runat="server" TextMode="Password"  class="form-input"></asp:TextBox>
                        
    </div>
</div>
<div class="row">    
    <div class="col s12 m6">
                                <label for="mac_name">Confirm New Password<span style="color:red">*</span>
                               </label>
                                <asp:TextBox id="mm_loginpwdnew2" runat="server" TextMode="Password"  class="form-input"></asp:TextBox>
                        
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
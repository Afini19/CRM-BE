<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="areacode.aspx.vb" Inherits="areacode_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<h5>AREA CODE</h5>
<br /><br />


<div class="row">    
    <div class="col s12 m6">
                                <label for="mac_code">Area Code<span style="color:red">*</span></label>
                                <asp:TextBox id="mac_code" runat="server" class="form-input"></asp:TextBox>
    </div>
   <div class="col s12 m6">

    </div>
</div>

<div class="row">    
    <div class="col s12 m12">
                                <label for="mac_name">Area Name<span style="color:red">*</span>
                               </label>
                                <asp:TextBox id="mac_name" runat="server" class="form-input"></asp:TextBox>
                        
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
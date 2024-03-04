<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="upload.aspx.vb" Inherits="upload_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform">

<b>Create Order Via Excel</b><br />
<hr width="100%" class="cssdivider" />



        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        <br />
        <br />        
        <asp:Label ID="Label1" runat="server" Text="FIRST LINE HAS HEADER ?" /><br />        
        <asp:RadioButtonList ID="rbHDR" runat="server" RepeatLayout = "Flow">
            <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
            <asp:ListItem Text="No" Value="No"></asp:ListItem>
        </asp:RadioButtonList>

<hr width="100%" class="cssdivider" />

      <input type="hidden" id="eventtype2" runat="server" />
      <input type="hidden" id="eventtype" runat="server" />
      <input type="hidden" id="eventargs" runat="server" />

                                                                                               
</form>
</div>                        
</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">  



</asp:Content>  
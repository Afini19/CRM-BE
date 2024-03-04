    <%@ Control Language="VB" AutoEventWireup="true" CodeFile="formentry.ascx.vb" Inherits="formentry_class" %>


            <asp:Literal ID="litcaption" runat="server"></asp:Literal>
             <asp:Literal ID="litrequired" runat="server"></asp:Literal>
            <asp:Literal ID="entryicon" runat="server"></asp:Literal>
            <asp:TextBox id="axvalue" runat="server" class="form-input validate" />
            <span class="helper-text" id="axvaluedesc" runat="server" data-error="" data-success=""></span>
            <asp:HiddenField runat="server" id="axvalueorg" />
            <asp:HiddenField runat="server" id="axvaluehidden" />
            <asp:Literal ID="myscripts" runat="server"></asp:Literal>
              


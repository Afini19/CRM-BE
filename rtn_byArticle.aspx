<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="rtn_byarticle.aspx.vb" Inherits="rtn_byarticle_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
<link rel="stylesheet" type="text/css" href="Datatables/datatables.min.css"/>
<script type="text/javascript" src="Datatables/datatables.min.js"></script>


</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform"  defaultbutton="btnsearch">
<h5><%=PageTitle%></h5>

<div class="row" >    
    <div class="col s12 m3">
                                <label for="_code">Search by article number<span style="color:red">*</span></label>
                                <asp:TextBox id="partno" runat="server" class="form-input"></asp:TextBox>
                                <div><asp:Button ID="btnsearch" runat="server" Text="Search" class="btn waves-effect waves-light cyan darken-4 caishbutton"  OnClick="searchdata" /></div>
    </div>
</div>


<div class="row">    
    <div class="col s12 m5">

<table id="caishtb" class="display hover stripe cell-border nowrap order-column" width="100%">
<asp:Literal runat="server" ID="litthead"></asp:Literal>
<tbody>
<asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand" >
<ItemTemplate>
<asp:Literal ID="litTableRows" runat="server"></asp:Literal>
</ItemTemplate>
</asp:Repeater>
</tbody>
<asp:Literal runat="server" ID="littfoot"></asp:Literal>
</table>

    </div>
    
        <div class="col s12 m1">
           <div><asp:Button ID="btnview2" runat="server" Text=">" class="btn waves-effect waves-light cyan darken-4 caishbutton"  OnClick="searchdata" /></div>
        </div>    
        <div class="col s12 m4">
                  Selected Article :-<br />
                  <div id="divtext" name="divtext"></div>              
                  <div id="divcode" name="divcode"></div> 
                  <div id="divuom" name="divuom"></div> 
                 
                  <br />
                 <label for="_code">Please enter Quantity<span style="color:red">*</span></label>
                 <asp:TextBox id="txtqty" runat="server" class="form-input"></asp:TextBox>
                   <br />
                   
                  <div class="row">
                     <div class="col s12 m12">
                         <asp:Button ID="btnview" runat="server" Text="Save Item" class="btn waves-effect waves-light cyan darken-2 caishbutton"  OnClick="savedata" />
                      </div>
                  </div> 
                  <div class="row">
                     <div class="col s12 m12">
                         <asp:Button ID="Button2" runat="server" Text="REVIEW DOCUMENT" class="btn waves-effect waves-light cyan darken-3 caishbutton"  OnClick="gotonext" />
                      </div>
                    </div> 
                    
                    <div class="row"> 
                     <div class="col s12 m12">
                         <asp:Button ID="Button1" runat="server" Text="<< BACK" class="btn waves-effect waves-light cyan darken-4 caishbutton"  OnClick="gotoback" />
                      </div>
                  </div> 

        </div>
   </div>

       	  <asp:Repeater ID="rptPaging" runat="server">
            <ItemTemplate>
                    <asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" ><%# Container.DataItem %></asp:LinkButton>
           </ItemTemplate>
        </asp:Repeater>

      <input type="hidden" id="table1sel" runat="server" />
      <input type="hidden" id="table1sel0" runat="server" />
      <input type="hidden" id="table1sel2" runat="server" />

      <input type="hidden" id="uid" runat="server" />
      <input type="hidden" id="eventtype2" runat="server" />
      <input type="hidden" id="eventtype" runat="server" />
      <input type="hidden" id="eventargs" runat="server" />
      <asp:Button ID="eventfire" runat="server" style="display:none" OnClick="eventfiresub" />
            <div style="visibility:hidden">
          	             <asp:Button ID="btnADD" runat="server" Text="Add" class="form-submit" OnClick="adddata" />
        <asp:Button ID="cmdPrev" runat="server" Text=" << " class="form-submit" CausesValidation="false" UseSubmitBehavior="false" OnClick="cmdPrev_Click" />
        <asp:Button ID="cmdNext" runat="server" Text=" >> " class="form-submit" CausesValidation="false" UseSubmitBehavior="false" OnClick="cmdNext_Click" />
          	             
      </div>      

      
      
</form>
</div>
</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">  

<script language="javascript" type="text/javascript">
$(document).ready(function() {
   <asp:Literal runat="server" ID="litsettings"></asp:Literal>  
   var table = $('#caishtb').DataTable();     
    $('#caishtb tbody').on('click', 'tr', function () {
        var data = table.row( this ).data();
        $('#<%=table1sel.clientid%>').val(data[1]);
        $('#divtext').html("<h5>" + data[2] + "</h5>");
        $('#divcode').html("<h6>" + data[1] + "</h6>");
        $('#divuom').html("<h6>UOM : " + data[3] + "</h6>");        
        $('#<%=table1sel2.clientid%>').val(data[3]);
        $('#<%=table1sel0.clientid%>').val(data[0]);

         if (data[0].trim()!="")
        {
         if ( $(this).hasClass('selected') ) {
            $(this).removeClass('selected');
         }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
          }
         }
     });  
});
</script>
</asp:Content>  
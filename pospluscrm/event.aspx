<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="event.aspx.vb" Inherits="event_class" MasterPageFile="~/Site.Master" %>  
<%@ Register Src="~/UserControls/formentry.ascx" TagPrefix="uc" TagName="AXFormEntry" %>


    <asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  
<link rel="stylesheet" type="text/css" href="../officeonetables/officeonetables.min.css"/>
<script type="text/javascript" src="../officeonetables/officeonetables.min.js"></script>
</asp:Content>  


<asp:Content ID="cttopbody" ContentPlaceHolderID="topbody" runat="server">  
    <!--#include File="~/navbarl3.aspx"-->
    <!--#include File="~/navbarleftSmall.aspx"-->
    </asp:Content>  
    <asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
    <div class="caishform" <%=Framework_MenuLeftCSS%>>
    <form id="frmform" runat="server" class="theform2">                        
        <div class="row">       
         <div class="col s12 m9">
                <div class="pagetitle"><%=PageTitle%></div>
        </div>
         <div class="col s12 m3">

         
         </div>    
        </div>


           

    <div class="row">    
        <div class="col s12 m4">
        
        
            <%=MenuGenerator.WebPartHeader("EVENT DETAILS")%>
        
                                    Event Code<span style="color:red">*</span>
                                    <asp:TextBox id="le_code" runat="server" class="form-input"></asp:TextBox>          
                                    
                                     Event Name<span style="color:red">*</span>
                                    <asp:TextBox id="le_name" runat="server" class="form-input"></asp:TextBox>     
                                    
                                    
                            <br />   
                            <div class="switch"><label><input type="checkbox" runat="server" id="chkactive"><span class="lever"></span>
                            Active ?
                            </label></div>     
                                                               
        </div>
         <div class="col s12 m4">
          <%=MenuGenerator.WebPartHeader("VALIDITY TIME CONTROL")%>
         
         
                            <div class="switch"><label><input type="checkbox" runat="server" id="le_enabletime"><span class="lever"></span>
                            Enable Time Control                           
                            </label></div>   
                            <br />
                            
                                      <div class="row">  
                                 <div class="col s12 m6">
                            <uc:AXFormEntry ID="le_fromtime" Caption="From Time (HH:MM)" FieldType="time" Required="false" runat="server"  />                            
                            </div>
                             <div class="col s12 m6">
                                                  <uc:AXFormEntry ID="le_totime" Caption="To Time (HH:MM)" FieldType="time" Required="false" runat="server"  />                          

                                 </div>
                            </div>
         
         
         </div>
    </div>
    
    
    
    
    
    
    <div class="row">    
        <div class="col s12 m4">
        
        
                <%=MenuGenerator.WebPartHeader("FILTER BY BRANCH")%>
                <uc:AXFormEntry ID="brcode" Caption="Lookup Branch" FieldType="text" Lookup="BRANCH"  Required="false" runat="server"  />                          
                      
                 <div class="row">    
                   <div class="col s12 m6">
                    <input type="button" class="<%=TableUtils.btnprimary%>" value="SAVE" />                                    
                  </div>
                 <div class="col s12 m6">
                      <input type="button" class="<%=TableUtils.btnprimary2%>" value="DELETE" />    
                 </div>                   
                                 
                 </div>                       
                       
                       
                       
            <table id="caishtb" class="<%=TableUtils.TableType%>" width="100%">
            <asp:Literal runat="server" ID="litthead"></asp:Literal>
            <tbody>
            <asp:Repeater ID="rep" runat="server">
            <ItemTemplate>
            <asp:Literal ID="litTableRows" runat="server"></asp:Literal>
            </ItemTemplate>
            </asp:Repeater>
            </tbody>
            <asp:Literal runat="server" ID="littfoot"></asp:Literal>
            </table>                       
                       
                                    
                                                                                
        </div>
        <div class="col s12 m4">
        
        
                <%=MenuGenerator.WebPartHeader("EVENTS QR")%>
                 <uc:AXFormEntry ID="source" Caption="Source Name" FieldType="text" lookup="QRSOURCE" Required="false" runat="server"  />                          
                
                  <div class="row">    
                  <div class="col s12 m6">
                    <input type="button" class="<%=TableUtils.btnprimary%>" value="SAVE" />                                    
                  </div>
                 <div class="col s12 m6">
                      <input type="button" class="<%=TableUtils.btnprimary2%>" value="DELETE" />    
                 </div>                 
                                 
                 </div>                       
                                        
            
                <table id="caishtb2" class="<%=TableUtils.TableType%>" width="100%">
                <asp:Literal runat="server" ID="litthead2"></asp:Literal>
                <tbody>
                <asp:Repeater ID="rep2" runat="server">
                <ItemTemplate>
                <asp:Literal ID="litTableRows2" runat="server"></asp:Literal>
                </ItemTemplate>
                </asp:Repeater>
                </tbody>
                <asp:Literal runat="server" ID="littfoot2"></asp:Literal>
                </table>           
                                                                
        </div>        
        
    </div>
    
    



    
    
    

             

      <input type="hidden" id="table1sel0" runat="server" />
                                                   
                          
           
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
$(document).ready(function() {
   <asp:Literal runat="server" ID="litsettings"></asp:Literal>  
    <asp:Literal runat="server" ID="litsettings2"></asp:Literal>  
   var table = $('#caishtb').DataTable();   
           
    $('#caishtb tbody').on('click', 'tr', function () {
        var data = table.row( this ).data();   
        $('#<%=table1sel0.clientid%>').val("");
        if (data != null)
        {     
            var seldata = data[table.column('uid:name').index()] + "";
            if (seldata.trim()!="")
                {
                $('#<%=table1sel0.clientid%>').val(seldata);
                }
        }
     });  
   
 });

</script>
</asp:Content>  
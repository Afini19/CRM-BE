<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="mm_businessdays.aspx.vb" Inherits="mmbusinessdays_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  

</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server" class="theform2">                        
<h5>Business Days Settings</h5>
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



       


<div class="row">    
    <div class="col s12 m6">

    <br />                        
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
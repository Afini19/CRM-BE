  <ul id="pagesearchoption" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#0277bd;color:white">
         <h5>Search Options</h5>
         <div style="display:block">&nbsp;</div>
        </div>
    </li>  
  <li>
      <div class="container">
       Member ID :<br />
       <input type="text" runat="server" id="sbgrnno" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
       </div>
   </li>
  <li>
      <div class="container">
       Member Name :<br />
       <input type="text" runat="server" id="sbshipform" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
       </div>
   </li>
  <li>
      <div class="container">
       Member Email / Mobile No :<br />
       <input type="text" runat="server" id="sbdoinv" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
        Join Date From:-<br />
       <input type="text" runat="server" id="sbfromdate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
        Join Date To:-<br />
       <input type="text" runat="server" id="sbtodate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
       </div>
   </li>
   
    <li><div class="divider"></div></li>
    <li><div>&nbsp;&nbsp;</div></li>

      <li>
    <div  class="container"">    
            <button class="btn waves-effect waves-light light-blue darken-3" onclick="$('#<%=eventtype.clientid%>').val('NAVSEARCH');$('[id*=<%=eventfirenorm.clientid%>]').click()" name="btnnavsearch" style="width:100%">Search</button>
     </div>
  </li>
    <li><div>&nbsp;&nbsp;</div></li>

  
  </ul>
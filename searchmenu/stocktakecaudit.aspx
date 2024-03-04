  <ul id="pagesearchoption" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#0277bd;color:white">
         <h5>Search Options</h5>
         <div style="display:block">&nbsp;</div>
        </div>
    </li>  
  <li>
      <div class="container">
       User ID :<br />
       <input type="text" runat="server" id="sbuserid" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
        Part No :<br />
       <input type="text" runat="server" id="sbstockcode" runat="server" style="font-size:0.9rem;background-color:white;text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
       Part Name :<br />
       <input type="text" runat="server" id="sbstockname" runat="server" style="font-size:0.9rem;background-color:white;text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
       Tag No :<br />
       <input type="text" runat="server" id="sbtagno" runat="server" style="font-size:0.9rem;background-color:white;text-decoration:none" />
       </div>
   </li>

    <li><div class="divider"></div></li>
    <li><div>&nbsp;&nbsp;</div></li>

  <li>
    <div  class="container"">    
            <button class="btn waves-effect waves-light light-blue darken-3" onclick="$('#<%=eventtype.clientid%>').val('NAVSEARCH');$('[id*=<%=eventfirenorm.clientid%>]').click()" name="btnnavsearch" style="width:100%">Search</button>
     </div>
  </li>

  </ul>

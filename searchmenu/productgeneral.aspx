  <ul id="pagesearchoption" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#0277bd;color:white">
         <h5>Search Options</h5>
         <div style="display:block">&nbsp;</div>
        </div>
    </li>  
  <li>
      <div class="container">
       Stock Code :<br />
       <input type="text" runat="server" id="sbstockcode" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
       Stock Name :<br />
       <input type="text" runat="server" id="sbstockname" runat="server" style="font-size:0.9rem;background-color:white;text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
       Stock Group :<br />
       <input type="text" runat="server" id="sbstockgroup" runat="server" style="font-size:0.9rem;background-color:white;text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
       Stock Type :<br />
       <input type="text" runat="server" id="sbstocktype" runat="server" style="font-size:0.9rem;background-color:white;text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
       Stock Principal :<br />
       <input type="text" runat="server" id="sbowner" runat="server" style="font-size:0.9rem;background-color:white;text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
       Site ID :<br />
       <input type="text" runat="server" id="sbsiteid" runat="server" style="font-size:0.9rem;background-color:white;text-decoration:none" />
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

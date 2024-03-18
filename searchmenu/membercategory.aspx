  <ul id="pagesearchoption" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#e3458a;color:white">
         <h5>Search Options</h5>
         <div style="display:block">&nbsp;</div>
        </div>
    </li>  
  <li>
    <div class="container">
       Category Code :<br />
       <input type="text" runat="server" id="sbcatcode" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
       </div>
    </li>
  <li>
    <div class="container">
       Category Name :<br />
       <input type="text" runat="server" id="sbcatname" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
    </div>
  </li>

  <li><div>&nbsp;&nbsp;</div></li>   
  <li><div class="divider"></div></li>
  <li><div>&nbsp;&nbsp;</div></li>

  <li>
    <div  class="container"">    
        <button class="btn waves-effect waves-light light-blue darken-3" onclick="$('#<%=eventtype.clientid%>').val('NAVSEARCH');$('[id*=<%=eventfirenorm.clientid%>]').click()" name="btnnavsearch" style="width:100%">Search</button>
    </div>
  </li>
  <li><div>&nbsp;&nbsp;</div></li>
  </ul>

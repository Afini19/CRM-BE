  <ul id="pagesearchoption" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#e3458a;color:white">
         <h5>Search Options</h5>
         <div style="display:block">&nbsp;</div>
        </div>
    </li>  
  <li>
        <div class="container">
           Category :<br />
           <input type="text" runat="server" id="sbcategory" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
           </div>
        </li>
  <li>
        <div class="container">
           Discount Rate :<br />
           <input type="text" runat="server" id="sbdiscrate" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
        </div>
  </li>
  <li>
       <div class="container">
          Spending From :<br />
          <input type="text" runat="server" id="sbspendingfrom" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
       </div>
  </li>
  <li>
      <div class="container">
         Spending To :<br />
         <input type="text" runat="server" id="sbspendingto" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
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

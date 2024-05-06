  <ul id="pagesearchoption" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#e3458a;color:white">
         <h5>Search Options</h5>
         <div style="display:block">&nbsp;</div>
        </div>
    </li>  
<li>
      <div class="container">
         Member ID :<br />
         <input type="text" runat="server" id="sbmemberid" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
      </div>
</li>
<li>
      <div class="container">
         Member Name :<br />
         <input type="text" runat="server" id="sbmembername" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
      </div>
</li>
<li>
      <div class="container">
         Member Type :<br />
         <input type="text" runat="server" id="sbmembertype" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
      </div>
</li>
    <li>
        <div class="container">
           Branch :<br />
           <input type="text" runat="server" id="sbbranch" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
           </div>
        </li>
  <li>
        <div class="container">
           Casher :<br />
           <input type="text" runat="server" id="sbcasher" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
        </div>
  </li>
  <li>
    <div class="container">
        Type :
        <select id="sbtype" runat="server" style="font-size: 0.9rem; background-color: white; text-decoration: none;">
            <option value="" selected="selected">Please Select</option>
            <option value="O">Redeem</option>
            <option value="G">Collect</option>
        </select>
    </div>
</li>
  <li>  
    <div class="container">
        Transaction From Date:-<br />
        <input type="text" runat="server" id="sbtransfromdate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
     </div>
  </li>
  <li>  
    <div class="container">
        Transaction To Date:-<br />
        <input type="text" runat="server" id="sbtranstodate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
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

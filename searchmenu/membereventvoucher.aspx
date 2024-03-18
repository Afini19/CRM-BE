  <ul id="pagesearchoption" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#e3458a;color:white">
         <h5>Search Options</h5>
         <div style="display:block">&nbsp;</div>
        </div>
    </li>  
  <li>
        <div class="container">
           Voucher Code :<br />
           <input type="text" runat="server" id="sbvouchercode" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
           </div>
  </li>
  <li>
        <div class="container">
           Voucher Name :<br />
           <input type="text" runat="server" id="sbvouchername" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
        </div>
  </li>
  <li>
       <div class="container">
          Voucher Type :<br />
          <input type="text" runat="server" id="sbvouchertype" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
       </div>
  </li>
  <li>
      <div class="container">
         Voucher Value :<br />
         <input type="text" runat="server" id="sbvouchervalue" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
      </div>
  </li>
  <li>
        <div class="container">
           Event Code :<br />
           <input type="text" runat="server" id="sbeventcode" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
        </div>
  </li>
  <li>  
   <div class="container">
       Effective From Date:-<br />
       <input type="text" runat="server" id="sbefffromdate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
    </div>
 </li>
 <li>  
   <div class="container">
       Effective To Date:-<br />
       <input type="text" runat="server" id="sbefftodate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
    </div>
  </li>
  <li>  
    <div class="container">
        Created From Date:-<br />
        <input type="text" runat="server" id="sbfromdate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
     </div>
  </li>
  <li>  
    <div class="container">
        Created To Date:-<br />
        <input type="text" runat="server" id="sbtodate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
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

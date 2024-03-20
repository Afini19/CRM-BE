  <ul id="pagesearchoption" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#e3458a;color:white">
         <h5>Search Options</h5>
         <div style="display:block">&nbsp;</div>
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
     Member Phone No. :<br />
     <input type="text" runat="server" id="sbphoneno" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
     </div>
  </li>
<li>
  <div class="container">
     Member Email :<br />
     <input type="text" runat="server" id="sbemail" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
  </div>
</li>
<li>  
  <div class="container">
      DOB From Date:-<br />
      <input type="text" runat="server" id="sbdobfromdate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
   </div>
</li>
<li>  
  <div class="container">
      DOB To Date:-<br />
      <input type="text" runat="server" id="sbdobtodate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
   </div>
</li>
<li>  
  <div class="container">
      Join From Date:-<br />
      <input type="text" runat="server" id="sbjoinfromdate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
   </div>
</li>
<li>  
  <div class="container">
      Join To Date:-<br />
      <input type="text" runat="server" id="sbjointodate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
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

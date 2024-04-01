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
        Status :<br />
        <select id="sbstatus" runat="server" style="font-size: 0.9rem; background-color: white; text-decoration: none;">
            <option value="" selected="selected">Please Select</option>
            <option value="unused">Unused</option>
            <option value="used">Used</option>
        </select>
    </div>
</li>

<li>  
  <div class="container">
      DOB Month From:-<br />
      <select id="sbdobmonthfrom" runat="server" style="font-size: 0.9rem; background-color: white; text-decoration: none;">
        <option value="1" selected="selected">January</option>
        <option value="2">February</option>
        <option value="3">March</option>
        <option value="4">April</option>
        <option value="5">May</option>
        <option value="6">June</option>
        <option value="7">July</option>
        <option value="8">August</option>
        <option value="9">September</option>
        <option value="10">October</option>
        <option value="11">November</option>
        <option value="12">December</option>
      </select>
   </div>
</li>

<li>  
  <div class="container">
      DOB Month To:-<br />
      <select id="sbdobmonthto" runat="server" style="font-size: 0.9rem; background-color: white; text-decoration: none;">
        <option value="1">January</option>
        <option value="2">February</option>
        <option value="3">March</option>
        <option value="4">April</option>
        <option value="5">May</option>
        <option value="6">June</option>
        <option value="7">July</option>
        <option value="8">August</option>
        <option value="9">September</option>
        <option value="10">October</option>
        <option value="11">November</option>
        <option value="12" selected="selected">December</option>
      </select>
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


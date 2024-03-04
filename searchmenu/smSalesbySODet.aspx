
  <ul id="pagesearchoption" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#0277bd;color:white">
         <h5>Search Options</h5>
         <div style="display:block">&nbsp;</div>
        </div>
    </li>  
   <li>
      <div class="container">
       Customer Code :<br />
       <input type="text" runat="server" id="sbcustcode" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
       </div>
   </li>    
   <li>
      <div class="container">
       Customer Name :<br />
       <input type="text" runat="server" id="sbcustname" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
       </div>
   </li>       
  <li>
      <div class="container">
       Product Code :<br />
       <input type="text" runat="server" id="sbstockcode" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
       Product Name :<br />
       <input type="text" runat="server" id="sbstockname" runat="server" style="font-size:0.9rem;background-color:white;text-decoration:none" />
       </div>
   </li>                             
  <li>
       <div class="container">
        Branch Code:<br />
        <table width="100%">
            <tr style="border-bottom: solid 0 white">
                <td width="48%">From:<br /><input type="text" runat="server" id="sbbranchfrom" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" /></td>
                <td width="4%">&nbsp;</td>
                <td width="48%">To:<br /><input type="text" runat="server" id="sbbranchto" runat="server" style="font-size:0.9rem;background-color:white; text-decoration:none" /></td>
           </tr>        
        </table>
     </div>
   </li>
  <li>  
      <div class="container">
        Sales From Date:-<br />
       <input type="text" runat="server" id="sbfromdate" class="datepicker"  style="font-size:0.9rem;background-color:white;text-decoration:none" />
       </div>
   </li>
  <li>  
      <div class="container">
        Sales To Date:-<br />
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

  </ul>

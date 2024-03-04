  <ul id="slide-out" class="sidenav sidenav-fixed" style="max-width:200px">
  <li>
       <img src="../images/officeoneax.png" style="max-width:250px;width:100%">
     <div class="divider"></div>
       
  </li>
  <li>
    <div style="margin:0px 0px 0px 0px;width:100%;max-width:200px; padding:5px 5px 5px 5px; top:0; left:0; bottom:0; height:100%; background-color:white" class="left">
   <div style="text-align:left; width:100%"><a class="subheader"><b>FILTER MENU</b></a></div>

    <div>
          Branch Code:<br />
      <asp:TextBox id="nb_branchcode" runat="server" class="form-input" style="width:100%; max-width:175px;"></asp:TextBox>    
   </div>

     <div>
      Shipment Date:<br />
      <asp:TextBox id="nb_datefrom" runat="server" class="datepicker" style="width:100%; max-width:175px;"></asp:TextBox>    
   </div>


    <asp:Button ID="nb_btn_search" runat="server" Text="Search" class="btn waves-effect waves-light cyan darken-4 caishbutton" />
    <br /><br />
    Shortcut:<br />
    <asp:Button ID="nb_btn_search1" runat="server" Text="All Incomplete" class="btn waves-effect waves-light cyan darken-4 caishbutton" onClick="search1" />
    <asp:Button ID="nb_btn_search2" runat="server" Text="Yesterday Shipments" class="btn waves-effect waves-light cyan darken-4 caishbutton" onClick="search2" style="margin-top:5px" />
    <asp:Button ID="nb_btn_search3" runat="server" Text="Today Shipments" class="btn waves-effect waves-light cyan darken-4 caishbutton" onClick="search3" style="margin-top:5px" />

</div>        

  
  </li>
  </ul>




    <%
        nb_btnback.CssClass = TableUtils.btnprimary4
     %>
  <ul id="slide-out" class="sidenav sidenav-fixed" style="max-width:200px">
  <li>
       <img src="../images/officeoneax.png" style="max-width:250px;width:100%">
       <div class="divider"></div>
       
  </li>
  <li>
    <div style="margin:0px 0px 0px 0px;width:100%;max-width:200px; padding:5px 5px 5px 5px; top:0; left:0; bottom:0; height:100%; background-color:white" class="left">
   <div style="text-align:left; width:100%"><a class="subheader"><b>ACTION MENU</b></a></div>

   <div style="text-align:left; width:100%"><a class="subheader"><b></b></a></div>

             <asp:Button ID="nb_btnsave" runat="server" Text="Auto Distribute" class="btn waves-effect waves-light red darken-3 caishbutton"  OnClick="startdistribute" />
             <br /><br />
             <div style="line-height:normal">Note : Auto Distribute Feature will distribute picked quantities to respective branch</div>
              <div class="divider"></div>            

              <br />
             <asp:Button ID="nb_btnsave2" runat="server" Text="Sort Selected" class="btn waves-effect waves-light red darken-5 caishbutton"  OnClick="sortselected" />
             <br /><br />
             <div style="line-height:normal">Note : To Validate and confirm picked items qty is sorted accordingly to branch bin
             </div>
              <div class="divider"></div>            


             <br /><br />

             <asp:Button ID="nb_btnback" runat="server" Text="<< BACK" class="btn waves-effect waves-light cyan darken-4 caishbutton"  OnClick="backback" />

</div>        

  
  </li>
  </ul>




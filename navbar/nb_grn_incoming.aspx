<%
    nb_btn_search.CssClass = TableUtils.btnprimary
    nb_btn_search1.CssClass = TableUtils.btnprimary2
    nb_btn_search2.CssClass = TableUtils.btnprimary2
    nb_btn_search3.CssClass = TableUtils.btnprimary2

    nb_btn_back.CssClass = TableUtils.btnprimary4

%>
  <ul id="slide-out" class="sidenav sidenav-fixed" style="max-width:200px">
  <li>
       <img src="../images/officeoneax.png" style="max-width:250px;width:100%">
       <div class="divider"></div>
       
  </li>
  <li>
    <div style="margin:0px 0px 0px 0px;width:100%;max-width:200px; padding:5px 5px 5px 5px; top:0; left:0; bottom:0; height:100%; background-color:white" class="left">
   <div style="text-align:left; width:100%"><a class="subheader"><b>FILTER MENU</b></a></div>

    <div>
          Document No:<br />
      <asp:TextBox id="nb_docno" runat="server" class="form-input" style="width:100%; max-width:175px;"></asp:TextBox>    
   </div>

     <div>
      Receiving date:<br />
      <asp:TextBox id="nb_datefrom" runat="server" class="datepicker" style="width:100%; max-width:175px;"></asp:TextBox>    
   </div>


    <asp:Button ID="nb_btn_search" runat="server" Text="Search" class="btn waves-effect waves-light cyan darken-4 caishbutton" />
    <br /><br />
    Shortcut:<br />
    <asp:Button ID="nb_btn_search1" runat="server" Text="Today Incoming" class="btn waves-effect waves-light cyan darken-4 caishbutton"  />
    <asp:Button ID="nb_btn_search2" runat="server" Text="Tomorrow Incoming" class="btn waves-effect waves-light cyan darken-4 caishbutton" style="margin-top:5px" />
    <asp:Button ID="nb_btn_search3" runat="server" Text="Yesterday Incoming" class="btn waves-effect waves-light cyan darken-4 caishbutton"  style="margin-top:5px" />


    <br /><br />
    <div class="divider"></div>
    <asp:Button ID="nb_btn_back" runat="server" Text="<< BACK" class="btn waves-effect waves-light red darken-4 caishbutton" onClick="gotoback"  />

</div>        

  
  </li>
  </ul>




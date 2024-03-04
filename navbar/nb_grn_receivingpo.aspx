<%
    nb_btnreview.CssClass = TableUtils.btnprimary
    nb_btnback.CssClass = TableUtils.btnprimary4
    nb_btn_print1.CssClass = TableUtils.btnprimary3
    %>
  <ul id="slide-out" class="sidenav sidenav-fixed" style="max-width:200px">
  <li>
       <img src="../images/officeoneax.png" style="max-width:250px;width:100%">
       <div class="divider"></div>
       
  </li>
  <li>
    <div style="margin:0px 0px 0px 0px;width:100%;max-width:200px; padding:5px 5px 5px 5px; top:0; left:0; bottom:0; height:100%; background-color:white" class="left">
   
   <div style="text-align:left; width:100%"><a class="subheader"><center><b>JOB QR</b></center></a></div>
   <div style="width:100%;padding : 4px 12px 12px 12px"><asp:Literal runat="server" id="litjobqr"></asp:Literal></div>

    <div class="divider"></div>

   <div style="text-align:left; width:100%"><a class="subheader"><b>PRINT</b></a></div>
    <asp:Button ID="nb_btn_print1" runat="server" Text="Print GRN Count List" class="btn waves-effect waves-light cyan darken-4 caishbutton" OnClick="gotoprint" />

    <div class="divider"></div>

   <div style="text-align:left; width:100%"><a class="subheader"><b>NAVIGATION</b></a></div>
                         <asp:Button ID="nb_btnreview" runat="server" Text="REVIEW DOCUMENT" class="btn waves-effect waves-light cyan darken-3 caishbutton"  OnClick="gotonext" />
                         <asp:Button ID="nb_btnback" runat="server" Text="<< BACK" class="btn waves-effect waves-light cyan darken-4 caishbutton" OnClick="gotoback" style="margin-top:5px;" />

</div>        

  
  </li>
  </ul>




  <ul id="slide-out" class="sidenav sidenav-fixed" style="max-width:200px">
  <li>
       <img src="../images/officeoneax.png" style="max-width:250px;width:100%">
     <div class="divider"></div>
       
  </li>

  <li>
    <div style="margin:0px 0px 0px 0px;width:100%;max-width:200px; padding:5px 5px 5px 5px; top:0; left:0; bottom:0; height:100%; background-color:white" class="left">
   
   <div style="text-align:left; width:100%"><a class="subheader"><center><b>JOB QR</b></center></a></div>
   <div style="width:100%;padding : 4px 8px 8px 8px"><asp:Literal runat="server" id="litjobqr"></asp:Literal></div>

    <div class="divider"></div>

   <div style="text-align:left; width:100%"><a class="subheader"><b>PRINT</b></a></div>
    <asp:Button ID="nb_btn_print1" runat="server" Text="Picklist by Branch" class="btn waves-effect waves-light cyan darken-4 caishbutton" />

    <div class="divider"></div>

   <div style="text-align:left; width:100%"><a class="subheader"><b>NAVIGATION</b></a></div>
    <asp:Button ID="nb_btn_article" runat="server" Text="By Article" class="btn waves-effect waves-light cyan darken-4 caishbutton" onclick="byarticle" />
    <asp:Button ID="nb_btn_branch" runat="server" Text="By Branch" class="btn waves-effect waves-light cyan darken-4 caishbutton" onclick="bybranch" style="margin-top:2px;" />

</div>        

  
  </li>
  </ul>




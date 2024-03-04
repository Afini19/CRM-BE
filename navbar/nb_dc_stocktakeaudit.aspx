  <ul id="slide-out" class="sidenav sidenav-fixed" style="max-width:200px">
  <li>
    <div style="margin:0px 0px 0px 0px;width:100%;max-width:200px; padding:5px 5px 5px 5px; top:0; left:0; bottom:0; height:100%; background-color:white" class="left">
   <div style="text-align:left; width:100%"><a class="subheader"><b>FILTER MENU</b></a></div>

    <div>
          User ID:<br />
      <asp:TextBox id="nb_userid" runat="server" class="form-input" style="width:100%; max-width:175px;"></asp:TextBox>    
   </div>

    <div>
          Part No:<br />
      <asp:TextBox id="nb_part" runat="server" class="form-input" style="width:100%; max-width:175px;"></asp:TextBox>    
   </div>

    <div>
          Part Name:<br />
      <asp:TextBox id="nb_partname" runat="server" class="form-input" style="width:100%; max-width:175px;"></asp:TextBox>    
   </div>
   
    <div>
          Tag No:<br />
      <asp:TextBox id="nb_tagno" runat="server" class="form-input" style="width:100%; max-width:175px;"></asp:TextBox>    
   </div>


    <asp:Button ID="nb_btn_search" onclick="nbsearchdata" runat="server" Text="Search" class="btn waves-effect waves-light cyan darken-4 caishbutton" />
</div>        

  
  </li>
  </ul>




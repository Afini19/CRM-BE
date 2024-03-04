
  <div class="navbar-fixed valign-wrapper" style="position: fixed; top:40px;width:100%;background-color:<%=WebPersonalised.Level2BarColor%>;padding-left:5px;border-bottom:solid 1px #e0e0e0;max-height:40px">

    
       <%If Framework_Back.trim <> "" Then%>
          <div class="left" style="color:white;padding-right:3px; padding-top:5px;max-width:10%">
          <a href="<%=Framework_Back.trim%>"><i class="material-icons" style="color:#00838f">navigate_before</i></a>      
          </div>
       <%End If%>
      <div class="left truncate" style="color::#263238;font-size:0.9rem;max-width:40%">
        <%=WebLib.MerchantName.ToString.ToUpper%>
      </div>

      <div class="left" style="max-width:5%;min-width:5%;display:flex;justify-content:space-between;">
       &nbsp;
      </div>

      <div class="left" style="max-width:40%;min-width:15%;display:flex;justify-content:space-between;">
       <%=Framework_RightNavBar%>
      </div>



   </div>




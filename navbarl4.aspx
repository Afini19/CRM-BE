
  <div class="navbar-fixed valign-wrapper" style="position:fixed;width:100%;color:<%=WebPersonalised.Level4ForeColor%>;background-color:<%=WebPersonalised.Level4BarColor%>;padding-left:5px;border-bottom:solid 1px <%=WebPersonalised.Level4BorderColor%>;max-height:40px">
      
      
      <%If Framework_Back.trim <> "" Then%>
      <div class="left" style="color:white;padding-right:3px;max-width:10%">
      <a href="<%=Framework_Back.trim%>"><i class="material-icons" style="color:#00838f">navigate_before</i></a>      
      </div>
     <%End If%>

      <div class="left truncate" style="color::#263238;font-size:0.9rem;max-width:40%">
        <%=WebLib.MerchantName.ToString.ToUpper%>
      </div>
      <div class="left" style="max-width:5%;min-width:5%;display:flex;justify-content:space-between;">
       &nbsp;
      </div>
      <%If Framework_RightNavBar.trim <> "" Then%>
      <div class="left" style="max-width:40%;min-width:15%;display:flex;justify-content:space-between;color:White">
       <%=Framework_RightNavBar%>
      </div>
      <%End If%>
      <div class="right" style="max-width:50%;min-width:15%;position:absolute;display:flex;justify-content:space-between;color:white;right:5px">
      <%If Framework_StatusDD = True Then%>
       <span style="display:flex;">
       <a href="#!" id="gblddstatus" data-target='gbldoption' onclick="$('#gblddstatus').dropdown({coverTrigger: false,constrainWidth : false});$('#gblddstatus').dropdown('open');">Status<i class="material-icons">keyboard_arrow_down</i></a>
       </span>
      <%end if%>
      
      
      
      <span style="display:flex;">
      <%If Framework_DBSearch = True Then%>
      <span style="margin-right:5px"><a href="#" id="pagedbsearch" data-target="pagesearchoption" class="sidenav-trigger"><i class="material-icons" style="color:black">search</i></a></span>      
      <%end if%>
      <%If Framework_PageOption = True Then%>
      <span style="margin-right:5px"><a href="#" id="pagedtfilter" data-target="pagedtfilteroption" onclick="$('#pagedtfilter').dropdown({coverTrigger: false,constrainWidth : false});$('#pagedtfilter').dropdown('open');"><i class="material-icons" style="color:black">view_module</i></a></span>      
      <span style="margin-right:5px"><a href="#" id="pagesel" data-target="pageseloption" onclick="$('#pagesel').dropdown({coverTrigger: false,constrainWidth : false});$('#pagesel').dropdown('open');"><i class="material-icons" style="color:black">dns</i></a></span>      
      <%end if%>
      </span>
      
      
      
      
      <%If Framework_SearchGrid = True Then%>
       <span style="display:flex;">
       <input type="text" id="topnavsearchbox" style="max-width:120px;font-size:0.9rem;background-color:white;text-decoration:none" class="form-input" placeholder="Search Grid" />
       </span>
      <%end if%>
      </div>
   </div>




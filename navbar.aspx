   <div class="navbar-fixed black valign-wrapper" style="max-height:48px;position: fixed;width:100%">

      <div class="left" style="color:white;padding-right:5px;">
      <a href="#" data-target="slide-out" class="sidenav-trigger"><i class="material-icons">apps</i></a>      
      </div>
 
      <div class="left truncate" style="color:white;max-width:40%">
       POSPLUS CRM PLUGIN
      </div>

      <div class="right" style="max-width:200px;min-width:20%;position:absolute;display:flex;justify-content:space-between;color:white;right:5px">
      <span style="display:flex;" onclick="$.colorbox({transition:'none',height:'60%',width:'60%',iframe:'true',href:'<%=Page.ResolveClientUrl("~/security/selectbranch.aspx")%>',onClosed:function() { location.reload(true); }});"><i class="material-icons" style="color:white;padding-left:10px">star_border</i></span>
      <span style="display:flex;"><a href="#" data-target="pagesecurity" class="sidenav-trigger"><i class="material-icons" style="color:white;padding-left:10px">lock_outline</i></a></span>
      <span style="display:flex;"><a href="#" data-target="pageprofile" class="sidenav-trigger"><i class="material-icons" style="color:white;padding-left:10px">account_circle</i></a></span>
      <span style="display:flex;"><a href="<%=Page.ResolveClientUrl("~/logout.aspx")%>" style="text-decoration:none;"><i class="material-icons" style="color:red;padding-left:10px">power_settings_new</i></a></span>
      </div>
           
 </div>
  <ul id="slide-out" class="sidenav" style="background-color:<%=WebPersonalised.NavBarColor%>">
    <li><div class="user-view" style="background-color:white">
       <img src="<%= Page.ResolveClientUrl("~/merchantimage/" & WebPersonalised.LogoFile & "")%>" style="max-width:250px;width:100%">
      <div style="line-height:normal;color:black">
      Login User : <%=WebLib.UserName %><br />Login Branch :  <%=WebLib.BranchName%>
      </div>
      <div style="display:block">&nbsp;</div>
    </div></li>
    <li><a href="<%=Page.ResolveClientUrl("~/pospluscrm/MemberCategorylist.aspx")%>" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Member Category</a></li>
    <li><a href="<%=Page.ResolveClientUrl("~/pospluscrm/MemberCategorylistme.aspx")%>" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Category Mechanism</a></li>
    <li><a href="<%=Page.ResolveClientUrl("~/pospluscrm/voucherlist.aspx")%>" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Voucher Admin</a></li>
    <li><a href="<%=Page.ResolveClientUrl("~/pospluscrm/Membereventvoucherlist.aspx")%>" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Event Based Voucher Settings</a></li> 
    <li><a href="<%=Page.ResolveClientUrl("~/pospluscrm/MembereventCategorylistme.aspx")%>" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Event Based Point Settings</a></li>  
    <li><div class="divider"></div></li>    
    <li><a href="#" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>e-Menu Setup</a></li>
    <li><a href="#" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Event Code Admin</a></li>     
    <li><a href="#" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Manual Voucher Issue</a></li> 
    <li><a href="#"  class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Member Details</a></li>
    <li><a href="#" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Member Dashboard</a></li>
    <li><a href="<%=Page.ResolveClientUrl("~/pospluscrm/memberpointtranslist.aspx")%>" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Member Points Transaction</a></li>
    <li><a href="<%=Page.ResolveClientUrl("~/pospluscrm/membervouchertranslist.aspx")%>" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Member Voucher Trans.</a></li>  
    <li><a href="<%=Page.ResolveClientUrl("~/pospluscrm/memberpointenqlist.aspx")%>" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Member Points Enquiry</a></li>  
    <li><a href="<%=Page.ResolveClientUrl("~/pospluscrm/membervoucherenqlist.aspx")%>" class="waves-effect" style="text-decoration:none;color:white"><i class="material-icons" style="color:white">folder</i>Member Voucher Enquiry</a></li>  
  </ul>

  <ul id="pagefav" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#b2ebf2;color:black">
         <h5>My Favourites</h5>
         <div style="display:block">&nbsp;</div>
      </div>
    </li>  
  </ul>
    <ul id="pageprofile" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#c8e6c9;color:black">
         <h5>My Profile</h5>
         <div style="display:block">&nbsp;</div>
      </div>
    </li>  
  </ul>
  
    <ul id="pagesecurity" class="sidenavright sidenav" style="background-color:white;">
    <li><div class="user-view" style="background-color:#ffecb3;color:black">
         <h5>Security</h5>
         <div style="display:block">&nbsp;</div>
      </div>
    </li>  
  </ul>
  

<%If Framework_MenuLeftBar = True Then%>
<div class="navbar-fixed hide-on-med-and-down" style="position: fixed;left:0;top:80px;bottom:40px;width:100%;background-color:<%=WebPersonalised.SideMenuBarColor%>;border-right:solid 1px <%=WebPersonalised.SideMenuBorderColor%>;<%=WebMenuEnquiry.LeftBarWidthCSS%>;height:100%">
    <center><div style="width:90%">
        <br />
        <%=Framework_MenuLeftCode%>
    </div></center>
</div>
<%end if%>


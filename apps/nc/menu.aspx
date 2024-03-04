<%@  Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="dashboard.aspx.vb" Inherits="nc_dashboard_class" MasterPageFile="~/Site.Master" %>  
<asp:Content ID="ctheader" ContentPlaceHolderID="head" runat="server">   
<script src="<%= Page.ResolveClientUrl("~/vendor/MetroJS/MetroJs.js")%>"></script>
<link href="<%= Page.ResolveClientUrl("~/vendor/MetroJS/MetroJs.css")%>" rel="stylesheet" type="text/css" />

</asp:Content>  
<asp:Content ID="ctbodytop" ContentPlaceHolderID="body" runat="server">  


</asp:Content>  

<asp:Content ID="ctbody" ContentPlaceHolderID="ContentArea" runat="server">  
<div class="caishform">
<form id="frmform" runat="server">
<!-- Apply blue theme as default for all tiles -->
<div id="tiles" class="blue"> 


<div class="live-tile" data-stops="100%" data-speed="750" data-delay="3000" onclick="location.href='add.aspx'">
<span class="tile-title"><center>
<a href="add.aspx"><i class='fa fa-5x fa-cloud-upload'></i></a><br />
New Name Card
</center><br /></span>
<p>Upload New Name Card</p>
</div>

<div class="green live-tile" data-stops="100%" data-speed="750" data-delay="4000" onclick="location.href='listing.aspx'">
<span class="tile-title"><center>
<a href="listing.aspx"><i class='fa fa-5x fa-search'></i></a><br />
Search
</center><br /></span>
<p>Search Name Card</p>
</div>

<div class="magenta list-tile"> 
<ul class="flip-list fourTiles" data-mode="flip-list" data-delay="3000">
<li>
<div style="text-align: center;vertical-align: middle; line-height: 80px" onclick="location.href='dashboard.aspx'"><i class="fa fa-3x fa-bar-chart"></i></div>
<div style="text-align: center;vertical-align: middle; line-height: 80px" onclick="location.href='dashboard.aspx'"><span style="font-size:0.8em;">Dashboard</span></div>
</li>
<li>
<div style="text-align: center;vertical-align: middle; line-height: 80px" onclick="location.href='home.aspx'"><i class="fa fa-3x fa-home"></i></div>
<div style="text-align: center;vertical-align: middle; line-height: 80px" onclick="location.href='home.aspx'"><span style="font-size:0.8em">Home</span></div>
</li>
<li>
<div style="text-align: center;vertical-align: middle; line-height: 80px" onclick="location.href='help.aspx'"><i class="fa fa-3x fa-info-circle"></i></div>
<div style="text-align: center;vertical-align: middle; line-height: 80px" onclick="location.href='help.aspx'"><span style="font-size:0.8em">Help</span></div>
</li>
<li>
<div style="text-align: center;vertical-align: middle; line-height: 80px" onclick="location.href='favourites.aspx'"><i class="fa fa-3x fa-star"></i></div>
<div style="text-align: center;vertical-align: middle; line-height: 80px" onclick="location.href='favourites.aspx'"><span style="font-size:0.8em">Bookmark</span></div>
</li>
</ul>
</div>

<div class="red live-tile" data-stops="100%" data-speed="750" data-delay="100000" onclick="location.href='settings.aspx'">
<span class="tile-title"><center>
<a href="settings.aspx"><i class='fa fa-5x fa-gear'></i></a><br />
Settings
</center><br /></span>
<p>Maintain Master Data Settings</p>
</div>


</div>
                                                                                                
</form>
</div>                        
</asp:Content>
<asp:Content ID="ctfoot" ContentPlaceHolderID="foot" runat="server">  
<script type="text/javascript">
    // apply regular slide universally unless .exclude class is applied 
    // NOTE: The default options for each liveTile are being pulled from the 'data-' attributes
    $(".live-tile, .flip-list").not(".exclude").liveTile();
</script>
</asp:Content>  
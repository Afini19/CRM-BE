<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8" />
		<meta name="author" content="www.frebsite.nl" />
		<meta name="viewport" content="width=device-width initial-scale=1.0 maximum-scale=1.0 user-scalable=yes" />

		<title></title>

	    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
	    <link rel="stylesheet" type="text/css" href="css/default.css">
		<link rel="stylesheet" type="text/css" href="css/jquery.mmenu.all.css" />
          <style type="text/css">
              .mm-menu {
                --mm-color-background:#F4F4F4;
                --mm-color-background-emphasis:#F4F4F4;
                --mm-color-text:#666666;
                --mm-color-border: #E4E4E4;
                --mm-color-button:#666666;
                --mm-color-text-dimmed:#4bb5ef;
                --mm-color-background-highlight:#DADADA;
              }

           </style>
		<style  type="text/css">
			@media (min-width: 2048px) {
				.header a {
					display: none;
				}
			}

			.mm-navbar_tabs span {
				display: inline-block;
				margin-left: 8px;
			}
			@media (max-width: 450px) {
				.mm-navbar_tabs span {
					display: none;
				}
			}
		</style>

	    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
		<script src="vendor/menu/jquery.mmenu.all.js"></script>
		<script>
			$(function() {
				$('nav#menu').mmenu({
					extensions	: [ 'theme-dark' ],
					setSelected	: true,
					counters	: true,
					searchfield : {
						placeholder		: 'Search menu items'
					},
					iconbar		: {
						add 		: true,
						size		: 40,
						top 		: [ 
							'<a href="#/"><span class="fa fa-home"></span></a>'
						],
						bottom 		: [
							'<a href="#/"><span class="fa fa-twitter"></span></a>',
							'<a href="#/"><span class="fa fa-facebook"></span></a>',
							'<a href="#/"><span class="fa fa-youtube"></span></a>'
						]
					},
					sidebar		: {
						collapsed		: {
							use 			: '(min-width: 450px)',
							size			: 40,
							hideNavbar		: false
						},
						expanded		: {
							use 			: '(min-width: 2048px)',
							size			: 35
						}
					},
					navbars		: [
						{
							content		: [ 'searchfield' ]
						}, {
							type		: 'tabs',
							content		: [ 
								'<a href="#panel-menu"><i class="fa fa-bars"></i> <span>Menu</span></a>', 
								'<a href="#panel-account"><i class="fa fa-user"></i> <span>Account</span></a>', 
								'<a href="#panel-cart"><i class="fa fa-shopping-cart"></i> <span>Cart</span></a>'
							]
						}, {
							content		: [ 'prev', 'breadcrumbs', 'close' ]
						}, {
							position	: 'bottom',
							content		: [ '<a href="logout">LOG OUT</a>' ]
						}
					]
				}, {
					searchfield : {
						clear 		: true
					},
					navbars		: {
						breadcrumbs	: {
							removeFirst	: true
						}
					}
				});
			});
		</script>
	</head>
	<body>
		<div id="page">
			<div class="menu-header">
				<a href="#menu"><span></span></a>
				Caish Office Suite
			</div>
			<div class="page-content">
			    <form id="frmform" runat="server">
                    <asp:TextBox runat="server"></asp:TextBox>
			    
			    </form>
			</div>
			<nav id="menu">
				<div id="panel-menu">
					<ul>
						<li><a href="/main.aspx">Home</a></li>
						<li><span>Sales Force</span>
							<ul>
								<li><a href="">Name Card Management</a></li>
								<li><a href="">Reminders</a></li>
							</ul>
						</li>
                		<li><span>Document Management</span>
							<ul>
								<li><a href="">Dashboard</a></li>
								<li><a href="">Search Documents</a></li>								
							</ul>
						</li>				
						<li class="Divider">My Favourites</li>
						<li><a href="default.html">Default demo</a></li>
						<li><a href="onepage.html">One page demo</a></li>
					</ul>
				</div>

				<div id="panel-account">
					<ul>
						<li><a href="/modules/profile/myprofile.aspx">My profile</a></li>
						<li><a href="/modules/profile/changepwd.aspx">Change Password</a></li>
						<li><a href="/logout.aspx">Sign out</a></li>
					</ul>
				</div>

				<div id="panel-cart">
					<p style="text-align: center; padding-top: 30px;">Your shoppingcart is empty.<br />
						<a href="#/">Continue shopping.</a></p>
				</div>
			</nav>
		</div>
	</form>
	</body>
</html>

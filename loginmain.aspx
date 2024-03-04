<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="loginmain.aspx.vb" Inherits="loginmain_class" %>
<!DOCTYPE html>
<html lang="en">
<head>
	<title></title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
<!--===============================================================================================-->
</head>
<body style="background-color:black">
<form id="frmform" runat="server">	
	<div class="limiter">
		<div class="container-login100" style="background-color:black;background-image: url('bg/<%=WebPersonalised.LoginBG%>'); background-position:center; background-repeat:no-repeat">
			<div class="wrap-login100">
				<form class="login100-form validate-form">
					<span class="login100-form-title p-b-1">
					    <img src="merchantimage/radiant.png" style="max-width:300px" />						
					</span>
					<div>
					    <h6>Please Enter Login ID and Password</h6>
					    <br />
					</div>		
					<div class="wrap-input100 validate-input" data-validate = "Valid email is: a@b.c">
						<asp:TextBox ID="loginid" runat="server" class="input100" type="text" name="email"></asp:TextBox>
						
						<span class="focus-input100" data-placeholder="Login ID"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Enter password">
						<span class="btn-show-pass">
							<i class="zmdi zmdi-eye"></i>
						</span>
						<asp:TextBox ID="loginpassword" runat="server" class="input100" type="password" name="pass"></asp:TextBox>
						<span class="focus-input100" data-placeholder="Password"></span>
					</div>
					<div class="container-login100-form-btn">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"></div>
							<asp:LinkButton ID="SubmitButton" UseSubmitBehavior="false" Text="PROCEED >>>" Runat="server" OnClick="loginpage" CssClass="login100-form-btn" />																						
						</div>
					</div>
					<div class="default-container-errormsg" style="color:Red; text-align:center"><asp:Literal runat="server" ID="lblmessage"></asp:Literal></div>

				</form>
			</div>
		</div>
	</div>
	

	<div id="dropDownSelect1"></div>
	
<!--===============================================================================================-->
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>
</form> 
</body>
</html>
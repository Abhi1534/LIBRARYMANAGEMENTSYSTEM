<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">
    <title>THCAA - Dashboard Login</title>

    <!-- Favicon -->
    <link rel="shortcut icon" type="image/x-icon" href="../../images/MainLogo.png">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">

    <!-- Fontawesome CSS -->
    <link rel="stylesheet" href="assets/css/font-awesome.min.css">

    <!-- Main CSS -->
    <link rel="stylesheet" href="assets/css/style.css">

    <!--[if lt IE 9]>
			<script src="assets/js/html5shiv.min.js"></script>
			<script src="assets/js/respond.min.js"></script>
		<![endif]-->
    <style>.ch{padding-left:100px;}</style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Main Wrapper -->
        <div class="main-wrapper login-body">
            <div class="login-wrapper">
                <div class="container">
                    <div class="loginbox">
                        <div class="login-left">
                            <img src="../../images/MainLogo.png" class="img-fluid" alt="Logo">
                            <%--<img class="img-fluid" src="../../images/MainLogo.png" alt="Logo">--%>
                        </div>
                        <div class="login-right">
                            <div class="login-right-wrap">
                                <h1>Login</h1>
                                <p class="account-subtitle">Access to our dashboard</p>

                                <!-- Form -->
                                <div class="form-group">
                                                <label class="focus-label">Mobile</label>
                                                <asp:TextBox runat="server" class="form-control" placeholder="Mobile" required="" ID="txt_Mobilenumber" MaxLength="10" pattern="[0-9]{10}" />
                                                <%--	<input type="email" class="form-control floating">--%>
                                            </div>
                                            <div class="form-group">
                                                <label class="focus-label"></label>
                                                <%--<input type="password" class="form-control floating">--%>
                                                <asp:TextBox runat="server" class="form-control" placeholder="Password" required="" ID="txt_password" TextMode="Password" Visible="true" />
                                                <asp:TextBox runat="server" ID="txt_otp" class="form-control" placeholder="please enter 4 digit otp" required="" Visible="false" />
                                                <br />
                                                <div class="alert alert-danger" runat="server" visible="false" id="div_fail">
                                                    <strong>please enter mobile number!</strong>
                                                </div>
                                                 <div class="alert alert-danger" runat="server" visible="false" id="div_otpwrong">
                                                    <strong>OTP Incorrect!</strong>
                                                </div>
                                                 <div class="alert alert-success" id="div_success" runat="server" visible="false">
                <strong>OTP send Successfully.</strong>.
            </div>
                                            </div>
                                            <div class="text-right">
                                                <asp:LinkButton Text="Login with OTP" OnClick="btn_loginwithotp_Click" runat="server" ID="btn_loginwithotp" ForeColor="Blue" Font-Underline="true" Visible="true" CausesValidation="false" />
                                               </div>

                                            <div class="text-left">
                                                <asp:CheckBox Text="Remember" runat="server" ID="cb_Remember" />
                                            </div>

                                            <%--	<div class="text-right">
												<a class="forgot-link" href="forgot-password.html">Forgot Password ?</a>
											</div>--%>

                                            <asp:Button Text="Login" runat="server" class="btn btn-primary btn-block btn-lg login-btn" ID="btn_login" OnClick="btn_login_Click" />
                                             <asp:LinkButton Text="Login with Password" OnClick="btn_loginwithpassword_Click" runat="server" ID="btn_loginwithpassword" ForeColor="Blue" Font-Underline="true" Visible="false" CausesValidation="false" />
                                            
                                            <div class="login-or">


                                                <span class="or-line"></span>
                                                <span class="span-or">or</span>
                                            </div>
                                            <%--<div class="row form-row social-login">
												<div class="col-6">
													<a href="#" class="btn btn-facebook btn-block"><i class="fab fa-facebook-f mr-1"></i> Login</a>
												</div>
												<div class="col-6">
													<a href="#" class="btn btn-google btn-block"><i class="fab fa-google mr-1"></i> Login</a>
												</div>
											</div>--%>
                                           <%-- <div class="text-center dont-have">Don’t have an account?<asp:LinkButton ID="lnkRegister" runat="server" OnClick="lnkRegister_Click" ForeColor="#09dca4">Register</asp:LinkButton></div>
                                       --%>
<%--                                <div class="form-group">
                                    <asp:TextBox runat="server" class="form-control" placeholder="Email" required="" ID="txt_email"  />
                                </div>
                                <div class="form-group">
                                    <asp:TextBox runat="server" class="form-control" placeholder="Password" required="" ID="txt_password" TextMode="Password" />
                                </div>
                                <div class="form-group">
                                    <asp:Button Text="Login" runat="server" class="btn btn-primary btn-block" ID="btn_login" OnClick="btn_login_Click" />
                                   
                                     </div>

                                <!-- /Form -->
                                <div class="text-left">
                                    <asp:CheckBox Text="Remember" runat="server" ID="cb_Remember" />
                                </div>

                                <div class="text-center forgotpass"><a href="forgot-password.html">Forgot Password?</a></div>--%>
                                <%--<div class="login-or">
									<span class="or-line"></span>
									<span class="span-or">or</span>
								</div>
                                --%>
                                <!-- Social Login -->
                                <%--<div class="social-login">
									<span>Login with</span>
									<a href="#" class="facebook"><i class="fa fa-facebook"></i></a><a href="#" class="google"><i class="fa fa-google"></i></a>
								</div>--%>
                                <!-- /Social Login -->

                                <!-- <div class="text-center dont-have">Don’t have an account? <a href="register.html">Register</a></div> -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /Main Wrapper -->

        <!-- jQuery -->
        <script src="assets/js/jquery-3.2.1.min.js"></script>

        <!-- Bootstrap Core JS -->
        <script src="assets/js/popper.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>

        <!-- Custom JS -->
        <script src="assets/js/script.js"></script>
    </form>
</body>
</html>

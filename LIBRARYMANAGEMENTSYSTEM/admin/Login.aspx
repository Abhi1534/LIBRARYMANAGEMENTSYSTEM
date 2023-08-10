<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" EnableEventValidation="false" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>THCAA</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">

    <!-- Favicons -->
    <link href="../images/MainLogo.png" rel="icon">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">

    <!-- Fontawesome CSS -->
    <link rel="stylesheet" href="assets/plugins/fontawesome/css/fontawesome.min.css">
    <link rel="stylesheet" href="assets/plugins/fontawesome/css/all.min.css">

    <!-- Main CSS -->
    <link rel="stylesheet" href="assets/css/style.css">

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
			<script src="assets/js/html5shiv.min.js"></script>
			<script src="assets/js/respond.min.js"></script>
		<![endif]-->

</head>
<body class="account-page">
    <form id="form1" runat="server">
        <!-- Main Wrapper -->
        <div class="main-wrapper">

            <!-- Header -->
            <header class="header">
                <nav class="navbar navbar-expand-lg header-nav">
                    <div class="navbar-header">
                        <a id="mobile_btn" href="javascript:void(0);">
                            <span class="bar-icon">
                                <span></span>
                                <span></span>
                                <span></span>
                            </span>
                        </a>
                        <a href="../index.aspx" class="navbar-brand logo">
                            <%--<img src="../images/thcaa1.png" class="img-fluid" alt="Logo">--%>
                            <img src="../../images/Sublogo.png" height="80px" alt="Logo">
                        </a>
                    </div>
                    <div class="main-menu-wrapper">
                        <div class="menu-header">
                            <a href="../index.aspx" class="menu-logo">
                                <img src="../images/MainLogo.png" class="img-fluid" alt="Logo">
                            </a>
                            <a id="menu_close" class="menu-close" href="javascript:void(0);">
                                <i class="fas fa-times"></i>
                            </a>
                        </div>

                    </div>
                    <ul class="nav header-navbar-rht">
                        <li class="nav-item contact-item">
                            <div class="header-contact-img">
                                <i class="far fa-hospital"></i>
                            </div>
                            <div class="header-contact-detail">
                                <p class="contact-header">Contact</p>
                                <p class="contact-info-header">+91 81259 13755</p>
                            </div>
                        </li>

                    </ul>
                </nav>
            </header>
            <!-- /Header -->

            <!-- Page Content -->
            <div class="content">
                <div class="container-fluid">

                    <div class="row">
                        <div class="col-md-8 offset-md-2">

                            <!-- Login Tab Content -->
                            <div class="account-content">
                                <div class="row align-items-center justify-content-center">
                                    <div class="col-md-7 col-lg-6 login-left">
                                        <img src="../images/hvcopy.png" class="img-fluid" alt="Doccure Login">
                                    </div>
                                    <div class="col-md-12 col-lg-6 login-right">
                                        <div class="login-header">
                                            <h3>Login <span>THCAA</span></h3>
                                        </div>
                                        <form>
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
                                            <div class="text-center dont-have">Don’t have an account?<asp:LinkButton ID="lnkRegister" runat="server" OnClick="lnkRegister_Click" ForeColor="#09dca4">Register</asp:LinkButton></div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                            <!-- /Login Tab Content -->

                        </div>
                    </div>

                </div>

            </div>
            <!-- /Page Content -->

            <!-- Footer -->
            <footer class="footer">

                <!-- Footer Top -->
                <div class="footer-top">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-9 col-md-9">

                                <!-- Footer Widget -->
                                <div class="footer-widget footer-about">
                                    <div class="footer-logo">
                                    </div>
                                    <div class="footer-about-content">
                                        <p>Disclaimer: While every effort has been made to keep the information on this site accurate. The material contained on this site and on the associated web pages is general information and is not intended to be advice on any particular matter. Visitors to this site should seek appropriate and verify all information before acting on the basis of any information contained herein. The TELANGANA High Court Advocates Association expressly disclaim any and all liability to any person, in respect of anything and of the consequences of anything done or omitted to be done by any such person in reliance upon the contents of this site and associated web pages.</p>
                                        <div class="social-icon">
                                            <ul>
                                                <li>
                                                    <a href="#" target="_blank"><i class="fab fa-facebook-f"></i></a>
                                                </li>
                                                <li>
                                                    <a href="#" target="_blank"><i class="fab fa-twitter"></i></a>
                                                </li>
                                                <li>
                                                    <a href="#" target="_blank"><i class="fab fa-linkedin-in"></i></a>
                                                </li>
                                                <li>
                                                    <a href="#" target="_blank"><i class="fab fa-instagram"></i></a>
                                                </li>
                                                <li>
                                                    <a href="#" target="_blank"><i class="fab fa-dribbble"></i></a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <!-- /Footer Widget -->

                            </div>





                            <div class="col-lg-3 col-md-3">

                                <!-- Footer Widget -->
                                <div class="footer-widget footer-contact">
                                    <h2 class="footer-title">Contact Us</h2>
                                    <div class="footer-contact-info">
                                        <div class="footer-address">
                                            <span><i class="fas fa-map-marker-alt"></i></span>
                                            <p>Telangana High Court Advocates’ Association, Survey No. 8 & 9, Hyderabad, Telangana -98, India. </p>
                                        </div>
                                        <p>
                                            <i class="fas fa-phone-alt"></i>
                                            +91 81259 13755
                                        </p>
                                        <p class="mb-0">
                                            <i class="fas fa-envelope"></i>
                                            telanganahcaa@gmail.com
                                        </p>
                                    </div>
                                </div>
                                <!-- /Footer Widget -->

                            </div>

                        </div>
                    </div>
                </div>
                <!-- /Footer Top -->

                <!-- Footer Bottom -->
                <div class="footer-bottom">
                    <div class="container-fluid">

                        <!-- Copyright -->
                        <div class="copyright">
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="copyright-text">
                                        <p class="mb-0">© 2023 Telangana High Court Advocates’ Association. All rights reserved.</p>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">

                                    <!-- Copyright Menu -->
                                    <div class="copyright-menu">
                                        <ul class="policy-menu">
                                            <li><a href="term-condition.html">Terms and Conditions</a></li>
                                            <li><a href="privacy-policy.html">Policy</a></li>
                                        </ul>
                                    </div>
                                    <!-- /Copyright Menu -->

                                </div>
                            </div>
                        </div>
                        <!-- /Copyright -->

                    </div>
                </div>
                <!-- /Footer Bottom -->

            </footer>
            <!-- /Footer -->

        </div>
    </form>
    <!-- /Main Wrapper -->

    <!-- jQuery -->
    <script src="assets/js/jquery.min.js"></script>

    <!-- Bootstrap Core JS -->
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!-- Custom JS -->
    <script src="assets/js/script.js"></script>

</body>
</html>

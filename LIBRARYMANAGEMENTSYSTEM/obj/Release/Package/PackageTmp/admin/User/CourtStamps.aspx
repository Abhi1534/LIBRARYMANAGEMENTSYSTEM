<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourtStamps.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.User.CourtStamps" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        table#ContentPlaceHolder1_grid_data th.gridHeadStyle, tr td {
            border: 1px solid #dee2e6;
            padding: 10px;
            text-align: center;
        }

        th.gridHeadStyle {
            background: #cdcdcd;
        }

        table#ContentPlaceHolder1_grid_data th {
            background: #cdcdcd;
            padding: 11px 2px;
            text-align: center;
        }

        .zoom {
            transition: transform .2s;
            width: 300px;
            height: 300px;
        }

            .zoom:hover {
                -ms-transform: scale(1.5); /* IE 9 */
                -webkit-transform: scale(1.5); /* Safari 3-8 */
                transform: scale(5.1);
            }

        .chkChoice input {
            margin-left: 10px;
            margin-right: 5px;
        }

        .myCheckBoxList label {
            padding-right: 20px;
        }
    </style>

    <meta charset="utf-8">
    <title>THCAA</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">

    <!-- Favicons -->
    <link href="../../images/MainLogo.png" rel="icon">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css">

    <!-- Fontawesome CSS -->
    <link rel="stylesheet" href="../assets/plugins/fontawesome/css/fontawesome.min.css">
    <link rel="stylesheet" href="../assets/plugins/fontawesome/css/all.min.css">

    <!-- Main CSS -->
    <link rel="stylesheet" href="../assets/css/style.css">

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
			<script src="assets/js/html5shiv.min.js"></script>
			<script src="assets/js/respond.min.js"></script>
		<![endif]-->
    <style>
        span.select2.select2-container.select2-container--default.select2-container--below.select2-container--focus {
            display: none;
        }

        span.select2.select2-container.select2-container--default.select2-container--below {
            display: none !important;
        }

        span.select2-selection.select2-selection--single {
            visibility: collapse;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <body class="account-page">
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                </asp:ScriptManager>
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
                                <a href="index.aspx" <%--class="navbar-brand logo"--%>>
                                    <img src="../../images/Sublogo.png" height="80px" alt="Logo">
                                </a>
                            </div>
                            <div class="main-menu-wrapper">
                                <div class="menu-header">
                                    <a href="index.aspx" class="menu-logo">
                                        <img src="../../images/MainLogo.png" class="img-fluid" alt="Logo">
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

                    <!-- Breadcrumb -->
                    <div class="breadcrumb-bar" style="background-color: #000">
                        <div class="container-fluid">
                            <div class="row align-items-center">
                                <div class="col-md-6 col-6">
                                    <nav aria-label="breadcrumb" class="page-breadcrumb">
                                        <ol class="breadcrumb">
                                            <li class="breadcrumb-item"><a href="../../index.aspx">Home</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Court Stamps</li>
                                        </ol>
                                    </nav>


                                </div>

                            </div>
                        </div>
                    </div>
                    <!-- /Breadcrumb -->

                    <!-- Page Content -->

                    <div class="content">
                        <div class="container-fluid">

                            <div class="row">

                                <!-- Profile Sidebar -->

                                <div class="col-md-12 col-lg-12 col-xl-12" data-select2-id="9">

                                    <!-- Basic Information -->
                                    <div class="card">
                                        <div class="card-body" data-select2-id="7">

                                            <!-- Page Header -->
                                            <div class="page-header">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <h3 class="page-title">Court Stamps</h3>

                                                    </div>
                                                </div>
                                            </div>
                                            <!-- /Page Header -->


                                            <div class="row">

                                                <div class="col-lg-5">
                                                    <div class="form-group">
                                                        <label id="lbl_barcode" runat="server" visible="false">Bar Code<span class="text-danger"></span></label>
                                                        <asp:Image ID="ImageGeneratedBarcode" runat="server" CssClass="img-thumbnail" Visible="false" />

                                                    </div>
                                                </div>

                                                <div class="alert alert-success" id="div_success" runat="server" visible="false">
                                                    <strong runat="server" id="strSuccessMsg">Success!</strong>.
                                                </div>
                                                <div class="alert alert-danger" runat="server" visible="false" id="div_fail">
                                                    <strong runat="server" id="strFailMsg">fail!</strong>
                                                </div>


                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="card">
                                                            <div class="card-body custom-edit-service">



                                                                <div class="service-fields mb-3">
                                                                    <div class="row">
                                                                        <div class="col-lg-4">
                                                                            <div class="form-group">
                                                                                <label>Name<span class="text-danger">*</span></label>
                                                                                <asp:TextBox runat="server" class="form-control" ID="txt_Advocatename" required="" />

                                                                            </div>
                                                                        </div>

                                                                        <div class="col-lg-4">
                                                                            <div class="form-group">
                                                                                <label>Mobile Number<span class="text-danger">*</span></label>
                                                                                <asp:TextBox runat="server" pattern="[7-9]{1}[0-9]{9}" class="form-control" ID="txt_MobileNumber" required="" />

                                                                            </div>
                                                                        </div>


                                                                        <div class="col-lg-4">
                                                                            <div class="form-group">
                                                                                <label>Email<span class="text-danger">*</span></label>
                                                                                <asp:TextBox runat="server" pattern="[^ @]*@[^ @]*" class="form-control" ID="txt_email" required="" />

                                                                            </div>
                                                                        </div>


                                                                        <div class="col-lg-4">
                                                                            <div class="form-group">
                                                                                <label>Stamp Type<span class="text-danger">*</span></label>
                                                                                <asp:DropDownList runat="server" class="form-control select" ID="ddl_stamptype">
                                                                                    <asp:ListItem Text="2" Value="0" />
                                                                                    <asp:ListItem Text="5" Value="1" />
                                                                                    <asp:ListItem Text="10" Value="2" />
                                                                                    <asp:ListItem Text="20" Value="3" />
                                                                                </asp:DropDownList>

                                                                            </div>
                                                                        </div>

                                                                        <div class="col-lg-4">
                                                                            <div class="form-group">
                                                                                <label>Number Of Stamps<span class="text-danger"> *</span></label>
                                                                                <asp:TextBox runat="server" class="form-control" ID="txt_numberofstamps" required="" OnTextChanged="txt_numberofstamps_TextChanged" AutoPostBack="true" />

                                                                            </div>
                                                                        </div>

                                                                        <div class="col-lg-4">
                                                                            <div class="form-group">
                                                                                <label>Total price<span class="text-danger">*</span></label>
                                                                                <asp:TextBox runat="server" class="form-control" ID="txt_price" required="" ReadOnly="true" />

                                                                            </div>
                                                                        </div>
                                                                    


                                                                    </div>
                                                                </div>


                                                                  <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div class="row">
                                                                            <div class="col-lg-4">
                                                                                <div class="form-group">
                                                                                    <div class="wrap-input100 validate-input" data-validate="Captcha is required">
                                                                                        <span class="label-input100"><span id="lblCaptcha" runat="server">Captcha </span><span style="color: red">*</span><span id="rightcaptch">
                                                                                            <img src="../../CaptchaHandler.ashx" id="img1" style="width: 130px;" />
                                                                                            &nbsp; &nbsp;<span id="lblRefresh" runat="server">Refresh</span><a href="#" onclick="javascript:EchallanCaptcha();">
                                                                                                <img src="../../images/Refresh.jpg" alt="images" style="width: 30px; border-radius: 2px; background: #fff !important; padding: 3px;" /></a></span></span>
                                                                                        <asp:TextBox ID="txtCaptcha" runat="server" class="form-control" placeholder="Type your Captcha"></asp:TextBox>

                                                                                        <span class="focus-input100" data-symbol="&#xf190;"></span>
                                                                                        <asp:Label ID="lblerrorMsg" runat="server" ForeColor="Red" Visible="false" Text=""></asp:Label>
                                                                                    </div>


                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="submit-section">
                                                                    <asp:Button Text="Payment" class="btn btn-primary submit-btn" runat="server" ID="btn_submit" OnClick="btn_submit_Click" />
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
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


                    <!-- /Main Wrapper -->

                    <!-- jQuery -->
                    <script src="../assets/js/jquery.min.js"></script>

                    <!-- Bootstrap Core JS -->
                    <script src="../assets/js/popper.min.js"></script>
                    <script src="../assets/js/bootstrap.min.js"></script>

                    <!-- Select2 JS -->
                    <script src="../assets/plugins/select2/js/select2.min.js"></script>

                    <!-- Datetimepicker JS -->
                    <script src="../assets/js/moment.min.js"></script>
                    <script src="../assets/js/bootstrap-datetimepicker.min.js"></script>

                    <!-- Sticky Sidebar JS -->
                    <script src="../assets/plugins/theia-sticky-sidebar/ResizeSensor.js"></script>
                    <script src="../assets/plugins/theia-sticky-sidebar/theia-sticky-sidebar.js"></script>

                    <!-- Custom JS -->
                    <script src="../assets/js/script.js"></script>

                      <script type="text/javascript">
                        function EchallanCaptcha() {
                            var img = document.getElementById("img1");
                            img.src = "../../CaptchaHandler.ashx?query=" + Math.random();
                        }
                    </script>

                    <script language="javascript">
                        function SelectRedirect() {
                            // ON selection of section this function will work
                            //alert( document.getElementById('s1').value);

                            switch (document.getElementById('s1').value) {
                                case "PHP":
                                    window.location = "index.aspx";
                                    break;


                            }// end of switch 
                        }
                        ////////////////// 
                    </script>
            </body>

        </div>
    </form>
</body>
</html>

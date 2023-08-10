<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentInvioce.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.PaymentInvioce" %>

<!DOCTYPE html>
<html lang="en">
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
    <script>
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }</script>
</head>
<body class="account-page">
    <form runat="server">

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
                        <a href="index.aspx" class="navbar-brand logo">
                            <img src="../images/Sublogo.png" class="img-fluid" alt="Logo">
                        </a>
                    </div>
                    <div class="main-menu-wrapper">
                        <div class="menu-header">
                            <a href="index.aspx" class="menu-logo">
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

            <!-- Breadcrumb -->
            <div class="breadcrumb-bar">
                <div class="container-fluid">
                    <div class="row align-items-center">
                        <div class="col-md-6 col-6">
                            <nav aria-label="breadcrumb" class="page-breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="../../index.aspx">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Checkout</li>
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
                        <div class="col-lg-12" style="text-align: center">
                            <div class="form-group">
                                <input type="button" onclick="printDiv('printableArea')" value="print" class="btn btn-primary btn-sm" />
                            </div>
                        </div>
                    </div>
                    <div class="content" id="printableArea">
                        <div class="row">
                            <div class="col-lg-8 offset-lg-2">
                                <div class="invoice-content">
                                    <div class="invoice-item">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="invoice-logo">
                                                    <img src="../../images/Sublogo.png" alt="logo">
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <p class="invoice-details">
                                                    <strong>Order:</strong>
                                                    <asp:Label ID="lbl_invoicenumber" runat="server" />
                                                    <br>
                                                    <strong>Issued:</strong>
                                                    <asp:Label ID="lbl_OrderIDDate" runat="server" />





                                                </p>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Invoice Item -->
                                    <div class="invoice-item">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="invoice-info">
                                                    <strong class="customer-text">Invoice From</strong>
                                                    <p class="invoice-details invoice-details-two">
                                                        Telangana High Court Advocates’ Association.
                                                    <br>
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="invoice-info invoice-info2">
                                                    <strong class="customer-text">Invoice To</strong>
                                                    <p class="invoice-details">
                                                        <asp:Label ID="lbl_invoiceto" runat="server" />
                                                        <br>
                                                        <asp:Label ID="lbl_Inviocername" runat="server" />
                                                        <br>
                                                        <asp:Label ID="lbl_invoiceremail" runat="server" />
                                                        <br>
                                                        <asp:Label ID="lbl_invoicermobile" runat="server" />
                                                        <br>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /Invoice Item -->

                                    <!-- Invoice Item -->
                                    <div class="invoice-item">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="invoice-info">
                                                    <strong class="customer-text">Payment Method</strong>
                                                    <p class="invoice-details invoice-details-two">
                                                        Razory Pay
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /Invoice Item -->

                                    <!-- Invoice Item -->
                                    <div class="invoice-item invoice-table-wrap">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="table-responsive">
                                                    <table class="invoice-table table table-bordered">
                                                        <thead>
                                                            <tr>
                                                                <th>
                                                                    <asp:Label ID="lbl_typename" runat="server" /></th>
                                                                <asp:Panel runat="server" ID="pnl_judicialstamphead" Visible="false">

                                                                    <th>
                                                                        <asp:Label ID="lbl_Nameonstamp" runat="server" />Name On Stamp</th>
                                                                    <th>
                                                                        <asp:Label ID="lbl_residencial" runat="server" />Residencial Address</th>
                                                                </asp:Panel>
                                                                <asp:Panel runat="server" ID="pnl_eachprice" Visible="false">

                                                                    <th>
                                                                        <asp:Label ID="lbl_noofstamps" runat="server" />Each Price</th>
                                                                </asp:Panel>

                                                                <th class="text-center">Amount</th>
                                                                <th class="text-right">Total</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lbl_membershiptype" runat="server" /></td>
                                                                <asp:Panel runat="server" ID="pnl_judicialstampvalue" Visible="false">
                                                                    <td class="text-center">
                                                                        <asp:Label ID="lbl_Nameofstampvalue" runat="server" /></td>
                                                                    <td class="text-center">
                                                                        <asp:Label ID="lbl_addressvalue" runat="server" /></td>
                                                                </asp:Panel>
                                                                <asp:Panel runat="server" ID="pnl_eachpricevalue" Visible="false">
                                                                    <td class="text-center">
                                                                        <asp:Label ID="lbl_eachpricevalue" runat="server" /></td>
                                                                </asp:Panel>
                                                                <td class="text-center">
                                                                    <asp:Label ID="lbl_amount" runat="server" /></td>

                                                                <td class="text-right">
                                                                    <asp:Label ID="lbl_totalamount" runat="server" /></td>
                                                            </tr>

                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-xl-4 ml-auto">
                                                <div class="table-responsive">
                                                    <table class="invoice-table-two table">
                                                        <tbody>

                                                            <tr>
                                                                <th>Total Amount:</th>
                                                                <td><span>
                                                                    <asp:Label ID="lbl_finaltotal" runat="server" /></span></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /Invoice Item -->

                                    <div class="invoice-item">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <label id="lbl_barcode" runat="server" visible="false">Bar Code<span class="text-danger"></span></label>
                                                <asp:Image ID="ImageGeneratedBarcode" runat="server" CssClass="img-thumbnail" Visible="false" Width="300px" Height="150px" />
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Invoice Information -->
                                    <%--<div class="other-info">
									<h4>Other information</h4>
									<p class="text-muted mb-0">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus sed dictum ligula, cursus blandit risus. Maecenas eget metus non tellus dignissim aliquam ut a ex. Maecenas sed vehicula dui, ac suscipit lacus. Sed finibus leo vitae lorem interdum, eu scelerisque tellus fermentum. Curabitur sit amet lacinia lorem. Nullam finibus pellentesque libero.</p>
								</div>--%>
                                    <!-- /Invoice Information -->

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
    </form>
    <!-- jQuery -->
    <script src="assets/js/jquery.min.js"></script>

    <!-- Bootstrap Core JS -->
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!-- Custom JS -->
    <script src="assets/js/script.js"></script>

</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPayments.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.User.UserPayments" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!--[if !mso]><!-->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!--<![endif]-->
    <meta name="format-detection" content="telephone=no">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Secure Payments Page | FoodShop</title>
    <link rel="shortcut icon" style="width: 64px !important; height: auto !important;" href="Images/logo-created.png">
    <link href='https://fonts.googleapis.com/css?family=Lato:400,700,300,100,900' rel='stylesheet' type='text/css'>
    <style type="text/css">
        .ExternalClass {
            width: 100%;
            background-color: #d9d9d9;
        }

        body {
            font-size: 13px;
            line-height: 1;
            background-color: white;
            border: solid silver thin !important;
            margin: 0;
            padding: 0;
            padding-top: 20px !important;
            padding-bottom: 20px !important;
            -webkit-font-smoothing: antialiased;
            font-family: 'Lato', sans-serif;
            -webkit-text-size-adjust: 100%;
            -ms-text-size-adjust: 100%;
        }

        #bodyTable {
            height: 100% !important;
            margin: 0;
            padding: 0;
            width: 100% !important;
        }

        table {
            border-collapse: collapse;
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
            border-spacing: 0;
            -webkit-text-size-adjust: 100%;
            -ms-text-size-adjust: 100%;
        }

        td, td a {
            color: #1cbcb4;
            text-decoration: none;
        }

        td {
            font-size: 14px;
            line-height: 1;
        }

        img {
            border: none;
            outline: none;
            text-decoration: none;
            display: inline-block;
            height: auto;
        }

        p {
            margin: 0;
            padding: 0;
        }

        a:hover, td a:hover {
            color: #7a8590;
            outline: none;
        }

        .bannerImg {
            width: 100%;
            max-width: 486px;
            height: auto;
        }

        /*Media Queries*/
        @media screen and (max-width: 639px) {

            body[yahoo] .table_wrapper {
                width: 100% !important;
            }
        }

        @media screen and (min-width: 480px) {
            .logo {
                float: left;
            }

            .nav {
                float: right;
            }

            .prob-view {
                float: left;
            }

            .social-icons {
                float: right;
            }
        }

        @media screen and (max-width: 479px) {
            .problem {
                text-align: center !important;
            }

            .make {
                font-size: 34px !important;
            }

            .we-need {
                font-size: 28px !important;
            }

            .become {
                font-size: 28px !important;
            }

            .volunteer {
                line-height: 1.2;
            }

            .upcoming {
                font-size: 28px !important;
            }

            .blog {
                font-size: 28px !important;
            }

            .get {
                font-size: 28px !important;
            }

            .blank {
                display: none;
            }
        }

        @media screen and (max-width: 590px) {
            .logo {
                width: 150px !important;
            }
        }
    </style>

    <!--[if (gte mso 9)|(IE)]>
    <style type="text/css">
    table {border-collapse: collapse;}
    </style>
    <![endif]-->
</head>
<body yahoo="fix" style="background-color: white; margin: 0; padding: 0; font-family: 'Lato', sans-serif; line-height: 1; color: #fff; -webkit-text-size-adjust: 100%; border: none !important; padding-top: 40px !important;" id="bodyTable">


    <%--  <form runat="server" id="form1">--%>
    <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="640" align="center" border="0" cellpadding="0" cellspacing="0" class="table_wrapper">

                    <!-- <header Section> -->



                    <!-- <header Section> -->

                    <tr>
                        
                        <td background="../admin/Images/BackgroundImage.jpg" style="background-size: cover; background-color: #fafafa;" valign="top">
                            <!--[if gte mso 9]>
                            <v:rect xmlns:v="urn:schemas-microsoft-com:vml" fill="true" stroke="false" style="width:640px;height:467px;">
                            <v:fill type="tile" src="images/banner-img.jpg" color="#5bc2d6" />
                            <v:textbox inset="0,0,0,0">
                            <![endif]-->
                            <div>
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>

                                        <td width="0">
                                            <img src="../admin/Images/visa.png" alt="" height="1" width="1" /></td>

                                        <td>
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td height="0">
                                                        <img src="../admin/Images/visa.png" alt="" height="1" width="1" /></td>
                                                </tr>

                                                <tr>
                                                    <td style="font-size: 0; text-align: center">
                                                        <!--[if (gte mso 9)|(IE)]>
                                                        <table width="100%"  cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                        <td width="260"  valign="top">
                                                        <![endif]-->
                                                        <table class="logo" style="display: inline-block; vertical-align: top; width: 100%; max-width: 350px" cellpadding="0" cellspacing="0" border="0">

                                                            <tr>
                                                                <td height="30">
                                                                    <img src="../admin/Images/visa.png" alt="" height="1" width="1" /></td>
                                                            </tr>

                                                        </table>
                                                        <!--[if (gte mso 9)|(IE)]>
                                                        </td>
                                                        <td width="290"  valign="top">
                                                        <![endif]-->
                                                        <table class="nav" style="display: inline-block; vertical-align: top; width: 100%; max-width: 240px" cellpadding="0" cellspacing="0" border="0">
                                                            <tr>
                                                                <td height="30">
                                                                    <img src="../admin/Images/visa.png"" alt="" height="1" width="1" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td width="240">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="center"><a href="http://demo.theschoolmagazine.in/Cart.aspx" style="text-decoration: none; font-size: 14px; color: black; line-height: 17px !important; font-family: Calibri !important;">Return To Cart</a></td>
                                                                            <td width="20">
                                                                                <img src="../admin/images/blank.gif" alt="" height="1" width="1" /></td>
                                                                            <td align="center"><a href="http://demo.theschoolmagazine.in/Shop.aspx" style="text-decoration: none; font-size: 14px; color: black; line-height: 17px !important; font-family: Calibri !important;">Explore Shop</a></td>

                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>


                                                        </table>
                                                        <!--[if (gte mso 9)|(IE)]>
                                                        </td>
                                                        </tr>
                                                        </table>
                                                        <![endif]-->
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td height="30">
                                                        <img src="../admin/Images/visa.png" alt="" height="1" width="1" /></td>
                                                </tr>

                                                <tr>
                                                    <td class="we-need" style="font-size: 17px; color: black; text-align: center; line-height: 35px !important; letter-spacing: 1px !important; font-weight: bold !important; text-transform: uppercase !important;">
                                                        <img style="height: 100px !important; width: auto !important; margin: auto !important;" src="Images/visa.png" />
                                                        <br />
                                                        <span style="font-weight: bolder !important;">Secure Payments Area</span>

                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="text-align: center; font-size: 15px; color: black; line-height: 27px; padding-top: 20px !important;">You order request has been successfully created.<br />
                                                        Please pay now to complete your order.
                                                        <br />
                                                        <b>Order ID</b>:
                                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                                        | <b>Payable Amount</b>:
                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                        <asp:Label ID="Label3" runat="server"></asp:Label>

                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td height="20">
                                                        <img src="../admin/Images/visa.png"" alt="" height="1" width="1" /></td>
                                                </tr>

                                                <tr>
                                                    <td align="center">
                                                        <table width="240" height="42" cellpadding="0" cellspacing="0" border="0" style="border-radius: 5px;">
                                                            <tr>
                                                                <td height="42" align="center">
                                                                    <form action="../User/UserPaymentConformation.aspx?oid=<%=baseid%>" method="post">
                                                                        

                                                                        <style>
                                                                            input[type="submit" i] {
                                                                                appearance: push-button;
                                                                                user-select: none;
                                                                                white-space: pre;
                                                                                align-items: flex-start;
                                                                                text-align: center;
                                                                                cursor: default;
                                                                                color: white !important;
                                                                                background-color: #1a75ff !important;
                                                                                box-sizing: border-box;
                                                                                padding: 10px 20px !important;
                                                                                border: none !important;
                                                                                font-size: 15px !important;                                                                                border-radius: 3px !important;
                                                                                font-weight: bold !important;
                                                                                cursor: pointer !important;
                                                                            }
                                                                        </style>
                                                                        <script
                                                                            src="https://checkout.razorpay.com/v1/checkout.js"
                                                                            data-key="rzp_test_Xte9DNl56BDjDl"
                                                                            data-amount="<%=finalpay%>"
                                                                            data-currency="<%=currency%>"
                                                                            data-name="Quick Checkout"
                                                                            data-description="Order Id: <%=orderid%>"
                                                                            data-image="../admin/Images/logo_1.png"
                                                                            data-prefill.name="<%=canname%>"
                                                                            data-prefill.email="<%=canemail%>"
                                                                            data-prefill.contact="<%=cantel%>"
                                                                            data-theme.color="#FF8000"></script>
                                                                        <input type="hidden" value="Hidden Element" name="hidden" />
                                                                    </form>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="40">
                                                        <img src="../admin/Images/visa.png"" alt="" height="1" width="1" /></td>
                                                </tr>


                                            </table>
                                        </td>
                                        <td width="20">
                                            <img src="../admin/Images/visa.png" alt="" height="1" width="1" /></td>

                                    </tr>

                                </table>
                            </div>
                            <!--[if gte mso 9]>
                            </v:textbox>
                            </v:rect>
                            <![endif]-->
                        </td>

                    </tr>


                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td height="20 ">
                                        
                                        <img src="../admin/Images/logo_1.png" alt="" height="1" width="1"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>

                                                            <td style="font-size: 13px; color: gray; text-align: center; line-height: 1.5">
                                                                This is a system generated page based on the order request generated on this website.<br />
                                                                Please do not reload of refresh the page during payment processing.
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>


                                        </table>
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>


                </table>


            </td>
        </tr>
    </table>
    <%--  </form>--%>
</body>
</html>


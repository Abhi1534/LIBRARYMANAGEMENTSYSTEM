<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <!--====== Required meta tags ======-->
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <meta name="description" content="Telangana High Court Advocates’ Association">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!--====== Title ======-->
    <title>THCAA Home Page</title>

    <!--====== Favicon Icon ======-->
    <link rel="shortcut icon" href="images/MainLogo.png" type="image/jpeg">

    <!--====== Slick css ======-->
    <link rel="stylesheet" href="css/slick.css">

    <!--====== Animate css ======-->
    <link rel="stylesheet" href="css/animate.css">

    <!--====== Nice Select css ======-->
    <link rel="stylesheet" href="css/nice-select.css">

    <!--====== Nice Number css ======-->
    <link rel="stylesheet" href="css/jquery.nice-number.min.css">

    <!--====== Magnific Popup css ======-->
    <link rel="stylesheet" href="css/magnific-popup.css">

    <!--====== Bootstrap css ======-->
    <link rel="stylesheet" href="css/bootstrap.min.css">

    <!--====== Fontawesome css ======-->
    <link rel="stylesheet" href="css/font-awesome.min.css">
    <link rel="stylesheet" href="admin/assets/plugins/fontawesome/css/fontawesome.min.css">

    <!--====== Default css ======-->
    <link rel="stylesheet" href="css/default.css">

    <!--====== Style css ======-->
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/style1.css">

    <!--====== Responsive css ======-->
    <link rel="stylesheet" href="css/responsive.css">

    <link rel="stylesheet" href="css/stylepopup.css">

    <style>
        marquee {
            font-family: 'Montserrat' !important;
            margin-top: 22px;
            min-height: 340px;
        }
    </style>
    <style>
        @import url('https://fonts.googleapis.com/css?family=Roboto:100,300,400');

        .one {
            font-family: 'Montserrat';
            font-size: 18px;
            font-weight: 600;
            text-shadow: 1px 0px 3px #b7161614;
            overflow: hidden;
            animation: bg 5s linear infinite;
        }

        .dropping-texts {
            display: inline-block;
            width: 135px;
            text-align: left;
            height: 21px;
            vertical-align: -2px;
        }

            .dropping-texts > div {
                font-size: 0px;
                opacity: 0;
                margin-left: -30px;
                position: absolute;
                font-weight: 300;
                box-shadow: 0px 60px 25px -20px rgba(0,0,0,0.5);
            }

                .dropping-texts > div:nth-child(1) {
                    animation: roll 5s linear infinite 0s;
                }

                .dropping-texts > div:nth-child(2) {
                    animation: roll 5s linear infinite 1s;
                }

                .dropping-texts > div:nth-child(3) {
                    animation: roll 5s linear infinite 2s;
                }

                .dropping-texts > div:nth-child(4) {
                    animation: roll2 5s linear infinite 3s;
                }

        @keyframes roll {
            0% {
                font-size: 0px;
                opacity: 0;
                margin-left: -30px;
                margin-top: 0px;
                transform: rotate(-25deg);
            }

            3% {
                opacity: 1;
                transform: rotate(0deg);
            }

            5% {
                font-size: inherit;
                opacity: 1;
                margin-left: 0px;
                margin-top: 0px;
            }

            20% {
                font-size: inherit;
                opacity: 1;
                margin-left: 0px;
                margin-top: 0px;
                transform: rotate(0deg);
            }

            27% {
                font-size: 0px;
                opacity: 0.5;
                margin-left: 20px;
                margin-top: 100px;
            }

            100% {
                font-size: 0px;
                opacity: 0;
                margin-left: -30px;
                margin-top: 0px;
                transform: rotate(15deg);
            }
        }

        @keyframes roll2 {
            0% {
                font-size: 0px;
                opacity: 0;
                margin-left: -30px;
                margin-top: 0px;
                transform: rotate(-25deg);
            }

            3% {
                opacity: 1;
                transform: rotate(180deg);
            }

            5% {
                opacity: 1;
                margin-left: 0px;
                margin-top: 0px;
                transform: rotate(0deg);
            }

            30% {
                font-size: inherit;
                opacity: 1;
                margin-left: 0px;
                margin-top: 0px;
                transform: rotate(0deg);
            }

            37% {
                font: size 0px;
                opacity: 0;
                margin-left: -1000px;
                margin-top: -800px;
            }

            100% {
                font-size: 0px;
                opacity: 0;
                margin-left: -30px;
                margin-top: 0px;
                transform: rotate(15deg);
            }
        }

        @keyframes bg {
            0% {
                color: #ffc600;
            }

            3% {
                color: #ffc600;
            }

            20% {
                color: #ffc600;
            }

            23% {
                color: #000;
            }

            40% {
                color: #000;
            }

            43% {
                color: #000;
            }

            60% {
                color: #000;
            }

            63% {
                color: #fff;
            }

            80% {
                color: #fff;
            }

            83% {
                color: #fff;
            }

            100% {
                color: #fff;
            }
        }

        .main-menu-wrapper a {
            text-transform: uppercase;
        }

        .btn-group {
            margin-top: 6px;
        }

        .tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #f1f1f1;
        }

            /* Style the buttons inside the tab */
            .tab button {
                background-color: inherit;
                float: left;
                border: none;
                outline: none;
                cursor: pointer;
                padding: 14px 16px;
                transition: 0.3s;
                font-size: 17px;
            }

                /* Change background color of buttons on hover */
                .tab button:hover {
                    background-color: #ddd;
                }

                /* Create an active/current tablink class */
                .tab button.active {
                    background-color: #1f3e5e;
                    font-weight: 600;
                    color: #fff;
                }

        /* Style the tab content */
        .tabcontent {
            display: none;
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
        }

        .card-body {
            text-align: center;
        }

        .cards {
            display: flex !important;
        }

        .card {
            margin: 15px 20px;
        }


        /* Slideshow container */
        .slideshow-container {
            max-width: 1000px;
            position: relative;
            margin: auto;
        }

        /* Caption text */
        .text {
            color: #f2f2f2;
            font-size: 15px;
            padding: 8px 12px;
            position: absolute;
            bottom: 8px;
            width: 100%;
            text-align: center;
        }

        /* Number text (1/3 etc) */
        .numbertext {
            color: #f2f2f2;
            font-size: 12px;
            padding: 8px 12px;
            position: absolute;
            top: 0;
        }

        /* The dots/bullets/indicators */
        .dot {
            height: 15px;
            width: 15px;
            margin: 0 2px;
            background-color: #bbb;
            border-radius: 50%;
            display: inline-block;
            transition: background-color 0.6s ease;
        }



        /* Fading animation */
        .fade {
            animation-name: fade;
            animation-duration: 1.5s;
        }

        @keyframes fade {
            from {
                opacity: .4;
            }

            to {
                opacity: 1;
            }
        }

        /* On smaller screens, decrease text size */
        @media only screen and (max-width: 300px) {
            .text {
                font-size: 11px;
            }
        }

        div#dots {
            display: none;
        }

        img.card-img-top {
            height: 60%;
        }
    </style>
</head>

<body>

    <!--====== PRELOADER PART START ======-->

    <div class="preloader">
     
        <img src="images/preloader.gif" />
    </div>


    <!--====== PRELOADER PART START ======-->

    <!--====== HEADER PART START ======-->

    <header id="header-part">

        <div class="header-top d-none d-lg-block">
            <div class="container">
                <div class="row">
                    <div class="col-lg-8">
                        <div class="header-contact text-lg-left text-center">
                            <ul>
                                <li>
                                    <img src="images/affiliate.png" alt="icon" style="width: 6%;">
                                    <span style="color: #fff;">+91 81259 13755</span>
                                </li>

                                <li>
                                    <img src="images/all-icon/email.png" alt="icon"><span style="padding-top: 2px;">  telanganahcaa@gmail.com</span></li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="header-opening-time text-lg-right text-center">
                            <p>
                                <div class="one">

                                    <div class="dropping-texts">

                                        <div>"WELCOME TO</div>
                                        <div>"WELCOME TO</div>
                                        <div>"WELCOME TO</div>
                                        <div>"WELCOME TO</div>
                                    </div>
                                    THCAA"
                                </div>
                            </p>

                            <ul>
                                <li></li>
                            </ul>

                        </div>
                    </div>
                </div>
                <!-- row -->
            </div>
            <!-- container -->
        </div>
        <!-- header top -->

        <div class="header-logo-support pt-30 pb-30" style="background-color: #edf0f2">
            <div class="container" style="align-content: center">
                <div class="row">

                    <div class="col-md-2 col-xs-12 col-s-12 col-lg-2 col-2">
                        <a href="index.aspx">
                            <img src="images/Thcaamain.png" alt="Logo">
                        </a>
                    </div>
                    <div class="col-md-9 col-xs-12 col-s-12 col-lg-9 col-9" style="padding-left: 0px; align-content: center; padding-top: 15px">
                        <img src="images/ThcaaName.png" id="nameogo"/>
                    </div>


                </div>

            </div>

        </div>


        <div class="navigation">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-9 col-8">
                        <nav class="navbar navbar-expand-lg">
                            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>

                            <div class="collapse navbar-collapse sub-menu-bar" id="navbarSupportedContent">
                                <ul class="navbar-nav mr-auto">
                                    <li class="nav-item">
                                        <a class="active" href="index.aspx">Home</a> </li>
                                    
                                    <li class="nav-item">
                                        <a href="#">ABOUT US <i class="fas fa-chevron-down"></i></a>
                                        <ul class="sub-menu">
                                              <li><a href="meetourteam.aspx" style="color: black">Executive Committee</a></li>
                                            <li><a href="History.aspx" style="color: black">history</a></li>
                                            <li><a href="images/pdf/bye-laws.pdf" target="_blank" style="color: black">by laws</a></li>
                                            <li><a href="AIMSandObjectives.aspx" style="color: black">Aims & objectives</a></li>
                                            <li><a href="PresidentDesk.aspx" style="color: black">President's Desk</a></li>
                                            <li><a href="SecretaryDesk.aspx" style="color: black">Secretary desk</a></li>
                                            <li><a href="#" style="color: black">Audit Report</a></li>
                                            <li><a href="images/pdf/facilities.pdf" target="_blank" style="color: black">facilities</a></li>
                                        </ul>
                                    </li>

                                    <li class="nav-item">
                                        <a href="meetourteam.aspx">Meet Our Team</a> </li>

                                    <li class="nav-item">
                                        <a href="events.html">Directory <i class="fas fa-chevron-down"></i></a>
                                        <ul class="sub-menu">
                                            <li><a href="MembershipDetails.aspx" style="color: black">Members directory</a></li>
                                            <li><a href="MembershipTypeWiseList.aspx" style="color: black">Membership Type directory</a></li>
                                        </ul>
                                    </li>
                                    <li class="nav-item">
                                        <a href="#">INFORMATION <i class="fas fa-chevron-down"></i></a>
                                        <ul class="sub-menu" id="baronr">
                                           <li><a href="images/pdf/Dept.%20allocation%20to%20GPs-1.pdf" target="_blank" style="color: black">advocate general & other legal officers</a></li>
                                            <li><a href="images/pdf/public-prosecutor-office.pdf" target="_blank" style="color: black">public procecutor & apps</a></li>
                                            <li><a href="images/pdf/New%20CG%20List%202022.pdf" target="_blank" style="color: black">Deputy solicitor general & central government standing counsels</a></li>
                                            <li><a href="images/pdf/List%20of%20Standing%20Counsel%20TS.pdf" target="_blank" style="color: black">other standing counsels</a></li>
                                            <li><a href="images/pdf/New%20CG%20List%202022.pdf" target="_blank" style="color: black">Central government standing counsels</a></li>
                                            <li><a href="images/pdf/SR.%20ADVOCATES%20latest%2028.12.2022%20%20website.xlsx" target="_blank" style="color: black">Designated Senior Advocates, High Court for the State of Telangana</a></li>
                                        </ul>
                                    </li>

                                     

                                     <li class="nav-item">
                                        <a href="Gallery.aspx">GALLERY</a> </li>

                                    <%--<li class="nav-item">
                                        <a href="teachers.html">other utilities <i class="fas fa-chevron-down"></i></a>
                                        <ul class="sub-menu">
                                            <li><a href="#" target="_blank">new member</a></li>
                                        <li><a href="images/PDF/clerks-list.pdf" target="_blank">details of advocates clerks</a></li>
                                        <li><a href="images/PDF/press-list.pdf" target="_blank">details of press reporters</a></li>
                                        </ul>
                                    </li>--%>


                                    <li class="nav-item">
                                        <a href="#">CONATCUS</a>
                                        <ul class="sub-menu">
                                            <li><a href="#" target="_blank">Queries/Feedback</a></li>
                                       <%-- <li><a href="#" target="_blank">Important Contacts</a></li>--%>
                                        </ul>
                                    </li>


                                    <li class="nav-item">
                                        <a href="events.html">Other Links <i class="fas fa-chevron-down"></i></a>
                                        <ul class="sub-menu" id="bartwo">
                                            <li><a href="https://tshc.gov.in/" target="_blank">High Court For the State Telangana </a></li>
                                            <li><a href="https://tshc.gov.in/" target="_blank">Supreme Court of India</a></li>
                                            <li><a href="https://tshc.gov.in/getLSNotifications" target="_blank">High Court Legal Services Committee</a></li>

                                            <li><a href="http://tslsa.telangana.gov.in/" target="_blank">Telangana State Legal Services Authority</a></li>

                                            <li><a href="http://www.sclsc.nic.in/" target="_blank">Supreme Court Legal Services Committee</a></li>

                                            <li><a href="http://www.telanganabarcouncil.org/" target="_blank">Bar Council of Telangana</a></li>
                                            <li><a href="http://ncdrc.nic.in/" target="_blank">National Consumer Disputes Redressal Commission</a></li>
                                            <li><a href="https://www.aftdelhi.nic.in/" target="_blank">Armed Forces Tribunal</a></li>

                                            <%--<li><a href="" target="_blank">Important Contacts</a></li>--%>
                                        </ul>
                                    </li>

                                    <li>

                                    <a href="https://www.youtube.com/@telanganahighcourtadvocate2589" target="_blank">You Tube </a>

                                </li>

                                    <li>
                                    <div class="btn-group">
                                        <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">LOGIN</button>
                                        <div class="dropdown-menu" style="">
                                            <a class="dropdown-item" href="admin/Login.aspx">User Login</a>
                                                <a class="dropdown-item" href="admin/admin/Login.aspx">Admin Login</a>

                                        </div>
                                    </div>
                                </li>

                                    <%--<li class="nav-item">
                                        <a href="shop.html">Shop</a>
                                        <ul class="sub-menu">
                                            <li><a href="shop.html">Shop</a></li>
                                            <li><a href="shop-singel.html">Shop Singel</a></li>
                                        </ul>
                                    </li>
                                    <li class="nav-item">
                                        <a href="contact.html">Contact</a>
                                        <ul class="sub-menu">
                                            <li><a href="contact.html">Contact Us</a></li>
                                            <li><a href="contact-2.html">Contact Us 2</a></li>
                                        </ul>
                                    </li>--%>
                                </ul>
                            </div>
                        </nav> <!-- nav -->
                    </div>
                    
                </div> <!-- row -->
            </div> <!-- container -->
        </div>

    </header>

    <div class="search-box" style="background-color: #edf0f2">
        <div class="serach-form">
            <div class="closebtn">
                <span></span>
                <span></span>
            </div>
            <form action="#">
                <input type="text" placeholder="Search by keyword">
                <button><i class="fa fa-search"></i></button>
            </form>
        </div>
        <!-- serach form -->
    </div>

    <section id="banner" class="banner1" style="background-color: #edf0f2">


        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                    <img src="images/5242643005717953558.png" />

                    <div style="text-align: center" id="dots"><span class="dot"></span><span class="dot"></span><span class="dot"></span></div>
                </div>
                <div class="col-md-8">
                    <div class="slideshow-container" style="margin-top: -25px;">
                        <div class="mySlides slide">
                            <img src="images/bc.jpg" style="width: 100%" />
                        </div>
                        <div class="mySlides slide">
                            <img src="images/bc1.jpg" style="width: 100%" />
                        </div>

                    </div>
                </div>
                <div class="col-md-2">
                    <img src="images/5242643005717953558_1.png" />
                </div>
            </div>
        </div>
    </section>

    <section id="category-3" class="category-2-items gray-bg" style="background-color: #edf0f2">
        <div class="container">
            <div class="row">
               
                <div class="col-lg-3 col-md-6">
                    <div class="singel-items text-center mt-30">
                        <div class="items-image">
                            <img src="images/category/ctg-2.jpg" alt="Category">
                        </div>
                        <div class="items-cont">
                            <a href="https://tshc.gov.in/vpass/NewFile.jsp" target="_blank">
                                <h5>High Court<br />
                                    Visitor Pass</h5>

                            </a>
                        </div>
                    </div>
                    <!-- singel items -->
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="singel-items text-center mt-30">
                        <div class="items-image">
                            <img src="images/category/ctg-4.jpg" alt="Category">
                        </div>
                        <div class="items-cont">
                            <a href="admin/User/WelfareStamps.aspx" target="_blank">
                                <h5>Welfare Stamps</h5>

                            </a>
                        </div>
                    </div>
                    <!-- singel items -->
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="singel-items text-center mt-30">
                        <div class="items-image">
                            <img src="images/category/ctg-1.jpg" alt="Category">
                        </div>
                        <div class="items-cont">
                            <a href="admin/User/CourtStamps.aspx" target="_blank">
                                <h5>Court Stamps</h5>

                            </a>
                        </div>
                    </div>
                    <!-- singel items -->
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="singel-items text-center mt-30">
                        <div class="items-image">
                            <img src="images/category/ctg-1.jpg" alt="Category">
                        </div>
                        <div class="items-cont">
                            <a href="admin/User/JudicialStamps.aspx" target="_blank">
                                <h5>Non Judicial Stamps</h5>

                            </a>
                        </div>
                    </div>
                    <!-- singel items -->
                </div>

                <div class="col-lg-3 col-md-6">
                    <div class="singel-items text-center mt-30">
                        <div class="items-image">
                            <img src="images/category/ctg-1.jpg" alt="Category">
                        </div>
                        <div class="items-cont">
                            <a href="admin/User/DonationOther.aspx" target="_blank">
                                <h5>Donations</h5>

                            </a>
                        </div>
                    </div>
                    <!-- singel items -->
                </div>
            </div>
            <!-- row -->
            <br />
            <h3 style="text-align: center !important; margin-left: -40px; padding-bottom: 20px; font-family: 'Montserrat'; color: #18304d; font-weight: 600; margin-top: 10px;">We are dedicated to uphold the integrity of the legal profession,<bt /><br />
                serve the members of the Bar & champion justice</h3>
        </div>
        <!-- container -->
    </section>

    <section id="about-part" class="pt-65" style="background-color: #edf0f2">
        <div class="container">
            <div class="row">
                <div class="col-lg-8">
                    <div class="section-title mt-50">

                        <%--<p style="position: absolute;z-index: 9999;top: 46px;left: 70%;font-weight: 500;font-family: 'Montserrat' !important;"><marquee>"kalyanbabu Donte the 2 Lacks"</marquee></p>--%>
                        <h5>About us</h5>
                        <h3>
                            <br />
                            The High Court Building</h3>
                    </div>
                    <!-- section title -->
                    <div class="about-cont">
                        <p>
                            After the historic struggle for separate statehood for Telangana, the State of Telangana was carved out of the erstwhile State of Andhra Pradesh and by virtue of the A.P. Reorganization Act, 2014 (Act 6 of 2014) the statehood for the Telangana State came into effect from 02.06.2014.
                        Soon after the formation of Telangana, the Andhra Pradesh High Court Advocates Association was also divided and thus the Telangana High Court Advocates’ Association came into existence. However, pursuant to the General Body Meeting conducted on 14-11-2014 option was given to the members of the A.P. High Court Advocates’ Association who were willing to join the newly formed Telangana High Court Advocates Association to exercise their option so as to save the standing at the Bar. Accordingly, about 5,000 members opted to become the members of THCAA.
                       The first elections to the Executive of the Telangana High Court Advocates’ Association were held on 30-03-2016 as per the new Bye-laws.
                        The newly elected body has been working for the welfare of the High Court Advocates.
                        </p>
                        <!-- <a href="#" class="main-btn mt-55">Learn More</a> -->
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">

                    <div class="donation-amount">
                        <h4>Announcement</h4>
                        <form>
                            <marquee width="100%" direction="down" height="300px;">
                                       <div class="ttm-ptablebox-features">
                                           <ul class="ttm-feature-lines">
                                               <asp:Repeater runat="server" ID="rpt_donationdetails">
    <ItemTemplate>  
        <li>
            <i class="fa fa-bullhorn" aria-hidden="true"></i> 
            <asp:Label runat="server" ID="lbl_donationpersondetails" Text='<%# Eval("donation")%>'></asp:Label>

        </li>

    </ItemTemplate>
</asp:Repeater>
                                             
                                           
                                               

                                               <!-- <li>Daily Meetings</li>
                                               <li>eveing staf</li>
                                               <li>Advanced Options</li>
                                               <li>Daily Meetings</li>
                                               <li>eveing staf</li> -->
                                           </ul>
                                       </div>
                                   </marquee>
                        </form>
                    </div>

                </div>
                <!-- about cont -->
                <%-- <div class="col-lg-6 offset-lg-1">
                    <div class="about-event mt-50">
                        <div class="event-title">
                            <h3>Our Features</h3>
                        </div> <!-- event title -->
                        <ul>
                            <li>
                                <div class="singel-event">
                                    
                                    <a href="events-singel.html"><h4><i class="iconbox-icon fa fa-video-camera"></i> Download Entry Pass</h4></a>
                                    
                                </div>
                            </li>
                            <li>
                                <div class="singel-event">
                                    
                                    <a href="events-singel.html"><h4><i class="iconbox-icon fa fa-flask"></i> high court causelist</h4></a>
                                   
                                </div>
                            </li>
                            <li>
                                <div class="singel-event">
                                   
                                    <a href="events-singel.html"><h4><i class="iconbox-icon fa fa-desktop"></i> high court case status</h4></a>
                                    
                                </div>
                            </li>
                            
                            <li>
                                <div class="singel-event">
                                    
                                    <a href="events-singel.html"><h4><i class="iconbox-icon fa fa-tint"></i> bar counsel of ap</h4></a>
                                   
                                </div>
                            </li>
                            <li>
                                <div class="singel-event">
                                   
                                    <a href="events-singel.html"><h4><i class="iconbox-icon fa fa-book"></i> supreme court</h4></a>
                                    
                                </div>
                            </li>
                        </ul> 
                    </div> <!-- about event -->
                </div>--%>
            </div>
            <!-- row -->
        </div>
        <!-- container -->
        <%--<div class="about-bg">
            <img src="images/hvcopy.png" alt="About">
        </div>--%>
    </section>

    <section id="course-part bg1" class="bg_cover1 pt-60 pb-60">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <div class="section-title pb-45">

                        <h3>Our Facilities</h3>
                    </div>
                    <!-- section title -->
                </div>
            </div>
            <!-- row -->
            <div class="row course-slied mt-30">
                <div class="col-lg-4">
                    <div class="singel-feature">
                        <div class="icon">
                            <img src="images/all-icon/f-1.png" alt="icon">
                        </div>
                        <div class="cont">
                            <h4>Aims & Objectives</h4>
                            <p>
                                After the historic struggle for separate statehood 
                                                for Telangana, the State of Telangana was carved.
                            </p>
                        </div>
                    </div>
                </div>



                <div class="col-lg-4">
                    <div class="singel-feature">
                        <div class="icon">
                            <img src="images/all-icon/f-2.png" alt="icon">
                        </div>
                        <div class="cont">
                            <a href="admin/User/SelfMemberRegistraion.aspx">
                                <h4>Become a Member</h4>
                            </a>

                            <p>
                                After the historic struggle for separate statehood
                                                
                                                for Telangana, the State of Telangana was carved.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="singel-feature">
                        <div class="icon">
                            <img src="images/all-icon/f-3.png" alt="icon">
                        </div>
                        <div class="cont">
                            <h4>Our Executive Commitee</h4>
                            <p>
                                After the historic struggle for separate statehood
                                                for Telangana, the State of Telangana was carved.
                            </p>
                        </div>
                    </div>
                </div>

            </div>
            <!-- course slied -->
        </div>
        <!-- container -->
    </section>

    <section id="course-part" class="pt-60 pb-60 gray-bg" style="background-color: #edf0f2">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <div class="section-title pb-45">
                        <h5>Our Events</h5>
                        <h2>Our Latest News</h2>
                    </div>
                    <!-- section title -->
                </div>
            </div>
            <!-- row -->
            <div class="row course-slied mt-30">

                <asp:Repeater runat="server" ID="rep_latestnews">
                    <ItemTemplate>
                        <div class="col-lg-4">
                            <div class="singel-course">
                                <div class="thum">
                                    <div class="image">
                                        <img src='@/<%# Eval("ImagePath")%>' alt="Course">
                                    </div>

                                </div>
                                <div class="cont">

                                    <!-- <a href="courses-singel.html"><h4>South India Invitational karate Championship</h4></a> -->
                                    <div class="course-teacher">

                                        <div class="name">
                                            <a href="Gallerylatest.aspx?ID=<%# Eval("NewsID")%>">
                                                <h6>
                                                    <asp:Label Text='<%# Eval("NewsContent")%>' runat="server" /><br />
                                                    <br />
                                                </h6>
                                            </a>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <!-- singel course -->
                        </div>
                    </ItemTemplate>
                </asp:Repeater>



            </div>
            <!-- course slied -->
        </div>
        <!-- container -->
    </section>

    <section id="news-part" class="pt-20 pb-110" style="background-color: #edf0f2">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <div class="section-title pb-50">
                        <h5>Latest News</h5>
                        <h2>From the news</h2>
                    </div>
                    <!-- section title -->
                </div>
            </div>
            <!-- row -->
            <div class="row">
                <div class="col-lg-6">
                    <div class="singel-news mt-30">
                        <div class="news-thum pb-25">
                            <img src="images/138.jpg" alt="News">
                        </div>

                    </div>
                    <!-- singel news -->
                </div>
                <div class="col-lg-6">
                    <div class="singel-news news-list">
                        <div class="row">

                            <div class="col-sm-12">
                                <div class="news-cont mt-30">

                                    <a href="blog-singel.html">
                                        <h3>Latest Updates & Notifications</h3>
                                    </a>
                                    <p><i class="fa fa-bullhorn" aria-hidden="true"></i>Information with regard to list of candidates whose candidature is rejected and accepted to the posts of Driver Notification No.10/2023 dated 23/01/2023 in the service of the High Court for the State of Telangana - Regarding.</p>
                                </div>
                            </div>
                        </div>
                        <!-- row -->
                    </div>
                    <!-- singel news -->
                    <div class="singel-news news-list">
                        <div class="row">

                            <div class="col-sm-12">
                                <div class="news-cont mt-30">


                                    <p><i class="fa fa-bullhorn" aria-hidden="true"></i>ADDING VACANCIES TO THE NOTIFICATION ISSUED VIDE NOTIFICATION NO. 9/2023 DATED 12-05-2023 FOR THE POSTS OF COPYIST IN THE DISTRICT JUDICIARY OF JAGTYAL UNDER TJMS RULES - Regarding</p>
                                </div>
                            </div>
                        </div>
                        <!-- row -->
                    </div>
                    <!-- singel news -->
                    <div class="singel-news news-list">
                        <div class="row">

                            <div class="col-sm-12">
                                <div class="news-cont mt-30">


                                    <p><i class="fa fa-bullhorn" aria-hidden="true"></i>http://tshcstatus.nic.in is now changed as https://csis.tshc.gov.in</p>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="singel-news news-list">
                        <div class="row">

                            <div class="col-sm-12">
                                <div class="news-cont mt-30">


                                    <p><i class="fa fa-bullhorn" aria-hidden="true"></i>Assignment of Administrative Districts Warangal, Hanumakonda and Jangaon to Honourable Sri Justice K.Lakshman with effect from 15-05-2023 - J.Spl.(Admn.) Section, dt. 16-05-2023</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- row -->
        </div>
        <!-- container -->
    </section>

    <section id="news-part" class="disc" style="background-color: #edf0f2">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                </div>
            </div>
        </div>
    </section>

    <footer id="footer-part" style="background-color: #edf0f2">
        <div class="footer-top pt-10 pb-10">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-6 col-md-6">
                        <div class="footer-about mt-40">
                            <div class="logo">
                                <a href="#">
                                    <img src="images/MainLogo.png" alt="Logo" style="width: 30%;"></a>
                            </div>

                            <ul class="mt-20">
                                <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
                                <li><a href="#"><i class="fa fa-instagram"></i></a></li>
                            </ul>
                            <div class="copyright text-md-left text-center pt-15">
                                <p><a target="_blank" href="#" style="color: #ffc600;">© 2023 <b>Telangana High Court Advocates’ Association</b>, All rights reserved.</a> </p>
                            </div>
                            <div class="copyright text-left pt-15">
                                <p>Powered by <b>GVR Infosystems Pvt Ltd</b></p>
                            </div>
                        </div>
                        <!-- footer about -->
                    </div>
                    <div class="col-md-3">
                        <div class="footer-title pb-25">
                            <h6>&nbsp;</h6>
                        </div>
                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7615.767535858838!2d78.46767753758847!3d17.369325123705277!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bcb978627c45fad%3A0x3833fd8eef09cc05!2sHigh%20Court%20for%20the%20State%20of%20Telangana!5e0!3m2!1sen!2sin!4v1681752836485!5m2!1sen!2sin" width="100%" height="260" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                    </div>

                    <div class="col-lg-3 col-md-3">
                        <div class="footer-address mt-40">
                            <div class="footer-title pb-25">
                                <h6>Contact Us</h6>
                            </div>
                            <ul>
                                <li>
                                    <div class="icon">
                                        <i class="fa fa-home"></i>
                                    </div>
                                    <div class="cont">
                                        <p>Telangana High Court Advocates’ Association, Survey No. 8 & 9, Hyderabad, Telangana -98, India.</p>

                                    </div>
                                </li>
                                <li>
                                    <div class="icon">
                                        <i class="fa fa-phone"></i>
                                    </div>
                                    <div class="cont">
                                        <p>+91 81259 13755</p>
                                    </div>
                                </li>
                                <li>
                                    <div class="icon">
                                        <i class="fa fa-envelope-o"></i>
                                    </div>
                                    <div class="cont">
                                        <p>telanganahcaa@gmail.com</p>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <!-- footer address -->
                    </div>
                </div>
                <!-- row -->
            </div>
            <!-- container -->
        </div>
        <!-- footer top -->

        <div class="footer-copyright pt-10 pb-25">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <p><b>Disclaimer</b>: While every effort has been made to keep the information on this site accurate. The material contained on this site and on the associated web pages is general information and is not intended to be advice on any particular matter. Visitors to this site should seek appropriate and verify all information before acting on the basis of any information contained herein. The TELANGANA High Court Advocates Association expressly disclaim any and all liability to any person, in respect of anything and of the consequences of anything done or omitted to be done by any such person in reliance upon the contents of this site and associated web pages.</p>

                    </div>
                </div>
                <!-- row -->
            </div>
            <!-- container -->
        </div>
        <!-- footer copyright -->
    </footer>


    <a href="" class="back-to-top">
        <img src="images/MainLogo.png" alt="" /></a>

    <script src="js/vendor/modernizr-3.6.0.min.js"></script>
    <script src="js/vendor/jquery-1.12.4.min.js"></script>

    <!--====== Bootstrap js ======-->
    <script src="js/bootstrap.min.js"></script>

    <!--====== Slick js ======-->
    <script src="js/slick.min.js"></script>

    <!--====== Magnific Popup js ======-->
    <script src="js/jquery.magnific-popup.min.js"></script>

    <!--====== Counter Up js ======-->
    <script src="js/waypoints.min.js"></script>
    <script src="js/jquery.counterup.min.js"></script>

    <!--====== Nice Select js ======-->
    <script src="js/jquery.nice-select.min.js"></script>

    <!--====== Nice Number js ======-->
    <script src="js/jquery.nice-number.min.js"></script>

    <!--====== Count Down js ======-->
    <script src="js/jquery.countdown.min.js"></script>

    <!--====== Validator js ======-->
    <script src="js/validator.min.js"></script>

    <!--====== Ajax Contact js ======-->
    <script src="js/ajax-contact.js"></script>

    <!--====== Main js ======-->
    <script src="js/main.js"></script>
    <%--  <script src="js/scriptpopup.js"></script>--%>

    <!--====== Map js ======-->
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDC3Ip9iVC0nIxC6V14CKLQ1HZNF_65qEQ"></script>
    <script src="js/map-script.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#misresenas").slick({
                arrows: false,
                autoplay: true
            });
        });
    </script>

    <script>
        function openCity(evt, cityName) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(cityName).style.display = "block";
            evt.currentTarget.className += "active";
        }

        // Get the element with id="defaultOpen" and click on it
        document.getElementById("defaultOpen").click();
    </script>



    <script>
        let slideIndex = 0;
        showSlides();

        function showSlides() {
            let i;
            let slides = document.getElementsByClassName("mySlides");
            let dots = document.getElementsByClassName("dot");
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slideIndex++;
            if (slideIndex > slides.length) { slideIndex = 1 }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            slides[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += "active";
            setTimeout(showSlides, 2000); // Change image every 2 seconds
        }
    </script>

</body>
</html>

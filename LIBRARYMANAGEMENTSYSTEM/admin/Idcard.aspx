<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Idcard.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.Idcard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        * {
            box-sizing: border-box;
        }

        body {
            margin-top: 80px;
            font-family: "HelveticaNeue-CondensedBold", "HelveticaNeue-Light", "Helvetica Neue Light", "Helvetica Neue", Helvetica, Arial, "Lucida Grande", sans-serif;
        }

        /*
 * CSS Background Grid Lines by Jason Delia
 * https://codepen.io/jasonadelia/pen/DnrAe
 */
        .bg-grid-line,
        .card:after,
        .card header:before {
            background-color: #333;
            background-image: linear-gradient(0deg, transparent 24%, rgba(255, 255, 255, .05) 25%, rgba(255, 255, 255, .05) 26%, transparent 27%, transparent 74%, rgba(255, 255, 255, .05) 75%, rgba(255, 255, 255, .05) 76%, transparent 77%, transparent), linear-gradient(90deg, transparent 24%, rgba(255, 255, 255, .05) 25%, rgba(255, 255, 255, .05) 26%, transparent 27%, transparent 74%, rgba(255, 255, 255, .05) 75%, rgba(255, 255, 255, .05) 76%, transparent 77%, transparent);
            height: 100%;
            background-size: 50px 50px;
        }

        .card {
            position: relative;
            height: 380px;
            width: 750px;
            margin: 0 auto;
            background: url(../images/idcardbg.png);
            border-radius: 4px;
            box-shadow: inset 0 0 0 1px rgba(0, 0, 0, .4), 0 0 10px rgba(0, 0, 0, .55), 0 2px 10px rgba(0, 0, 0, .6);
            background-position: inherit;
            background-size: cover;
        }

        .backside .card {
            position: relative;
            height: 380px;
            width: 750px;
            margin: 0 auto;
            background: url(../images/idcardback.png);
            border-radius: 4px;
            box-shadow: inset 0 0 0 1px rgba(0, 0, 0, .4), 0 0 10px rgba(0, 0, 0, .55), 0 2px 10px rgba(0, 0, 0, .6);
            background-position: center;
            background-size: cover;
        }


        /* card stripe */
        .card:before {
            position: absolute;
            z-index: 2;
            content: '';
            left: 50%;
            top: -70px;
            margin: 0 0 0 -40px;
            height: 100px;
            width: 80px;
            background: rgba(255, 255, 255, .2);
            background-image: linear-gradient(left, rgba(255,255,255, .4) 0%, rgba(255,255,255, .1) 50%,rgba(255,255,255, .4) 100%), linear-gradient(bottom, rgba(255, 255, 255, 1) 0%, rgba(255, 255, 255, 0) 40%), linear-gradient(top, rgba(255, 255, 255, .8) 0%, rgba(255, 255, 255, 0) 40%);
            border-radius: 6px;
            box-shadow: 0 0 0 1px rgba(0, 0, 0, .8);
            opacity: .5;
        }


        /* card stripe clip */
        .backside .card:after {
            position: absolute;
            z-index: 2;
            height: 20px;
            width: 20px;
            top: -55px;
            left: 50%;
            margin: 0 0 0 -10px;
            border-radius: 50%;
            box-shadow: 0 0 0 5px rgba(255, 255, 255, .6), 0 0 10px rgba(0, 0, 0, .7), inset 2px 2px 2px rgba(0, 0, 0, .5);
            display: none;
        }

        .backside .card:before {
            position: absolute;
            z-index: 2;
            left: 50%;
            top: -70px;
            margin: 0 0 0 -40px;
            height: 100px;
            width: 80px;
            background: rgba(255, 255, 255, .2);
            background-image: linear-gradient(left, rgba(255,255,255, .4) 0%, rgba(255,255,255, .1) 50%,rgba(255,255,255, .4) 100%), linear-gradient(bottom, rgba(255, 255, 255, 1) 0%, rgba(255, 255, 255, 0) 40%), linear-gradient(top, rgba(255, 255, 255, .8) 0%, rgba(255, 255, 255, 0) 40%);
            border-radius: 6px;
            box-shadow: 0 0 0 1px rgba(0, 0, 0, .8);
            opacity: .5;
            display: none;
        }


        /* card stripe clip */
        .card:after {
            position: absolute;
            content: '';
            z-index: 2;
            height: 20px;
            width: 20px;
            top: -55px;
            left: 50%;
            margin: 0 0 0 -10px;
            border-radius: 50%;
            box-shadow: 0 0 0 5px rgba(255, 255, 255, .6), 0 0 10px rgba(0, 0, 0, .7), inset 2px 2px 2px rgba(0, 0, 0, .5);
        }

        .card header {
            position: relative;
            background: #ED3D34;
            height: 90px;
            width: 100%;
            border-top-left-radius: 4px;
            border-top-right-radius: 4px;
            border-bottom: 2px solid rgba(180, 80, 80, .5);
            border-top: 1px solid rgba(221, 108, 108, .8);
            box-shadow: inset 0 1px 0 0 rgba(255, 120, 120, .8), 0 1px 2px rgba(0, 0, 0, .4);
            padding: 35px 20px;
            opacity: .9;
        }

            /* top gradient */
            .card header:after {
                position: absolute;
                content: '';
                left: 1px;
                top: 1px;
                width: 100%;
                height: 10px;
                background: linear-gradient(bottom, rgba(255,255,255, .1) 0%, rgba(255,255,255,.05) 70%, rgba(255,255,255,0) 100%);
            }

            /* card hole */
            .card header:before {
                position: absolute;
                z-index: 1;
                content: '';
                left: 50%;
                top: 22px;
                margin: 0 0 0 -50px;
                height: 15px;
                width: 100px;
                border-radius: 25px;
                box-shadow: inset 1px 1px 0 1px rgba(0, 0, 0, .3), inset -1px -1px 0 0 rgba(255, 255, 255, .5);
            }

            .card header h1 {
                color: #fff;
                line-height: 90%;
                font-size: 35px;
                margin: 0;
                text-shadow: -1px -1px 1px rgba(0, 0, 0, .5);
            }

        .card article {
            padding: 30px;
        }

            .card article img {
                border: 5px solid #fff;
                box-shadow: 0 0 3px rgba(0, 0, 0, .25);
                float: left;
                margin-right: 30px;
                width: 190px;
                height: 225px;
                transition: all .3s ease-in-out;
                margin-top: 90px;
            }

            .card article h2 {
                color: #515355;
                float: left;
                margin: 0 5px 15px 0;
                font-weight: 600;
                padding: 0 0 8px 0;
                width: 450px;
            }

            .card article .area {
                position: relative;
                height: 170px;
                width: 470px;
                float: left;
            }

                .card article .area h3 {
                    color: red;
                    font-size: 20px;
                    float: right;
                    margin-top: -18px;
                }

                .card article .area ul {
                    margin: 5px 0 30px 0;
                    padding: 0;
                    list-style: none;
                }

                    .card article .area ul li {
                        margin: 20px 0 0 0;
                        font-size: 18px;
                        color: #000;
                        text-shadow: 0 0 1px rgba(0, 0, 0, .3);
                    }

                        .card article .area ul li .bar {
                            position: relative;
                            width: 280px;
                            height: 15px;
                            display: inline-block;
                            border-radius: 50px;
                            float: right;
                            margin: 0 15px 0 0;
                            opacity: .9;
                            background-color: #CACACA;
                            box-shadow: inset 0 2px 2px rgba(0, 0, 0, .35);
                        }

                            .card article .area ul li .bar:before {
                                position: absolute;
                                left: 0;
                                width: 0;
                                height: 15px;
                                background: rgb(254,213,121);
                                /*background-image:
    linear-gradient(left, rgba(254,213,121,.8) 0%,rgba(254,204,105,.8) 100%),
    repeating-linear-gradient(-45deg, transparent, 
      transparent 4px, 
      rgba(255,255,255,.5) 4px, 
      rgba(255,255,255,.5) 10px);
  background-image:
    linear-gradient(to right, rgba(254,213,121,.8) 0%,rgba(254,204,105,.8) 100%),
    repeating-linear-gradient(-45deg, transparent, 
      transparent 4px, 
      rgba(255,255,255,.5) 4px, 
      rgba(255,255,255,.5) 10px);*/
                                box-shadow: inset 0 4px 4px rgba(255, 255, 255, .3), inset 0 -2px 3px rgba(0, 0, 0, .05), 0 1px 0 0px #D29D40;
                                display: inline-block;
                                border-radius: 50px;
                                content: '';
                                z-index: -1;
                            }

                            .card article .area ul li .bar.percent-100:before {
                                width: 280px;
                            }

                            .card article .area ul li .bar.percent-90:before {
                                width: 260px;
                            }

                            .card article .area ul li .bar.percent-80:before {
                                width: 240px;
                            }

                            .card article .area ul li .bar.percent-70:before {
                                width: 220px;
                            }

                            .card article .area ul li .bar.percent-60:before {
                                width: 200px;
                            }

                            .card article .area ul li .bar.percent-50:before {
                                width: 180px;
                            }



                .card article .area::-webkit-scrollbar {
                    width: 10px;
                }

                .card article .area::-webkit-scrollbar-track {
                    background-color: rgba(217, 217, 217, .5);
                    border-radius: 50px;
                }

                .card article .area::-webkit-scrollbar-thumb {
                    background: rgba(184, 184, 184, .5);
                    box-shadow: inset 1px 1px 0 rgba(0, 0, 0, 0.10), inset 0 -1px 0 rgba(0, 0, 0, 0.07);
                    border-radius: 50px;
                }

        .card h2 {
            margin-top: 87px !important;
            font-weight: 900;
        }

        li.role {
            font-size: 22px !important;
            font-weight: 600;
            color: #041783 !important;
            border-radius: 4px !important;
            border: 1px solid #FFC107;
            width: 35%;
            padding: 10px;
            background: #fff;
            text-align: center;
        }

        li.scaner img {
            width: 35%;
            height: 68%;
            position: absolute;
            top: -30px;
            left: 280px;
        }

        .backside {
            margin-top: 50px;
        }

            .backside span.boldarea {
                font-weight: 600;
                margin-left: 13px;
                font-family: system-ui;
            }
    </style>
</head>
<body class='bg-grid-line'>
    <form id="form1" runat="server">
        <div class="frontside">

            <div class='card'>

                <article>
                    <%--<img alt='My Pic' id='thumb' src='https://s.cdpn.io/1202/timpietrusky_on_rampage_small_1.jpg'>--%>
                    <img runat="server" id="img_profile" />
                    <h2>
                        <asp:Label ID="lbl_name" runat="server" /></h2>
                    <div class='area'>
                        <h3>Regd  No. </h3>
                        <ul>
                            <li>Enrolment No : 
          <span class="boldarea">
              <asp:Label ID="lbl_Enrolementid" runat="server" /></span>
                            </li>
                            <li>Date:
          <span class="boldarea">
              <asp:Label ID="lbl_EnrolementidDate" runat="server" /></span>
                            </li>
                            <li class="role">
                                <asp:Label ID="lbl_membershipname" runat="server" /></li>
                            <li class="scaner">
                                <img src="images/scanr.png" />
                            </li>
                        </ul>
                    </div>
                </article>
             
            </div>
        </div>
        <div class="backside">
            <div class='card'>

                <article>
                    <%--<img alt='My Pic' id='thumb' src='https://s.cdpn.io/1202/timpietrusky_on_rampage_small_1.jpg'>--%>


                    <div class='area'>

                        <ul>
                            <li>D.O.B : 
          <span class="boldarea">
              <asp:Label ID="lbl_dob" runat="server" /></span>
                            </li>
                            <li>Blood  &nbsp;:
          <span class="boldarea">
              <asp:Label ID="lbl_bloodgroup" runat="server" /></span>
                            </li>
                            <li>Phone :
          <span class="boldarea">
              <asp:Label ID="lbl_mobilenumber" runat="server" /></span>
                            </li>
                            <li>E-mail :
          <span class="boldarea">
              <asp:Label ID="lbl_email" runat="server" /></span>
                            </li>
                            <li>Address :
          <span class="boldarea">
              <asp:Label ID="lbl_address" runat="server" /></span>
                            </li>
                            <li>Mem.Date :
          <span class="boldarea">
              <asp:Label ID="lbl_membershipdate" runat="server" /></span>
                            </li>


                        </ul>
                    </div>
                </article>
            </div>
        </div>
    </form>
</body>
</html>

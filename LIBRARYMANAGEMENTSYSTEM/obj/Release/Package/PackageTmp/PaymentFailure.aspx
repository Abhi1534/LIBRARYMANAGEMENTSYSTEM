<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentFailure.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.PaymentFailure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<style>
    #lblTimer {
        font-size: 20px;
        font-weight: bold;
        color: blue;
    }
</style>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>QR Code Display</title>
</head>

<%--<script>
    // Countdown function
    function countdown() {
        var hfTimer = document.getElementById('hfTimer');
        var label = document.getElementById('lblTimer');
        var time = parseInt(hfTimer.value, 10);

        if (time > 0) {
            time--;
            hfTimer.value = time;
            label.innerText = time;
            setTimeout(countdown, 1000); // Call this function again after 1 second (1000ms)
        } else {
            // Time's up, you can perform any action here when the countdown reaches 0
            label.innerText = "Time's up!";<a href="admin/PaymentConformation.aspx">admin/PaymentConformation.aspx</a>
        }
    }

    // Start the countdown when the page loads
    // countdown();


    $(document).ready(function () {
        countdown(); // Start the initial countdown

        // Update countdown every second using AJAX
        setInterval(function () {
            $.ajax({
                type: "POST",
                url: "Default.aspx/GetCountdownValue", // Add the correct URL to your server-side method
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Update the hidden field value with the returned countdown value
                    $("#hfTimer").val(response.d);
                },
                failure: function (response) {
                    // Handle any failure if needed
                }
            });
        }, 1000);
    });
</script>--%>
<body>
    <div style="padding-left:32%;background-image:url(images/Paytm2.png); background-repeat:no-repeat;
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
   " >
        <div class="main-wrapper" style="text-align: center; border: 2px solid blue; max-width: 55%; background-color: white; object-fit: cover">
            <%--  <h1 style="color:blue">QR Code Information</h1>--%>

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
                                            <div class="service-fields mb-3">
                                                <div class="row">
                                                    <div class="col-lg-4" style="font-family: 'Cambria Math'">
                                                        <form id="form1" runat="server">
                                                            <img style="align-content: center" class="form-group" width="300px" src="images/Paytm_Logo.png" /><br />

                                                            <asp:Label ID="lblname" runat="server" CssClass="form-group" Style="font-family: 'Cambria Math'; font-size: 28px;" Text="Payment Status Check Here"></asp:Label>
                                                            <br />
                                                         <%--   <asp:Label class="form-group" ID="Label2" runat="server" Text="You will be redirected in..."></asp:Label>
                                                            <asp:Timer ID="Timer1" runat="server">
                                                            </asp:Timer>--%>
                                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                            </asp:ScriptManager>
                                                            <%--<asp:Label ID="lblTime" runat="server" Text="60"></asp:Label>--%>
                                                          <%--  <asp:HiddenField ID="hfTimer" runat="server" Value="60" ClientIDMode="Static" />
                                                            <asp:Label class="form-group" ID="lblTimer" runat="server" Text="60" ClientIDMode="Static"></asp:Label>--%>
                                                            <p>

                                                                <asp:Label ForeColor="Blue" Font-Size="16px" runat="server" ID="lblPn" Text=""></asp:Label><br />

                                                                <asp:Label ForeColor="Blue" Font-Size="26px" runat="server" Font-Bold="true" ID="Label1" Text="Amount : &#8377;"></asp:Label>
                                                                <asp:Label runat="server" ForeColor="Blue" Font-Size="26px" Font-Bold="true" ID="lblAmount" Text=""></asp:Label>

                                                            </p>
                                                            <p>
                                                                <asp:Label ForeColor="Blue" Font-Size="16px" runat="server" ID="Label3" Text="Transaction Status: "></asp:Label>

                                                                <asp:Label ForeColor="Blue" Font-Size="26px" runat="server" Font-Bold="true" ID="lblStatus" Text=""></asp:Label>

                                                            </p>
                                                            <p>
                                                                <asp:Button ID="btnCheckStatus" class="btn btn-primary submit-btn"  runat="server" Text="Check Payment Status" OnClick="btnCheckStatus_Click" />
                                                            </p>
                                                            <p>
                                                                <asp:LinkButton ID="lnkHome" runat="server" PostBackUrl="~/index.aspx" Text="Click Here to Goto Home Page"></asp:LinkButton>

                                                            </p>

                                                        </form>
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
        </div>
    </div>
</body>
</html>

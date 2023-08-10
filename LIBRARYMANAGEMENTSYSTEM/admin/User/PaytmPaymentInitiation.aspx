<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaytmPaymentInitiation.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.User.PaytmPaymentInitiation" %>


<!DOCTYPE html>
<html lang="en">
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
     <style>
        #lblTimer{
            font-size:20px;
            font-weight:bold;
            color:blue;
        }
    </style>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>QR Code Display</title>
</head>
   <script>
        function refreshPage() {
            location.reload();
        }
    </script>
<script>
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
            if (time % 5==0)
            {
                document.getElementById('hfTimer') = hfTimer;
                document.getElementById('lblTimer') = label;
                updateTimeCount();
               // window.location.reload(false); // Reload the page from the browser cache
        }
        } else {
            // Time's up, you can perform any action here when the countdown reaches 0
            label.innerText = "Time's up!";
            document.getElementById('lblTimer') = "Time's up!";
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
                url: "PaytmPaymentInitiation.aspx/GetCountdownValue", // Add the correct URL to your server-side method
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

    function updateTimeCount() {
        // Make an AJAX request to the server-side endpoint
        $.ajax({
            type: "POST", // Use "POST" or "GET" based on your server-side setup
            url: "PaytmPaymentInitiation.aspx/GetTimeCount", // Replace with the actual URL of the server-side endpoint
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                // Update the UI or perform actions based on the time count
                console.log("Time Count: " + data.d);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.error("Error getting time count: " + errorThrown);
            }
        });
    }
</script>
<body>
  <%--  <meta http-equiv="refresh" content="05" />--%>
    <div style="padding:50px;height:100%; background-image:url(../../images/Paytm2.png); background-repeat:no-repeat;
        
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
   ">
    <div class="main-wrapper" style=" text-align: center;border: 2px solid blue;max-width: 55%; background-color:white;object-fit:cover " >
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
                                                <div class="col-lg-4" style="font-family:'Cambria Math'" >
                                                    <form id="form1" runat="server">
                                                         <img style="align-content:center" class="form-group" width="300px" src="../../images/Paytm_Logo.png" /><br />
        
         <asp:Label ID="lblname" runat="server" CssClass="form-group" style="font-family:'Cambria Math';font-size: 28px;" Text="Accepted Here"></asp:Label>
                                                        <br />
                                                        <asp:Label class="form-group" ID="Label2" runat="server" Text="You will be redirected in..."></asp:Label>
                                                        <asp:Timer ID="timerRefresh" runat="server" Interval="5000" OnTick="timerRefresh_Tick" Enabled="false" />
   <asp:Timer ID="Timer1" runat="server">
                                                        </asp:Timer>
                                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                        </asp:ScriptManager>
                                                        <%--<asp:Label ID="lblTime" runat="server" Text="60"></asp:Label>--%>
                                                        <asp:HiddenField ID="hfTimer" runat="server" Value="" ClientIDMode="Static" />
                                                        <asp:Label class="form-group"  ID="lblTimer" runat="server" Text="" ClientIDMode="Static"></asp:Label>

                                                        <p>
                                                            <asp:Label  ForeColor="Blue" Font-Size="16px" runat="server" ID="lblPn" Text=""></asp:Label><br />                                                           
                                                          
                                                            <asp:Label  ForeColor="Blue" Font-Size="26px" runat="server" Font-Bold="true" ID="Label1" Text="Amount : &#8377;"></asp:Label>
                                                            <asp:Label runat="server" ForeColor="Blue" Font-Size="26px" Font-Bold="true"  ID="lblAmount" Text=""></asp:Label>
                                                           
                                                        </p>
                                                        <div id="divQrCode" runat="server">
                                                        <img runat="server" style="width:144px;height:144px" id="imgQR" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAeAAAAHgAQAAAABVr4M4AAAFOUlEQVR4Xu2aMY7kRgxFaXSwoY6go/TRWkfTUfoIHU6wGJrvk6WetWEY8EYekkmXVP9RyQfJqhnz3wg7LIOHl90+Y3Ga/fj5h9vjtM1jEfHc3HNLi4zbwF3gO5tshOKDd49Yftx4qzdkIa+RhbwpRjNwG/hpMtZhaaxQ7LERNgqHacvsjvmi7LAQHOJt4I7wXopY/PiZhcmzDJ2xFeEh3sg7cF/Yqx5ho4gD4IbDDPPlbzatgZvB6PI5pQ+vXsXWh2G1MwqTmtZZMDFwHxgGxbvE/PsiY+B/kP598T+HZRbiUGUphxGML3JYTr14zuWwKwZuAodp2F9JLhsBKzTQ1PqhNpYO2wZuA+dG9aFi9px6o1e9qns9jRFHi8zCHHwbuAm8HAaTB6HDmHHLWDotRyiLytCHkRfN254Df3t43clSYhw4ZlyMlb1K6SpvpsOFMt/AbWCXNDb2vJPFczhMMFHVRx+oxTFwJ5g3slFsbAw0IXX5KWGMtVwYIHMM6c6dn4GbwCeVhaJDreFNBoyk2atcs04w71I1cBtYZSikMg0KmLySM9UaPLcYfQmrpXjgLjDSii2bVjSkOhqxoEKdtDEjS2qUl6l34BZwbMlhqiyCY6HJ5u0wKpTKkEU6bT2gvgw0A39rOG1kco/pT8gPOQw4POdYTQ6jQsXC9eaIvTp8D9wC3rJFaaEyRInhDYWJFHIYLvQr7305bOAGsJ945ROHlY2OkOpEhLHUtNBkYWIrR2Q5bOAeMNLqVRyEVkO6sVAWYIzF3juvYuAmcGyoIUn6YZJmGdK7bGPxRk+PUz9XrxqYjQYw1QeHXZEbjL93HuleqkdRhoBZsPUauA+83GN3FmpIqx4pyHtauvARdsSFGmhUhgbuAa+pF0aK820jnaglLc1+DT0v/eFn4BbwuUuhylK3tE+jV7kOS1bdSyPOQwvEcuHAXWB/asa93FO1ZjlswUpHPfpitYE7wRlvq1X1IUgXIauhqcYWixyZ63Hg7w27JloYXalEr2IjsmjY1fgbeQnK0Mo7cCNYfuIpGL8mG8oQ0kxH91KpUhnSZBxtzAfuA8cPDrvqEUxONjIWDosP1AWuSZzC/IPAwN8fhkqHeWRRnHE04neZz7MeqQzll8pzAzeBj9jNXkUGjBUKo0WpMOGwWET1WVtEpRu4CezXsxwWCrv7upLba8ShMFmVIbLEygduBav64KdXzrjApXDSkdd0RsJq+QHbXf/uNHAH+Agb8fAl7iGVn5xelRVqu+709RpKNWxg6wHrRBRb+5LuCYbVFKTb1gVcaeTCgdvA0X7w1cN9dSakVY9UmBhf6vzMl6IMRT0yOWzgDrA7M27Y6BeGbCHN6pNwGEsaHaTTlwM3gQ8cJqYWv0w217+1iYmMu25bojBhvoGbwMs9CvoQite65feacS3P2GTRBwKWPQduAR8GbPgp6xGRsPKqRcWb6lVW1/1npMOeA3eAeS6kFJnlUyOOy2GPMz0nRnbkkwP3gfETClt96OHPpTDdrfhVfXJLEeKBG8EZB6bJGddqtL3TvUqa52feaDFwJ/jIXZhdUueNelXUo03SSGd4LhxGqbpG5IG7wHd28yCUk41L4Tr/pMOiV6lCvdNJPHAf+GnLNCYbwSDVs5qWO5pIRxalk8YH7ggz2WCjWCjST8wx21/GX20P3A/enXu3UFjd8kuahSnnGD9TU18auA3My08U5aeInHq9/KTOJGMplubrQDPw94bzTTqsrmKfum7DRitdZOEbYcdNLjTs6AM3gXn3X+O34D8BZvPilGAnT3MAAAAASUVORK5CYII=" />
                                                            </div>
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





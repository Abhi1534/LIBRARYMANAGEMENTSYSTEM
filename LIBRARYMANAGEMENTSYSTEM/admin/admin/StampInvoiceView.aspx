<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="StampInvoiceView.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.StampInvoiceView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-title">Expenditure Details</h3>

                    </div>
                </div>
            </div>
            <div class="content">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12" style="text-align: right">
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
                                                    <img src="../../images/Sublogo.png" alt="logo" height="100px">
                                                </div>
                                            </div>
                                            <div class="col-md-6" style="text-align: right; padding-left: 250px;">
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
                                    <br />
                                    <br />
                                    <!-- Invoice Item -->
                                    <div class="invoice-item">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="invoice-info">
                                                    <strong class="customer-text">Invoice From</strong><br />
                                                    <p class="invoice-details invoice-details-two">
                                                        Telangana High Court Advocates’ Association.
                                                    <br>
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="col-md-6" style="padding-left: 250px;">
                                                <div class="invoice-info invoice-info2">
                                                    <strong class="customer-text">Invoice To</strong><br />
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
                                                    <strong class="customer-text">Payment Method</strong><br />
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
                                                                <td style="text-align:right"><span>
                                                                    <asp:Label ID="lbl_finaltotal" runat="server"  /></span></td>
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
                                                <asp:Image ID="ImageGeneratedBarcode" runat="server" CssClass="img-thumbnail" Visible="false" Width="250px" Height="100px" />
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
        </div>
    </div>
</asp:Content>

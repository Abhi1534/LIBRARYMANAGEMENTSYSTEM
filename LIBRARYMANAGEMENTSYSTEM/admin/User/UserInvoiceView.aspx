<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/admin/User/UserDashboard.Master" AutoEventWireup="true" CodeBehind="UserInvoiceView.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.User.UserInvoiceView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table#ContentPlaceHolder1_gdvInvoice th.gridHeadStyle, tr td {
            border: 1px solid #dee2e6;
            padding: 10px;
            text-align: center;
        }

        th.gridHeadStyle {
            background: #cdcdcd;
        }

        table#ContentPlaceHolder1_gdvInvoice th {
            background: #cdcdcd;
            padding: 11px 2px;
            text-align: center;
        }
    </style>
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
    <%-- <div class="main-wrapper">--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="col-md-7 col-lg-8 col-xl-9" data-select2-id="9">
        <div class="page-header">
            <div class="row">
                <div class="col-lg-12">
                    <h3 class="page-title">Invoice View</h3>

                </div>
            </div>
        </div>
        <!-- Basic Information -->
        <div class="card" data-select2-id="8">
            <div class="card-body" data-select2-id="7">

                <!-- Page Header -->


                <div class="row">
                    <div class="col-lg-6" style="text-align: left">
                        <div class="form-group">
                            <asp:LinkButton runat="server" ID="btn_back" CssClass="btn btn-primary btn-sm" OnClick="btn_back_Click"><i class="fa fa-solid fa fa-circle-left" aria-hidden="true"></i>Back</asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-lg-6" style="text-align: right">
                        <div class="form-group">
                            <input type="button" onclick="printDiv('printableArea')" value="print" class="btn btn-primary btn-sm" />
                        </div>
                    </div>
                </div>


                <!-- Page Content -->
                <div class="content" id="printableArea">
                    <%--  <div class="container-fluid">

                            <div class="row">
                                <div class="col-lg-12 offset-lg-2">
                                    <div class="invoice-content">
                                        <div class="invoice-item">--%>
                    <div class="row">
                        <div class="col-md-8">
                            <div class="invoice-logo">
                                <img src="../../images/Sublogo.png" width="600px" height="100px" alt="logo">
                            </div>
                        </div>
                        <div class="col-md-4">
                            <p class="invoice-details" style="float: right">
                                <strong>Order:</strong>
                                <asp:Label ID="lbl_invoicenumber" runat="server" />
                                <br>
                                <strong>Issued:</strong>
                                <asp:Label ID="lbl_OrderIDDate" runat="server" />
                            </p>
                        </div>
                    </div>
                    <%-- </div>
                                        <br />
                                        <br />
                                        <br />--%>
                    <!-- Invoice Item -->
                    <br />
                    <br />
                    <div class="invoice-item">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="invoice-info">
                                    <strong class="customer-text">Invoice From</strong>
                                    <p class="invoice-details invoice-details-two">
                                        Telangana High Court Advocates’ Association.
                                                            <br />
                                    </p>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="invoice-info invoice-info2">
                                    <strong class="customer-text">Invoice To</strong>
                                    <p class="invoice-details">
                                        <asp:Label ID="lbl_Inviocername" runat="server" />
                                        <br />
                                        <asp:Label ID="lbl_Address" runat="server" />
                                        <br />
                                        <%-- <asp:Label ID="lbl_invoicermobile" runat="server" /><br />--%>
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
                                        <asp:Label ID="lblPaymentType" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /Invoice Item -->

                    <!-- Invoice Item -->
                    <div class="table-responsive">
                        <table class="table mb-0">
                            <asp:GridView ID="gdvInvoice" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                                Width="100%" GridLines="None" ShowFooter="true"
                                EmptyDataText="No details">
                                <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Description">

                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblBookID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BookID")%>'> </asp:Label>--%>
                                            <asp:Label ID="lblItemName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Name")%>'> </asp:Label></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Qty">

                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblBookID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BookID")%>'> </asp:Label>--%>
                                            <asp:Label ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Qty")%>'> </asp:Label></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Amount">

                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblBookID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BookID")%>'> </asp:Label>--%>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Amount")%>'> </asp:Label></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle Font-Bold="True" />
                            </asp:GridView>

                        </table>
                    </div>
                </div>

            </div>
        </div>


        <%--   </div>
                                </div>
                            </div>

                        </div>

                    </div>
                    <!-- /Page Content -->

                </div>
            </div>

        </div>--%>
    </div>
</asp:Content>

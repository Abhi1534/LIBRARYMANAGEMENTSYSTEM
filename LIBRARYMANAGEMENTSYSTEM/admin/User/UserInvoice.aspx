<%@ Page Title="" Language="C#" MasterPageFile="~/admin/User/UserDashboard.Master" AutoEventWireup="true" CodeBehind="UserInvoice.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.User.UserInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-7 col-lg-8 col-xl-9" data-select2-id="9">

        <!-- Basic Information -->
        <div class="card" data-select2-id="8">
            <div class="card-body" data-select2-id="7">

                <!-- Page Header -->
                <div class="page-header">
                    <div class="row">
                        <div class="col-sm-12">
                            <h3 class="page-title">Invoice</h3>

                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-5" style="text-align: right">
                        <div class="form-group">
                            <asp:TextBox ID="txtSearch" class="form-control" placeholder="Search here" runat="server" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>

                </div>



                <div class="table-responsive">
                    <table class="table mb-0">


                        <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                            Width="100%" GridLines="None" OnRowCommand="grid_data_RowCommand"
                            EmptyDataText="No details">
                            <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                            <Columns>
                                <asp:TemplateField HeaderText="SINO">

                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inovice Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_PaymentIntiationpage" runat="server" Visible="false" Text='<%# Eval("PaymentIntiationpage")%>'></asp:Label>
                                        <asp:Label ID="lbl_InoviceNum" runat="server" Text='<%# Eval("InoviceNum")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Created Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_CreatedDate" runat="server" Text='<%# Eval("CreatedDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Payment Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_PaymentType" runat="server" Text='<%# Eval("PaymentType")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Amount" runat="server" Text='<%# Eval("Amount")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>

                                        <asp:LinkButton runat="server" CommandName="Btn_ViewCommand" CommandArgument="<%# Container.DataItemIndex %>" ID="btn_Edit"><asp:image imageurl="../admin/Images/view.svg" runat="server" Height="20px" Width="20px" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </table>
                </div>
                <%-- </div>--%>
            </div>
        </div>
    </div>
    <%-- </div>

    </div>--%>
    <%--  </div>
        </div>
    </div>--%>
    <%--   </div>
        </div>
    </div>--%>
    <!-- /Page Wrapper -->



    <!-- /Main Wrapper -->

    <!-- jQuery -->
    <script src="../admin/assets/js/jquery-3.2.1.min.js"></script>


    <!-- Bootstrap Core JS -->
    <script src="../admin/assets/js/popper.min.js"></script>
    <script src="../admin/assets/js/bootstrap.min.js"></script>

    <!-- Slimscroll JS -->
    <script src="../admin/assets/plugins/slimscroll/jquery.slimscroll.min.js"></script>

    <!-- Datatables JS -->
    <script src="../admin/assets/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../admin/assets/plugins/datatables/datatables.min.js"></script>

    <!-- Custom JS -->
    <script src="../admin/assets/js/script.js"></script>

</asp:Content>


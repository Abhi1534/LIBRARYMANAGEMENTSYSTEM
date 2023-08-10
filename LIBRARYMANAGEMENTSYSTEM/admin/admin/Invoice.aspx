<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        
        table#ContentPlaceHolder1_gdvLibartyStatus th.gridHeadStyle, tr td {
            border: 1px solid #dee2e6;
            padding: 10px;
            text-align: left;
        }

        th.gridHeadStyle {
            background: #cdcdcd;
        }

        table#ContentPlaceHolder1_gdvLibartyStatus th {
            background: #cdcdcd;
            padding: 11px 2px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">Invoice View</h3>

                    </div>
                </div>
            </div>

              <div class="row">
                <div class="col-lg-5" style="text-align: right">
                    <div class="form-group">
                          <asp:TextBox ID="txtSearch" class="form-control" placeholder="Search here" runat="server" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox></div>
                </div>

            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body custom-edit-service">
                            <div class="service-fields mb-3">
                               
                              

                                <div class="table-responsive">
                                    <table class="table mb-0">


                                       <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                                Width="100%" GridLines="None" OnRowCommand="grid_data_RowCommand" OnPageIndexChanging="grid_data_PageIndexChanging"
                                EmptyDataText="No details">
                                <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SINO" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">

                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inovice Number" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PaymentIntiationpage" runat="server" Visible="false" Text='<%# Eval("PaymentIntiationpage")%>'></asp:Label>
                                            <asp:Label ID="lbl_InoviceNum" runat="server" Text='<%# Eval("InoviceNum")%>'></asp:Label>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Created Date" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_CreatedDate" runat="server" Text='<%# Eval("CreatedDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Payment Type" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PaymentType" runat="server" Text='<%# Eval("PaymentType")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Amount" runat="server" Text='<%# Eval("Amount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>

                                            <asp:LinkButton runat="server" CommandName="Btn_ViewCommand" CommandArgument="<%# Container.DataItemIndex %>" ID="btn_Edit"><asp:image imageurl="Images/view.svg" runat="server" Height="20px" Width="20px" /></asp:LinkButton>
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

                </div>
            </div>
        </div>
    </div>
    <%--   </div>
        </div>
    </div>--%>
    <!-- /Page Wrapper -->



    <!-- /Main Wrapper -->

    <!-- jQuery -->
    <script src="assets/js/jquery-3.2.1.min.js"></script>

    <!-- Bootstrap Core JS -->
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!-- Slimscroll JS -->
    <script src="assets/plugins/slimscroll/jquery.slimscroll.min.js"></script>

    <!-- Datatables JS -->
    <script src="assets/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/plugins/datatables/datatables.min.js"></script>

    <!-- Custom JS -->
    <script src="assets/js/script.js"></script>

</asp:Content>


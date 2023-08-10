<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Libabry_Status.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.Libabry_Status" %>

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
    <!-- Page Wrapper -->
    <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">Books Status</h3>

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


                                        <asp:GridView ID="gdvLibartyStatus" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                                            Width="100%" GridLines="None"
                                            EmptyDataText="No details" OnPageIndexChanging="gdvLibartyStatus_PageIndexChanging">
                                            <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Book Name">

                                                    <ItemTemplate>
                                                        <a href="profile.aspx"  class="avatar avatar-sm mr-2">
                                                            <img class="avatar-img rounded-circle" src="assets/img/doctors/doctor-thumb-01.jpg" alt="User Image"></a>

                                                        <asp:Label ID="lblBookName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BookName")%>'> </asp:Label></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Book Author">
                                                    <ItemTemplate>
                                                        <a href="profile.aspx" class="avatar avatar-sm mr-2">
                                                            <img class="avatar-img rounded-circle" src="assets/img/doctors/doctor-thumb-01.jpg" alt="User Image"></a>

                                                        <asp:Label ID="lblBookAuthor" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AutherName")%>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Books">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalBooks" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"NoOfBooks")%>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Available Books">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAvailableBooks" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AvailableBooks")%>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Price")%>'> </asp:Label>
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

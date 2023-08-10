<%@ Page Title="" Language="C#" MasterPageFile="~/admin/User/UserDashboard.Master" AutoEventWireup="true" CodeBehind="MembersBookStatus.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.User.MembersBookStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table#ContentPlaceHolder1_gdvLibartyStatus th.gridHeadStyle, tr td {
            border: 1px solid #dee2e6;
            padding: 10px;
            /*text-align: left;*/
        }

        table#ContentPlaceHolder1_grid_data th.gridHeadStyle, tr td {
            border: 1px solid #dee2e6;
            padding: 10px;
            /*text-align: left;*/
        }

        th.gridHeadStyle {
            background: #cdcdcd;
        }

        table#ContentPlaceHolder1_gdvLibartyStatus th {
            background: #cdcdcd;
            padding: 11px 2px;
            text-align: center;
        }
        .text{    text-align: left;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-7 col-lg-8 col-xl-9" data-select2-id="9">
        <div class="row">
            <div class="col-md-5">
                <asp:TextBox ID="txtSearch" class="form-control" placeholder="Search here" runat="server" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
                <%--<button class="btn" type="submit"><i class="fa fa-search"></i></button>--%>
                <br />
            </div>

        </div>
        <!-- Basic Information -->
        <div class="card" data-select2-id="8">

            <div class="card-body" data-select2-id="7">
                <!-- <h2 class="text-center mb-4">Estimation Approval</h2> -->

                <div class="table-responsive">
                    <table class="table mb-0">


                        <asp:GridView ID="gdvLibartyStatus" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                            Width="100%" GridLines="None" OnPageIndexChanging="gdvLibartyStatus_PageIndexChanging"
                            EmptyDataText="No details">
                            <EmptyDataRowStyle Height="100px" HorizontalAlign="left" CssClass="datatable table table-hover table-center mb-0" />
                            <Columns>
                                <asp:TemplateField HeaderText="Book Name" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="text">

                                    <ItemTemplate>
                                        <a href="profile.aspx" class="avatar avatar-sm mr-2">
                                            <img class="avatar-img rounded-circle" src="../assets/img/doctors/doctor-thumb-01.jpg" alt="User Image"></a>

                                        <asp:Label ID="lblBookName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BookName")%>'> </asp:Label></a>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Book Author" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="text">
                                    <ItemTemplate>
                                        <a href="profile.aspx" class="avatar avatar-sm mr-2">
                                            <img class="avatar-img rounded-circle" src="../assets/img/doctors/doctor-thumb-01.jpg" alt="User Image"></a>

                                        <asp:Label ID="lblBookAuthor" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AutherName")%>'> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Books" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalBooks" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"NoOfBooks")%>'> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Available Books" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAvailableBooks" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AvailableBooks")%>'> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Price")%>'> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                        </asp:GridView>
                    </table>
                </div>
            </div>
        </div>
        <!-- /Recent Orders -->


        <!-- /Basic Information -->


        <!-- /Registrations -->

        <!-- <div class="submit-section submit-btn-bottom">
								<button type="submit" class="btn btn-primary submit-btn" type="button" data-toggle="modal" data-target="#tooltipmodal" data-original-title="" title="">Sumbit</button>
								
							</div> -->

    </div>



    <!-- /Page Content -->

    <!-- Footer -->



    <div class="modal fade" id="tooltipmodal" tabindex="-1" role="dialog" aria-labelledby="tooltipmodal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">

                <div class="success-card">
                    <div class="card-body">
                        <div class="success-cont">
                            <i class="fas fa-check"></i>
                            <h3>Successfully!</h3>
                            <p class="mb-0">Product ID: 245468</p>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal" data-original-title="" title="">Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

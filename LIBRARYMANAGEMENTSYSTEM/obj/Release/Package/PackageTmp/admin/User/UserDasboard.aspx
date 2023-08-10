<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/admin/User/UserDashboard.Master" AutoEventWireup="true" CodeBehind="UserDasboard.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.User.UserDasboard" %>

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

        .zoom {
            transition: transform .2s;
            width: 300px;
            height: 300px;
        }

            .zoom:hover {
                -ms-transform: scale(1.5); /* IE 9 */
                -webkit-transform: scale(1.5); /* Safari 3-8 */
                transform: scale(5.1);
            }

        .chkChoice input {
            margin-left: 10px;
            margin-right: 5px;
        }

        .myCheckBoxList label {
            padding-right: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-7 col-lg-8 col-xl-9" data-select2-id="9">

        <div class="alert alert-success" id="div_success" runat="server" visible="false">
            <strong>Success!</strong>.
        </div>
        <div class="alert alert-danger" runat="server" visible="false" id="div_fail">
            <strong>fail!</strong>
        </div>
        <!-- Basic Information -->
        <div class="card" data-select2-id="8">
            <div class="card-body" data-select2-id="7">
                <%-- <div class="page-wrapper">
                    <div class="content container-fluid">--%>

                <div class="page-header">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="page-title">Dashboard</h3>

                        </div>
                    </div>
                </div>


                <div class="col-md-12 col-lg-12 col-xl-12">
                    <div class="card">
                        <div class="card-body">

                            <!-- Profile Settings Form -->
                            <form>
                                <div class="row form-row">
                                    <div class="col-12 col-md-4">
                                        <div class="form-group">
                                            <label>Full Name</label>
                                            <asp:TextBox runat="server" ID="txt_Name" class="form-control" ReadOnly="true" />
                                        </div>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <div class="form-group">
                                            <label>Date of Birth</label>
                                            <asp:TextBox runat="server" ID="txt_dob" class="form-control" TextMode="Date" ReadOnly="true" />

                                        </div>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <div class="form-group">
                                            <label>Blood Group</label>
                                            <asp:TextBox runat="server" ID="txt_Bloodgroup" class="form-control" ReadOnly="true" />

                                        </div>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <div class="form-group">
                                            <label>Email ID</label>
                                            <asp:TextBox runat="server" ID="txt_email" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <div class="form-group">
                                            <label>Mobile</label>
                                            <asp:TextBox runat="server" ID="txt_mobile" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <div class="form-group">
                                            <label>Address</label>
                                            <asp:TextBox runat="server" ID="txt_address" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <div class="form-group">
                                            <label>Enrollment Number</label>
                                            <asp:TextBox runat="server" class="form-control" ID="txt_enrollmentnumber" ReadOnly="true" />

                                        </div>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <div class="form-group">
                                            <label>Enrollment Date</label>
                                            <asp:TextBox runat="server" class="form-control" ID="txt_enrollmentdate" TextMode="Date" ReadOnly="true" />

                                        </div>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <div class="form-group">
                                            <label>Membership Date</label>
                                            <asp:TextBox runat="server" class="form-control" ID="txt_membershipdate" ReadOnly="true" TextMode="Date" />

                                        </div>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <div class="form-group">
                                            <label>Membership Type</label>
                                            <asp:DropDownList runat="server" class="form-control select" ID="ddl_MemberShipType">
                                            </asp:DropDownList>

                                        </div>
                                    </div>

                                </div>

                            </form>
                            <!-- /Profile Settings Form -->

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <%--   </div>
                </div>
    --%>
</asp:Content>

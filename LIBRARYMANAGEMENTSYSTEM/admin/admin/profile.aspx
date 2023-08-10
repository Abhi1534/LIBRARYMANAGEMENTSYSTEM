<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.profile" %>

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
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="alert alert-success" id="div_success" runat="server" visible="false">
                <strong>Success!</strong>.
            </div>
            <div class="alert alert-danger" runat="server" visible="false" id="div_fail">
                <strong>fail!</strong>
            </div>
            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col">
                        <h3 class="page-title">Profile</h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="index.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active">Profile</li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- /Page Header -->

            <div class="row">
                <div class="col-md-12">
                    <div class="profile-header">
                        <div class="row align-items-center">
                            <div class="col-auto profile-image">
                                <a href="#">
                                    <asp:Image ID="img_photoupload" runat="server" CssClass="zoom" />
                                </a>
                            </div>
                            <div class="col ml-md-n2 profile-user-info">
                                <h4 class="user-name mb-0">
                                    <asp:Label ID="lbl_profilename" runat="server" /></h4>
                                <h6 class="text-muted">
                                    <asp:Label ID="lbl_email" runat="server" /></h6>
                            </div>
                            <div class="col-auto profile-btn">

                                <%--<a href="" class="btn btn-primary">
											Edit
										</a>--%>
                            </div>
                        </div>
                    </div>
                    <div class="profile-menu">
                        <ul class="nav nav-tabs nav-tabs-solid">
                            <li class="nav-item">
                                <a class="nav-link active" data-toggle="tab" href="#per_details_tab">About</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-toggle="tab" href="#password_tab">Password</a>
                            </li>
                        </ul>
                    </div>
                    <div class="tab-content profile-tab-cont">

                        <!-- Personal Details Tab -->
                        <div class="tab-pane fade show active" id="per_details_tab">

                            <!-- Personal Details -->
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="card">
                                        <div class="card-body">
                                            <h5 class="card-title d-flex justify-content-between">
                                                <span>Personal Details</span>
                                                <a class="edit-link" data-toggle="modal" href="#edit_personal_details"><i class="fa fa-edit mr-1"></i>Edit</a>
                                            </h5>
                                            <div class="row">
                                                <p class="col-sm-2 text-muted text-sm-right mb-0 mb-sm-3">Name</p>
                                                <p class="col-sm-10">
                                                    <asp:Label ID="lbl_pname" runat="server" />
                                                </p>
                                            </div>
                                            <div class="row">
                                                <p class="col-sm-2 text-muted text-sm-right mb-0 mb-sm-3">Date of Birth</p>
                                                <p class="col-sm-10">
                                                    <asp:Label ID="lbl_dob" runat="server" />
                                                </p>
                                            </div>
                                            <div class="row">
                                                <p class="col-sm-2 text-muted text-sm-right mb-0 mb-sm-3">Email ID</p>
                                                <p class="col-sm-10">
                                                    <asp:Label ID="lbl_pemail" runat="server" />
                                                </p>
                                            </div>
                                            <div class="row">
                                                <p class="col-sm-2 text-muted text-sm-right mb-0 mb-sm-3">Mobile</p>
                                                <p class="col-sm-10">
                                                    <asp:Label ID="lbl_mobile" runat="server" />
                                                </p>
                                            </div>
                                            <div class="row">
                                                <p class="col-sm-2 text-muted text-sm-right mb-0">Address</p>
                                                <p class="col-sm-10 mb-0">
                                                    <asp:Label ID="lbl_Address" runat="server" />
                                                </p>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Edit Details Modal -->
                                    <div class="modal fade" id="edit_personal_details" aria-hidden="true" role="dialog">
                                        <div class="modal-dialog modal-dialog-centered" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title">Personal Details</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body">
                                                    <form>
                                                        <div class="row form-row">
                                                            <div class="col-12 col-sm-6">
                                                                <div class="form-group">
                                                                    <label>Name</label>
                                                                    <asp:TextBox runat="server" ID="txt_Name" required="" class="form-control" />

                                                                </div>
                                                            </div>

                                                            <div class="col-12">
                                                                <div class="form-group">
                                                                    <label>Date of Birth</label>
                                                                    <div class="cal-icon">
                                                                        <asp:TextBox runat="server" ID="txt_dob" required="" class="form-control" TextMode="Date" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-12 col-sm-6">
                                                                <div class="form-group">
                                                                    <label>Email ID</label>
                                                                    <asp:TextBox runat="server" ID="txt_email" required="" class="form-control" />
                                                                </div>
                                                            </div>
                                                            <div class="col-12 col-sm-6">
                                                                <div class="form-group">
                                                                    <label>Mobile</label>
                                                                    <asp:TextBox runat="server" ID="txt_mobile" required="" class="form-control" />
                                                                </div>
                                                            </div>
                                                            <div class="col-12">
                                                                <h5 class="form-title"><span>Address</span></h5>
                                                            </div>
                                                            <div class="col-12">
                                                                <div class="form-group">
                                                                    <label>Address</label>
                                                                    <asp:TextBox runat="server" ID="txt_address" required="" class="form-control" />
                                                                </div>
                                                            </div>
                                                            <div class="col-12 col-sm-6">
                                                                <div class="form-group">
                                                                    <label>Clerk Name<span class="text-danger"></span></label>
                                                                    <asp:TextBox runat="server" class="form-control" ID="txt_ClerkName" />


                                                                </div>
                                                            </div>
                                                            <div class="col-12 col-sm-6">
                                                                <div class="form-group">
                                                                    <label>Clerk Mobile Number<span class="text-danger"></span></label>
                                                                    <asp:TextBox runat="server" class="form-control" ID="txt_clerkmobilenumber" />


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <asp:Button Text="Save Changes" runat="server" class="btn btn-primary btn-block" ID="btn_upadateDetails" OnClick="btn_upadateDetails_Click" />

                                                    </form>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /Edit Details Modal -->

                                </div>


                            </div>
                            <!-- /Personal Details -->

                        </div>
                        <!-- /Personal Details Tab -->

                        <!-- Change Password Tab -->
                        <div id="password_tab" class="tab-pane fade">

                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title">Change Password</h5>
                                    <div class="row">
                                        <div class="col-md-10 col-lg-6">

                                            <div class="form-group">
                                                <label>Old Password</label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_oldpassword" TextMode="Password" />

                                            </div>
                                            <div class="form-group">
                                                <label>New Password</label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_password" TextMode="Password" />

                                            </div>
                                            <div class="form-group">
                                                <label>Confirm Password</label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_confirmpassword" />
                                                <asp:CompareValidator ErrorMessage="Please check the password" ForeColor="Red" ControlToValidate="txt_confirmpassword" runat="server" ControlToCompare="txt_password" ValidationGroup="A" />
                                            </div>
                                            <asp:Button Text="Save Changes" runat="server" class="btn btn-primary" ValidationGroup="A" ID="btn_passwordsubmit" OnClick="btn_passwordsubmit_Click" UseSubmitBehavior="false" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /Change Password Tab -->

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

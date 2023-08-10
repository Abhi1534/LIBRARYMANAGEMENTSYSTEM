<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="MembershipPaymentConformation.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.MembershipPaymentConformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">Payment Conformation</h3>

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body custom-edit-service">
                            <div class="service-fields mb-3">
                                <div class="content success-page-cont">
                                    <div class="container-fluid">

                                        <div class="row justify-content-center">
                                            <div class="col-lg-6">

                                                <!-- Success Card -->
                                                <div class="card success-card">
                                                    <div class="card-body">
                                                        <div class="success-cont">
                                                            <i class="fas fa-check"></i>
                                                            <h3>Payment Successfully!</h3>
                                                            <asp:LinkButton Text="Download Invoice" runat="server" ID="btn_downloadinvoice" OnClick="btn_downloadinvoice_Click" />
                                                            <%--<p class="mb-0">Product ID: 245468</p>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /Success Card -->

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
</asp:Content>

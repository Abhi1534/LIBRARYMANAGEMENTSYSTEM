<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="IDCardDetails.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.IDCardDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">



            <asp:Panel ID="pnlSearch" runat="server">

                <div class="alert alert-danger" runat="server" visible="false" id="div_fail">
                    <strong>Details are not available !</strong>
                </div>

                <div class="col-sm-12">
                    <div class="card">

                        <div class="row">

                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:TextBox runat="server" class="form-control" placeholder="Search here" ID="txt_search" required="" />
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn btn-primary btn-sm" OnClick="lnkSearch_Click"><i class="fa fa-solid fa fa-circle-left" aria-hidden="true"></i>Search</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>

            </asp:Panel>

            <asp:Panel ID="pnlIDCard" runat="server" Visible="false">
                <div class="row">
                    <div class="col-lg-12" style="text-align: right">
                        <div class="form-group">
                            <asp:LinkButton runat="server" ID="btn_back" CssClass="btn btn-primary btn-sm" OnClick="btn_back_Click" Visible="false"><i class="fa fa-solid fa fa-circle-left" aria-hidden="true"></i>Back</asp:LinkButton>
                        </div>
                    </div>

                </div>
                <section id="teachers-part" style="padding-top: 10px">
                    <%--class="pt-280 pb-120"--%>
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-5">
                                <div class="section-title mt-50 pb-35">

                                    <h3>Member Details:</h3>
                                </div>
                                <!-- section title -->
                            </div>
                        </div>




                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-body custom-edit-service">
                                        <div class="service-fields mb-3">

                                            <div class="row">
                                                <div class="col-sm-4">

                                                    <div class="form-group">
                                                        <div class="change-avatar">
                                                            <div class="profile-img">
                                                                <asp:Image ID="img_photoupload" runat="server" CssClass="imgfill" Height="300px" Width="300px" BorderStyle="groove" />
                                                                <br />
                                                                <br />
                                                                <%--  <label>Membership Type</label>--%>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <asp:Label ID="txt_lbl_membershiptype" runat="server" Style="font-weight: bold; padding-left: 35px; font-family: 'FontAwesome'; font-size: x-large; color: crimson;" />
                                                    <div class="form-group">
                                                        <div class="change-avatar">
                                                            <div class="profile-img">
                                                               <asp:Label Style="font-weight: bold; padding-left: 35px; font-family: 'FontAwesome'; font-size: x-large; color: black;">QRCode</asp:Label>
                                                                <asp:Image ID="QRCode" runat="server" CssClass="imgfill" Height="300px" Width="300px" BorderStyle="groove" />
                                                                <br />
                                                                <br />
                                                                <%--  <label>Membership Type</label>--%>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <%--  <asp:DropDownList runat="server" CssClass="member"  ID="ddl_MemberShipType" ReadOnly="true" Font-Bold="true">
                                            </asp:DropDownList>--%>
                                                </div>

                                                <div class="col-lg-8">
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <label>Full Name</label>
                                                                <asp:TextBox runat="server" ID="txt_Name" class="form-control textb" ReadOnly="true" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <label>Date of Birth</label>
                                                                <asp:TextBox runat="server" ID="txt_dob" class="form-control textb" TextMode="Date" ReadOnly="true" />

                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <label>Blood Group</label>
                                                                <asp:TextBox runat="server" ID="txt_Bloodgroup" class="form-control textb" ReadOnly="true" />

                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <label>Email ID</label>
                                                                <asp:TextBox runat="server" ID="txt_email" class="form-control textb" ReadOnly="true" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <label>Mobile</label>
                                                                <asp:TextBox runat="server" ID="txt_mobile" class="form-control textb" ReadOnly="true" />
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <label>Enrollment Number</label>
                                                                <asp:TextBox runat="server" class="form-control textb" ID="txt_enrollmentnumber" ReadOnly="true" />

                                                            </div>
                                                        </div>

                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <label>Enrollment Date</label>
                                                                <asp:TextBox runat="server" class="form-control textb" ID="txt_enrollmentdate" TextMode="Date" ReadOnly="true" />

                                                            </div>
                                                        </div>

                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <label>Membership Date</label>
                                                                <asp:TextBox runat="server" class="form-control textb" ID="txt_membershipdate" ReadOnly="true" TextMode="Date" />
                                                            </div>
                                                        </div>


                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <label>Clerk Name</label>
                                                                <asp:TextBox runat="server" class="form-control textb" ID="txt_clerkname" ReadOnly="true" />
                                                            </div>
                                                        </div>


                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <label>Clerk Mobile Number</label>
                                                                <asp:TextBox runat="server" class="form-control textb" ID="txt_ClerkMobilenumber" ReadOnly="true" />
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <label>Address</label>
                                                                <asp:TextBox runat="server" ID="txt_address" class="form-control textb" ReadOnly="true" TextMode="MultiLine" />
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
                </section>
            </asp:Panel>
        </div>


    </div>
</asp:Content>

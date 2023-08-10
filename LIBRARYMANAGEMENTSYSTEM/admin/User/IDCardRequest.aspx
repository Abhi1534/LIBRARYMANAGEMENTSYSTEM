<%@ Page Title="" Language="C#" MasterPageFile="~/admin/User/UserDashboard.Master" AutoEventWireup="true" CodeBehind="IDCardRequest.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.User.IDCardRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-7 col-lg-8 col-xl-9" data-select2-id="9">
        <div class="page-header">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="page-title">ID Card Request</h3>

                </div>
            </div>
        </div>
        <div class="card" data-select2-id="8">
            <div class="card-body" data-select2-id="7">



                <p>Note: !Important for every new ID Card Request charge of 200.</p>


                <div class="service-fields mb-3">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Advocate Name<span class="text-danger">*</span></label>
                                <asp:TextBox runat="server" class="form-control" ID="txt_Advocatename" required="" />

                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Mobile Number<span class="text-danger">*</span></label>
                                <asp:TextBox runat="server" class="form-control" ID="txt_MobileNumber" required="" />

                            </div>
                        </div>


                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Email<span class="text-danger">*</span></label>
                                <asp:TextBox runat="server" class="form-control" ID="txt_email" required="" />

                            </div>
                        </div>


                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Enrollment Number<span class="text-danger">*</span></label>
                                <asp:TextBox runat="server" class="form-control" ID="txt_enrollmentnumber" required="" />

                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Enrollment Date<span class="text-danger">*</span></label>
                                <asp:TextBox runat="server" class="form-control" ID="txt_enrollmentdate" required="" TextMode="Date" />

                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Address<span class="text-danger">*</span></label>
                                <asp:TextBox runat="server" class="form-control" ID="txt_address" required="" />

                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>DOB<span class="text-danger">*</span></label>
                                <asp:TextBox runat="server" class="form-control" ID="txt_dob" TextMode="Date" required="" />

                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Blood Group<span class="text-danger">*</span></label>
                                <asp:DropDownList runat="server" class="form-control select" ID="ddl_Bloodgroup">
                                    <asp:ListItem Text="A+" />
                                    <asp:ListItem Text="A-" />
                                    <asp:ListItem Text="B+" />
                                    <asp:ListItem Text="B-" />
                                    <asp:ListItem Text="O+" />
                                    <asp:ListItem Text="O-" />
                                    <asp:ListItem Text="AB+" />
                                    <asp:ListItem Text="AB-" />
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Membership Type<span class="text-danger">*</span></label>
                                <asp:DropDownList runat="server" class="form-control select" ID="ddl_MemberShipType" Enabled="false" Height="46px" Width="100%">
                                </asp:DropDownList>

                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Membership Date<span class="text-danger">*</span></label>
                                <asp:TextBox runat="server" class="form-control" ID="txt_membershipdate" required="" TextMode="Date" ReadOnly="true" />

                            </div>
                        </div>


                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Delivery Type <span class="text-danger">*</span></label>
                                <asp:RadioButtonList runat="server" class="radio_input" ID="rb_deliverytype" OnSelectedIndexChanged="rb_deliverytype_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="true">
                                    <asp:ListItem Text="By Hand" Value="0" Selected="True" />
                                    <asp:ListItem Text="Post" Value="1" />
                                </asp:RadioButtonList>

                            </div>
                        </div>


                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Price<span class="text-danger">*</span></label>
                                <asp:TextBox runat="server" class="form-control" ID="txt_price" required="" Text="200" ReadOnly="true" />

                            </div>
                        </div>
                    </div>
                    <asp:Label ID="lbl_deliverynote" Text="Note: ID Card Delivered through Post to your registered adress charges will apply 50/-, . " runat="server" Visible="false" ForeColor="Red" />

                </div>

                <div class="submit-section">
                    <asp:Button Text="Payment" class="btn btn-primary submit-btn" runat="server" ID="btn_payment" OnClick="btn_payment_Click" />
                </div>

                <%-- <div class="card">
                                <div class="card-body custom-edit-service">--%>
            </div>

        </div>

    </div>

</asp:Content>

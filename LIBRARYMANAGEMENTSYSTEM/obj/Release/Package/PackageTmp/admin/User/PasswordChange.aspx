<%@ Page Title="" Language="C#" MasterPageFile="~/admin/User/UserDashboard.Master" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.User.PasswordChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-7 col-lg-8 col-xl-9" data-select2-id="9">
        <div class="page-header">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="page-title">Change Password</h3>

                </div>
            </div>
        </div>
         <div class="alert alert-success" id="div_success" runat="server" visible="false">
                <strong>Success!</strong>.
            </div>
            <div class="alert alert-danger" runat="server" visible="false" id="div_fail">
                <strong>fail!</strong>
            </div>
        <div class="card" data-select2-id="8">
            <div class="card-body" data-select2-id="7">

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
</asp:Content>

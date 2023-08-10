<%@ Page Title="" Language="C#" MasterPageFile="~/admin/User/UserDashboard.Master" AutoEventWireup="true" CodeBehind="UserPaymentConformation.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.User.UserPaymentConformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-7 col-lg-8 col-xl-9" data-select2-id="9">

        <!-- Basic Information -->
        <div class="card" data-select2-id="8">
            <div class="card-body" data-select2-id="7">
                <div class="card success-card">
                    <div class="card-body">
                        <div class="success-cont">
                            <i class="fas fa-check"></i>
                            <h3><asp:Label ID="lbl_paymentstatus" runat="server" /></h3>
                            <p class="mb-0">
                                <asp:LinkButton Text="View Invioce" runat="server" ID="btn_view" OnClick="btn_view_Click" ForeColor="Blue" />&nbsp&nbsp&nbsp&nbsp
                                 <asp:LinkButton Text="View RequestSample" runat="server" ID="btn_viewcard" OnClick="btn_viewcard_Click" Visible="false" ForeColor="Green"/>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

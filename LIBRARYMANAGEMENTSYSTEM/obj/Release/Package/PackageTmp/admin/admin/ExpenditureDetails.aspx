<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="ExpenditureDetails.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.ExpenditureDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-title">Expenditure Details</h3>

                    </div>
                </div>
            </div>



            <div class="row">

                <div class="col-lg-5">
                    <div class="form-group">
                        <asp:TextBox runat="server" class="form-control" placeholder="Search here" ID="txt_search" AutoPostBack="true" OnTextChanged="txt_search_TextChanged" />
                        <cc1:AutoCompleteExtender ClientIDMode="Static" EnableCaching="false" ServiceMethod="SearchText" MinimumPrefixLength="1"
                            CompletionInterval="100" CompletionSetCount="10" TargetControlID="txt_search" ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                        </cc1:AutoCompleteExtender>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12" style="text-align: right">
                    <div class="form-group">
                        <asp:LinkButton runat="server" ID="btn_back" CssClass="btn btn-primary btn-sm" OnClick="btn_back_Click"><i class="fa fa-solid fa fa-circle-left" aria-hidden="true"></i>Back</asp:LinkButton>
                    </div>
                </div>

            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table mb-0">
                        <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                            Width="100%" GridLines="None" OnRowDataBound="grid_data_RowDataBound" OnPageIndexChanging="grid_data_PageIndexChanging" OnRowCommand="grid_data_RowCommand"
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
                                        <asp:LinkButton Text='<%# Eval("InoviceNum")%>' runat="server" ID="lbtn_invoicenumber" CommandArgument='<%# Eval("InoviceNum")%>' CommandName="Btn_EditCommand" Font-Underline="true" ForeColor="#0033cc" />
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="gridHeadStyle"
                                    ItemStyle-CssClass="table-avatar">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_PaymentType" Visible="false" runat="server" Text='<%# Eval("PaymentIntiationpage")%>'></asp:Label>
                                        <asp:Label ID="lbl_MembershipID" Visible="false" runat="server" Text='<%# Eval("MembershipID")%>'></asp:Label>
                                        <asp:Label ID="lbl_AdvocateName" runat="server" Text='<%# Eval("AdvocateName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile Number" HeaderStyle-CssClass="gridHeadStyle"
                                    ItemStyle-CssClass="table-avatar">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_MobileNumber" runat="server" Text='<%# Eval("MobileNumber")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email ID" HeaderStyle-CssClass="gridHeadStyle"
                                    ItemStyle-CssClass="table-avatar">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Email" runat="server" Text='<%# Eval("Email")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Membership Type Name" HeaderStyle-CssClass="gridHeadStyle"
                                    ItemStyle-CssClass="table-avatar">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_MembershipTypeName" runat="server" Text='<%# Eval("MembershipTypeName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="gridHeadStyle"
                                    ItemStyle-CssClass="table-avatar">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Amount" runat="server" Text='<%# Eval("Amount")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                        </asp:GridView>





                        <asp:GridView ID="Grd_StampsData" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                            Width="100%" GridLines="None" OnPageIndexChanging="Grd_StampsData_PageIndexChanging" OnRowCommand="Grd_StampsData_RowCommand"
                            EmptyDataText="No details" Visible="false">
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
                                        <asp:LinkButton Text='<%# Eval("InoviceNum")%>' runat="server" ID="lbtn_invoicenumber" CommandArgument='<%# Eval("InoviceNum")%>' CommandName="Btn_EditCommand" Font-Underline="true" ForeColor="#0033cc" />
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="gridHeadStyle"
                                    ItemStyle-CssClass="table-avatar">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_ID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                        <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile Number" HeaderStyle-CssClass="gridHeadStyle"
                                    ItemStyle-CssClass="table-avatar">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_MobileNumber" runat="server" Text='<%# Eval("MobileNumber")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" HeaderStyle-CssClass="gridHeadStyle"
                                    ItemStyle-CssClass="table-avatar">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Email" runat="server" Text='<%# Eval("Email")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number of Stamps" HeaderStyle-CssClass="gridHeadStyle"
                                    ItemStyle-CssClass="table-avatar">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Numberofstamps" runat="server" Text='<%# Eval("Numberofstamps")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Stamp Price" HeaderStyle-CssClass="gridHeadStyle"
                                    ItemStyle-CssClass="table-avatar">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_stampPrice" runat="server" Text='<%# Eval("stampPrice")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="gridHeadStyle"
                                    ItemStyle-CssClass="table-avatar">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Amount" runat="server" Text='<%# Eval("Amount")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                        </asp:GridView>
                    </table>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

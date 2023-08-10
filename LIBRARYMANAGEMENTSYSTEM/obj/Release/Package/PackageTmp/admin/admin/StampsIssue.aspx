<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="StampsIssue.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.StampsIssue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        <style > table#ContentPlaceHolder1_grid_data th.gridHeadStyle, tr td {
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

        .ch {
            padding-left: 10px;
            padding-right: 40px;
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
                    <div class="col-sm-12">
                        <h3 class="page-title">Membership Type</h3>

                    </div>
                </div>
            </div>
            <div class="row">

                <div class="col-lg-4">
                    <div class="form-group">
                        <label>Search Here</label>
                        <asp:TextBox runat="server" class="form-control" placeholder="Enter Invoice" ID="txt_search" OnTextChanged="txt_search_TextChanged" />
                        <cc1:AutoCompleteExtender ClientIDMode="Static" EnableCaching="false" ServiceMethod="SearchText" MinimumPrefixLength="1"
                            CompletionInterval="100" CompletionSetCount="10" TargetControlID="txt_search" ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                        </cc1:AutoCompleteExtender>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label>Stamp Type</label>
                        <asp:DropDownList runat="server" ID="ddl_Stamptype" class="form-control select">
                            <asp:ListItem Text="All" Value="0" />
                            <asp:ListItem Text="Welfare Stamps" Value="1" />
                            <asp:ListItem Text="Court Stamps" Value="2" />
                            <asp:ListItem Text="Non Judicial Stamps" Value="3" />
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label>Issue Type</label>
                        <asp:CheckBoxList runat="server" CssClass="checkbox ch" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Issued" Value="0" />
                            <asp:ListItem Text="Not Issued" Value="1" />
                        </asp:CheckBoxList>
                    </div>
                </div>


            </div>

            <div class="alert alert-success" id="div_success" runat="server" visible="false">
                <strong>Success!</strong>.
            </div>
            <div class="alert alert-danger" runat="server" visible="false" id="div_fail">
                <strong>fail!</strong>
            </div>

            <!-- /Page Header -->

            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body custom-edit-service">
                            <div class="service-fields mb-3">

                                <div class="table-responsive">
                                    <table class="table mb-0">
                                        <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                                            Width="100%" GridLines="None"
                                            EmptyDataText="No details" OnRowCommand="grid_data_RowCommand" OnPageIndexChanging="grid_data_PageIndexChanging">
                                            <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SINO">

                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Invoice Number">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_InoviceNum" runat="server" Text='<%# Eval("InoviceNum")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mobile Number">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_MobileNumber" runat="server" Text='<%# Eval("MobileNumber")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Stamp Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_StampType" runat="server" Text='<%# Eval("PaymentIntiationpage")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Number of stamps">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Numberofstamps" runat="server" Text='<%# Eval("Numberofstamps")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Stamp Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_stampPrice" runat="server" Text='<%# Eval("stampPrice")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Amount" runat="server" Text='<%# Eval("Amount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Payment Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_PaymentStatus" runat="server" Text='<%# Eval("PaymentStatus")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Issued Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_IssuedStatus" runat="server" Text='<%# Eval("IssuedStatus").ToString() == "0" ? "Pending" : "Issued" %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Status Change">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" CommandName="Btn_EditCommand" ID="btn_Edit" CommandArgument='<%# Eval("InoviceNum")%>'><asp:image imageurl="Images/edit.svg" runat="server" Height="20px" Width="20px" /></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </table>
                                </div>
                                <%--</div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>

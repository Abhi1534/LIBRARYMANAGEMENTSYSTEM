<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Features.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.Features" %>

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

        .rbl input[type="radio"] {
            /*margin-left: 10px;*/
            margin-right: 5px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">FEATURES</h3>

                    </div>
                </div>
            </div>

            <div class="row">

                <div class="col-lg-5">
                    <div class="form-group">
                        <asp:TextBox runat="server" class="form-control" placeholder="Search here" ID="txt_search" OnTextChanged="txt_search_TextChanged" AutoPostBack="true" />
                    </div>
                </div>
                <div class="col-lg-6" style="text-align: right">
                    <div class="form-group">
                        <asp:LinkButton runat="server" ID="btn_add" CssClass="btn btn-primary btn-sm" OnClick="btn_add_Click"><i class="fa fa-plus" aria-hidden="true"></i>  Add New</asp:LinkButton>

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12" style="text-align: right">
                    <div class="form-group">
                        <asp:LinkButton runat="server" ID="btn_back" CssClass="btn btn-primary btn-sm" OnClick="btn_back_Click" Visible="false"><i class="fa fa-solid fa fa-circle-left" aria-hidden="true"></i>Back</asp:LinkButton>
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
                                <asp:Panel runat="server" ID="pnl_entry" Visible="false">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Select Bank Account<span class="text-danger">*</span></label>
                                                <asp:Label ID="lblFeatureID" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:DropDownList runat="server" ID="ddlBankAccount" CssClass="custom-select" required="">
                                                </asp:DropDownList>
                                                <%-- <asp:RequiredFieldValidator ControlToValidate="ddlBankAccount" ErrorMessage="" runat="server" InitialValue="0" ValidationGroup="A" ForeColor="Red" />--%>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Feature Name<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txtFeatureName" required="" />
                                                <%-- <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="txtFeatureName" runat="server" ValidationGroup="A" />--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group row mb-0">
                                                <label class="col-form-label col-lg-4">Status</label>
                                                <div class="col-lg-10">
                                                    <div class="input-group">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"></span>
                                                        </div>

                                                        <asp:RadioButtonList runat="server" ID="rbtnActive" RepeatDirection="Horizontal" BorderStyle="None" Width="300px" CssClass="rbl">
                                                            <asp:ListItem Text="Active" />
                                                            <asp:ListItem Text="InActive" />
                                                        </asp:RadioButtonList>

                                                        <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="rbtnActive" runat="server" ValidationGroup="A" ForeColor="Red" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group row mb-0">
                                                <label class="col-form-label col-lg-4">Feature type</label>
                                                <div class="col-lg-10">
                                                    <div class="input-group">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"></span>
                                                        </div>
                                                        <asp:RadioButtonList runat="server" ID="rbtnSingle" RepeatDirection="Horizontal" BorderStyle="None" Width="300px" OnSelectedIndexChanged="rbtnSingle_SelectedIndexChanged" AutoPostBack="true" CssClass="rbl" re>
                                                            <asp:ListItem Text="Single" />
                                                            <asp:ListItem Text="Multiple" />
                                                        </asp:RadioButtonList>
                                                        <%-- <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="rbtnSingle" runat="server" ValidationGroup="A" />--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <br />
                                    <div class="row">
                                        <div id="divSingle" runat="server" visible="false" class="col-lg-12">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Value<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txtSingleValue" required="" />
                                                    <%-- <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="rbtnSingle" runat="server" ValidationGroup="A" />--%>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">

                                        <div id="divMultiple" runat="server" visible="false" class="col-lg-12">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Option(use Comma Separator like 1,2,3)<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txtMultiOptions" required="" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Values(use Comma Separator like 10,20,30)<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txtMultiValues" required="" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <div class="submit-section">
                                                <asp:Button Text="Submit" runat="server" class="btn btn-primary submit-btn" ID="btn_submit" OnClick="btn_submit_Click" ValidationGroup="A" />

                                                <%--   <asp:Button Text="Cancel" runat="server" class="btn btn-primary submit-btn" ID="btn_Cancel" OnClick="btn_Cancel_Click" />--%>
                                            </div>

                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnl_view" Visible="true">
                                    <!-- Recent Orders -->
                                    <div class="card-body">
                                        <div class="table-responsive">
                                            <table class="table mb-0">
                                                <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                                                    Width="100%" GridLines="None" OnRowCommand="grid_data_RowCommand"
                                                    EmptyDataText="No details">
                                                    <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SINO" HeaderStyle-CssClass="gridHeadStyle"
                                                            ItemStyle-CssClass="table-avatar">

                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Feature Name" HeaderStyle-CssClass="gridHeadStyle"
                                                            ItemStyle-CssClass="table-avatar">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_FeatureID" Visible="false" runat="server" Text='<%# Eval("FeatureID")%>'></asp:Label>
                                                                <asp:Label ID="lbl_FeatureName" runat="server" Text='<%# Eval("FeatureName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Account No" HeaderStyle-CssClass="gridHeadStyle"
                                                            ItemStyle-CssClass="table-avatar">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_AccountNo" runat="server" Text='<%# Eval("AccountName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Feature Type" HeaderStyle-CssClass="gridHeadStyle"
                                                            ItemStyle-CssClass="table-avatar">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_FeatureType" runat="server" Text='<%# Eval("FeatureType").ToString() == "1" ? "Single" : "Multiple" %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Options" HeaderStyle-CssClass="gridHeadStyle"
                                                            ItemStyle-CssClass="table-avatar">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Options" runat="server" Text='<%# Eval("Options")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Values" HeaderStyle-CssClass="gridHeadStyle"
                                                            ItemStyle-CssClass="table-avatar">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_FeatureValues" runat="server" Text='<%# Eval("FeatureValues")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="gridHeadStyle"
                                                            ItemStyle-CssClass="table-avatar">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_status" runat="server" Text='<%# Eval("IsActive").ToString() == "1" ? "Active" : "InActive" %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="gridHeadStyle"
                                                            ItemStyle-CssClass="table-avatar">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" CommandName="Btn_EditCommand" CommandArgument="<%# Container.DataItemIndex %>" ID="btn_Edit"><asp:image imageurl="Images/edit-247.svg" runat="server" Height="30px" Width="30px"  /></asp:LinkButton>
                                                                <%--  <asp:LinkButton runat="server" CommandName="Btn_DeleteCommand" CommandArgument="<%# Container.DataItemIndex %>" ID="btn_Delete"><asp:image imageurl="Images/Delete.svg" runat="server" Height="45px" Width="45px"/></asp:LinkButton>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </table>
                                        </div>
                                    </div>

                                </asp:Panel>
                            </div>

                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>

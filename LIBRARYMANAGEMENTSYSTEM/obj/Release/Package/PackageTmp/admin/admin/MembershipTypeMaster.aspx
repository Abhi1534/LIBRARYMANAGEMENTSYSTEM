<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="MembershipTypeMaster.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.MembershipTypeMaster" %>

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
        table#ContentPlaceHolder1_grid_data th {
    background: #cdcdcd;
    padding: 11px 2px;
    text-align: center;
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

                <div class="col-lg-5">
                    <div class="form-group">
                        <asp:TextBox runat="server" class="form-control" placeholder="Search here" ID="txt_search" OnTextChanged="txt_search_TextChanged" />
                        <cc1:AutoCompleteExtender ClientIDMode="Static" EnableCaching="false" ServiceMethod="SearchText" MinimumPrefixLength="1"
                            CompletionInterval="100" CompletionSetCount="10" TargetControlID="txt_search" ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                        </cc1:AutoCompleteExtender>
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
                                                <label>Membership Type Name<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_membershiptypename"  />

                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Subscription Amount<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" onblur="Sum(this);" CausesValidation="True" ID="txt_SubscriptionAmount"  />

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Entrance Fee<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" onblur="Sum(this);" CausesValidation="True" ID="txt_EntranceFee" />

                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Identity Card Fee<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_identitycardfee" onblur="Sum(this);" CausesValidation="True"  />

                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Application Form Fee<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_ApplicationFormFee" onblur="Sum(this);" CausesValidation="True" />

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Miscellaneous Fee<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_Miscellaneousfee" onblur="Sum(this);" CausesValidation="True" />

                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Entry Identity Card Fee<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_EntryIdentitycard" onblur="Sum(this);" CausesValidation="True" />

                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Total Fee<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_totalfee" ReadOnly="true" CausesValidation="True" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>Description<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_description" TextMode="MultiLine" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="submit-section">
                                        <asp:Button Text="Submit" runat="server" class="btn btn-primary submit-btn" ID="btn_submit" OnClick="btn_submit_Click" />

                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnl_view" Visible="true">
                                    <!-- Recent Orders -->
                                    <%--<div class="card-body">--%>
                                    <div class="table-responsive">
                                        <table class="table mb-0">
                                            <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                                                Width="100%" GridLines="None"
                                                EmptyDataText="No details" OnRowCommand="grid_data_RowCommand">
                                                <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SINO">

                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Membership ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_MemID" runat="server" Text='<%# Eval("MemID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Membership Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_MembershipName" runat="server" Text='<%# Eval("MembershipTypeName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Subscription Fee">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Subscription" runat="server" Text='<%# Eval("Subscription")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Entrance Fee">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_EntranceFee" runat="server" Text='<%# Eval("EntranceFee")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Identity Card Fee">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_IdentityCard" runat="server" Text='<%# Eval("IdentityCard")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Application Form Fee">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_ApplicationForm" runat="server" Text='<%# Eval("ApplicationForm")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Miscellaneous Fee">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Miscellaneous" runat="server" Text='<%# Eval("Miscellaneous")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Entry Identity Card Fee">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_EntryIdentityCard" runat="server" Text='<%# Eval("EntryIdentityCard")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Total Fee">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_totalfee" runat="server" Text='<%# Eval("totalfee")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" CommandName="Btn_EditCommand" ID="btn_Edit" CommandArgument='<%# Eval("MemID")%>'><asp:image imageurl="Images/edit.svg" runat="server" Height="20px" Width="20px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </table>
                                    </div>
                                    <%--</div>--%>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>
  
</asp:Content>

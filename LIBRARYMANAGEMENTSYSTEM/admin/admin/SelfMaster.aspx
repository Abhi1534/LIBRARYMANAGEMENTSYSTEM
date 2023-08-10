<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SelfMaster.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.SelfMaster" %>
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
                        <h3 class="page-title">Self Master</h3>

                    </div>
                </div>
            </div>
            <!-- /Page Header -->
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

            <br />
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body custom-edit-service">
                            <div class="service-fields mb-3">
                                <asp:Panel runat="server" ID="pnl_entry" Visible="false">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Section Name<span class="text-danger">*</span></label>
                                                <asp:DropDownList runat="server" class="form-control select" ID="ddl_sectionname" OnSelectedIndexChanged="ddl_sectionname_SelectedIndexChanged" AutoPostBack="true" ValidationGroup="A">
                                                </asp:DropDownList>

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Rack Name<span class="text-danger">*</span></label>
                                                <asp:DropDownList runat="server" class="form-control select" ID="ddl_RackName" OnSelectedIndexChanged="ddl_RackName_SelectedIndexChanged" AutoPostBack="true" ValidationGroup="A">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Selfs<span class="text-danger">*</span></label>
                                                <asp:DropDownList runat="server" class="form-control select" ID="ddl_NoOfSelfs"  ValidationGroup="A">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Number of Books in self<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_numberofbooksinself" ValidationGroup="A" />
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">

                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>Description<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_description" TextMode="MultiLine" ValidationGroup="A"/>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="submit-section">
                                        <asp:Button class="btn btn-primary submit-btn" Text="Submit" runat="server" ID="btn_submit" OnClick="btn_submit_Click" ValidationGroup="A"/>

                                    </div>
                                </asp:Panel>
                                 <asp:Panel runat="server" ID="pnl_view" Visible="true">
                                    <!-- Recent Orders -->
                                 <%--   <div class="card">--%>
                                        <div class="card-body">
                                            <div class="table-responsive">

                                                <table class="datatable table table-hover table-center mb-0">
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

                                                             <asp:TemplateField HeaderText="Self ID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Selfid" runat="server" Text='<%# Eval("SelMID")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Section Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_SectionName" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                             <asp:TemplateField HeaderText="Rack Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_RackName" runat="server" Text='<%# Eval("RackName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                             <asp:TemplateField HeaderText="Self Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_NoOfSelfs" runat="server" Text='<%# Eval("NoOfSelfs")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                              <asp:TemplateField HeaderText="Number Of Books In Self">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_NoOfBooksInself" runat="server" Text='<%# Eval("NoOfBooksInself")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                           <%-- <asp:TemplateField HeaderText="Action">
                                                                <ItemTemplate>
                                                                      <asp:LinkButton runat="server" CommandName="Btn_EditCommand" ID="btn_Edit" CommandArgument='<%# Eval("SelMID")%>'><asp:image imageurl="Images/edit.svg" runat="server" Height="20px" Width="20px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </table>
                                            </div>
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

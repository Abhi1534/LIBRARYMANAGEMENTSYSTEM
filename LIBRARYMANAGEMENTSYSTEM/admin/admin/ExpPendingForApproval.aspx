<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="ExpPendingForApproval.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.ExpPendingForApproval" %>
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


        .zoom {
            transition: transform .2s;
            width: 300px;
            height: 300px;
        }

            .zoom:hover {
                -ms-transform: scale(1.5); /* IE 9 */
                -webkit-transform: scale(1.5); /* Safari 3-8 */
                transform: scale(5.1);
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
                        <h3 class="page-title">Approval Expenses</h3>

                    </div>
                </div>
            </div>



            <div class="row">

                <div class="col-lg-5">
                    <div class="form-group">
                        <asp:TextBox runat="server" class="form-control" placeholder="Search here" ID="txt_search" AutoPostBack="true" OnTextChanged="txt_search_TextChanged" />
                    </div>
                </div>
                <%--<div class="col-lg-6" style="text-align: right">
                    <div class="form-group">
                        <asp:LinkButton runat="server" ID="btn_add" CssClass="btn btn-primary btn-sm" OnClick="btn_add_Click"><i class="fa fa-plus" aria-hidden="true"></i>  Add New</asp:LinkButton>

                    </div>
                </div>--%>
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
 <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body custom-edit-service">

            <asp:Panel runat="server" ID="pnl_entry" Visible="false">


                <div class="row">
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Expense Name<span class="text-danger">*</span></label>
                            <asp:Label ID="lblExpID" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtExpenseName" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Amount<span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtAmount" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Description<span class="text-danger"></span></label>
                            <asp:TextBox ID="txtDescription" class="form-control" runat="server" ReadOnly="true" ></asp:TextBox>
                            
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Bill Date<span class="text-danger"></span></label>
                            <asp:TextBox ID="txtBillDate" class="form-control" runat="server" ReadOnly="true" TextMode="Date"></asp:TextBox>
                           
                        </div>
                    </div>
                     <div class="col-lg-4">
                        <div class="form-group">
                            <label>Secretary Approved Amount<span class="text-danger"></span></label>
                            <asp:TextBox ID="txtSecretaryApprovedAmount" class="form-control" TextMode="Number" runat="server"  ></asp:TextBox>
                            
                        </div>
                    </div>
                     <div class="col-lg-4">
                        <div class="form-group">
                            <label>Treasury Approved Amount<span class="text-danger"></span></label>
                            <asp:TextBox ID="txtTreasuryApprovedAmount" class="form-control" TextMode="Number" runat="server" ></asp:TextBox>
                            
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Secretary Remarks<span class="text-danger"></span></label>
                            <asp:TextBox ID="txtSecretaryRemarks" class="form-control" runat="server" ></asp:TextBox>
                            
                        </div>
                    </div>
                     <div class="col-lg-4">
                        <div class="form-group">
                            <label>Treasury Remarks<span class="text-danger"></span></label>
                            <asp:TextBox ID="txtTreasuryRemarks" class="form-control" runat="server"  ></asp:TextBox>
                            
                        </div>
                    </div>
                </div>

              

                <div class="submit-section">
                    <div class="col-lg-12">
                        <div class="submit-section">
                            <asp:Button runat="server" ID="btnSave" Text="Save" class="btn btn-primary submit-btn" OnClick="btnSave_Click" ValidationGroup="A" />
                         &nbsp;&nbsp;&nbsp;  <%--<button class="btn btn-primary submit-btn" type="submit" name="form_submit" value="submit">Submit</button>--%>
                       <%-- </div>
                    </div>
                     <div class="col-lg-6">
                        <div class="submit-section">--%>
                            <asp:Button runat="server" ID="btnReject" Text="Reject" class="btn btn-primary submit-btn" OnClick="btnReject_Click" ValidationGroup="A" />
                            <%--<button class="btn btn-primary submit-btn" type="submit" name="form_submit" value="submit">Submit</button>--%>
                        </div>
                    </div>
                </div>
            </asp:Panel>


            <asp:Panel runat="server" ID="pnl_view" Visible="true">
                <!-- Recent Orders -->
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table mb-0">
                            <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="2" AllowSorting="true"
                                Width="100%" GridLines="None" OnRowDataBound="grid_data_RowDataBound"  OnPageIndexChanging="grid_data_PageIndexChanging" OnRowCommand="grid_data_RowCommand"
                                EmptyDataText="No details">
                                <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SINO" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">

                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="gridHeadStyle" 
                                        ItemStyle-CssClass="table-avatar" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ExpenseName" runat="server" Text='<%# Eval("ExpenseName")%>'></asp:Label>
                                           </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Expense Name" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar" >
                                        <ItemTemplate> 
                                              <asp:Label ID="lbl_ExpID" Visible="false" runat="server" Text='<%# Eval("ExpID")%>'></asp:Label>
                                            <asp:Label ID="lbl_Description" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bill Date" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_BillDate" runat="server" Text='<%# Eval("BillDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Amount" runat="server" Text='<%# Eval("Amount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <%--<asp:TemplateField HeaderText="Approved Amount" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ApprovedAmount" runat="server" Text='<%# Eval("ApprovedAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                   <asp:TemplateField HeaderText="Secretary Approved Amount" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SecretaryApprovedAmount" runat="server" Text='<%# Eval("SecretaryApprovedAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Treasury Approved Amount" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_TreasuryApprovedAmount" runat="server" Text='<%# Eval("TreasuryApprovedAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                      <asp:TemplateField HeaderText="Secretary Approved" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SecretaryApproved" runat="server" Text='<%# Eval("SecretaryApproved")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Treasury Approved" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_TreasuryApproved" runat="server" Text='<%# Eval("TreasuryApproved")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>

                                            <asp:LinkButton runat="server" CommandName="Btn_EditCommand" CommandArgument="<%# Container.DataItemIndex %>" ID="btn_Edit"><asp:image imageurl="Images/edit.svg" runat="server" Height="20px" Width="20px" /></asp:LinkButton>
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
</asp:Content>
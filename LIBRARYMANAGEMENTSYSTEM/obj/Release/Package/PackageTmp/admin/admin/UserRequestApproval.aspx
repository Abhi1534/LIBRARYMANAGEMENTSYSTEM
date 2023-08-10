<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="UserRequestApproval.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.UserRequestApproval" %>
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
                        <h3 class="page-title">Approval Users Request</h3>

                    </div>
                </div>
            </div>



            <div class="row">

                <div class="col-lg-5">
                    <div class="form-group">
                        <asp:TextBox runat="server" class="form-control" placeholder="Search here" ID="txt_search" AutoPostBack="true" OnTextChanged="txt_search_TextChanged" />
                    </div>
                </div>

                <div class="col-lg-5">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlServiceName"  class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlServiceName_SelectedIndexChanged">
                            <asp:ListItem Text="Please Select DrviceName" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Car" Value="Car"></asp:ListItem>
                            <asp:ListItem Text="ID Card" Value="ID Card"></asp:ListItem>
                            <asp:ListItem Text="Proxymetri card" Value="Proxymetri card"></asp:ListItem>
                            <asp:ListItem Text="Practice Certificate" Value="Practice Certificate"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="col-lg-5">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlStatus"  class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                            <asp:ListItem Text="Please Select Status" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dispatched" Value="Dispatched"></asp:ListItem>
                            <asp:ListItem Text="Waiting for Dispatch" Value="Pending"></asp:ListItem>
                        </asp:DropDownList>
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
                            <label>Courier Name<span class="text-danger">*</span></label>
                            <asp:Label ID="lblSerID" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtCourierName" class="form-control" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Courier No<span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtCourierNo" class="form-control" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Service Name <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtServiceName" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Member Name<span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtMemberName" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Mobile Number<span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtMobileNumber" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Amount<span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtAmount" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    
                </div>

              

                <div class="submit-section">
                    <div class="col-lg-12">
                        <div class="submit-section">
                            <asp:Button runat="server" ID="btnSave" Text="Save" class="btn btn-primary submit-btn" OnClick="btnSave_Click" ValidationGroup="A" />
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
                                    <asp:TemplateField HeaderText="ServiceName" HeaderStyle-CssClass="gridHeadStyle" 
                                        ItemStyle-CssClass="table-avatar" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ServiceName" runat="server" Text='<%# Eval("ServiceName")%>'></asp:Label>
                                           </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Name" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar" >
                                        <ItemTemplate> 
                                              <asp:Label ID="lbl_SerID" Visible="false" runat="server" Text='<%# Eval("SerID")%>'></asp:Label>
                                            <asp:Label ID="lbl_MemberName" runat="server" Text='<%# Eval("MemberName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile Number" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_MobileNumber" runat="server" Text='<%# Eval("MobileNumber")%>'></asp:Label>
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
                                   <asp:TemplateField HeaderText="Delivery Status" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_DeliveryStatus" runat="server" Text='<%# Eval("DeliveryStatus")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Courier Reference Number" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_CourierRefNumber" runat="server" Text='<%# Eval("CourierRefNumber")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                      <asp:TemplateField HeaderText="CourierName" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_CourierName" runat="server" Text='<%# Eval("CourierName")%>'></asp:Label>
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

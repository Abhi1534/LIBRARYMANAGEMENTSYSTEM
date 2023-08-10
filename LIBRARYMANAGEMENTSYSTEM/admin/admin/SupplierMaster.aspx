<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="SupplierMaster.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.SupplierMaster" %>
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
    <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">Supplier Master</h3>

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
                                            <label>Supplier Name<span class="text-danger">*</span></label>
                                            <asp:Label ID="lblSupID" runat="server" Text="" Visible="false"></asp:Label>
                                              <asp:TextBox runat="server" class="form-control" ID="txtSupName" required="" />
                                        </div>
                                    </div> 
                                     <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Mobile<span class="text-danger">*</span></label>
                                              <asp:TextBox runat="server" class="form-control" ID="txtMobile" required="" />
                                        </div>
                                    </div>                                    
                                          <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Phone<span class="text-danger">*</span></label>
                                              <asp:TextBox runat="server" class="form-control" ID="txtphone" required="" />
                                        </div>
                                    </div>
                                     <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Email<span class="text-danger">*</span></label>
                                              <asp:TextBox runat="server" class="form-control" ID="txtEmail" required="" />
                                        </div>
                                    </div>
                                     <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Country<span class="text-danger">*</span></label>
                                              <asp:TextBox runat="server" class="form-control" ID="txtCountry" required="" />
                                        </div>
                                    </div>
                                     <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>State<span class="text-danger">*</span></label>
                                              <asp:TextBox runat="server" class="form-control" ID="txtState" required="" />
                                        </div>
                                    </div>                                    
                                     <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>City<span class="text-danger">*</span></label>
                                              <asp:TextBox runat="server" class="form-control" ID="txtCity" required="" />
                                        </div>
                                    </div> 
                                     <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Address<span class="text-danger">*</span></label>
                                              <asp:TextBox runat="server" class="form-control" ID="txtAddress" required="" />
                                        </div>
                                    </div>   
                                    
                                     <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Pan<span class="text-danger">*</span></label>
                                              <asp:TextBox runat="server" class="form-control" ID="txtpan" required="" />
                                        </div>
                                    </div>
                                     <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>GSTIN<span class="text-danger">*</span></label>
                                              <asp:TextBox runat="server" class="form-control" ID="txtGSTIN" required="" />
                                        </div>
                                    </div>
                                     <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>CIN<span class="text-danger">*</span></label>
                                              <asp:TextBox runat="server" class="form-control" ID="txtCIN"  required="" />
                                        </div>
                                    </div>
                                                      
                                </div>
                                <div class="row">

                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label>Description<span class="text-danger"></span></label>
                                            <asp:TextBox runat="server" class="form-control" Width="40%" ID="txtdescription"  />
                                        </div>
                                    </div>
                                </div>
                                 <div class="row">
                                 <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:CheckBox runat="server"  ID="chkActive"  />
                                             <label>Active<span class="text-danger"></span></label>
                                             
                                        </div>
                                    </div>    
                                     </div>
                                <div class="submit-section">
                                    <asp:Button Text="Submit" runat="server" class="btn btn-primary submit-btn" ID="btn_submit" OnClick="btn_submit_Click" />
                                    
                                </div>
                                     </asp:Panel>
                                 <asp:Panel runat="server" ID="pnl_view" Visible="true">
                                <!-- Recent Orders -->
                                <div class="card-body">
                                    <div class="table-responsive">
                                        <table class="table mb-0">
                                            <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                                                Width="100%" GridLines="None" OnRowCommand="grid_data_RowCommand" OnPageIndexChanging="grid_data_PageIndexChanging"
                                                EmptyDataText="No details">
                                                <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SINO" HeaderStyle-CssClass="gridHeadStyle"
                                                        ItemStyle-CssClass="table-avatar">

                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Supplier Name" HeaderStyle-CssClass="gridHeadStyle"
                                                        ItemStyle-CssClass="table-avatar">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSupplierID" Visible="false" runat="server" Text='<%# Eval("SupID")%>'></asp:Label>
                                                            <asp:Label ID="lbl_SupName" runat="server" Text='<%# Eval("SupplierName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile No" HeaderStyle-CssClass="gridHeadStyle"
                                                        ItemStyle-CssClass="table-avatar">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Moobile" runat="server" Text='<%# Eval("Mobile")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email ID" HeaderStyle-CssClass="gridHeadStyle"
                                                        ItemStyle-CssClass="table-avatar">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Email" runat="server" Text='<%# Eval("Email")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="GSTIN" HeaderStyle-CssClass="gridHeadStyle"
                                                        ItemStyle-CssClass="table-avatar">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_GSTIN" runat="server" Text='<%# Eval("GSTIN")%>'></asp:Label>
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
    </div>
</asp:Content>

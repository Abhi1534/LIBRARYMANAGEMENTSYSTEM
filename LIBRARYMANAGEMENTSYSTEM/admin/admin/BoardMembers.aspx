<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="BoardMembers.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.BoardMembers" %>
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
                        <h3 class="page-title">Board Members</h3>

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

            <asp:Panel runat="server" ID="pnl_entry" Visible="false">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-body custom-edit-service">
                                <div class="service-fields mb-3">
                                    <div class="row">
                                      
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Name<span class="text-danger">*</span></label>
                                <asp:Label ID="lblMemberID" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:TextBox ID="txtName" class="form-control"  runat="server" required=""></asp:TextBox>
                                                <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="txtName" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="A" />

                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Designation<span class="text-danger">*</span></label>
                                                 <asp:TextBox ID="txtDesignation" class="form-control"  runat="server" required=""></asp:TextBox>
                                                <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="txtDesignation" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="A" />
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Mobile No<span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtMobileNo" class="form-control" runat="server" required=""></asp:TextBox>
                                                <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="txtMobileNo" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="A" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Email</label>
                                                <asp:TextBox ID="txtEmail" class="form-control" runat="server" required=""></asp:TextBox>
                                                <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="txtEmail" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="A" />
                                                
                                            </div>
                                        </div>


                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Address<span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtAddress" class="form-control" runat="server" required=""></asp:TextBox>
                                                <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="txtAddress" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="A" />
                                            </div>
                                        </div>
                                     
                 
                                    </div>
                                     <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Photo<span class="text-danger">*</span></label>
                                            </div>

                                            <asp:Image runat="server" ID="imgwardphoto" AlternateText="Book Cover" Width="100" Visible="false"
                                                Height="100" BorderWidth="2px" CssClass="zoom" />
                                            <asp:FileUpload ID="ctrlphotoupload" runat="server" Width="50%" CssClass="txtbox"
                                                EnableViewState="true" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="btnphotoupload" Text="Upload" OnClick="btnphotoupload_Click"
                            CausesValidation="false" />
                                            <asp:Label runat="server" ID="lbluploadwardphoto" Text="" />
                                            <asp:LinkButton runat="server" ID="lnk_removeward" Text="Remove" OnClick="lnk_removeward_Click"
                                                Visible="false" CausesValidation="false" />
                                            <asp:HiddenField ID="ctrlphotouploadfilename" runat="server" Value="" />
                                        </div>
                                    </div>
                                    
                                    
                                </div>
                                <br />
                                <br />

                              
                                <div class="submit-section">
                                    <div class="col-lg-12">
                                        <div class="submit-section">
                                            <asp:Button runat="server" ID="btnSave" Text="Save" class="btn btn-primary submit-btn" OnClick="btnSave_Click" ValidationGroup="A" />
                                        </div>
                                    </div>
                                </div>


                            </div>
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
                                    <asp:TemplateField HeaderText="Member Name" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_MemberID" Visible="false" runat="server" Text='<%# Eval("BoardOfMemberID")%>'></asp:Label>
                                            <asp:Label ID="lbl_MemberName" runat="server" Text='<%# Eval("MemberName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Designation" runat="server" Text='<%# Eval("Designation")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile No" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_MobileNo" runat="server" Text='<%# Eval("MobileNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email ID" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_EmailID" runat="server" Text='<%# Eval("EmailID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Address" runat="server" Text='<%# Eval("Address")%>'></asp:Label>
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

    <asp:Panel ID="pnlPopUp" runat="server" Visible="false">

        <%--<div class="modal fade" id="delete_modal"   role="dialog">--%>
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <!--	<div class="modal-header">
							<h5 class="modal-title">Delete</h5>
							<button type="button" class="close" data-dismiss="modal" aria-label="Close">
								<span aria-hidden="true">&times;</span>
							</button>
						</div>-->
                <div class="modal-body">
                    <div class="form-content p-2">
                        <h4 class="modal-title">Successfull</h4>
                        <asp:Label class="mb-4" ID="lblMessage" Text="" runat="server"></asp:Label>

                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <%--</div>--%>
    </asp:Panel>
</asp:Content>

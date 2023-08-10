<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="BookIssue.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.BookIssue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridHeadStyle {
            border-bottom: 1px solid #dee2e6;
        }

        .table-avatar {
            border-bottom: 1px solid #dee2e6;
        }
        /*border-top: 1px solid #dee2e6;*/
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
                        <h3 class="page-title">Book Issue</h3>

                    </div>
                </div>
            </div>
            <div class="alert alert-success" id="div_success" runat="server" visible="false">
                <strong>Success!</strong>.
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body custom-edit-service">
                            <div class="service-fields mb-3">
                                <div class="divEntry" runat="server" style="overflow: auto">
                                    <asp:Panel runat="server" ID="pnlLeftDetails">
                                        <div class="card-body custom-edit-service">

                                            <div class="service-fields mb-3">
                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Book Serial<span class="text-danger">*</span></label>
                                                            <asp:TextBox runat="server" class="form-control" placeholder="Search here" ID="txt_search" OnTextChanged="txt_search_TextChanged" AutoPostBack="true" />
                                                            <cc1:AutoCompleteExtender ClientIDMode="Static" EnableCaching="false" ServiceMethod="SearchText" MinimumPrefixLength="1"
                                                                CompletionInterval="100" CompletionSetCount="10" TargetControlID="txt_search" ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                                            </cc1:AutoCompleteExtender>
                                                        </div>
                                                    </div>
                                                   <%-- <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Book Name<span class="text-danger">*</span></label>--%>

                                                            <%--<asp:Label runat="server" ID="lblBookType" Text="Book Type" class="form_controlLabel"></asp:Label>--%>
                                                          <%--  <asp:DropDownList runat="server" ID="ddlBookName" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged">
                                                            </asp:DropDownList>--%>
                                                       <%-- </div>
                                                    </div>--%>
                                                      <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Book Name<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txt_BookName" class="form-control" runat="server" ReadOnly="true" required=""></asp:TextBox><br />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Author Name<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtAuthor" class="form-control" runat="server" ReadOnly="true" required=""></asp:TextBox><br />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Price<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtPrice" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Available Books<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtAvailableBooks" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>



                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>No. Of Books<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtNoOfbooks" class="form-control" runat="server" AutoPostBack="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Date Of Issue<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtissueDate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>MemberShip MobileNumber<span class="text-danger">*</span></label>
                                                            <asp:Label runat="server" ID="lblMemberID" Visible="false" class="form_controlLabel"></asp:Label>
                                                            <asp:TextBox ID="txtMemberShipMobileNo" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtMemberShipMobileNo_TextChanged"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>MemberShip Name<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txt_membershipname" class="form-control" runat="server" ReadOnly="true" required=""></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <%-- <label>Issued By<span class="text-danger">*</span></label>--%>
                                                            <asp:TextBox ID="txtIssuedBy" class="form-control" runat="server" Visible="false" required=""></asp:TextBox>
                                                        </div>
                                                    </div>


                                                </div>
                                                <div class="submit-section">
                                                    <div class="col-lg-12">
                                                        <div class="form-group">
                                                            <div class="submit-section">
                                                                <asp:Button ID="btnSubmit" class="btn btn-primary submit-btn" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>
                                        </div>
                                    </asp:Panel>



                                </div>


                                <div class="row">
                                    <div class="col-md-12">

                                        <!-- Recent Orders -->
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="table-responsive">

                                                    <table class="datatable table table-hover table-center mb-0">
                                                        <asp:GridView ID="gdvBookIssues" Visible="false" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                                                            Width="100%" GridLines="None"
                                                            EmptyDataText="No details">
                                                            <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Book Name" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">

                                                                    <ItemTemplate>
                                                                        <a href="profile.html" class="avatar avatar-sm mr-2">
                                                                            <img class="avatar-img rounded-circle" src="assets/img/doctors/doctor-thumb-01.jpg" alt="User Image"></a>

                                                                        </a><asp:Label ID="lblBookID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BookID")%>'> </asp:Label>
                                                                        <asp:Label ID="lblBookName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BookName")%>'> </asp:Label></a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Book Author" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">
                                                                    <ItemTemplate>

                                                                        <a href="profile.html" class="avatar avatar-sm mr-2">
                                                                            <img class="avatar-img rounded-circle" src="assets/img/doctors/doctor-thumb-01.jpg" alt="User Image"></a>

                                                                        <asp:Label ID="lblBookAuthor" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AuthorName")%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Issue Date" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblissueDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DateOfIssue")%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Issued By" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIssuedBy" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"IssuedBy")%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="No Of books" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNoOfbooks" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"NoOfbooks")%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Price" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPrice" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Price")%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                              <%--  <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Amount")%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">
                                                                    <ItemTemplate>
                                                                        <asp:Button class="btn btn-primary submit-btn" ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                            </Columns>
                                                        </asp:GridView>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12" style="text-align: right; padding-right: 10%;">

                                        <!-- Recent Orders -->

                                        <%-- <asp:Label ID="lblTotalAmt" runat="server" Text=" Total Amount : " Visible="false" Font-Size="25px"></asp:Label>
                                        <asp:Label ID="lblTotalAmount" Font-Bold="true" Font-Size="25px"  Visible="false" runat="server" Text=""></asp:Label>--%>
                                    </div>
                                </div>
                                <div class="submit-section">
                                    <div class="col-lg-12">
                                        <div class="submit-section">
                                            <asp:Button class="btn btn-primary submit-btn" Visible="false" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="PendingForApproval.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.PendingForApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table#ContentPlaceHolder1_gdvPendigList th.gridHeadStyle, tr td {
            border: 1px solid #dee2e6;
            padding: 10px;
            text-align: center;
        }

        th.gridHeadStyle {
            background: #cdcdcd;
        }

        table#ContentPlaceHolder1_gdvPendigList th {
            background: #cdcdcd;
            padding: 11px 2px;
            text-align: center;
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

        .chkChoice input {
            margin-left: 10px;
            margin-right: 5px;
        }

        .myCheckBoxList label {
            padding-right: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page Wrapper -->
    <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">Pending List</h3>

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5">
                    <asp:TextBox ID="txtSearch" class="form-control" placeholder="Search here" runat="server" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>

                    <br />
                </div>

            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body custom-edit-service">
                            <div class="service-fields mb-3">
                                <asp:Panel runat="server" ID="pnl_entry" Visible="false">
                                    <div class="service-fields mb-3">
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Advocate Name<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_Advocatename" ReadOnly="true" />

                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Gender<span class="text-danger">*</span></label>
                                                    <asp:DropDownList runat="server" class="form-control select" ID="ddl_gender" ReadOnly="true">
                                                        <asp:ListItem Text="Male" />
                                                        <asp:ListItem Text="Female" />
                                                        <asp:ListItem Text="Other" />
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Mobile Number<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_MobileNumber" ReadOnly="true" />

                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Mobile Number 2<span class="text-danger">(Optional)</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_mobilenumber2" ReadOnly="true" />

                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Phone Number<span class="text-danger">(Optional)</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_phonenumber" ReadOnly="true" />

                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Address<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_address" ReadOnly="true" />

                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>State<span class="text-danger">*</span></label>
                                                    <asp:DropDownList runat="server" class="form-control select" ID="ddl_state" ReadOnly="true">
                                                        <asp:ListItem Text="Telengana" />

                                                    </asp:DropDownList>

                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Email<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_email" ReadOnly="true" />

                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>DOB<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_dob" TextMode="Date" ReadOnly="true" />

                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Blood Group<span class="text-danger">*</span></label>
                                                    <asp:DropDownList runat="server" class="form-control select" ID="ddl_Bloodgroup" ReadOnly="true">
                                                        <asp:ListItem Text="A+" />
                                                        <asp:ListItem Text="A-" />
                                                        <asp:ListItem Text="B+" />
                                                        <asp:ListItem Text="B-" />
                                                        <asp:ListItem Text="O+" />
                                                        <asp:ListItem Text="O-" />
                                                        <asp:ListItem Text="AB+" />
                                                        <asp:ListItem Text="AB-" />
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Enrollment Number<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_enrollmentnumber" ReadOnly="true" />

                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Enrollment Date<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_enrollmentdate" TextMode="Date" ReadOnly="true" />

                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Membership Type<span class="text-danger">*</span></label>
                                                    <asp:DropDownList runat="server" class="form-control select" ID="ddl_MemberShipType" ReadOnly="true">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Membership Date<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_membershipdate" ReadOnly="true" TextMode="Date" />

                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Membership Fee<span class="text-danger"></span></label>&nbsp
                                                <asp:Image ImageUrl="Images/info.svg" runat="server" Height="15px" ID="imgreview"></asp:Image>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_membershipfee" ReadOnly="true" required="" />


                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Vehicle Number<span class="text-danger"></span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txt_vehiclenumber" ReadOnly="true" />

                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Vote<span class="text-danger">*</span></label>
                                                    <asp:DropDownList runat="server" class="form-control select" ID="ddl_vote" ReadOnly="true">
                                                        <asp:ListItem Text="YES" />
                                                        <asp:ListItem Text="NO" />
                                                    </asp:DropDownList>

                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                    <div id="div_feedeatils" runat="server" visible="false">
                                        <asp:Label ID="lbl_subfee" runat="server" />
                                        <asp:Label ID="lbl_entreefee" runat="server" />
                                        <asp:Label ID="lbl_identitycarddfee" runat="server" />
                                        <asp:Label ID="lbl_appfee" runat="server" />
                                        <asp:Label ID="lbl_misfee" runat="server" />
                                        <asp:Label ID="lbl_entryidfee" runat="server" />
                                    </div>
                                    <div class="service-fields mb-3" style="align-content:center">
                                        <div class="row">

                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <label>Bar Council Enrollment Certificate<span class="text-danger">*</span></label>
                                                    <br />
                                                    <%-- <asp:FileUpload runat="server" ID="fu_barcouncilenrollmentcerupload" multiple="" accept="image/jpeg, image/png, image/gif," />
                                                <asp:Button Text="Upload" runat="server" CssClass="btn btn-primary btn-sm" ID="btn_barcouncilenrollmentcerupload" OnClick="btn_barcouncilenrollmentcerupload_Click" />
                                                    --%> <%--<asp:Image ImageUrl="Images/right.svg" runat="server" ID="img_barcouncilenrollmentceruploadscusess" Visible="false" Height="20px" />--%>
                                                    <asp:Image ID="img_barcouncilenrollmentcerupload" runat="server" Width="100px" Height="100px" Visible="false" CssClass="zoom" />

                                                </div>
                                            </div>

                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <label>ID issued by Bar Council<span class="text-danger">*</span></label>
                                                    <br />
                                                    <%-- <asp:FileUpload runat="server" ID="fu_barcouncilIDupload" multiple="" accept="image/jpeg, image/png, image/gif," />
                                                <asp:Button Text="Upload" runat="server" CssClass="btn btn-primary btn-sm" ID="btn_barcouncilIDupload" OnClick="btn_barcouncilIDupload_Click" />--%>
                                                    <%-- <asp:Image ImageUrl="Images/right.svg" runat="server" ID="img_barcouncilIDuploadsucess" Visible="false" Height="20px" />--%>
                                                    <asp:Image ID="img_barcouncilIDupload" runat="server" Width="100px" Height="100px" Visible="false" CssClass="zoom" />
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <label>PassPort Photo<span class="text-danger">*</span></label>
                                                    <br />
                                                    <%--<asp:FileUpload runat="server" ID="fu_photoupload" multiple="" accept="image/jpeg, image/png, image/gif," />
                                                <asp:Button Text="Upload" runat="server" CssClass="btn btn-primary btn-sm" ID="btn_photoupload" OnClick="btn_photoupload_Click" />--%>
                                                    <%--  <asp:Image ImageUrl="Images/right.svg" runat="server" ID="img_photouploadsuccess" Visible="false" Height="20px" />--%>

                                                    <asp:Image ID="img_photoupload" runat="server" Width="100px" Height="100px" Visible="false" CssClass="zoom" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <%-- <asp:Panel runat="server" ID="pnl_paymenttype">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label>Payment Type <span class="text-danger">*</span></label>

                                        </div>
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <asp:RadioButtonList ID="rbtnPaymentType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" CssClass="chkChoice myCheckBoxList" OnSelectedIndexChanged="rbtnPaymentType_SelectedIndexChanged">
                                                <asp:ListItem Text="Cheque/Online"></asp:ListItem>
                                                <asp:ListItem Text="Cash"></asp:ListItem>

                                            </asp:RadioButtonList>

                                        </div>
                                    </div>
                                </asp:Panel>--%>
                                    <%-- <asp:Panel runat="server" ID="pnl_paymenttypeonlinecheque" Visible="false">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label>Reference Number<span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txt_paymentReferencenumber" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>--%>

                                    <%--  <asp:Panel runat="server" ID="pnl_paymenttypecash" Visible="false">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <table class="table mb-0" border="1" style="border-style: double">
                                                <tr>
                                                    <td>Denomination(if depositing Cash)</td>
                                                    <td>2000</td>
                                                    <td>500</td>
                                                    <td>200</td>
                                                    <td>100</td>
                                                    <td>50</td>
                                                    <td>20</td>
                                                    <td>10</td>
                                                    <td>1/2/5</td>
                                                </tr>
                                                <tr>
                                                    <td>Rupees</td>
                                                    <td>
                                                        <asp:TextBox ID="txt_2000notes" class="form-control" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txt_500notes" class="form-control" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txt_200notes" class="form-control" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txt_100notes" class="form-control" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txt_50notes" class="form-control" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txt_20notes" class="form-control" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txt_10notes" class="form-control" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txt_125coins" class="form-control" runat="server"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </asp:Panel>--%>
                                    <div class="submit-section">
                                        <asp:Button Text="Approve" class="btn btn-primary submit-btn" runat="server" ID="btn_Approve" OnClick="btn_Approve_Click" />
                                        <%-- <asp:Button Text="Payment" class="btn btn-primary submit-btn" runat="server" ID="btn_Payment" OnClick="btn_Payment_Click" Visible="false" />--%>
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnl_view" Visible="true">
                                    <div class="table-responsive">
                                        <table class="table mb-0">
                                            <asp:GridView ID="gdvPendigList" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                                                Width="100%" GridLines="None" OnRowCommand="gdvPendigList_RowCommand"
                                                EmptyDataText="No details">
                                                <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Advocate Name">

                                                        <ItemTemplate>
                                                            <a href="profile.aspx" class="avatar avatar-sm mr-2">
                                                                <img class="avatar-img rounded-circle" src="assets/img/doctors/doctor-thumb-01.jpg" alt="User Image"></a>
                                                            <asp:Label ID="lblMemberID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MemberID")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblAdvocateName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AdvocateName")%>'> </asp:Label></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Enrollment Date">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblEnrollmentDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"EnrollmentDate")%>'> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Membership Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMembershipType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MembershipTypeName")%>'> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Membership Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMembershipDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MembershipDate")%>'> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Enrollment Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEnrollmentNumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"EnrollmentNumber")%>'> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" CommandName="Btn_ApproveCommand" CommandArgument="<%# Container.DataItemIndex %>" ID="btn_Approve"><asp:image imageurl="Images/edit.svg" runat="server" Height="20px" Width="20px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                </Columns>
                                            </asp:GridView>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- /Page Wrapper -->



    <!-- /Main Wrapper -->

    <!-- jQuery -->
    <%-- <script src="assets/js/jquery-3.2.1.min.js"></script>

    <!-- Bootstrap Core JS -->
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!-- Slimscroll JS -->
    <script src="assets/plugins/slimscroll/jquery.slimscroll.min.js"></script>

    <!-- Datatables JS -->
    <script src="assets/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/plugins/datatables/datatables.min.js"></script>

    <!-- Custom JS -->
    <script src="assets/js/script.js"></script>--%>
</asp:Content>

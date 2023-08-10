<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="MemberRegistraion.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.MemberRegistraion" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">Membership Registration</h3>

                    </div>
                </div>
            </div>
            <!-- /Page Header -->


            <div class="row">

                <div class="col-lg-5">
                    <div class="form-group">
                        <label id="lbl_barcode" runat="server" visible="false">Bar Code<span class="text-danger"></span></label>
                        <asp:Image ID="ImageGeneratedBarcode" runat="server" CssClass="img-thumbnail" Visible="false" />

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5">
                    <div class="form-group">
                        <asp:TextBox runat="server" class="form-control" placeholder="Search here" ID="txt_search" OnTextChanged="txt_search_TextChanged" AutoPostBack="true" />
                        <cc1:AutoCompleteExtender ClientIDMode="Static" EnableCaching="false" ServiceMethod="SearchText" MinimumPrefixLength="1"
                            CompletionInterval="100" CompletionSetCount="10" TargetControlID="txt_search" ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                        </cc1:AutoCompleteExtender>
                    </div>
                </div>
                <div class="col-lg-6" style="text-align: right">
                    <div class="form-group">
                        <asp:LinkButton runat="server" ID="btnExcelDownload" CssClass="btn btn-primary btn-sm" OnClick="btnExcelDownload_Click">  Excel Download</asp:LinkButton>

                  <%--  </div>
                    <div class="form-group">--%>
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


            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body custom-edit-service">


                            <asp:Panel runat="server" ID="pnl_entry" Visible="false">
                                <div class="alert alert-danger" runat="server" id="div1">
                                    <asp:CheckBox Text="IsActive" runat="server" ID="ch_isactive" Checked="true" />
                                </div>
                                <div class="service-fields mb-3">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Advocate Name<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_Advocatename" required="" />

                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Gender<span class="text-danger">*</span></label>
                                                <asp:DropDownList runat="server" class="form-control select" ID="ddl_gender">
                                                    <asp:ListItem Text="Male" />
                                                    <asp:ListItem Text="Female" />
                                                    <asp:ListItem Text="Other" />
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Mobile Number<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_MobileNumber" required="" />

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Mobile Number 2<span class="text-danger">(Optional)</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_mobilenumber2" />

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Phone Number<span class="text-danger">(Optional)</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_phonenumber" />

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Address<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_address" required="" />

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>State<span class="text-danger">*</span></label>
                                                <asp:DropDownList runat="server" class="form-control select" ID="ddl_state">
                                                    <asp:ListItem Text="Telengana" />

                                                </asp:DropDownList>

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Email<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_email" required="" />

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>DOB<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_dob" TextMode="Date" required="" />

                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Blood Group<span class="text-danger">*</span></label>
                                                <asp:DropDownList runat="server" class="form-control select" ID="ddl_Bloodgroup">
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
                                                <asp:TextBox runat="server" class="form-control" ID="txt_enrollmentnumber" required="" />

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Enrollment Date<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_enrollmentdate" TextMode="Date" required="" />

                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Membership Type<span class="text-danger">*</span></label>
                                                <asp:DropDownList runat="server" class="form-control select" ID="ddl_MemberShipType" OnSelectedIndexChanged="ddl_MemberShipType_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Membership Date<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_membershipdate" required="" TextMode="Date" />

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
                                                <label>Clerk Name<span class="text-danger"></span></label>                                              
                                                <asp:TextBox runat="server" class="form-control" ID="txt_ClerkName" />


                                            </div>
                                        </div>
                                          <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Clerk Mobile Number<span class="text-danger"></span></label>                                               
                                                <asp:TextBox runat="server" class="form-control" ID="txt_clerkmobilenumber" />


                                            </div>
                                        </div>
                                        <%-- <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Vehicle Number<span class="text-danger"></span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txt_vehiclenumber" />

                                            </div>
                                        </div>
                                        <asp:LinkButton Text="ADD" runat="server" ID="btn_vehicalad" OnClick="btn_vehicalad_Click" CssClass="btn-primary" />
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Vote<span class="text-danger">*</span></label>
                                                <asp:DropDownList runat="server" class="form-control select" ID="ddl_vote">
                                                    <asp:ListItem Text="YES" />
                                                    <asp:ListItem Text="NO" />
                                                </asp:DropDownList>

                                            </div>
                                        </div>--%>
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
                                <div class="service-fields mb-3">
                                    <div class="row">

                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>Bar Council Enrollment Certificate<span class="text-danger">*</span></label>
                                                <br />
                                                <asp:FileUpload runat="server" ID="fu_barcouncilenrollmentcerupload" multiple="" accept="image/jpeg, image/png, image/gif," />
                                                <asp:Button Text="Upload" runat="server" CssClass="btn btn-primary btn-sm" ID="btn_barcouncilenrollmentcerupload" OnClick="btn_barcouncilenrollmentcerupload_Click" />
                                                <%--<asp:Image ImageUrl="Images/right.svg" runat="server" ID="img_barcouncilenrollmentceruploadscusess" Visible="false" Height="20px" />--%>
                                                <asp:Image ID="img_barcouncilenrollmentcerupload" runat="server" Width="100px" Height="100px" Visible="false" CssClass="zoom" />

                                            </div>
                                        </div>

                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>ID issued by Bar Council<span class="text-danger">*</span></label>
                                                <br />
                                                <asp:FileUpload runat="server" ID="fu_barcouncilIDupload" multiple="" accept="image/jpeg, image/png, image/gif," />
                                                <asp:Button Text="Upload" runat="server" CssClass="btn btn-primary btn-sm" ID="btn_barcouncilIDupload" OnClick="btn_barcouncilIDupload_Click" />
                                                <%-- <asp:Image ImageUrl="Images/right.svg" runat="server" ID="img_barcouncilIDuploadsucess" Visible="false" Height="20px" />--%>
                                                <asp:Image ID="img_barcouncilIDupload" runat="server" Width="100px" Height="100px" Visible="false" CssClass="zoom" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>PassPort Photo<span class="text-danger">*</span></label>
                                                <br />
                                                <asp:FileUpload runat="server" ID="fu_photoupload" multiple="" accept="image/jpeg, image/png, image/gif," />
                                                <asp:Button Text="Upload" runat="server" CssClass="btn btn-primary btn-sm" ID="btn_photoupload" OnClick="btn_photoupload_Click" />
                                                <%--  <asp:Image ImageUrl="Images/right.svg" runat="server" ID="img_photouploadsuccess" Visible="false" Height="20px" />--%>

                                                <asp:Image ID="img_photoupload" runat="server" Width="100px" Height="100px" Visible="false" CssClass="zoom" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>Certificate of Practice<span class="text-danger">*</span></label>
                                                <br />
                                                <asp:FileUpload runat="server" ID="fu_Certificateofpractice" multiple="" accept="image/jpeg, image/png, image/gif," />
                                                <asp:Button Text="Upload" runat="server" CssClass="btn btn-primary btn-sm" ID="btn_Certificateofpractice" OnClick="btn_Certificateofpractice_Click" />
                                                <%--  <asp:Image ImageUrl="Images/right.svg" runat="server" ID="img_photouploadsuccess" Visible="false" Height="20px" />--%>

                                                <asp:Image ID="img_Certificateofpractice" runat="server" Width="100px" Height="100px" Visible="false" CssClass="zoom" />
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <asp:Panel runat="server" ID="pnl_paymenttype">
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
                                            <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="rbtnPaymentType" runat="server" ForeColor="Red" ValidationGroup="A" />

                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnl_paymenttypeonlinecheque" Visible="false">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label>Reference Number<span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txt_paymentReferencenumber" class="form-control" runat="server" required=""></asp:TextBox>

                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="pnl_paymenttypecash" Visible="false">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <table class="table mb-0" border="1" style="border-style: double">
                                                <tr>
                                                    <td>Denomination(if depositing Cash)</td>
                                                    <%--  <td>2000</td>--%>
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
                                                    <%--   <td>
                                                        <asp:TextBox ID="txt_2000notes" class="form-control" runat="server"></asp:TextBox></td>
                                                    <td>--%>
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
                                </asp:Panel>
                                <div class="submit-section">
                                    <asp:Button Text="Submit" class="btn btn-primary submit-btn" runat="server" ID="btn_submit" ValidationGroup="A" OnClick="btn_submit_Click" />
                                    <%-- <asp:Button Text="Payment" class="btn btn-primary submit-btn" runat="server" ID="btn_Payment" OnClick="btn_Payment_Click" Visible="false" />--%>
                                </div>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnl_view" Visible="true">
                                <!-- Recent Orders -->
                                <div class="table-responsive">
                                    <table class="table mb-0">
                                        <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                                            Width="100%" GridLines="None" EmptyDataText="No details" OnRowCommand="grid_data_RowCommand" OnPageIndexChanging="grid_data_PageIndexChanging">
                                            <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SINO">

                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="MemberID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_MemberID" runat="server" Text='<%# Eval("MemberID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Advocate Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_AdvocateName" runat="server" Text='<%# Eval("AdvocateName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mobile Number">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_MobileNumber" runat="server" Text='<%# Eval("MobileNumber")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Email">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Email" runat="server" Text='<%# Eval("Email")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Gender">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Gender" runat="server" Text='<%# Eval("Gender")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--<asp:TemplateField HeaderText="Membership Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_MembershipType" runat="server" Text='<%# Eval("MembershipTypeName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <%-- <asp:TemplateField HeaderText="Vote">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_vote" runat="server" Text='<%# Eval("Vote")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Payment Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_PaymentStatus" runat="server" Text='<%# Eval("PaymentStatus").ToString() == "" ? "NO" : Eval("PaymentStatus") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Image" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Image ImageUrl='<%# Eval("photopath")%>' runat="server" Height="50px" Width="50px" />

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" CommandName="Btn_EditCommand" ID="btn_Edit" CommandArgument='<%# Eval("MemberID")%>'><asp:image imageurl="Images/edit.svg" runat="server" Height="20px" Width="20px" /></asp:LinkButton>
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
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="AddReceipts.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.AddReceipts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
    <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-title">Add Receipts</h3>

                    </div>
                </div>
            </div>
            <div class="alert alert-success" id="div_success" runat="server" visible="false">
                <strong>Success!</strong>.
            </div>
            <div class="alert alert-danger" runat="server" visible="false" id="div_fail">
                <strong>Transaction ID is Already Exists!</strong>
            </div>
            
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body custom-edit-service">
                            <div class="service-fields mb-3">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label>Registered Member ID <span class="text-danger">*</span></label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:RadioButton ID="rbtnRegistered" runat="server" Text=" Registered Member" GroupName="A" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:RadioButton ID="rbtnNonRegistered" runat="server" Text=" Non Registered Member" GroupName="A" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Registered Member ID<span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtMemberID" class="form-control" runat="server" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Received From<span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtReceivedFrom" class="form-control" runat="server" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <asp:Panel ID="pnlDropDown" runat="server">
                                    <asp:Label ID="lblDdlvalues" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblDDlNames" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblDdlIds" runat="server" Text="" Visible="false"></asp:Label>

                                </asp:Panel>
                                <asp:Panel ID="pnlCheckBox" runat="server">
                                </asp:Panel>

                                <asp:Label ID="lblChkValues" runat="server" Visible="false" Text=""></asp:Label>
                                <asp:Label ID="lblChkNames" runat="server" Visible="false" Text=""></asp:Label>
                                <asp:Label ID="lblChkIds" runat="server" Visible="false" Text=""></asp:Label>

                                <asp:Panel runat="server" ID="Panel1">

                                    <asp:Repeater ID="rptCustomers" runat="server">
                                        <ItemTemplate>
                                            <label class="switch">
                                                <asp:CheckBox runat="server" ID="chkFeatures" Text='<%# Eval("featureOptions") %>' OnCheckedChanged="chkFeatures_CheckedChanged" AutoPostBack="true" CssClass="chkChoice myCheckBoxList bubble left" />
                                                <asp:Label ID="chkIds" runat="server" Text='<%# Eval("FeatureID") %>' Visible="false"></asp:Label>
                                            </label>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </asp:Panel>

                                <div class="row">


                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label>Towards <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtTowards" class="form-control" runat="server" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label>Sum Of Rupees <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtCheckBoxTotal" class="form-control" Visible="false" runat="server" Text=""></asp:TextBox>
                                            <asp:TextBox ID="txtDropDownTotal" class="form-control" Visible="false" runat="server" Text=""></asp:TextBox>
                                            <asp:TextBox ID="txtAmount" class="form-control" runat="server" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label>Transaction ID <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtTransactionID" class="form-control" runat="server" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">


                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label>Payment Type <span class="text-danger">*</span></label>

                                        </div>
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <asp:RadioButtonList ID="rbtnPaymentType" runat="server" AutoPostBack="true" OnTextChanged="rbtnPaymentType_TextChanged" RepeatDirection="Horizontal" CssClass="chkChoice myCheckBoxList">
                                                <asp:ListItem Text="Cheque/Online"></asp:ListItem>
                                                <asp:ListItem Text="Cash"></asp:ListItem>

                                            </asp:RadioButtonList>

                                        </div>
                                    </div>

                                      <asp:Panel runat="server" ID="pnl_paymenttypeonlinecheque" Visible="false">
                                                    <div class="col-lg-12">
                                                        <div class="form-group">
                                                            <label>Reference Number<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txt_paymentReferencenumber" class="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </asp:Panel>

                                                <asp:Panel runat="server" ID="pnl_paymenttypecash" Visible="false">
                                                    <div class="col-lg-12">
                                                        <div class="form-group">
                                                            <table class="table mb-0" border="1" style="border-style:double">
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
                                                </asp:Panel>

                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <div class="submit-section">
                                                <asp:Button Text="Submit" runat="server" class="btn btn-primary submit-btn" ID="btn_submit" OnClick="btn_submit_Click" />

                                                <%--  <asp:Button Text="Clear" runat="server" class="btn btn-primary submit-btn" ID="btnClear" OnClick="btnClear_Click" />--%>
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
    </div>
</asp:Content>

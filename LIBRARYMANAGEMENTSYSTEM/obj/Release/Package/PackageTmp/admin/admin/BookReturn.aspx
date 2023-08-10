<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="BookReturn.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.BookReturn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-title">Book Return</h3>

                    </div>
                </div>
            </div>
            <div style="margin-left: 75%">
                <div class="row">
                    <div class="col-md-12">
                        <label>Bar Code<span class="text-danger">*</span></label>
                        <div class="service-upload">
                            <asp:Image ID="ImageGeneratedBarcode" runat="server" CssClass="img-thumbnail" Visible="false" />
                        </div>
                        <br />
                    </div>

                </div>

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
                                                            <label>MemberShip MobileNumber<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtMemberShipMobileNo" AutoPostBack="true" class="form-control" runat="server" OnTextChanged="txtMemberShipMobileNo_TextChanged"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>MemberShip Name<span class="text-danger">*</span></label>

                                                            <asp:TextBox ID="txt_Membershipname" class="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Book Name<span class="text-danger">*</span></label>

                                                            <asp:DropDownList runat="server" ID="ddlBookName" AutoPostBack="true" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged" class="form-control">
                                                                <asp:ListItem Value="0" Text="Select Book Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Author Name<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtAuthor" class="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Date Of Issued<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtIssuedDate" class="form-control" runat="server" ReadOnly="" TextMode="Date"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Date Of Submit<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtSubmitDate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>No. Of Books Issued<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="lblNoOfBooksIssued" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>


                                                        </div>
                                                    </div>


                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>No. Of Books Return<span class="text-danger">*</span></label>
                                                            <asp:Label ID="lblNoOfBooks" runat="server" Visible="false"></asp:Label>
                                                            <asp:TextBox ID="txtNoOfbooks" required="" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtNoOfbooks_TextChanged"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                                                TargetControlID="txtNoOfbooks" />

                                                        </div>
                                                    </div>

                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Fine Amount<span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtFineAmount" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                            <asp:Label ID="lblFine" runat="server" Visible="false"></asp:Label>
                                                            <asp:Label ID="lblBookID" runat="server" Visible="false"></asp:Label>
                                                            <asp:Label ID="lblMembershipID" runat="server" Visible="false"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>  
                                                <asp:Panel runat="server" ID="pnl_paymenttype" Visible="false">
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
                                                </asp:Panel>
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

                                                <%-- <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label>Bar Code<span class="text-danger">*</span></label>
                                        <div class="service-upload">
                                              <asp:Image ID="ImageGeneratedBarcode" runat="server" CssClass="img-thumbnail" Visible="false"/>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>

                                                <div class="submit-section">
                                                    <div class="col-lg-12">
                                                        <div class="form-group">
                                                            <div class="submit-section">
                                                                <asp:Button ID="btnSave" class="btn btn-primary submit-btn" runat="server" Text="Save" OnClick="btnSave_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


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
    </div>
</asp:Content>

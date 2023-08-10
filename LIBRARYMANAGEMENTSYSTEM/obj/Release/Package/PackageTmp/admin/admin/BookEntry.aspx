<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="BookEntry.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.BookEntry" %>

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


    <div class="page-wrapper">
        <div class="content container-fluid">

            <!-- Page Header -->
            <div class="page-header">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-title">Book Entry</h3>

                    </div>
                </div>
            </div>



            <div class="row">

                <div class="col-lg-5">
                    <div class="form-group">
                        <asp:TextBox runat="server" class="form-control" placeholder="Search here" ID="txt_search" />
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
                <div style="margin-left: 75%">
                    <div class="row">
                        <div class="col-md-12">
                            <label>Bar Code<span class="text-danger">*</span></label>
                            <div class="service-upload">
                                <asp:Label ID="lblBookID" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Image ID="ImageGeneratedBarcode" runat="server" CssClass="img-thumbnail" Visible="false" /><br />
                                <asp:LinkButton Text="Print" runat="server" ID="btn_printbarcode" OnClick="btn_printbarcode_Click" Visible="false"  />
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
                                    <div class="row">
                                        <%-- <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Book Serial No<span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtSerialNo" class="form-control" runat="server" ReadOnly="true" ></asp:TextBox>
                                        </div>
                                    </div>--%>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Year Of Publish<span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtYearOfPublish" class="form-control" MaxLength="4" runat="server" required=""></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Book Type<span class="text-danger">*</span></label>
                                                <asp:DropDownList runat="server" ID="ddlBookType" class="form-control">
                                                    <asp:ListItem Value="0" Text="Select Book Type"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Journal"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Magazines"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Articles"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Proceedings"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="Judgments"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="News Papers"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="Periodicals"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="ddlBookType" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="A" />
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Place Of Publish<span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtPlace" class="form-control" runat="server" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Subject<span class="text-danger">*</span></label>
                                                <%--<asp:Label runat="server" ID="lblBookType" Text="Book Type" class="form_controlLabel"></asp:Label>--%>
                                                <asp:DropDownList runat="server" ID="ddlSubject" class="form-control">
                                                    <asp:ListItem Value="0" Text="Select Subject Type"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Constitution Law"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Criminal Law"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Civil Law"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Crpc"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="IPC"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="Contract Law"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="Taxation Law"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="Banking Law"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="Family Law"></asp:ListItem>

                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="ddlSubject" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="A" />
                                            </div>
                                        </div>


                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Title/ Book Name<span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtBookName" class="form-control" runat="server" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Total Pages<span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtTotalPages" class="form-control" runat="server" required=""></asp:TextBox>

                                            </div>
                                        </div>
                                         <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Edition<span class="text-danger"></span></label>
                                                <asp:TextBox ID="txt_edition" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>ISBN/ISSN/NO<span class="text-danger"></span></label>
                                                <asp:TextBox ID="txtISBN" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Volume<span class="text-danger"></span></label>
                                                <asp:TextBox ID="txtVolume" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Publisher Name<span class="text-danger"></span></label>
                                                <asp:TextBox ID="txtPublisher" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Price<span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtPrice" class="form-control" runat="server" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>No of Books<span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txt_noofbooks" class="form-control" runat="server" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Bill Date<span class="text-danger"></span></label>
                                                <asp:TextBox ID="txtBillDate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Invoice/Bill No<span class="text-danger"></span></label>
                                                <asp:TextBox ID="txtInvoice" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Suppliper Contact No<span class="text-danger"></span></label>
                                                <asp:TextBox ID="txtSupContact" class="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Suppliper Name<span class="text-danger"></span></label>
                                                <asp:DropDownList runat="server" class="form-control select" ID="ddlSupplier">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Suppliper Address<span class="text-danger"></span></label>
                                                <asp:TextBox ID="txtSupAddress" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Section Name<span class="text-danger">*</span></label>
                                                <asp:DropDownList runat="server" class="form-control select" ID="ddlSectionName" AutoPostBack="true" OnSelectedIndexChanged="ddlSectionName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="ddlSectionName" runat="server" ForeColor="Red" ValidationGroup="A" InitialValue="0" />

                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Rack Name<span class="text-danger">*</span></label>
                                                <asp:DropDownList runat="server" class="form-control select" AutoPostBack="true" ID="ddlRackName">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="ddlRackName" runat="server" ForeColor="Red" ValidationGroup="A" InitialValue="0" />
                                            </div>
                                        </div>
                                        <%-- <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Number of Selfs<span class="text-danger">*</span></label>
                                           <asp:DropDownList runat="server" class="form-control select" ID="ddlSelfs"  >
                                        
                                           </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                        <%--<div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Number of Books in self<span class="text-danger">*</span></label>
                                                <asp:TextBox runat="server" class="form-control" ID="txtNoOfBooksInSelf" required="" />
                                            </div>
                                        </div>--%>
                                    </div>

                                    <div class="col-sm-12">
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <div class="form-group">
                                                    <label>Author Name<span class="text-danger">*</span></label>
                                                    <asp:TextBox ID="txtAuthor" class="form-control" runat="server"></asp:TextBox>
                                                    <asp:req
                                                    <asp:HiddenField ID="hdnAuthorName" runat="server" Visible="false" Value="" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <br />
                                                    <asp:Button class="btn btn-primary submit-btn" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <asp:Label ID="lblAuthor" runat="server" Text="Author Names :" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblAuthorNames" runat="server" Text="" Visible="false"></asp:Label>
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="form-group">
                                                <asp:GridView ID="grdAuthor" runat="server" Visible="false">
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <%--  <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label>Book Cover<span class="text-danger">*</span></label>
                                        <div class="col-md-12" style="padding-left: 20px; padding-right: 20px">--%>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Book Cover<span class="text-danger">*</span></label>
                                            </div>

                                            <asp:Image runat="server" ID="imgwardphoto" AlternateText="Book Cover" Width="100" Visible="false"
                                                Height="100" BorderWidth="2px" CssClass="zoom" />
                                            <%--</asp:Label>--%>
                                            <asp:FileUpload ID="ctrlphotoupload" runat="server" Width="50%" CssClass="txtbox"
                                                EnableViewState="true" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="btnphotoupload" Text="Upload" OnClick="btnphotoupload_Click"
                            CausesValidation="false" />
                                            <asp:Label runat="server" ID="lbluploadwardphoto" Text="" />
                                            <%--<asp:LinkButton ID="href_wardphotofilename" runat="server" OnClick="DownloadFile"></asp:LinkButton>--%>
                                            <asp:LinkButton runat="server" ID="lnk_removeward" Text="Remove" OnClick="lnk_removeward_Click"
                                                Visible="false" CausesValidation="false" />
                                            <asp:HiddenField ID="ctrlphotouploadfilename" runat="server" Value="" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />

                                <%--<div class="service-upload">
                                            <i class="fas fa-cloud-upload-alt"></i>
                                            <span>Book Cover *</span>
                                            <asp:FileUpload runat="server" ID="fu_upload" multiple="" accept="image/jpeg, image/png, image/gif," />
                                        </div>
                                    </div>
                                </div>
                            </div>--%>

                                <div class="submit-section">
                                    <div class="col-lg-12">
                                        <div class="submit-section">
                                            <asp:Button runat="server" ID="btnSave" Text="Save" class="btn btn-primary submit-btn" OnClick="btnSave_Click" ValidationGroup="A" />
                                            <%--<button class="btn btn-primary submit-btn" type="submit" name="form_submit" value="submit">Submit</button>--%>
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
                                    <asp:TemplateField HeaderText="Book Name" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_BookID" Visible="false" runat="server" Text='<%# Eval("BookID")%>'></asp:Label>
                                            <asp:Label ID="lbl_BookName" runat="server" Text='<%# Eval("BookName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile No" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_AuthorName" runat="server" Text='<%# Eval("AutherName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Price" runat="server" Text='<%# Eval("Price")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No Of Books" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_NoOfBooks" runat="server" Text='<%# Eval("NoOfBooks")%>'></asp:Label>
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
   <%-- <script type="text/javascript">
        $(".pic").live("mousemove", function (e) {
            var dv = $("#popup");
            if (dv.length == 0) {
                var src = $(this)[0].src;
                var dv = $("<div />").css({ height: 250, width: 250, position: "absolute" });
                var img = $("<img />").css({ height: 250, width: 250 }).attr("src", src);
                dv.append(img);
                dv.attr("id", "popup");
                $("body").append(dv);
            }
            dv.css({ left: e.pageX, top: e.pageY });
        });
        $(".pic").live("mouseout", function () {
            $("#popup").remove();
        });

    </script>--%>
</asp:Content>


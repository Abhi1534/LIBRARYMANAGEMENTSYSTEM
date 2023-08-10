<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.Notifications" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <head runat="server">
    <script type="text/javascript">  

        function ValidDates(e, sender, args) {
            var today = new Date();
            var fromdatesplit = document.getElementById("ctl00_HomePageContent_txtfromdate").value
            var froms = fromdatesplit.split("/");
            var fromdate = new Date(froms[1] + '/' + froms[0] + '/' + froms[2]);

            var tosplit = document.getElementById("ctl00_HomePageContent_txttodate").value
            var tos = tosplit.split("/");
            var todate = new Date(tos[1] + '/' + tos[0] + '/' + tos[2]);



            if (fromdate > todate) {
                alert("To date should be greater than From date");
                document.getElementById("ctl00_HomePageContent_txttodate").value = '';
                return false;
            }
        }


    </script>
        </head>
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
                        <h3 class="page-title">Notifications</h3>

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

            <asp:Panel runat="server" ID="pnl_entry" Visible="false">


                <div class="row">
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Content<span class="text-danger">*</span></label>
                            <asp:Label ID="lblNotificationID" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtContent" class="form-control" runat="server" required=""></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Description<span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtdescription" class="form-control" runat="server" required=""></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>From Date<span class="text-danger"></span></label>
                            <asp:TextBox ID="txtfromdate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                            
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>To Date<span class="text-danger"></span></label>
                            <asp:TextBox ID="txttodate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                           
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Files<span class="text-danger">*</span></label>
                        </div>

                        <%--</asp:Label>--%>
                        <asp:FileUpload ID="ctrlphotoupload" runat="server" Width="50%" CssClass="txtbox" AllowMultiple="true"
                            EnableViewState="true" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="btnphotoupload" Text="Upload" OnClick="btnphotoupload_Click"
                            CausesValidation="false" />
                        <asp:Label runat="server" ID="lbluploadwardphoto" Text="" />
                        <%--<asp:LinkButton ID="href_wardphotofilename" runat="server" OnClick="DownloadFile"></asp:LinkButton>--%>
                        <asp:LinkButton runat="server" ID="lnk_removeward" Text="Remove" OnClick="lnk_removeward_Click"
                            Visible="false" CausesValidation="false" />
                        <asp:HiddenField ID="ctrlphotouploadfilename" runat="server" Value="" />

                        <asp:Repeater ID="rptImage" runat="server" OnItemDataBound="rptImage_ItemDataBound">
                            <ItemTemplate>
                                <%--  <img alt="" src='images/<%#Eval("ImageUrl") %>' height="50px" width="50px" />--%>
                                <asp:Image runat="server" ID="imgwardphoto" ImageUrl='<%# Eval("ImageUrl") %>' AlternateText="Photo" Width="100"
                                    Height="100" BorderWidth="2px" CssClass="zoom" />
                            </ItemTemplate>
                        </asp:Repeater>


                    </div>

                </div>

                <div class="submit-section">
                    <div class="col-lg-12">
                        <div class="submit-section">
                            <asp:Button runat="server" ID="btnSave" Text="Save" class="btn btn-primary submit-btn" OnClick="btnSave_Click" ValidationGroup="A" />
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
                                    <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_NotificationID" Visible="false" runat="server" Text='<%# Eval("NotificationID")%>'></asp:Label>
                                            <asp:Label ID="lbl_Description" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notification Content" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_NotificationContent" runat="server" Text='<%# Eval("NotificationContent")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From Date" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Fromdate" runat="server" Text='<%# Eval("Fromdate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Date" HeaderStyle-CssClass="gridHeadStyle"
                                        ItemStyle-CssClass="table-avatar">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Todate" runat="server" Text='<%# Eval("Todate")%>'></asp:Label>
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
</asp:Content>



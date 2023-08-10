<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="MembersBookStatus.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.MembersBookStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridHeadStyle {
            background-color: #f8f9fa;
            border-bottom: 1px solid rgba(0, 0, 0, 0.03);
            box-sizing: border-box;
            font-family: 'Mada', sans-serif;
            font-size: 1rem;
            line-height: 1.5;
            height: 50px;
            border-top: 1px solid #dee2e6;
             border-bottom: 1px solid #dee2e6;
        }
        .table-avatar {
            border-bottom: 1px solid #dee2e6;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-wrapper">
		
			<!-- Header -->
			<header class="header">
				<nav class="navbar navbar-expand-lg header-nav">
					<div class="navbar-header">
						<a id="mobile_btn" href="javascript:void(0);">
							<span class="bar-icon">
								<span></span>
								<span></span>
								<span></span>
							</span>
						</a>
						<a href="index.aspx" class="navbar-brand logo">
							<img src="../images/thcaa1.png" class="img-fluid" alt="Logo">
						</a>
					</div>
					<div class="main-menu-wrapper">
						<div class="menu-header">
							<a href="index.aspx" class="menu-logo">
								<img src="../images/thcaa1.png" class="img-fluid" alt="Logo">
							</a>
							<a id="menu_close" class="menu-close" href="javascript:void(0);">
								<i class="fas fa-times"></i>
							</a>
						</div>
						
					</div>		 
					<ul class="nav header-navbar-rht">
						<li class="nav-item contact-item">
							<div class="header-contact-img">
								<i class="far fa-hospital"></i>							
							</div>
							<div class="header-contact-detail">
								<p class="contact-header">Contact</p>
								<p class="contact-info-header"> +91 81259 13755</p>
							</div>
						</li>
						
					</ul>
				</nav>
				
			</header>
			<!-- /Header -->
			
			<!-- Breadcrumb -->
			<div class="breadcrumb-bar">
				<div class="container-fluid">
					<div class="row align-items-center">
						<div class="col-md-6 col-6">
							<nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Dashboard</li>
								</ol>
							</nav>
							
						</div>
						<div class="col-md-6 col-6">
							<nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb" style="float: right;">
									<li class="breadcrumb-item">
										<button type="button" class="btn btn-block btn-outline-primary"><a href="../index.aspx">Logout</a></button>
									</li>
									<!-- <li class="breadcrumb-item active" aria-current="page">Dashboard</li> -->
								</ol>
							</nav>
							
						</div>
					</div>
				</div>
			</div>
			<!-- /Breadcrumb -->
			
			<!-- Page Content -->
			<div class="content">
				<div class="container-fluid">
                     <div style="margin-left: 75%">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txtSearch" class="form-control" placeholder="Search here" runat="server" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <%--<button class="btn" type="submit"><i class="fa fa-search"></i></button>--%>
                                            <br />
                                        </div>
                                       
                                    </div>

                                </div>
					   <div class="row">
                                    <div class="col-md-12">

                                        <!-- Recent Orders -->
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="table-responsive">

                                                    <table class="datatable table table-hover table-center mb-0">
                                                        <asp:GridView ID="gdvLibartyStatus" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true"
                                                            Width="100%" GridLines="None"
                                                            EmptyDataText="No details">
                                                            <EmptyDataRowStyle Height="100px" HorizontalAlign="Center" CssClass="datatable table table-hover table-center mb-0" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Book Name" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">

                                                                    <ItemTemplate>
                                                                        <a href="profile.aspx" class="avatar avatar-sm mr-2">
                                                                            <img class="avatar-img rounded-circle" src="assets/img/doctors/doctor-thumb-01.jpg" alt="User Image"></a>

                                                                        <asp:Label ID="lblBookName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BookName")%>'> </asp:Label></a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Book Author" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">
                                                                    <ItemTemplate>
                                                                        <a href="profile.aspx" class="avatar avatar-sm mr-2">
                                                                            <img class="avatar-img rounded-circle" src="assets/img/doctors/doctor-thumb-01.jpg" alt="User Image"></a>

                                                                        <asp:Label ID="lblBookAuthor" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AutherName")%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Books" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTotalBooks" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"NoOfBooks")%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Available Books" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAvailableBooks" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AvailableBooks")%>'> </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="gridHeadStyle"
                                                                    ItemStyle-CssClass="table-avatar" HeaderStyle-Width="4%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Price")%>'> </asp:Label>
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

				</div>

			</div>	
			<!-- /Page Content -->
   
			<!-- Footer -->
			<footer class="footer">
				
				<!-- Footer Top -->
				<div class="footer-top">
					<div class="container-fluid">
						<div class="row">
							<div class="col-lg-9 col-md-9">
							
								<!-- Footer Widget -->
								<div class="footer-widget footer-about">
									<div class="footer-logo">
										
									</div>
									<div class="footer-about-content">
										<p> Disclaimer: While every effort has been made to keep the information on this site accurate. The material contained on this site and on the associated web pages is general information and is not intended to be advice on any particular matter. Visitors to this site should seek appropriate and verify all information before acting on the basis of any information contained herein. The TELANGANA High Court Advocates Association expressly disclaim any and all liability to any person, in respect of anything and of the consequences of anything done or omitted to be done by any such person in reliance upon the contents of this site and associated web pages.</p>
										<div class="social-icon">
											<ul>
												<li>
													<a href="#" target="_blank"><i class="fab fa-facebook-f"></i> </a>
												</li>
												<li>
													<a href="#" target="_blank"><i class="fab fa-twitter"></i> </a>
												</li>
												<li>
													<a href="#" target="_blank"><i class="fab fa-linkedin-in"></i></a>
												</li>
												<li>
													<a href="#" target="_blank"><i class="fab fa-instagram"></i></a>
												</li>
												<li>
													<a href="#" target="_blank"><i class="fab fa-dribbble"></i> </a>
												</li>
											</ul>
										</div>
									</div>
								</div>
								<!-- /Footer Widget -->
								
							</div>
							
							
							
							
							
							<div class="col-lg-3 col-md-3">
							
								<!-- Footer Widget -->
								<div class="footer-widget footer-contact">
									<h2 class="footer-title">Contact Us</h2>
									<div class="footer-contact-info">
										<div class="footer-address">
											<span><i class="fas fa-map-marker-alt"></i></span>
											<p> Telangana High Court Advocates’ Association, Survey No. 8 & 9, Hyderabad, Telangana -98, India. </p>
										</div>
										<p>
											<i class="fas fa-phone-alt"></i>
											+91 81259 13755
										</p>
										<p class="mb-0">
											<i class="fas fa-envelope"></i>
											telanganahcaa@gmail.com
										</p>
									</div>
								</div>
								<!-- /Footer Widget -->
								
							</div>
							
						</div>
					</div>
				</div>
				<!-- /Footer Top -->
				
				<!-- Footer Bottom -->
                <div class="footer-bottom">
					<div class="container-fluid">
					
						<!-- Copyright -->
						<div class="copyright">
							<div class="row">
								<div class="col-md-6 col-lg-6">
									<div class="copyright-text">
										<p class="mb-0">© 2023 Telangana High Court Advocates’ Association. All rights reserved.</p>
									</div>
								</div>
								<div class="col-md-6 col-lg-6">
								
									<!-- Copyright Menu -->
									<div class="copyright-menu">
										<ul class="policy-menu">
											<li><a href="term-condition.html">Terms and Conditions</a></li>
											<li><a href="privacy-policy.html">Policy</a></li>
										</ul>
									</div>
									<!-- /Copyright Menu -->
									
								</div>
							</div>
						</div>
						<!-- /Copyright -->
						
					</div>
				</div>
				<!-- /Footer Bottom -->
				
			</footer>
			<!-- /Footer -->
		   
		</div>

		<div class="modal fade" id="tooltipmodal" tabindex="-1" role="dialog" aria-labelledby="tooltipmodal" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered" role="document">
			  <div class="modal-content">
				
				<div class="success-card">
					<div class="card-body">
						<div class="success-cont">
							<i class="fas fa-check"></i>
							<h3>Successfully!</h3>
							<p class="mb-0">Product ID: 245468</p>
						</div>
					</div>
				</div>
					<div class="modal-footer">
					  <button class="btn btn-secondary" type="button" data-dismiss="modal" data-original-title="" title="">Close</button>
					  </div>
			  </div>
			</div>
	  </div>
</asp:Content>

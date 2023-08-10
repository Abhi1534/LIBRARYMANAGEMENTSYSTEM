<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="page-wrapper">
			
                <div class="content container-fluid">
					
					<!-- Page Header -->
					<div class="page-header">
						<div class="row">
							<div class="col-sm-12">
								<h3 class="page-title">Welcome Admin!</h3>
								<ul class="breadcrumb">
									<li class="breadcrumb-item active">Dashboard</li>
								</ul>
							</div>
						</div>
					</div>
					<!-- /Page Header -->

					<div class="row">
						<div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<span class="dash-widget-icon text-primary border-primary">
											<i class="fe fe-users"></i>
										</span>
										<div class="dash-count">
											<h3>
                                                <asp:Label ID="lbl_noofmembers" runat="server" /></h3>
										</div>
									</div>
									<div class="dash-widget-info">
										<h6 class="text-muted">No of users Created</h6>
										<%--<div class="progress progress-sm">
											<div class="progress-bar bg-primary w-50"></div>
										</div>--%>
									</div>
								</div>
							</div>
						</div>
						<%--<div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<span class="dash-widget-icon text-success">
											<i class="fe fe-credit-card"></i>
										</span>
										<div class="dash-count">
											<h3>487 Rs</h3>
										</div>
									</div>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Amount collected</h6>
										<div class="progress progress-sm">
											<div class="progress-bar bg-success w-50"></div>
										</div>
									</div>
								</div>
							</div>
						</div>
						<div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<span class="dash-widget-icon text-warning border-warning">
											<i class="fe fe-money"></i>
										</span>
										<div class="dash-count">
											<h3>485</h3>
										</div>
									</div>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Online Collected</h6>
										<div class="progress progress-sm">
											<div class="progress-bar bg-warning w-50"></div>
										</div>
									</div>
								</div>
							</div>
						</div>--%>
                          <div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<span class="dash-widget-icon text-danger border-danger">
											<i class="fe fe-credit-card"></i>
										</span>
										<div class="dash-count">
											<h3>
                                                <asp:Label ID="lbl_todayonlinecollection" runat="server" /></h3>
										</div>
									</div>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Today Online Collection</h6>
										<%--<<div class="progress progress-sm">
											<div class="progress-bar bg-danger w-50"></div>
										</div>--%>
									</div>
								</div>
							</div>
						</div>

                         <div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<span class="dash-widget-icon text-danger border-danger">
											<i class="fe fe-credit-card"></i>
										</span>
										<div class="dash-count">
											<h3>
                                                <asp:Label ID="lbl_todayofflinecollection" runat="server" /></h3>
										</div>
									</div>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Today Offline Collection</h6>
										<%--<<div class="progress progress-sm">
											<div class="progress-bar bg-danger w-50"></div>
										</div>--%>
									</div>
								</div>
							</div>
						</div>
						<div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<span class="dash-widget-icon text-success border-success">
											<i class="fe fe-book"></i>
										</span>
										<div class="dash-count">
											<h3><asp:Label ID="lbl_totalbooks" runat="server" /></h3>
										</div>
									</div>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Total Books available</h6>
										<%--<div class="progress progress-sm">
											<div class="progress-bar bg-success w-50"></div>
										</div>--%>
									</div>
								</div>
							</div>
						</div>
                       
						<div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<span class="dash-widget-icon text-secondary border-secondary">
											<i class="fe fe-credit-card"></i>
										</span>
										<div class="dash-count">
											<h3><asp:Label ID="lbl_todayissued" runat="server" /></h3>
										</div>
									</div>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Today Issued</h6>
										<%--<div class="progress progress-sm">
											<div class="progress-bar bg-secondary w-50"></div>
										</div>--%>
									</div>
								</div>
							</div>
						</div>
						<div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<div class="dash-widget-header">
										<span class="dash-widget-icon text-danger border-danger">
											<i class="fe fe-credit-card"></i>
										</span>
										<div class="dash-count">
											<h3>
                                                <asp:Label ID="lbl_pendingcopies" runat="server" /></h3>
										</div>
									</div>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Pending Copies</h6>
										<%--<<div class="progress progress-sm">
											<div class="progress-bar bg-danger w-50"></div>
										</div>--%>
									</div>
								</div>
							</div>
						</div>

                       
					</div>
					
					
					
					
				</div>			
			</div>
</asp:Content>

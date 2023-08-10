<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="Expenditure.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.Expenditure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="page-wrapper">
			
                <div class="content container-fluid">
					
					<!-- Page Header -->
					<div class="page-header">
						<div class="row">
							<div class="col-sm-12">
								<h3 class="page-title">Expenditure</h3>
								
							</div>
						</div>
					</div>
					<!-- /Page Header -->

					<div class="row">
						<div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
									<asp:LinkButton ID="lnkReg" runat="server" OnClick="lnkReg_Click">
                                        <div class="dash-widget-header">
										<span class="dash-widget-icon text-primary border-primary">
										<i class="fe fe-users"></i>	
										</span>
										<div class="dash-count">
											<h3>
                                                <asp:Label ID="lbl_noofRegistrations" runat="server" Text="0" /></h3>
										</div>
									</div></asp:LinkButton>
									<div class="dash-widget-info">
										<h6 class="text-muted">Membership registration</h6>
										
									</div>
								</div>
							</div>
						</div>
					
						<div class="col-xl-4 col-sm-6 col-12">
							<div class="card">
								<div class="card-body">
								<asp:LinkButton ID="lnkBook" runat="server" ForeColor="#699834" OnClick="lnkBook_Click">	<div class="dash-widget-header">
										<span class="dash-widget-icon text-success border-success">
											<i class="fe fe-book"></i>
										</span>
										<div class="dash-count">
											<h3><asp:Label ID="lbl_Library" runat="server" Text="0"/></h3>
										</div>
									</div></asp:LinkButton>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Library</h6>
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
								<asp:LinkButton ID="lnkDonation" runat="server" ForeColor="#e84646" OnClick="lnkDonation_Click">	<div class="dash-widget-header">
										<span class="dash-widget-icon text-danger border-danger">
												<i class="fe fe-credit-card"></i>
										</span>
										<div class="dash-count">
											<h3>
                                                <asp:Label ID="lbl_Donation" runat="server" Text="0"/></h3>
										</div>
									</div></asp:LinkButton>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Donation</h6>
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
								<asp:LinkButton ID="lnkReceipt" runat="server" ForeColor="#e84646" OnClick="lnkReceipt_Click">		<div class="dash-widget-header">
										<span class="dash-widget-icon text-danger border-danger">
											<i class="fe fe-credit-card"></i>
									</span>
										<div class="dash-count">
											<h3>
                                                <asp:Label ID="lbl_Receipts" runat="server" Text="0" /></h3>
										</div>
									</div>	</asp:LinkButton>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Receipts</h6>
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
								<asp:LinkButton ID="lbtn_WelfareStamps" runat="server" ForeColor="#b8bdc1" OnClick="lbtn_WelfareStamps_Click">	<div class="dash-widget-header">
										<span class="dash-widget-icon text-secondary border-secondary">
										<i class="fe fe-credit-card"></i>
										</span>
										<div class="dash-count">
											<h3><asp:Label ID="lbl_WelfareStamps" runat="server" Text="0" /></h3>
										</div>
									</div></asp:LinkButton>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Welfare Stamps</h6>
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
								<asp:LinkButton ID="lbtn_CourtStamps" runat="server" ForeColor="#b8bdc1" OnClick="lbtn_CourtStamps_Click">	<div class="dash-widget-header">
										<span class="dash-widget-icon text-secondary border-secondary">
										<i class="fe fe-credit-card"></i>
										</span>
										<div class="dash-count">
											<h3><asp:Label ID="lbl_CourtStamps" runat="server" Text="0" /></h3>
										</div>
									</div></asp:LinkButton>
									<div class="dash-widget-info">
										
										<h6 class="text-muted">Court Stamps</h6>
										<%--<div class="progress progress-sm">
											<div class="progress-bar bg-secondary w-50"></div>
										</div>--%>
									</div>
								</div>
							</div>
						</div>
                       
					</div>
					
					
					
					
				</div>			
			</div>
</asp:Content>

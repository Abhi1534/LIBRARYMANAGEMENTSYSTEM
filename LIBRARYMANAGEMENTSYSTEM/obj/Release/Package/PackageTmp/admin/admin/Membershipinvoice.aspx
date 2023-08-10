<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="Membershipinvoice.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.admin.admin.Membershipinvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-7 col-lg-8 col-xl-9">
							<div class="card card-table">
								<div class="card-body">
								
									<!-- Invoice Table -->
									<div class="table-responsive">
										<table class="table table-hover table-center mb-0">
											<thead>
												<tr>
													<th>Invoice No</th>
													<th>Book Name</th>
													<th>Amount</th>
													<th>Paid On</th>
													<th></th>
												</tr>
											</thead>
											<tbody>
												<tr>
													<td>
														<a href="invoice-view.html">#INV-0010</a>
													</td>
													<td>
														<h2 class="table-avatar">
															<a href="patient-profile.aspx" class="avatar avatar-sm mr-2">
																<img class="avatar-img rounded-circle" src="assets/img/patients/patient.jpg" alt="User Image">
															</a>
															<a href="patient-profile.aspx">Richard Wilson <span>#PT0016</span></a>
														</h2>
													</td>
													<td>₹450</td>
													<td>14 Nov 2019</td>
													<td class="text-right">
														<div class="table-action">
															<a href="invoice-view.html" class="btn btn-sm bg-info-light">
																<i class="far fa-eye"></i> View
															</a>
															<a href="javascript:void(0);" class="btn btn-sm bg-primary-light">
																<i class="fas fa-print"></i> Print
															</a>
														</div>
													</td>
												</tr>
												<tr>
													<td>
														<a href="invoice-view.html">#INV-0009</a>
													</td>
													<td>
														<h2 class="table-avatar">
															<a href="patient-profile.aspx" class="avatar avatar-sm mr-2">
																<img class="avatar-img rounded-circle" src="assets/img/patients/patient1.jpg" alt="User Image">
															</a>
															<a href="patient-profile.aspx">Charlene Reed <span>#PT0001</span></a>
														</h2>
													</td>
													<td>₹200</td>
													<td>13 Nov 2019</td>
													<td class="text-right">
														<div class="table-action">
															<a href="invoice-view.html" class="btn btn-sm bg-info-light">
																<i class="far fa-eye"></i> View
															</a>
															<a href="javascript:void(0);" class="btn btn-sm bg-primary-light">
																<i class="fas fa-print"></i> Print
															</a>
														</div>
													</td>
												</tr>
												
											</tbody>
										</table>
									</div>
									<!-- /Invoice Table -->
									
								</div>
							</div>
						</div>
</asp:Content>

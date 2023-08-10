using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode
{
    public class LBR_DAL
    {
        string strConnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public DataTable GetBooksData(string flag, string bookID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("pr_GetBookDetails", sqlCon);
                    cmd.Parameters.AddWithValue("@bookID", bookID.ToString());
                    cmd.Parameters.AddWithValue("@flag", flag.ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable GetBooksByUser(string userID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("pr_GetTransactionDetailsByUser", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userID.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public string SaveBookIssue(DataTable dt)
        {
            DataTable dtResult = new DataTable();
            string result = string.Empty;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("SP_Insert_BookIssue", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@tblBookIssue", dt);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtResult);
                    if (dtResult.Rows.Count > 0)
                    {
                        result = dtResult.Rows[0]["Result"].ToString();
                    }
                }
            }
            catch (Exception ex)
            { }
            return result;
        }
        public DataSet GetDropDownData()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("pr_GetSel_Rack_Data", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
            }
            catch (Exception ex)
            { }
            return ds;
        }
        public DataTable Getselfs(string rackID, string flag)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("pr_GetSels_ByRack_Data", sqlCon);
                    cmd.Parameters.Add("@rack_Section_ID", rackID.ToString());
                    cmd.Parameters.Add("@flag", flag.ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }


        public DataTable InserBookEntry(BookEntryDetails objBookEntryDetails)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Pr_InsertBookEntry", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_YearOPublish", objBookEntryDetails.yearOPublish.ToString());
                    cmd.Parameters.AddWithValue("@p_BookType", objBookEntryDetails.bookType.ToString());
                    cmd.Parameters.AddWithValue("@p_Place", objBookEntryDetails.place.ToString());
                    cmd.Parameters.AddWithValue("@p_Subject", objBookEntryDetails.subject.ToString());
                    cmd.Parameters.AddWithValue("@p_BookName", objBookEntryDetails.bookName.ToString());
                    cmd.Parameters.AddWithValue("@p_TotalPages", objBookEntryDetails.totalPages.ToString());
                    cmd.Parameters.AddWithValue("@p_ISBN", objBookEntryDetails.isbn.ToString());
                    cmd.Parameters.AddWithValue("@p_Volume", objBookEntryDetails.volume.ToString());
                    cmd.Parameters.AddWithValue("@p_Publisher", objBookEntryDetails.publisher.ToString());
                    cmd.Parameters.AddWithValue("@p_Price", objBookEntryDetails.price.ToString());
                    cmd.Parameters.AddWithValue("@p_NoOfBooks", objBookEntryDetails.noOfBooks.ToString());
                    cmd.Parameters.AddWithValue("@p_BillDate", objBookEntryDetails.billDate.ToString());
                    cmd.Parameters.AddWithValue("@p_Invoice", objBookEntryDetails.invoice.ToString());
                    cmd.Parameters.AddWithValue("@p_SupplierName", objBookEntryDetails.supplierName.ToString());
                    cmd.Parameters.AddWithValue("@p_SupContact", objBookEntryDetails.supContact.ToString());
                    cmd.Parameters.AddWithValue("@p_SupAddress", objBookEntryDetails.supAddress.ToString());
                    cmd.Parameters.AddWithValue("@p_SectionName", objBookEntryDetails.sectionName.ToString());
                    cmd.Parameters.AddWithValue("@p_RackName", objBookEntryDetails.RackName.ToString());
                    cmd.Parameters.AddWithValue("@p_NoOfSelfs", objBookEntryDetails.noOfSelf.ToString());
                    cmd.Parameters.AddWithValue("@p_NoOfBooksInSelfs", objBookEntryDetails.noOfBooksInSelf.ToString());
                    cmd.Parameters.AddWithValue("@p_Author", objBookEntryDetails.author.ToString());
                    cmd.Parameters.AddWithValue("@p_BookCover", objBookEntryDetails.bookCover.ToString());
                    cmd.Parameters.AddWithValue("@p_CreatedBy", objBookEntryDetails.createdBy.ToString());
                    cmd.Parameters.AddWithValue("@p_CreatedIP", objBookEntryDetails.userIP.ToString());
                    cmd.Parameters.AddWithValue("@p_Edition", objBookEntryDetails.Edition);
                    //cmd.ExecuteNonQuery();
                    //sqlCon.Close();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable GetBooksByMember(string MobileNo, string flag)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_GetBooksByMember", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MembershipMobileNo", MobileNo.ToString());
                    cmd.Parameters.AddWithValue("@flag", flag.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable InserBookReturn(BookReturnDetails objBookReturnDetails, PaymentTypeConformation objpayment)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Pr_InsertBookReturn", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", objBookReturnDetails.bookName.ToString());
                    cmd.Parameters.AddWithValue("@BookID", objBookReturnDetails.bookID.ToString());
                    cmd.Parameters.AddWithValue("@MembershipID", objBookReturnDetails.membershipID.ToString());
                    cmd.Parameters.AddWithValue("@AuthorName", objBookReturnDetails.authorName.ToString());
                    cmd.Parameters.AddWithValue("@SubmittedBy", objBookReturnDetails.submittedBy.ToString());
                    cmd.Parameters.AddWithValue("@NoOfBooks", objBookReturnDetails.noOfBooks.ToString());
                    cmd.Parameters.AddWithValue("@DateOfSubmit", Convert.ToDateTime(objBookReturnDetails.submitDate.ToString()));
                    cmd.Parameters.AddWithValue("@FineAmount", objBookReturnDetails.fineAmount.ToString());
                    cmd.Parameters.AddWithValue("@BookIssueID", objBookReturnDetails.bookIssueID.ToString());
                    cmd.Parameters.AddWithValue("@CreatedBy", objBookReturnDetails.createdBy.ToString());
                    cmd.Parameters.AddWithValue("@CreatedIP", objBookReturnDetails.userIP.ToString());
                    //  ------payment----------------
                    cmd.Parameters.AddWithValue("@PaymentIntiationpage", objpayment.PaymentIntiationpage);
                    cmd.Parameters.AddWithValue("@Paymentoff", objpayment.Paymentoff);
                    cmd.Parameters.AddWithValue("@PaymentType", objpayment.PaymentType);
                    cmd.Parameters.AddWithValue("@ReferenceID", objpayment.ReferenceID);
                    cmd.Parameters.AddWithValue("@nofnotes2000", objpayment.nofnotes2000);
                    cmd.Parameters.AddWithValue("@nofnotes500", objpayment.nofnotes500);
                    cmd.Parameters.AddWithValue("@nofnotes200", objpayment.nofnotes200);
                    cmd.Parameters.AddWithValue("@nofnotes100", objpayment.nofnotes100);
                    cmd.Parameters.AddWithValue("@nofnotes50", objpayment.nofnotes50);
                    cmd.Parameters.AddWithValue("@nofnotes20", objpayment.nofnotes20);
                    cmd.Parameters.AddWithValue("@nofnotes10", objpayment.nofnotes10);
                    cmd.Parameters.AddWithValue("@nofnotes1_2_5", objpayment.nofnotes1_2_5);
                    cmd.Parameters.AddWithValue("@PaymentStatus", objpayment.PaymentStatus);
                    cmd.Parameters.AddWithValue("@IsActive", objpayment.IsActive);
                    //cmd.ExecuteNonQuery();
                    //sqlCon.Close();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable InsertSupplierDet(SupplierDetails objSupplierDetails)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("pr_ins_and_Update_tbl_SupplierMaster", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupID", objSupplierDetails.supID.ToString());
                    cmd.Parameters.AddWithValue("@SupplierName", objSupplierDetails.supName.ToString());
                    cmd.Parameters.AddWithValue("@Mobile", objSupplierDetails.supMobileNo.ToString());
                    cmd.Parameters.AddWithValue("@Phone", objSupplierDetails.supPhoneNo.ToString());
                    cmd.Parameters.AddWithValue("@Email", objSupplierDetails.supEmail.ToString());
                    cmd.Parameters.AddWithValue("@Country", objSupplierDetails.supCountry.ToString());
                    cmd.Parameters.AddWithValue("@State", objSupplierDetails.supState.ToString());
                    cmd.Parameters.AddWithValue("@City", objSupplierDetails.supCity.ToString());
                    cmd.Parameters.AddWithValue("@Address", objSupplierDetails.supAddress.ToString());
                    cmd.Parameters.AddWithValue("@PAN", objSupplierDetails.supPan.ToString());
                    cmd.Parameters.AddWithValue("@GSTIN", objSupplierDetails.supGSTIN.ToString());
                    cmd.Parameters.AddWithValue("@CIN", objSupplierDetails.supCIN.ToString());
                    cmd.Parameters.AddWithValue("@Description", objSupplierDetails.supDescription.ToString());
                    cmd.Parameters.AddWithValue("@IsActive", objSupplierDetails.supIsActive.ToString());
                    cmd.Parameters.AddWithValue("@CreatedBy", objSupplierDetails.createdBy.ToString());
                    cmd.Parameters.AddWithValue("@CreatedIP", objSupplierDetails.userIP.ToString());
                    cmd.Parameters.AddWithValue("@flag", objSupplierDetails.flag);
                    //cmd.ExecuteNonQuery();
                    //sqlCon.Close();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable GetSupplierData(string flag, string supID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_GetSupplierData", sqlCon);
                    cmd.Parameters.AddWithValue("@SupID", supID.ToString());
                    cmd.Parameters.AddWithValue("@flag", flag.ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable GetPendingMembersList()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_GetPendingMembersList", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable AprrovePendingMembersList(string memberID, string modifyBy, string ModifyIP, string username)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_AprrovePendingMembers", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberID", Convert.ToInt32(memberID.ToString()));
                    cmd.Parameters.AddWithValue("@ModifyBy", modifyBy.ToString());
                    cmd.Parameters.AddWithValue("@ModifyIp", ModifyIP.ToString());
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@IsActive", "1");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable GetBankDet()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_GetBankAccountDetails", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable InserFeatureDetails(FeaturesDetails objFeaturesDetails)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Pr_Insert_Update_FeatureDetails", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FeatureID", objFeaturesDetails.featureID);
                    cmd.Parameters.AddWithValue("@AccountNo", objFeaturesDetails.featureBankAccount);
                    cmd.Parameters.AddWithValue("@FeatureName", objFeaturesDetails.featureName);
                    cmd.Parameters.AddWithValue("@FeatureType", objFeaturesDetails.featureType);
                    cmd.Parameters.AddWithValue("@Options", objFeaturesDetails.featureOptions);
                    cmd.Parameters.AddWithValue("@FeatureValues", objFeaturesDetails.featureValues);
                    cmd.Parameters.AddWithValue("@IsActive", objFeaturesDetails.featureIsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", objFeaturesDetails.createdBy);
                    cmd.Parameters.AddWithValue("@CreatedIP", objFeaturesDetails.userIP);
                    cmd.Parameters.AddWithValue("@flag", objFeaturesDetails.flag);
                    //cmd.ExecuteNonQuery();
                    //sqlCon.Close();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable GetFeaturesDetails(string featureID, string flag)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_Delete_GetFeaturesDetails", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FeatureID", featureID.ToString());
                    cmd.Parameters.AddWithValue("@flag", flag.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable InsertReceiptDetails(ReceiptDetails objReceiptDetails, PaymentTypeConformation objpayment)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Pr_Insert_Update_ReceiptDetails", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReceiptID", objReceiptDetails.receiptID);
                    cmd.Parameters.AddWithValue("@MemberID", objReceiptDetails.memberID);
                    cmd.Parameters.AddWithValue("@MemberName", objReceiptDetails.memberName);
                    cmd.Parameters.AddWithValue("@FeatureName", objReceiptDetails.featureName);
                    cmd.Parameters.AddWithValue("@Towards", objReceiptDetails.towards);
                    cmd.Parameters.AddWithValue("@TotalAmount", objReceiptDetails.totalAmount);
                    cmd.Parameters.AddWithValue("@FeatureOptions", objReceiptDetails.featureOptions);
                    cmd.Parameters.AddWithValue("@FeatureValue", objReceiptDetails.featureValues);
                    //  cmd.Parameters.AddWithValue("@PaymentType", objReceiptDetails.paymentType);
                    cmd.Parameters.AddWithValue("@TransactionID", objReceiptDetails.transactionID);
                    // cmd.Parameters.AddWithValue("@IsActive", objReceiptDetails.isActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", objReceiptDetails.createdBy);
                    cmd.Parameters.AddWithValue("@CreatedIP", objReceiptDetails.userIP);
                    cmd.Parameters.AddWithValue("@flag", objReceiptDetails.flag);
                    //  ------payment----------------
                    cmd.Parameters.AddWithValue("@PaymentIntiationpage", objpayment.PaymentIntiationpage);
                    cmd.Parameters.AddWithValue("@Paymentoff", objpayment.Paymentoff);
                    cmd.Parameters.AddWithValue("@PaymentType", objpayment.PaymentType);
                    cmd.Parameters.AddWithValue("@ReferenceID", objpayment.ReferenceID);
                    cmd.Parameters.AddWithValue("@nofnotes2000", objpayment.nofnotes2000);
                    cmd.Parameters.AddWithValue("@nofnotes500", objpayment.nofnotes500);
                    cmd.Parameters.AddWithValue("@nofnotes200", objpayment.nofnotes200);
                    cmd.Parameters.AddWithValue("@nofnotes100", objpayment.nofnotes100);
                    cmd.Parameters.AddWithValue("@nofnotes50", objpayment.nofnotes50);
                    cmd.Parameters.AddWithValue("@nofnotes20", objpayment.nofnotes20);
                    cmd.Parameters.AddWithValue("@nofnotes10", objpayment.nofnotes10);
                    cmd.Parameters.AddWithValue("@nofnotes1_2_5", objpayment.nofnotes1_2_5);
                    cmd.Parameters.AddWithValue("@PaymentStatus", objpayment.PaymentStatus);
                    cmd.Parameters.AddWithValue("@IsActive", objpayment.IsActive);
                    //cmd.ExecuteNonQuery();
                    //sqlCon.Close();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable GetInvoiceData(string flag, string type, string invoice)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_GetInvoiceDetails", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", invoice.ToString());
                    cmd.Parameters.AddWithValue("@type", type.ToString());
                    cmd.Parameters.AddWithValue("@flag", flag.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable GetEmployees(string flag, string empID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_GetEmployeeDetails", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_empID", empID.ToString());
                    cmd.Parameters.AddWithValue("@p_flag", flag.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable InsertEmployeeDetails(EmployeeDetails objEmployeeDetails)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_InsertEmployeeDetails", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_EmpID", objEmployeeDetails.empID);
                    cmd.Parameters.AddWithValue("@p_Name", objEmployeeDetails.Name);
                    cmd.Parameters.AddWithValue("@p_Designation", objEmployeeDetails.Designation);
                    cmd.Parameters.AddWithValue("@p_WorkedAt", objEmployeeDetails.workedAt);
                    cmd.Parameters.AddWithValue("@p_Qualification", objEmployeeDetails.qualification);
                    cmd.Parameters.AddWithValue("@p_BasicSalary", objEmployeeDetails.basicSalary);
                    cmd.Parameters.AddWithValue("@p_IsActive", objEmployeeDetails.isActive);
                    cmd.Parameters.AddWithValue("@p_CreatedBy", objEmployeeDetails.createdBy);
                    cmd.Parameters.AddWithValue("@p_CreatedIP", objEmployeeDetails.userIP);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }


        public DataTable GetBoardMembers(string flag, string BoardMemberID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_GetBoardMemberDetails", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_BoardMemberID", BoardMemberID.ToString());
                    cmd.Parameters.AddWithValue("@p_flag", flag.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable InsertBoardMemberDetails(BoardMemberDetails objBoardMemberDetails)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_InsertBoardMemberDetails", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_BoardOfMemberID", objBoardMemberDetails.boardMemberID);
                    cmd.Parameters.AddWithValue("@p_MemberName", objBoardMemberDetails.memberName);
                    cmd.Parameters.AddWithValue("@p_Designation", objBoardMemberDetails.designation);
                    cmd.Parameters.AddWithValue("@p_MobileNo", objBoardMemberDetails.mobileNo);
                    cmd.Parameters.AddWithValue("@p_EmailID", objBoardMemberDetails.emailID);
                    cmd.Parameters.AddWithValue("@p_Address", objBoardMemberDetails.address);
                    cmd.Parameters.AddWithValue("@p_Photo", objBoardMemberDetails.photo);
                    cmd.Parameters.AddWithValue("@p_IsActive", objBoardMemberDetails.isActive);
                    cmd.Parameters.AddWithValue("@p_CreatedBy", objBoardMemberDetails.createdBy);
                    cmd.Parameters.AddWithValue("@p_CreatedIP", objBoardMemberDetails.userIP);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataSet Get_SerchMembershiptype(string text)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_serch_BoardMember", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@text", text);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        public DataTable GetExpenditures(string type, string paymentPage)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_GetExpenditures", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_Type", type.ToString());
                    cmd.Parameters.AddWithValue("@p_PaymentPage", paymentPage.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataSet Get_SerchExpendituresMembers(string text, string expenditureType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_serch_ExpendituresMembers", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@text", text);
                    cmdsrc.Parameters.AddWithValue("@p_expenditureType", expenditureType);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataTable InsertNotifications(NotificationsDetails objNotificationsDetails)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_InsertNotifications", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_NotificationFk", objNotificationsDetails.notificationID);
                    cmd.Parameters.AddWithValue("@p_NotificationContent", objNotificationsDetails.notificationContent);
                    cmd.Parameters.AddWithValue("@p_Description", objNotificationsDetails.description);
                    cmd.Parameters.AddWithValue("@p_Fromdate", objNotificationsDetails.fromdate);
                    cmd.Parameters.AddWithValue("@p_Todate", objNotificationsDetails.todate);
                    cmd.Parameters.AddWithValue("@p_ImagePath", objNotificationsDetails.photo);
                    cmd.Parameters.AddWithValue("@p_IsActive", objNotificationsDetails.isActive);
                    cmd.Parameters.AddWithValue("@p_CreatedBy", objNotificationsDetails.createdBy);
                    cmd.Parameters.AddWithValue("@p_CreatedIP", objNotificationsDetails.userIP);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable InsertLatestNews(LatestNewsDetails objLatestNewsDetails)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_InsertLatestNews", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_NewsFk", objLatestNewsDetails.newsID);
                    cmd.Parameters.AddWithValue("@p_NewsContent", objLatestNewsDetails.newsContent);
                    cmd.Parameters.AddWithValue("@p_Description", objLatestNewsDetails.description);
                    cmd.Parameters.AddWithValue("@p_Fromdate", objLatestNewsDetails.fromdate);
                    cmd.Parameters.AddWithValue("@p_Todate", objLatestNewsDetails.todate);
                    cmd.Parameters.AddWithValue("@p_ImagePath", objLatestNewsDetails.photo);
                    cmd.Parameters.AddWithValue("@p_IsActive", objLatestNewsDetails.isActive);
                    cmd.Parameters.AddWithValue("@p_CreatedBy", objLatestNewsDetails.createdBy);
                    cmd.Parameters.AddWithValue("@p_CreatedIP", objLatestNewsDetails.userIP);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable GetNotificationData(string type, string notificationID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_get_Notifications", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_flag", type.ToString());
                    cmd.Parameters.AddWithValue("@p_ID", notificationID.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable GetLatestNews(string type, string newsID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_get_LatestNews", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_flag", type.ToString());
                    cmd.Parameters.AddWithValue("@p_ID", newsID.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataSet Get_SerchNotifications(string text)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("Pr_get_Search_Notifications", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@text", text);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        public DataSet Get_SerchLatestNews(string text)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("Pr_get_Search_LatestNews", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@text", text);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        public DataTable InsertExpanses(ExpansesDetails objExpansesDetails)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_Insert_Update_ExpansesDetails", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_ExpID", objExpansesDetails.expID);
                    cmd.Parameters.AddWithValue("@p_ExpName", objExpansesDetails.expName);
                    cmd.Parameters.AddWithValue("@p_Description", objExpansesDetails.description);
                    cmd.Parameters.AddWithValue("@p_Amount", objExpansesDetails.amount);
                    cmd.Parameters.AddWithValue("@p_SecretaryApprovedAmount", objExpansesDetails.secretaryApprovedAmount);
                    cmd.Parameters.AddWithValue("@p_TreasuryApprovedAmount", objExpansesDetails.treasuryApprovedAmount);
                    cmd.Parameters.AddWithValue("@p_BillDate", objExpansesDetails.billDate);
                    cmd.Parameters.AddWithValue("@p_SecretaryRemarks", objExpansesDetails.secretaryRemarks);
                    cmd.Parameters.AddWithValue("@p_TreasuryRemarks", objExpansesDetails.treasuryRemarks);
                    cmd.Parameters.AddWithValue("@p_IsActive", objExpansesDetails.isActive);
                    cmd.Parameters.AddWithValue("@p_CreatedBy", objExpansesDetails.createdBy);
                    cmd.Parameters.AddWithValue("@p_CreatedIP", objExpansesDetails.userIP);
                    cmd.Parameters.AddWithValue("@p_type", objExpansesDetails.type);
                    cmd.Parameters.AddWithValue("@p_Status", objExpansesDetails.status);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable GetExpensesData(string type, string expID, string createdBy)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_get_Expenses", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_flag", type.ToString());
                    cmd.Parameters.AddWithValue("@p_ID", expID.ToString());
                    cmd.Parameters.AddWithValue("@p_userID", createdBy.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable GetSearchExpensesData(string type, string createdBy, string textSearch)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_get_SearchExpenses", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_flag", type.ToString());
                    cmd.Parameters.AddWithValue("@p_userID", createdBy.ToString());
                    cmd.Parameters.AddWithValue("@p_text", textSearch.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable GetSearchInvoiceData(string textSearch)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_get_SearchInvoices", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_text", textSearch.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable GetUserServiceRequest(string type, string serID, string textSearch, string status, string ServiceName)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_GetUserServiceRequest", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_type", type.ToString());
                    cmd.Parameters.AddWithValue("@p_SerID", serID.ToString());
                    cmd.Parameters.AddWithValue("@P_text", textSearch.ToString());
                    cmd.Parameters.AddWithValue("@p_Status", status.ToString());
                    cmd.Parameters.AddWithValue("@p_ServiceName", ServiceName.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable UpdateServiceReqDetails(ServiceReqDetails objServiceReqDetails)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_UpdateUserServiceReque", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_serID", objServiceReqDetails.serID);
                    cmd.Parameters.AddWithValue("@p_CourierName", objServiceReqDetails.CourierName);
                    cmd.Parameters.AddWithValue("@p_CourierRefNumber", objServiceReqDetails.CourierRefNumber);
                    cmd.Parameters.AddWithValue("@p_CreatedBy", objServiceReqDetails.createdBy);
                    cmd.Parameters.AddWithValue("@p_CreatedIP", objServiceReqDetails.userIP);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable GetSearchFeaturesDetails(string textSearch)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_get_SearchFeatures", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_text", textSearch.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataTable SearchPendingMembers(string textSearch)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_SearchPendingMembers", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_text", textSearch.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataTable Get_SerchSupplier(string textSearch)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("Pr_SearchSuppliers", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_text", textSearch.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
    }
}
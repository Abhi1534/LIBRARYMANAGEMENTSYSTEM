using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode
{
    public class LBR_BAL
    {

    }

    public class BookEntryDetails
    {
        public string bookType { get; set; }
        public string bookName { get; set; }
        public string yearOPublish { get; set; }
        public string place { get; set; }
        public string subject { get; set; }
        public string totalPages { get; set; }
        public string isbn { get; set; }
        public string volume { get; set; }
        public string publisher { get; set; }
        public string price { get; set; }
        public string noOfBooks { get; set; }
        public string noOfBooksInSelf { get; set; }
        public string billDate { get; set; }
        public string invoice { get; set; }
        public string supplierName { get; set; }
        public string supContact { get; set; }
        public string supAddress { get; set; }
        public string sectionName { get; set; }
        public string RackName { get; set; }
        public string noOfSelf { get; set; }
        public string author { get; set; }
        public string bookCover { get; set; }
        public string createdBy { get; set; }
        public string userIP { get; set; }
        public string Edition { get; set; }
    }
    public class BookReturnDetails
    {
        public string bookName { get; set; }
        public string bookID { get; set; }
        public string membershipID { get; set; }
        public string submitDate { get; set; }
        public string submittedBy { get; set; }
        public string authorName { get; set; }
        public string userIP { get; set; }
        public string createdBy { get; set; }
        public string noOfBooks { get; set; }
        public string fineAmount { get; set; }
        public string bookIssueID { get; set; }


       

    }
    public class PaymentTypeConformation
    {
        public string MembershipID { get; set; }
        public string PaymentIntiationpage { get; set; }
        public string Paymentoff { get; set; }
        public string PaymentType { get; set; }
        public string Amount { get; set; }
        public string ReferenceID { get; set; }
        public string nofnotes2000 { get; set; }
        public string nofnotes500 { get; set; }
        public string nofnotes200 { get; set; }
        public string nofnotes100 { get; set; }
        public string nofnotes50 { get; set; }
        public string nofnotes20 { get; set; }
        public string nofnotes10 { get; set; }
        public string nofnotes1_2_5 { get; set; }
        public string PaymentStatus { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedIP { get; set; }
        public string IsActive { get; set; }
        public string flag { get; set; }
    }

    public class SupplierDetails
    {
        public string supID { get; set; }
        public string supName { get; set; }
        public string supMobileNo { get; set; }
        public string supPhoneNo { get; set; }
        public string supEmail { get; set; }
        public string supAddress { get; set; }
        public string supCountry { get; set; }
        public string supState { get; set; }
        public string supCity { get; set; }
        public string supPan { get; set; }
        public string supGSTIN { get; set; }
        public string supCIN { get; set; }
        public string supDescription { get; set; }
        public string supIsActive { get; set; }
        public string createdBy { get; set; }
        public string userIP { get; set; }
        public string flag { get; set; }
    }
    public class FeaturesDetails
    {
        public string featureID { get; set; }
        public string featureName { get; set; }
        public string featureBankAccount { get; set; }
        public string featureType { get; set; }
        public string featureOptions { get; set; }
        public string featureValues { get; set; }
        public string featureIsActive { get; set; }
        public string createdBy { get; set; }
        public string userIP { get; set; }
        public string flag { get; set; }
    }
    public class ReceiptDetails
    {
        public string receiptID { get; set; }
        public string memberID { get; set; }
        public string memberName { get; set; }
        public string featureOptions { get; set; }
        public string featureValues { get; set; }
        public string featureName { get; set; }
        public string isActive { get; set; }
        public string totalAmount { get; set; }
        public string towards { get; set; }
        public string paymentType { get; set; }
        public string transactionID { get; set; }
        public string createdBy { get; set; }
        public string userIP { get; set; }
        public string flag { get; set; }
    }
    public class EmployeeDetails
    {
        public string empID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string workedAt { get; set; }
        public string qualification { get; set; }
        public string basicSalary { get; set; }
        public string isActive { get; set; }
        public string createdBy { get; set; }
        public string userIP { get; set; }
    }
    public class BoardMemberDetails
    {
        public string boardMemberID { get; set; }
        public string memberName { get; set; }
        public string designation { get; set; }
        public string mobileNo { get; set; }
        public string emailID { get; set; }
        public string address { get; set; }
        public string photo { get; set; }
        public string isActive { get; set; }
        public string createdBy { get; set; }
        public string userIP { get; set; }
    }
    public class NotificationsDetails
    {
        public string notificationID { get; set; }
        public string description { get; set; }
        public string notificationContent { get; set; }
        public string isActive { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string photo { get; set; }
        public string createdBy { get; set; }
        public string userIP { get; set; }
    }

    public class ExpansesDetails
    {
        public string description { get; set; }
        public string expID { get; set; }
        public string expName { get; set; }
        public string amount { get; set; }
        public string isActive { get; set; }
        public string billDate { get; set; }
        public string createdBy { get; set; }
        public string userIP { get; set; }
        public string type { get; set; }
        public string secretaryApprovedAmount { get; set; }
        public string treasuryApprovedAmount { get; set; }
        public string secretaryRemarks { get; set; }
        public string treasuryRemarks { get; set; }
        public string status { get; set; }
    }
    public class LatestNewsDetails
    {
        public string newsID { get; set; }
        public string description { get; set; }
        public string newsContent { get; set; }
        public string isActive { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string photo { get; set; }
        public string createdBy { get; set; }
        public string userIP { get; set; }
    }

    public class ServiceReqDetails
    {
        public string serID { get; set; }
        public string CourierName { get; set; }
        public string CourierRefNumber { get; set; }       
        public string createdBy { get; set; }
        public string userIP { get; set; }
    }
}
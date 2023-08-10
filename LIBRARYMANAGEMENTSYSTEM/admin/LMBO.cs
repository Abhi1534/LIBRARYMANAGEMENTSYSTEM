using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIBRARYMANAGEMENTSYSTEM.admin
{
    public class LMBO
    {
        public class Membershiptypemaster
        {
            public string Membershiptype { get; set; }
            public string Subscription { get; set; }
            public string EntranceFee { get; set; }
            public string IdentityCard { get; set; }
            public string ApplicationForm { get; set; }
            public string Miscellaneous { get; set; }
            public string EntryIdentityCard { get; set; }
            public string totalfee { get; set; }
            public string Description { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedIP { get; set; }
            public string IsActive { get; set; }
            public string flag { get; set; }
            public string Membershiptypeid { get; set; }
            public string ModifyBy { get; set; }
            public string ModifyIp { get; set; }
            public string barcouncilenrollmentcerpath { get; set; }
            public string barcouncilIDpath { get; set; }
            public string photopath { get; set; }

        }
        public class RactSection
        {
            public string RackSectionName { get; set; }
            public string Description { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedIP { get; set; }
            public string IsActive { get; set; }
            public string ModifyBy { get; set; }
            public string ModifyIp { get; set; }
            public string SecMID { get; set; }
            public string flag { get; set; }

        }
        public class Subject
        {
            public string SubjectName { get; set; }
            public string Description { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedIP { get; set; }
            public string IsActive { get; set; }
            public string ModifyBy { get; set; }
            public string ModifyIp { get; set; }
            public string SubjectID { get; set; }
            public string flag { get; set; }

        }

        public class RactMaster
        {
            public string SectionName { get; set; }
            public string RackName { get; set; }
            public string NumberofSelfs { get; set; }
            public string Description { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedIP { get; set; }
            public string IsActive { get; set; }

            public string ModifyBy { get; set; }
            public string ModifyIp { get; set; }
            public string RackID { get; set; }
            public string flag { get; set; }
        }
        public class SelfMasteradd
        {
            public string SectionName { get; set; }
            public string RackName { get; set; }
            public string NumberofSelfs { get; set; }
            public string NumberofBooks { get; set; }
            public string Description { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedIP { get; set; }
            public string IsActive { get; set; }

        }
        public class MemberShipRegistration
        {
            public string AdvocateName { get; set; }
            public string Gender { get; set; }
            public string MobileNumber { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public string State { get; set; }
            public string Email { get; set; }
            public string DOB { get; set; }
            public string BloodGroup { get; set; }
            public string EnrollmentDate { get; set; }
            public string enrollmentNumber { get; set; }
            public string MembershipType { get; set; }
            public string MembershipDate { get; set; }
            public string MembershipFee { get; set; }
            public string VehicleNumber { get; set; }
            public string Vote { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedIP { get; set; }
            public string IsActive { get; set; }
            public string barcouncilenrollmentcerpath { get; set; }
            public string barcouncilIDpath { get; set; }
            public string photopath { get; set; }
            public string Certificateofpracticepath { get; set; }
            public string flag { get; set; }
            public string ModifyBy { get; set; }
            public string ModifyIp { get; set; }
            public string MemberID { get; set; }

            public string ClerkName { get; set; }
            public string ClerkMobileNumber { get; set; }
        }

        public class PaymentConformation
        {
            public string MembershipID { get; set; }
            public string MembershipType { get; set; }
            public string Membershipvalue { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedIP { get; set; }
            public string flag { get; set; }
            public string ReferenceID { get; set; }
            public string PaymentType { get; set; }
            public string InoviceNum { get; set; }

        }

        public class PaymentStamps
        {
            public string Name { get; set; }
            public string MobileNumber { get; set; }
            public string Email { get; set; }
            public string PaymentIntiationpage { get; set; }
            public string NumberOfStamps { get; set; }
            public string StampPrice { get; set; }
            public string PaymentType { get; set; }
            public string TotalPrice { get; set; }
            public string ReferenceID { get; set; }
            public string PaymentStatus { get; set; }
            public string enrollmentNumber { get; set; }
            public string IsActive { get; set; }
            public string flag { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedIP { get; set; }
            public string NameofStamp { get; set; }
            public string ResAddress { get; set; }
            public string IssuedStatus { get; set; }
        }

        public class Addmaster
        {
            public string AddType { get; set; }
            public string AddName { get; set; }
            public string AddAmount { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string addcontent { get; set; }
            public string PhotoPath { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedIp { get; set; }
            public string Isactive { get; set; }
            public string flag { get; set; }
            public string AddID { get; set; }
            public string ModifyBy { get; set; }
            public string ModifyIp { get; set; }

        }

        public class UserServiceRequest
        {
            public string ServiceName { get; set; }
            public string MemberID { get; set; }
            public string MemberName { get; set; }
            public string MobileNumber { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string DOB { get; set; }
            public string BloodGroup { get; set; }
            public string EnrolementID { get; set; }
            public string EnrolementDate { get; set; }
            public string MembershipType { get; set; }
            public string MembershipDate { get; set; }
            public string DeliveryType { get; set; }
            public string Amount { get; set; }
            public string DeliveryStatus { get; set; }
            public string CourierRefNumber { get; set; }
            public string CourierName { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedIp { get; set; }
            public string Isactive { get; set; }
            public string flag { get; set; }
            public string PaymentReferenceID { get; set; }
            public string PaymentStatus { get; set; }
        }


        public class VehicalRequest
        {
            public string MemberID { get; set; }
            public string VehicalType { get; set; }
            public string VehicalNumber { get; set; }

            public string CreatedBy { get; set; }
            public string CreatedIp { get; set; }

        }
        public class Body
        {
            public ResultInfo resultInfo { get; set; }
            public string qrCodeId { get; set; }
            public string qrData { get; set; }
            public string image { get; set; }
        }
        public class PayMentResponse
        {
            public Head head { get; set; }
            public Body body { get; set; }
        }

        public class Head
        {
            public string responseTimestamp { get; set; }
            public string version { get; set; }
            public string clientId { get; set; }
            public string signature { get; set; }
        }

        public class ResultInfo
        {
            public string resultStatus { get; set; }
            public string resultCode { get; set; }
            public string resultMsg { get; set; }
        }

        public class Root
        {
            public Head head { get; set; }
            public Body body { get; set; }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class PaymentStatusBody
        {
            public PaymentStatusResultInfo resultInfo { get; set; }
            public string txnId { get; set; }
            public string bankTxnId { get; set; }
            public string orderId { get; set; }
            public string txnAmount { get; set; }
            public string txnType { get; set; }
            public string gatewayName { get; set; }
            public string bankName { get; set; }
            public string mid { get; set; }
            public string paymentMode { get; set; }
            public string refundAmt { get; set; }
            public string txnDate { get; set; }
            public string merchantUniqueReference { get; set; }
            public string posId { get; set; }
            public string udf1 { get; set; }
        }

        public class PaymentStatusHead
        {
            public string responseTimestamp { get; set; }
            public string version { get; set; }
            public string signature { get; set; }
        }

        public class PaymentStatusResultInfo
        {
            public string resultStatus { get; set; }
            public string resultCode { get; set; }
            public string resultMsg { get; set; }
        }

        public class PaymentStatusResponse
        {
            public PaymentStatusHead head { get; set; }
            public PaymentStatusBody body { get; set; }
        }



        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Amount
        {
            [JsonProperty("Amount payment amount")]
            public string Amountpaymentamount { get; set; }

            [JsonProperty("Amount currency")]
            public string Amountcurrency { get; set; }
        }

        public class CheckBody
        {
            public CheckResultInfo resultInfo { get; set; }
            public string merchantId { get; set; }
            public string merchantName { get; set; }
            public List<Order> orders { get; set; }
        }

        public class CheckHead
        {
            public object version { get; set; }
            public string timestamp { get; set; }
            public object channelId { get; set; }
            public string tokenType { get; set; }
            public object clientId { get; set; }
        }

        public class Order
        {
            public string txnId { get; set; }
            public string orderId { get; set; }
            public string mercUniqRef { get; set; }
            public string orderCreatedTime { get; set; }
            public string orderCompletedTime { get; set; }
            public string orderType { get; set; }
            public string orderStatus { get; set; }
            public string customerName { get; set; }
            public double txnAmount { get; set; }
            public string customerComment { get; set; }
            public PaymentFormData paymentFormData { get; set; }
        }

        public class PaymentFormData
        {
            public Amount Amount { get; set; }
        }

        public class CheckResultInfo
        {
            public string resultStatus { get; set; }
            public string resultCode { get; set; }
            public string resultMessage { get; set; }
        }

        public class CheckResponse
        {
            public CheckHead head { get; set; }
            public CheckBody body { get; set; }
        }



        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class LinkBody
        {
            public string merchantRequestId { get; set; }
            public int linkId { get; set; }
            public string linkType { get; set; }
            public string longUrl { get; set; }
            public string shortUrl { get; set; }
            public double amount { get; set; }
            public string expiryDate { get; set; }
            public bool isActive { get; set; }
            public string merchantHtml { get; set; }
            public string createdDate { get; set; }
            public List<NotificationDetail> notificationDetails { get; set; }
            public LinkResultInfo resultInfo { get; set; }
        }

        public class LinkHead
        {
            public object version { get; set; }
            public string timestamp { get; set; }
            public object channelId { get; set; }
            public string tokenType { get; set; }
            public object clientId { get; set; }
        }

        public class NotificationDetail
        {
            public string customerName { get; set; }
            public string contact { get; set; }
            public string notifyStatus { get; set; }
            public string timestamp { get; set; }
        }

        public class LinkResultInfo
        {
            public string resultStatus { get; set; }
            public string resultCode { get; set; }
            public string resultMessage { get; set; }
        }

        public class CreateLinkResponse
        {
            public LinkHead head { get; set; }
            public LinkBody body { get; set; }
        }





    }
}
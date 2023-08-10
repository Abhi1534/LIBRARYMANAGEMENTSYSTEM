using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM.admin
{
    public class LMBAL
    {
        LMDAL DBDAL = new LMDAL();
        public DataSet INSMembershiptype(Membershiptypemaster objmtm)
        {
            return DBDAL.INSMembershiptype(objmtm);
        }
        public DataSet GETALLMembershiptype()
        {
            return DBDAL.GETALLMembershiptype();
        }
        public DataSet INSRacksection(RactSection objrs)
        {
            return DBDAL.INSRacksection(objrs);
        }
        public DataSet INSSubjectMaster(Subject objrs)
        {
            return DBDAL.INSSubjectMaster(objrs);
        }
        public DataSet GETALLRacksection()
        {
            return DBDAL.GETALLRacksection();
        }
        public DataSet INSRacksMaster(RactMaster objrs)
        {
            return DBDAL.INSRacksMaster(objrs);
        }
        public DataSet GETALLRacksMaster()
        {
            return DBDAL.GETALLRacksMaster();
        }
        public DataSet Pr_GetALLselfMaster()
        {
            return DBDAL.Pr_GetALLselfMaster();
        }
        public DataSet Pr_Getsectionbyrackname(string SectionID)
        {
            return DBDAL.Pr_Getsectionbyrackname(SectionID);
        }
        public DataSet INSMembershipRegistration(MemberShipRegistration objrs)
        {
            return DBDAL.INSMembershipRegistration(objrs);
        }
        public DataSet pr_getmembershiptypebyfee(string Membershiptypeid)
        {
            return DBDAL.pr_getmembershiptypebyfee(Membershiptypeid);
        }
        public DataSet pr_get_logindetails(string Username, string Password)
        {
            return DBDAL.pr_get_logindetails(Username, Password);
        }

        public DataSet pr_get_logindetails_otp(string Username)
        {
            return DBDAL.pr_get_logindetails_otp(Username);
        }

        public DataSet Pr_GetRacknamebysection(string SectionID)
        {
            return DBDAL.Pr_GetRacknamebysection(SectionID);
        }
        public DataSet GETSelfsbyRack(string section, string Rack)
        {
            return DBDAL.GETSelfsbyRack(section, Rack);
        }
        public DataSet INSselfmaster(SelfMasteradd objrs)
        {
            return DBDAL.INSselfmaster(objrs);
        }
        public DataSet pr_get_serch_membershiptype(string text)
        {
            return DBDAL.pr_get_serch_membershiptype(text);
        }
        public DataSet pr_get_membershiptypeMasterbyid(string MEMID)
        {
            return DBDAL.pr_get_membershiptypeMasterbyid(MEMID);
        }
        public DataSet pr_get_serch_SectionMaster(string text)
        {
            return DBDAL.pr_get_serch_SectionMaster(text);
        }
        public DataSet pr_get_Sectionmasterbyid(string SecMID)
        {
            return DBDAL.pr_get_Sectionmasterbyid(SecMID);
        }
        public DataSet pr_getindidvalmembershipdata(string Emailid, string mobilenumber)
        {
            return DBDAL.pr_getindidvalmembershipdata(Emailid, mobilenumber);
        }
        public DataSet pr_getmemberdata()
        {
            return DBDAL.pr_getmemberdata();
        }

        public DataSet GetMembersExcelData()
        {
            return DBDAL.GetMembersExcelData();
        }
        public DataSet pr_get_Searchmembershipregistration(string text)
        {
            return DBDAL.pr_get_Searchmembershipregistration(text);
        }
        public DataSet pr_get_Dashboarddata(string fromdate, string todate)
        {
            return DBDAL.pr_get_Dashboarddata(fromdate, todate);
        }
        public DataSet pr_get_serch_RackMaster(string text)
        {
            return DBDAL.pr_get_serch_RackMaster(text);
        }
        public DataSet pr_get_Rackmasterbyid(string RackID)
        {
            return DBDAL.pr_get_Rackmasterbyid(RackID);
        }
        public DataSet pr_get_serch_Selfmaster(string text)
        {
            return DBDAL.pr_get_serch_Selfmaster(text);
        }
        public DataSet pr_get_serch_Subjectmaster(string text)
        {
            return DBDAL.pr_get_serch_Subjectmaster(text);
        }
        public DataSet pr_get_Subjectmasterbyid(string SubID)
        {
            return DBDAL.pr_get_Subjectmasterbyid(SubID);
        }
        public DataSet pr_get_allSubjectmaster()
        {
            return DBDAL.pr_get_allSubjectmaster();
        }
        public DataSet pr_get_SelfmasterbyID(string SelID)
        {
            return DBDAL.pr_get_SelfmasterbyID(SelID);
        }
        //public DataSet pr_ins_and_Update_tbl_PaymentConformation(PaymentConformation objpay)
        //{
        //    return DBDAL.pr_ins_and_Update_tbl_PaymentConformation(objpay);
        //}
        public DataSet pr_get_INVNum_auto()
        {
            return DBDAL.pr_get_INVNum_auto();
        }
        public DataSet pr_get_memberregistrationbyid(string memberID)
        {
            return DBDAL.pr_get_memberregistrationbyid(memberID);
        }
        public DataSet pr_get_serachbookname(string text)
        {
            return DBDAL.pr_get_serachbookname(text);
        }
        public DataSet pr_get_booknamebyid(string BookID)
        {
            return DBDAL.pr_get_booknamebyid(BookID);
        }
        public DataSet InsertPaymentDetails(PaymentTypeConformation objpay)
        {
            return DBDAL.InsertPaymentDetails(objpay);
        }
        public DataSet pr_get_BookSerialNoid(string BookSerialNo)
        {
            return DBDAL.pr_get_BookSerialNoid(BookSerialNo);
        }
        public DataSet pr_updatepassword(string password, string UserName)
        {
            return DBDAL.pr_updatepassword(password, UserName);
        }
        public DataSet InsertstampsPaymentDetails(PaymentStamps objstamps)
        {
            return DBDAL.InsertstampsPaymentDetails(objstamps);
        }
        public DataSet pr_getstampsamount(string InoviceNum)
        {
            return DBDAL.pr_getstampsamount(InoviceNum);
        }
        public DataSet pr_ins_and_Update_tbl_AddsMaster(Addmaster objaddmaster)
        {
            return DBDAL.pr_ins_and_Update_tbl_AddsMaster(objaddmaster);
        }
        public DataSet pr_get_AddsMaster(string AddID, string flag, string Text)
        {
            return DBDAL.pr_get_AddsMaster(AddID, flag, Text);
        }
        public DataSet pr_ins_and_Update_Tbl_UserServiceRequest(UserServiceRequest objaddmaster)
        {
            return DBDAL.pr_ins_and_Update_Tbl_UserServiceRequest(objaddmaster);
        }
        public DataSet pr_ins_VehicalNumber(VehicalRequest objreq)
        {
            return DBDAL.pr_ins_VehicalNumber(objreq);
        }
        public DataSet pr_getbarcodebookdetails(string flag, string BookID)
        {
            return DBDAL.pr_getbarcodebookdetails(flag, BookID);
        }
        public DataSet pr_get_Stamps_list(string flag, string InoviceNum, string Status)
        {
            return DBDAL.pr_get_Stamps_list(flag, InoviceNum, Status);
        }
        public DataSet pr_get_membershipwisememberdata(string MembershipType)
        {
            return DBDAL.pr_get_membershipwisememberdata(MembershipType);
        }
        public DataSet pr_get_latestnews_image(string flag, string NewsID)
        {
            return DBDAL.pr_get_latestnews_image(flag, NewsID);
        }

        public DataSet pr_get_otp()
        {
            return DBDAL.pr_get_otp();
        }
        public DataSet GetIDCardDetailsbyMobileNo(string mobileNo)
        {
            return DBDAL.GetIDCardDetailsbyMobileNo(mobileNo);
        }
    }
}
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM.admin
{
    public partial class PaymentConformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PageIntiateforpayment"] != null && !string.IsNullOrWhiteSpace(Session["PageIntiateforpayment"].ToString()))
                {
                    if (Session["PageIntiateforpayment"].ToString()== "WelfareStamps" || Session["PageIntiateforpayment"].ToString() == "CourtStamps" || Session["PageIntiateforpayment"].ToString() == "JudicialStamps" || Session["PageIntiateforpayment"].ToString() == "Donations")
                    {
                        paymentinitiationStamps();
                    }
                  
                    else
                    {
                        paymentinitiation();
                    }
                }
               
               

            }

        }
        public void paymentinitiation()
        {
            if (Session["membershipfee"] != null && !string.IsNullOrWhiteSpace(Session["membershipfee"].ToString()))
            {
                PaymentTypeConformation objpayment = new PaymentTypeConformation();
                LMBAL objbal = new LMBAL();

                objpayment.MembershipID = Session["MemberID"].ToString();
                objpayment.PaymentIntiationpage = Session["PageIntiateforpayment"].ToString();
                objpayment.Paymentoff = Session["MembershiptypeName"].ToString();
                objpayment.PaymentType = "Online";
                objpayment.Amount = Session["membershipfee"].ToString();
                objpayment.ReferenceID = "";
                objpayment.nofnotes2000 = "";
                objpayment.nofnotes500 = "";
                objpayment.nofnotes200 = "";
                objpayment.nofnotes100 = "";
                objpayment.nofnotes50 = "";
                objpayment.nofnotes20 = "";
                objpayment.nofnotes10 = "";
                objpayment.nofnotes1_2_5 = "";
                objpayment.PaymentStatus = "Success";
                objpayment.CreatedBy = Session["MemberID"].ToString();
                objpayment.CreatedIP = Request.ServerVariables["Remote_Addr"];
                objpayment.IsActive = "0";
                objpayment.flag = "1";
                DataSet ds = new DataSet();
                ds = objbal.InsertPaymentDetails(objpayment);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["result"].ToString() == "Success")
                    {
                        lbl_paymentstatus.Text = "Payment Successfully!";
                    }
                }
            }
        }


        public void paymentinitiationStamps()
        {
            if (Session["membershipfee"] != null && !string.IsNullOrWhiteSpace(Session["membershipfee"].ToString()))
            {
                PaymentStamps objpayment = new PaymentStamps();
                LMBAL objbal = new LMBAL();
                objpayment.Name = Session["MembershipName"].ToString();
                objpayment.MobileNumber = Session["Membershipmobilenumber"].ToString();
                objpayment.Email = Session["MembershipEmailID"].ToString();
                objpayment.PaymentIntiationpage = Session["PageIntiateforpayment"].ToString();
                objpayment.NumberOfStamps = Session["MembershiptypeName"].ToString();
                objpayment.StampPrice = Session["Stampprice"].ToString();
                objpayment.PaymentType = "Online";
                objpayment.TotalPrice = Session["membershipfee"].ToString();
                objpayment.ReferenceID ="";
                objpayment.PaymentStatus = "Success";
                objpayment.CreatedBy = Session["MemberID"].ToString();
                objpayment.CreatedIP = Request.ServerVariables["Remote_Addr"];
                objpayment.enrollmentNumber = Session["MemberID"].ToString();
                objpayment.IsActive = "0";
                objpayment.flag = "1";
                objpayment.IssuedStatus = "0";
                if (Session["ResAddress"] != null && !string.IsNullOrWhiteSpace(Session["ResAddress"].ToString()))
                {
                    objpayment.ResAddress = Session["ResAddress"].ToString();
                }
                else
                {
                    objpayment.ResAddress = "";
                }

                if (Session["NameofStamp"] != null && !string.IsNullOrWhiteSpace(Session["NameofStamp"].ToString()))
                {
                    objpayment.NameofStamp = Session["NameofStamp"].ToString();
                }
                else
                {
                    objpayment.NameofStamp = "";
                }
                DataSet ds = new DataSet();
                ds = objbal.InsertstampsPaymentDetails(objpayment);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["result"].ToString() == "Success")
                    {
                        lbl_paymentstatus.Text = "Payment Successfully!";
                    }
                }
            }
        }


     


        protected void btn_view_Click(object sender, EventArgs e)
        {

            Response.Redirect("PaymentInvioce.aspx");
        }
    }
}
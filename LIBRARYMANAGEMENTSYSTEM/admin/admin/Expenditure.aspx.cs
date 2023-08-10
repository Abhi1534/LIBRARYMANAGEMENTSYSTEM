using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class Expenditure : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            if (!Page.IsPostBack)
            {
                BindData();
                bindstampdetail();
            }
        }
        public void BindData()
        {
            DataTable dt = objDal.GetExpenditures("1","");
            int regAmount = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PaymentIntiationpage"].ToString().Contains("Registration"))
                    {
                        regAmount += Convert.ToInt32(dt.Rows[i]["Amount"].ToString());
                        lbl_noofRegistrations.Text = regAmount.ToString();
                    }
                    else if (dt.Rows[i]["PaymentIntiationpage"].ToString().Contains("Book"))
                    {
                        lbl_Library.Text = dt.Rows[i]["Amount"].ToString();
                    }
                    else if (dt.Rows[i]["PaymentIntiationpage"].ToString()=="Receipt")
                    {
                        lbl_Receipts.Text = dt.Rows[i]["Amount"].ToString();
                    }
                    else if (dt.Rows[i]["PaymentIntiationpage"].ToString()=="Donation Receipt")
                    {
                        lbl_Donation.Text = dt.Rows[i]["Amount"].ToString();
                    }
                    //else if (dt.Rows[i]["PaymentIntiationpage"].ToString().Contains("Stamps"))
                    //{
                    //    lbl_Stamps.Text = dt.Rows[i]["Amount"].ToString();
                    //}
                }
            }
        }

        public void bindstampdetail()
        {
            LMBAL objbal = new LMBAL();
            string innum = "";
            DataSet ds = objbal.pr_getstampsamount(innum);
            if (ds.Tables[0].Rows.Count>0)
            {
                lbl_WelfareStamps.Text= ds.Tables[0].Rows[0]["WelfareAmount"].ToString();
            }
            else
            {
                lbl_WelfareStamps.Text = "0";
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                lbl_CourtStamps.Text = ds.Tables[2].Rows[0]["CourtAmount"].ToString();
            }
            else
            {
                lbl_CourtStamps.Text = "0";
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                lbl_Donation.Text = ds.Tables[8].Rows[0]["DonationsAmount"].ToString();
            }

            }

        protected void lnkReg_Click(object sender, EventArgs e)
        {
            Session["ExpenditureType"] = "Registration";
            Response.Redirect("ExpenditureDetails.aspx");
        }

        protected void lnkBook_Click(object sender, EventArgs e)
        {
            Session["ExpenditureType"] = "Book Return";
            Response.Redirect("ExpenditureDetails.aspx");
        }      

        protected void lnkDonation_Click(object sender, EventArgs e)
        {
            Session["ExpenditureType"] = "Donation";
            Response.Redirect("ExpenditureDetails.aspx");
        }

        protected void lnkReceipt_Click(object sender, EventArgs e)
        {
            Session["ExpenditureType"] = "Receipt";
            Response.Redirect("ExpenditureDetails.aspx");
        }

       

        protected void lbtn_WelfareStamps_Click(object sender, EventArgs e)
        {
            Session["ExpenditureType"] = "WelfareStamp";
            Session["PageIntiateforpayment"] = "WelfareStamp";
            Response.Redirect("ExpenditureDetails.aspx");
        }

        protected void lbtn_CourtStamps_Click(object sender, EventArgs e)
        {
            Session["ExpenditureType"] = "CourtStamps";
            Session["PageIntiateforpayment"] = "CourtStamps";
            Response.Redirect("ExpenditureDetails.aspx");
        }
    }
}
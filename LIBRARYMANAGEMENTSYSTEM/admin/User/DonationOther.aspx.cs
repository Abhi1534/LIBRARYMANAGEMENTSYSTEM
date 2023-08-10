using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class DonationOther : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (Session["ChallanCaptcha"] != null && txtCaptcha.Text == Session["ChallanCaptcha"].ToString())
            {
                PaymentStamps objpay = new PaymentStamps();
                objpay.Name = txt_Advocatename.Text;
                objpay.MobileNumber = txt_MobileNumber.Text;
                objpay.Email = txt_email.Text;
                objpay.enrollmentNumber = "";
                objpay.NumberOfStamps = txt_Description.Text;
                objpay.TotalPrice = txt_price.Text;
                objpay.ResAddress = "";
                objpay.NameofStamp = "";
                Session["MemberID"] = "0";
                Session["MembershipName"] = txt_Advocatename.Text;
                Session["MembershipEmailID"] = txt_email.Text;
                Session["Membershipmobilenumber"] = txt_MobileNumber.Text;
                Session["membershipfee"] = txt_price.Text;
                Session["PageIntiateforpayment"] = "Donations";
                Session["MembershiptypeName"] = "0";
                Session["headofinvoice"] = "";
                Session["NameofStamp"] = txt_Description.Text;
                Session["Stampprice"] = "0";
                Response.Redirect("../../PaytmPaymentInitiation.aspx");
            }
            else
            {
                txtCaptcha.Text = string.Empty;
                lblerrorMsg.Visible = true;
                lblerrorMsg.Text = "Please Enter Valid Captcha";
            }
        }

        //protected void txt_numberofstamps_TextChanged(object sender, EventArgs e)
        //{
        //    if (txt_numberofstamps.Text != "")
        //    {
        //        int num = Convert.ToInt32(txt_numberofstamps.Text);

        //        int price = Convert.ToInt32(num * 100);
        //        txt_price.Text = Convert.ToString(price);
        //    }
        //    else
        //    {
        //        txt_price.Text = "";
        //    }

        //}
    }
}
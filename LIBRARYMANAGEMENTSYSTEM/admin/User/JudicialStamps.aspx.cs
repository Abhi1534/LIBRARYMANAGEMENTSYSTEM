using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class JudicialStamps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                objpay.NumberOfStamps = txt_numberofstamps.Text;
                objpay.TotalPrice = txt_price.Text;
                objpay.ResAddress = txt_residenceaddress.Text;
                objpay.NameofStamp = txt_nameonstamppaper.Text;
                Session["MemberID"] = "0";
                Session["MembershipName"] = txt_Advocatename.Text;
                Session["MembershipEmailID"] = txt_email.Text;
                Session["Membershipmobilenumber"] = txt_MobileNumber.Text;
                Session["membershipfee"] = txt_price.Text;
                Session["PageIntiateforpayment"] = "JudicialStamps";
                Session["MembershiptypeName"] = txt_numberofstamps.Text;
                Session["headofinvoice"] = "No Of Stamps";
                Session["Stampprice"] = ddl_stamptype.SelectedItem.Text;
                Session["ResAddress"] = txt_residenceaddress.Text;
                Session["NameofStamp"] = txt_nameonstamppaper.Text;
                Response.Redirect("../../PaytmPaymentInitiation.aspx");
            }
            else
            {
                txtCaptcha.Text = string.Empty;
                lblerrorMsg.Visible = true;
                lblerrorMsg.Text = "Please Enter Valid Captcha";
            }
        }

        protected void txt_numberofstamps_TextChanged(object sender, EventArgs e)
        {
            if (ddl_stamptype.SelectedItem.Text != "")
            {
                int amount = Convert.ToInt32(ddl_stamptype.SelectedItem.Text);
                int noofqun = Convert.ToInt32(txt_numberofstamps.Text);
                int total = amount * noofqun;
                txt_price.Text = Convert.ToString(total);
            }
        }
    }
}
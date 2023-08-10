using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class PracticeCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getuser();
                bindmembershiptype();
            }
        }
        protected void ddl_MemberShipType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void getuser()
        {
            LMBAL bal = new LMBAL();
            string memberid = Session["MemberID"].ToString();
            DataSet ds = bal.pr_get_memberregistrationbyid(memberid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_Advocatename.Text = ds.Tables[0].Rows[0]["AdvocateName"].ToString();
                if (Session["DOB"] != null && !string.IsNullOrWhiteSpace(Session["DOB"].ToString()))
                {
                    txt_dob.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToString("yyyy-MM-dd");
                }
                ddl_Bloodgroup.SelectedItem.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                txt_email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txt_MobileNumber.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                txt_address.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                string photopath = ds.Tables[0].Rows[0]["photopath"].ToString();
                Session["Photofilepath"] = ds.Tables[0].Rows[0]["photopath"].ToString();
                txt_enrollmentdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EnrollmentDate"].ToString()).ToString("yyyy-MM-dd");
                txt_enrollmentnumber.Text = ds.Tables[0].Rows[0]["EnrollmentNumber"].ToString();
                ddl_MemberShipType.SelectedValue = ds.Tables[0].Rows[0]["MembershipType"].ToString();
                txt_membershipdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["MembershipDate"].ToString()).ToString("yyyy-MM-dd");
            }

        }
        public void bindmembershiptype()
        {

            LMBAL objMaster = new LMBAL();
            ddl_MemberShipType.Items.Clear();
            DataSet dt_Set = objMaster.GETALLMembershiptype();
            if (dt_Set.Tables[0].Rows.Count > 0)
            {
                ddl_MemberShipType.DataSource = dt_Set.Tables[0];
                ddl_MemberShipType.DataTextField = "MembershipTypeName";
                ddl_MemberShipType.DataValueField = "MemID";
                ddl_MemberShipType.DataBind();
                ddl_MemberShipType.Items.Insert(0, new ListItem("Select MemberShip Type", "0"));

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Membership Type not loading')", true);
            }

        }
        protected void rb_deliverytype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rb_deliverytype.SelectedItem.Text == "Post")
            {
                lbl_deliverynote.Visible = true;
                int sum = Convert.ToInt32(txt_price.Text) + 50;
                txt_price.Text = Convert.ToString(sum);
            }
            else
            {
                lbl_deliverynote.Visible = false;
                txt_price.Text = "200";
            }

        }
        protected void btn_payment_Click(object sender, EventArgs e)
        {
            UserServiceRequest objreq = new UserServiceRequest();
            objreq.ServiceName = "Practice Certificate";
            objreq.MemberID = Session["MemberID"].ToString();
            objreq.MemberName = txt_Advocatename.Text;
            objreq.MobileNumber = txt_MobileNumber.Text;
            objreq.Email = txt_email.Text;
            objreq.Address = txt_address.Text;
            Session["txt_address"] = txt_address.Text;
            objreq.DOB = txt_dob.Text;
            Session["DOB"] = txt_dob.Text;
            objreq.BloodGroup = ddl_Bloodgroup.SelectedItem.Text;
            Session["BloodGroup"] = ddl_Bloodgroup.SelectedItem.Text;
            objreq.EnrolementID = txt_enrollmentnumber.Text;
            Session["txt_enrollmentnumber"] = txt_enrollmentnumber.Text;
            objreq.EnrolementDate = txt_enrollmentdate.Text;
            Session["txt_enrollmentdate"] = txt_enrollmentdate.Text;
            objreq.MembershipType = ddl_MemberShipType.SelectedItem.Text;
            Session["ddl_MemberShipType"] = ddl_MemberShipType.SelectedItem.Text;
            objreq.MembershipDate = txt_membershipdate.Text;
            Session["txt_membershipdate"] = txt_membershipdate.Text;
            objreq.DeliveryType = rb_deliverytype.SelectedItem.Text;
            objreq.Amount = txt_price.Text;
            objreq.DeliveryStatus = "Pending";
            objreq.CourierRefNumber = "";
            objreq.CourierName = "";
            objreq.CreatedBy = Session["MemberID"].ToString();
            objreq.CreatedIp = Request.ServerVariables["Remote_Addr"];
            objreq.Isactive = "1";
            objreq.flag = "1";
            objreq.PaymentReferenceID = "";
            objreq.PaymentStatus = "Success";
            Session["UserServiceRequest"] = objreq;
            Session["MembershippersonID"] = Session["MemberID"].ToString();
            Session["MembershipName"] = txt_Advocatename.Text;
            Session["MembershipEmailID"] = txt_email.Text;
            Session["Membershipmobilenumber"] = txt_MobileNumber.Text;
            Session["membershipfee"] = txt_price.Text;
            Session["PageIntiateforpayment"] = "Practice Certificate";
            Response.Redirect("PaytmPaymentInitiation.aspx");

        }
    }
}
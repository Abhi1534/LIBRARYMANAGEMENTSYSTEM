using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM.admin
{
    public partial class Idcard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_name.Text = Session["MembershipName"].ToString();
                lbl_Enrolementid.Text = Session["txt_enrollmentnumber"].ToString();
                lbl_EnrolementidDate.Text = Session["txt_enrollmentdate"].ToString();
                lbl_membershipname.Text = Session["ddl_MemberShipType"].ToString();
                lbl_dob.Text = Session["DOB"].ToString();
                lbl_bloodgroup.Text = Session["BloodGroup"].ToString();
                lbl_mobilenumber.Text = Session["Membershipmobilenumber"].ToString();
                lbl_email.Text = Session["MembershipEmailID"].ToString();
                lbl_address.Text = Session["txt_address"].ToString();
                lbl_membershipdate.Text = Session["txt_membershipdate"].ToString();
                img_profile.Src= Session["userphotopath"].ToString();
            }
        }
    }
}
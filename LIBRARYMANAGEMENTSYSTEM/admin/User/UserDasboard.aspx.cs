using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class UserDasboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getuser();
                bindmembershiptype();
            }
        }
        public void getuser()
        {
            LMBAL bal = new LMBAL();
            string memberid = Session["MemberID"].ToString();
            DataSet ds = bal.pr_get_memberregistrationbyid(memberid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_Name.Text = ds.Tables[0].Rows[0]["AdvocateName"].ToString();
                if (Session["DOB"] != null && !string.IsNullOrWhiteSpace(Session["DOB"].ToString()))
                {
                    txt_dob.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToString("yyyy-MM-dd");
                }
                txt_Bloodgroup.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                txt_email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txt_mobile.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
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
        protected string PhotoBase64ImgSrc(string fileNameandPath)
        {
            string base64 = string.Empty;
            try
            {
                byte[] byteArray = File.ReadAllBytes(fileNameandPath);
                base64 = Convert.ToBase64String(byteArray);
            }
            catch (Exception ex)
            {
            }

            return string.Format("data:image/gif;base64,{0}", base64);
        }
    }
}
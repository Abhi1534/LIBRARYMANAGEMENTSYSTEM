using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            if (!IsPostBack)
            {
                getuser();
            }
        }
        public void getuser()
        {
            LMBAL bal = new LMBAL();
            string memberid = Session["MemberID"].ToString();
            DataSet ds = bal.pr_get_memberregistrationbyid(memberid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_profilename.Text = ds.Tables[0].Rows[0]["AdvocateName"].ToString();
                lbl_pname.Text = ds.Tables[0].Rows[0]["AdvocateName"].ToString();
                lbl_pemail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                lbl_email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                lbl_mobile.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                lbl_dob.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToString("yyyy-MM-dd");
                lbl_Address.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txt_Name.Text = ds.Tables[0].Rows[0]["AdvocateName"].ToString();
                if (ds.Tables[0].Rows[0]["DOB"] != null && !string.IsNullOrWhiteSpace(ds.Tables[0].Rows[0]["DOB"].ToString()))
                {
                    txt_dob.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToString("yyyy-MM-dd");
                }    
                txt_email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txt_mobile.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                txt_address.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                if (ds.Tables[0].Rows[0]["photopath"] != null && !string.IsNullOrWhiteSpace(ds.Tables[0].Rows[0]["photopath"].ToString()))
                {
                    string photopath = ds.Tables[0].Rows[0]["photopath"].ToString();
                    Session["Photofilepath"] = ds.Tables[0].Rows[0]["photopath"].ToString();
                    img_photoupload.ImageUrl =photopath;
                    img_photoupload.Visible = true;
                }
               
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
        protected void btn_passwordsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string username = Session["MobileNumber"].ToString();
                string password = txt_oldpassword.Text;
                LMBAL bal = new LMBAL();
                DataSet ds = bal.pr_get_logindetails(username, password);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string newpassword = txt_password.Text;
                    DataSet ds1 = bal.pr_updatepassword(newpassword, username);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        div_success.Visible = true;
                        div_fail.Visible = false;
                    }
                    else
                    {
                        div_success.Visible = false;
                        div_fail.Visible = true;
                    }
                }
                else
                {

                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void btn_upadateDetails_Click(object sender, EventArgs e)
        {
            MemberShipRegistration objrs = new MemberShipRegistration();

            objrs.AdvocateName = txt_Name.Text;
            objrs.Gender = "";
            objrs.MobileNumber = txt_mobile.Text;
            objrs.PhoneNumber = "";
            objrs.Address = txt_address.Text;
            objrs.State = "";
            objrs.Email = txt_email.Text;
            objrs.DOB = txt_dob.Text;
            objrs.BloodGroup = "";
            objrs.EnrollmentDate = "";
            objrs.MembershipType = "";
            objrs.MembershipDate = "";
            objrs.MembershipFee = "";
            objrs.VehicleNumber = "";
            objrs.Vote = "";
            objrs.CreatedBy = "";
            objrs.CreatedIP = "";
            objrs.enrollmentNumber = "";
            objrs.IsActive = "1";
            objrs.barcouncilenrollmentcerpath = "";
            objrs.barcouncilIDpath = "";
            objrs.ClerkName = txt_ClerkName.Text;
            objrs.ClerkMobileNumber = txt_clerkmobilenumber.Text;
            if (Session["Photofilepath"] != null && !string.IsNullOrWhiteSpace(Session["Photofilepath"].ToString()))
            {
                objrs.photopath = Session["Photofilepath"].ToString();
            }
            else
            {
                objrs.photopath = "";
            }
            objrs.flag = "3";
            objrs.CreatedBy = "";
            objrs.CreatedIP = "";
            objrs.ModifyBy = Session["MemberID"].ToString();
            objrs.ModifyIp = Request.ServerVariables["Remote_Addr"];
            objrs.MemberID = Session["MemberID"].ToString();

            LMBAL objbal = new LMBAL();
            DataSet ds = new DataSet();
            ds = objbal.INSMembershipRegistration(objrs);
            if (ds.Tables[0].Rows[0]["result"].ToString() == "Success")
            {
                div_success.Visible = true;
            }
        }
    }
}
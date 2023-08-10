using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class IDCardDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {
                Response.Redirect("../SessionExpired.aspx");
            }
            if (!IsPostBack)
            {
                pnlIDCard.Visible = false;
                pnlSearch.Visible = true;
                txt_search.Text = "";
                btn_back.Visible = false;
                div_fail.Visible = false;
            }
        }
        public void getuser()
        {
            LMBAL bal = new LMBAL();
            if (!string.IsNullOrEmpty(txt_search.Text))
            {
                DataSet ds = bal.GetIDCardDetailsbyMobileNo(txt_search.Text);
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
                    txt_enrollmentdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EnrollmentDate"].ToString()).ToString("yyyy-MM-dd");
                    txt_enrollmentnumber.Text = ds.Tables[0].Rows[0]["EnrollmentNumber"].ToString();
                    txt_lbl_membershiptype.Text = ds.Tables[0].Rows[0]["MembershipTypeName"].ToString();
                    txt_membershipdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["MembershipDate"].ToString()).ToString("yyyy-MM-dd");
                    string photopath = ds.Tables[0].Rows[0]["photopath"].ToString();
                    Session["Photofilepath"] = ds.Tables[0].Rows[0]["photopath"].ToString();
                    img_photoupload.ImageUrl = ds.Tables[0].Rows[0]["photopath"].ToString();
                    txt_clerkname.Text = ds.Tables[0].Rows[0]["ClerkName"].ToString();
                    txt_ClerkMobilenumber.Text = ds.Tables[0].Rows[0]["ClerkMobileNumber"].ToString();
                    BarQRCodeGenerator.BarQRGenerator objIBar = new BarQRCodeGenerator.BarQRGenerator();
                   string qrCodeUrl= ConfigurationManager.AppSettings["QRCodeUrl"].ToString() + ds.Tables[0].Rows[0]["MemberID"].ToString(); //HttpContext.Current.Request.Url.AbsoluteUri;
                    byte[] bytes = objIBar.GenerateQRCodeByteArray(qrCodeUrl.ToString(), "");
                    string base64 = Convert.ToBase64String(bytes);
                    QRCode.ImageUrl = string.Format("data:image/gif;base64,{0}", base64);
                    //ImageGeneratedBarcode.Visible = true;


                    
                    pnlIDCard.Visible = true;
                    pnlSearch.Visible = false;
                    txt_search.Text = "";
                    div_fail.Visible = false;
                    btn_back.Visible = true;
                }
                else
                {
                    pnlIDCard.Visible = false;
                    pnlSearch.Visible = true;
                    txt_search.Text = "";
                    div_fail.Visible = true;
                    btn_back.Visible = false;

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Mobile Number')", true);
                    return;
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

        protected void btn_back_Click(object sender, EventArgs e)
        {
            pnlIDCard.Visible = false;
            pnlSearch.Visible = true;
            txt_search.Text = "";
            btn_back.Visible = false;
            div_fail.Visible = false;
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            getuser();
        }
    }
}
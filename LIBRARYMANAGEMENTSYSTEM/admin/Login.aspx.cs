using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.IO;
using System.Text;

namespace LIBRARYMANAGEMENTSYSTEM.admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();

            }

        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            div_success.Visible = false;
            div_fail.Visible = false;
            div_otpwrong.Visible = false;
            string username = txt_Mobilenumber.Text;
            string password = txt_password.Text;
            DataSet ds = new DataSet();
            LMBAL bal = new LMBAL();
            if (username != null && !string.IsNullOrWhiteSpace(username) && password != null && !string.IsNullOrWhiteSpace(password))
            {
                ds = bal.pr_get_logindetails(username, password);
                Session["ValidateMobilenumber"] = "";
            }

            if (Session["ValidateMobilenumber"] != null && !string.IsNullOrWhiteSpace(Session["ValidateMobilenumber"].ToString()))
            {
                if (txt_otp.Text==Session["Loginotp"].ToString())
                {
                    ds = bal.pr_get_logindetails_otp(username);
                }
                else
                {
                    btn_loginwithotp.Visible = true;
                    div_otpwrong.Visible = true;
                    txt_otp.Focus();
                    return;
                }
               
            }

            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["RoleID"] != null && !string.IsNullOrWhiteSpace(ds.Tables[0].Rows[0]["RoleID"].ToString()))
                {


                    if (cb_Remember.Checked == true)
                    {
                        Response.Cookies["username"].Value = txt_Mobilenumber.Text;
                        Response.Cookies["password"].Value = txt_password.Text;
                    }
                    string MemberID = ds.Tables[0].Rows[0]["MemberID"].ToString();
                    Session["MemberID"] = MemberID;
                    string Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    Session["Email"] = ds.Tables[0].Rows[0]["Email"].ToString();
                    string Gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                    Session["Gender"] = ds.Tables[0].Rows[0]["Gender"].ToString();
                    string MembershipType = ds.Tables[0].Rows[0]["MembershipType"].ToString();
                    Session["MembershipType"] = ds.Tables[0].Rows[0]["MembershipType"].ToString();
                    string MobileNumber = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    Session["MobileNumber"] = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    string AdvocateName = ds.Tables[0].Rows[0]["AdvocateName"].ToString();

                    string DOB = ds.Tables[0].Rows[0]["DOB"].ToString();
                    Session["DOB"] = ds.Tables[0].Rows[0]["DOB"].ToString();

                    string Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    Session["Address"] = ds.Tables[0].Rows[0]["Address"].ToString();
                    Session["BloodGroup"] = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                    Session["AdvocateName"] = ds.Tables[0].Rows[0]["AdvocateName"].ToString();
                    Session["userphotopath"] = ds.Tables[0].Rows[0]["photopath"].ToString();
                    int Isactive = Convert.ToInt32(ds.Tables[0].Rows[0]["Isactive"].ToString());
                    Response.Redirect("../admin/User/UserDasboard.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Account Deactivate please contanct Admin.')", true);
                    return;
                   

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Incorrect UserName or Password..!')", true);
                return;

            }
        }

        protected void lnkRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/User/SelfMemberRegistraion.aspx");
        }

        protected void btn_loginwithotp_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txt_Mobilenumber.Text != "")
                {
                    LMBAL obj = new LMBAL();
                    DataSet ds = obj.pr_get_otp();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string otp = ds.Tables[0].Rows[0]["OTP"].ToString();
                        //if (txt_otp.Text == otp.ToString())
                        //{
                        message();
                        //Session["ValidateMobilenumber"] = txt_Mobilenumber.Text;
                        //    Session["Loginotp"] = otp;
                        div_success.Visible = true;
                        //}

                        //string sAPIKey = "rUmg2YSTEkSvPaN3SKxu5A";
                        //string sSenderID = "SLNSVD";
                        //string sChannel = "2";
                        //string sDCS = "0";
                        //string sFlashsms = "0";
                        //string sNumber = txt_email.Text;

                        //string sMessage = "Your OTP" +otp+ "to access for Login Dashboard. Please do not share this with any one. THCAA - SLNSVD";
                        ////string sURL = "https://www.smsgatewayhub.com/api/mt/SendSMS?APIKey=" + sAPIKey + "&senderid=" + sSenderID + "&channel=" + sChannel + "&DCS=" + sDCS + "&flashsms=" + sFlashsms + "&number=" + sNumber + "&text=" + sMessage + "&route=0";
                        //string sURL = "https://www.smsgatewayhub.com/api/mt/SendSMS?APIKey=" + sAPIKey + "&senderid=" + sSenderID + "&channel=" + sChannel + "&DCS=" + sDCS + "&flashsms=" + sFlashsms + "&number=" + sNumber + "&text=" + sMessage + "&route=0";
                        //// string sURL = "https://smsmaa.com/SMS_API/sendsms.php?username=evnredkrl&password=KRL999&mobile=" + sNumber + "&sendername=EVNRED&message=" + sMessage + "&routetype=1";
                        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
                        //request.MaximumAutomaticRedirections = 4;
                        //request.Credentials = CredentialCache.DefaultCredentials;
                        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        //Stream receiveStream = response.GetResponseStream();
                        //StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                        //string sResponse = readStream.ReadToEnd();
                        //div_success.Visible = true;
                        btn_loginwithpassword.Visible = true;
                        btn_loginwithotp.Visible = false;
                        div_fail.Visible = false;
                        txt_password.Visible = false;
                        txt_otp.Visible = true;

                    }
                    else
                    {

                    }

                }
                else
                {
                    div_fail.Visible = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void message() {
            string sAPIKey = "rUmg2YSTEkSvPaN3SKxu5A";
            string sSenderID = "EVNRED";//  "NREDCA";
            string sChannel = "2";
            string sDCS = "0";
            string sFlashsms = "0";
            string sNumber = txt_Mobilenumber.Text;
            int OTPNumber = new Random().Next(1000, 9999);
            Session["ValidateMobilenumber"] = txt_Mobilenumber.Text;
            Session["Loginotp"] = OTPNumber;
            string sMessage = "Dear User,Your OTP for login portal is '" + OTPNumber.ToString() + "'. Please do not share this OTP.Regards,EV-NREDCAP";
          
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
         
            string sURL = "https://www.smsgatewayhub.com/api/mt/SendSMS?APIKey=" + sAPIKey + "&senderid=" + sSenderID + "&channel=" + sChannel + "&DCS=" + sDCS + "&flashsms=" + sFlashsms + "&number=" + sNumber + "&text=" + sMessage + "&route=0";


            Uri uri = new Uri(sURL, UriKind.Absolute);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string sResponse = readStream.ReadToEnd();
           // TempData["Otp"] = OTPNumber.ToString();
            response.Close();
            readStream.Close();
            string Otpsent = OTPNumber.ToString();
           // return Otpsent;
        }

        protected void btn_loginwithpassword_Click(object sender, EventArgs e)
        {
            try
            {
                txt_password.Visible = true;
                txt_otp.Visible = false;
                btn_loginwithpassword.Visible = false;
                btn_loginwithotp.Visible = true;
                div_fail.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
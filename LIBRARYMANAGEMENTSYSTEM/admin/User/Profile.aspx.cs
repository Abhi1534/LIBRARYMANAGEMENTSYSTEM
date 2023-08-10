using LIBRARYMANAGEMENTSYSTEM.admin.admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                txt_Name.Text = ds.Tables[0].Rows[0]["AdvocateName"].ToString(); 
                if (Session["DOB"] != null && !string.IsNullOrWhiteSpace(Session["DOB"].ToString()))
                {
                    txt_dob.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToString("yyyy-MM-dd");
                }
                ddl_Bloodgroup.SelectedValue = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                txt_email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txt_mobile.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                txt_address.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                string photopath = ds.Tables[0].Rows[0]["photopath"].ToString();
                Session["Photofilepath"] = ds.Tables[0].Rows[0]["photopath"].ToString();
                img_photoupload.ImageUrl = photopath;
                img_photoupload.Visible = true;
                txt_ClerkName.Text= ds.Tables[0].Rows[0]["ClerkName"].ToString();
                txt_clerkmobilenumber.Text = ds.Tables[0].Rows[0]["ClerkMobileNumber"].ToString();
            }
           
        }
        protected void btn_passwordsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //string username = Session["Email"].ToString();
                //string password = txt_oldpassword.Text;
                //LMBAL bal = new LMBAL();
                //DataSet ds = bal.pr_get_logindetails(username, password);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    string newpassword = txt_password.Text;
                //    DataSet ds1 = bal.pr_updatepassword(newpassword, username);
                //    if (ds1.Tables[0].Rows.Count > 0)
                //    {
                //        div_success.Visible = true;
                //        div_fail.Visible = false;
                //       // MailCoustmer();
                //        //freeconsultantMessageTeam();
                //    }
                //    else
                //    {
                //        div_success.Visible = false;
                //        div_fail.Visible = true;
                //    }
                // }
                //else
                //{

                //}


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void freeconsultantMessageTeam()
        {
            string messtext = "Dear " + Environment.NewLine + Environment.NewLine +

                                   "Mr/Mrs." + Session["AdvocateName"].ToString() + Environment.NewLine + Environment.NewLine + "Password Change Successfully.If your not please contact admin team." + Environment.NewLine +
                                  Environment.NewLine



                                  + Environment.NewLine + "Thank You." + Environment.NewLine + "THCAA." + Environment.NewLine;
            string sndname = "BUSERL";
            string mess = "http://sms.bulksmsind.in/sendSMS?username=gvrinfosystems&message=" + messtext + "&sendername=" + sndname + "&smstype=TRANS&numbers=" + 918121191086 + "&apikey=55d44c71-3d4c-4b6b-a0ca-30f46963be83";

            System.Net.WebRequest request = System.Net.WebRequest.Create(mess);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();
            Response.Write("Sent");

        }
        private void MailCoustmer()
        {
            MailMessage myMail = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            string MailID = ConfigurationManager.AppSettings["MailID"].ToString();
            string Password = ConfigurationManager.AppSettings["Password"].ToString();
            myMail.From = new MailAddress(MailID);
            myMail.To.Add(Session["Email"].ToString());

            myMail.Subject = "Telengana High Court Advocates Association";
            myMail.IsBodyHtml = true;
            myMail.AlternateViews.Add(Mail_Body_Coustmer());
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(MailID, Password);
            smtp.EnableSsl = true;
            smtp.Send(myMail);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Details send Successfully Please check your Email')", true);
        }
        private AlternateView Mail_Body_Coustmer()
        {
            // string path = Server.MapPath(@"images/emaillogo.jpeg");
            // LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            // Img.ContentId = "MyImage";
            string str = @"<div>" +
           "<br>" +
            "<table width='100%'>" +
                " <tr>" +
                     "<td align='center' style='background - color: white'>" +
                            "<h1>" + "Welcome To Telengana High Court Advocates Association" + "</h1>" +
                                   "<img src=cid:MyImage  id='img' alt='' width='100px' height='100px'/> " + "<br>" +
                                   "<br>" +
                              " </td>" +

                           "</tr>" +

                           "<tr align='center'>" +

                                "<td>" + "<br>" +

                       "Dear" + "<h2>" + Session["AdvocateName"].ToString() + "</h2>" +

                   " </td>" +

                    "<tr align = 'center'>" +
                       " <td>" +

                           "<br>" + "Password Update Successfully. If your not please contact admin team." +
                            "<br>" +
                       " </td>" +
                   " </tr>" +
                    "<tr>" +
                       "<td align = 'center'>" +
                            "<br>" +
                           " <br>" +

                            "Thank you for Your Choose THCAA" +

                    "</tr>" +
           " </table>" +
            "<div>";


            AlternateView AV =
            AlternateView.CreateAlternateViewFromString(str, null, MediaTypeNames.Text.Html);
            // AV.LinkedResources.Add(Img);
            return AV;
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
        public static string GetUploadFolderPath(string MainModule, string SubModule, string type, string mailid)
        {
            string folderpath = string.Empty;
           // string UploadFolderPath = ConfigurationManager.AppSettings["Docpath"].ToString();
            StringBuilder strUploadBuilder = new StringBuilder();
            strUploadBuilder.AppendFormat(@"Sharepath\{0}\{1}\{2}\{3}\", MainModule, SubModule, type, mailid);
            CreateFolder(strUploadBuilder.ToString());
            return strUploadBuilder.ToString();

        }
        public static string GetviewUploadFolderPath(string MainModule, string SubModule, string type, string mailid, string filename)
        {
            string folderpath = string.Empty;
            string UploadFolderPath = ConfigurationManager.AppSettings["Docviewpath"].ToString();
            StringBuilder strUploadBuilder = new StringBuilder(UploadFolderPath);
            strUploadBuilder.AppendFormat(@"{0}/{1}/{2}/{3}/{4}", MainModule, SubModule, type, mailid, filename);
            //CreateFolder(strUploadBuilder.ToString());

            return strUploadBuilder.ToString();

        }
        private static void CreateFolder(string path)
        {
            try
            {

                System.IO.DirectoryInfo dirInfo = new DirectoryInfo(@path);
                //Models.Logger.Log("GenEmployerCode API :: CreateFolder chk exists", dirInfo.ToString());

                if (!dirInfo.Exists)

                {  // Models.Logger.Log("GenEmployerCode API :: inside folder check", "");
                    CreateFolder(Directory.GetParent(path).FullName);
                }


                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btn_photoupload_Click(object sender, EventArgs e)
        {
            if (fu_photoupload.HasFiles)
            {
                foreach (HttpPostedFile postedfile in fu_photoupload.PostedFiles)
                {
                    string CreatedIP = Request.ServerVariables["Remote_Addr"];
                    string useid = Session["MemberID"].ToString();
                    string fileName = Path.GetFileName(postedfile.FileName);

                    if (postedfile.ContentLength > 0)
                    {
                        Savedocs obj = new Savedocs();
                        obj.Impersonate("123");
                        string date1 = DateTime.Now.ToString("dd-MM-yyyy");
                        //string file_full_path = GetUploadFolderPath("GVR", "MembershipRegistraion", "Photo", "customers");
                        string file_full_path = Path.Combine("../../Sharepath", "GVR","MembershipRegistraion","Photo", "customers");
                        file_full_path = Path.Combine(file_full_path, fileName);
                        Session["Photofilepath"] = file_full_path;
                        Session["PhotofileName"] = fileName;
                        postedfile.SaveAs(Server.MapPath(file_full_path));
                        img_photoupload.ImageUrl = file_full_path;
                        img_photoupload.Visible = true;
                    }
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
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
            objrs.BloodGroup = ddl_Bloodgroup.SelectedItem.Text;
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
            objrs.Certificateofpracticepath = "";
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
                getuser();
            }

        }
    }
}
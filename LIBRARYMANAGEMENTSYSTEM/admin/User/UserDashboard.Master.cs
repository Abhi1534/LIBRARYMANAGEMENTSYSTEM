using LIBRARYMANAGEMENTSYSTEM.admin.admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class UserDashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            if (!IsPostBack)
            {
                getuserdetails();
            }
        }

        public void getuserdetails()
        {
            LMBAL bal = new LMBAL();
            string memberid = Session["MemberID"].ToString();
            DataSet ds = bal.pr_get_memberregistrationbyid(memberid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_username.Text = ds.Tables[0].Rows[0]["AdvocateName"].ToString();
                lbl_address.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                lbl_Dob.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToString("dd-MM-yyyy");
                string photopath = ds.Tables[0].Rows[0]["photopath"].ToString();
                Session["Photofilepath"] = ds.Tables[0].Rows[0]["photopath"].ToString();
                img_photoupload.ImageUrl = photopath;
                img_photoupload.Visible = true;
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



        protected void btnImageUpload_Click(object sender, EventArgs e)
        {
            try
            {


              //  hfFileName.Value = FileUploadImage.PostedFile.FileName;
                if (hfFileName.Value != "")

                {
                    //foreach (HttpPostedFile postedfile in FileUploadImage.PostedFiles)
                    //{
                    string CreatedIP = Request.ServerVariables["Remote_Addr"];
                    // string useid = Session["MemberID"].ToString();
                    //string fileName = Path.GetFileName(postedfile.FileName);
                    string fileName = hfFileName.Value;
                    //if (postedfile.ContentLength > 0)
                    //{
                    Savedocs obj = new Savedocs();
                    obj.Impersonate("123");
                    string date1 = DateTime.Now.ToString("dd-MM-yyyy");
                    string file_full_path = Path.Combine("../../Sharepath", "GVR", "MembershipRegistraion", "Photo", Session["Email"].ToString());
                    file_full_path = Path.Combine(file_full_path, fileName);
                    Session["Photofilepath"] = file_full_path;
                    Session["PhotofileName"] = fileName;
                    // postedfile.SaveAs(file_full_path);
                  //  string uploadFilePath = hfUploadFilePath.Value;
                    byte[] bytes = File.ReadAllBytes(file_full_path);
                    File.WriteAllBytes(file_full_path, bytes);

                    // hfFileName.
                    img_photoupload.ImageUrl = file_full_path;
                    img_photoupload.Visible = true;


                    //    }

                    //}

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static string GetUploadFolderPath(string MainModule, string SubModule, string type, string mailid)
        {
            string folderpath = string.Empty;
            string UploadFolderPath = ConfigurationManager.AppSettings["Docpath"].ToString();
            StringBuilder strUploadBuilder = new StringBuilder(UploadFolderPath);
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
    }
}
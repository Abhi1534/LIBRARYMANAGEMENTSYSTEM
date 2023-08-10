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
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class AddsMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            if (!IsPostBack)
            {
                bindgriddata();
            }
        }
        public void bindgriddata()
        {
            LMBAL objMaster = new LMBAL();
            DataSet ds = objMaster.pr_get_AddsMaster("","1","");
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid_data.DataSource = ds;
                grid_data.DataBind();
            }

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = true;
            pnl_view.Visible = false;
            btn_back.Visible = true;
            btn_add.Visible = false;
            txt_search.Visible = false;
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddsMaster.aspx");
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> SearchText(string prefixText, int count)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_AddsMaster("", "3", prefixText);
            List<string> address = new List<string>();

            foreach (DataRow row in dt_Set.Tables[0].Rows)
            {
                address.Add(row["AddName"].ToString());

            }
            return address;
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_AddsMaster("","3",txt_search.Text);
            grid_data.DataSource = dt_Set;
            grid_data.DataBind();
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            if (fu_photo.HasFiles)

            {
                foreach (HttpPostedFile postedfile in fu_photo.PostedFiles)
                {
                    string CreatedIP = Request.ServerVariables["Remote_Addr"];
                    string useid = Session["MemberID"].ToString();
                    string fileName = Path.GetFileName(postedfile.FileName);

                    if (postedfile.ContentLength < 2097152)
                    {
                        Savedocs obj = new Savedocs();
                        obj.Impersonate("123");
                        string date1 = DateTime.Now.ToString("dd-MM-yyyy");

                        //string file_full_path = GetUploadFolderPath("GVR", "ADDS", "Photo");
                        string file_full_path = Path.Combine("../../Sharepath", "GVR", "ADDS", "Photo");
                        file_full_path = Path.Combine(file_full_path, fileName);
                        Session["Photofilepath"] = file_full_path;
                        Session["PhotofileName"] = fileName;
                        postedfile.SaveAs(Server.MapPath(file_full_path));
                        img_addphoto.ImageUrl = file_full_path;
                        img_addphoto.Visible = true;


                    }

                }

            }
        }
        public static string GetUploadFolderPath(string MainModule, string SubModule, string type)
        {
            string folderpath = string.Empty;
            string UploadFolderPath = ConfigurationManager.AppSettings["Docpath"].ToString();
            StringBuilder strUploadBuilder = new StringBuilder(UploadFolderPath);
            strUploadBuilder.AppendFormat(@"Sharepath\{0}\{1}\{2}\", MainModule, SubModule, type);
            CreateFolder(strUploadBuilder.ToString());
            return strUploadBuilder.ToString();

        }
        public static string GetviewUploadFolderPath(string MainModule, string SubModule, string type, string mailid)
        {
            string folderpath = string.Empty;
            string UploadFolderPath = ConfigurationManager.AppSettings["Docviewpath"].ToString();
            StringBuilder strUploadBuilder = new StringBuilder(UploadFolderPath);
            strUploadBuilder.AppendFormat(@"{0}/{1}/{2}/{3}/", MainModule, SubModule, type, mailid);
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
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                Addmaster objmtm = new Addmaster();
                objmtm.AddType = ddl_addtype.SelectedItem.Text;
                objmtm.AddName = txt_addname.Text;
                objmtm.AddAmount = txt_addamount.Text;
                objmtm.StartDate = txt_StartDate.Text;
                objmtm.EndDate = txt_enddate.Text;
                objmtm.addcontent = txt_addcontent.Text;
                if (Session["Photofilepath"] != null && !string.IsNullOrWhiteSpace(Session["Photofilepath"].ToString()))
                {
                    objmtm.PhotoPath = Session["Photofilepath"].ToString();
                }
                else
                {
                    objmtm.PhotoPath = "";
                }
              
               
                objmtm.Isactive = "1";
                if (Session["AddID"] != null && !string.IsNullOrWhiteSpace(Session["AddID"].ToString()))
                {
                    objmtm.flag = "2";
                    objmtm.CreatedBy = "";
                    objmtm.CreatedIp = "";
                    objmtm.ModifyBy = Session["MemberID"].ToString();
                    objmtm.ModifyIp = Request.ServerVariables["Remote_Addr"];
                    objmtm.AddID = Session["AddID"].ToString();
                }
                else
                {
                    objmtm.flag = "1";
                    objmtm.CreatedBy = Session["MemberID"].ToString();
                    objmtm.CreatedIp = Request.ServerVariables["Remote_Addr"];
                    objmtm.ModifyBy = "";
                    objmtm.ModifyIp = "";
                    objmtm.AddID = "";
                }

                DataSet ds = new DataSet();
                LMBAL objbal = new LMBAL();
                ds = objbal.pr_ins_and_Update_tbl_AddsMaster(objmtm);

                if (ds.Tables[0].Rows[0]["result"].ToString() == "Success")
                {
                    div_success.Visible = true;
                   
                }
                else
                {
                    div_fail.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}
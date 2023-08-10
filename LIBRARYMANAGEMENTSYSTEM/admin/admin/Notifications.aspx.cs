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
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class Notifications : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
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

            DataTable dt = objDal.GetNotificationData("1", "0");
            if (dt.Rows.Count > 0)
            {
                grid_data.DataSource = dt;
                grid_data.DataBind();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["Imagefilepath"] != null)
            {
                string CreatedIP = Request.ServerVariables["Remote_Addr"];
                NotificationsDetails objNotifications = new NotificationsDetails();
                objNotifications.description = txtdescription.Text;
                objNotifications.notificationContent = txtContent.Text;
                objNotifications.fromdate = txtfromdate.Text;
                objNotifications.todate = txttodate.Text;
                objNotifications.isActive = "1";
                objNotifications.notificationID = lblNotificationID.Text;
                objNotifications.userIP = CreatedIP;
                objNotifications.createdBy = Session["MemberID"].ToString();
                objNotifications.photo = Session["Imagefilepath"].ToString();
                DataTable dt = objDal.InsertNotifications(objNotifications);
                if (dt.Rows.Count > 0)
                {
                    div_success.Visible = true;
                    ClearData();
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please upload the Photos')", false);
                return;
            }

        }
        public void ClearData()
        {
            txtContent.Text = "";
            txtdescription.Text = "";
            txtfromdate.Text = "";
            txttodate.Text = "";
            rptImage.Visible = false;
            Session["Imagefilepath"] = "";

        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = true;
            pnl_view.Visible = false;
            btn_back.Visible = true;
            btn_add.Visible = false;
            txt_search.Visible = false;
            ClearData();
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = false;
            pnl_view.Visible = true;
            btn_back.Visible = false;
            btn_add.Visible = true;
            txt_search.Visible = true;
            div_fail.Visible = false;
            div_success.Visible = false;
            bindgriddata();
        }
        protected void btnphotoupload_Click(object sender, EventArgs e)
        {
            // ViewState["TypeOFRequest"] = "1";
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            //RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            //FileUpload ctrlphotoupload = (FileUpload)item.FindControl("ctrlphotoupload");
            if (ctrlphotoupload.HasFiles)
            {
                string imgPath = "";
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("ImageUrl", typeof(string)));

                foreach (HttpPostedFile postedfile in ctrlphotoupload.PostedFiles)
                {
                    string CreatedIP = Request.ServerVariables["Remote_Addr"];
                    string useid = "123";// Session["UserID"].ToString();
                    string fileName = Path.GetFileName(postedfile.FileName);
                    if (postedfile.ContentLength > 0)
                    {
                        Savedocs obj = new Savedocs();
                        string date1 = DateTime.Now.ToString("dd-MM-yyyy");
                        string file_full_path = GetUploadFolderPath("GVR", "LibraryManagement", useid, txtContent.Text);
                        file_full_path = Path.Combine(file_full_path, fileName);
                        imgPath = imgPath + file_full_path + ",";
                        Session["ImagefileName"] = fileName;
                        postedfile.SaveAs(file_full_path);
                        DataRow drNew = dt.NewRow();
                        // string imgPath = (file_full_path.ToString()).ToString();
                        drNew["ImageUrl"] = file_full_path.ToString();
                        dt.Rows.Add(drNew);
                        dt.AcceptChanges();
                    }
                }
                Session["Imagefilepath"] = imgPath.ToString().Trim(',');
                if (dt.Rows.Count > 0)
                {
                    rptImage.Visible = true;
                    rptImage.DataSource = dt;
                    rptImage.DataBind();
                }
                else
                {
                    rptImage.Visible = false;
                }
            }
        }
        protected void lnk_removeward_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.Delete(Session["Imagefilepath"].ToString());
                lnk_removeward.Visible = false;
                lbluploadwardphoto.Text = string.Empty;
                ctrlphotouploadfilename.Value = string.Empty;
            }
            catch (Exception ex)
            {
            }
            finally
            {
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
        public static string GetUploadFolderPath(string MainModule, string SubModule, string userid, string uid)
        {
            string folderpath = string.Empty;
            string UploadFolderPath = ConfigurationManager.AppSettings["Docpath"].ToString();
            StringBuilder strUploadBuilder = new StringBuilder(UploadFolderPath);
            strUploadBuilder.AppendFormat(@"Sharepath\{0}\{1}\{2}\{3}\", MainModule, SubModule, userid, uid);
            CreateFolder(strUploadBuilder.ToString());
            return strUploadBuilder.ToString();

        }
        public static string GetviewUploadFolderPath(string MainModule, string SubModule, string userid, string uid)
        {
            string folderpath = string.Empty;
            string UploadFolderPath = ConfigurationManager.AppSettings["Docviewpath"].ToString();
            StringBuilder strUploadBuilder = new StringBuilder(UploadFolderPath);
            strUploadBuilder.AppendFormat(@"{0}/{1}/{2}/{3}/", MainModule, SubModule, userid, uid);
            return strUploadBuilder.ToString();
        }
        private static void CreateFolder(string path)
        {
            try
            {
                System.IO.DirectoryInfo dirInfo = new DirectoryInfo(@path);
                if (!dirInfo.Exists)

                {
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

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grid_data.Rows[rowIndex];
                Label lbl_NotificationID = row.FindControl("lbl_NotificationID") as Label;
                DataTable dt = objDal.GetNotificationData("2", lbl_NotificationID.Text);

                if (dt.Rows.Count > 0)
                {
                    lblNotificationID.Text = lbl_NotificationID.Text;
                    txtContent.Text = dt.Rows[0]["NotificationContent"].ToString();
                    txtdescription.Text = dt.Rows[0]["Description"].ToString();

                    txtfromdate.Text = Convert.ToDateTime(dt.Rows[0]["Fromdate"].ToString()).ToString("yyyy-MM-dd");
                    txttodate.Text = Convert.ToDateTime(dt.Rows[0]["Todate"].ToString()).ToString("yyyy-MM-dd");
                    if (dt.Rows[0]["ImagePath"].ToString() != null)
                    {
                        string imgPath = "";
                        // string[] imgPath = dt.Rows[0]["ImagePath"].ToString().Split(',');
                        DataTable dtImage = new DataTable();
                        dtImage.Columns.Add(new DataColumn("ImageUrl", typeof(string)));
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[i]["ImagePath"].ToString() ))
                            {
                                DataRow drNew = dtImage.NewRow();
                                // string imgPath = (file_full_path.ToString()).ToString();
                                drNew["ImageUrl"] = dt.Rows[i]["ImagePath"].ToString();
                                dtImage.Rows.Add(drNew);
                                dtImage.AcceptChanges();
                                imgPath = imgPath + dt.Rows[i]["ImagePath"].ToString() + ",";
                            }
                        }
                        if (dtImage.Rows.Count > 0)
                        {
                            rptImage.Visible = true;
                            rptImage.DataSource = dtImage;
                            rptImage.DataBind();
                        }
                        else
                        {
                            rptImage.Visible = false;
                        }
                        Session["Imagefilepath"] = imgPath.ToString().Trim(',');
                        //imgwardphoto.ImageUrl = PhotoBase64ImgSrc(dt.Rows[0]["Photo"].ToString());   //filePath; // @"~/Images/" + originalFileName;
                        //imgwardphoto.DataBind();
                        //imgwardphoto.Visible = true;
                    }
                    div_fail.Visible = false;
                    div_success.Visible = false;
                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    btn_add.Visible = false;
                    txt_search.Visible = false;
                }
            }

        }

        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            bindgriddata();
        }

        protected void rptImage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RepeaterItem item = e.Item;
                Image imgwardphoto = (item.FindControl("imgwardphoto") as Image);
                imgwardphoto.ImageUrl = PhotoBase64ImgSrc(imgwardphoto.ImageUrl.ToString());   //filePath; // @"~/Images/" + originalFileName;

            }
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objDal.Get_SerchNotifications(txt_search.Text);
            grid_data.DataSource = dt_Set;
            grid_data.DataBind();
        }
    }
}
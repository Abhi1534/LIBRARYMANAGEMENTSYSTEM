using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System.IO;
using System.Configuration;
using System.Text;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class BoardMembers : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            if (!Page.IsPostBack)
            {
                bindgriddata();
            }
        }
        public void bindgriddata()
        {

            DataTable dt = objDal.GetBoardMembers("1", "0");
            if (dt.Rows.Count > 0)
            {
                grid_data.DataSource = dt;
                grid_data.DataBind();
            }

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = true;
            pnl_view.Visible = false;
            btn_back.Visible = true;
            btn_add.Visible = false;
            // txt_search.Visible = false;
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            // bindgriddata();
            Response.Redirect("BoardMembers.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string userip = Request.UserHostAddress;
            DataTable dt = new DataTable();
            try
            {
                string userid = Session["MemberID"].ToString();
                BoardMemberDetails objBoardMemberDetails = new BoardMemberDetails();
                objBoardMemberDetails.boardMemberID = lblMemberID.Text;
                objBoardMemberDetails.memberName = txtName.Text;
                objBoardMemberDetails.designation = txtDesignation.Text;
                objBoardMemberDetails.mobileNo = txtMobileNo.Text;
                objBoardMemberDetails.emailID = txtEmail.Text;
                if (Session["Imagefilepath"] != null && !string.IsNullOrWhiteSpace(Session["Imagefilepath"].ToString()))
                {
                    objBoardMemberDetails.photo = Session["Imagefilepath"].ToString();
                }
                else
                {
                    objBoardMemberDetails.photo = "";
                }

                objBoardMemberDetails.address = txtAddress.Text;
                objBoardMemberDetails.isActive = "1";
                objBoardMemberDetails.createdBy = userid.ToString();
                objBoardMemberDetails.userIP = userip.ToString();
                dt = objDal.InsertBoardMemberDetails(objBoardMemberDetails);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "1000" || dt.Rows[0][0].ToString() == "1001")
                    {
                        div_success.Visible = true;
                    }
                    else
                    {
                        div_fail.Visible = true;
                    }
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                div_fail.Visible = true;
            }
        }
        public void ClearData()
        {
            txtName.Text = "";
            lblMemberID.Text = "";
            txtAddress.Text = "";
            txtDesignation.Text = "";
            txtEmail.Text = "";
            txtMobileNo.Text = "";
        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grid_data.Rows[rowIndex];
                Label lbl_MemberID = row.FindControl("lbl_MemberID") as Label;
                DataTable dt = objDal.GetBoardMembers("2", lbl_MemberID.Text);
                if (dt.Rows.Count > 0)
                {
                    lblMemberID.Text = lbl_MemberID.Text;
                    txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
                    txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
                    txtName.Text = dt.Rows[0]["MemberName"].ToString();
                    txtEmail.Text = dt.Rows[0]["EmailID"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    Session["Imagefilepath"] = dt.Rows[0]["Photo"].ToString();
                    imgwardphoto.ImageUrl = dt.Rows[0]["Photo"].ToString();   //filePath; // @"~/Images/" + originalFileName;
                    imgwardphoto.DataBind();
                    imgwardphoto.Visible = true;
                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    btn_add.Visible = false;
                    // txt_search.Visible = false;
                }
            }

        }

        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            bindgriddata();
        }

        protected void btnphotoupload_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            if (ctrlphotoupload.HasFiles)
            {
                foreach (HttpPostedFile postedfile in ctrlphotoupload.PostedFiles)
                {
                    string CreatedIP = Request.ServerVariables["Remote_Addr"];
                    string useid = "123";// Session["UserID"].ToString();
                    string fileName = Path.GetFileName(postedfile.FileName);
                    if (postedfile.ContentLength > 0)
                    {
                        Savedocs obj = new Savedocs();
                        string date1 = DateTime.Now.ToString("dd-MM-yyyy");
                        string file_full_path = Path.Combine("../../Sharepath", "GVR", "LibraryManagement", useid, txtName.Text);
                        file_full_path = Path.Combine(file_full_path, fileName);
                        Session["Imagefilepath"] = file_full_path;
                        Session["ImagefileName"] = fileName;
                        postedfile.SaveAs(Server.MapPath(file_full_path));
                        imgwardphoto.ImageUrl =file_full_path.ToString();   //filePath; // @"~/Images/" + originalFileName;
                        imgwardphoto.DataBind();
                        imgwardphoto.Visible = true;
                    }
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
        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objDal.Get_SerchMembershiptype(txt_search.Text);
            grid_data.DataSource = dt_Set;
            grid_data.DataBind();
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

    }
}
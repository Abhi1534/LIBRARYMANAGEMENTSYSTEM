using LIBRARYMANAGEMENTSYSTEM.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddonationdetails();
                // bindADDS();
                bindlatestnews();
            }
        }

        public void binddonationdetails()
        {
            string InoviceNum = "";
            LMBAL bal = new LMBAL();
            DataSet ds = bal.pr_getstampsamount(InoviceNum);
            if (ds.Tables[7].Rows.Count > 0)
            {
                rpt_donationdetails.DataSource = ds.Tables[7];
                rpt_donationdetails.DataBind();

            }
        }

        public void bindlatestnews()
        {
            
            LMBAL bal = new LMBAL();
            DataSet ds = bal.pr_get_latestnews_image("1","");
            if (ds.Tables[0].Rows.Count > 0)
            {
                rep_latestnews.DataSource = ds;
                rep_latestnews.DataBind();

            }
        }

        //public void bindADDS()
        //{

        //    LMBAL bal = new LMBAL();
        //    DataSet ds = bal.pr_get_AddsMaster("", "1", "");
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {

        //       lbl_addcontantleft.Text= ds.Tables[0].Rows[0]["addcontent"].ToString();
        //        lbl_addNameleft.Text= ds.Tables[0].Rows[0]["AddName"].ToString();
        //        img_addphotoLeft.ImageUrl = PhotoBase64ImgSrc(ds.Tables[0].Rows[0]["PhotoPath"].ToString());

        //        lbl_addcontantright.Text = ds.Tables[0].Rows[0]["addcontent"].ToString();
        //        lbl_addNameright.Text = ds.Tables[0].Rows[0]["AddName"].ToString();
        //        img_addphotoright.ImageUrl = PhotoBase64ImgSrc(ds.Tables[0].Rows[0]["PhotoPath"].ToString());

        //    }
        //}
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
using LIBRARYMANAGEMENTSYSTEM.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM
{
    public partial class Gallerylatest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string latestnewsid = Request.QueryString["ID"];
            Session["latestnewsid"] = latestnewsid.ToString();
            if (!IsPostBack)
            {
                bindlatestnews();
            }
        }
        public void bindlatestnews()
        {

            LMBAL bal = new LMBAL();
            if (Session["latestnewsid"] != null && !string.IsNullOrWhiteSpace(Session["latestnewsid"].ToString()))
            {
                DataSet ds = bal.pr_get_latestnews_image("2", Session["latestnewsid"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rpt_gallerylatest.DataSource = ds;
                    rpt_gallerylatest.DataBind();

                }
            }
        }
    }
}
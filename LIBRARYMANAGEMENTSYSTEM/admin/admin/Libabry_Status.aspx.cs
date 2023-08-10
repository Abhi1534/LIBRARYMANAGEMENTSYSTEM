using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class Libabry_Status : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        string strConnection = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            BindGrid();
        }
        public void BindGrid()
        {

            DataTable dt = new DataTable();
            try
            {
                dt= objDal.GetBooksData("1", "0");
                if (dt.Rows.Count > 0)
                    {
                        ViewState["GriData"] = dt;
                        gdvLibartyStatus.DataSource = dt;
                        gdvLibartyStatus.DataBind();
                    }
            }
            catch (Exception ex)
            { }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
          DataTable  dt = objDal.GetBooksData("1", "0");
            if (dt.Rows.Count>0)
            {
                DataTable dtNew = dt.Select("[BookName] like '"+txtSearch.Text+"%'").CopyToDataTable();
                gdvLibartyStatus.DataSource = dtNew;
                gdvLibartyStatus.DataBind();
            }
        }

        protected void gdvLibartyStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvLibartyStatus.PageIndex = e.NewPageIndex;
            BindGrid();

        }
    }
}
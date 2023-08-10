using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System.Data;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class Transactions : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] != null)
            {
                BindGrid(Session["MemberID"].ToString());
            }
        }
        public void BindGrid(string userID)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = objDal.GetBooksByUser(userID.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["GriData"] = dt;
                    gdvLibartyStatus.DataSource = dt;
                    gdvLibartyStatus.DataBind();
                }
            }
            catch (Exception ex)
            { }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (Session["MemberID"] != null)
            {
                DataTable dt = objDal.GetBooksByUser(Session["MemberID"].ToString());
                DataTable dtNew = dt.Select("[BookName] like '" + txtSearch.Text + "%'").CopyToDataTable();
                gdvLibartyStatus.DataSource = dtNew;
                gdvLibartyStatus.DataBind();
            }
        }

        protected void gdvLibartyStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["MemberID"] != null)
            {
                DataTable dt = objDal.GetBooksByUser(Session["MemberID"].ToString());
                gdvLibartyStatus.PageIndex = e.NewPageIndex;
                gdvLibartyStatus.DataSource = dt;
                gdvLibartyStatus.DataBind();
            }
        }
    }
}
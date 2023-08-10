using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System.Data;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class Expenses : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        string userID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {
                Response.Redirect("../SessionExpired.aspx");
            }
            if (!IsPostBack)
            {
                userID = Session["MemberID"].ToString();
                bindgriddata(Session["MemberID"].ToString());
            }
        }
        public void bindgriddata(string createdBy)
        {
            userID = Session["MemberID"].ToString();
            DataTable dt = objDal.GetExpensesData("1", "0", userID.ToString());
            if (dt.Rows.Count > 0)
            {
                grid_data.DataSource = dt;
                grid_data.DataBind();
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string CreatedIP = Request.ServerVariables["Remote_Addr"];
            ExpansesDetails objExpansesDetails = new ExpansesDetails();
            objExpansesDetails.expID = "";
            objExpansesDetails.description = txtDescription.Text;
            objExpansesDetails.amount = txtAmount.Text;
            objExpansesDetails.billDate = txtBillDate.Text;
            objExpansesDetails.expName = txtExpenseName.Text;
            objExpansesDetails.secretaryRemarks = "";
            objExpansesDetails.treasuryRemarks = "";
            objExpansesDetails.secretaryApprovedAmount = "";
            objExpansesDetails.treasuryApprovedAmount = "";
            objExpansesDetails.isActive = "1";
            objExpansesDetails.type = "1";
            objExpansesDetails.status = "";
            objExpansesDetails.userIP = CreatedIP;
            objExpansesDetails.createdBy = Session["MemberID"].ToString();
            DataTable dt = objDal.InsertExpanses(objExpansesDetails);
            if (dt.Rows.Count > 0)
            {
                div_success.Visible = true;
                ClearData();
            }


        }
        public void ClearData()
        {
            txtAmount.Text = "";
            txtBillDate.Text = "";
            txtDescription.Text = "";
            txtExpenseName.Text = "";
            txt_search.Visible = false;

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
            bindgriddata(userID.ToString());
        }

        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            bindgriddata(userID.ToString());
        }
        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataTable dt_Set = objDal.GetSearchExpensesData("1",  userID.ToString(),txt_search.Text);
            grid_data.DataSource = dt_Set;
            grid_data.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class Invoice : System.Web.UI.Page
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
                string userID = Session["MemberID"].ToString();
                BindGrid("3", "", userID);
            }
        }
        public void BindGrid(string flag, string type, string invoice)
        {
            DataTable dt = objDal.GetInvoiceData(flag, type, invoice);
            if (dt.Rows.Count > 0)
            {
                grid_data.DataSource = dt;
                grid_data.DataBind();
            }
        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_ViewCommand")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument) % grid_data.PageSize;
                GridViewRow row = grid_data.Rows[rowIndex];
                Label lbl_InoviceNum = row.FindControl("lbl_InoviceNum") as Label;
                Label lbl_PaymentIntiationpage = row.FindControl("lbl_PaymentIntiationpage") as Label;
                string type = "";
                if (lbl_PaymentIntiationpage.Text.Contains("Return"))
                    type = "BookReturn";
                else if (lbl_PaymentIntiationpage.Text.Contains("Receipt"))
                    type = "Receipt";
                else if (lbl_PaymentIntiationpage.Text.Contains("Donations"))
                    type = "Stamps";
                else if (lbl_PaymentIntiationpage.Text.Contains("Stamps"))
                    type = "Stamps";
                else
                    type = "Registration";
                Response.Redirect("InvoiceView.aspx?type="+ type.ToString() + "&Inv=" + lbl_InoviceNum.Text + "&req=Invoice", false);

            }

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataTable dt_Set = objDal.GetSearchInvoiceData(txtSearch.Text);
            if (dt_Set.Rows.Count > 0)
            {
                grid_data.DataSource = dt_Set;
                grid_data.DataBind();
            }
        }

        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            string userID = Session["MemberID"].ToString();
            BindGrid("3", "", userID);
        }
    }
}
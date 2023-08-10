using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class UserInvoice : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userID = Session["MemberID"].ToString();
                BindGrid("2", "", userID);
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
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grid_data.Rows[rowIndex];
                Label lbl_InoviceNum = row.FindControl("lbl_InoviceNum") as Label;
                Label lbl_PaymentIntiationpage = row.FindControl("lbl_PaymentIntiationpage") as Label;
                string type = "";
                if (lbl_PaymentIntiationpage.Text.Contains("Return"))
                    type = "BookReturn";
                else if (lbl_PaymentIntiationpage.Text.Contains("Receipt"))
                    type = "Receipt";
                else
                    type = "Registration";
                Response.Redirect("UserInvoiceView.aspx?type="+ type.ToString() + "&Inv=" + lbl_InoviceNum.Text, false);

            }

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
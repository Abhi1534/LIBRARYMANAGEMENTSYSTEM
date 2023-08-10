using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class StampsIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddata();
            }
        }
        public void binddata()
        {
            DataSet ds = new DataSet();
            LMBAL objbal = new LMBAL();
            ds = objbal.pr_get_Stamps_list("1","","");
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid_data.DataSource = ds;
                grid_data.DataBind();
            }
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                string InoviceNum = e.CommandArgument.ToString();
                GridViewRow gvrc = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RowIndex = gvrc.RowIndex;                
                Label Issuedstatus = (Label)grid_data.Rows[RowIndex].FindControl("lbl_IssuedStatus");
                LMBAL bal = new LMBAL();
                if (Issuedstatus.Text== "Pending")
                {
                    DataSet ds = bal.pr_get_Stamps_list("12", InoviceNum, "1");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        binddata();
                    }
                    else
                    {
                        div_fail.Visible = true;
                    }
                }
                else
                {
                    DataSet ds = bal.pr_get_Stamps_list("12", InoviceNum, "0");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        binddata();
                    }
                    else
                    {
                        div_fail.Visible = true;
                    }
                }
               
            }
        }
        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}
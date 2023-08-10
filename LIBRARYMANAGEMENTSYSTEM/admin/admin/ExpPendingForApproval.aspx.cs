using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System.Data;
namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class ExpPendingForApproval : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        string rollID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RoleID"] == null || Session["MemberID"] == null)
            {
                Response.Redirect("../SessionExpired.aspx");
            }
            else
            {
                rollID = Session["RoleID"].ToString();
            }
            if (!IsPostBack)
            {
                bindgriddata();
            }
        }
        public void bindgriddata()
        {


            DataTable dt = objDal.GetExpensesData("2", "0", "");
            if (dt.Rows.Count > 0)
            {
                grid_data.DataSource = dt;
                grid_data.DataBind();
            }

        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                //  int rowIndex = Convert.ToInt32(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument) % grid_data.PageSize;
                GridViewRow row = grid_data.Rows[rowIndex];

                // GridViewRow row = grid_data.Rows[rowIndex];
                Label lbl_ExpID = row.FindControl("lbl_ExpID") as Label;
                DataTable dt = objDal.GetExpensesData("3", lbl_ExpID.Text, "");

                if (dt.Rows.Count > 0)
                {
                    lblExpID.Text = lbl_ExpID.Text;
                    txtAmount.Text = dt.Rows[0]["Amount"].ToString();
                    txtSecretaryApprovedAmount.Text = dt.Rows[0]["SecretaryApprovedAmount"].ToString();
                    txtTreasuryApprovedAmount.Text = dt.Rows[0]["TreasuryApprovedAmount"].ToString();

                    txtBillDate.Text = Convert.ToDateTime(dt.Rows[0]["BillDate"].ToString()).ToString("yyyy-MM-dd");
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                    txtExpenseName.Text = dt.Rows[0]["ExpenseName"].ToString();
                    txtTreasuryRemarks.Text = dt.Rows[0]["TreasuryRemarks"].ToString();
                    txtSecretaryRemarks.Text = dt.Rows[0]["SecretaryRemarks"].ToString();
                    if (rollID.ToString() == "7")
                    {
                        txtTreasuryRemarks.Enabled = true;
                        txtTreasuryApprovedAmount.Enabled = true;
                        //txtSecretaryApprovedAmount.Enabled = false;
                        //txtSecretaryRemarks.Enabled = false;
                        txtSecretaryApprovedAmount.Attributes.Add("readonly", "readonly");
                        txtSecretaryRemarks.Attributes.Add("readonly", "readonly");

                    }
                    else
                    {
                        //  txtTreasuryApprovedAmount.Enabled = false;
                        txtSecretaryApprovedAmount.Enabled = true;
                        // txtTreasuryRemarks.Enabled = false;
                        txtSecretaryRemarks.Enabled = true;
                        txtTreasuryApprovedAmount.Attributes.Add("readonly", "readonly");
                        txtTreasuryRemarks.Attributes.Add("readonly", "readonly");

                    }
                    div_fail.Visible = false;
                    div_success.Visible = false;
                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    // btn_add.Visible = false;
                    txt_search.Visible = false;
                    btnReject.Visible = true;
                    btnSave.Visible = true;
                }
            }

        }

        protected void grid_data_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView childGrid = (GridView)sender;
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = (LinkButton)e.Row.FindControl("btn_Edit");
                if (rollID.ToString() == "6" || rollID.ToString() == "7")
                {
                    Label lbl_SecretaryApproved = (Label)e.Row.FindControl("lbl_SecretaryApproved");
                    Label lbl_TreasuryApproved = (Label)e.Row.FindControl("lbl_TreasuryApproved");
                    if (rollID.ToString() == "6")
                    {
                        if (lbl_SecretaryApproved.Text == "Pending")
                            lnk.Enabled = true;
                        else
                            lnk.Enabled = false;
                    }
                    else
                    {
                        if (lbl_TreasuryApproved.Text == "Pending")
                            lnk.Enabled = true;
                        else
                            lnk.Enabled = false;
                    }

                }
                else
                {
                    lnk.Enabled = false;
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ApproveRejectDetails("1");
        }

        public void ApproveRejectDetails(string status)
        {
            ExpansesDetails objExpansesDetails = new ExpansesDetails();
            int amount = Convert.ToInt32(txtAmount.Text);
            int approvedAmount = 0;
            if (rollID.ToString() == "6")
            {
                objExpansesDetails.type = "2";
                if (!string.IsNullOrEmpty(txtSecretaryApprovedAmount.Text))
                {
                    approvedAmount = Convert.ToInt32(txtSecretaryApprovedAmount.Text);
                    if (approvedAmount > amount)
                    {
                        txtSecretaryApprovedAmount.Text = "";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Approved amount is greater than Expenses amount')", true);
                        return;
                    }
                }
                else
                {
                    txtSecretaryApprovedAmount.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter the amount')", true);
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtTreasuryApprovedAmount.Text))
                {
                    approvedAmount = Convert.ToInt32(txtTreasuryApprovedAmount.Text);
                    objExpansesDetails.type = "3";
                    if (approvedAmount > amount)
                    {
                        txtTreasuryApprovedAmount.Text = "";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Approved amount is greater than Expenses amount')", true);
                        return;
                    }
                }
                else
                {
                    txtTreasuryApprovedAmount.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter the amount')", true);
                    return;
                }
            }



            string CreatedIP = Request.ServerVariables["Remote_Addr"];

            objExpansesDetails.expID = lblExpID.Text;
            objExpansesDetails.description = txtDescription.Text;
            objExpansesDetails.amount = txtAmount.Text;
            objExpansesDetails.billDate = txtBillDate.Text;
            objExpansesDetails.expName = txtExpenseName.Text;

            objExpansesDetails.secretaryRemarks = txtSecretaryRemarks.Text;
            objExpansesDetails.treasuryRemarks = txtTreasuryRemarks.Text;

            objExpansesDetails.status = status.ToString();
            objExpansesDetails.secretaryApprovedAmount = txtSecretaryApprovedAmount.Text;
            objExpansesDetails.treasuryApprovedAmount = txtTreasuryApprovedAmount.Text;
            objExpansesDetails.isActive = "1";

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
            txtSecretaryApprovedAmount.Text = "";
            txtTreasuryApprovedAmount.Text = "";
            txtSecretaryRemarks.Text = "";
            txtTreasuryRemarks.Text = "";
            txt_search.Visible = false;
            lblExpID.Text = "";
            btnReject.Visible = false;
            btnSave.Visible = false;

        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = true;
            pnl_view.Visible = false;
            btn_back.Visible = true;
            //  btn_add.Visible = false;
            txt_search.Visible = false;
            ClearData();
            btnReject.Visible = true;
            btnSave.Visible = true;
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = false;
            pnl_view.Visible = true;
            btn_back.Visible = false;
            //  btn_add.Visible = true;
            txt_search.Visible = true;
            div_fail.Visible = false;
            div_success.Visible = false;
            bindgriddata();
        }

        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            bindgriddata();
        }
        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataTable dt_Set = objDal.GetSearchExpensesData("2", "", txt_search.Text);
            if (dt_Set.Rows.Count > 0)
            {
                grid_data.DataSource = dt_Set;
                grid_data.DataBind();
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            ApproveRejectDetails("2");
        }
    }
}
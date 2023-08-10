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
    public partial class Features : System.Web.UI.Page
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
                bindgriddata("0", "3");
            }

        }
        public void bindgriddata(string featureID, string flag)
        {

            DataTable dt = objDal.GetFeaturesDetails(featureID, flag);
            if (dt.Rows.Count > 0)
            {
                grid_data.DataSource = dt;
                grid_data.DataBind();
            }

        }
        public void BindBankDet()
        {
            DataTable dt = new DataTable();
            dt = objDal.GetBankDet();
            if (dt.Rows.Count > 0)
            {
                ddlBankAccount.DataSource = dt;
                ddlBankAccount.DataTextField = "AccountName";
                ddlBankAccount.DataValueField = "AccountID";
                ddlBankAccount.DataBind();
                ddlBankAccount.Items.Insert(0, new ListItem("Select Bank Account No"));
            }
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            BindBankDet();
            pnl_entry.Visible = true;
            pnl_view.Visible = false;
            btn_back.Visible = true;
            btn_add.Visible = false;
            txt_search.Visible = false;
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            //bindgriddata("0", "3");
            //pnl_entry.Visible = false;
            //pnl_view.Visible = true;
            //btn_back.Visible = false;
            //btn_add.Visible = true;
            //txt_search.Visible = true;
            Response.Redirect("Features.aspx");
        }

        protected void rbtnSingle_CheckedChanged(object sender, EventArgs e)
        {
            divSingle.Visible = true;
            divMultiple.Visible = false;
        }

        protected void rbtnMultiple_CheckedChanged(object sender, EventArgs e)
        {
            divSingle.Visible = false;
            divMultiple.Visible = true;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string useid = Session["MemberID"].ToString();
            string userip = Request.UserHostAddress;
            FeaturesDetails objFeaturesDetails = new FeaturesDetails();
            objFeaturesDetails.featureBankAccount = ddlBankAccount.SelectedValue;
            objFeaturesDetails.featureName = txtFeatureName.Text;
            objFeaturesDetails.createdBy = useid.ToString();
            objFeaturesDetails.userIP = userip.ToString();

            if (!string.IsNullOrEmpty(lblFeatureID.Text))
                objFeaturesDetails.flag = "2";
            else
                objFeaturesDetails.flag = "1";
            objFeaturesDetails.featureID = lblFeatureID.Text;
            if (rbtnActive.SelectedItem.Text == "Active")
                objFeaturesDetails.featureIsActive = "1";
            else
                objFeaturesDetails.featureIsActive = "0";
            if (rbtnSingle.SelectedItem.Text == "Single")
            {
                objFeaturesDetails.featureType = "1";
                objFeaturesDetails.featureOptions = "1";
                objFeaturesDetails.featureValues = txtSingleValue.Text;
            }
            else
            {
                string[] option = txtMultiOptions.Text.Split(',');
                string[] featureValues = txtMultiValues.Text.Split(',');
                if (option.Length == featureValues.Length)
                {
                    objFeaturesDetails.featureType = "2";
                    objFeaturesDetails.featureOptions = txtMultiOptions.Text;
                    objFeaturesDetails.featureValues = txtMultiValues.Text;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Options and Values')", true);
                    return;
                }
            }
            DataTable dt = objDal.InserFeatureDetails(objFeaturesDetails);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Result"].ToString() == "Success")
                {
                    //  string scriptText = "alert('Feature Inserted Successfully!!!'); window.location='../admin/Features.aspx'";
                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", scriptText, true);
                    div_success.Visible = true;
                    ClearData();
                }
                else if (dt.Rows[0]["Result"].ToString() == "Updated")
                {
                    div_success.Visible = true;
                    string scriptText = "alert('Updated Successfully!!!'); window.location='../admin/Features.aspx'";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", scriptText, true);
                    ClearData();
                }
                else if (dt.Rows[0]["Result"].ToString() == "Already Exists")
                {
                    string scriptText = "alert('Updated Successfully!!!'); window.location='../admin/Features.aspx'";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", scriptText, true);
                    return;
                }
                bindgriddata("0", "3");
            }
        }
        //protected void btn_Cancel_Click(object sender, EventArgs e)
        //{
        //    ClearData();
        //}
        public void ClearData()
        {
            txtFeatureName.Text = "";
            txtMultiOptions.Text = "";
            txtMultiValues.Text = "";
            txtSingleValue.Text = "";
            //ddlBankAccount.SelectedValue = "0";
            lblFeatureID.Text = "";
        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grid_data.Rows[rowIndex];
                DataTable dt = new DataTable();
                Label lbl_FeatureID = row.FindControl("lbl_FeatureID") as Label;
                dt = objDal.GetFeaturesDetails(lbl_FeatureID.Text, "1");
                if (dt.Rows.Count > 0)
                {
                    BindBankDet();
                    lblFeatureID.Text = lbl_FeatureID.Text;
                    txtFeatureName.Text = dt.Rows[0]["FeatureName"].ToString();
                    ddlBankAccount.SelectedValue = dt.Rows[0]["AccountID"].ToString();
                    if (dt.Rows[0]["IsActive"].ToString() == "1")
                        rbtnActive.SelectedValue = "Active";
                    else
                        rbtnActive.SelectedValue = "InActive";
                    if (dt.Rows[0]["FeatureType"].ToString() == "1")
                    {
                        rbtnSingle.SelectedValue = "Single";
                        txtSingleValue.Text = dt.Rows[0]["FeatureValues"].ToString();
                        divSingle.Visible = true;
                        divMultiple.Visible = false;
                    }
                    else
                    {
                        rbtnSingle.SelectedValue = "Multiple";
                        txtMultiOptions.Text = dt.Rows[0]["Options"].ToString();
                        txtMultiValues.Text = dt.Rows[0]["FeatureValues"].ToString();
                        divMultiple.Visible = true;
                        divSingle.Visible = false;
                    }


                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    btn_add.Visible = false;
                    txt_search.Visible = false;
                }

            }
            else if (e.CommandName == "Btn_DeleteCommand")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grid_data.Rows[rowIndex];
                Label lbl_FeatureID = row.FindControl("lbl_FeatureID") as Label;
                DataTable dt = objDal.GetFeaturesDetails(lblFeatureID.Text, "2");
                if (dt.Rows.Count > 0)
                {
                    string scriptText = "alert('Deleted Successfully!!!'); window.location='../admin/Features.aspx'";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", scriptText, true);
                    grid_data.DataSource = dt;
                    grid_data.DataBind();
                }

            }
        }

        protected void rbtnSingle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnSingle.SelectedItem.Text == "Single")
            {
                divSingle.Visible = true;
                divMultiple.Visible = false;
            }
            else
            {
                divSingle.Visible = false;
                divMultiple.Visible = true;
            }

        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataTable dt_Set = objDal.GetSearchFeaturesDetails(txt_search.Text);
            if (dt_Set.Rows.Count > 0)
            {
                grid_data.DataSource = dt_Set;
                grid_data.DataBind();
            }
        }
    }
}
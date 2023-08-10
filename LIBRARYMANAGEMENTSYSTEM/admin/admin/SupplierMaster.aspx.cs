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
    public partial class SupplierMaster : System.Web.UI.Page
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
                bindgriddata();
            }

        }
        public void bindgriddata()
        {

            DataTable dt = objDal.GetSupplierData("1", "0");
            if (dt.Rows.Count > 0)
            {
                grid_data.DataSource = dt;
                grid_data.DataBind();
            }

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string userip = Request.UserHostAddress;
            try
            {
                SupplierDetails objSupplier = new SupplierDetails();
                objSupplier.supID = lblSupID.Text;
                objSupplier.supName = txtSupName.Text;
                objSupplier.supMobileNo = txtMobile.Text;
                objSupplier.supPhoneNo = txtphone.Text;
                objSupplier.supEmail = txtEmail.Text;
                objSupplier.supAddress = txtEmail.Text;
                objSupplier.supCountry = txtCountry.Text;
                objSupplier.supState = txtState.Text;
                objSupplier.supCity = txtCity.Text;
                objSupplier.supAddress = txtAddress.Text;
                objSupplier.supPan = txtpan.Text;
                objSupplier.supGSTIN = txtGSTIN.Text;
                objSupplier.supCIN = txtCIN.Text;
                objSupplier.supDescription = txtdescription.Text;
                objSupplier.supIsActive = Convert.ToInt32(chkActive.Checked).ToString();
                objSupplier.createdBy = "1";
                if (!string.IsNullOrEmpty(lblSupID.Text))
                    objSupplier.flag = "2";
                else
                    objSupplier.flag = "1";
                objSupplier.userIP = userip.ToString();
                DataTable dt = objDal.InsertSupplierDet(objSupplier);
                if (dt.Rows.Count > 0)
                {
                    ClearData();
                    if (dt.Rows[0]["result"].ToString() == "Success")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Inserted Supplier Details')", true);
                        bindgriddata();
                        div_success.Visible = true;
                        return;
                    }
                    else if (dt.Rows[0]["result"].ToString() == "Updated")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Updated Supplier Details')", true);
                        bindgriddata();
                        div_success.Visible = true;
                        return;
                    }

                }
            }
            catch (Exception ex)
            { }

        }
        public void ClearData()
        {
            pnl_entry.Visible = false;
            pnl_view.Visible = true;
            btn_back.Visible = false;
            btn_add.Visible = true;
            txt_search.Visible = true;
            txtAddress.Text = "";
            txtCIN.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtdescription.Text = "";
            txtEmail.Text = "";
            txtGSTIN.Text = "";
            txtMobile.Text = "";
            txtpan.Text = "";
            txtphone.Text = "";
            txtState.Text = "";
            txtSupName.Text = "";

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = true;
            pnl_view.Visible = false;
            btn_back.Visible = true;
            btn_add.Visible = false;
            txt_search.Visible = false;
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = false;
            pnl_view.Visible = true;
            btn_back.Visible = false;
            btn_add.Visible = true;
            txt_search.Visible = true;
        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grid_data.Rows[rowIndex];
                Label lblSupplierID = row.FindControl("lblSupplierID") as Label;
                DataTable dt = objDal.GetSupplierData("2", lblSupplierID.Text);
                if (dt.Rows.Count > 0)
                {
                    lblSupID.Text = lblSupplierID.Text;
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtCIN.Text = dt.Rows[0]["CIN"].ToString();
                    txtCity.Text = dt.Rows[0]["City"].ToString();
                    txtCountry.Text = dt.Rows[0]["Country"].ToString();
                    txtdescription.Text = dt.Rows[0]["Description"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtGSTIN.Text = dt.Rows[0]["GSTIN"].ToString();
                    txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                    txtpan.Text = dt.Rows[0]["PAN"].ToString();
                    txtphone.Text = dt.Rows[0]["Phone"].ToString();
                    txtState.Text = dt.Rows[0]["State"].ToString();
                    txtSupName.Text = dt.Rows[0]["SupplierName"].ToString();
                    if (dt.Rows[0]["IsActive"].ToString() == "1")
                        chkActive.Checked = true;
                    else
                        chkActive.Checked = false;
                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    btn_add.Visible = false;
                    txt_search.Visible = false;
                }

            }
        }
        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataTable dt_Set = objDal.Get_SerchSupplier(txt_search.Text);
            grid_data.DataSource = dt_Set;
            grid_data.DataBind();
        }

        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            bindgriddata();
        }
    }
}
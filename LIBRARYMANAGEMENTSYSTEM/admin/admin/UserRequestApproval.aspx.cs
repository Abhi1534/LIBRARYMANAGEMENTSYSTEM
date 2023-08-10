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
    public partial class UserRequestApproval : System.Web.UI.Page
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
                bindgriddata("1", "", "", "0", "0");
            }
        }
        public void bindgriddata(string type, string serID, string textSearch, string status, string ServiceName)
        {


            DataTable dt = objDal.GetUserServiceRequest(type, serID, textSearch, status, ServiceName);
            //if (dt.Rows.Count > 0)
            //{
            grid_data.DataSource = dt;
            grid_data.DataBind();


        }

        protected void ddlServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgriddata("3", "", txt_search.Text, ddlStatus.SelectedValue, ddlServiceName.SelectedValue);
        }


        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgriddata("3", "", txt_search.Text, ddlStatus.SelectedValue, ddlServiceName.SelectedValue);
            // SearchData();
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            bindgriddata("3", "", txt_search.Text, ddlStatus.SelectedValue, ddlServiceName.SelectedValue);
            //  SearchData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ServiceReqDetails objServiceReqDetails = new ServiceReqDetails();
            string CreatedIP = Request.ServerVariables["Remote_Addr"];
            objServiceReqDetails.serID = lblSerID.Text;
            objServiceReqDetails.CourierName = txtCourierName.Text;
            objServiceReqDetails.CourierRefNumber = txtCourierNo.Text;
            objServiceReqDetails.userIP = CreatedIP;
            objServiceReqDetails.createdBy = Session["MemberID"].ToString();
            DataTable dt = objDal.UpdateServiceReqDetails(objServiceReqDetails);
            if (dt.Rows.Count > 0)
            {
                div_success.Visible = true;
                ClearData();
            }

        }

        protected void grid_data_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView childGrid = (GridView)sender;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = (LinkButton)e.Row.FindControl("btn_Edit");
                Label lbl_DeliveryStatus = (Label)e.Row.FindControl("lbl_DeliveryStatus");
                if(lbl_DeliveryStatus.Text== "Dispatched")
                {
                    lnk.Enabled = false;
                }
                else
                {
                    lnk.Enabled = true;
                }
            }

        }

        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            bindgriddata("3", "", txt_search.Text, ddlStatus.SelectedValue, ddlServiceName.SelectedValue);
        }

        public void ClearData()
        {
            txtAmount.Text = "";
            txtCourierName.Text = "";
            txtCourierNo.Text = "";
            txtMemberName.Text = "";
            txtMobileNumber.Text = "";
            txtServiceName.Text = "";
            txt_search.Text = "";
            btnSave.Visible = false;

        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = true;
            pnl_view.Visible = false;
            btn_back.Visible = true;
            ddlServiceName.Visible = false;
            ddlStatus.Visible = false;
            //  btn_add.Visible = false;
            txt_search.Visible = false;
            ClearData();
            btnSave.Visible = true;
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            ddlServiceName.Visible = true;
            ddlStatus.Visible = true;
            pnl_entry.Visible = false;
            pnl_view.Visible = true;
            btn_back.Visible = false;
            //  btn_add.Visible = true;
            txt_search.Visible = true;
            div_fail.Visible = false;
            div_success.Visible = false;
            bindgriddata("1", "", "", "0", "0");
        }



        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Btn_EditCommand")
            {
                //  int rowIndex = Convert.ToInt32(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument) % grid_data.PageSize;
                GridViewRow row = grid_data.Rows[rowIndex];

                // GridViewRow row = grid_data.Rows[rowIndex];
                Label lbl_SerID = row.FindControl("lbl_SerID") as Label;
                DataTable dt = objDal.GetUserServiceRequest("2", lbl_SerID.Text, "", "0", "0");

                if (dt.Rows.Count > 0)
                {
                    lblSerID.Text = lbl_SerID.Text;
                    txtAmount.Text = dt.Rows[0]["Amount"].ToString();
                    txtMemberName.Text = dt.Rows[0]["MemberName"].ToString();
                    txtMobileNumber.Text = dt.Rows[0]["MobileNumber"].ToString();

                    txtServiceName.Text = dt.Rows[0]["ServiceName"].ToString();

                    div_fail.Visible = false;
                    div_success.Visible = false;
                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    // btn_add.Visible = false;
                    txt_search.Visible = false;
                    btnSave.Visible = true;
                    ddlServiceName.Visible = false;
                    ddlStatus.Visible = false;
                }
            }
        }
    }
}
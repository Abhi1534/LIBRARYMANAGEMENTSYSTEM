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
    public partial class EmployeesInformation : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            if (!Page.IsPostBack)
            {
                bindgriddata();
            }
        }
        public void bindgriddata()
        {

            DataTable dt = objDal.GetEmployees("1", "0");
            if (dt.Rows.Count > 0)
            {
                grid_data.DataSource = dt;
                grid_data.DataBind();
            }

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = true;
            pnl_view.Visible = false;
            btn_back.Visible = true;
            btn_add.Visible = false;
           // txt_search.Visible = false;
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
           // bindgriddata();
            Response.Redirect("EmployeesInformation.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string userip = Request.UserHostAddress;
            DataTable dt = new DataTable();
            try
            {
                string userid = Session["MemberID"].ToString();
                EmployeeDetails objEmployeeDetails = new EmployeeDetails();
                objEmployeeDetails.empID = lblEmpID.Text;
                objEmployeeDetails.Name = txtName.Text;
                objEmployeeDetails.Designation = txtDesignation.Text;
                objEmployeeDetails.workedAt = txtWorkedAt.Text;
                objEmployeeDetails.qualification = txtQualification.Text;
                objEmployeeDetails.basicSalary = txtBasicSalary.Text;
                objEmployeeDetails.isActive = "1";
                objEmployeeDetails.createdBy = userid.ToString();
                objEmployeeDetails.userIP = userip.ToString();
                dt = objDal.InsertEmployeeDetails(objEmployeeDetails);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "1000" || dt.Rows[0][0].ToString() == "1001")
                    {
                        div_success.Visible = true;
                    }
                    else
                    {
                        div_fail.Visible = true;
                    }
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                div_fail.Visible = true;
            }
        }
        public void ClearData()
        {
            txtName.Text = "";
            lblEmpID.Text = "";
            txtBasicSalary.Text = "";
            txtDesignation.Text = "";
            txtQualification.Text = "";
            txtWorkedAt.Text = "";
        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grid_data.Rows[rowIndex];
                Label lbl_EmpID = row.FindControl("lbl_EmpID") as Label;
                DataTable dt = objDal.GetEmployees("2", lbl_EmpID.Text);
                if (dt.Rows.Count > 0)
                {
                    lblEmpID.Text = lbl_EmpID.Text;
                    txtBasicSalary.Text = dt.Rows[0]["BasicSalary"].ToString();
                    txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
                    txtName.Text = dt.Rows[0]["EmpName"].ToString();
                    txtQualification.Text = dt.Rows[0]["Qualification"].ToString();
                    txtWorkedAt.Text = dt.Rows[0]["WorkedAt"].ToString();
                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    btn_add.Visible = false;
                   // txt_search.Visible = false;
                }
            }

        }

        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            bindgriddata();
        }

    }
}
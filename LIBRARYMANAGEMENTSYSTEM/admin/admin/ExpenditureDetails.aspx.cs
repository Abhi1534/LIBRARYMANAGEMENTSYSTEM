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
    public partial class ExpenditureDetails : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        string expenditureType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["ExpenditureType"].ToString()))
                {
                    expenditureType = Session["ExpenditureType"].ToString();
                }
                else
                {
                    Response.Redirect("../SessionExpired.aspx");
                }
                if (Session["ExpenditureType"].ToString() == "WelfareStamp")
                {
                    welfireStampsBindData();
                    Grd_StampsData.Visible = true;
                    grid_data.Visible = false;
                }
                else if (Session["ExpenditureType"].ToString() == "CourtStamps")
                {
                    CourtStampsBindData();
                    Grd_StampsData.Visible = true;
                    grid_data.Visible = false;
                }
                else if (Session["ExpenditureType"].ToString() == "Donation")
                {
                    DonationBindData();
                    Grd_StampsData.Visible = true;
                    grid_data.Visible = false;
                }
                else
                {
                    BindData();

                }

            }
        }
        public void BindData()
        {

            DataTable dt = objDal.GetExpenditures("2", expenditureType.ToString());
            if (dt.Rows.Count > 0)
            {
                grid_data.DataSource = dt;
                grid_data.DataBind();
            }

        }

        public void welfireStampsBindData()
        {
            LMBAL objbal = new LMBAL();
            string InoviceNum = "";
            DataSet ds = objbal.pr_getstampsamount(InoviceNum);
            if (ds.Tables[4].Rows.Count > 0)
            {
                Grd_StampsData.DataSource = ds.Tables[4];
                Grd_StampsData.DataBind();
            }

        }

        public void CourtStampsBindData()
        {
            LMBAL objbal = new LMBAL();
            string InoviceNum = "";
            DataSet ds = objbal.pr_getstampsamount(InoviceNum);
            if (ds.Tables[5].Rows.Count > 0)
            {
                Grd_StampsData.DataSource = ds.Tables[5];
                Grd_StampsData.DataBind();
            }

        }
        public void DonationBindData()
        {
            LMBAL objbal = new LMBAL();
            string InoviceNum = "";
            DataSet ds = objbal.pr_getstampsamount(InoviceNum);
            if (ds.Tables[9].Rows.Count > 0)
            {
                Grd_StampsData.DataSource = ds.Tables[9];
                Grd_StampsData.DataBind();
            }

        }
        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void grid_data_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            GridView childGrid = (GridView)sender;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl_PaymentType = e.Row.FindControl("lbl_PaymentType") as Label;
                if (lbl_PaymentType.Text.Contains("Registration"))
                {
                    e.Row.Cells[5].Visible = true;
                }
                else
                { e.Row.Cells[5].Visible = false; }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (Session["ExpenditureType"].ToString().Contains("Registration"))
                {
                    e.Row.Cells[5].Visible = true;
                }
                else
                { e.Row.Cells[5].Visible = false; }

            }
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objDal.Get_SerchExpendituresMembers(txt_search.Text, Session["ExpenditureType"].ToString());
            if (dt_Set.Tables[0].Rows.Count>0)
            {
                grid_data.DataSource = dt_Set;
                grid_data.DataBind();
            }
           
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Expenditure.aspx");
        }

        protected void Grd_StampsData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            if (Session["ExpenditureType"].ToString() == "WelfareStamp")
            {
                welfireStampsBindData();
            }
            if (Session["ExpenditureType"].ToString() == "CourtStamps")
            {
                CourtStampsBindData();
            }
            if (Session["ExpenditureType"].ToString() == "Donation")
            {
                DonationBindData();
            }
            if (Session["ExpenditureType"].ToString() == "Registration")
            {
                BindData();
            }

        }

        protected void Grd_StampsData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                string InoviceNum = e.CommandArgument.ToString();

                LMBAL bal = new LMBAL();
                DataSet ds = bal.pr_getstampsamount(InoviceNum);
                if (ds.Tables[6].Rows.Count > 0)
                {
                    Session["membershipfee"] = ds.Tables[6].Rows[0]["Amount"].ToString();
                    Session["MembershipName"] = ds.Tables[6].Rows[0]["Name"].ToString();
                    Session["Invoicenumber"] = ds.Tables[6].Rows[0]["InoviceNum"].ToString();
                    Session["MembershipEmailID"] = ds.Tables[6].Rows[0]["Email"].ToString();
                    Session["Membershipmobilenumber"] = ds.Tables[6].Rows[0]["MobileNumber"].ToString();
                    Session["MembershiptypeName"] = ds.Tables[6].Rows[0]["Numberofstamps"].ToString();
                    Session["membershipfee"] = ds.Tables[6].Rows[0]["Amount"].ToString();
                    Session["headofinvoice"] = "No Of Stamps";
                    Session["Stampprice"] = ds.Tables[6].Rows[0]["stampPrice"].ToString();
                    Response.Redirect("StampInvoiceView.aspx");

                }
            }
        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                string InoviceNum = e.CommandArgument.ToString();

                Response.Redirect("InvoiceView.aspx?type=" + Session["ExpenditureType"].ToString() + "&Inv=" + InoviceNum.ToString() + "&req=Expenditure", false);
            }
        }
    }
}
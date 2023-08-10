using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class SubjectMaster : System.Web.UI.Page
    {
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
            LMBAL objMaster = new LMBAL();
            DataSet ds = objMaster.pr_get_allSubjectmaster();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid_data.DataSource = ds;
                grid_data.DataBind();
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubjectMaster.aspx");
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = true;
            pnl_view.Visible = false;
            btn_back.Visible = true;
            btn_add.Visible = false;
            txt_search.Visible = false;

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                Subject objrs = new Subject();
                objrs.SubjectName = txt_Subjectname.Text;
                objrs.Description = txt_description.Text;

                if (Session["SubID"] != null && !string.IsNullOrWhiteSpace(Session["SubID"].ToString()))
                {
                    objrs.flag = "2";
                    objrs.CreatedBy = "";
                    objrs.CreatedIP = "";
                    objrs.ModifyBy = Session["MemberID"].ToString();
                    objrs.ModifyIp = Request.ServerVariables["Remote_Addr"];
                    objrs.SubjectID = Session["SubID"].ToString();
                }
                else
                {
                    objrs.flag = "1";
                    objrs.CreatedBy = Session["MemberID"].ToString();
                    objrs.CreatedIP = Request.ServerVariables["Remote_Addr"];
                    objrs.ModifyBy = "";
                    objrs.ModifyIp = "";
                    objrs.SubjectID = "";
                }

                objrs.IsActive = "1";
                DataSet ds = new DataSet();
                LMBAL objbal = new LMBAL();
                ds = objbal.INSSubjectMaster(objrs);
                if (ds.Tables[0].Rows[0]["result"].ToString() == "Success")
                {
                    div_success.Visible = true;
                    txt_Subjectname.Text = "";

                    txt_description.Text = "";

                }
                else
                {
                    div_fail.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> SearchText(string prefixText, int count)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_serch_Subjectmaster(prefixText);
            List<string> address = new List<string>();

            foreach (DataRow row in dt_Set.Tables[0].Rows)
            {
                address.Add(row["SubjectName"].ToString());

            }
            return address;
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_serch_Subjectmaster(txt_search.Text);
            grid_data.DataSource = dt_Set;
            grid_data.DataBind();
        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                string UID = e.CommandArgument.ToString();

                LMBAL bal = new LMBAL();
                DataSet ds = bal.pr_get_Subjectmasterbyid(UID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    btn_add.Visible = false;
                    txt_search.Visible = false;
                    txt_Subjectname.Text = ds.Tables[0].Rows[0]["SubjectName"].ToString();
                    txt_description.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    Session["SubID"] = ds.Tables[0].Rows[0]["SubID"].ToString();
                }
            }

        }
    }
}
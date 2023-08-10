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
    public partial class RackMaster : System.Web.UI.Page
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
                bindsectionmaster();
            }

        }
        public void bindgriddata()
        {
            LMBAL objMaster = new LMBAL();
            DataSet ds = objMaster.GETALLRacksMaster();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid_data.DataSource = ds;
                grid_data.DataBind();
            }

        }
        public void bindsectionmaster()
        {
            LMBAL objMaster = new LMBAL();
            ddl_sectionname.Items.Clear();

            //ddl_sectionname.Items.Insert(0, new ListItem("Select District Name", "0"));
            DataSet dt_Set = objMaster.GETALLRacksection();
            if (dt_Set.Tables[0].Rows.Count > 0)
            {
                ddl_sectionname.DataSource = dt_Set.Tables[0];
                ddl_sectionname.DataTextField = "SectionName";
                ddl_sectionname.DataValueField = "SecMID";
                ddl_sectionname.DataBind();
                ddl_sectionname.Items.Insert(0, new ListItem("Select Section Name", "0"));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Section Name not loading')", true);
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                RactMaster objrs = new RactMaster();
                objrs.SectionName = ddl_sectionname.SelectedItem.Value;
                objrs.RackName = txt_RackName.Text;
                objrs.NumberofSelfs = txt_noofselfs.Text;
                objrs.Description = txt_description.Text;
                objrs.IsActive = "1";
                if (Session["RackID"] != null && !string.IsNullOrWhiteSpace(Session["RackID"].ToString()))
                {
                    objrs.flag = "2";
                    objrs.CreatedBy = "";
                    objrs.CreatedIP = "";
                    objrs.ModifyBy = Session["MemberID"].ToString();
                    objrs.ModifyIp = Request.ServerVariables["Remote_Addr"];
                    objrs.RackID = Session["RackID"].ToString();
                }
                else
                {
                    objrs.flag = "1";
                    objrs.CreatedBy = Session["MemberID"].ToString();
                    objrs.CreatedIP = Request.ServerVariables["Remote_Addr"];
                    objrs.ModifyBy = "";
                    objrs.ModifyIp = "";
                    objrs.RackID = "";
                }
                DataSet ds = new DataSet();
                LMBAL objbal = new LMBAL();
                ds = objbal.INSRacksMaster(objrs);
                if (ds.Tables[0].Rows[0]["result"].ToString() == "Success")
                {
                    div_success.Visible = true;
                    ddl_sectionname.SelectedItem.Value ="0";
                    txt_noofselfs.Text = "";
                    txt_RackName.Text = "";
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
            Response.Redirect("RackMaster.aspx");
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> SearchText(string prefixText, int count)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_serch_SectionMaster(prefixText);
            List<string> address = new List<string>();

            foreach (DataRow row in dt_Set.Tables[0].Rows)
            {
                address.Add(row["SectionName"].ToString());

            }
            return address;
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_serch_RackMaster(txt_search.Text);
            grid_data.DataSource = dt_Set;
            grid_data.DataBind();
        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                string UID = e.CommandArgument.ToString();

                LMBAL bal = new LMBAL();
                DataSet ds = bal.pr_get_Rackmasterbyid(UID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    btn_add.Visible = false;
                    txt_search.Visible = false;
                    // txt_Sectionname.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
                    ddl_sectionname.SelectedValue = ds.Tables[0].Rows[0]["SectionName"].ToString();
                    txt_RackName.Text= ds.Tables[0].Rows[0]["RackName"].ToString();
                    txt_noofselfs.Text= ds.Tables[0].Rows[0]["NoOfSelfs"].ToString();
                    txt_description.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    Session["RackID"] = ds.Tables[0].Rows[0]["RackID"].ToString();
                }
            }

        }
    }
}
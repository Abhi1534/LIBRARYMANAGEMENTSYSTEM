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
    public partial class SelfMaster : System.Web.UI.Page
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
            DataSet ds = objMaster.Pr_GetALLselfMaster();
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
                SelfMasteradd objrs = new SelfMasteradd();
                objrs.SectionName = ddl_sectionname.SelectedItem.Value;
                objrs.RackName = ddl_RackName.SelectedValue;
                objrs.NumberofSelfs = ddl_NoOfSelfs.SelectedItem.Text;
                objrs.NumberofBooks = txt_numberofbooksinself.Text;
                objrs.Description = txt_description.Text;
                objrs.CreatedBy = "1"; //Session["MemberID"].ToString();
                objrs.CreatedIP = Request.ServerVariables["Remote_Addr"];
                objrs.IsActive = "1";
                DataSet ds = new DataSet();
                LMBAL objbal = new LMBAL();
                ds = objbal.INSselfmaster(objrs);
                if (ds.Tables[0].Rows[0]["result"].ToString() == "Success")
                {
                    div_success.Visible = true;
                    ddl_sectionname.SelectedItem.Value = "0";
                    //txt_noofselfs.Text = "";
                    //txt_RackName.Text = "";
                    //txt_description.Text = "";

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
            Response.Redirect("SelfMaster.aspx");

        }
       

        protected void ddl_sectionname_SelectedIndexChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            ddl_RackName.Items.Clear();
            string section = ddl_sectionname.SelectedValue;
           // ddl_NoOfSelfs.Items.Insert(0, new ListItem("Select Rack Name", "0"));
            DataSet dt_Set = objMaster.Pr_GetRacknamebysection(section);
            if (dt_Set.Tables[0].Rows.Count > 0)
            {
                ddl_RackName.DataSource = dt_Set.Tables[0];
                ddl_RackName.DataTextField = "RackName";
                ddl_RackName.DataValueField = "RackID";
                ddl_RackName.DataBind();
                ddl_RackName.Items.Insert(0, new ListItem("Select Rack Name", "0"));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Rack Name not loading')", true);
            }
        }

        protected void ddl_RackName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            ddl_NoOfSelfs.Items.Clear();

            string section = ddl_sectionname.SelectedValue;
            string Rack = ddl_RackName.SelectedValue;
          //  ddl_NoOfSelfs.Items.Insert(0, new ListItem("Select Rack Name", "0"));
            DataSet dt_Set = objMaster.GETSelfsbyRack(section, Rack);
            if (dt_Set.Tables[0].Rows.Count > 0)
            {
              int noofselfs=Convert.ToInt32(dt_Set.Tables[0].Rows[0]["NoOfSelfs"].ToString());


               // ddl_NoOfSelfs.DataSource = dt_Set.Tables[0];
                for (int i = 0; i < noofselfs; i++)
                {
                    ddl_NoOfSelfs.Items.Insert(i, new ListItem((i + 1).ToString(), (i + 1).ToString()));
                }

                //ddl_NoOfSelfs.DataTextField = "NoOfSelfs";
                //ddl_NoOfSelfs.DataValueField = "RackID";
                //ddl_NoOfSelfs.DataBind();
                ddl_NoOfSelfs.Items.Insert(0, new ListItem("Select Self Number", "0"));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Rack Name not loading')", true);
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> SearchText(string prefixText, int count)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_serch_Selfmaster(prefixText);
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
            DataSet dt_Set = objMaster.pr_get_serch_Selfmaster(txt_search.Text);
            grid_data.DataSource = dt_Set;
            grid_data.DataBind();
        }
        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                string UID = e.CommandArgument.ToString();

                LMBAL bal = new LMBAL();
                DataSet ds = bal.pr_get_SelfmasterbyID(UID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    btn_add.Visible = false;
                    txt_search.Visible = false;
                    ddl_sectionname.SelectedValue = ds.Tables[0].Rows[0]["SectionName"].ToString();
                    ddl_RackName.SelectedValue = ds.Tables[0].Rows[0]["RackName"].ToString();
                    ddl_NoOfSelfs.SelectedValue = ds.Tables[0].Rows[0]["NoOfSelfs"].ToString();
                    txt_numberofbooksinself.Text = ds.Tables[0].Rows[0]["NoOfBooksInself"].ToString();
                    txt_description.Text = ds.Tables[0].Rows[0]["Description"].ToString();                  
                    Session["SelMID"] = ds.Tables[0].Rows[0]["SelMID"].ToString();
                }
            }
        }
    }
}
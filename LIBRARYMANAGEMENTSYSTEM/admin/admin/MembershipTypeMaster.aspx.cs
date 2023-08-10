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
    public partial class MembershipTypeMaster : System.Web.UI.Page
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
            DataSet ds = objMaster.GETALLMembershiptype();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid_data.DataSource = ds;
                grid_data.DataBind();
            }

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                Membershiptypemaster objmtm = new Membershiptypemaster();
                objmtm.Membershiptype = txt_membershiptypename.Text;
                objmtm.Subscription = txt_SubscriptionAmount.Text;
                objmtm.EntranceFee = txt_EntranceFee.Text;
                objmtm.IdentityCard = txt_identitycardfee.Text;
                objmtm.ApplicationForm = txt_ApplicationFormFee.Text;
                objmtm.Miscellaneous = txt_Miscellaneousfee.Text;
                objmtm.EntryIdentityCard = txt_EntryIdentitycard.Text;
                objmtm.Description = txt_description.Text; 
                int total= Convert.ToInt32(txt_SubscriptionAmount.Text) + Convert.ToInt32(txt_EntranceFee.Text) + Convert.ToInt32(txt_identitycardfee.Text) +
                    Convert.ToInt32(txt_ApplicationFormFee.Text) + Convert.ToInt32(txt_Miscellaneousfee.Text) + Convert.ToInt32(txt_EntryIdentitycard.Text);
                objmtm.totalfee = total.ToString();
                objmtm.IsActive = "1";
                if (Session["MemshiptypeID"] != null && !string.IsNullOrWhiteSpace(Session["MemshiptypeID"].ToString()))
                {
                    objmtm.flag = "2";
                    objmtm.CreatedBy = "";
                    objmtm.CreatedIP = "";
                    objmtm.ModifyBy= Session["MemberID"].ToString();
                    objmtm.ModifyIp= Request.ServerVariables["Remote_Addr"];
                    objmtm.Membershiptypeid = Session["MemshiptypeID"].ToString();
                }
                else
                {
                    objmtm.flag = "1";
                    objmtm.CreatedBy = Session["MemberID"].ToString();
                    objmtm.CreatedIP = Request.ServerVariables["Remote_Addr"];
                    objmtm.ModifyBy = "";
                    objmtm.ModifyIp = "";
                    objmtm.Membershiptypeid = "";
                }

                DataSet ds = new DataSet();
                LMBAL objbal = new LMBAL();
                ds = objbal.INSMembershiptype(objmtm);

                if (ds.Tables[0].Rows[0]["result"].ToString() == "Success")
                {
                    div_success.Visible = true;
                    txt_membershiptypename.Text = "";
                    txt_SubscriptionAmount.Text = "";
                    txt_EntranceFee.Text = "";
                    txt_identitycardfee.Text = "";
                    txt_ApplicationFormFee.Text = "";
                    txt_Miscellaneousfee.Text = "";
                    txt_EntryIdentitycard.Text = "";
                    txt_description.Text = "";
                    txt_totalfee.Text = "";
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
            Response.Redirect("MembershipTypeMaster.aspx");

        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> SearchText(string prefixText, int count)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_serch_membershiptype(prefixText);
            List<string> address = new List<string>();

            foreach (DataRow row in dt_Set.Tables[0].Rows)
            {
                address.Add(row["MembershipTypeName"].ToString());

            }
            return address;
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_serch_membershiptype(txt_search.Text);
            grid_data.DataSource = dt_Set;
            grid_data.DataBind();
        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                string UID = e.CommandArgument.ToString();

                LMBAL bal = new LMBAL();
                DataSet ds = bal.pr_get_membershiptypeMasterbyid(UID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    btn_add.Visible = false;
                    txt_search.Visible = false;
                    txt_membershiptypename.Text = ds.Tables[0].Rows[0]["MembershipTypeName"].ToString();
                    txt_SubscriptionAmount.Text = ds.Tables[0].Rows[0]["Subscription"].ToString();
                    txt_EntranceFee.Text = ds.Tables[0].Rows[0]["EntranceFee"].ToString();
                    txt_identitycardfee.Text = ds.Tables[0].Rows[0]["IdentityCard"].ToString();
                    txt_ApplicationFormFee.Text = ds.Tables[0].Rows[0]["ApplicationForm"].ToString();
                    txt_Miscellaneousfee.Text = ds.Tables[0].Rows[0]["Miscellaneous"].ToString();
                    txt_EntryIdentitycard.Text = ds.Tables[0].Rows[0]["EntryIdentityCard"].ToString();
                    txt_description.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    txt_totalfee.Text= ds.Tables[0].Rows[0]["totalfee"].ToString();
                    Session["MemshiptypeID"] = ds.Tables[0].Rows[0]["MemID"].ToString();
                }
            }
        }
    }
}
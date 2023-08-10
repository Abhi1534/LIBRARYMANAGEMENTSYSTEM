using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            if (!IsPostBack)
            {
                binddashboarddata();
            }
        }

        public void binddashboarddata()
        {
            string fromdate = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            string todate = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            LMBAL objMaster = new LMBAL();
            DataSet ds = objMaster.pr_get_Dashboarddata(fromdate, todate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_noofmembers.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lbl_noofmembers.Text = "0";
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                lbl_totalbooks.Text = ds.Tables[1].Rows[0][0].ToString();
            }
            else
            {
                lbl_totalbooks.Text = "0";
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                lbl_todayissued.Text = ds.Tables[2].Rows[0][0].ToString();
            }
            else
            {
                lbl_todayissued.Text = "0";

            }


            if (ds.Tables[3].Rows.Count > 0)
            {
                if (ds.Tables[3].Rows[0]["NoOfBooksIssued"].ToString() != "")
                {
                    int bicount = Convert.ToInt32(ds.Tables[3].Rows[0]["NoOfBooksIssued"].ToString());
                    if (ds.Tables[4].Rows[0]["NoOfBooksreturn"].ToString() != "")
                    {
                        int brcount = Convert.ToInt32(ds.Tables[4].Rows[0]["NoOfBooksreturn"].ToString());
                        if (brcount==null)
                        {
                            brcount = 0;
                        }
                        lbl_pendingcopies.Text = Convert.ToInt32(bicount - brcount).ToString();
                    }
                    else
                    {
                        lbl_pendingcopies.Text =Convert.ToInt32(bicount).ToString();
                    }
                    
                }



            }
            else
            {
                lbl_pendingcopies.Text = "0";

            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                if (ds.Tables[5].Rows[0]["Amount"] != null && !string.IsNullOrWhiteSpace(ds.Tables[5].Rows[0]["Amount"].ToString()))
                {
                    lbl_todayonlinecollection.Text = ds.Tables[5].Rows[0]["Amount"].ToString();
                }
                else
                {
                    lbl_todayonlinecollection.Text = "0";
                }
            }
            else
            {
                lbl_todayonlinecollection.Text = "0";

            }
            if (ds.Tables[6].Rows[0]["Amount"] != null && !string.IsNullOrWhiteSpace(ds.Tables[6].Rows[0]["Amount"].ToString()))
            {
                lbl_todayofflinecollection.Text = ds.Tables[6].Rows[0]["Amount"].ToString();
            }
            else
            {
                lbl_todayofflinecollection.Text = "0";

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }

        protected void btn_passwordsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string username = Session["MobileNumber"].ToString();
                string password = txt_oldpassword.Text;
                LMBAL bal = new LMBAL();
                DataSet ds = bal.pr_get_logindetails(username, password);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string newpassword = txt_password.Text;
                    DataSet ds1 = bal.pr_updatepassword(newpassword, username);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        div_success.Visible = true;
                        div_fail.Visible = false;
                   
                    }
                    else
                    {
                        div_success.Visible = false;
                        div_fail.Visible = true;
                    }
                }
                else
                {

                }


            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
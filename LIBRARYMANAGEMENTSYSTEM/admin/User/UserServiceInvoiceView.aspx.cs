using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class UserServiceInvoiceView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_amount.Text = Session["membershipfee"].ToString();
                lbl_finaltotal.Text = Session["membershipfee"].ToString();
                lbl_Inviocername.Text = Session["MembershipName"].ToString();
                lbl_invoicenumber.Text = Session["Invoicenumber"].ToString();
                lbl_invoiceremail.Text = Session["MembershipEmailID"].ToString();
                lbl_invoicermobile.Text = Session["Membershipmobilenumber"].ToString();               
                lbl_OrderIDDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                lbl_totalamount.Text = Session["membershipfee"].ToString();
                lbl_invoiceto.Text = Session["PageIntiateforpayment"].ToString();
                lbl_Service.Text= Session["PageIntiateforpayment"].ToString();
            }
        }
    }
}
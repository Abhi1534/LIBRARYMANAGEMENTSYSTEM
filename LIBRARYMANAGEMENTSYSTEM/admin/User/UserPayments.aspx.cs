using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class UserPayments : System.Web.UI.Page
    {
        public string orderId;

        public string oid = String.Empty;
        public string finalpay = String.Empty;

        public string currency = "INR";

        public string orderid = String.Empty;
        public string nettotal = String.Empty;

        public string canname = String.Empty;
        public string canemail = String.Empty;
        public string cantel = String.Empty;

        public string baseid = String.Empty;
        LMBAL objbal = new LMBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int useid = Convert.ToInt32(Session["MemberID"].ToString());
                baseid = useid.ToString();

                string customerid;
                DataSet ds2 = objbal.pr_get_INVNum_auto();

                if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {

                    canname = Session["MembershipName"].ToString();
                    canemail = Session["MembershipEmailID"].ToString();
                    cantel = Session["Membershipmobilenumber"].ToString();
                    orderid = ds2.Tables[0].Rows[0]["INVNUM"].ToString();
                    Session["Invoicenumber"] = ds2.Tables[0].Rows[0]["INVNUM"].ToString();
                    nettotal = Session["membershipfee"].ToString();
                    customerid = useid.ToString();
                }


                double newtotal = Convert.ToDouble(nettotal) * 100;
                finalpay = newtotal.ToString();

                Label1.Text = nettotal;
                Label2.Text = orderid;
                Label3.Text = "INR";


                Dictionary<string, object> input = new Dictionary<string, object>();
                input.Add("amount", finalpay); // this amount should be same as transaction amount
                input.Add("currency", "INR");
                input.Add("receipt", orderid);
                input.Add("payment_capture", 1);

                string key = "rzp_test_NgNYlgLkruqfY1";
                string secret = "zDtTBIZEOFrNz1EZwNU2My22";

                RazorpayClient client = new RazorpayClient(key, secret);

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                Razorpay.Api.Order order = client.Order.Create(input);
                orderId = order["id"].ToString();
            }
            catch
            {
                Response.Redirect("404.aspx");
            }
        }
    }
}
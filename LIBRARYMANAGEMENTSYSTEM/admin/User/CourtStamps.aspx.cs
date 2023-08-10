using Newtonsoft.Json;
using Paytm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;
using System.Text;
using Newtonsoft.Json;
using System.Data;
using System.Web.Script.Serialization;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class CourtStamps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //paymentresendlink();
                //paymentlinkresponse();
                ////   paymentlink();
            }
        }

        protected void txt_numberofstamps_TextChanged(object sender, EventArgs e)
        {
            if (ddl_stamptype.SelectedItem.Text != "")
            {
                int amount = Convert.ToInt32(ddl_stamptype.SelectedItem.Text);
                int noofqun = Convert.ToInt32(txt_numberofstamps.Text);
                int total = amount * noofqun;
                txt_price.Text = Convert.ToString(total);
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (Session["ChallanCaptcha"] != null && txtCaptcha.Text == Session["ChallanCaptcha"].ToString())
            {
               // paymentlink();
                PaymentStamps objpay = new PaymentStamps();
                objpay.Name = txt_Advocatename.Text;
                objpay.MobileNumber = txt_MobileNumber.Text;
                objpay.Email = txt_email.Text;
                objpay.enrollmentNumber = "";
                objpay.NumberOfStamps = txt_numberofstamps.Text;
                objpay.TotalPrice = txt_price.Text;
                objpay.ResAddress = "";
                objpay.NameofStamp = "";
                Session["MemberID"] = "0";
                Session["MembershipName"] = txt_Advocatename.Text;
                Session["MembershipEmailID"] = txt_email.Text;
                Session["Membershipmobilenumber"] = txt_MobileNumber.Text;
                Session["membershipfee"] =  txt_price.Text;
                Session["PageIntiateforpayment"] = "CourtStamps";
                Session["MembershiptypeName"] = txt_numberofstamps.Text;
                Session["headofinvoice"] = "No Of Stamps";
                Session["Stampprice"] = ddl_stamptype.SelectedItem.Text;
                Session["PageName"] = "CourtStamps";
                Response.Redirect("../../PaytmPaymentInitiation.aspx");
            }
            else
            {
                txtCaptcha.Text = string.Empty;
                lblerrorMsg.Visible = true;
                lblerrorMsg.Text = "Please Enter Valid Captcha";
            }
        }

        public void paymentlink()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

            LMBAL objbal = new LMBAL();
            DataSet ds2 = objbal.pr_get_INVNum_auto();
            Session["Invoicenumber"] = ds2.Tables[0].Rows[0]["INVNUM"].ToString();
            Dictionary<string, object> body = new Dictionary<string, object>();
            Dictionary<string, object> head = new Dictionary<string, object>();
            Dictionary<string, Dictionary<string, object>> requestBody = new Dictionary<string, Dictionary<string, object>>();

            body.Add("merchantRequestId", ds2.Tables[0].Rows[0]["INVNUM"].ToString());
            body.Add("mid", "TELANG03979848583519");
            body.Add("linkType", "FIXED");
            body.Add("linkDescription", "Test  Payment");
            body.Add("linkName", "Test");
            body.Add("amount", txt_price.Text);

            body.Add("sendSms", "true");

            Dictionary<string, string> customerContact = new Dictionary<string, string>();
            customerContact.Add("customerName", txt_Advocatename.Text);
            customerContact.Add("customerEmail", txt_email.Text);
            customerContact.Add("customerMobile", txt_MobileNumber.Text);
            body.Add("customerContact", customerContact);

            head.Add("tokenType", "AES");
            //  Generate  CheckSum  here  from  Paytm  Library.
            string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), "MKaJnBObQy0plkBb");

            head.Add("signature", paytmChecksum);

            requestBody.Add("body", body);
            requestBody.Add("head", head);

            string post_data = JsonConvert.SerializeObject(requestBody);

            //For  Staging  url
            string url = "https://securegw-stage.paytm.in/link/create";

            //For  Production  url
            //string  url  =  "https://securegw.paytm.in/link/create";

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = post_data.Length;

            using (StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                requestWriter.Write(post_data);
            }

            string responseData = string.Empty;

            using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                responseData = responseReader.ReadToEnd();
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                LMBO.CreateLinkResponse objResp = new LMBO.CreateLinkResponse();
                objResp = json_serializer.Deserialize<LMBO.CreateLinkResponse>(responseData);
                if (objResp != null)
                {
                    if (objResp.body != null)
                    {
                        if (objResp.body.resultInfo != null)
                        {
                            if (objResp.body.resultInfo.resultStatus == "SUCCESS")
                            {
                                string result = CheckStatus(objResp.body.linkId.ToString());
                                JavaScriptSerializer json = new JavaScriptSerializer();
                                LMBO.CheckResponse objCheckResp = new LMBO.CheckResponse();
                                objCheckResp = json_serializer.Deserialize<LMBO.CheckResponse>(result);
                                if (objCheckResp != null)
                                {
                                    if (objCheckResp.body != null)
                                    {
                                        if (objCheckResp.body.resultInfo != null)
                                        {
                                            if (objCheckResp.body.resultInfo.resultStatus == "SUCCESS")
                                            {
                                                Response.Redirect("../PaymentConformation.aspx");
                                            }
                                        }
                                    }
                                }

                                //  Response.Redirect("admin/PaymentConformation.aspx");

                            }

                        }
                    }
                }
            }




        }

        public string CheckStatus( string linkID)
        {
            //  Dictionary<string, string> body1 = new Dictionary<string, string>();
            //  Dictionary<string, string> head1 = new Dictionary<string, string>();
            //  Dictionary<string, Dictionary<string, string>> requestBody1 = new Dictionary<string, Dictionary<string, string>>();

            ////  body1.Add("mid", ConfigurationManager.AppSettings["paymentMid"].ToString());
            //  body1.Add("mid", "TELANG03979848583519");
            //   body1.Add("orderId", Session["Invoicenumber"].ToString());

            //  /*
            //  * Generate checksum by parameters we have in body
            //  * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
            //  */
            //  string paytmChecksum1 = Checksum.generateSignature(JsonConvert.SerializeObject(body1), "MKaJnBObQy0plkBb");// ConfigurationManager.AppSettings["paymentKey"].ToString());

            //  head1.Add("signature", paytmChecksum1);

            //  requestBody1.Add("body", body1);
            //  requestBody1.Add("head", head1);

            //  string post_data1 = JsonConvert.SerializeObject(requestBody1);

            //  //For  Staging
            //  string url1 = "https://securegw-stage.paytm.in/v3/order/status";

            //  //For  Production 
            //  //string  url  =  "https://securegw.paytm.in/v3/order/status";

            //  HttpWebRequest webRequest1 = (HttpWebRequest)WebRequest.Create(url1);

            //  webRequest1.Method = "POST";
            //  webRequest1.ContentType = "application/json";
            //  webRequest1.ContentLength = post_data1.Length;

            //  using (StreamWriter requestWriter = new StreamWriter(webRequest1.GetRequestStream()))
            //  {
            //      requestWriter.Write(post_data1);
            //  }

            //  string responseData1 = string.Empty;

            //  using (StreamReader responseReader1 = new StreamReader(webRequest1.GetResponse().GetResponseStream()))
            //  {
            //      responseData1 = responseReader1.ReadToEnd();
            //      Console.WriteLine(responseData1);

            //      //  responseData1 = responseReader1.ReadToEnd();
            //      JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            //      LMBO.PaymentStatusResponse objResp = new LMBO.PaymentStatusResponse();
            //      objResp = json_serializer.Deserialize<LMBO.PaymentStatusResponse>(responseData1);
            //      if (objResp != null)
            //      {
            //          if (objResp.body != null)
            //          {
            //              if (objResp.body.resultInfo != null)
            //              {
            //                  if (objResp.body.resultInfo.resultStatus == "TXN_SUCCESS")
            //                  {
            //                      Response.Redirect("admin/PaymentConformation.aspx");
            //                      //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Transaction has been Success, Transaction ID is: '" + objResp.body.txnId + "')", true);
            //                      //return;
            //                  }
            //                  else
            //                  {
            //                      //lblStatus.Text = objResp.body.resultInfo.resultStatus;
            //                      //lblAmount.Text = objResp.body.txnAmount;
            //                      //Session["Response"] = objResp;
            //                      //Session["mid"] = "TELANG38998201047460";
            //                      //Response.Redirect("../PaymentFailure.aspx");
            //                  }
            //              }
            //          }
            //      }
            //  }

            Dictionary<string, string> body = new Dictionary<string, string>();
            Dictionary<string, string> head = new Dictionary<string, string>();
            Dictionary<string, object> requestBody = new Dictionary<string, object>();

            body.Add("mid", "TELANG03979848583519");
            body.Add("linkId", "454660");

            head.Add("tokenType", "AES");

            //  Generate  CheckSum  here  from  Paytm  Library.
            string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), "MKaJnBObQy0plkBb");

            head.Add("signature", paytmChecksum);

            requestBody.Add("body", body);
            requestBody.Add("head", head);

            string post_data = JsonConvert.SerializeObject(requestBody);

            //For  Staging  url
            string url = "https://securegw-stage.paytm.in/link/fetchTransaction";

            //For  Production  url
            //string  url  =  "https://securegw.paytm.in/link/fetchTransaction";

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = post_data.Length;

            using (StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                requestWriter.Write(post_data);
            }

            string responseData = string.Empty;

            using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                responseData = responseReader.ReadToEnd();
            }
            return responseData;

        }

        public void paymentlinkresponse()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            Dictionary<string, string> body = new Dictionary<string, string>();
            Dictionary<string, string> head = new Dictionary<string, string>();
            Dictionary<string, object> requestBody = new Dictionary<string, object>();

            body.Add("mid", "TELANG03979848583519");
            body.Add("linkId", "454660");

            head.Add("tokenType", "AES");

            //  Generate  CheckSum  here  from  Paytm  Library.
            string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), "MKaJnBObQy0plkBb");

            head.Add("signature", paytmChecksum);

            requestBody.Add("body", body);
            requestBody.Add("head", head);

            string post_data = JsonConvert.SerializeObject(requestBody);

            //For  Staging  url
            string url = "https://securegw-stage.paytm.in/link/fetchTransaction";

            //For  Production  url
            //string  url  =  "https://securegw.paytm.in/link/fetchTransaction";

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = post_data.Length;

            using (StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                requestWriter.Write(post_data);
            }

            string responseData = string.Empty;

            using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                responseData = responseReader.ReadToEnd();
            }

        }

        public void paymentresendlink()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            Dictionary<string, object> body = new Dictionary<string, object>();
            Dictionary<string, string> head = new Dictionary<string, string>();
            Dictionary<string, object> requestBody = new Dictionary<string, object>();

            body.Add("mid", "TELANG03979848583519");
            body.Add("linkId", "454660");
            body.Add("sendSms", "true");
            Dictionary<string, string> notifyContact = new Dictionary<string, string>();
            notifyContact.Add("customerMobile", "8121191086");
            body.Add("notifyContact", notifyContact);

            head.Add("tokenType", "AES");

            //  Generate  CheckSum  here  from  Paytm  Library.
            string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), "MKaJnBObQy0plkBb");

            head.Add("signature", paytmChecksum);

            requestBody.Add("body", body);
            requestBody.Add("head", head);

            string post_data = JsonConvert.SerializeObject(requestBody);

            //For  Staging  url
            string url = "https://securegw-stage.paytm.in/link/resendNotification";

            //For  Production  url
            //string  url  =  "https://securegw.paytm.in/link/resendNotification";

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = post_data.Length;

            using (StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                requestWriter.Write(post_data);
            }

            string responseData = string.Empty;

            using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                responseData = responseReader.ReadToEnd();
                Console.WriteLine(responseData);
            }

        }
    }
}
using LIBRARYMANAGEMENTSYSTEM.admin;
using Newtonsoft.Json;
using Paytm;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System.Web.Script.Serialization;
using System.Configuration;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM
{
    public partial class PaytmPaymentInitiation : System.Web.UI.Page
    {
        public string orderId;
        public string orderid = String.Empty;
        public string amount = String.Empty;

        public string post_data = String.Empty;
        LMBAL objbal = new LMBAL();


        protected void Page_Load(object sender, EventArgs e)
        {
            try {
             //   Session["membershipfee"] = "1";
                string mID = "";
                string paymentLink = "";
                if (Session["PageIntiateforpayment"] != null)
                {

                    if (Session["PageIntiateforpayment"].ToString() == "JudicialStamps" || Session["PageIntiateforpayment"].ToString() == "CourtStamps")
                    {
                        mID = ConfigurationManager.AppSettings["smsPaymentLinkMid"].ToString();
                        paymentLink = ConfigurationManager.AppSettings["smspaymentLinkKey"].ToString();
                    }

                    else if (Session["PageIntiateforpayment"].ToString() == "Proximity Card")
                    {
                        paymentLink = ConfigurationManager.AppSettings["smspaymentLinkKey2"].ToString();
                        mID = ConfigurationManager.AppSettings["smsPaymentLinkMid2"].ToString();
                    }
                    else if (Session["PageIntiateforpayment"].ToString() == "ID Card" || Session["PageIntiateforpayment"].ToString() == "Donations" || Session["PageIntiateforpayment"].ToString() == "Car Pass" || Session["PageIntiateforpayment"].ToString() == "Practice Certificate")
                    {
                        paymentLink = @"VuU%&CWv#1dUFTjm";
                        mID = ConfigurationManager.AppSettings["smsPaymentLinkMid1"].ToString();


                    }
                    else
                    {
                        paymentLink = @"VuU%&CWv#1dUFTjm";
                        mID = ConfigurationManager.AppSettings["smsPaymentLinkMid1"].ToString();
                    }
                }
                if (!IsPostBack)
                {
                    
                    paymentlink(paymentLink, mID);
                    timerRefresh.Enabled = true;
                    lblTimer.Text = ConfigurationManager.AppSettings["PaymentTimeOut"].ToString();
                    hfTimer.Value = ConfigurationManager.AppSettings["PaymentTimeOut"].ToString();
                    paymentinitiation(paymentLink, mID);
                    //  paymentlink();
                }
                // string a=  lblTimer.Text;
                int time = Convert.ToInt32(hfTimer.Value);

                if (time == 0)
                {
                    Session["Response"] = "";
                    Session["mid"] = mID.ToString();// ConfigurationManager.AppSettings["paymentMid"].ToString();
                    Response.Redirect("PaymentFailure.aspx");
                }
                else //if (time % 5 == 0)
                {
                    Dictionary<string, string> body1 = new Dictionary<string, string>();
                    Dictionary<string, string> head1 = new Dictionary<string, string>();
                    Dictionary<string, Dictionary<string, string>> requestBody1 = new Dictionary<string, Dictionary<string, string>>();

                    body1.Add("mid", mID.ToString());
                    body1.Add("orderId", Session["Invoicenumber"].ToString());

                    /*
                    * Generate checksum by parameters we have in body
                    * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
                    */
                    string paytmChecksum1 = Checksum.generateSignature(JsonConvert.SerializeObject(body1), paymentLink.ToString());

                    head1.Add("signature", paytmChecksum1);

                    requestBody1.Add("body", body1);
                    requestBody1.Add("head", head1);

                    string post_data1 = JsonConvert.SerializeObject(requestBody1);

                    //For  Staging
                    string url1 = ConfigurationManager.AppSettings["paymentgatwayurlforQRCodeStatus"].ToString();

                    //For  Production 
                    //string  url  =  ConfigurationManager.AppSettings["productionpaymentgatwaystageurlforqrstatus"].ToString();

                    HttpWebRequest webRequest1 = (HttpWebRequest)WebRequest.Create(url1);

                    webRequest1.Method = "POST";
                    webRequest1.ContentType = "application/json";
                    webRequest1.ContentLength = post_data1.Length;

                    using (StreamWriter requestWriter = new StreamWriter(webRequest1.GetRequestStream()))
                    {
                        requestWriter.Write(post_data1);
                    }

                    string responseData1 = string.Empty;

                    using (StreamReader responseReader1 = new StreamReader(webRequest1.GetResponse().GetResponseStream()))
                    {
                        responseData1 = responseReader1.ReadToEnd();


                        LBR_DAL objDal = new LBR_DAL();
                        // responseData1 = responseReader1.ReadToEnd();
                        JavaScriptSerializer json_serializer1 = new JavaScriptSerializer();
                        LMBO.PaymentStatusResponse objResp = new LMBO.PaymentStatusResponse();
                        objResp = json_serializer1.Deserialize<LMBO.PaymentStatusResponse>(responseData1);
                        if (objResp != null)
                        {
                            if (objResp.body != null)
                            {
                                if (objResp.body.resultInfo != null)
                                {
                                    if (objResp.body.resultInfo.resultStatus == "TXN_SUCCESS")
                                    {
                                        Response.Redirect("admin/PaymentConformation.aspx");

                                    }

                                }
                            }
                        }
                    }
                    if (Session["linkId"] != null)
                    {
                        string result = CheckStatus(Session["linkId"].ToString(), paymentLink.ToString(),mID.ToString());
                        JavaScriptSerializer json_serializer = new JavaScriptSerializer();
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
                                        if (objCheckResp.body.orders != null)
                                        {
                                            List<Order> objOrders = new List<Order>();
                                            objOrders = objCheckResp.body.orders;
                                            if (objOrders.Count > 0)
                                            {
                                                foreach (Order orders in objOrders)
                                                {
                                                    if (orders.orderStatus == "SUCCESS")
                                                    {
                                                     //   Response.Redirect("  admin / PaymentConformation.aspx", false);
                                                        Response.Redirect("admin/PaymentConformation.aspx");

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                }
            }
            catch(Exception ex)
            {
              //  Response.Redirect("../SessionExpired.aspx");
            }
        }

        protected void timerRefresh_Tick(object sender, EventArgs e)
        {
            int seconds = Convert.ToInt32(ConfigurationManager.AppSettings["PaymentTimeOut"].ToString());
            if (timerRefresh.Interval > seconds * 1000)

            {
                timerRefresh.Enabled = false;
            }
            else
            {
                timerRefresh.Interval = 5000; // Increase the timer interval by 5 seconds
            }
        }

        private void paymentinitiation(string paymentLink, string mID)
        {
            try { 
            //...abhishek...
            // ServicePointManager.Expect100Continue = true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;
            //...abhishek...end

            Dictionary<string, string> body = new Dictionary<string, string>();
            Dictionary<string, string> head = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, string>> requestBody = new Dictionary<string, Dictionary<string, string>>();
            DataSet ds2 = objbal.pr_get_INVNum_auto();



            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                Session["Invoicenumber"] = ds2.Tables[0].Rows[0]["INVNUM"].ToString();
                body.Add("mid",mID.ToString());
              //      body.Add("mid", ConfigurationManager.AppSettings["paymentMid"].ToString());
                body.Add("orderId", ds2.Tables[0].Rows[0]["INVNUM"].ToString());
                body.Add("amount", Session["membershipfee"].ToString());
                body.Add("businessType", "UPI_QR_CODE");
                body.Add("posId", ConfigurationManager.AppSettings["posId"].ToString());
                int useid = Convert.ToInt32(Session["MemberID"].ToString());
                string canname = Session["MembershipName"].ToString();
                string canemail = Session["MembershipEmailID"].ToString();
                string cantel = Session["Membershipmobilenumber"].ToString();
                Session["Invoicenumber"] = ds2.Tables[0].Rows[0]["INVNUM"].ToString();
                string nettotal = Session["membershipfee"].ToString();

            }
            var result = JsonConvert.SerializeObject(body);
            /*
            * Generate checksum by parameters we have in body
            * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
            */
            string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), paymentLink.ToString());

            head.Add("clientId", "C11");
            head.Add("version", "V1");
            head.Add("signature", paytmChecksum);

            requestBody.Add("body", body);
            requestBody.Add("head", head);

            string post_data = JsonConvert.SerializeObject(requestBody);

            //For  Staging
            string url = ConfigurationManager.AppSettings["paymentgatwayurlforQRCodeGenration"].ToString();

            //For  Production  url
            //string  url  =  ConfigurationManager.AppSettings["productionpaymentgatwaystageurlforqrgenration"].ToString();

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
                LBR_DAL objDal = new LBR_DAL();
                responseData = responseReader.ReadToEnd();
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                LMBO.PayMentResponse objResp = new LMBO.PayMentResponse();
                objResp = json_serializer.Deserialize<LMBO.PayMentResponse>(responseData);
                if (objResp.body != null)
                {
                    //  lblQRCOdeID.Text = objResp.body.qrCodeId;
                    if (objResp.body.resultInfo != null)
                    {
                        if (objResp.body.resultInfo.resultStatus == "SUCCESS")
                        {
                            imgQR.Src = "data:image/png;base64," + objResp.body.image;
                            string[] qrData = objResp.body.qrData.Split('&');

                            foreach (var item in qrData)
                            {
                                if (item.Contains("upi://pay"))
                                {

                                }
                                if (item.Contains("pn="))
                                {
                                    string[] itemValue = item.Split('=');
                                    lblPn.Text = itemValue[1].ToString().Replace("%20", " ");
                                }

                                else if (item.Contains("am="))
                                {
                                    string[] itemValue = item.Split('=');
                                    lblAmount.Text = itemValue[1].ToString();
                                }

                            }
                        }

                    }

                }

            }

            }
            catch (Exception ex)
            {
              //  Response.Redirect("../SessionExpired.aspx");
            }


        }

        // public Timer timer1;
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

        }


        public void paymentlink(string paymentLink,string mID)
        {
            try {
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
            body.Add("mid", mID.ToString());
                //body.Add("mid", ConfigurationManager.AppSettings["smsPaymentLinkMid"].ToString());
            body.Add("linkType", ConfigurationManager.AppSettings["smslinkType"].ToString());
            body.Add("linkDescription", "Test  Payment");
            body.Add("linkName", "Test");
            body.Add("amount", Session["membershipfee"].ToString());

            body.Add("sendSms", "true");

            Dictionary<string, string> customerContact = new Dictionary<string, string>();
            customerContact.Add("customerName", Session["MembershipName"].ToString());
            customerContact.Add("customerEmail", Session["MembershipEmailID"].ToString());
            customerContact.Add("customerMobile", Session["Membershipmobilenumber"].ToString());
            body.Add("customerContact", customerContact);

            head.Add("tokenType", "AES");
            //  Generate  CheckSum  here  from  Paytm  Library.
            string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), paymentLink.ToString());
           //     string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), ConfigurationManager.AppSettings["smspaymentLinkKey"].ToString());

            head.Add("signature", paytmChecksum);

            requestBody.Add("body", body);
            requestBody.Add("head", head);

            string post_data = JsonConvert.SerializeObject(requestBody);

            //For  Staging  url
            string url = ConfigurationManager.AppSettings["smsPaymentLinkCreate"].ToString();// "https://securegw-stage.paytm.in/link/create";

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
                                    lblAmount.Text = objResp.body.amount.ToString();
                                Session["linkID"] = objResp.body.linkId.ToString();
                                string result = CheckStatus(objResp.body.linkId.ToString(), paymentLink.ToString(),mID.ToString());
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
                                                //Response.Redirect("../PaymentConformation.aspx");
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
            catch (Exception ex)
            {
               // Response.Redirect("../SessionExpired.aspx");
            }


        }

        public string CheckStatus(string linkID, string paymentLink, string mID)
        {
            string responseData = string.Empty;
            try { 
            Dictionary<string, string> body = new Dictionary<string, string>();
            Dictionary<string, string> head = new Dictionary<string, string>();
            Dictionary<string, object> requestBody = new Dictionary<string, object>();

            body.Add("mid", mID.ToString());
          //  body.Add("mid", ConfigurationManager.AppSettings["smsPaymentLinkMid"].ToString());

           // body.Add("mid", "TELANG03979848583519");
            body.Add("linkId", linkID.ToString());

            head.Add("tokenType", "AES");

            //  Generate  CheckSum  here  from  Paytm  Library.
            //string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), ConfigurationManager.AppSettings["smspaymentLinkKey"].ToString());
            string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), paymentLink.ToString());

            head.Add("signature", paytmChecksum);

            requestBody.Add("body", body);
            requestBody.Add("head", head);

            string post_data = JsonConvert.SerializeObject(requestBody);

            //For  Staging  url
            string url = ConfigurationManager.AppSettings["smsPaymentLinkfetch"].ToString(); // "https://securegw-stage.paytm.in/link/fetchTransaction";

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

           

            using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                responseData = responseReader.ReadToEnd();
            }
            }
            catch (Exception ex)
            {
               // Response.Redirect("../SessionExpired.aspx");
            }
            return responseData;

        }

        //public void paymentlink()
        //{
        //    ServicePointManager.Expect100Continue = true;
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        //           | SecurityProtocolType.Tls11
        //           | SecurityProtocolType.Tls12
        //           | SecurityProtocolType.Ssl3;

        //    LMBAL objbal = new LMBAL();
        //    DataSet ds2 = objbal.pr_get_INVNum_auto();
        //    Session["Invoicenumber"] = ds2.Tables[0].Rows[0]["INVNUM"].ToString();
        //    Dictionary<string, object> body = new Dictionary<string, object>();
        //    Dictionary<string, object> head = new Dictionary<string, object>();
        //    Dictionary<string, Dictionary<string, object>> requestBody = new Dictionary<string, Dictionary<string, object>>();

        //    body.Add("merchantRequestId", ds2.Tables[0].Rows[0]["INVNUM"].ToString());
        //    body.Add("mid", ConfigurationManager.AppSettings["paymentLinkMid"].ToString());
        //    body.Add("linkType", "GENERIC");
        //    body.Add("linkDescription", "Test  Payment");
        //    body.Add("linkName", "Test");
        //    body.Add("amount", "10.00");
        //    Dictionary<string, string> customerContact = new Dictionary<string, string>();
        //    customerContact.Add("customerName", "Abhishek Machavarapu");
        //    customerContact.Add("customerEmail", "abhishekit015@gmail.com");
        //    customerContact.Add("customerMobile", "8121191086");
        //    body.Add("customerContact", customerContact);
        //    head.Add("tokenType", "AES");
        //    //  Generate  CheckSum  here  from  Paytm  Library.
        //    string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), ConfigurationManager.AppSettings["paymentLinkKey"].ToString());

        //    head.Add("signature", paytmChecksum);

        //    requestBody.Add("body", body);
        //    requestBody.Add("head", head);

        //    string post_data = JsonConvert.SerializeObject(requestBody);

        //    //For  Staging  url
        //    string url = ConfigurationManager.AppSettings["StagingpaymentLinkCreate"].ToString();

        //    //For  Production  url
        //    //string  url  =  ConfigurationManager.AppSettings["ProductionpaymentLinkCreate"].ToString();

        //    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

        //    webRequest.Method = "POST";
        //    webRequest.ContentType = "application/json";
        //    webRequest.ContentLength = post_data.Length;

        //    using (StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream()))
        //    {
        //        requestWriter.Write(post_data);
        //    }

        //    string responseData = string.Empty;

        //    using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
        //    {
        //        responseData = responseReader.ReadToEnd();
        //        //Console.WriteLine(responseData);
        //    }




        //}

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

            body.Add("mid", ConfigurationManager.AppSettings["paymentLinkMid"].ToString());
            body.Add("linkId", "454660");

            head.Add("tokenType", "AES");

            //  Generate  CheckSum  here  from  Paytm  Library.
            string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), ConfigurationManager.AppSettings["paymentLinkKey"].ToString());

            head.Add("signature", paytmChecksum);

            requestBody.Add("body", body);
            requestBody.Add("head", head);

            string post_data = JsonConvert.SerializeObject(requestBody);

            //For  Staging  url
            string url = ConfigurationManager.AppSettings["StagingpaymentLinkfetch"].ToString();

            //For  Production  url
            //string  url  =  ConfigurationManager.AppSettings["ProductionpaymentLinkfetch"].ToString();

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

            body.Add("mid", ConfigurationManager.AppSettings["paymentLinkMid"].ToString());
            body.Add("linkId", "454660");
            body.Add("sendSms", "true");
            Dictionary<string, string> notifyContact = new Dictionary<string, string>();
            notifyContact.Add("customerMobile", "8121191086");
            body.Add("notifyContact", notifyContact);

            head.Add("tokenType", "AES");

            //  Generate  CheckSum  here  from  Paytm  Library.
            string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), ConfigurationManager.AppSettings["paymentLinkKey"].ToString());

            head.Add("signature", paytmChecksum);

            requestBody.Add("body", body);
            requestBody.Add("head", head);

            string post_data = JsonConvert.SerializeObject(requestBody);

            //For  Staging  url
            string url = ConfigurationManager.AppSettings["StagingpaymentLinkResend"].ToString();

            //For  Production  url
            //string  url  =  ConfigurationManager.AppSettings["ProductionpaymentLinkResend"].ToString();

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
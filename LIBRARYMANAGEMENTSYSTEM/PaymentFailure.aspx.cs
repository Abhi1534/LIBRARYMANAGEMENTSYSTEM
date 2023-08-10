using LIBRARYMANAGEMENTSYSTEM.admin;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using Newtonsoft.Json;
using Paytm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM
{
    public partial class PaymentFailure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PaymentCheck();
            }
        }

        public void PaymentCheck()
        {
            //if (Session["PaytmResponse"] != null)
            //{
            //    LMBO.PayMentResponse objResp = new LMBO.PayMentResponse();
            //    objResp = (LMBO.PayMentResponse)Session["PaytmResponse"];
            //    if (objResp != null)
            //    {
            //        if (objResp.body != null)
            //        {
            //            if (objResp.body.resultInfo != null)
            //            {
            //                lblStatus.Text = objResp.body.resultInfo.resultStatus;
            //                lblAmount.Text = objResp.body.;
            //            }
            //        }
            //    }
            //}
            try
            {
                if (Session["Response"] != null && Session["Response"] != "")
                {
                    LMBO.PaymentStatusResponse objResp = new LMBO.PaymentStatusResponse();
                    objResp = (LMBO.PaymentStatusResponse)Session["Response"];
                    if (objResp != null)
                    {
                        if (objResp.body != null)
                        {
                            if (objResp.body.resultInfo != null)
                            {
                                lblStatus.Text = objResp.body.resultInfo.resultStatus;
                                lblAmount.Text = objResp.body.txnAmount;
                            }
                        }
                    }
                }
                else
                {

                    CheckStatus();
                }
            }
            catch (Exception ex)
            {
               // Response.Redirect("../SessionExpired.aspx");
            }
        }

        public void CheckStatus()
        {
            try
            {
                Dictionary<string, string> body1 = new Dictionary<string, string>();
                Dictionary<string, string> head1 = new Dictionary<string, string>();
                Dictionary<string, Dictionary<string, string>> requestBody1 = new Dictionary<string, Dictionary<string, string>>();

                body1.Add("mid", ConfigurationManager.AppSettings["paymentMid"].ToString());
                body1.Add("orderId", Session["Invoicenumber"].ToString());

                /*
                * Generate checksum by parameters we have in body
                * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
                */
                string paytmChecksum1 = Checksum.generateSignature(JsonConvert.SerializeObject(body1), ConfigurationManager.AppSettings["paymentKey"].ToString());

                head1.Add("signature", paytmChecksum1);

                requestBody1.Add("body", body1);
                requestBody1.Add("head", head1);

                string post_data1 = JsonConvert.SerializeObject(requestBody1);

                //For  Staging
                string url1 = ConfigurationManager.AppSettings["paymentgatwayurlforQRCodeStatus"].ToString();// "https://securegw-stage.paytm.in/v3/order/status";

                //For  Production 
                //string  url  =  "https://securegw.paytm.in/v3/order/status";

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
                    Console.WriteLine(responseData1);

                    LBR_DAL objDal = new LBR_DAL();
                    //  responseData1 = responseReader1.ReadToEnd();
                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    LMBO.PaymentStatusResponse objResp = new LMBO.PaymentStatusResponse();
                    objResp = json_serializer.Deserialize<LMBO.PaymentStatusResponse>(responseData1);
                    if (objResp != null)
                    {
                        if (objResp.body != null)
                        {
                            if (objResp.body.resultInfo != null)
                            {
                                if (objResp.body.resultInfo.resultStatus == "TXN_SUCCESS")
                                {
                                    Response.Redirect("admin/PaymentConformation.aspx");
                                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Transaction has been Success, Transaction ID is: '" + objResp.body.txnId + "')", true);
                                    //return;
                                }
                                else
                                {
                                    lblStatus.Text = objResp.body.resultInfo.resultStatus;
                                    lblAmount.Text = objResp.body.txnAmount;
                                    //Session["Response"] = objResp;
                                    //Session["mid"] = "TELANG38998201047460";
                                    //Response.Redirect("../PaymentFailure.aspx");
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
        public void CheckLinkStatus()
        {
            try
            {




                string result = CheckPendingStatus(Session["linkId"].ToString());
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
                                                Response.Redirect("admin/PaymentConformation.aspx");

                                            }
                                            else
                                            {
                                                lblStatus.Text = orders.orderStatus;
                                                lblAmount.Text = orders.txnAmount.ToString();
                                            }
                                        }
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
        public string CheckPendingStatus(string linkID)
        {
            string responseData = string.Empty;
            try
            {
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




                Dictionary<string, string> body = new Dictionary<string, string>();
                Dictionary<string, string> head = new Dictionary<string, string>();
                Dictionary<string, object> requestBody = new Dictionary<string, object>();

                body.Add("mid", mID.ToString());
                body.Add("linkId", linkID.ToString());

                head.Add("tokenType", "AES");

                //  Generate  CheckSum  here  from  Paytm  Library.
                //  string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), "MKaJnBObQy0plkBb");
                string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), paymentLink.ToString());

                head.Add("signature", paytmChecksum);

                requestBody.Add("body", body);
                requestBody.Add("head", head);

                string post_data = JsonConvert.SerializeObject(requestBody);

                //For  Staging  url
                string url = ConfigurationManager.AppSettings["smsPaymentLinkfetch"].ToString(); // "https://securegw-stage.paytm.in/link/fetchTransaction";
                                                                                                 //string url = "https://securegw-stage.paytm.in/link/fetchTransaction";

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
        protected void btnCheckStatus_Click(object sender, EventArgs e)
        {
            CheckStatus();
            CheckLinkStatus();
        }
    }
}
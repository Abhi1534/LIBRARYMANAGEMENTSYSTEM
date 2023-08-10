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

namespace LIBRARYMANAGEMENTSYSTEM
{
    public partial class MembershippaymentInitiation : System.Web.UI.Page
    {
        //public string orderId;
        //public string orderid = String.Empty;
        //public string amount = String.Empty;

        public string post_data = String.Empty;
        LMBAL objbal = new LMBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            paymentinitiation();
        }

        private void paymentinitiation()
        {
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
                body.Add("mid", "TELANG38998201047460");
                body.Add("orderId", ds2.Tables[0].Rows[0]["INVNUM"].ToString());
                body.Add("amount", "100.00");
                body.Add("businessType", "UPI_QR_CODE");
                body.Add("posId", "S12_123");
            }
            var result = JsonConvert.SerializeObject(body);
            /*
            * Generate checksum by parameters we have in body
            * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
            */
            string paytmChecksum = Checksum.generateSignature(JsonConvert.SerializeObject(body), "mCFk31V_JinVw_EL");

            head.Add("clientId", "C11");
            head.Add("version", "V1");
            head.Add("signature", paytmChecksum);

            requestBody.Add("body", body);
            requestBody.Add("head", head);

            string post_data = JsonConvert.SerializeObject(requestBody);

            //For  Staging
            string url = "https://securegw-stage.paytm.in/paymentservices/qr/create";

            //For  Production  url
            //string  url  =  "https://securegw.paytm.in/paymentservices/qr/create";

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
                   // lblQRCOdeID.Text = objResp.body.qrCodeId;

                   // imgQR.Src = "data:image/png;base64," + objResp.body.image;
                    frmLink.Action = objResp.body.qrData;
                    string[] qrData = objResp.body.qrData.Split('&');
                    txnToken.Value = "mCFk31V_JinVw_EL";
                    
                    foreach (var item in qrData)
                    {
                       
                        if (item.Contains("pn="))
                        {
                            string[] itemValue = item.Split('=');
                            mid.Value = itemValue[1].ToString().Replace("%20", " ");
                        }
                       
                        else if (item.Contains("tr="))
                        {
                            string[] itemValue = item.Split('=');
                            orderId.Value = itemValue[1].ToString();
                        }
                      

                    }
                   // Response.Redirect("https://securegw-stage.paytm.in/theia/api/v1/showPaymentPage?mid=TELANG38998201047460&orderId=" + orderId.Value);
                    frmLink.Action = "https://securegw-stage.paytm.in/theia/api/v1/showPaymentPage?mid=TELANG38998201047460&orderId=" + orderId.Value;
                }
                // Console.WriteLine(responseData);
            }


        }
    }
}
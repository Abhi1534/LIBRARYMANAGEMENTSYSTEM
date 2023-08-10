
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace LIBRARYMANAGEMENTSYSTEM.admin
{
    public partial class PaymentInvioce : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddetail();
            }
        }
        public void binddetail()
        {
            lbl_amount.Text = Session["membershipfee"].ToString();
            lbl_finaltotal.Text = Session["membershipfee"].ToString();
            lbl_Inviocername.Text = Session["MembershipName"].ToString();
            lbl_invoicenumber.Text = Session["Invoicenumber"].ToString();
            lbl_invoiceremail.Text = Session["MembershipEmailID"].ToString();
            lbl_invoicermobile.Text = Session["Membershipmobilenumber"].ToString();
            lbl_membershiptype.Text = Session["MembershiptypeName"].ToString();
            lbl_OrderIDDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lbl_totalamount.Text = Session["membershipfee"].ToString();
            lbl_typename.Text = Session["headofinvoice"].ToString();

            lbl_invoiceto.Text = Session["PageIntiateforpayment"].ToString();
            if (Session["PageIntiateforpayment"].ToString() == "WelfareStamps" || Session["PageIntiateforpayment"].ToString() == "CourtStamps" || Session["PageIntiateforpayment"].ToString() == "JudicialStamps")
            {
                pnl_eachprice.Visible = true;
                pnl_eachpricevalue.Visible = true;
                lbl_eachpricevalue.Text = Session["Stampprice"].ToString();
                if (Session["PageIntiateforpayment"].ToString() == "JudicialStamps")
                {
                    pnl_judicialstamphead.Visible = true;
                    pnl_judicialstampvalue.Visible = true;
                    lbl_addressvalue.Text = Session["ResAddress"].ToString();
                    lbl_Nameofstampvalue.Text = Session["NameofStamp"].ToString();
                }
            }
            barcodegenrator();
        }

        public void barcodegenrator()
        {

            string generatebarcode = Session["Invoicenumber"].ToString();

            BarQRCodeGenerator.BarQRGenerator objIBar = new BarQRCodeGenerator.BarQRGenerator();
            //string bookserialno = "BookSN06233378";// Session["Bookserialnumber"].ToString();
            string barCodeData = generatebarcode;
            byte[] bytes = objIBar.GenerateBarCodeByteArray(generatebarcode, barCodeData);
            string base64 = Convert.ToBase64String(bytes);
            ImageGeneratedBarcode.ImageUrl = string.Format("data:image/gif;base64,{0}", base64);
            ImageGeneratedBarcode.Visible = true;
           // btn_printbarcode.Visible = true;

            byte[] bytesImg = Convert.FromBase64String(base64);
            File.WriteAllBytes(Server.MapPath("../admin/GeneratedBarcodeImage/" + generatebarcode + ".png"), bytesImg);
            string filePath = Server.MapPath("../admin/GeneratedBarcodeImage/" + generatebarcode + ".png");
            //Session["Barcodeimgprint"] = filePath;
            //  GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode(generatebarcode, BarcodeWriterEncoding.Code128);
            ////  barcode.ResizeTo(400, 120);

            //  //Styling a QR code and adding annotation text
            //  //barcode.AddBarcodeValueTextAboveBarcode();
            //  barcode.AddBarcodeValueTextBelowBarcode();
            //  barcode.SetMargins(10);
            //  barcode.ChangeBarCodeColor(Color.Black);

            //  var folder = Server.MapPath("/App_Data/GeneratedBarcodeImage");
            //  if (!Directory.Exists(folder))
            //  {
            //      Directory.CreateDirectory(folder);
            //  }
            //  string filePath = Server.MapPath("GeneratedBarcodeImage/barcode.png");
            //  barcode.SaveAsPng(filePath);
            //  ImageGeneratedBarcode.ImageUrl = "../admin/GeneratedBarcodeImage/" + Path.GetFileName(filePath);
            //  ImageGeneratedBarcode.Visible = true;
        }
    }
}
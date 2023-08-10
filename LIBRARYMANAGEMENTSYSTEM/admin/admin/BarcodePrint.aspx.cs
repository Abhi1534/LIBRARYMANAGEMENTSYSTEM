
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class BarcodePrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getbarcodedetails();
            if (!IsPostBack)
            {
               // getbarcodedetails();
            }
        }
        public void getbarcodedetails()
        {
            LMBAL objMaster = new LMBAL();
            DataSet ds = objMaster.pr_getbarcodebookdetails("1", "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                pnl_barcodeview.Controls.Add(new LiteralControl("<div class='row'>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("<div class='col-sm-12'>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("<div class='card' style='text-align:center;font-weight:bold;'>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("<div class='card-body custom-edit-service'>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("<div 'class=service-fields mb-3'>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("<div class='row'>"));



                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    pnl_barcodeview.Controls.Add(new LiteralControl(" <div class='col-lg-4' style='align-content:center'>"));
                    pnl_barcodeview.Controls.Add(new LiteralControl("<div class='form-group'>"));



                    Label lblBookName = new Label();
                    lblBookName.Text = ds.Tables[0].Rows[i]["BookName"].ToString();
                    pnl_barcodeview.Controls.Add(lblBookName);
                    pnl_barcodeview.Controls.Add(new LiteralControl("<br />"));
                    string generatebarcode = ds.Tables[0].Rows[i]["BookSerialNo"].ToString();

                    BarQRCodeGenerator.BarQRGenerator objIBar = new BarQRCodeGenerator.BarQRGenerator();
                    //string bookserialno = "BookSN06233378";// Session["Bookserialnumber"].ToString();
                    string barCodeData = ds.Tables[0].Rows[i]["BookName"].ToString();
                    byte[] bytes = objIBar.GenerateBarCodeByteArray(generatebarcode, barCodeData);
                    string base64 = Convert.ToBase64String(bytes);
                    //ImageGeneratedBarcode.ImageUrl = string.Format("data:image/gif;base64,{0}", base64);
                    //ImageGeneratedBarcode.Visible = true;


                    byte[] bytesImg = Convert.FromBase64String(base64);
                    File.WriteAllBytes(Server.MapPath("../admin/GeneratedBarcodeImage/" + generatebarcode + ".png"), bytesImg);
                    string filePath = Server.MapPath("../admin/GeneratedBarcodeImage/" + generatebarcode + ".png");


                    //GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode(generatebarcode, BarcodeWriterEncoding.Code128);
                    //barcode.ResizeTo(200, 60);

                    ////Styling a QR code and adding annotation text
                    ////barcode.AddBarcodeValueTextAboveBarcode();
                    //barcode.AddBarcodeValueTextBelowBarcode();
                    //barcode.SetMargins(10);
                    //barcode.ChangeBarCodeColor(Color.Black);

                    //var folder = Server.MapPath("/App_Data/GeneratedBarcodeImage");
                    //if (!Directory.Exists(folder))
                    //{
                    //    Directory.CreateDirectory(folder);
                    //}
                    //string filePath = Server.MapPath("GeneratedBarcodeImage/" + generatebarcode + ".png");
                    //barcode.SaveAsPng(filePath);
                    pnl_barcodeview.Controls.Add(new System.Web.UI.WebControls.Image { ImageUrl = String.Format("../admin/GeneratedBarcodeImage/" + Path.GetFileName(filePath)) });

                    pnl_barcodeview.Controls.Add(new LiteralControl("<br />"));
                    LinkButton btnprint = new LinkButton()
                    {
                        Text = "Print"
                    };
                   // btnprint.Attributes.Add("class", "btn btn-group-toggle btn-primary");
                   // btnprint.Style["margin-bottom"] = "10px";
                    btnprint.Attributes.Add("runat", "server");
                    btnprint.CommandArgument = filePath;
                    btnprint.Click += new EventHandler(this.btnprint_Click);

                    pnl_barcodeview.Controls.Add(btnprint);


                    pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                    pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                }
                pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));

            }

        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> SearchText(string prefixText, int count)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_getbarcodebookdetails("3", prefixText);
            List<string> address = new List<string>();

            foreach (DataRow row in dt_Set.Tables[0].Rows)
            {
                address.Add(row["BookName"].ToString());

            }
            return address;
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataSet ds = objMaster.pr_getbarcodebookdetails("3", txt_search.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                pnl_barcodeview.Controls.Add(new LiteralControl("<div class='row'>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("<div class='col-sm-12'>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("<div class='card' style='text-align:center;font-weight:bold;'>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("<div class='card-body custom-edit-service'>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("<div 'class=service-fields mb-3'>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("<div class='row'>"));




                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    pnl_barcodeview.Controls.Add(new LiteralControl(" <div class='col-lg-4' style='align-content:center'>"));
                    pnl_barcodeview.Controls.Add(new LiteralControl("<div class='form-group'>"));

                    Label lblBookName = new Label();
                    lblBookName.Text = ds.Tables[0].Rows[i]["BookName"].ToString();
                    pnl_barcodeview.Controls.Add(lblBookName);
                    pnl_barcodeview.Controls.Add(new LiteralControl("<br />"));
                    string generatebarcode = ds.Tables[0].Rows[i]["BookSerialNo"].ToString();


                    BarQRCodeGenerator.BarQRGenerator objIBar = new BarQRCodeGenerator.BarQRGenerator();
                    //string bookserialno = "BookSN06233378";// Session["Bookserialnumber"].ToString();
                    string barCodeData = generatebarcode;
                    byte[] bytes = objIBar.GenerateBarCodeByteArray(generatebarcode, barCodeData);
                    string base64 = Convert.ToBase64String(bytes);                   

                    byte[] bytesImg = Convert.FromBase64String(base64);
                    File.WriteAllBytes(Server.MapPath("../admin/GeneratedBarcodeImage/" + generatebarcode + ".png"), bytesImg);
                    string filePath = Server.MapPath("../admin/GeneratedBarcodeImage/" + generatebarcode + ".png");
                    


                    //GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode(generatebarcode, BarcodeWriterEncoding.Code128);
                    //barcode.ResizeTo(200, 60);

                    ////Styling a QR code and adding annotation text
                    ////barcode.AddBarcodeValueTextAboveBarcode();
                    //barcode.AddBarcodeValueTextBelowBarcode();

                    //barcode.SetMargins(10);
                    //barcode.ChangeBarCodeColor(Color.Black);

                    //var folder = Server.MapPath("/App_Data/GeneratedBarcodeImage");
                    //if (!Directory.Exists(folder))
                    //{
                    //    Directory.CreateDirectory(folder);
                    //}
                    //string filePath = Server.MapPath("GeneratedBarcodeImage/" + generatebarcode + ".png");
                   // barcode.SaveAsPng(filePath);
                    pnl_barcodeview.Controls.Add(new System.Web.UI.WebControls.Image { ImageUrl = String.Format("../admin/GeneratedBarcodeImage/" + Path.GetFileName(filePath)) });
                    // LinkButton btnprint = new LinkButton();
                    pnl_barcodeview.Controls.Add(new LiteralControl("<br />"));
                    LinkButton btnprint = new LinkButton()
                    {
                        Text = "Print"
                    };
                    //btnprint.Attributes.Add("class", "btn btn-group-toggle btn-primary");
                    //btnprint.Style["margin-bottom"] = "10px";
                    btnprint.Attributes.Add("runat", "server");
                    btnprint.CommandName = "btn_view";
                    btnprint.CommandArgument = filePath;
                    
                    btnprint.Click += new EventHandler(this.btnprint_Click);

                    pnl_barcodeview.Controls.Add(btnprint);

                   pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                    pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                }
                pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));
                pnl_barcodeview.Controls.Add(new LiteralControl("</div>"));

            }

        }
        public void btnprint_Click(object sender, EventArgs e)
        {
            string argument = ((LinkButton)sender).CommandArgument;

            if (argument!="")
            {
                imgprint(argument);
            }
           
        }
        public void imgprint(string filepath)
        {
            PrintDocument pd = new PrintDocument();
           
            pd.PrintPage += (sender, args) =>
            {
                System.Drawing.Image i = System.Drawing.Image.FromFile(filepath);
                Point p = new Point(100, 100);
                args.Graphics.DrawImage(i, 0, 0, 220, 100);

            };
            pd.Print();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System.Drawing.Printing;

using System.Drawing.Imaging;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class BookEntry : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        string strConnection = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            if (!Page.IsPostBack)
            {
                bindgriddata();
            }
        }
        public void bindgriddata()
        {

            DataTable dt = objDal.GetBooksData("1", "0");
            if (dt.Rows.Count > 0)
            {
                grid_data.DataSource = dt;
                grid_data.DataBind();
            }

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblAuthor.Visible = true;
            lblAuthorNames.Visible = true;
            if (!string.IsNullOrEmpty(hdnAuthorName.Value))
            {
                hdnAuthorName.Value = hdnAuthorName.Value + "," + txtAuthor.Text;
            }
            else
            {
                hdnAuthorName.Value = txtAuthor.Text;
            }
            lblAuthorNames.Text = hdnAuthorName.Value;
            txtAuthor.Text = "";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InsertBookDetails();

            if (Session["Bookserialnumber"] != null && !string.IsNullOrWhiteSpace(Session["Bookserialnumber"].ToString()))
            {
                string bookserialno = Session["Bookserialnumber"].ToString();

                BarQRCodeGenerator.BarQRGenerator objIBar = new BarQRCodeGenerator.BarQRGenerator();
                //string bookserialno = "BookSN06233378";// Session["Bookserialnumber"].ToString();
                string barCodeData = txtBookName.Text;
                byte[] bytes = objIBar.GenerateBarCodeByteArray(bookserialno, barCodeData);
                string base64 = Convert.ToBase64String(bytes);
                ImageGeneratedBarcode.ImageUrl = string.Format("data:image/gif;base64,{0}", base64);
                ImageGeneratedBarcode.Visible = true;
                btn_printbarcode.Visible = true;

                byte[] bytesImg = Convert.FromBase64String(base64);
                File.WriteAllBytes(Server.MapPath("../admin/GeneratedBarcodeImage/" + bookserialno + ".png"), bytesImg);
                string filePath = Server.MapPath("../admin/GeneratedBarcodeImage/" + bookserialno + ".png");
                Session["Barcodeimgprint"] = filePath;
              //  imgprint(filePath);

                //string generatebarcode = bookserialno;
                //GeneratedBarcode barcode = BarcodeWriter.CreateBarcode(generatebarcode, BarcodeWriterEncoding.Code128);
                //barcode.ResizeTo(200, 60);

                //// Styling a QR code and adding annotation text
                ////barcode.AddBarcodeValueTextAboveBarcode();
                //barcode.AddBarcodeValueTextBelowBarcode();
                //barcode.SetMargins(10);
                //barcode.ChangeBarCodeColor(Color.Black);

                //var folder = Server.MapPath("/App_Data/GeneratedBarcodeImage");
                //if (!Directory.Exists(folder))
                //{
                //    Directory.CreateDirectory(folder);
                //}
                //string filePath = Server.MapPath("GeneratedBarcodeImage/" + bookserialno + ".png");
                //barcode.SaveAsPng(filePath);
                //ImageGeneratedBarcode.ImageUrl = String.Format("../admin/GeneratedBarcodeImage/" + Path.GetFileName(filePath));
                //ImageGeneratedBarcode.Visible = true;
                //imgprint(filePath);


                //GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode(bookserialno, BarcodeWriterEncoding.Code128);
                //barcode.ResizeTo(200, 60);
                //barcode.AddBarcodeValueTextBelowBarcode();
                //barcode.SetMargins(10);
                //barcode.ChangeBarCodeColor(Color.Black);
                //var folder = Server.MapPath("/App_Data/GeneratedBarcodeImage");
                //if (!Directory.Exists(folder))
                //{
                //    Directory.CreateDirectory(folder);
                //}
                //string filePath = Server.MapPath("GeneratedBarcodeImage/" + bookserialno + ".png");
                //barcode.SaveAsPng(filePath);
                //ImageGeneratedBarcode.ImageUrl = String.Format("../admin/GeneratedBarcodeImage/" + Path.GetFileName(filePath));
                //ImageGeneratedBarcode.Visible = true;
                //imgprint(filePath);
            }
            else
            {
                div_fail.Visible = true;
            }




        }

        public void imgprint(string filepath)
        {
            PrintDocument pd = new PrintDocument();
            //System.Drawing.Image i = System.Drawing.Image.FromFile(filepath);
            //int a = i.Width;
            //    int b = i.Height;
            // args.Graphics.DrawImage(i, 10, 10, i.Width, i.Height);
            pd.PrintPage += (sender, args) =>
            {
                System.Drawing.Image i = System.Drawing.Image.FromFile(filepath);
                Point p = new Point(100, 100);
                args.Graphics.DrawImage(i, 0, 0, 220, 100);

            };
            pd.Print();
        }
        public void BindDropDownData()
        {
            DataSet ds = objDal.GetDropDownData();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlSectionName.DataSource = ds.Tables[2];
                    ddlSectionName.DataTextField = "SectionName";
                    ddlSectionName.DataValueField = "SecMID";
                    ddlSectionName.DataBind();
                    ddlSectionName.Items.Insert(0, new ListItem("Select Section Name", "0"));
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    ddlSubject.DataSource = ds.Tables[3];
                    ddlSubject.DataTextField = "SubjectName";
                    ddlSubject.DataValueField = "SubID";
                    ddlSubject.DataBind();
                    ddlSubject.Items.Insert(0, new ListItem("Select Subject Name", "0"));
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    ddlSupplier.DataSource = ds.Tables[4];
                    ddlSupplier.DataTextField = "SupplierName";
                    ddlSupplier.DataValueField = "SupID";
                    ddlSupplier.DataBind();
                    ddlSupplier.Items.Insert(0, new ListItem("Select Suppliper Name", "0"));
                }

            }
        }

        public void InsertBookDetails()
        {
            string userip = Request.UserHostAddress;
            DataTable dt = new DataTable();
            //if (Session["Imagefilepath"] == null)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please upload the Book Cover')", false);
            //    return;
            //}
            //else
            //{
            try
            {
                string useid = Session["MemberID"].ToString();

                BookEntryDetails objBookEntryDetails = new BookEntryDetails();
                objBookEntryDetails.yearOPublish = txtYearOfPublish.Text;
                objBookEntryDetails.bookType = ddlBookType.SelectedValue;
                objBookEntryDetails.place = txtPlace.Text;
                objBookEntryDetails.subject = ddlSubject.SelectedValue;
                objBookEntryDetails.bookName = txtBookName.Text;
                Session["bookName"] = txtBookName.Text;
                objBookEntryDetails.totalPages = txtTotalPages.Text;
                objBookEntryDetails.isbn = txtISBN.Text;
                objBookEntryDetails.volume = txtVolume.Text;
                objBookEntryDetails.publisher = txtPublisher.Text;
                objBookEntryDetails.price = txtPrice.Text;
                objBookEntryDetails.noOfBooks = txt_noofbooks.Text;
                objBookEntryDetails.Edition = txt_edition.Text;
                if (txtBillDate.Text != "")
                {
                    objBookEntryDetails.billDate = txtBillDate.Text;
                }
                else
                {
                    objBookEntryDetails.billDate = "";

                }

                objBookEntryDetails.invoice = txtInvoice.Text;
                objBookEntryDetails.supplierName = ddlSupplier.SelectedValue;
                objBookEntryDetails.supContact = txtSupContact.Text;
                objBookEntryDetails.supAddress = txtSupAddress.Text;
                objBookEntryDetails.sectionName = ddlSectionName.SelectedValue;
                objBookEntryDetails.RackName = ddlRackName.SelectedValue;
                objBookEntryDetails.noOfSelf = "";// ddlSelfs.SelectedValue;
                objBookEntryDetails.noOfBooksInSelf = "";
                objBookEntryDetails.author = hdnAuthorName.Value;
                if (Session["Imagefilepath"] != null && !string.IsNullOrWhiteSpace(Session["Imagefilepath"].ToString()))
                {
                    objBookEntryDetails.bookCover = Session["Imagefilepath"].ToString();
                }
                else
                {
                    objBookEntryDetails.bookCover = "";
                }

                objBookEntryDetails.createdBy = useid.ToString();
                objBookEntryDetails.userIP = userip.ToString();
                dt = objDal.InserBookEntry(objBookEntryDetails);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["BookSerialNo"].ToString() != "")
                    {
                        Session["Bookserialnumber"] = dt.Rows[0]["BookSerialNo"].ToString();
                        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record is Updated Successfully')", true);
                        div_success.Visible = true;
                        // ClearData();
                    }
                    else
                    {
                        Session["Bookserialnumber"] = dt.Rows[0]["BookSerialNo"].ToString();
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Successfully Inserted Book Entry and Book Serial No is : '" + dt.Rows[0][0].ToString() + "')", true);
                        div_success.Visible = true;
                        //ClearData();
                    }
                }
            }
            catch (Exception ex)
            {
                div_fail.Visible = true;
            }
            //}
        }
        public void ClearData()
        {
            txtAuthor.Text = "";
            txtBillDate.Text = "";
            txtBookName.Text = "";
            txtInvoice.Text = "";
            txtISBN.Text = "";
            // txtNoOfBooksInSelf.Text = "";
            txtPlace.Text = "";
            txtPrice.Text = "";
            txtPublisher.Text = "";
            txtSupAddress.Text = "";
            txtSupContact.Text = "";
            ddlSupplier.SelectedValue = "0";
            txtTotalPages.Text = "";
            txtVolume.Text = "";
            txtYearOfPublish.Text = "";
            txt_noofbooks.Text = "";
            ddlBookType.SelectedValue = "0";
            ddlRackName.SelectedValue = "0";
            ddlSectionName.SelectedValue = "0";
            // ddlSelfs.SelectedValue = "0";
            ddlSubject.SelectedValue = "0";
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            BindDropDownData();
            pnl_entry.Visible = true;
            pnl_view.Visible = false;
            btn_back.Visible = true;
            btn_add.Visible = false;
            txt_search.Visible = false;
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookEntry.aspx");
        }
        protected void btnphotoupload_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            if (ctrlphotoupload.HasFiles)
            {
                foreach (HttpPostedFile postedfile in ctrlphotoupload.PostedFiles)
                {
                    string CreatedIP = Request.ServerVariables["Remote_Addr"];
                    string useid = "123";// Session["UserID"].ToString();
                    string fileName = Path.GetFileName(postedfile.FileName);
                    if (postedfile.ContentLength > 0)
                    {
                        Savedocs obj = new Savedocs();
                        string date1 = DateTime.Now.ToString("dd-MM-yyyy");
                        string file_full_path = Path.Combine("../../Sharepath", "GVR", "LibraryManagement", useid, txtBookName.Text);
                        file_full_path = Path.Combine(file_full_path, fileName);
                        Session["Imagefilepath"] = file_full_path;
                        Session["ImagefileName"] = fileName;
                        postedfile.SaveAs(Server.MapPath(file_full_path));
                        imgwardphoto.ImageUrl = file_full_path.ToString();   //filePath; // @"~/Images/" + originalFileName;
                        imgwardphoto.DataBind();
                        imgwardphoto.Visible = true;
                    }
                }
            }
        }
        protected void lnk_removeward_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.Delete(Session["Imagefilepath"].ToString());
                lnk_removeward.Visible = false;
                lbluploadwardphoto.Text = string.Empty;
                ctrlphotouploadfilename.Value = string.Empty;
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        protected string PhotoBase64ImgSrc(string fileNameandPath)
        {
            string base64 = string.Empty;
            try
            {
                byte[] byteArray = File.ReadAllBytes(fileNameandPath);
                base64 = Convert.ToBase64String(byteArray);
            }
            catch (Exception ex)
            {
            }

            return string.Format("data:image/gif;base64,{0}", base64);
        }
        public static string GetUploadFolderPath(string MainModule, string SubModule, string userid, string uid)
        {
            string folderpath = string.Empty;
            string UploadFolderPath = ConfigurationManager.AppSettings["Docpath"].ToString();
            StringBuilder strUploadBuilder = new StringBuilder(UploadFolderPath);
            strUploadBuilder.AppendFormat(@"Sharepath\{0}\{1}\{2}\{3}\", MainModule, SubModule, userid, uid);
            CreateFolder(strUploadBuilder.ToString());
            return strUploadBuilder.ToString();

        }
        public static string GetviewUploadFolderPath(string MainModule, string SubModule, string userid, string uid)
        {
            string folderpath = string.Empty;
            string UploadFolderPath = ConfigurationManager.AppSettings["Docviewpath"].ToString();
            StringBuilder strUploadBuilder = new StringBuilder(UploadFolderPath);
            strUploadBuilder.AppendFormat(@"{0}/{1}/{2}/{3}/", MainModule, SubModule, userid, uid);
            return strUploadBuilder.ToString();
        }
        private static void CreateFolder(string path)
        {
            try
            {
                System.IO.DirectoryInfo dirInfo = new DirectoryInfo(@path);
                if (!dirInfo.Exists)

                {
                    CreateFolder(Directory.GetParent(path).FullName);
                }
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            BindDropDownData();
            if (e.CommandName == "Btn_EditCommand")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grid_data.Rows[rowIndex];
                Label lbl_BookID = row.FindControl("lbl_BookID") as Label;
                DataTable dt = objDal.GetBooksData("2", lbl_BookID.Text);
                if (dt.Rows.Count > 0)
                {
                    lblBookID.Text = lbl_BookID.Text;
                    txtAuthor.Text = dt.Rows[0]["AutherName"].ToString();
                    txtBillDate.Text = Convert.ToDateTime(dt.Rows[0]["BillDate"].ToString()).ToString("yyyy-MM-dd"); ;
                    txtBookName.Text = dt.Rows[0]["BookName"].ToString();
                    txtInvoice.Text = dt.Rows[0]["BillNo"].ToString();
                    txtISBN.Text = dt.Rows[0]["ISBN"].ToString();
                    // txtNoOfBooksInSelf.Text = dt.Rows[0]["NoOfBooksInSelfs"].ToString();
                    txtPlace.Text = dt.Rows[0]["PlaceOfPublish"].ToString();
                    txtPrice.Text = dt.Rows[0]["Price"].ToString();
                    txtPublisher.Text = dt.Rows[0]["PublisherName"].ToString();
                    // txtSerialNo.Text = "";
                    txtSupAddress.Text = dt.Rows[0]["SAddress"].ToString();
                    txtSupContact.Text = dt.Rows[0]["SCNo"].ToString();
                    ddlSupplier.SelectedValue = dt.Rows[0]["SName"].ToString();
                    txtTotalPages.Text = dt.Rows[0]["TotalPages"].ToString();
                    txtVolume.Text = dt.Rows[0]["Volume"].ToString();
                    txtYearOfPublish.Text = dt.Rows[0]["YearOfPublish"].ToString();
                    txt_noofbooks.Text = dt.Rows[0]["NoOfBooks"].ToString();
                    ddlBookType.SelectedValue = dt.Rows[0]["BookType"].ToString();
                    txt_edition.Text = dt.Rows[0]["Edition"].ToString();
                    ddlSectionName.SelectedValue = dt.Rows[0]["SectionName"].ToString();
                    BindRacks(ddlSectionName.SelectedValue);
                    ddlRackName.SelectedValue = dt.Rows[0]["RackName"].ToString();
                    //  BindSelfs(ddlRackName.SelectedValue);
                    // ddlSelfs.SelectedValue = dt.Rows[0]["NoOfSelfs"].ToString();
                    if (dt.Rows[0]["BookSubject"] != null && !string.IsNullOrWhiteSpace(dt.Rows[0]["BookSubject"].ToString()))
                    {
                        ddlSubject.SelectedValue = dt.Rows[0]["BookSubject"].ToString();

                    }


                    if (dt.Rows[0]["BookCover"] != null && !string.IsNullOrWhiteSpace(dt.Rows[0]["BookCover"].ToString()))
                    {
                        Session["Imagefilepath"] = dt.Rows[0]["BookCover"].ToString();
                        imgwardphoto.ImageUrl = PhotoBase64ImgSrc(dt.Rows[0]["BookCover"].ToString());   //filePath; // @"~/Images/" + originalFileName;
                        imgwardphoto.DataBind();
                        imgwardphoto.Visible = true;
                    }

                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    btn_add.Visible = false;
                    txt_search.Visible = false;
                }

            }
        }
        //public void BindSelfs(string ddlRack)
        //{
        //    DataTable dtSelfs = new DataTable();
        //    dtSelfs = objDal.Getselfs(ddlRack, "1");
        //    if (dtSelfs.Rows.Count > 0)
        //    {
        //        ddlSelfs.DataSource = dtSelfs;
        //        ddlSelfs.DataTextField = "SelfsName";
        //        ddlSelfs.DataValueField = "SelfsID";
        //        ddlSelfs.DataBind();
        //        ddlSelfs.Items.Insert(0, new ListItem("Select Self Name", "0"));
        //    }
        //}
        public void BindRacks(string ddlSection)
        {
            DataTable dtRacks = new DataTable();
            dtRacks = objDal.Getselfs(ddlSection, "2");
            if (dtRacks.Rows.Count > 0)
            {
                ddlRackName.DataSource = dtRacks;
                ddlRackName.DataTextField = "RackName";
                ddlRackName.DataValueField = "RackID";
                ddlRackName.DataBind();
                ddlRackName.Items.Insert(0, new ListItem("Select Rack Name", "0"));
            }
        }

        //protected void ddlRackName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable dtSelfs = new DataTable();
        //    if (ddlRackName.SelectedValue != "0")
        //    {
        //        BindSelfs(ddlRackName.SelectedValue);
        //    }
        //}
        protected void ddlSectionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtSelfs = new DataTable();
            if (ddlRackName.SelectedValue != "0")
            {
                BindRacks(ddlSectionName.SelectedValue);
            }
        }

        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            bindgriddata();
        }

      
        protected void btn_printbarcode_Click(object sender, EventArgs e)
        {
            if (Session["Barcodeimgprint"] != null && !string.IsNullOrWhiteSpace(Session["Barcodeimgprint"].ToString()))
            {
                imgprint(Session["Barcodeimgprint"].ToString());
            }

        }
    }
}
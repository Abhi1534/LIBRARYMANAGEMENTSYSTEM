using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;
//using OfficeOpenXml;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class MemberRegistraion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            if (!IsPostBack)
            {
                bindmembershiptype();
               // bindGriddata();
                txt_membershipdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txt_enrollmentdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }

        public void bindGriddata()
        {
            DataSet ds1 = new DataSet();
            LMBAL objbal = new LMBAL();
            ds1 = objbal.pr_getmemberdata();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grid_data.DataSource = ds1;
                grid_data.DataBind();
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds1 = new DataSet();
                LMBAL objbal = new LMBAL();
                ds1 = objbal.pr_getindidvalmembershipdata(txt_email.Text,txt_MobileNumber.Text);

                MemberShipRegistration objrs = new MemberShipRegistration();

                objrs.AdvocateName = txt_Advocatename.Text;
                Session["MembershipName"] = txt_Advocatename.Text;
                objrs.Gender = ddl_gender.SelectedItem.Text;
                objrs.MobileNumber = txt_MobileNumber.Text;
                Session["Membershipmobilenumber"] = txt_MobileNumber.Text;
                objrs.PhoneNumber = txt_phonenumber.Text;
                objrs.Address = txt_address.Text;
                objrs.State = ddl_state.SelectedItem.Text;
                objrs.Email = txt_email.Text;
                Session["MembershipEmailID"] = txt_email.Text;
                objrs.DOB = txt_dob.Text;
                objrs.BloodGroup = ddl_Bloodgroup.SelectedItem.Text;
                objrs.EnrollmentDate = txt_enrollmentdate.Text;
                objrs.MembershipType = ddl_MemberShipType.SelectedItem.Value;
                objrs.MembershipDate = txt_membershipdate.Text;
                objrs.MembershipFee = txt_membershipfee.Text;
                Session["membershipfee"] = txt_membershipfee.Text;
                objrs.VehicleNumber = "";
                objrs.Vote = "";
                objrs.CreatedBy = Session["MemberID"].ToString();
                objrs.CreatedIP = Request.ServerVariables["Remote_Addr"];
                objrs.enrollmentNumber = txt_enrollmentnumber.Text;
                objrs.ClerkName = txt_ClerkName.Text;
                objrs.ClerkMobileNumber = txt_clerkmobilenumber.Text;
                if (ch_isactive.Checked==true)
                {
                    objrs.IsActive = "1";
                }
                else
                {
                    objrs.IsActive = "0";
                }
               
                if (Session["barcouncilenrollmentcerfilepath"] != null && !string.IsNullOrWhiteSpace(Session["barcouncilenrollmentcerfilepath"].ToString()))
                {
                    objrs.barcouncilenrollmentcerpath = Session["barcouncilenrollmentcerfilepath"].ToString();
                }
                else
                {
                    objrs.barcouncilenrollmentcerpath = "";
                }

                if (Session["barcouncilIDuploadfilepath"] != null && !string.IsNullOrWhiteSpace(Session["barcouncilIDuploadfilepath"].ToString()))
                {
                    objrs.barcouncilIDpath = Session["barcouncilIDuploadfilepath"].ToString();
                }
                else
                {
                    objrs.barcouncilIDpath = "";
                }
                if (Session["Photofilepath"] != null && !string.IsNullOrWhiteSpace(Session["Photofilepath"].ToString()))
                {
                    objrs.photopath = Session["Photofilepath"].ToString();
                }
                else
                {
                    objrs.photopath = "";
                }
                if (Session["Certificateofpracticepath"] != null && !string.IsNullOrWhiteSpace(Session["Certificateofpracticepath"].ToString()))
                {
                    objrs.Certificateofpracticepath = Session["Certificateofpracticepath"].ToString();
                }
                else
                {
                    objrs.Certificateofpracticepath = "";
                }
                if (Session["MembershippersonID"] != null && !string.IsNullOrWhiteSpace(Session["MembershippersonID"].ToString()))
                {
                    objrs.flag = "2";
                    objrs.CreatedBy = "";
                    objrs.CreatedIP = "";
                    objrs.ModifyBy = Session["MemberID"].ToString();
                    objrs.ModifyIp = Request.ServerVariables["Remote_Addr"];
                    objrs.MemberID = Session["MembershippersonID"].ToString();
                }
                else
                {
                    objrs.flag = "1";
                    objrs.CreatedBy = Session["MemberID"].ToString();
                    objrs.CreatedIP = Request.ServerVariables["Remote_Addr"];
                    objrs.ModifyBy = "";
                    objrs.ModifyIp = "";
                    objrs.MemberID = "";

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('EmailID already Exisit');", true);
                        txt_email.Focus();
                        return;
                    }
                }


                DataSet ds = new DataSet();
                ds = objbal.INSMembershipRegistration(objrs);
                if (ds.Tables[1].Rows[0]["result"].ToString() == "Success")
                {

                    div_success.Visible = true;

                    string memid = ds.Tables[2].Rows[0]["MemberID"].ToString();
                    Session["MembershippersonID"] = memid;

                    paymentinitiation();
                    string memidauto = ds.Tables[0].Rows[0]["MembershipRegistrationID"].ToString();
                    
                    BarQRCodeGenerator.BarQRGenerator objIBar = new BarQRCodeGenerator.BarQRGenerator();
                    string barCodeData = memidauto;
                    byte[] bytes = objIBar.GenerateBarCodeByteArray(barCodeData, txt_Advocatename.Text);
                    string base64 = Convert.ToBase64String(bytes);
                    ImageGeneratedBarcode.ImageUrl = string.Format("data:image/gif;base64,{0}", base64);
                    ImageGeneratedBarcode.Visible = true;

                    lbl_barcode.Visible = true;
                    // pnl_paymenttype.Visible = true;
                    // btn_Payment.Visible = true;
                    btn_submit.Visible = false;
                    Session["MembershippersonID"] = "";
                }
                else
                {
                    div_fail.Visible = true;
                }
            }



            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void bindmembershiptype()
        {

            LMBAL objMaster = new LMBAL();
            ddl_MemberShipType.Items.Clear();
            DataSet dt_Set = objMaster.GETALLMembershiptype();
            if (dt_Set.Tables[0].Rows.Count > 0)
            {
                ddl_MemberShipType.DataSource = dt_Set.Tables[0];
                ddl_MemberShipType.DataTextField = "MembershipTypeName";
                ddl_MemberShipType.DataValueField = "MemID";
                ddl_MemberShipType.DataBind();
                ddl_MemberShipType.Items.Insert(0, new ListItem("Select MemberShip Type", "0"));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Membership Type not loading')", true);
            }



        }

        protected void ddl_MemberShipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MembershipTypeID = ddl_MemberShipType.SelectedItem.Value;

            LMBAL bal = new LMBAL();
            DataSet ds = bal.pr_getmembershiptypebyfee(MembershipTypeID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_membershipfee.Text = ds.Tables[0].Rows[0]["totalfee"].ToString();
                Session["MembershipFee"] = txt_membershipfee.Text;

                lbl_appfee.Text = ds.Tables[0].Rows[0]["ApplicationForm"].ToString();
                lbl_subfee.Text = ds.Tables[0].Rows[0]["Subscription"].ToString();
                lbl_entreefee.Text = ds.Tables[0].Rows[0]["EntranceFee"].ToString();
                lbl_identitycarddfee.Text = ds.Tables[0].Rows[0]["IdentityCard"].ToString();
                lbl_misfee.Text = ds.Tables[0].Rows[0]["Miscellaneous"].ToString();
                lbl_entryidfee.Text = ds.Tables[0].Rows[0]["EntryIdentityCard"].ToString();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Subscription Fee: " + lbl_subfee.Text + Environment.NewLine + "Application Form Fee:" + lbl_appfee.Text +
                    Environment.NewLine + "Entrance Fee:" + lbl_entreefee.Text + Environment.NewLine +
                   "Identity Card Fee:" + lbl_identitycarddfee.Text + Environment.NewLine +
                   "Miscellaneous Fee:" + lbl_misfee.Text + Environment.NewLine + "Entry Identity Card Fee" + lbl_entryidfee.Text);

                imgreview.Attributes.Add("title", sb.ToString());
            }
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_Searchmembershipregistration(txt_search.Text);
            grid_data.DataSource = dt_Set;
            grid_data.DataBind();
        }
       
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchText(string prefixText, int count)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_Searchmembershipregistration(prefixText);
            
            List<string> address = new List<string>();

            foreach (DataRow row in dt_Set.Tables[0].Rows)
            {
                address.Add(row["AdvocateName"].ToString());

            }
            return address;
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            pnl_entry.Visible = true;
            pnl_view.Visible = false;
            btn_back.Visible = true;
            btn_add.Visible = false;
            txt_search.Visible = false;
            btnExcelDownload.Visible = false;
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberRegistraion.aspx");

        }

        protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_EditCommand")
            {
                string UID = e.CommandArgument.ToString();
                GridViewRow gvrc = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RowIndex = gvrc.RowIndex;
                // string filname = e.CommandArgument.ToString();
                Label PaymentStatus = (Label)grid_data.Rows[RowIndex].FindControl("lbl_PaymentStatus");
                LMBAL bal = new LMBAL();
                DataSet ds = bal.pr_get_memberregistrationbyid(UID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnl_entry.Visible = true;
                    pnl_view.Visible = false;
                    btn_back.Visible = true;
                    btn_add.Visible = false;
            btnExcelDownload.Visible = false;
                    txt_search.Visible = false;

                    txt_Advocatename.Text = ds.Tables[0].Rows[0]["AdvocateName"].ToString();
                    Session["MembershipName"] = txt_Advocatename.Text;
                    ddl_gender.SelectedItem.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                    txt_MobileNumber.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    Session["Membershipmobilenumber"] = txt_MobileNumber.Text;
                    txt_phonenumber.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    txt_address.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    ddl_state.SelectedItem.Text = ds.Tables[0].Rows[0]["State"].ToString();
                    txt_email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    Session["MembershipEmailID"] = txt_email.Text;
                    txt_dob.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).ToString("yyyy-MM-dd");
                    ddl_Bloodgroup.SelectedItem.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                    txt_enrollmentdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EnrollmentDate"].ToString()).ToString("yyyy-MM-dd");
                    ddl_MemberShipType.SelectedValue = ds.Tables[0].Rows[0]["MembershipType"].ToString();
                    txt_membershipdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["MembershipDate"].ToString()).ToString("yyyy-MM-dd");
                    txt_membershipfee.Text = ds.Tables[0].Rows[0]["MembershipFee"].ToString();
                   // txt_vehiclenumber.Text = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                   // ddl_vote.SelectedItem.Text = ds.Tables[0].Rows[0]["Vote"].ToString();
                    txt_enrollmentnumber.Text = ds.Tables[0].Rows[0]["EnrollmentNumber"].ToString();
                    txt_ClerkName.Text= ds.Tables[0].Rows[0]["ClerkName"].ToString();
                    txt_clerkmobilenumber.Text = ds.Tables[0].Rows[0]["ClerkMobileNumber"].ToString();
                    Session["MembershippersonID"] = ds.Tables[0].Rows[0]["MemberID"].ToString();

                    img_barcouncilenrollmentcerupload.ImageUrl = ds.Tables[0].Rows[0]["barcouncilenrollmentcerpath"].ToString();
                    Session["barcouncilenrollmentcerfilepath"] = ds.Tables[0].Rows[0]["barcouncilenrollmentcerpath"].ToString();
                    img_barcouncilenrollmentcerupload.Visible = true;

                    img_barcouncilIDupload.ImageUrl = ds.Tables[0].Rows[0]["barcouncilIDpath"].ToString();
                    Session["barcouncilIDuploadfilepath"] = ds.Tables[0].Rows[0]["barcouncilIDpath"].ToString();
                    img_barcouncilIDupload.Visible = true;

                    img_photoupload.ImageUrl = ds.Tables[0].Rows[0]["photopath"].ToString();
                    Session["Photofilepath"] = ds.Tables[0].Rows[0]["photopath"].ToString();
                    img_photoupload.Visible = true;

                    img_Certificateofpractice.ImageUrl = ds.Tables[0].Rows[0]["Certificateofpracticepath"].ToString();
                    Session["Certificateofpracticepath"] = ds.Tables[0].Rows[0]["Certificateofpracticepath"].ToString();
                    img_Certificateofpractice.Visible = true;
                    
                    string isactive= ds.Tables[0].Rows[0]["IsActive"].ToString();
                    if (isactive=="1")
                    {
                        ch_isactive.Checked = true;
                    }
                    else
                    {
                        ch_isactive.Checked = false;
                    }

                    if (PaymentStatus.Text == "NO")
                    {
                        pnl_paymenttype.Visible = true;
                    }
                    else
                    {
                        pnl_paymenttype.Visible = true;
                    }

                }
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
        protected void btn_barcouncilenrollmentcerupload_Click(object sender, EventArgs e)
        {

            if (fu_barcouncilenrollmentcerupload.HasFiles)

            {
                foreach (HttpPostedFile postedfile in fu_barcouncilenrollmentcerupload.PostedFiles)
                {
                    string CreatedIP = Request.ServerVariables["Remote_Addr"];
                    string useid = Session["MemberID"].ToString();
                    string fileName = Path.GetFileName(postedfile.FileName);

                    if (postedfile.ContentLength > 0)
                    {
                        Savedocs obj = new Savedocs();
                        obj.Impersonate("123");
                        string date1 = DateTime.Now.ToString("dd-MM-yyyy");
                        //  string file_full_path = GetUploadFolderPath("GVR", "MembershipRegistraion", "barcouncilenrollmentcer", txt_email.Text);
                        string file_full_path = Path.Combine("../../Sharepath", "GVR", "MembershipRegistraion", "barcouncilenrollmentcer");
                        file_full_path = Path.Combine(file_full_path, fileName);
                        Session["barcouncilenrollmentcerfilepath"] = file_full_path;
                        Session["barcouncilenrollmentcerfileName"] = fileName;
                        postedfile.SaveAs(Server.MapPath(file_full_path));
                        img_barcouncilenrollmentcerupload.ImageUrl = file_full_path;
                        img_barcouncilenrollmentcerupload.Visible = true;


                    }

                }

            }
        }

        protected void btn_barcouncilIDupload_Click(object sender, EventArgs e)
        {
            if (fu_barcouncilIDupload.HasFiles)

            {
                foreach (HttpPostedFile postedfile in fu_barcouncilIDupload.PostedFiles)
                {
                    string CreatedIP = Request.ServerVariables["Remote_Addr"];
                    string useid = Session["MemberID"].ToString();
                    string fileName = Path.GetFileName(postedfile.FileName);

                    if (postedfile.ContentLength > 0)
                    {
                        Savedocs obj = new Savedocs();
                        obj.Impersonate("123");
                        string date1 = DateTime.Now.ToString("dd-MM-yyyy");
                        // string file_full_path = GetUploadFolderPath("GVR", "MembershipRegistraion", "barcouncilIDupload", txt_email.Text);
                        string file_full_path = Path.Combine("../../Sharepath", "GVR", "MembershipRegistraion", "barcouncilIDupload");
                        file_full_path = Path.Combine(file_full_path, fileName);
                        Session["barcouncilIDuploadfilepath"] = file_full_path;
                        Session["barcouncilIDuploadfileName"] = fileName;
                        postedfile.SaveAs(Server.MapPath(file_full_path));
                        img_barcouncilIDupload.ImageUrl = file_full_path;
                        img_barcouncilIDupload.Visible = true;


                    }

                }

            }
        }

        protected void btn_photoupload_Click(object sender, EventArgs e)
        {
            if (fu_photoupload.HasFiles)

            {
                foreach (HttpPostedFile postedfile in fu_photoupload.PostedFiles)
                {
                    string CreatedIP = Request.ServerVariables["Remote_Addr"];
                    string useid = Session["MemberID"].ToString();
                    string fileName = Path.GetFileName(postedfile.FileName);

                    if (postedfile.ContentLength > 0)
                    {
                        Savedocs obj = new Savedocs();
                        obj.Impersonate("123");
                        string date1 = DateTime.Now.ToString("dd-MM-yyyy");
                       // string file_full_path = GetUploadFolderPath("GVR", "MembershipRegistraion", "Photo", "customers");
                        string file_full_path = Path.Combine("../../Sharepath", "GVR", "MembershipRegistraion", "Photo", "customers");
                        file_full_path = Path.Combine(file_full_path, fileName);
                        Session["Photofilepath"] = file_full_path;
                        Session["PhotofileName"] = fileName;
                        postedfile.SaveAs(Server.MapPath(file_full_path));
                        img_photoupload.ImageUrl = file_full_path;
                        img_photoupload.Visible = true;


                    }

                }

            }
        }
        public static string GetUploadFolderPath(string MainModule, string SubModule, string type, string mailid)
        {
            string folderpath = string.Empty;
            string UploadFolderPath = ConfigurationManager.AppSettings["Docpath"].ToString();
            StringBuilder strUploadBuilder = new StringBuilder(UploadFolderPath);
            strUploadBuilder.AppendFormat(@"Sharepath\{0}\{1}\{2}\{3}\", MainModule, SubModule, type, mailid);
            CreateFolder(strUploadBuilder.ToString());
            return strUploadBuilder.ToString();

        }
        public static string GetviewUploadFolderPath(string MainModule, string SubModule, string type, string mailid, string filename)
        {
            string folderpath = string.Empty;
            string UploadFolderPath = ConfigurationManager.AppSettings["Docviewpath"].ToString();
            StringBuilder strUploadBuilder = new StringBuilder(UploadFolderPath);
            strUploadBuilder.AppendFormat(@"{0}/{1}/{2}/{3}/{4}", MainModule, SubModule, type, mailid, filename);
            //CreateFolder(strUploadBuilder.ToString());

            return strUploadBuilder.ToString();

        }
        private static void CreateFolder(string path)
        {
            try
            {

                System.IO.DirectoryInfo dirInfo = new DirectoryInfo(@path);
                //Models.Logger.Log("GenEmployerCode API :: CreateFolder chk exists", dirInfo.ToString());

                if (!dirInfo.Exists)

                {  // Models.Logger.Log("GenEmployerCode API :: inside folder check", "");
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

        public void paymentinitiation()
        {
            if (txt_membershipfee.Text != "")
            {
                PaymentTypeConformation objpayment = new PaymentTypeConformation();
                LMBAL objbal = new LMBAL();

                objpayment.MembershipID = Session["MembershippersonID"].ToString();
                objpayment.PaymentIntiationpage = "Membership Registration";
                objpayment.Paymentoff = ddl_MemberShipType.SelectedItem.Text;
                objpayment.PaymentType = rbtnPaymentType.SelectedItem.Text;
                objpayment.Amount = txt_membershipfee.Text;
                objpayment.ReferenceID = txt_paymentReferencenumber.Text;
                objpayment.nofnotes2000 = "0";
                objpayment.nofnotes500 = txt_500notes.Text;
                objpayment.nofnotes200 = txt_200notes.Text;
                objpayment.nofnotes100 = txt_100notes.Text;
                objpayment.nofnotes50 = txt_50notes.Text;
                objpayment.nofnotes20 = txt_20notes.Text;
                objpayment.nofnotes10 = txt_10notes.Text;
                objpayment.nofnotes1_2_5 = txt_125coins.Text;
                objpayment.PaymentStatus = "Success";
                objpayment.CreatedBy = Session["MemberID"].ToString();
                objpayment.CreatedIP = Request.ServerVariables["Remote_Addr"];
                objpayment.IsActive = "1";
                objpayment.flag = "1";
                DataSet ds = new DataSet();
                ds = objbal.InsertPaymentDetails(objpayment);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["result"].ToString() == "Success")
                    {

                    }
                }
            }
        }

        protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_data.PageIndex = e.NewPageIndex;
            LMBAL objMaster = new LMBAL();
            if (!string.IsNullOrEmpty(txt_search.Text))
            {
                DataSet dt_Set = objMaster.pr_get_Searchmembershipregistration(txt_search.Text);
                grid_data.DataSource = dt_Set;
                grid_data.DataBind();
            }
            else
            {
                bindGriddata();
            }
        }

        protected void rbtnPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnPaymentType.SelectedItem.Text == "Cheque/Online")
            {
                pnl_paymenttypeonlinecheque.Visible = true;
                pnl_paymenttypecash.Visible = false;
            }
            if (rbtnPaymentType.SelectedItem.Text == "Cash")
            {
                pnl_paymenttypecash.Visible = true;
                pnl_paymenttypeonlinecheque.Visible = false;
            }
        }

        //protected void btn_vehicalad_Click(object sender, EventArgs e)
        //{

        //}

        protected void btn_Certificateofpractice_Click(object sender, EventArgs e)
        {

            if (fu_Certificateofpractice.HasFiles)

            {
                foreach (HttpPostedFile postedfile in fu_Certificateofpractice.PostedFiles)
                {
                    string CreatedIP = Request.ServerVariables["Remote_Addr"];
                    // string useid = Session["MemberID"].ToString();
                    string fileName = Path.GetFileName(postedfile.FileName);

                    if (postedfile.ContentLength > 0)
                    {
                        Savedocs obj = new Savedocs();
                        obj.Impersonate("123");
                        string date1 = DateTime.Now.ToString("dd-MM-yyyy");
                        string file_full_path = Path.Combine("../../Sharepath", "GVR", "MembershipRegistraion", "Certificateofpractice");
                        string extension = Path.GetExtension(fu_Certificateofpractice.FileName);
                        fileName = txt_MobileNumber.Text + extension;

                        file_full_path = Path.Combine(file_full_path, fileName);
                        Session["Certificateofpracticepath"] = file_full_path;
                        Session["CertificateofpracticefileName"] = fileName;
                        postedfile.SaveAs(Server.MapPath(file_full_path));
                        img_Certificateofpractice.ImageUrl = file_full_path;
                        img_Certificateofpractice.Visible = true;


                    }

                }

            }
        }

        protected void btnExcelDownload_Click(object sender, EventArgs e)
        {
            LMBAL objbal = new LMBAL();
            DataSet ds = objbal.GetMembersExcelData();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    //ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    //using (var excelPackage = new ExcelPackage())
                    //{
                    //    // Create the worksheet
                    //    var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                    //    // Fill the worksheet with data from the DataTable
                    //    worksheet.Cells["A1"].LoadFromDataTable(ds.Tables[0], true);

                    //    // Set the response properties for downloading the file
                    //    HttpContext.Current.Response.Clear();
                    //    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    //    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=file.xlsx");
                    //    HttpContext.Current.Response.BinaryWrite(excelPackage.GetAsByteArray());
                    //    HttpContext.Current.Response.End();
                    //}


                    string attachment = "attachment; filename=MasterData.xls";
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", attachment);
                    Response.ContentType = "application/vnd.ms-excel";
                    string tab = "";

                    foreach (DataColumn dc in ds.Tables[0].Columns)
                    {
                        Response.Write(tab + dc.ColumnName);
                        tab = "\t";
                    }
                    Response.Write("\n");
                    int i;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        tab = "";
                        for (i = 0; i < ds.Tables[0].Columns.Count; i++)
                        {
                            Response.Write(tab + dr[i].ToString());
                            tab = "\t";
                        }
                        Response.Write("\n");
                    }
                    Response.End();

                    //  DownloadExcelFile(ds.Tables[0]);
                }
                else
                {
                   // div_fail_search.Visible = true;
                }
            }
        }
    }
}
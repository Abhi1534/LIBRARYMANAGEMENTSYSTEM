using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class BookReturn : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            if (!IsPostBack)
            {
                txtSubmitDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }

        protected void ddlBookName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = objDal.GetBooksByMember(txtMemberShipMobileNo.Text, "1");
            if (dt.Rows.Count > 0)
            {
                if (ddlBookName.SelectedValue != "0")
                {
                    DataTable newDt = dt.Select("[BookIssueID]='" + Convert.ToInt32(ddlBookName.SelectedValue) + "'").CopyToDataTable();
                    if (newDt.Rows.Count > 0)
                    {
                        txtAuthor.Text = newDt.Rows[0]["AuthorName"].ToString();
                        lblFine.Text = newDt.Rows[0]["FineAmount"].ToString();
                        lblNoOfBooksIssued.Text = newDt.Rows[0]["NoOfBooks"].ToString();
                        lblMembershipID.Text = newDt.Rows[0]["memberID"].ToString();
                        lblBookID.Text = newDt.Rows[0]["BookID"].ToString();
                        txtIssuedDate.Text = Convert.ToDateTime(newDt.Rows[0]["DateOfIssue"].ToString()).ToString("yyyy-MM-dd");
                    }
                    txtNoOfbooks.Text = "";
                }
                else
                {
                    clearData();
                }

            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            BarQRCodeGenerator.BarQRGenerator objIBar = new BarQRCodeGenerator.BarQRGenerator();
            string barCodeData = ddlBookName.SelectedItem.Value;
            byte[] bytes = objIBar.GenerateBarCodeByteArray(barCodeData, txtAuthor.Text);
            string base64 = Convert.ToBase64String(bytes);
            ImageGeneratedBarcode.ImageUrl = string.Format("data:image/gif;base64,{0}", base64);
            ImageGeneratedBarcode.Visible = true;
            InsertBookReturnDetails();
        }
        public void InsertBookReturnDetails()
        {
            try
            {
                string useid = Session["MemberID"].ToString();

                string userip = Request.UserHostAddress;
                DataTable dt = new DataTable();

                BookReturnDetails objBookReturnDetails = new BookReturnDetails();
                PaymentTypeConformation objpayment = new PaymentTypeConformation();
                objBookReturnDetails.authorName = txtAuthor.Text;
                objBookReturnDetails.noOfBooks = txtNoOfbooks.Text;
                objBookReturnDetails.submitDate = txtSubmitDate.Text;
                objBookReturnDetails.submittedBy = "";
                objBookReturnDetails.bookName = ddlBookName.SelectedItem.Text;
                objBookReturnDetails.bookID = lblBookID.Text;
                objBookReturnDetails.membershipID = lblMembershipID.Text;
                objBookReturnDetails.fineAmount = txtFineAmount.Text;
                objBookReturnDetails.bookIssueID = ddlBookName.SelectedValue;
                objBookReturnDetails.createdBy = useid.ToString();
                objBookReturnDetails.userIP = userip.ToString();
                if (txtFineAmount.Text!="" || txtFineAmount.Text != "0")
                {
                    objpayment.PaymentIntiationpage = "Book Return";
                    objpayment.Paymentoff = ddlBookName.SelectedItem.Value;
                    objpayment.PaymentType = rbtnPaymentType.SelectedItem.Text;
                    objpayment.ReferenceID = txt_paymentReferencenumber.Text;
                    objpayment.nofnotes2000 = txt_2000notes.Text;
                    objpayment.nofnotes500 = txt_500notes.Text;
                    objpayment.nofnotes200 = txt_200notes.Text;
                    objpayment.nofnotes100 = txt_100notes.Text;
                    objpayment.nofnotes50 = txt_50notes.Text;
                    objpayment.nofnotes20 = txt_20notes.Text;
                    objpayment.nofnotes10 = txt_10notes.Text;
                    objpayment.nofnotes1_2_5 = txt_125coins.Text;
                    objpayment.PaymentStatus = "Success";
                    objpayment.IsActive = "1";


                }
                else
                {
                    objpayment.PaymentIntiationpage = "";
                    objpayment.Paymentoff = "";
                    objpayment.PaymentType = "";
                    objpayment.ReferenceID = "";
                    objpayment.nofnotes2000 = "";
                    objpayment.nofnotes500 = "";
                    objpayment.nofnotes200 = "";
                    objpayment.nofnotes100 = "";
                    objpayment.nofnotes50 = "";
                    objpayment.nofnotes20 = "";
                    objpayment.nofnotes10 = "";
                    objpayment.nofnotes1_2_5 = "";
                    objpayment.PaymentStatus = "";
                    objpayment.IsActive = "";
                }

                dt = objDal.InserBookReturn(objBookReturnDetails, objpayment);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() != "Fail")
                    {
                        Response.Redirect("InvoiceView.aspx?type=BookReturn&Inv=" + dt.Rows[0]["INVNUM"].ToString(), false);
                        //   ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Book Returned Successfully')", true);
                        // clearData();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }
        public void clearData()
        {
            txtAuthor.Text = "";
            txtNoOfbooks.Text = "";
            txtSubmitDate.Text = "";
            ddlBookName.SelectedValue = "0";
            txtIssuedDate.Text = "";
            //  txtSubmittedBy.Text = "";
            txtFineAmount.Text = "";
            txtMemberShipMobileNo.Text = "";
            lblNoOfBooksIssued.Text = "";
            txt_Membershipname.Text = "";
            pnl_paymenttype.Visible = false;
            pnl_paymenttypecash.Visible = false;
            pnl_paymenttypeonlinecheque.Visible = false;
        }

        protected void txtMemberShipMobileNo_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = objDal.GetBooksByMember(txtMemberShipMobileNo.Text, "1");

            if (dt.Rows.Count > 0)
            {
                txt_Membershipname.Text = dt.Rows[0]["AdvocateName"].ToString();
                ddlBookName.DataSource = dt;
                ddlBookName.DataTextField = "BookName";
                ddlBookName.DataValueField = "BookIssueID";
                ddlBookName.DataBind();
                ddlBookName.Items.Insert(0, new ListItem("Select Book Name", "0"));
            }
            else
            {
                txtMemberShipMobileNo.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter valid Mobile Number')", true);
                return;
                //txt_Membershipname.Text = dt.Rows[0]["AdvocateName"].ToString();
                //ddlBookName.DataSource = dt;
                //ddlBookName.DataTextField = "BookName";
                //ddlBookName.DataValueField = "BookIssueID";
                //ddlBookName.DataBind();
                //ddlBookName.Items.Insert(0, new ListItem("Select Book Name", "0"));
            }
            ImageGeneratedBarcode.Visible = false;
            txtFineAmount.Text = "";
            txtNoOfbooks.Text = "";
            // clearData();
        }

        protected void txtNoOfbooks_TextChanged(object sender, EventArgs e)
        {
            int issueBooks = Convert.ToInt32(lblNoOfBooksIssued.Text);
            if (!string.IsNullOrEmpty(txtNoOfbooks.Text))
            {
                int returnBooks = Convert.ToInt32(txtNoOfbooks.Text);
                if (issueBooks < returnBooks || returnBooks == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter valid return books')", true);
                    txtNoOfbooks.Text = "";
                    return;
                }
                else
                {
                    int fineAmount = Convert.ToInt32(lblFine.Text) * returnBooks;
                    txtFineAmount.Text = fineAmount.ToString();
                    pnl_paymenttype.Visible = true;
                }
            }
            else
            {
                txtFineAmount.Text = "";
                txtNoOfbooks.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter valid return books')", true);
                return;
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
    }
}
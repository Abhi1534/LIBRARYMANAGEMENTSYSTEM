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
    public partial class AddReceipts : System.Web.UI.Page
    {
        LBR_DAL objDal = new LBR_DAL();
        List<string> pFeature = new List<string>();
        int totalAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberID"] == null)
            {

                Response.Redirect("../SessionExpired.aspx");
            }
            dynamidropDown();
            if (!IsPostBack)
            {
                dynamicCheck();
            }
        }
        public void dynamidropDown()
        {
            pnlDropDown.Controls.Add(new LiteralControl("<div class='col-lg-12'>"));
            pnlDropDown.Controls.Add(new LiteralControl("<div class='row'>"));
            DataTable dt = new DataTable();
            dt = objDal.GetFeaturesDetails("0", "3");
            if (dt.Rows.Count>0)
            {

          
            DataTable chkDt = dt.Select("[FeatureType]='1' and [IsActive]=1").CopyToDataTable();
            DataTable dropDownDt = dt.Select("[FeatureType]='2' and [IsActive]=1").CopyToDataTable();
            for (int i = 0; i < dropDownDt.Rows.Count; i++)
            {
                Label lblFeatureName = new Label();

                string ddlName = dropDownDt.Rows[i]["FeatureName"].ToString();
                DropDownList ddl = new DropDownList();
                
                ddl.Width = 400;
                ddl.Height = 40;
                ddl.ID = dropDownDt.Rows[i]["FeatureID"].ToString() + "_" + ddlName.ToString();
                string[] options = dropDownDt.Rows[i]["Options"].ToString().Split(',');
                string[] FeatureValues = dropDownDt.Rows[i]["FeatureValues"].ToString().Split(',');
                DataTable dtOpt = new DataTable();

                dtOpt.Columns.Add(new DataColumn("ID", typeof(string)));
                dtOpt.Columns.Add(new DataColumn("Options", typeof(string)));
                dtOpt.Columns.Add(new DataColumn("FeatureValues", typeof(string)));
                for (int j = 0; j < options.Length; j++)
                {
                    if (j == 0)
                    {
                        DataRow drNew1 = dtOpt.NewRow();
                        drNew1["ID"] = "0";// dropDownDt.Rows[i]["FeatureID"].ToString() + "_" +
                        drNew1["Options"] = "Select " + ddlName.ToString();
                        drNew1["FeatureValues"] = "Select " + ddlName.ToString();
                        dtOpt.Rows.Add(drNew1);
                        dtOpt.AcceptChanges();
                    }
                    DataRow drNew = dtOpt.NewRow();
                    drNew["ID"] = FeatureValues[j].ToString().Trim();// dropDownDt.Rows[i]["FeatureID"].ToString() + "_" +
                    drNew["Options"] = options[j].ToString().Trim() + " (" + FeatureValues[j].ToString().Trim() + ")";
                    drNew["FeatureValues"] = FeatureValues[j].ToString().Trim();

                    dtOpt.Rows.Add(drNew);
                    dtOpt.AcceptChanges();
                }
                pnlDropDown.Controls.Add(new LiteralControl("<div class='col-lg-4'>"));
                pnlDropDown.Controls.Add(new LiteralControl("<div class='form-group'>"));
                ddl.DataTextField = "Options";
                ddl.DataValueField = "ID";
                ddl.DataSource = dtOpt;
                ddl.SelectedIndexChanged += new EventHandler(ddlSelectedChanged);
                ddl.DataBind();
                ddl.AutoPostBack = true;
                ddl.Attributes.Add("class", "custom-select");
                lblFeatureName.Text = ddlName.ToString();
                pnlDropDown.Controls.Add(lblFeatureName);
                pnlDropDown.Controls.Add(ddl);
                pnlDropDown.Controls.Add(new LiteralControl("</div>"));
                pnlDropDown.Controls.Add(new LiteralControl("</div>"));
            }
            pnlDropDown.Controls.Add(new LiteralControl("</div>"));
            pnlDropDown.Controls.Add(new LiteralControl("</div>"));
            }
        }
        public void dynamicCheck()
        {
            DataTable dt = new DataTable();
            dt = objDal.GetFeaturesDetails("0", "3");
            if (dt.Rows.Count>0)
            {

           
            DataTable chkDt = objDal.GetFeaturesDetails("0", "4");
            DataTable dropDownDt = dt.Select("[FeatureType]='2' and [IsActive]=1").CopyToDataTable();
            rptCustomers.DataSource = chkDt;
            rptCustomers.DataBind();
            Session["chkDt"] = chkDt;
            Session["dropDownDt"] = dropDownDt;
            }
        }
        private void ddlSelectedChanged(object sender, EventArgs e)
        {
            try
            {
                int ddlTotal = 0;
                lblDdlIds.Text = "";
                lblDdlvalues.Text = "";
                lblDDlNames.Text = "";
                foreach (DropDownList dropDownList in pnlDropDown.Controls.OfType<DropDownList>())
                {
                    if (dropDownList.SelectedValue != "0")
                    //  totalAmount += Convert.ToInt32(chkDt.Rows[0]["FeatureValues"].ToString());
                    {

                        string ddFeatureAmount = dropDownList.SelectedItem.Value.ToString();
                        totalAmount += Convert.ToInt32(ddFeatureAmount.ToString());

                        if (string.IsNullOrEmpty(txtAmount.Text))
                            ddlTotal = 0 + totalAmount;
                        else
                            ddlTotal = totalAmount;
                        string[] ddlselectValues = dropDownList.ID.ToString().Split('_');
                        lblDDlNames.Text += "," + ddlselectValues[1].ToString();
                        lblDdlIds.Text += "," + ddlselectValues[0].ToString();
                        lblDdlvalues.Text += "," + dropDownList.SelectedItem.Value.ToString();
                    }

                }
                txtDropDownTotal.Text = ddlTotal.ToString();
                int chkTotal = 0;
                if (!string.IsNullOrEmpty(txtCheckBoxTotal.Text))
                    chkTotal = Convert.ToInt32(txtCheckBoxTotal.Text);
                txtAmount.Text = (chkTotal + ddlTotal).ToString();
            }
            catch (Exception ex)
            { }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                string useid = Session["MemberID"].ToString();
                string userip = Request.UserHostAddress;
                ReceiptDetails objReceiptDetails = new ReceiptDetails();
                PaymentTypeConformation objpayment = new PaymentTypeConformation();
                objReceiptDetails.memberID = txtMemberID.Text;
                objReceiptDetails.memberName = txtReceivedFrom.Text;
                objReceiptDetails.paymentType = rbtnPaymentType.SelectedItem.Text;
                objReceiptDetails.receiptID = "";
               // objReceiptDetails.isActive = "1";
                objReceiptDetails.flag = "1";
                objReceiptDetails.totalAmount = txtAmount.Text;
                objReceiptDetails.towards = txtTowards.Text;
                objReceiptDetails.transactionID = txtTransactionID.Text;
                objReceiptDetails.userIP = userip.ToString();
                objReceiptDetails.createdBy = useid.ToString();
                //  string fOptions = lblDdlIds.Text + lblChkIds.Text;
                objReceiptDetails.featureOptions = (lblDdlIds.Text + lblChkIds.Text).Substring(1);
                objReceiptDetails.featureValues = (lblDdlvalues.Text + lblChkValues.Text).Substring(1);
                objReceiptDetails.featureName = (lblDDlNames.Text + lblChkNames.Text).Substring(1);

                objpayment.PaymentIntiationpage = "Receipt";
                objpayment.Paymentoff = objReceiptDetails.featureName;
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

                DataTable dt = objDal.InsertReceiptDetails(objReceiptDetails, objpayment);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() != "Fail" && dt.Rows[0][0].ToString() != "Already Exists")
                    {
                        div_fail.Visible = false;
                        div_success.Visible = true;
                        Response.Redirect("InvoiceView.aspx?type=Receipt&Inv=" + dt.Rows[0]["INVNUM"].ToString(), false);

                    }
                    else
                    {
                        div_success.Visible = false;
                        div_fail.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        public void ClearData()
        {
            txtAmount.Text = "";
            txtCheckBoxTotal.Text = "";
            txtDropDownTotal.Text = "";
            txtMemberID.Text = "";
            txtReceivedFrom.Text = "";
            txtTowards.Text = "";
            txtTransactionID.Text = "";
            rbtnPaymentType.ClearSelection();
            lblChkIds.Text = "";
            lblChkNames.Text = "";
            lblChkValues.Text = "";
            lblDdlIds.Text = "";
            lblDDlNames.Text = "";
            lblDdlvalues.Text = "";
            foreach (DropDownList dropDownList in pnlDropDown.Controls.OfType<DropDownList>())
            {
                if (dropDownList.SelectedValue != "0")
                {
                    dropDownList.SelectedValue = "0";
                }
            }
            foreach (RepeaterItem item in rptCustomers.Items)
            {
                CheckBox chk = item.FindControl("chkFeatures") as CheckBox;
                if (chk.Checked)
                {
                    chk.Checked = false;
                }
            }
        }
        protected void chkFeatures_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int chkTotal = 0;
                lblChkIds.Text = "";
                lblChkValues.Text = "";
                lblChkNames.Text = "";
                foreach (RepeaterItem item in rptCustomers.Items)
                {
                    CheckBox chk = item.FindControl("chkFeatures") as CheckBox;
                    if (chk.Checked)
                    {
                        string[] chkAmt = chk.Text.Split('(');
                        string amtChk = chkAmt[1].ToString().Replace(")", "");
                        totalAmount += Convert.ToInt32(amtChk.ToString());

                        if (string.IsNullOrEmpty(txtAmount.Text))
                            chkTotal = 0 + totalAmount;
                        else
                            chkTotal = totalAmount;
                        Label chkIds = item.FindControl("chkIds") as Label;
                        lblChkNames.Text += "," + chkAmt[0].ToString();
                        lblChkIds.Text += "," + chkIds.Text;
                        lblChkValues.Text += "," + amtChk.ToString();
                    }
                }
                txtCheckBoxTotal.Text = chkTotal.ToString();
                int ddlTotal = 0;
                if (!string.IsNullOrEmpty(txtDropDownTotal.Text))
                    ddlTotal = Convert.ToInt32(txtDropDownTotal.Text);
                txtAmount.Text = (chkTotal + ddlTotal).ToString();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        protected void rbtnPaymentType_TextChanged(object sender, EventArgs e)
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
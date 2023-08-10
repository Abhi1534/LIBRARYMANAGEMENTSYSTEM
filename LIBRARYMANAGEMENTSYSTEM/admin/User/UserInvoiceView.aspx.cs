using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class UserInvoiceView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string type = Request.QueryString["type"].ToString();
                string invoice = Request.QueryString["Inv"].ToString();
                BindData("1", type.ToString(), invoice);
            }
        }
        public void BindData(string flag,string type,string invoice)
        {
            LBR_DAL objDal = new LBR_DAL();
            DataTable dt = new DataTable();
            dt = objDal.GetInvoiceData(flag,type, invoice);
            if(dt.Rows.Count>0)
            {
                if (type.ToString() == "Receipt")
                {
                    string[] options = dt.Rows[0]["Qty"].ToString().Split(',');
                    string[] Name = dt.Rows[0]["Name"].ToString().Split(',');
                    string[] Amount = dt.Rows[0]["Amount"].ToString().Split(',');
                    DataTable dtOpt = new DataTable();

                    // dtOpt.Columns.Add(new DataColumn("ID", typeof(string)));
                    dtOpt.Columns.Add(new DataColumn("Name", typeof(string)));
                    dtOpt.Columns.Add(new DataColumn("Amount", typeof(string)));
                    dtOpt.Columns.Add(new DataColumn("Qty", typeof(string)));
                    for (int j = 0; j < options.Length; j++)
                    {
                        DataRow drNew = dtOpt.NewRow();
                        //  drNew["ID"] = j.ToString().Trim();// dropDownDt.Rows[i]["FeatureID"].ToString() + "_" +
                        drNew["Name"] = Name[j].ToString().Trim();
                        drNew["Qty"] = "1";
                        drNew["Amount"] = Amount[j].ToString().Trim();

                        dtOpt.Rows.Add(drNew);
                        dtOpt.AcceptChanges();
                    }
                    gdvInvoice.DataSource = dtOpt;
                    gdvInvoice.DataBind();
                }
                else
                {
                    gdvInvoice.DataSource = dt;
                    gdvInvoice.DataBind();
                }

                gdvInvoice.FooterRow.Cells[1].Text = "Total :";
                gdvInvoice.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                gdvInvoice.FooterRow.Cells[2].Text =dt.Rows[0]["TotalAmount"].ToString();

                lblPaymentType.Text = dt.Rows[0]["PaymentType"].ToString();
                lbl_Address.Text= dt.Rows[0]["Address"].ToString();
                lbl_Inviocername.Text= dt.Rows[0]["AdvocateName"].ToString();
                lbl_OrderIDDate.Text =Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString()).ToString("dd/MM/yyyy");
                lbl_invoicenumber.Text = dt.Rows[0]["InoviceNum"].ToString();
            }
            
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInvoice.aspx");
        }
    }
}
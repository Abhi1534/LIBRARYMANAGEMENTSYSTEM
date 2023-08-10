using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM.admin.User
{
    public partial class UserPaymentConformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PageIntiateforpayment"].ToString() == "ID Card" || Session["PageIntiateforpayment"].ToString() == "Proximity Card" || Session["PageIntiateforpayment"].ToString() == "Car Pass" || Session["PageIntiateforpayment"].ToString() == "Practice Certificate")
                {
                    paymentinitiationUserServices();
                }
                else
                {
                    paymentinitiation();
                }
                
            }
           
        }
        public void paymentinitiation()
        {
            if (Session["membershipfee"] != null && !string.IsNullOrWhiteSpace(Session["membershipfee"].ToString()))
            {
                LBR_DAL objDal = new LBR_DAL();
                ReceiptDetails objReceiptDetails = new ReceiptDetails();
                PaymentTypeConformation objpayment = new PaymentTypeConformation();
                objReceiptDetails = (ReceiptDetails)Session["objReceiptDetails"];
                objpayment = (PaymentTypeConformation)Session["objpayment"];
                DataTable dt = objDal.InsertReceiptDetails(objReceiptDetails, objpayment);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() != "Fail" && dt.Rows[0][0].ToString() != "Already Exists")
                    {
                        Session["scinvm"] = dt.Rows[0]["INVNUM"].ToString();
                        lbl_paymentstatus.Text = "Payment Successfully!";
                    }
                    else
                    {
                        //div_success.Visible = false;
                        //div_fail.Visible = true;
                    }

                }
            }
        }

        public void paymentinitiationUserServices()
        {
            if (Session["membershipfee"] != null && !string.IsNullOrWhiteSpace(Session["membershipfee"].ToString()))
            {
                UserServiceRequest objpayment = new UserServiceRequest();
                objpayment = (UserServiceRequest)Session["UserServiceRequest"];
                LMBAL objbal = new LMBAL();
                DataSet ds = new DataSet();
                ds = objbal.pr_ins_and_Update_Tbl_UserServiceRequest(objpayment);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["result"].ToString() == "Success")
                    {
                        lbl_paymentstatus.Text = "Payment Successfully!";
                        if (Session["PageIntiateforpayment"].ToString() == "ID Card")
                        {
                            btn_viewcard.Visible = true;
                        }
                        if (Session["PageIntiateforpayment"].ToString() == "Car Pass")
                        {
                            VehicalRequest objve = new VehicalRequest();
                            objve = (VehicalRequest)Session["Gv_Vehical_details"];
                            
                            DataSet ds1 = new DataSet();
                            objve.CreatedBy = Session["MemberID"].ToString();
                            objve.CreatedIp= Request.ServerVariables["Remote_Addr"];
                            ds1 = objbal.pr_ins_VehicalNumber(objve);
                        }
                        
                    }
                }
            }
        }
        protected void btn_view_Click(object sender, EventArgs e)
        {
            if (Session["PageIntiateforpayment"].ToString() == "ID Card" || Session["PageIntiateforpayment"].ToString() == "Proximity Card" || Session["PageIntiateforpayment"].ToString() == "Car Pass" || Session["PageIntiateforpayment"].ToString() == "Practice Certificate")
            {
                Response.Redirect("UserServiceInvoiceView.aspx");
            }
            else
            {
                Response.Redirect("UserInvoiceView.aspx?type=Receipt&Inv=" + Session["scinvm"].ToString(), false);
            }          
        }

        protected void btn_viewcard_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('../idcard.aspx','_blank')</script>");                     
        }
    }
}
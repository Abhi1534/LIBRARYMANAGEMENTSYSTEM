using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class AdminDashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdvocateName"] != null && !string.IsNullOrWhiteSpace(Session["AdvocateName"].ToString()))
                {
                    lbl_pname.Text = Session["AdvocateName"].ToString();
                    lbl_profiletype.Text = Session["RoleName"].ToString();
                    if (Session["userphotopath"] != null && !string.IsNullOrWhiteSpace(Session["userphotopath"].ToString()))
                    {
                        img_photo_avatar.ImageUrl =Session["userphotopath"].ToString();
                        img_drphoto.ImageUrl = Session["userphotopath"].ToString();
                    }
                   
                    CheckUserType();
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
        public void CheckUserType()
        {
            if (Session["UserDetails"] != null)
            {
                LMBAL bal = new LMBAL();
                string[] userDet = Session["UserDetails"].ToString().Split(',');
                DataSet ds = bal.pr_get_logindetails(userDet[0].ToString(), userDet[1].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string memberType = ds.Tables[0].Rows[0]["RoleID"].ToString();
                   if(memberType.ToString()=="1")
                    {
                        lnkMasterMenu.Visible = true;
                        lnkMembReg.Visible = true;
                        lnkBookMaster.Visible = true;
                        lnkPendingApp.Visible = true;
                        lnkStampsIssue.Visible = true;
                        lnkAddFeature.Visible = true;
                        lnkAddReceipt.Visible = true;
                        lnkInvoiceList.Visible = true;
                        lnk_expenditure.Visible = true;
                        lnkExpenses.Visible = true;
                        lnkExpPendingForApproval.Visible = true;
                        lnlprofile.Visible = true;
                        lnlIDCard.Visible = true;

                    }
                    else if (memberType.ToString() == "2")
                    {
                        lnkMasterMenu.Visible = false;
                        lnkMembReg.Visible = true;
                        lnkBookMaster.Visible = false;
                        lnkPendingApp.Visible = true;
                        lnkStampsIssue.Visible = true;
                        lnkAddFeature.Visible = true;
                        lnkAddReceipt.Visible = true;
                        lnkInvoiceList.Visible = true;
                        lnk_expenditure.Visible = false;
                        lnkExpenses.Visible = true;
                        lnkExpPendingForApproval.Visible = false;
                        lnlprofile.Visible = true;
                        lnlIDCard.Visible = true;
                    }
                    else if(memberType.ToString() == "3")
                    {
                        lnkMasterMenu.Visible = false;
                        lnkMembReg.Visible = false;
                        lnkBookMaster.Visible = true;
                        lnkPendingApp.Visible = false;
                        lnkStampsIssue.Visible = false;
                        lnkAddFeature.Visible = false;
                        lnkAddReceipt.Visible = false;
                        lnkInvoiceList.Visible = true;
                        lnk_expenditure.Visible = false;
                        lnkExpenses.Visible = true;
                        lnkExpPendingForApproval.Visible = false;
                        lnlprofile.Visible = true;
                        lnlIDCard.Visible = true;
                    }

                    else if (memberType.ToString() == "5")
                    {
                        lnkMasterMenu.Visible = false;
                        lnkMembReg.Visible = true;
                        lnkBookMaster.Visible = false;
                        lnkPendingApp.Visible = true;
                        lnkStampsIssue.Visible = true;
                        lnkAddFeature.Visible = true;
                        lnkAddReceipt.Visible = true;
                        lnkInvoiceList.Visible = true;
                        lnk_expenditure.Visible = false;
                        lnkExpenses.Visible = true;
                        lnkExpPendingForApproval.Visible = false;
                        lnlprofile.Visible = true;
                        lnlIDCard.Visible = true;
                    }
                    else if (memberType.ToString() == "6")
                    {
                        lnkMasterMenu.Visible = false;
                        lnkMembReg.Visible = true;
                        lnkBookMaster.Visible = false;
                        lnkPendingApp.Visible = true;
                        lnkStampsIssue.Visible = false;
                        lnkAddFeature.Visible = false;
                        lnkAddReceipt.Visible = false;
                        lnkInvoiceList.Visible = true;
                        lnk_expenditure.Visible = true;
                        lnkExpenses.Visible = false;
                        lnkExpPendingForApproval.Visible = true;
                        lnlprofile.Visible = true;
                        lnlIDCard.Visible = true;
                    }
                    else if (memberType.ToString() == "7")
                    {
                        lnkMasterMenu.Visible = false;
                        lnkMembReg.Visible = true;
                        lnkBookMaster.Visible = false;
                        lnkPendingApp.Visible = true;
                        lnkStampsIssue.Visible = false;
                        lnkAddFeature.Visible = false;
                        lnkAddReceipt.Visible = false;
                        lnkInvoiceList.Visible = true;
                        lnk_expenditure.Visible = true;
                        lnkExpenses.Visible = false;
                        lnkExpPendingForApproval.Visible = true;
                        lnlprofile.Visible = true;
                        lnlIDCard.Visible = true;
                    }
                    else if (memberType.ToString() == "8")
                    {
                        lnkMasterMenu.Visible = false;
                        lnkMembReg.Visible = false;
                        lnkBookMaster.Visible = false;
                        lnkPendingApp.Visible = false;
                        lnkStampsIssue.Visible = false;
                        lnkAddFeature.Visible = false;
                        lnkAddReceipt.Visible = false;
                        lnkInvoiceList.Visible = false;
                        lnk_expenditure.Visible = false;
                        lnkExpenses.Visible = true;
                        lnkExpPendingForApproval.Visible = false;
                        lnlprofile.Visible = true;
                        lnlIDCard.Visible = true;
                    }

                    else
                    {
                        
                    }
                }
                }
        }
    }
}
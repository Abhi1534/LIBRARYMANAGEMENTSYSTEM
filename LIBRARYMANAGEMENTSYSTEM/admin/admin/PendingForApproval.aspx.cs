using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System.IO;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class PendingForApproval : System.Web.UI.Page
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
                BindGrid();
                bindmembershiptype();
            }
           
        }
        public void BindGrid()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = objDal.GetPendingMembersList();
                if (dt.Rows.Count > 0)
                {
                    Session["GriData"] = dt;
                    gdvPendigList.DataSource = dt;
                    gdvPendigList.DataBind();
                }
                else
                {
                    gdvPendigList.EmptyDataText = "No Details Found";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Pending List')", true);
                }
            }
            catch (Exception ex)
            { }
}
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (Session["GriData"] != null)
            {
                DataTable dt = (DataTable)ViewState["GriData"];
                DataTable dtNew = dt.Select("[AdvocateName] like '" + txtSearch.Text + "%'").CopyToDataTable();
                gdvPendigList.DataSource = dtNew;
                gdvPendigList.DataBind();
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
        protected void gdvPendigList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Btn_ApproveCommand")
                {
                    // string UID = e.CommandArgument.ToString();
                     GridViewRow gvrc = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                     int RowIndex = gvrc.RowIndex;
                   // string filname = e.CommandArgument.ToString();
                    Label lblMemberID = (Label)gdvPendigList.Rows[RowIndex].FindControl("lblMemberID");
                    //GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
                    //LinkButton lb = (LinkButton)sender;
                    //GridViewRow rows = (GridViewRow)lb.NamingContainer;
                    //Label lblMemberID = rows.FindControl("lblMemberID") as Label;
                    LMBAL bal = new LMBAL();
                    DataSet ds = bal.pr_get_memberregistrationbyid(lblMemberID.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        pnl_entry.Visible = true;
                        pnl_view.Visible = false;
                        txtSearch.Visible = false;

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
                        txt_vehiclenumber.Text = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                        ddl_vote.SelectedItem.Text = ds.Tables[0].Rows[0]["Vote"].ToString();
                        txt_enrollmentnumber.Text = ds.Tables[0].Rows[0]["EnrollmentNumber"].ToString();
                        Session["MembershippersonID"] = ds.Tables[0].Rows[0]["MemberID"].ToString();


                        img_barcouncilenrollmentcerupload.ImageUrl = ds.Tables[0].Rows[0]["barcouncilenrollmentcerpath"].ToString();
                        Session["barcouncilenrollmentcerfilepath"] = ds.Tables[0].Rows[0]["barcouncilenrollmentcerpath"].ToString();
                        img_barcouncilenrollmentcerupload.Visible = true;

                        img_barcouncilIDupload.ImageUrl = ds.Tables[0].Rows[0]["barcouncilIDpath"].ToString();
                        Session["barcouncilIDuploadfilepath"] = ds.Tables[0].Rows[0]["barcouncilIDpath"].ToString();
                        img_barcouncilIDupload.Visible = true;

                        img_photoupload.ImageUrl =ds.Tables[0].Rows[0]["photopath"].ToString();
                        Session["Photofilepath"] = ds.Tables[0].Rows[0]["photopath"].ToString();
                        img_photoupload.Visible = true;



                    }
                }
                //if (e.CommandName == "Btn_ApproveCommand")
                //{
                //    GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                //    Button lb = (Button)sender;
                //    GridViewRow rows = (GridViewRow)lb.NamingContainer;
                //    Label lblMemberID = rows.FindControl("lblMemberID") as Label;
                //    DataTable dt = new DataTable();
                //    string modifyIP = Request.ServerVariables["Remote_Addr"];
                //    string modifyBy = Session["MemberID"].ToString();
                //    dt = objDal.AprrovePendingMembersList(lblMemberID.Text, modifyBy.ToString(), modifyIP.ToString());
                //    string scriptText = "alert('Membership Approved Successfully!!!'); window.location='../admin/PendingForApproval.aspx'";
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", scriptText, true);
                //  //  BindGrid();
                //}
            }
            catch (Exception ex)
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
        protected void btn_Approve_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string modifyIP = Request.ServerVariables["Remote_Addr"];
            string modifyBy = Session["MemberID"].ToString();
            dt = objDal.AprrovePendingMembersList(Session["MembershippersonID"].ToString(), modifyBy.ToString(), modifyIP.ToString(), Session["MembershipEmailID"].ToString());
            string scriptText = "alert('Membership Approved Successfully!!!'); window.location='../admin/PendingForApproval.aspx'";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", scriptText, true);
            BindGrid();
        }
    }
}
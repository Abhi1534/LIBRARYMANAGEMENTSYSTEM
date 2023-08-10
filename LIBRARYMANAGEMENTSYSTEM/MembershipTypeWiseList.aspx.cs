using LIBRARYMANAGEMENTSYSTEM.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIBRARYMANAGEMENTSYSTEM
{
    public partial class MembershipTypeWiseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddl_MemberShipType.SelectedValue != "")
            {
                binddatamembershipwise();
            }                      

            if (!IsPostBack)
            {
                bindmembershiptype();
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
     
        protected string PhotoBase64ImgSrc(string fileNameandPath)
        {
            string base64 = string.Empty;
            try
            {
                if (fileNameandPath == "0" || string.IsNullOrEmpty(fileNameandPath))
                {
                    fileNameandPath = @"C:\Users\malya\OneDrive\Documents\Visual Studio 2015\Projects\LIBRARYMANAGEMENTSYSTEM\LIBRARYMANAGEMENTSYSTEM\images\Emptyimage.png";
                    byte[] byteArray = File.ReadAllBytes(fileNameandPath);
                    base64 = Convert.ToBase64String(byteArray);
                }
                else
                {
                    byte[] byteArray = File.ReadAllBytes(fileNameandPath);
                    base64 = Convert.ToBase64String(byteArray);
                }

            }
            catch (Exception ex)
            {
            }

            return string.Format("data:image/gif;base64,{0}", base64);
        }
        public void btnmemberview_Click(object sender, EventArgs e)
        {
            string argument = ((LinkButton)sender).CommandArgument;
            Session["MemberviewID"] = argument;
            if (argument != "")
            {
                Response.Redirect("MemberWiseDetails.aspx?MemberviewID=" + Session["MemberviewID"].ToString());
            }

        }
    
        public void binddatamembershipwise()
        {
             pnl_viewDetails.Controls.Clear();
            LMBAL objMaster = new LMBAL();
            DataSet ds = objMaster.pr_get_membershipwisememberdata(ddl_MemberShipType.SelectedItem.Value);
            if (ds.Tables[0].Rows.Count > 0)
            {
                pnl_viewDetails.Controls.Add(new LiteralControl("<div class='row'>"));
                pnl_viewDetails.Controls.Add(new LiteralControl("<div class='col-sm-12'>"));
                pnl_viewDetails.Controls.Add(new LiteralControl("<div class='card' style='text-align:center;font-weight:bold;'>"));
                pnl_viewDetails.Controls.Add(new LiteralControl("<div class='card-body custom-edit-service'>"));
                pnl_viewDetails.Controls.Add(new LiteralControl("<div 'class=service-fields mb-3'>"));
                pnl_viewDetails.Controls.Add(new LiteralControl("<div class='row'>"));

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    pnl_viewDetails.Controls.Add(new LiteralControl("<div class='col-lg-3 col-sm-4'> "));
                    pnl_viewDetails.Controls.Add(new LiteralControl("<div class='singel-teachers mt-50 text-center' style='height: 300px'>"));
                    pnl_viewDetails.Controls.Add(new LiteralControl("<div class='image'>"));

                    pnl_viewDetails.Controls.Add(new System.Web.UI.WebControls.Image { ImageUrl = ds.Tables[0].Rows[i]["photopath"].ToString() });
                    pnl_viewDetails.Controls.Add(new LiteralControl("</div>"));

                    pnl_viewDetails.Controls.Add(new LiteralControl("<div class='cont' style='background-color: whitesmoke;'>"));
                    pnl_viewDetails.Controls.Add(new LiteralControl("<h6>"));

                    LinkButton linkmemberview = new LinkButton()
                    {
                        Text = ds.Tables[0].Rows[i]["AdvocateName"].ToString()
                    };

                    linkmemberview.Attributes.Add("runat", "server");
                    linkmemberview.CommandName = "btn_view";
                    linkmemberview.CommandArgument = ds.Tables[0].Rows[i]["MemberID"].ToString();
                    linkmemberview.Click += new EventHandler(this.btnmemberview_Click);
                    linkmemberview.CausesValidation = false;
                    pnl_viewDetails.Controls.Add(linkmemberview);
                    pnl_viewDetails.Controls.Add(new LiteralControl("</h6>"));

                    pnl_viewDetails.Controls.Add(new LiteralControl("<span>"));
                    Label lblMembershipTypeName = new Label();
                    lblMembershipTypeName.Text = ds.Tables[0].Rows[i]["MembershipTypeName"].ToString();
                    pnl_viewDetails.Controls.Add(lblMembershipTypeName);
                    pnl_viewDetails.Controls.Add(new LiteralControl("<br />"));


                    pnl_viewDetails.Controls.Add(new LiteralControl("</span>"));

                    pnl_viewDetails.Controls.Add(new LiteralControl("</div>"));
                    pnl_viewDetails.Controls.Add(new LiteralControl("</div>"));
                    pnl_viewDetails.Controls.Add(new LiteralControl("</div>"));

                }
                pnl_viewDetails.Controls.Add(new LiteralControl("</div>"));
                pnl_viewDetails.Controls.Add(new LiteralControl("</div>"));
                pnl_viewDetails.Controls.Add(new LiteralControl("</div>"));
                pnl_viewDetails.Controls.Add(new LiteralControl("</div>"));
                pnl_viewDetails.Controls.Add(new LiteralControl("</div>"));

            }
        }

        protected void ddl_MemberShipType_SelectedIndexChanged(object sender, EventArgs e)
        {
           // binddatamembershipwise();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using ZXing;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public partial class BookIssue : System.Web.UI.Page
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
                gdvBookIssues.Visible = false;
                Session["GridData"] = null;
                txtissueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
               // GetBooks();
                
            }
        }
        //public void GetBooks()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = objDal.GetBooksData("1", "0");
        //        if (dt.Rows.Count > 0)
        //        {
        //            Session["BookData"] = dt;
        //            ddlBookName.DataSource = dt;
        //            ddlBookName.DataTextField = "BookName";
        //            ddlBookName.DataValueField = "BookID";
        //            ddlBookName.DataBind();
        //            ddlBookName.Items.Insert(0, new ListItem("Select Book Name", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    { }

        //}
       //public void barcodefetch()
       // {
       //     BarcodeResult Result = BarcodeReader.QuicklyReadOneBarcode("GetStarted.png");
       //     if (Result != null && Result.Text == "https://ironsoftware.com/csharp/barcode/")
       //     {
       //         Console.WriteLine("GetStarted was a success.  Read Value: " + Result.Text);
       //     }
       // }
      
    //protected void ddlBookName_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        if (Session["BookData"] != null)
    //        {
    //            DataTable dt = (DataTable)Session["BookData"];
    //            DataTable newDt = dt.Select("[BookID]='" + Convert.ToUInt32(ddlBookName.SelectedValue) + "'").CopyToDataTable();
    //            if (newDt.Rows.Count > 0)
    //            {
    //                txtPrice.Text = newDt.Rows[0]["Price"].ToString();
    //                txtAuthor.Text = newDt.Rows[0]["AutherName"].ToString();
    //                txtAvailableBooks.Text = newDt.Rows[0]["AvailableBooks"].ToString();
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txtNoOfbooks.Text))
    //        {
    //            int noOfBooks = Convert.ToInt32(txtNoOfbooks.Text);
    //            int price = Convert.ToInt32(txtPrice.Text);
    //        }
    //    }

        protected void txtNoOfbooks_TextChanged(object sender, EventArgs e)
        {
            int noOfBooks = Convert.ToInt32(txtNoOfbooks.Text);
            int price = Convert.ToInt32(txtPrice.Text);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            string userip = Request.UserHostAddress;
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(txtPrice.Text))
            {
                if (Session["GridData"] != null)
                {
                    dt = (DataTable)Session["GridData"];
                    DataRow drNew = dt.NewRow();
                    // drNew["BookID"] = ddlBookName.SelectedValue;
                    drNew["BookID"] = txt_BookName.Text.Substring(txt_BookName.Text.LastIndexOf('-') + 1);
                    drNew["MemberShipID"] = lblMemberID.Text;
                    // drNew["BookName"] = ddlBookName.SelectedItem.Text;
                    drNew["BookName"] = txt_BookName.Text.Substring(0, txt_BookName.Text.IndexOf('-'));
                    drNew["AuthorName"] = txtAuthor.Text;
                    drNew["DateOfIssue"] = txtissueDate.Text;
                    drNew["IssuedBy"] = Session["MemberID"].ToString();
                    drNew["NoOfbooks"] = txtNoOfbooks.Text;
                    drNew["Price"] = txtPrice.Text;
                    drNew["CreatedBy"] = Session["MemberID"].ToString();
                    drNew["UserIP"] = userip.ToString();

                    dt.Rows.Add(drNew);
                    dt.AcceptChanges();
                    Session["GridData"] = dt;
                    gdvBookIssues.Visible = true;
                    gdvBookIssues.DataSource = dt;
                    gdvBookIssues.DataBind();
                }
                else
                {
                    dt.Columns.Add(new DataColumn("BookID", typeof(string)));
                    dt.Columns.Add(new DataColumn("MemberShipID", typeof(string)));
                    dt.Columns.Add(new DataColumn("BookName", typeof(string)));
                    dt.Columns.Add(new DataColumn("AuthorName", typeof(string)));
                    dt.Columns.Add(new DataColumn("DateOfIssue", typeof(string)));
                    dt.Columns.Add(new DataColumn("IssuedBy", typeof(string)));
                    dt.Columns.Add(new DataColumn("NoOfbooks", typeof(string)));
                    dt.Columns.Add(new DataColumn("Price", typeof(string)));
                    dt.Columns.Add(new DataColumn("Amount", typeof(int)));
                    dt.Columns.Add(new DataColumn("CreatedBy", typeof(string)));
                    dt.Columns.Add(new DataColumn("UserIP", typeof(string)));

                    DataRow drNew = dt.NewRow();
                    drNew["BookID"] = txt_BookName.Text.Substring(txt_BookName.Text.LastIndexOf('-') + 1);
                   // drNew["BookID"] = ddlBookName.SelectedValue;
                    drNew["MemberShipID"] = lblMemberID.Text;
                    // drNew["BookName"] = ddlBookName.SelectedItem.Text;
                    drNew["BookName"] = txt_BookName.Text.Substring(0, txt_BookName.Text.IndexOf('-'));
                    drNew["AuthorName"] = txtAuthor.Text;
                    drNew["DateOfIssue"] = txtissueDate.Text;
                    drNew["IssuedBy"] = Session["MemberID"].ToString();
                    drNew["NoOfbooks"] = txtNoOfbooks.Text;
                    drNew["Price"] = txtPrice.Text;
                    drNew["CreatedBy"] = "1";
                    drNew["UserIP"] = userip.ToString();
                    dt.Rows.Add(drNew);
                    dt.AcceptChanges();
                    Session["GridData"] = dt;
                    gdvBookIssues.Visible = true;
                    gdvBookIssues.DataSource = dt;
                    gdvBookIssues.DataBind();
                }
                txt_search.Text = "";
                txt_BookName.Text = "";
                //ddlBookName.SelectedValue = "0";
                txtAuthor.Text = "";
                txtissueDate.Text = "";
                txtIssuedBy.Text = "";
                txtNoOfbooks.Text = "";
                txtPrice.Text = "";
                txtAvailableBooks.Text = "";
                txtMemberShipMobileNo.Text = "";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Book Name and No Of Books')", true);
                return;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["GridData"] != null)
            {
                DataTable dt = (DataTable)Session["GridData"];
                string result = objDal.SaveBookIssue(dt);
                div_success.Visible = true;
                clearData();
            }
        }

        public void clearData()
        {
            gdvBookIssues.DataSource = "";
            gdvBookIssues.Visible = false;
            btnSave.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            Button lb = (Button)sender;
            GridViewRow rows = (GridViewRow)lb.NamingContainer;
            try
            {

                if (rows != null)
                {
                    int index = rows.RowIndex;
                    Label lblBookID = rows.FindControl("lblBookID") as Label;
                    DataTable dt = Session["GridData"] as DataTable;
                    dt.Rows[index].Delete();
                    Session["GridData"] = dt;
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[0]["BookID"].ToString()))
                            {
                                gdvBookIssues.DataSource = dt;
                                gdvBookIssues.DataBind();
                                btnSave.Visible = true;
                            }
                            else
                            {
                                btnSave.Visible = false;
                            }
                        }
                        else
                        {
                            btnSave.Visible = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }


        }

        protected void txtMemberShipMobileNo_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = objDal.GetBooksByMember(txtMemberShipMobileNo.Text, "2");
            if (dt.Rows.Count > 0)
            {
                lblMemberID.Text = dt.Rows[0]["memberID"].ToString();
                txt_membershipname.Text = dt.Rows[0]["AdvocateName"].ToString();
               
            }
            else
            {
                txtMemberShipMobileNo.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Mobile No of Membership user ')", true);
                return;
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> SearchText(string prefixText, int count)
        {
            LMBAL objMaster = new LMBAL();
            DataSet dt_Set = objMaster.pr_get_serachbookname(prefixText);
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
            //string bookid = txt_search.Text.Substring(txt_search.Text.LastIndexOf('-') + 1);          
            //DataSet ds = objMaster.pr_get_booknamebyid(bookid);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
            //    txtAuthor.Text = ds.Tables[0].Rows[0]["AutherName"].ToString();
            //    txtAvailableBooks.Text = ds.Tables[0].Rows[0]["AvailableBooks"].ToString();
            //}
            DataSet ds1 = objMaster.pr_get_BookSerialNoid(txt_search.Text);//book id dhagira text value pass chaie
            if (ds1.Tables[0].Rows.Count > 0)
            {
                txtPrice.Text = ds1.Tables[0].Rows[0]["Price"].ToString();
                txtAuthor.Text = ds1.Tables[0].Rows[0]["AutherName"].ToString();
                txtAvailableBooks.Text = ds1.Tables[0].Rows[0]["AvailableBooks"].ToString();
                txt_BookName.Text= ds1.Tables[0].Rows[0]["BookName"].ToString();
            }
        }


    }
}
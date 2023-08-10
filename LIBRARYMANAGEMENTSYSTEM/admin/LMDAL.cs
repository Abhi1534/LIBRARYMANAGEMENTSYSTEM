using LIBRARYMANAGEMENTSYSTEM.admin.admin.AppCode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static LIBRARYMANAGEMENTSYSTEM.admin.LMBO;

namespace LIBRARYMANAGEMENTSYSTEM.admin
{
    public class LMDAL
    {
        string strConnectionString = string.Empty;

        public LMDAL()
        {
            strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        //Membership type master start
        public DataSet INSMembershiptype(Membershiptypemaster objmtm)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_ins_and_Update_tbl_MemebershipType", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@MembershipTypeName", objmtm.Membershiptype);
                    cmdsrc.Parameters.AddWithValue("@Subscription", objmtm.Subscription);
                    cmdsrc.Parameters.AddWithValue("@EntranceFee", objmtm.EntranceFee);
                    cmdsrc.Parameters.AddWithValue("@IdentityCard", objmtm.IdentityCard);
                    cmdsrc.Parameters.AddWithValue("@ApplicationForm", objmtm.ApplicationForm);
                    cmdsrc.Parameters.AddWithValue("@Miscellaneous", objmtm.Miscellaneous);
                    cmdsrc.Parameters.AddWithValue("@EntryIdentityCard", objmtm.EntryIdentityCard);
                    cmdsrc.Parameters.AddWithValue("@totalfee", objmtm.totalfee);
                    cmdsrc.Parameters.AddWithValue("@Description", objmtm.Description);
                    cmdsrc.Parameters.AddWithValue("@CreatedBy", objmtm.CreatedBy);
                    cmdsrc.Parameters.AddWithValue("@CreatedIp", objmtm.CreatedIP);
                    cmdsrc.Parameters.AddWithValue("@IsActive", objmtm.IsActive);
                    cmdsrc.Parameters.AddWithValue("@Membershiptypeid", objmtm.Membershiptypeid);
                    cmdsrc.Parameters.AddWithValue("@ModifyBy", objmtm.ModifyBy);
                    cmdsrc.Parameters.AddWithValue("@ModifyIp", objmtm.ModifyIp);
                    cmdsrc.Parameters.AddWithValue("@flag", objmtm.flag);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet GETALLMembershiptype()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_getallMembershipTypes", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        // end------------------------------------------------------------------------------------------


        //section Master start
        public DataSet INSRacksection(RactSection objmtm)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_ins_and_Update_tbl_SectionMaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@SectionName", objmtm.RackSectionName);
                    cmdsrc.Parameters.AddWithValue("@Description", objmtm.Description);
                    cmdsrc.Parameters.AddWithValue("@CreatedBy", objmtm.CreatedBy);
                    cmdsrc.Parameters.AddWithValue("@CreatedIp", objmtm.CreatedIP);
                    cmdsrc.Parameters.AddWithValue("@IsActive", objmtm.IsActive);
                    cmdsrc.Parameters.AddWithValue("@SecMID", objmtm.SecMID);
                    cmdsrc.Parameters.AddWithValue("@ModifyBy", objmtm.ModifyBy);
                    cmdsrc.Parameters.AddWithValue("@ModifyIp", objmtm.ModifyIp);
                    cmdsrc.Parameters.AddWithValue("@flag", objmtm.flag);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet INSSubjectMaster(Subject objmtm)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_ins_and_Update_tbl_SubjectMaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@SubjectName", objmtm.SubjectName);
                    cmdsrc.Parameters.AddWithValue("@Description", objmtm.Description);
                    cmdsrc.Parameters.AddWithValue("@CreatedBy", objmtm.CreatedBy);
                    cmdsrc.Parameters.AddWithValue("@CreatedIp", objmtm.CreatedIP);
                    cmdsrc.Parameters.AddWithValue("@IsActive", objmtm.IsActive);
                    cmdsrc.Parameters.AddWithValue("@SubID", objmtm.SubjectID);
                    cmdsrc.Parameters.AddWithValue("@ModifyBy", objmtm.ModifyBy);
                    cmdsrc.Parameters.AddWithValue("@ModifyIp", objmtm.ModifyIp);
                    cmdsrc.Parameters.AddWithValue("@flag", objmtm.flag);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet GETALLRacksection()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("Pr_GetAllSections", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        // end------------------------------------------------------------------------------------------


        //Rack Master start
        public DataSet INSRacksMaster(RactMaster objmtm)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_ins_and_Update_tbl_RackMaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@SectionName", objmtm.SectionName);
                    cmdsrc.Parameters.AddWithValue("@RackName", objmtm.RackName);
                    cmdsrc.Parameters.AddWithValue("@NoOfSelfs", objmtm.NumberofSelfs);
                    cmdsrc.Parameters.AddWithValue("@Description", objmtm.Description);
                    cmdsrc.Parameters.AddWithValue("@CreatedBy", objmtm.CreatedBy);
                    cmdsrc.Parameters.AddWithValue("@CreatedIp", objmtm.CreatedIP);
                    cmdsrc.Parameters.AddWithValue("@IsActive", objmtm.IsActive);
                    cmdsrc.Parameters.AddWithValue("@ModifyBy", objmtm.ModifyBy);
                    cmdsrc.Parameters.AddWithValue("@ModifyIp", objmtm.ModifyIp);
                    cmdsrc.Parameters.AddWithValue("@RackID", objmtm.RackID);
                    cmdsrc.Parameters.AddWithValue("@flag", objmtm.flag);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet GETALLRacksMaster()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("Pr_GetALLRackMaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet Pr_GetALLselfMaster()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("Pr_GetALLselfMaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        // end------------------------------------------------------------------------------------------

        //Rack Master


        public DataSet Pr_GetRacknamebysection(string SectionID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("Pr_GetRacknamebysection", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@SectionID", SectionID);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        //end


        public DataSet Pr_Getsectionbyrackname(string SectionID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("Pr_Getsectionbyrackname", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@SectionID", SectionID);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet GETSelfsbyRack(string section, string Rack)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("Pr_GetSelfnamebyRack", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@SectionID", section);
                    cmdsrc.Parameters.AddWithValue("@RackName", Rack);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        public DataSet INSselfmaster(SelfMasteradd objmtm)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_ins_and_Update_tbl_SelfMaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@SectionName", objmtm.SectionName);
                    cmdsrc.Parameters.AddWithValue("@RackName", objmtm.RackName);
                    cmdsrc.Parameters.AddWithValue("@NoOfSelfs", objmtm.NumberofSelfs);
                    cmdsrc.Parameters.AddWithValue("@NoOfBooksInSelf", objmtm.NumberofBooks);
                    cmdsrc.Parameters.AddWithValue("@Description", objmtm.Description);
                    cmdsrc.Parameters.AddWithValue("@CreatedBy", objmtm.CreatedBy);
                    cmdsrc.Parameters.AddWithValue("@CreatedIp", objmtm.CreatedIP);
                    cmdsrc.Parameters.AddWithValue("@IsActive", objmtm.IsActive);
                    cmdsrc.Parameters.AddWithValue("@flag", 1);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }



        public DataSet INSMembershipRegistration(MemberShipRegistration objmtm)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_ins_and_Update_tbl_MembershipRegistration", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@AdvocateName", objmtm.AdvocateName);
                    cmdsrc.Parameters.AddWithValue("@Gender", objmtm.Gender);
                    cmdsrc.Parameters.AddWithValue("@MobileNumber", objmtm.MobileNumber);
                    cmdsrc.Parameters.AddWithValue("@PhoneNumber", objmtm.PhoneNumber);
                    cmdsrc.Parameters.AddWithValue("@Address", objmtm.Address);
                    cmdsrc.Parameters.AddWithValue("@Email", objmtm.Email);
                    cmdsrc.Parameters.AddWithValue("@DOB", objmtm.DOB);
                    cmdsrc.Parameters.AddWithValue("@BloodGroup", objmtm.BloodGroup);
                    cmdsrc.Parameters.AddWithValue("@EnrollmentDate", objmtm.EnrollmentDate);
                    cmdsrc.Parameters.AddWithValue("@State", objmtm.State);
                    cmdsrc.Parameters.AddWithValue("@MembershipType", objmtm.MembershipType);
                    cmdsrc.Parameters.AddWithValue("@MembershipDate", objmtm.MembershipDate);
                    cmdsrc.Parameters.AddWithValue("@MembershipFee", objmtm.MembershipFee);
                    cmdsrc.Parameters.AddWithValue("@VehicleNumber", objmtm.VehicleNumber);
                    cmdsrc.Parameters.AddWithValue("@Vote", objmtm.Vote);
                    cmdsrc.Parameters.AddWithValue("@CreatedBy", objmtm.CreatedBy);
                    cmdsrc.Parameters.AddWithValue("@CreatedIp", objmtm.CreatedIP);
                    cmdsrc.Parameters.AddWithValue("@IsActive", objmtm.IsActive);
                    cmdsrc.Parameters.AddWithValue("@flag", objmtm.flag);
                    cmdsrc.Parameters.AddWithValue("@EnrollmentNumber", objmtm.enrollmentNumber);
                    cmdsrc.Parameters.AddWithValue("@Certificateofpracticepath", objmtm.Certificateofpracticepath);
                    cmdsrc.Parameters.AddWithValue("@ModifyBy", objmtm.ModifyBy);
                    cmdsrc.Parameters.AddWithValue("@ModifyIp", objmtm.ModifyIp);
                    cmdsrc.Parameters.AddWithValue("@barcouncilenrollmentcerpath", objmtm.barcouncilenrollmentcerpath);
                    cmdsrc.Parameters.AddWithValue("@barcouncilIDpath", objmtm.barcouncilIDpath);
                    cmdsrc.Parameters.AddWithValue("@photopath", objmtm.photopath);
                    cmdsrc.Parameters.AddWithValue("@MemberID", objmtm.MemberID);
                    cmdsrc.Parameters.AddWithValue("@ClerkName", objmtm.ClerkName);
                    cmdsrc.Parameters.AddWithValue("@ClerkMobileNumber", objmtm.ClerkMobileNumber);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        public DataSet pr_getmembershiptypebyfee(string MembershipTypeID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_getmembershiptypebyfee", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@MembershipTypeID", MembershipTypeID);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_logindetails(string UserName, string password)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_logindetails", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@username", UserName);
                    cmdsrc.Parameters.AddWithValue("@password", password);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_logindetails_otp(string UserName)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_logindetails_otp", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@username", UserName);
                   
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_serch_membershiptype(string text)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_serch_membershiptype", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@text", text);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_membershiptypeMasterbyid(string Memid)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_membershiptypeMasterbyid", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@Memid", Memid);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_serch_SectionMaster(string text)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_serch_SectionMaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@text", text);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_Sectionmasterbyid(string SecMID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_Sectionmasterbyid", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@SecMID", SecMID);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_getindidvalmembershipdata(string emailid, string mobilenumber)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_getindidvalmembershipdata", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@Email", emailid);
                    cmdsrc.Parameters.AddWithValue("@MobileNumber", emailid);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_getmemberdata()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_getmemberdata", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_Searchmembershipregistration(string text)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_Searchmembershipregistration", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@text", text);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_Dashboarddata(string fromdate, string todate)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_Dashboarddata", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@fromdate", fromdate);
                    cmdsrc.Parameters.AddWithValue("@todate", todate);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_serch_RackMaster(string text)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_serch_RackMaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@text", text);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_Rackmasterbyid(string RackID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_Rackmasterbyid", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@RackID", RackID);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_serch_Selfmaster(string text)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_serch_Selfmaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@text", text);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_serch_Subjectmaster(string text)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_serch_Subjectmaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@text", text);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        public DataSet pr_get_Subjectmasterbyid(string SubID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_Subjectmasterbyid", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@SubID", SubID);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_allSubjectmaster()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_allSubjectmaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_SelfmasterbyID(string SelMID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_SelfmasterbyID", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@SelMID", SelMID);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        //public DataSet pr_ins_and_Update_tbl_PaymentConformation(PaymentConformation objmtm)
        //{
        //    DataSet ds = new DataSet();
        //    using (SqlConnection con = new SqlConnection(strConnectionString))
        //    {
        //        try
        //        {
        //            SqlCommand cmdsrc = new SqlCommand("pr_ins_and_Update_tbl_PaymentConformation", con);
        //            cmdsrc.CommandType = CommandType.StoredProcedure;
        //            cmdsrc.Parameters.AddWithValue("@MembershipID", objmtm.MembershipID);
        //            cmdsrc.Parameters.AddWithValue("@MembershipType", objmtm.MembershipType);
        //            cmdsrc.Parameters.AddWithValue("@Membershipvalue", objmtm.Membershipvalue);
        //            cmdsrc.Parameters.AddWithValue("@CreatedBy", objmtm.CreatedBy);
        //            cmdsrc.Parameters.AddWithValue("@CreatedIP", objmtm.CreatedIP);
        //            cmdsrc.Parameters.AddWithValue("@flag", objmtm.flag);
        //            cmdsrc.Parameters.AddWithValue("@ReferenceID", objmtm.ReferenceID);
        //            cmdsrc.Parameters.AddWithValue("@PaymentType", objmtm.PaymentType);
        //            cmdsrc.Parameters.AddWithValue("@InoviceNum", objmtm.InoviceNum);
        //            SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
        //            da.Fill(ds);
        //            return ds;
        //        }
        //        catch (Exception ex)
        //        {
        //            // General.LogerrorDB(ex, "DB");
        //            throw ex;

        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }
        //}


        public DataSet pr_get_INVNum_auto()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_INVNum_auto", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_memberregistrationbyid(string memberID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_memberregistrationbyid", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@memberID", memberID);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_get_serachbookname(string text)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_serachbookname", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@text", text);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        public DataSet pr_get_booknamebyid(string BookID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_booknamebyid", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@BookID", BookID);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet InsertPaymentDetails(PaymentTypeConformation objpayment)
        {
            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
                {
                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("pr_ins_and_Update_tbl_PaymentTypeConformations", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //  ------payment----------------
                    cmd.Parameters.AddWithValue("@MembershipID", objpayment.MembershipID.ToString());

                    cmd.Parameters.AddWithValue("@PaymentIntiationpage", objpayment.PaymentIntiationpage);
                    cmd.Parameters.AddWithValue("@Paymentoff", objpayment.Paymentoff);
                    cmd.Parameters.AddWithValue("@PaymentType", objpayment.PaymentType);
                    cmd.Parameters.AddWithValue("@Amount", objpayment.Amount);

                    cmd.Parameters.AddWithValue("@ReferenceID", objpayment.ReferenceID);
                    cmd.Parameters.AddWithValue("@nofnotes2000", objpayment.nofnotes2000);
                    cmd.Parameters.AddWithValue("@nofnotes500", objpayment.nofnotes500);
                    cmd.Parameters.AddWithValue("@nofnotes200", objpayment.nofnotes200);
                    cmd.Parameters.AddWithValue("@nofnotes100", objpayment.nofnotes100);
                    cmd.Parameters.AddWithValue("@nofnotes50", objpayment.nofnotes50);
                    cmd.Parameters.AddWithValue("@nofnotes20", objpayment.nofnotes20);
                    cmd.Parameters.AddWithValue("@nofnotes10", objpayment.nofnotes10);
                    cmd.Parameters.AddWithValue("@nofnotes1_2_5", objpayment.nofnotes1_2_5);
                    cmd.Parameters.AddWithValue("@PaymentStatus", objpayment.PaymentStatus);
                    cmd.Parameters.AddWithValue("@CreatedBy", objpayment.CreatedBy.ToString());
                    cmd.Parameters.AddWithValue("@CreatedIP", objpayment.CreatedIP.ToString());
                    cmd.Parameters.AddWithValue("@IsActive", objpayment.IsActive);
                    cmd.Parameters.AddWithValue("@flag", objpayment.flag);
                    //cmd.ExecuteNonQuery();
                    //sqlCon.Close();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataSet pr_get_BookSerialNoid(string BookSerialNo)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_BookSerialNoid", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@BookSerialNo", BookSerialNo);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_updatepassword(string password, string UserName)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_updatepassword", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@password", password);
                    cmdsrc.Parameters.AddWithValue("@UserName", UserName);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet InsertstampsPaymentDetails(PaymentStamps objpayment)
        {
            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
                {

                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("pr_ins_and_Update_tbl_StampsPaymentConformations", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //  ------payment----------------
                    cmd.Parameters.AddWithValue("@Name", objpayment.Name);
                    cmd.Parameters.AddWithValue("@MobileNumber", objpayment.MobileNumber);
                    cmd.Parameters.AddWithValue("@Email", objpayment.Email);
                    cmd.Parameters.AddWithValue("@PaymentIntiationpage", objpayment.PaymentIntiationpage);
                    cmd.Parameters.AddWithValue("@Numberofstamps", objpayment.NumberOfStamps);
                    cmd.Parameters.AddWithValue("@stampPrice", objpayment.StampPrice);
                    cmd.Parameters.AddWithValue("@PaymentType", objpayment.PaymentType);
                    cmd.Parameters.AddWithValue("@Amount", objpayment.TotalPrice);
                    cmd.Parameters.AddWithValue("@ReferenceID", objpayment.ReferenceID);
                    cmd.Parameters.AddWithValue("@PaymentStatus", objpayment.PaymentStatus);
                    cmd.Parameters.AddWithValue("@CreatedBy", objpayment.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedIP", objpayment.CreatedIP);
                    cmd.Parameters.AddWithValue("@IsActive", objpayment.IsActive);
                    cmd.Parameters.AddWithValue("@EnrollementNo", objpayment.enrollmentNumber);
                    cmd.Parameters.AddWithValue("@flag", objpayment.flag);
                    cmd.Parameters.AddWithValue("@NameofStamp", objpayment.NameofStamp);
                    cmd.Parameters.AddWithValue("@ResAddress", objpayment.ResAddress);
                    cmd.Parameters.AddWithValue("@IssuedStatus", objpayment.IssuedStatus);
                    //cmd.ExecuteNonQuery();
                    //sqlCon.Close();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataSet pr_getstampsamount(string InoviceNum)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_getstampsamount", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@InoviceNum", InoviceNum);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_ins_and_Update_tbl_AddsMaster(Addmaster objadds)
        {
            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
                {

                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("pr_ins_and_Update_tbl_AddsMaster", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //  ------payment----------------
                    cmd.Parameters.AddWithValue("@AddType", objadds.AddType);
                    cmd.Parameters.AddWithValue("@AddName", objadds.AddName);
                    cmd.Parameters.AddWithValue("@AddAmount", objadds.AddAmount);
                    cmd.Parameters.AddWithValue("@StartDate", objadds.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", objadds.EndDate);
                    cmd.Parameters.AddWithValue("@addcontent", objadds.addcontent);
                    cmd.Parameters.AddWithValue("@PhotoPath", objadds.PhotoPath);
                    cmd.Parameters.AddWithValue("@CreatedBy", objadds.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedIp", objadds.CreatedIp);
                    cmd.Parameters.AddWithValue("@Isactive", objadds.Isactive);
                    cmd.Parameters.AddWithValue("@flag", objadds.flag);
                    cmd.Parameters.AddWithValue("@AddID", objadds.AddID);
                    cmd.Parameters.AddWithValue("@ModifyBy", objadds.ModifyBy);
                    cmd.Parameters.AddWithValue("@ModifyIp", objadds.ModifyIp);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataSet pr_get_AddsMaster(string AddID, string flag, string Text)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_AddsMaster", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@AddID", AddID);
                    cmdsrc.Parameters.AddWithValue("@flag", flag);
                    cmdsrc.Parameters.AddWithValue("@Text", Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet pr_ins_and_Update_Tbl_UserServiceRequest(UserServiceRequest objadds)
        {
            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
                {

                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("pr_ins_and_Update_Tbl_UserServiceRequest", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //  ------payment----------------
                    cmd.Parameters.AddWithValue("@ServiceName", objadds.ServiceName);
                    cmd.Parameters.AddWithValue("@MemberID", objadds.MemberID);
                    cmd.Parameters.AddWithValue("@MemberName", objadds.MemberName);
                    cmd.Parameters.AddWithValue("@MobileNumber", objadds.MobileNumber);
                    cmd.Parameters.AddWithValue("@Email", objadds.Email);
                    cmd.Parameters.AddWithValue("@Address", objadds.Address);
                    cmd.Parameters.AddWithValue("@DOB", objadds.DOB);
                    cmd.Parameters.AddWithValue("@BloodGroup", objadds.BloodGroup);
                    cmd.Parameters.AddWithValue("@EnrolementID", objadds.EnrolementID);
                    cmd.Parameters.AddWithValue("@EnrolementDate", objadds.EnrolementDate);
                    cmd.Parameters.AddWithValue("@MembershipType", objadds.MembershipType);
                    cmd.Parameters.AddWithValue("@MembershipDate", objadds.MembershipDate);
                    cmd.Parameters.AddWithValue("@DeliveryType", objadds.DeliveryType);
                    cmd.Parameters.AddWithValue("@Amount", objadds.Amount);
                    cmd.Parameters.AddWithValue("@DeliveryStatus", objadds.DeliveryStatus);
                    cmd.Parameters.AddWithValue("@CourierRefNumber", objadds.CourierRefNumber);
                    cmd.Parameters.AddWithValue("@CourierName", objadds.CourierName);
                    cmd.Parameters.AddWithValue("@CreatedBy", objadds.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedIp", objadds.CreatedIp);
                    cmd.Parameters.AddWithValue("@Isactive", objadds.Isactive);
                    cmd.Parameters.AddWithValue("@flag", objadds.flag);
                    cmd.Parameters.AddWithValue("@PaymentReferenceID", objadds.PaymentReferenceID);
                    cmd.Parameters.AddWithValue("@PaymentStatus", objadds.PaymentStatus);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataSet pr_ins_VehicalNumber(VehicalRequest objadds)
        {

            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
                {

                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("pr_ins_VehicalNumber", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //  ------payment----------------
                    cmd.Parameters.AddWithValue("@MemberID", objadds.MemberID);
                    cmd.Parameters.AddWithValue("@VehicalType", objadds.VehicalType);
                    cmd.Parameters.AddWithValue("@VehicalNumber", objadds.VehicalNumber);
                    cmd.Parameters.AddWithValue("@CreatedBy", objadds.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedIp", objadds.CreatedIp);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataSet pr_getbarcodebookdetails(string flag, string BookID)
        {

            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
                {

                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("pr_getbarcodebookdetails", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //  ------payment----------------
                    cmd.Parameters.AddWithValue("@flag", flag);
                    cmd.Parameters.AddWithValue("@BookID", BookID);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataSet pr_get_Stamps_list(string flag, string InoviceNum, string Status)
        {

            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
                {

                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("pr_get_Stamps_list", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //  ------payment----------------
                    cmd.Parameters.AddWithValue("@flag", flag);
                    cmd.Parameters.AddWithValue("@InoviceNum", InoviceNum);
                    cmd.Parameters.AddWithValue("@Status", Status);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }


        public DataSet pr_get_membershipwisememberdata(string MembershipType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("pr_get_membershipwisememberdata", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@MembershipType", MembershipType);
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }


        public DataSet pr_get_latestnews_image(string flag, string NewsID)
        {

            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
                {

                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("pr_get_latestnews_image", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //  ------payment----------------
                    cmd.Parameters.AddWithValue("@flag", flag);
                    cmd.Parameters.AddWithValue("@NewsID", NewsID);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }

        public DataSet pr_get_otp()
        {

            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
                {

                    //sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("pr_get_otp", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            { }
            return dt;
        }
        public DataSet GetIDCardDetailsbyMobileNo(string mobileNo)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("Pr_GetIDCardDetailsbyMobileNo", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    cmdsrc.Parameters.AddWithValue("@MobileNo", mobileNo);

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }
        public DataSet GetMembersExcelData()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                try
                {
                    SqlCommand cmdsrc = new SqlCommand("Pr_GetMembersExcelData", con);
                    cmdsrc.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    // General.LogerrorDB(ex, "DB");
                    throw ex;

                }
                finally
                {
                    con.Close();
                }
            }
        }


    }
}
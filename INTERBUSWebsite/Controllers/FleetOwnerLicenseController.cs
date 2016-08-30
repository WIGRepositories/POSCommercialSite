using INTERBUSWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace INTERBUSWebsite.Controllers
{
    public class FleetOwnerLicenseController : ApiController
    {

        [HttpGet]
        public DataSet validatefleetowner(string fleetownercode)
        {
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ValidateFleetOwnerCode";
            cmd.Connection = conn;

            //conn.Open();
            SqlParameter code = new SqlParameter("@fleetownercode", SqlDbType.VarChar, 10);
            code.Value = fleetownercode;
            cmd.Parameters.Add(code);

            SqlParameter mm = new SqlParameter("@result", SqlDbType.Int);
            mm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(mm);

             DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);

            int result = -1;
            result = Convert.ToInt32(mm.Value);

            DataTable dt = new DataTable();
            dt.Columns.Add("result");
            DataRow dr = dt.NewRow();
            dr[0] = result;

            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
           
            return ds;

        }


        [HttpGet]
        public int updatebtpos(string fleetownercode, string units)
        {
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updatebtpos";
            cmd.Connection = conn;

            conn.Open();
            SqlParameter code = new SqlParameter("@fleetownercode", SqlDbType.VarChar, 10);
            code.Value = fleetownercode;
            cmd.Parameters.Add(code);

            SqlParameter posunits = new SqlParameter("@units", SqlDbType.Int);
            posunits.Value =  Convert.ToInt32(units);
            cmd.Parameters.Add(posunits);


            SqlParameter mm = new SqlParameter("@result", SqlDbType.Int);
            mm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(mm);

            cmd.ExecuteNonQuery();

            conn.Close();

            int result = -1;
            result = Convert.ToInt32(mm.Value);
            return result;

        }

        [HttpGet]
        public int registerpos(string fleetownercode, string ipconfig)
        {
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "registerbtpos";
                cmd.Connection = conn;

                conn.Open();
                SqlParameter code = new SqlParameter("@fleetownercode", SqlDbType.VarChar, 10);
                code.Value = fleetownercode.Trim();
                cmd.Parameters.Add(code);

                SqlParameter posunits = new SqlParameter("@ipconfig", SqlDbType.VarChar, 20);
                posunits.Value = ipconfig.Trim();
                cmd.Parameters.Add(posunits);


                SqlParameter mm = new SqlParameter("@result", SqlDbType.Int);
                mm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(mm);

                cmd.ExecuteNonQuery();

                conn.Close();

                int result = -1;
                result = Convert.ToInt32(mm.Value);
                return result;
            }
            catch {
                return -1;
            }
        }

       
        [HttpPost]
        [Route("api/FleetOwnerLicense/CreateNewFOR")]
        public DataTable CreateNewFOR(FleetOwnerRequest fleetOwnerRequest)
        {
            DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdFleetOwnerRequestDetails";
                cmd.Connection = conn;
                //conn.Open();    
         
                //User details
                SqlParameter FRFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                FRFirstName.Value = fleetOwnerRequest.FirstName;
                cmd.Parameters.Add(FRFirstName);

                SqlParameter FRMiddleName = new SqlParameter("@MiddleName", SqlDbType.VarChar, 50);
                FRMiddleName.Value = fleetOwnerRequest.MiddleName;
                cmd.Parameters.Add(FRMiddleName);

                SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                LastName.Value = fleetOwnerRequest.LastName;
                cmd.Parameters.Add(LastName);

                SqlParameter FREmailAddress = new SqlParameter("@EmailAddress", SqlDbType.VarChar, 50);
                FREmailAddress.Value = fleetOwnerRequest.EmailAddress;
                cmd.Parameters.Add(FREmailAddress);

                SqlParameter Gender = new SqlParameter("@Gender", SqlDbType.Int);
                Gender.Value = fleetOwnerRequest.Gender;
                cmd.Parameters.Add(Gender);

                SqlParameter PhoneNo = new SqlParameter("@PhoneNo", SqlDbType.VarChar, 20);
                PhoneNo.Value = fleetOwnerRequest.PhoneNo;
                cmd.Parameters.Add(PhoneNo);

                SqlParameter AltPhoneNo = new SqlParameter("@AltPhoneNo", SqlDbType.VarChar, 20);
                AltPhoneNo.Value = fleetOwnerRequest.AltPhoneNo;
                cmd.Parameters.Add(AltPhoneNo);

                SqlParameter Address = new SqlParameter("@Address", SqlDbType.VarChar, 15);
                Address.Value = fleetOwnerRequest.Address;
                cmd.Parameters.Add(Address);

                SqlParameter userPhoto = new SqlParameter("@userPhoto", SqlDbType.Int);
                userPhoto.Value = fleetOwnerRequest.userPhoto;
                cmd.Parameters.Add(userPhoto);
                            
                //Company details
                

                SqlParameter FRCompanyName = new SqlParameter("@CompanyName", SqlDbType.VarChar, 20);
                FRCompanyName.Value = fleetOwnerRequest.CompanyName;
                cmd.Parameters.Add(FRCompanyName);

                SqlParameter CmpEmailAddress = new SqlParameter("@CmpEmailAddress", SqlDbType.VarChar, 15);
                CmpEmailAddress.Value = fleetOwnerRequest.CmpEmailAddress;
                cmd.Parameters.Add(CmpEmailAddress);

                SqlParameter CmpAddress = new SqlParameter("@CmpAddress", SqlDbType.Int);
                CmpAddress.Value = fleetOwnerRequest.CmpAddress;
                cmd.Parameters.Add(CmpAddress);

                SqlParameter CmpAltAddress = new SqlParameter("@CmpAltAddress", SqlDbType.VarChar, 15);
                CmpAltAddress.Value = fleetOwnerRequest.CmpAltAddress;
                cmd.Parameters.Add(CmpAltAddress);

                SqlParameter FleetSize = new SqlParameter("@FleetSize", SqlDbType.Int);
                FleetSize.Value = fleetOwnerRequest.FleetSize;
                cmd.Parameters.Add(FleetSize); 

                SqlParameter StaffSize = new SqlParameter("@StaffSize", SqlDbType.VarChar, 50);
                StaffSize.Value = fleetOwnerRequest.StaffSize;
                cmd.Parameters.Add(StaffSize);

                SqlParameter Country = new SqlParameter("@Country", SqlDbType.VarChar, 50);
                Country.Value = fleetOwnerRequest.Country;
                cmd.Parameters.Add(Country);

                SqlParameter state = new SqlParameter("@state", SqlDbType.VarChar, 50);
                state.Value = fleetOwnerRequest.state;
                cmd.Parameters.Add(state);

                SqlParameter Code = new SqlParameter("@Code", SqlDbType.VarChar, 50);
                Code.Value = fleetOwnerRequest.Code;
                cmd.Parameters.Add(Code);

                SqlParameter CmpFax = new SqlParameter("@CmpFax", SqlDbType.VarChar, 50);
                CmpFax.Value = fleetOwnerRequest.CmpFax;
                cmd.Parameters.Add(CmpFax);

                SqlParameter CmpCaption = new SqlParameter("@CmpCaption", SqlDbType.VarChar, 50);
                CmpCaption.Value = fleetOwnerRequest.CmpCaption;
                cmd.Parameters.Add(CmpCaption);

                SqlParameter CmpTitle = new SqlParameter("@CmpTitle", SqlDbType.VarChar, 50);
                CmpTitle.Value = fleetOwnerRequest.CmpTitle;
                cmd.Parameters.Add(CmpTitle);


                SqlParameter CmpPhoneNo = new SqlParameter("@CmpPhoneNo", SqlDbType.VarChar, 50);
                CmpPhoneNo.Value = fleetOwnerRequest.CmpPhoneNo;
                cmd.Parameters.Add(CmpPhoneNo);

                SqlParameter CmpAltPhoneNo = new SqlParameter("@CmpAltPhoneNo", SqlDbType.VarChar, 50);
                CmpAltPhoneNo.Value = fleetOwnerRequest.CmpAltPhoneNo;
                cmd.Parameters.Add(CmpAltPhoneNo);

                SqlParameter ZipCode = new SqlParameter("@ZipCode", SqlDbType.VarChar, 50);
                ZipCode.Value = fleetOwnerRequest.ZipCode;
                cmd.Parameters.Add(ZipCode);

                SqlParameter CmpLogo = new SqlParameter("@CmpLogo", SqlDbType.VarChar, 50);
                CmpLogo.Value = fleetOwnerRequest.CmpLogo;
                cmd.Parameters.Add(CmpLogo);

                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                insupdflag.Value = fleetOwnerRequest.insupdflag;
                cmd.Parameters.Add(insupdflag);
                
               //General details                     

                SqlParameter CurrentSystemInUse = new SqlParameter("@CurrentSystemInUse", SqlDbType.VarChar, 50);
                CurrentSystemInUse.Value = fleetOwnerRequest.CurrentSystemInUse;
                cmd.Parameters.Add(CurrentSystemInUse);

                SqlParameter SentNewProductsEmails = new SqlParameter("@SentNewProductsEmails", SqlDbType.Int);
                SentNewProductsEmails.Value = fleetOwnerRequest.SentNewProductsEmails;
                cmd.Parameters.Add(SentNewProductsEmails);

                SqlParameter howdidyouhearaboutus = new SqlParameter("@howdidyouhearaboutus", SqlDbType.VarChar, 50);
                howdidyouhearaboutus.Value = fleetOwnerRequest.howdidyouhearaboutus;
                cmd.Parameters.Add(howdidyouhearaboutus);

                SqlParameter Agreetotermsandconditions = new SqlParameter("@Agreetotermsandconditions", SqlDbType.Int);
                Agreetotermsandconditions.Value = fleetOwnerRequest.Agreetotermsandconditions;
                cmd.Parameters.Add(Agreetotermsandconditions);
                               

               // cmd.ExecuteScalar();
               // conn.Close();
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(Tbl);
                return Tbl;
            }
              
            catch (Exception ex)
            {
               
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw (ex);
                //string str = ex.Message;
                //Tbl.Columns.Add("status");
                //Tbl.Columns.Add("details");
                //Tbl.Rows.Add(new string[]{"0",ex.Message});

                //string str = ex.Message;
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);

            }
            // int found = 0;
            return Tbl;
        }
       
        public void Options()
        {

        }

    }
}

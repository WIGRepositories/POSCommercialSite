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
        public DataTable CreateNewFO(FleetOwnerRequest C)
        {
            DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InSupdFleetOwnerRequest1";
                cmd.Connection = conn;
                conn.Open();


                 SqlParameter UId = new SqlParameter("Id", SqlDbType.Int);
                 UId.Value = C.Id;
                 cmd.Parameters.Add(UId);

                SqlParameter UFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                UFirstName.Value = C.FirstName;
                cmd.Parameters.Add(UFirstName);

                SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                LastName.Value = C.LastName;
                cmd.Parameters.Add(LastName);

                SqlParameter UEmail = new SqlParameter("@Email", SqlDbType.VarChar, 15);
                UEmail.Value = C.Email;
                cmd.Parameters.Add(UEmail);

                SqlParameter UMobileNo = new SqlParameter("@MobileNo", SqlDbType.VarChar, 15);
                UMobileNo.Value = C.MobileNo;
                cmd.Parameters.Add(UMobileNo);

                SqlParameter CCompanyName = new SqlParameter("@CompanyName", SqlDbType.VarChar, 15);
                CCompanyName.Value = C.CompanyName;
                cmd.Parameters.Add(CCompanyName);

                SqlParameter Description = new SqlParameter("@Description", SqlDbType.VarChar, 15);
                Description.Value = C.Description;
                cmd.Parameters.Add(Description);              

                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                insupdflag.Value = C.insupdflag;
                cmd.Parameters.Add(insupdflag);


                cmd.ExecuteScalar();

                cmd.Parameters.Clear();   
            }
            catch (Exception ex)
            {
                conn.Close();
                string str = ex.Message;
            }
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        [Route("api/FleetOwnerLicense/CreateNewFOR")]
        public DataTable CreateNewFOR(FleetOwnerRequest1 FR)
        {
            DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InSupdFleetOwnerRequestDetails";
                cmd.Connection = conn;
                conn.Open();


                //SqlParameter FRId = new SqlParameter("Id", SqlDbType.Int);
                //FRId.Value = FR.Id;
                //cmd.Parameters.Add(FRId);

                SqlParameter FRFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                FRFirstName.Value = FR.FirstName;
                cmd.Parameters.Add(FRFirstName);

                SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                LastName.Value = FR.LastName;
                cmd.Parameters.Add(LastName);

                SqlParameter FREmailAddress = new SqlParameter("@EmailAddress", SqlDbType.VarChar, 50);
                FREmailAddress.Value = FR.EmailAddress;
                cmd.Parameters.Add(FREmailAddress);

                SqlParameter FRTitle = new SqlParameter("@Title", SqlDbType.VarChar, 20);
                FRTitle.Value = FR.Title;
                cmd.Parameters.Add(FRTitle);

                SqlParameter FRCompanyName = new SqlParameter("@CompanyName", SqlDbType.VarChar, 20);
                FRCompanyName.Value = FR.CompanyName;
                cmd.Parameters.Add(FRCompanyName);

                SqlParameter Description = new SqlParameter("@Description", SqlDbType.VarChar, 15);
                Description.Value = FR.Description;
                cmd.Parameters.Add(Description);

                SqlParameter CompanyEmployeSize = new SqlParameter("@CompanyEmployeSize", SqlDbType.Int);
                CompanyEmployeSize.Value = FR.CompanyEmployeSize;
                cmd.Parameters.Add(CompanyEmployeSize);

                SqlParameter FleetSize = new SqlParameter("@FleetSize", SqlDbType.Int);
                FleetSize.Value = FR.FleetSize;
                cmd.Parameters.Add(FleetSize);               

                SqlParameter Gender = new SqlParameter("@Gender", SqlDbType.Int);
                Gender.Value = FR.Gender;
                cmd.Parameters.Add(Gender);            


                SqlParameter Address = new SqlParameter("@Address", SqlDbType.VarChar, 15);
                Address.Value = FR.Address;
                cmd.Parameters.Add(Address);

                SqlParameter PhoneNo = new SqlParameter("@PhoneNo", SqlDbType.VarChar,50);
                PhoneNo.Value = FR.PhoneNo;
                cmd.Parameters.Add(PhoneNo);

                SqlParameter StaffSize = new SqlParameter("@StaffSize", SqlDbType.VarChar, 50);
                StaffSize.Value = FR.StaffSize;
                cmd.Parameters.Add(StaffSize);

                SqlParameter Country = new SqlParameter("@Country", SqlDbType.VarChar, 50);
                Country.Value = FR.Country;
                cmd.Parameters.Add(Country);

                SqlParameter Code = new SqlParameter("@Code", SqlDbType.VarChar, 50);
                Code.Value = FR.Code;
                cmd.Parameters.Add(Code);

                SqlParameter Fax = new SqlParameter("@Fax", SqlDbType.VarChar, 50);
                Fax.Value = FR.Fax;
                cmd.Parameters.Add(Fax);

                SqlParameter PermanentAddress = new SqlParameter("@PermanentAddress", SqlDbType.VarChar, 50);
                PermanentAddress.Value = FR.PermanentAddress;
                cmd.Parameters.Add(PermanentAddress);

                SqlParameter TemporaryAddres = new SqlParameter("@TemporaryAddres", SqlDbType.VarChar, 50);
                TemporaryAddres.Value = FR.TemporaryAddres;
                cmd.Parameters.Add(TemporaryAddres);

                SqlParameter state = new SqlParameter("@state", SqlDbType.VarChar, 50);
                state.Value = FR.state;
                cmd.Parameters.Add(state);
            



                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                insupdflag.Value = FR.insupdflag;
                cmd.Parameters.Add(insupdflag);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Tbl);
               
                // cmd.ExecuteScalar();
               // conn.Close();


                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
               // conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "InSupdFleetOwnerRequest";
                cmd1.Connection = conn;
              //  conn.Open();
               

                SqlParameter CurrentSystemInUse = new SqlParameter("@CurrentSystemInUse", SqlDbType.VarChar, 50);
                CurrentSystemInUse.Value = FR.CurrentSystemInUse;
                cmd1.Parameters.Add(CurrentSystemInUse);

                SqlParameter SentNewProductsEmails = new SqlParameter("@SentNewProductsEmails", SqlDbType.Int);
                SentNewProductsEmails.Value = FR.SentNewProductsEmails;
                cmd1.Parameters.Add(SentNewProductsEmails);

                SqlParameter howdidyouhearaboutus = new SqlParameter("@howdidyouhearaboutus", SqlDbType.VarChar, 50);
                howdidyouhearaboutus.Value = FR.howdidyouhearaboutus;
                cmd1.Parameters.Add(howdidyouhearaboutus);

                SqlParameter Agreetotermsandconditions = new SqlParameter("@Agreetotermsandconditions", SqlDbType.Int);
                Agreetotermsandconditions.Value = FR.Agreetotermsandconditions;
                cmd1.Parameters.Add(Agreetotermsandconditions);

                SqlParameter insupdflag1 = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                insupdflag1.Value = FR.insupdflag;
                cmd1.Parameters.Add(insupdflag1);

                cmd1.ExecuteScalar();
                conn.Close();
                

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

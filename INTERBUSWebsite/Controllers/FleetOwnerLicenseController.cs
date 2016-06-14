using BTPOSDashboardAPI.Models;

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
        //[HttpGet]
        //public DataTable FleetOwner()//Main Method
        //{
        //    DataTable Tbl = new DataTable();
        //    //connect to database
        //    SqlConnection conn = new SqlConnection();
        //    //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
        //    //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
        //    cmd.CommandText = "GetFleetOwnerLicense";
        //    cmd.Connection = conn;
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter db = new SqlDataAdapter(cmd);
        //    db.Fill(ds);
        //    Tbl = ds.Tables[0];

        //    // int found = 0;
        //    return Tbl;
        //}
        //[HttpPost]
        //public DataTable FleetOL(FleetOL B)
        //{
        //    DataTable Tbl = new DataTable();
        //    try
        //    {

        //        //connect to database
        //        SqlConnection conn = new SqlConnection();
        //        //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
        //        //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "insFleetOwnerLicense";
        //        cmd.Connection = conn;
        //        conn.Open();
        //        SqlParameter FId = new SqlParameter();
        //        FId.ParameterName = "@Id";
        //        FId.SqlDbType = SqlDbType.Int;
        //        FId.Value = Convert.ToString(B.Id);
        //        cmd.Parameters.Add(FId);
        //        SqlParameter FFleetOwnerId = new SqlParameter();
        //        FFleetOwnerId.ParameterName = "@FleetOwnerId";
        //        FFleetOwnerId.SqlDbType = SqlDbType.Int;
        //        FFleetOwnerId.Value = Convert.ToString(B.FleetOwnerId);
        //        cmd.Parameters.Add(FFleetOwnerId);
        //        SqlParameter FlicenseId = new SqlParameter();
        //        FlicenseId.ParameterName = "@LicenseId";
        //        FlicenseId.SqlDbType = SqlDbType.Int;
        //        FlicenseId.Value = B.LicenseId;
        //        cmd.Parameters.Add(FlicenseId);
        //        SqlParameter FCode = new SqlParameter();
        //        FCode.ParameterName = "@Code";
        //        FCode.SqlDbType = SqlDbType.Int;
        //        FCode.Value =Convert.ToString( B.Code);
        //        cmd.Parameters.Add(FCode);
        //        SqlParameter FOFromDate = new SqlParameter();
        //        FOFromDate.ParameterName = "@FromDate";
        //        FOFromDate.SqlDbType = SqlDbType.DateTime;
        //        FOFromDate.Value = B.FromDate;
        //        cmd.Parameters.Add(FOFromDate);
        //        SqlParameter FOEndDate = new SqlParameter();
        //        FOEndDate.ParameterName = "@EndDate";
        //        FOEndDate.SqlDbType = SqlDbType.DateTime;
        //        FOEndDate.Value = B.EndDate;
        //        cmd.Parameters.Add(FOEndDate);
        //        SqlParameter FONotificationDate = new SqlParameter();
        //        FONotificationDate.ParameterName = "@NotificationDate";
        //        FONotificationDate.SqlDbType = SqlDbType.DateTime;
        //        FONotificationDate.Value = B.NotificationDate;
        //        cmd.Parameters.Add(FONotificationDate);
        //        SqlParameter FTransactionId = new SqlParameter();
        //        FTransactionId.ParameterName = "@TransactionId";
        //        FTransactionId.SqlDbType = SqlDbType.Int;
        //        FTransactionId.Value = Convert.ToString(B.TransactionId);
        //        cmd.Parameters.Add(FTransactionId);
        //        SqlParameter FRenewedOn = new SqlParameter();
        //        FRenewedOn.ParameterName = "@RenewedOn ";
        //        FRenewedOn.SqlDbType = SqlDbType.DateTime;
        //        FRenewedOn.Value = B.RenewedOn;
        //        cmd.Parameters.Add(FRenewedOn);

        //        cmd.ExecuteScalar();
        //        conn.Close();

        //        //DataSet ds = new DataSet();
        //        //SqlDataAdapter db = new SqlDataAdapter(cmd);
        //        // db.Fill(ds);
        //        // Tbl = ds.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        string str = ex.Message;
        //    }
        //    // int found = 0;
        //    return Tbl;
        //}

        [HttpGet]
        public int validatefleetowner(string fleetownercode)
        {
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ValidateFleetOwnerCode";
            cmd.Connection = conn;

            conn.Open();
            SqlParameter code = new SqlParameter("@fleetownercode", SqlDbType.VarChar, 10);
            code.Value = fleetownercode;
            cmd.Parameters.Add(code);

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
                cmd.CommandText = "InsupdCreateFleetOwner";
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
                cmd.CommandText = "InsFleetOwnerRequest";
                cmd.Connection = conn;
                conn.Open();


                SqlParameter FRId = new SqlParameter("Id", SqlDbType.Int);
                FRId.Value = FR.Id;
                cmd.Parameters.Add(FRId);

                SqlParameter FRFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                FRFirstName.Value = FR.FirstName;
                cmd.Parameters.Add(FRFirstName);

                SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                LastName.Value = FR.LastName;
                cmd.Parameters.Add(LastName);

                SqlParameter FREmailAdress = new SqlParameter("@EmailAdress ", SqlDbType.VarChar, 50);
                FREmailAdress.Value = FR.EmailAdress;
                cmd.Parameters.Add(FREmailAdress);

                SqlParameter FRTitle = new SqlParameter("@Title", SqlDbType.VarChar, 20);
                FRTitle.Value = FR.Title;
                cmd.Parameters.Add(FRTitle);

                SqlParameter FRCompanyName = new SqlParameter("@CompanyName", SqlDbType.VarChar, 15);
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

                SqlParameter CurrentSystemInUse = new SqlParameter("@CurrentSystemInUse", SqlDbType.VarChar, 15);
                CurrentSystemInUse.Value = FR.CurrentSystemInUse;
                cmd.Parameters.Add(CurrentSystemInUse);

                SqlParameter SentNewProductsEmails = new SqlParameter("@SentNewProductsEmails", SqlDbType.VarChar, 15);
                SentNewProductsEmails.Value = FR.SentNewProductsEmails;
                cmd.Parameters.Add(SentNewProductsEmails);

                SqlParameter Gender = new SqlParameter("@Gender", SqlDbType.VarChar, 20);
                Gender.Value = FR.Gender;
                cmd.Parameters.Add(Gender);

                SqlParameter howdidyouhearaboutus = new SqlParameter("@howdidyouhearaboutus", SqlDbType.VarChar, 50);
                howdidyouhearaboutus.Value = FR.howdidyouhearaboutus;
                cmd.Parameters.Add(howdidyouhearaboutus);

                SqlParameter Agreetotermsandconditions = new SqlParameter("@Agreetotermsandconditions", SqlDbType.Int);
                Agreetotermsandconditions.Value = FR.Agreetotermsandconditions;
                cmd.Parameters.Add(Agreetotermsandconditions);


                SqlParameter Address = new SqlParameter("@Address", SqlDbType.VarChar, 15);
                Address.Value = FR.Address;
                cmd.Parameters.Add(Address);

               
                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                insupdflag.Value = FR.insupdflag;
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

        public void Options()
        {

        }

    }
}

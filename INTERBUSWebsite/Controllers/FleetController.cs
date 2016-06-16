using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTPOSDashboardAPI.Models;

namespace INTERBUSWebsite.Controllers
{
    public class FleetController : ApiController
    {
        [HttpPost]
        [Route("api/Fleet/CreateNewFOR1")]
        public DataTable CreateNewFOR1(Fleet FR)
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
                cmd.CommandText = "InSupdFleetOwnerRequest3";
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

                SqlParameter FREmailAddress = new SqlParameter("@EmailAddress ", SqlDbType.VarChar, 50);
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

                SqlParameter PhoneNo = new SqlParameter("@PhoneNo", SqlDbType.VarChar, 50);
                PhoneNo.Value = FR.PhoneNo;
                cmd.Parameters.Add(PhoneNo);


              

                cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                conn.Close();

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "InSupdFleetOwnerRequest2";
                cmd1.Connection = conn;
                conn.Open();

                SqlParameter Agreetotermsandconditions = new SqlParameter("@Agreetotermsandconditions", SqlDbType.Int);
                Agreetotermsandconditions.Value = FR.Agreetotermsandconditions;
                cmd1.Parameters.Add(Agreetotermsandconditions);

                SqlParameter SentNewProductsEmails = new SqlParameter("@SentNewProductsEmails", SqlDbType.Int);
                SentNewProductsEmails.Value = FR.SentNewProductsEmails;
                cmd1.Parameters.Add(SentNewProductsEmails);

                SqlParameter CurrentSystemInUse = new SqlParameter("@CurrentSystemInUse", SqlDbType.VarChar, 50);
                CurrentSystemInUse.Value = FR.CurrentSystemInUse;
                cmd1.Parameters.Add(CurrentSystemInUse);

                SqlParameter howdidyouhearaboutus = new SqlParameter("@howdidyouhearaboutus", SqlDbType.VarChar, 50);
                howdidyouhearaboutus.Value = FR.howdidyouhearaboutus;
                cmd1.Parameters.Add(howdidyouhearaboutus);

                

                cmd1.ExecuteScalar();
                cmd1.Parameters.Clear();

            }
            catch (Exception ex)
            {
                conn.Close();
                string str = ex.Message;
            }
            // int found = 0;
            return Tbl;
        }
    }
}

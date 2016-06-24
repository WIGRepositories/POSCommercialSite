﻿using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace INTERBUSWebsite.Controllers
{
    public class FleetOwnerReqController : ApiController
    {

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

                conn.Close();

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

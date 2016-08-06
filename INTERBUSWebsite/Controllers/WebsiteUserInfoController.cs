﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INTERBUSWebsite.Controllers
{
    public class WebsiteUserInfoController : ApiController
    {
        [HttpGet]

        public DataTable GetWebsiteUserInfo()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetWebsiteUserInfo";
            cmd.Connection = conn;

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;



        }
         [HttpPost]
        public HttpResponseMessage pos(WebsiteUserInfo b)
        {

            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdWebsiteUserInfo";
                cmd.Connection = conn;
                conn.Open();
                //string insertquery = "insert into login(UserName,Password,FirstName,LastName,MobileNo) values (@UserName,@Password,@FirstName,@lastName,@MobileNo)";



                //SqlCommand con=new SqlCommand(insertquery,conn);
                SqlParameter pid = new SqlParameter();
                pid.ParameterName = "@FirstName ";
                pid.SqlDbType = SqlDbType.VarChar;
                pid.Value = b.FirstName;
                cmd.Parameters.Add(pid);

                SqlParameter aa = new SqlParameter();
                aa.ParameterName = "@LastName";
                aa.SqlDbType = SqlDbType.VarChar;
                aa.Value = b.LastName;
                cmd.Parameters.Add(aa);

                SqlParameter Aid = new SqlParameter();
                Aid.ParameterName = "@UserName";
                Aid.SqlDbType = SqlDbType.VarChar;
                Aid.Value = b.UserName;
                cmd.Parameters.Add(Aid);

                SqlParameter lid = new SqlParameter();
                lid.ParameterName = "@Password";
                lid.SqlDbType = SqlDbType.VarChar;
                lid.Value = b.Password;
                cmd.Parameters.Add(lid);
              

                SqlParameter Gid = new SqlParameter();
                Gid.ParameterName = "@EmailAddress";
                Gid.SqlDbType = SqlDbType.VarChar;
                Gid.Value = b.EmailAddress;
                cmd.Parameters.Add(Gid);

                                             

                SqlParameter aa1 = new SqlParameter();
                aa1.ParameterName = "@Mobile";
                aa1.SqlDbType = SqlDbType.VarChar;
                aa1.Value = b.Mobile;
                cmd.Parameters.Add(aa1);




                cmd.ExecuteScalar();
                conn.Close();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
        public void Options()
        {


        }


    }     
   
}

   


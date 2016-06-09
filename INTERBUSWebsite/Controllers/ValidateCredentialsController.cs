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
    public class ValidateCredentialsController : ApiController
    {


        [HttpPost]
        [Route("api/ValidateCredentials/ValidateCredentials")]
        public DataTable ValidateCredentials(UserLogin u)
        {
            DataTable Tbl = new DataTable();

            string username = u.LoginInfo;
            string pwd = u.Passkey;

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.WebsiteValidateCredentials";

            cmd.Connection = conn;

            SqlParameter lUserName = new SqlParameter("@logininfo", SqlDbType.VarChar, 50);
            lUserName.Value = username;
            lUserName.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(lUserName);


            SqlParameter lPassword = new SqlParameter("@passkey", SqlDbType.VarChar, 50);
            lPassword.Value = pwd;
            lPassword.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(lPassword);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Tbl);

            return Tbl;


        }
        public void Options() { }

   
    
    
   
    
   
  [HttpPost]
  [Route("api/ValidateCredentials/savepassword")]
          public DataTable savepassword(reset b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdwebsiteresetpassword";
            cmd.Connection = conn;
            conn.Open();
       

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@UserName";
            Gid.SqlDbType = SqlDbType.VarChar;
            Gid.Value = b.UserName;
            cmd.Parameters.Add(Gid);


            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@OldPassword";
            pid.SqlDbType = SqlDbType.VarChar;
            pid.Value = b.OldPassword;
            cmd.Parameters.Add(pid);

            
          
            SqlParameter gid = new SqlParameter();
            gid.ParameterName = "@ReenterNewPassword";
            gid.SqlDbType = SqlDbType.VarChar;
            gid.Value = b.ReenterNewPassword;
            cmd.Parameters.Add(gid);

            SqlParameter oid = new SqlParameter();
            
            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
           // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            // int found = 0;
            return Tbl;
        }
  

    }
    }

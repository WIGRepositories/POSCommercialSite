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
    public class UserInfoController : ApiController
    {
         [HttpPost]
          public DataTable saveUserInfo(UserIn b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdWebsiteUserInfo";
            cmd.Connection = conn;
            conn.Open();
       

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@FirstName";
            Gid.SqlDbType = SqlDbType.VarChar;
            Gid.Value = b.FirstName;
            cmd.Parameters.Add(Gid);


            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@LastName";
            pid.SqlDbType = SqlDbType.VarChar;
            pid.Value = b.LastName;
            cmd.Parameters.Add(pid);

            
            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@UserName";
            lid.SqlDbType = SqlDbType.VarChar;
            lid.Value = b.UserName;
            cmd.Parameters.Add(lid);

            SqlParameter gid = new SqlParameter();
            gid.ParameterName = "@Password";
            gid.SqlDbType = SqlDbType.VarChar;
            gid.Value = b.Password;
            cmd.Parameters.Add(gid);

            SqlParameter oid = new SqlParameter();
            oid.ParameterName = "@EmailAddress";
            oid.SqlDbType = SqlDbType.VarChar;
            oid.Value = b.EmailAddress;
            cmd.Parameters.Add(oid);
            
             SqlParameter rid = new SqlParameter();
            rid.ParameterName = "@ConfirmPassword";
            rid.SqlDbType = SqlDbType.VarChar;
            rid.Value = b.ConfirmPassword;
            cmd.Parameters.Add(rid);

             SqlParameter wid = new SqlParameter();
            wid.ParameterName = "@Gender";
            wid.SqlDbType = SqlDbType.VarChar;
            wid.Value = b.Gender;
             cmd.Parameters.Add(wid);

             SqlParameter salt = new SqlParameter();
             salt.ParameterName = "@salt";
             salt.SqlDbType = SqlDbType.VarChar;
             salt.Value = b.salt;
             cmd.Parameters.Add(salt);

            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
           // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            // int found = 0;
            return Tbl;
        }
        public void Options() { }

    }
    }


  
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
    public class resetpasswordController : ApiController
    {
        [HttpGet]

        public DataTable GetResetPassword()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetResetPassword";
            cmd.Connection = conn;

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;



        }

        [HttpPost]
        public HttpResponseMessage pos(ResetPassword b)
        {

            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelResetPassword";
                cmd.Connection = conn;
                conn.Open();
                //string insertquery = "insert into login(UserName,Password,FirstName,LastName,MobileNo) values (@UserName,@Password,@FirstName,@lastName,@MobileNo)";



                //SqlCommand con=new SqlCommand(insertquery,conn);
                SqlParameter usn = new SqlParameter();
                usn.ParameterName = "@UserName ";
                usn.SqlDbType = SqlDbType.VarChar;
                usn.Value = b.UserName;
                cmd.Parameters.Add(usn);

                SqlParameter oldpsw = new SqlParameter();
                oldpsw.ParameterName = "@OldPassword";
                oldpsw.SqlDbType = SqlDbType.VarChar;
                oldpsw.Value = b.LastName;
                cmd.Parameters.Add(oldpsw);

                SqlParameter npsw = new SqlParameter();
                npsw.ParameterName = "@NewPassword";
                npsw.SqlDbType = SqlDbType.VarChar;
                npsw.Value = b.NewPassword;
                npsw.Parameters.Add(npsw);

                SqlParameter repsw = new SqlParameter();
                repsw.ParameterName = "@ReEnterNewPassword";
                repsw.SqlDbType = SqlDbType.VarChar;
                repsw.Value = b.ReEnterNewPassword;
                repsw.Parameters.Add(repsw);
                
             
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
    

  
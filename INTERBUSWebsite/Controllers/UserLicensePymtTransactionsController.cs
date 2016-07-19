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
    public class UserLicensePymtTransactionsController : ApiController
    {
        [HttpGet]

        public DataTable UserLicensePymtT()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUserLicensePymtTransactions";
            cmd.Connection = conn;

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;



        }

        [HttpPost]
        public HttpResponseMessage SaveType(UserLicensePymtTransactions b)
        {

            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelUserLicensePymtTransactions";
                cmd.Connection = conn;
                conn.Open();

       
                //SqlParameter Cid = new SqlParameter();
                //Cid.ParameterName = "@Id";
                //Cid.SqlDbType = SqlDbType.Int;
                //Cid.Value = Convert.ToInt32(b.Id);
                //cmd.Parameters.Add(Cid);

                SqlParameter Gid = new SqlParameter();
                Gid.ParameterName = "@TransId";
                Gid.SqlDbType = SqlDbType.VarChar;
                Gid.Value = b.TransId;
                cmd.Parameters.Add(Gid);
              
                SqlParameter cid = new SqlParameter();
                cid.ParameterName = "@GatewayTransId";
                cid.SqlDbType = SqlDbType.VarChar;
                cid.Value = b.GatewayTransId;
                cmd.Parameters.Add(cid);
               
                SqlParameter tid = new SqlParameter();
                tid.ParameterName = "@Desc";
                tid.SqlDbType = SqlDbType.VarChar;
                tid.Value = b.Desc;
                cmd.Parameters.Add(tid);
                 
                SqlParameter fid = new SqlParameter();
                fid.ParameterName = "@ULPymtId";
                fid.SqlDbType = SqlDbType.Int;
                fid.Value = b.ULPymtId;
                cmd.Parameters.Add(fid); 
                
                SqlParameter rid = new SqlParameter();
                rid.ParameterName = "@StatusId";
                rid.SqlDbType = SqlDbType.Int;
                rid.Value = b.StatusId;
                cmd.Parameters.Add(rid);   
               
                SqlParameter hid = new SqlParameter();
                hid.ParameterName = "@Amount";
                hid.SqlDbType = SqlDbType.Decimal;
                hid.Value = b.Amount;
                cmd.Parameters.Add(hid);
                 
     
                SqlParameter pDesc = new SqlParameter();
                pDesc.ParameterName = "@TransDate";
                pDesc.SqlDbType = SqlDbType.DateTime;
                pDesc.Value = b.TransDate;
                cmd.Parameters.Add(pDesc);


              

               


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
        public void Options() { }

    }
}


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
    public class ULFeaturesController : ApiController
    {
         [HttpGet]

        public DataTable ULFeaturess()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetULFeatures";
            cmd.Connection = conn;

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;



        }

        [HttpPost]
         public HttpResponseMessage SaveType(ULFeatures b)
        {

            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdTypes";
                cmd.Connection = conn;
                conn.Open();
                
	

                //SqlParameter Cid = new SqlParameter();
                //Cid.ParameterName = "@Id";
                //Cid.SqlDbType = SqlDbType.Int;
                //Cid.Value = Convert.ToInt32(b.Id);
                //cmd.Parameters.Add(Cid);
                
                SqlParameter fid = new SqlParameter();
                fid.ParameterName = "@ULPymtId";
                fid.SqlDbType = SqlDbType.Int;
                fid.Value = Convert.ToInt32(b.ULPymtId);
                cmd.Parameters.Add(fid);
                
                SqlParameter rid = new SqlParameter();
                rid.ParameterName = "@FeatureId";
                rid.SqlDbType = SqlDbType.Int;
                rid.Value = Convert.ToInt32(b.FeatureId);
                cmd.Parameters.Add(rid);
                
                SqlParameter tid = new SqlParameter();
                tid.ParameterName = "@FeatureValue";
                tid.SqlDbType = SqlDbType.VarChar;
                tid.Value = b.FeatureValue;
                cmd.Parameters.Add(tid);

                SqlParameter wid = new SqlParameter();
                wid.ParameterName = "@FeatureDesc";
                wid.SqlDbType = SqlDbType.VarChar;
                wid.Value = b.FeatureDesc;
                cmd.Parameters.Add(wid);
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


   
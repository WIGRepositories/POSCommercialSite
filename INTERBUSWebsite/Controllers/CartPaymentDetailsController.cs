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
    public class CartPaymentDetailsController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage SaveType(CartDetails processPymt1)
        {
           
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsupdCartPaymentDetails";
            cmd.Connection = conn;
            conn.Open();

            SqlParameter qid = new SqlParameter();
            qid.ParameterName = "@LicenseType";
            qid.SqlDbType = SqlDbType.VarChar;
            qid.Value = processPymt1.LicenseType;
            cmd.Parameters.Add(qid);

            SqlParameter Cid = new SqlParameter();
            Cid.ParameterName = "@Frequency";
            Cid.SqlDbType = SqlDbType.Int;
            Cid.Value = Convert.ToInt32(processPymt1.Frequency);
            cmd.Parameters.Add(Cid);

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@NoOfMonths";
            Gid.SqlDbType = SqlDbType.VarChar;
            Gid.Value = processPymt1.NoOfMonths;
            cmd.Parameters.Add(Gid);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@TotalAmount";
            lid.SqlDbType = SqlDbType.Int;
            lid.Value = Convert.ToInt32(processPymt1.TotalAmount);
            cmd.Parameters.Add(lid);
               
               
            SqlParameter pDesc = new SqlParameter();
            pDesc.ParameterName = "@CreateDate";
            pDesc.SqlDbType = SqlDbType.DateTime;
            pDesc.Value = processPymt1.CreateDate;
            cmd.Parameters.Add(pDesc);

            SqlParameter sid = new SqlParameter();
            sid.ParameterName = "@TransId ";
            sid.SqlDbType = SqlDbType.VarChar;
            sid.Value = processPymt1.TransId ;
            cmd.Parameters.Add(sid);

            SqlParameter llid = new SqlParameter();
            llid.ParameterName = "@UnitPrice";
            llid.SqlDbType = SqlDbType.Int;
            llid.Value = Convert.ToInt32(processPymt1.UnitPrice);
            cmd.Parameters.Add(llid);

            SqlParameter fid = new SqlParameter();
            fid.ParameterName = "@FleetOwner";
            fid.SqlDbType = SqlDbType.VarChar;
            fid.Value = processPymt1.FleetOwner;
            cmd.Parameters.Add(fid);
            
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







    
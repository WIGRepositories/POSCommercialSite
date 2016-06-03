using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KESENENI2.Controllers
{
    public class TicketBookingController : ApiController
    {
          [HttpGet]

        public DataTable GetAvailableServices(int srcId, int destId)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = "Getsp_Availableseats";
              cmd.Parameters.Add("Src_Id", SqlDbType.Int).Value = srcId;
              cmd.Parameters.Add("Des_Id", SqlDbType.Int).Value = destId;
            cmd.Connection = conn;
          
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;

        }

    }
}

  
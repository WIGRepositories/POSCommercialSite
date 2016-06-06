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
    public class TicketBookingController : ApiController
    {

        [HttpGet]

        public Booking TestServices()
        {
            Booking b = new Booking();
           
            passengerDetails d1 = new passengerDetails();
            d1.Fname = "Lokesh";
            d1.Lname = "Godem";
            d1.Age = 24;
            d1.Sex = 1;
            d1.Identityproof = "Pan";
            d1.SeatId = "5";


            passengerDetails d2 = new passengerDetails();
            d1.Fname = "Lokesh1";
            d1.Lname = "Godem1";
            d1.Age = 25;
            d1.Sex = 1;
            d1.Identityproof = "Adr";
            d1.SeatId = "6";
   

            b.passengersList = new List<passengerDetails> {d1, d2};
            return b;
        }
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

    [HttpPost]
          public DataTable SaveBookingDetails(Booking B)
          {

              DataTable Tbl = new DataTable();
              SqlConnection conn = new SqlConnection();
              //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
              conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

              SqlCommand PnrDeatilscmd = new SqlCommand();
              PnrDeatilscmd.CommandType = CommandType.StoredProcedure;
              PnrDeatilscmd.CommandText = "sp_InsPnrDetails";
              PnrDeatilscmd.Connection = conn;
              conn.Open();

              int LastPnrID;
              string Pnr_Gen_No = "PNR" + Guid.NewGuid().ToString().Substring(0, 6);

            SqlParameter LastInsPnrID = new SqlParameter("@LastInsPnrID", SqlDbType.Int);
            LastInsPnrID.Direction = ParameterDirection.Output;
              PnrDeatilscmd.Parameters.Add(LastInsPnrID);

              //SqlParameter PnrGenNo = new SqlParameter("@PnrGenNo", SqlDbType.Int);
              //PnrDeatilscmd.Parameters.Add(PnrGenNo);

              SqlParameter Pnr_No = new SqlParameter("Pnr_No", SqlDbType.VarChar, 20);
              Pnr_No.Value = Pnr_Gen_No;
              PnrDeatilscmd.Parameters.Add(Pnr_No);

              SqlParameter No_Seats = new SqlParameter("No_Seats", SqlDbType.Int);
              No_Seats.Value = B.No_Seats;
              PnrDeatilscmd.Parameters.Add(No_Seats);

              SqlParameter cost = new SqlParameter("cost", SqlDbType.Int);
              cost.Value = B.cost;
              PnrDeatilscmd.Parameters.Add(cost);


              DateTime dt = DateTime.Now;
              String strDate = "";
              strDate = dt.ToString("MM/dd/yyyy");   

              SqlParameter dateandtime = new SqlParameter("dateandtime", SqlDbType.VarChar, 30);
              dateandtime.Value = strDate;
              PnrDeatilscmd.Parameters.Add(dateandtime);

              SqlParameter src = new SqlParameter("src", SqlDbType.VarChar, 30);
              src.Value = B.src;
              PnrDeatilscmd.Parameters.Add(src);

              SqlParameter dest = new SqlParameter("dest", SqlDbType.VarChar, 30);
              dest.Value = B.dest;
              PnrDeatilscmd.Parameters.Add(dest);

              SqlParameter vehicle_No = new SqlParameter("vehicle_No", SqlDbType.VarChar, 20);
              vehicle_No.Value = B.vehicle_No;
              PnrDeatilscmd.Parameters.Add(vehicle_No);

              SqlParameter JourneyDate = new SqlParameter("JourneyDate", SqlDbType.VarChar, 30);
              JourneyDate.Value = strDate; //DateTime.Now.ToString("yyyy-MM-ddThh:mm:sszzz"); 
              PnrDeatilscmd.Parameters.Add(JourneyDate);

              SqlParameter ArrivalTime = new SqlParameter("ArrivalTime", SqlDbType.VarChar, 30);
              ArrivalTime.Value = strDate;
              PnrDeatilscmd.Parameters.Add(ArrivalTime);

              SqlParameter DeptTime = new SqlParameter("DeptTime", SqlDbType.VarChar, 30);
              DeptTime.Value = strDate;
              PnrDeatilscmd.Parameters.Add(DeptTime);

        PnrDeatilscmd.ExecuteNonQuery();

         LastPnrID = Convert.ToInt32(LastInsPnrID.Value);
         


        conn.Close();

             SqlCommand PaymentDetailscmd = new SqlCommand();
             PaymentDetailscmd.CommandType = CommandType.StoredProcedure;
             PaymentDetailscmd.CommandText = "sp_InsPaymentDetails";
 PaymentDetailscmd.Connection = conn;
        conn.Open();

             SqlParameter Transaction_Number = new SqlParameter("Transaction_Number", SqlDbType.VarChar, 30);
             Transaction_Number.Value = B.Transaction_Number;
             PaymentDetailscmd.Parameters.Add(Transaction_Number);

             SqlParameter Amount = new SqlParameter("Amount", SqlDbType.Int);
             Amount.Value = B.Amount;
             PaymentDetailscmd.Parameters.Add(Amount);

             SqlParameter Paymentmode = new SqlParameter("Paymentmode", SqlDbType.Int);
             Paymentmode.Value = B.Paymentmode;
             PaymentDetailscmd.Parameters.Add(Paymentmode);

             SqlParameter datetime = new SqlParameter("dateandtime", SqlDbType.DateTime);
             datetime.Value =DateTime.Now.ToString("MM/dd/yyyy");
             PaymentDetailscmd.Parameters.Add(datetime);

             SqlParameter Pnr_Id = new SqlParameter("Pnr_Id", SqlDbType.Int);
             Pnr_Id.Value = LastPnrID;
             PaymentDetailscmd.Parameters.Add(Pnr_Id);

             SqlParameter PnrNo = new SqlParameter("Pnr_No", SqlDbType.VarChar, 20);
             PnrNo.Value = Pnr_Gen_No;
             PaymentDetailscmd.Parameters.Add(PnrNo);


             SqlParameter Gateway_transId = new SqlParameter("Gateway_transId", SqlDbType.VarChar, 20);
             Gateway_transId.Value = B.Gateway_transId;
             PaymentDetailscmd.Parameters.Add(Gateway_transId);


             PaymentDetailscmd.ExecuteNonQuery(); 
        conn.Close();
 return Tbl;

        
            //SqlCommand PnrToSeats = new SqlCommand();
            //PnrToSeats.CommandType = CommandType.StoredProcedure;
            //PnrToSeats.CommandText = "sp_InsPaymentDetails";
            //PnrToSeats.Connection = conn;

            //SqlParameter Pnr_ID = new SqlParameter("@Pnr_ID", SqlDbType.DateTime);
            //Pnr_ID.Value = LastPnrID;
            //PnrToSeats.Parameters.Add(PnrNo);

            //SqlParameter PnrNumber = new SqlParameter("@Pnr_No", SqlDbType.DateTime);
            //PnrNumber.Value = LastPnrID;
            //PnrToSeats.Parameters.Add(PnrNumber);

            //SqlParameter SeatNo = new SqlParameter("@SeatNo", SqlDbType.DateTime);
            //SeatNo.Value = B.SeatNo;
            //PnrToSeats.Parameters.Add(SeatNo);

            //SqlParameter VehicleNo = new SqlParameter("@VehicleNo", SqlDbType.DateTime);
            //VehicleNo.Value = B.VehicleNo;
            //PnrToSeats.Parameters.Add(VehicleNo);
        
        
         

            
             
          }

    }
}

  
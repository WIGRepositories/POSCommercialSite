using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using INTERBUSWebsite.Models;

namespace INTERBUSWebsite.Controllers
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
            cmd.CommandText = "GetAvailableServices";
            cmd.Parameters.Add("@srcId", SqlDbType.Int).Value = srcId;
            cmd.Parameters.Add("@destId", SqlDbType.Int).Value = destId;
            cmd.Connection = conn;
          
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            int a = Tbl.Rows.Count;

                return Tbl;
          }



    [HttpPost]
          public DataTable SaveBookingDetails(Booking B)
          {

              //Booking b = TestServices();
              IEnumerable<passengerDetails> pasglist = B.passengersList;

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

              Random r = new Random();
              var x = r.Next(0, 1000000);
              string s = x.ToString("00000000");
          
           //   string AuthCode = "AUTH" + Guid.NewGuid().ToString().Substring(0, 6);

              SqlParameter Aut = new SqlParameter("AuthCode", SqlDbType.VarChar, 10);
              Aut.Value = s;
              PnrDeatilscmd.Parameters.Add(Aut);

              SqlParameter Journeytype = new SqlParameter("JourneyType", SqlDbType.VarChar, 20);
              Journeytype.Value = B.JourneyType;
              PnrDeatilscmd.Parameters.Add(Journeytype);
             

              PnrDeatilscmd.ExecuteNonQuery();
              PnrDeatilscmd.Parameters.Clear();
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
              datetime.Value = DateTime.Now.ToString("MM/dd/yyyy");
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

              SqlParameter TransactionStatus = new SqlParameter("TransactionStatus", SqlDbType.VarChar, 20);
              TransactionStatus.Value = B.TransactionStatus;
              PaymentDetailscmd.Parameters.Add(TransactionStatus);
             

              PaymentDetailscmd.ExecuteNonQuery();
              PaymentDetailscmd.Parameters.Clear();
              conn.Close();




            
              conn.Open();


              foreach (passengerDetails result in pasglist)
            {
                SqlCommand PassengerDetailscmd = new SqlCommand();
                PassengerDetailscmd.CommandType = CommandType.StoredProcedure;
                PassengerDetailscmd.CommandText = "sp_InsPassengerDetails";
                PassengerDetailscmd.Connection = conn;
                SqlParameter Fname = new SqlParameter("Fname", SqlDbType.VarChar, 30);
                Fname.Value = result.Fname;
                PassengerDetailscmd.Parameters.Add(Fname);

                SqlParameter Lname = new SqlParameter("Lname", SqlDbType.VarChar, 30);
                Lname.Value = result.Lname;
                PassengerDetailscmd.Parameters.Add(Lname);

                SqlParameter Age = new SqlParameter("Age", SqlDbType.Int);
                Age.Value = result.Age;
                PassengerDetailscmd.Parameters.Add(Age);

                SqlParameter Sex = new SqlParameter("Sex", SqlDbType.Int);
                Sex.Value = result.Sex;
                PassengerDetailscmd.Parameters.Add(Sex);

                DateTime dat = DateTime.Now;
                String startDate = "";
                startDate = dat.ToString("MM/dd/yyyy");

                SqlParameter date_time = new SqlParameter("datetime", SqlDbType.VarChar, 30);
                date_time.Value = startDate;
                PassengerDetailscmd.Parameters.Add(date_time);

                SqlParameter Identityproof = new SqlParameter("Identityproof", SqlDbType.VarChar,30);
                Identityproof.Value = result.Identityproof;
                PassengerDetailscmd.Parameters.Add(Identityproof);

                SqlParameter PnrId = new SqlParameter("Pnr_Id", SqlDbType.Int);
                PnrId.Value = LastPnrID;
                PassengerDetailscmd.Parameters.Add(PnrId);

                SqlParameter Pnrno = new SqlParameter("Pnr_No", SqlDbType.VarChar, 20);
                Pnrno.Value = Pnr_Gen_No;
                PassengerDetailscmd.Parameters.Add(Pnrno);

                PassengerDetailscmd.ExecuteNonQuery();
                PassengerDetailscmd.Parameters.Clear();
            }
            conn.Close();

           conn.Open();


           foreach (passengerDetails result in pasglist)
           {
               SqlCommand PnrToSeatscmd = new SqlCommand();
               PnrToSeatscmd.CommandType = CommandType.StoredProcedure;
               PnrToSeatscmd.CommandText = "sp_InsPnrToSeats";
               PnrToSeatscmd.Connection = conn;

               SqlParameter Pnr_ID = new SqlParameter("Pnr_ID", SqlDbType.Int);
               Pnr_ID.Value = LastPnrID;
               PnrToSeatscmd.Parameters.Add(Pnr_ID);

               SqlParameter Pnrnum = new SqlParameter("Pnr_No", SqlDbType.VarChar, 20);
               Pnrnum.Value = Pnr_Gen_No;
               PnrToSeatscmd.Parameters.Add(Pnrnum);

               SqlParameter seatNo = new SqlParameter("SeatNo", SqlDbType.VarChar, 20);
               seatNo.Value = result.SeatNo;
               PnrToSeatscmd.Parameters.Add(seatNo);

               SqlParameter SeatId = new SqlParameter("SeatId", SqlDbType.Int);
               SeatId.Value = result.SeatId;
               PnrToSeatscmd.Parameters.Add(SeatId);

               SqlParameter VehicleNo = new SqlParameter("VehicleNo", SqlDbType.VarChar, 30);
               VehicleNo.Value = B.vehicle_No;
               PnrToSeatscmd.Parameters.Add(VehicleNo);

               DateTime dat = DateTime.Now;
               String staDate = "";
               staDate = dat.ToString("MM/dd/yyyy");

               SqlParameter Date = new SqlParameter("Date", SqlDbType.VarChar, 30);
               Date.Value = staDate;
               PnrToSeatscmd.Parameters.Add(Date);
              
               PnrToSeatscmd.ExecuteNonQuery();
               PnrToSeatscmd.Parameters.Clear();
           }

           conn.Close();

 return Tbl;
             
          }

    }
}

  
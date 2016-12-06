using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using INTERBUSWebsite.Models;
using System.Web.Http.Tracing;

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
          public int SaveBookingDetails(BookingDetails B)
          {
              //DataTable Tbl = new DataTable();

              SqlConnection conn = new SqlConnection();
              conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
              SqlTransaction transaction = null;
              try
              {
                  SqlCommand PnrDeatilscmd = new SqlCommand();
                  PnrDeatilscmd.CommandType = CommandType.StoredProcedure;
                  PnrDeatilscmd.CommandText = "InsUpdDelBookingDetails";
                  PnrDeatilscmd.Connection = conn;
                  conn.Open();

                  transaction = conn.BeginTransaction();
                  PnrDeatilscmd.Transaction = transaction;

                  SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
                  Id.Value = B.Id;
                  PnrDeatilscmd.Parameters.Add(Id);

                  SqlParameter TicketNo = new SqlParameter("@TicketNo", SqlDbType.VarChar, 20);
                  TicketNo.Value = B.TicketNo;
                  PnrDeatilscmd.Parameters.Add(TicketNo);

                  SqlParameter TransId = new SqlParameter("@TransId", SqlDbType.Int);
                  TransId.Value = B.TransId;
                  PnrDeatilscmd.Parameters.Add(TransId);

                  SqlParameter EmailId = new SqlParameter("@EmailId", SqlDbType.VarChar, 50);
                  EmailId.Value = B.EmailId;
                  PnrDeatilscmd.Parameters.Add(EmailId);

                  SqlParameter MobileNo = new SqlParameter("@MobileNo", SqlDbType.VarChar, 15);
                  MobileNo.Value = B.MobileNo;
                  PnrDeatilscmd.Parameters.Add(MobileNo);

                  SqlParameter AltMobileNo = new SqlParameter("@AltMobileNo", SqlDbType.VarChar, 15);
                  AltMobileNo.Value = B.AltMobileNo;
                  PnrDeatilscmd.Parameters.Add(AltMobileNo);

                  SqlParameter TravelDate = new SqlParameter("@TravelDate", SqlDbType.Date);
                  TravelDate.Value = B.JourneyDate;
                  PnrDeatilscmd.Parameters.Add(TravelDate);

                  SqlParameter TravelTime = new SqlParameter("@TravelTime", SqlDbType.Time);
                  TravelTime.Value = B.JourneyTime.Value.TimeOfDay;
                  PnrDeatilscmd.Parameters.Add(TravelTime);

                  SqlParameter Src = new SqlParameter("@Src", SqlDbType.VarChar, 50);
                  Src.Value = B.Src;
                  PnrDeatilscmd.Parameters.Add(Src);

                  SqlParameter Dest = new SqlParameter("@Dest", SqlDbType.VarChar, 50);
                  Dest.Value = B.Dest;
                  PnrDeatilscmd.Parameters.Add(Dest);

                  SqlParameter SrcId = new SqlParameter("@SrcId", SqlDbType.Int);
                  SrcId.Value = B.SrcId;
                  PnrDeatilscmd.Parameters.Add(SrcId);

                  SqlParameter DestId = new SqlParameter("@DestId", SqlDbType.Int);
                  DestId.Value = B.DestId;
                  PnrDeatilscmd.Parameters.Add(DestId);

                  SqlParameter RouteId = new SqlParameter("@RouteId", SqlDbType.Int);
                  RouteId.Value = B.RouteId;
                  PnrDeatilscmd.Parameters.Add(RouteId);

                  SqlParameter VehicleId = new SqlParameter("@VehicleId", SqlDbType.Int);
                  VehicleId.Value = B.VehicleId;
                  PnrDeatilscmd.Parameters.Add(VehicleId);

                  SqlParameter NoOfSeats = new SqlParameter("@NoOfSeats", SqlDbType.Int);
                  NoOfSeats.Value = B.NoOfSeats;
                  PnrDeatilscmd.Parameters.Add(NoOfSeats);

                  SqlParameter Seats = new SqlParameter("@Seats", SqlDbType.VarChar, 250);
                  Seats.Value = B.Seats;
                  PnrDeatilscmd.Parameters.Add(Seats);

                  SqlParameter Status = new SqlParameter("@Status", SqlDbType.VarChar, 50);
                  Status.Value = B.Status;
                  PnrDeatilscmd.Parameters.Add(Status);

                  SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
                  StatusId.Value = B.StatusId;
                  PnrDeatilscmd.Parameters.Add(StatusId);

                  SqlParameter BookedBy = new SqlParameter("@BookedBy", SqlDbType.VarChar, 150);
                  BookedBy.Value = B.BookedBy;
                  PnrDeatilscmd.Parameters.Add(BookedBy);

                  SqlParameter BookedById = new SqlParameter("@BookedById", SqlDbType.Int);
                  BookedById.Value = B.BookedById;
                  PnrDeatilscmd.Parameters.Add(BookedById);

                  SqlParameter Amount = new SqlParameter("@Amount", SqlDbType.Decimal);
                  Amount.Value = B.Amount;
                  PnrDeatilscmd.Parameters.Add(Amount);

                  SqlParameter BookingType = new SqlParameter("@BookingType", SqlDbType.VarChar, 10);
                  BookingType.Value = B.BookingType;
                  PnrDeatilscmd.Parameters.Add(BookingType);

                  SqlParameter BookingTypeId = new SqlParameter("@BookingTypeId", SqlDbType.Int);
                  BookingTypeId.Value = B.BookingTypeId;
                  PnrDeatilscmd.Parameters.Add(BookingTypeId);

                  SqlParameter JourneyType = new SqlParameter("@JourneyType", SqlDbType.VarChar, 10);
                  JourneyType.Value = B.JourneyType;
                  PnrDeatilscmd.Parameters.Add(JourneyType);

                  SqlParameter JourneyTypeId = new SqlParameter("@JourneyTypeId", SqlDbType.Int);
                  JourneyTypeId.Value = B.JourneyTypeId;
                  PnrDeatilscmd.Parameters.Add(JourneyTypeId);

                  SqlParameter UserId = new SqlParameter("@UserId", SqlDbType.Int);
                  UserId.Value = B.UserId;
                  PnrDeatilscmd.Parameters.Add(UserId);

                  SqlParameter Address = new SqlParameter("@Address", SqlDbType.VarChar, 500);
                  Address.Value = B.Address;
                  PnrDeatilscmd.Parameters.Add(Address);

                  SqlParameter insupddelflag = new SqlParameter("@insupddelflag", SqlDbType.VarChar);
                  insupddelflag.Value = B.insupddelflag;
                  PnrDeatilscmd.Parameters.Add(insupddelflag);

                  object bookingId = PnrDeatilscmd.ExecuteScalar();
                  #region 
                  if (B.BookedSeats != null)
                  {

                      PnrDeatilscmd.Parameters.Clear();

                      PnrDeatilscmd.CommandText = "InsUpdDelBookedSeats";

                      foreach (BookedSeats b in B.BookedSeats)
                      {
                          //@Id int = -1,@BookingId int,@TicketNo varchar(20),@SeatNo varchar(5),@SeatId int,@VehicleId int,@Row int,@Col int,@JourneyDate date,@JourneyTime time(7)
                          //,@Status varchar(10),@StatusId int,@FName varchar(50),@LName varchar(50),@Age int,@Gender int,@PassengerType varchar(15),@IdProof varchar(50)
                          //,@PrimaryPassenger int,@insupddelflag varchar                       

                          SqlParameter bId = new SqlParameter("@Id", SqlDbType.Int);
                          bId.Value = b.Id;
                          PnrDeatilscmd.Parameters.Add(bId);

                          SqlParameter BookingId = new SqlParameter("@BookingId", SqlDbType.Int);
                          BookingId.Value = bookingId;
                          PnrDeatilscmd.Parameters.Add(BookingId);

                          SqlParameter bTicketNo = new SqlParameter("@TicketNo", SqlDbType.VarChar, 50);
                          bTicketNo.Value = B.TicketNo;
                          PnrDeatilscmd.Parameters.Add(bTicketNo);

                          SqlParameter SeatNo = new SqlParameter("@SeatNo", SqlDbType.VarChar, 50);
                          SeatNo.Value = b.SeatNo;
                          PnrDeatilscmd.Parameters.Add(SeatNo);

                          SqlParameter SeatId = new SqlParameter("@SeatId", SqlDbType.Int);
                          SeatId.Value = b.SeatId;
                          PnrDeatilscmd.Parameters.Add(SeatId);

                          SqlParameter bVehicleId = new SqlParameter("@VehicleId", SqlDbType.Int);
                          bVehicleId.Value = b.VehicleId;
                          PnrDeatilscmd.Parameters.Add(bVehicleId);

                          SqlParameter Row = new SqlParameter("@Row", SqlDbType.Int);
                          Row.Value = b.Row;
                          PnrDeatilscmd.Parameters.Add(Row);

                          SqlParameter Col = new SqlParameter("@Col", SqlDbType.Int);
                          Col.Value = b.Col;
                          PnrDeatilscmd.Parameters.Add(Col);

                          SqlParameter JourneyDate = new SqlParameter("@JourneyDate", SqlDbType.Date);
                          JourneyDate.Value = B.JourneyDate;
                          PnrDeatilscmd.Parameters.Add(JourneyDate);

                          SqlParameter JourneyTime = new SqlParameter("@JourneyTime", SqlDbType.Time);
                          JourneyTime.Value = B.JourneyTime.Value.TimeOfDay;
                          PnrDeatilscmd.Parameters.Add(JourneyTime);

                          SqlParameter bStatus = new SqlParameter("@Status", SqlDbType.VarChar, 50);
                          bStatus.Value = b.Status;
                          PnrDeatilscmd.Parameters.Add(bStatus);

                          SqlParameter bStatusId = new SqlParameter("@StatusId", SqlDbType.Int);
                          bStatusId.Value = b.StatusId;
                          PnrDeatilscmd.Parameters.Add(bStatusId);

                          SqlParameter FName = new SqlParameter("@FName", SqlDbType.VarChar, 50);
                          FName.Value = b.FName;
                          PnrDeatilscmd.Parameters.Add(FName);

                          SqlParameter LName = new SqlParameter("@LName", SqlDbType.VarChar, 50);
                          LName.Value = b.LName;
                          PnrDeatilscmd.Parameters.Add(LName);

                          SqlParameter Age = new SqlParameter("@Age", SqlDbType.Int);
                          Age.Value = b.Age;
                          PnrDeatilscmd.Parameters.Add(Age);

                          SqlParameter Gender = new SqlParameter("@Gender", SqlDbType.Int);
                          Gender.Value = b.Gender;
                          PnrDeatilscmd.Parameters.Add(Gender);

                          SqlParameter PassengerType = new SqlParameter("@PassengerType", SqlDbType.VarChar, 50);
                          PassengerType.Value = b.PassengerType;
                          PnrDeatilscmd.Parameters.Add(PassengerType);

                          SqlParameter IdProof = new SqlParameter("@IdProof", SqlDbType.VarChar, 250);
                          IdProof.Value = b.IdProof;
                          PnrDeatilscmd.Parameters.Add(IdProof);

                          SqlParameter PrimaryPassenger = new SqlParameter("@PrimaryPassenger", SqlDbType.Int);
                          PrimaryPassenger.Value = b.PrimaryPassenger;
                          PnrDeatilscmd.Parameters.Add(PrimaryPassenger);

                          SqlParameter binsupddelflag = new SqlParameter("@insupddelflag", SqlDbType.VarChar);
                          binsupddelflag.Value = b.insupddelflag;
                          PnrDeatilscmd.Parameters.Add(binsupddelflag);

                          PnrDeatilscmd.ExecuteScalar();

                          PnrDeatilscmd.Parameters.Clear();
                      }
                  }
                  #endregion
                  transaction.Commit();
                  //return Tbl;
                  int bid = Convert.ToInt32(bookingId);
                  return bid;
              }
              catch (SqlException sqlEx)
              {
                  transaction.Rollback();
                  //traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveAssetDetails:" + sqlEx.Message);
                  //return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);
                  return -1;

              }
              catch (Exception ex)
              {
                  //transaction.Rollback();
                  if (conn != null && conn.State == ConnectionState.Open)
                  {
                      conn.Close();
                  }
                  string str = ex.Message;
                  return -1;
                  //traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveAssetDetails:" + ex.Message);
                  //return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
              }
              finally
              {
                  conn.Close();
                  conn.Dispose();
              }
          }

    }
}

  
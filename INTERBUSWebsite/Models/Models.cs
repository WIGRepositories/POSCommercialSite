using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTPOSDashboardAPI.Models
{
   

    public class FleetOwner
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string BTPOSgroupid { get; set; }

        public string Active { get; set; }

    }

    public class TroubleTicketingCategories
    {
        public int active { get; set; }

        public string desc { get; set; }

        public int Id { get; set; }

        public string TTCategory { get; set; }

        public int typegrpid { get; set; }

    }

   

    public class BOTPOSL
    {
        public int Id { set; get; }
        public int BTPOSid { set; get; }
        public int licenseId { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime NotificationDate { set; get; }
        public int TransactionId { set; get; }
        public DateTime RenewedOn { set; get; }
    }
    public class FleetOL
    {
        public int Id { set; get; }
        public int FleetOwnerId { set; get; }
        public int LicenseId { set; get; }
        public int Code { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime NotificationDate { set; get; }
        public int TransactionId { set; get; }
        public DateTime RenewedOn { set; get; }
    }
    public class Payment
    {
        public int Id { set; get; }
        public int PaymentTypeId { set; get; }
        public int Amount { set; get; }
        public DateTime date { set; get; }
        public int TransactionId { set; get; }
    }
   

    public class FleetOwnerRequest
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String MobileNo { get; set; }
        public String CompanyName { get; set; }
        public String Description { get; set; }       
        public string insupdflag { get; set; }

    }

    public class Booking
    {
        public int Pnr_ID { get; set; }
        public string Pnr_No {get; set;}
        public int No_Seats { get; set; }
        public int cost { get; set; }
        public string dateandtime { get; set; }
        public string src { get; set; }
        public string dest { get; set; }
        public string vehicle_No { get; set; }
        public string JourneyDate { get; set; }
        public string ArrivalTime { get; set; }
        public string DeptTime { get; set; }
        public int PassengerId { get; set; }

        public int TransactionId { get; set; }
        public string Transaction_Number { get; set; }
        public int Amount { get; set; }
        public int Paymentmode { get; set; }
        public string Gateway_transId { get; set; }

        //public int Bookedhistory_Id { get; set; }
        //public int UserId { get; set; }
        public int RouteId { get; set; }
        public int fleetOwnerId { get; set; }
        public int TransactionStatus { get; set; }
        public string AuthCode { get; set; }
        public int JourneyType { get; set; }
      
        public IEnumerable<passengerDetails> passengersList { get; set; }
        
    }
        
    public class passengerDetails {
        public string SeatNo { get; set; }
        public int SeatId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public string Identityproof { get; set; }
        public string datetime { get; set; }
    }

    

    public class Licence
    {
        public int Id { get; set; }
        public int LicenseCatId { get; set; }
        public String LicenseType { get; set; }
        public String Description { get; set; }
        public int Active { get; set; }

    }

    public class UserIn
    {
      
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String EmailAddress { get; set; }
        public String ConfirmPassword { get; set; }
        public String Gender { get; set; } 
        public String salt { set; get; }
     
       

    }
    public class UserLogin
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public string LoginInfo { set; get; }
        public string Passkey { set; get; }
        public string salt { set; get; }
        public string Active { set; get; }

    }
    public class reset
    {
      
        public string UserName { set; get; }
        public string OldPassword { set; get; }
        public string NewPassword { set; get; }
        public string ReenterNewPassword { set; get; }

    }
    public class FleetOwnerRequest1
    { 

     //   public int  Id {get; set;}
       public string  FirstName {get; set;}

        public string LastName{get; set;}
        public string PhoneNo{get; set;}
        public  string EmailAddress {get; set;}

        public string CompanyName {get; set;}
        public string Description {get; set;}

        public string Title{get; set;}
        public string CompanyEmployeSize {set; get;}

        public string FleetSize {set; get;}
        
        public string CurrentSystemInUse {set; get;}

        public int  SentNewProductsEmails { set; get; }
          
        public string Gender {set; get;}  

        public string howdidyouhearaboutus {get; set;}

        public int Agreetotermsandconditions { get; set; }

         public  string Address {get; set;}
          
         public string insupdflag {get; set;}
           
    }

    public class Fleet
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }

        public string CompanyName { get; set; }
        public string Description { get; set; }

        public string Title { get; set; }
        public string CompanyEmployeSize { set; get; }

        public string FleetSize { set; get; }

        public string CurrentSystemInUse { set; get; }

        public int SentNewProductsEmails { set; get; }

        public string Gender { set; get; }

        public string howdidyouhearaboutus { get; set; }

        public int Agreetotermsandconditions { get; set; }

        public string Address { get; set; }

       // public string insupdflag { get; set; }

    }

   
}

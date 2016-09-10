using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INTERBUSWebsite.Models
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
   
   

    public class Booking
    {
        public int Pnr_ID { get; set; }
        public string Pnr_No { get; set; }
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
        
    public class passengerDetails
    {
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
    public class FleetOwnerRequest
    {                    
        //user details
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName{get; set;}
        public int PhoneNo{get; set;}
        public string EmailAddress { get; set; }
        public int AltPhoneNo{get; set;}  
        public int Gender { set; get; }
        public string Address { get; set; }
        public string userPhoto { get; set; }

        //Company details
        public string CompanyName {get; set;}
        public string CmpEmailAddress { get; set; }

        public string CmpAddress { get; set; }
        public string CmpAltAddress { get; set; }

        public string CmpCaption { get; set; }

        public string CmpTitle { get; set; }
        public string CmpPhoneNo { set; get; }
        public string CmpAltPhoneNo { set; get; }

        public string FleetSize { set; get; }           
        public int StaffSize { get; set; }
        public string Country {get;set;}
        public string Code {get;set;}
        public string CmpFax {get;set;}
        public string ZipCode {get;set;}
        public string  CmpLogo{get;set;}
        public string state{get;set;}  
        public string insupdflag { get; set; }

       //General details
        public string CurrentSystemInUse { set; get; }
        public string SentNewProductsEmails { set; get; }  
        public string howdidyouhearaboutus { get; set; }           
        public int Agreetotermsandconditions { get; set; }                    
           
    }
    public class LicensePage
    {
        public int Id { get; set; }
        public int LicenseTypeId { get; set; }
        public string LicenseType { get; set; }
        public string fleetownercode { get; set; }
        public Decimal Unitprice { get; set; }
        public int FeatureName { get; set; }
        public int FeatureLabel { get; set; }
        public int FeatureValue { get; set; }

      
        public string insupdflag { get; set; }

        public int LicenseCatId { get; set; }

    }
    public class CartDetails
    {

        public string LicenseType { set; get; }
        public int Frequency { set; get; }
        public string NoOfMonths { set; get; }
        public int TotalAmount { set; get; }
        public DateTime CreateDate { set; get; }
        public string TransId { set; get; }
        public int UnitPrice { set; get; }
        public string FleetOwner { set; get; }

    }
    
    public class UserLicenseDetails
    {
        public List<ULLicense> checkSchedule { get; set; }
        public int Id { set; get; }
        public int UserId { set; get; }
        public int FOId { set; get; }
        public string FOCode { set; get; }
        public int LicenseTypeId { set; get; }
        public DateTime? StartDate { set; get; }
        public DateTime? ExpiryOn { set; get; }
        public int GracePeriod { set; get; }
        public DateTime? ActualExpiry { set; get; }
        public DateTime? LastUpdatedOn { set; get; }
        public int Active { set; get; }
        public int RenewFreqTypeId { set; get; }
        public int StatusId { set; get; }

        public string insupddelflag { set; get; }

    }
    public class ULLicense
    {
        public int Id { set; get; }
        public int ULId { set; get; }
        public string TransId { set; get; }
        public DateTime? CreatedOn { set; get; }
        public decimal Amount { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Units { set; get; }
        public int StatusId { set; get; }
        public int LicensePymtTransId { set; get; }
        public int IsRenewal { set; get; }
        public string insupddelflag { set; get; }
    }
  
    public class UserLicensePayments
    {
        public int Id { set; get;}
        public int ULId { set; get;}
        public DateTime CreatedOn { set; get;}
        public decimal Amount { set; get;}
        public decimal UnitPrice { set; get;}
        public decimal Units { set; get;}
        public int StatusId { set; get;}
        public int LicensePymtTransId { set; get;}
        public int IsRenewal { set; get;}
        public string TransId { set; get; }
        public DateTime PaymentTypeId { get; set; }
    }
    public class UserLicensePymtTransactions
    {
        public int Id { set; get; }
        public string TransId { set; get; }
        public string GatewayTransId { set; get; }
        public decimal Amount { set; get; }
        public DateTime TransDate { set; get; }
        public int ULPymtId { set; get; }
        public int StatusId { set; get; }
        public string Desc { set; get; }
        public string insupddelflag { set; get; }
        public decimal Tax { set; get; }
        public decimal Discount { set; get; }
        public int PymtTypeId { set; get; }

    }
    public class ULPymtTransDetails
    {
        public int Id { set; get; }
        public int ULPPymtTransId { set; get; }
        public int PaymentTypeId { set; get; }
        public int StatusId { set; get; }
        public decimal Discount { set; get; }
        public decimal Tax { set; get; }
        public decimal Amount { set; get; }
        public DateTime TransDate { set; get; }
    }
    public class ULFeatures
    {
       // public int Id { set; get; }
        public int ULPymtId { set; get; }
        public int FeatureId { set; get; }
        public string FeatureValue { set; get; }
        public string FeatureDesc { set; get; }
    }

    public class payPalPymnt { 
    
    }

    public class ULConfirmDetails
    { 
        public int Id { set; get; }
        public int ULId { set; get; }
        public int ULPymtId { set; get; }
        public int foId { set; get; }
        public int userId { set; get; }
        public string TransId { set; get; }
        public string GatewayTransId { set; get; }
        public int itemId { set; get; }
        public string address { set; get; }
        public decimal Amount { set; get; }
        public decimal Units { set; get; }
        public decimal POSUnits { set; get; }     
        public int IsRenewal { set; get; }
        public string insupddelflag { set; get; }
    }
   
}

      public class WebsiteUserInfo
      {
          public string FirstName { set; get; }
          public string LastName { set; get; }

          public string UserName { set; get; }

          public string Password { set; get; }

          public string EmailAddress { set; get; }

          public string Mobile { set; get; }
          

      }


     public class ResetPassword
     {
         public string Username { set; get; }

         public string OldPassword { set; get; }

         public string NewPassword {set;get;}

         public string ReEnterNewPassword {set;get;}
     }
using INTERBUSWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace INTERBUSWebsite.Controllers
{
    public class UserInfoController : ApiController
    {
        [HttpPost]
        public DataTable saveUserInfo(UserInfo b)
        {

            DataTable Tbl = new DataTable();
           // int userid = b.Id;
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();


                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdWebsiteUserInfo";
                cmd.Connection = conn;
                //     conn.Open();       

                SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                id.Value = b.Id;
                cmd.Parameters.Add(id);

                SqlParameter Gid = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                Gid.Value = b.FirstName;
                cmd.Parameters.Add(Gid);

                SqlParameter pid = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                pid.Value = b.LastName;
                cmd.Parameters.Add(pid);


                SqlParameter lid = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                lid.Value = b.UserName;
                cmd.Parameters.Add(lid);

                SqlParameter gid = new SqlParameter("@Password", SqlDbType.VarChar, 50);
                gid.Value = b.Password;
                cmd.Parameters.Add(gid);

                SqlParameter oid = new SqlParameter("@EmailAddress", SqlDbType.VarChar, 50);
                oid.Value = b.EmailAddress;
                cmd.Parameters.Add(oid);

                SqlParameter rid = new SqlParameter("@Mobile", SqlDbType.VarChar, 15);
                rid.Value = b.Mobile;
                cmd.Parameters.Add(rid);

                SqlParameter wid = new SqlParameter("@Gender", SqlDbType.Int);
                wid.Value = b.Gender;
                cmd.Parameters.Add(wid);

                SqlParameter UserTypeId = new SqlParameter("@UserTypeId", SqlDbType.Int);
                UserTypeId.Value = b.UserTypeId;
                cmd.Parameters.Add(UserTypeId);

                SqlParameter UserId = new SqlParameter("@UserId", SqlDbType.Int);
                UserId.Value = b.UserId;
                cmd.Parameters.Add(UserId);

                SqlParameter Active = new SqlParameter("@Active", SqlDbType.Int);
                Active.Value = b.Active;
                cmd.Parameters.Add(Active);

                SqlParameter IsEmailVerified = new SqlParameter("@IsEmailVerified", SqlDbType.Int);
                IsEmailVerified.Value = b.IsEmailVerified;
                cmd.Parameters.Add(IsEmailVerified);
                                
                SqlParameter insUpdDelFlag = new SqlParameter("@insUpdDelFlag", SqlDbType.VarChar, 15);
                insUpdDelFlag.Value = b.InsUpdDelFlag;
                cmd.Parameters.Add(insUpdDelFlag);

                SqlParameter emailVerificationCode = new SqlParameter("@EVerificationCode", SqlDbType.VarChar, 15);
                emailVerificationCode.Value = null;
                emailVerificationCode.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(emailVerificationCode);

              //  conn.Open();

             //   object outputid = cmd.ExecuteScalar();

              //  conn.Close();
              //  userid = (int)outputid;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Tbl);
                
                //retrive the code and send email to the user
                object val = emailVerificationCode.Value;
                if (val != null)
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        string emailserver = System.Configuration.ConfigurationManager.AppSettings["emailserver"].ToString();
                                                
                        string username = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
                        string pwd = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
                        string fromaddress = System.Configuration.ConfigurationManager.AppSettings["fromaddress"].ToString();
                        string port = System.Configuration.ConfigurationManager.AppSettings["port"].ToString();

                        SmtpClient SmtpServer = new SmtpClient(emailserver);

                        mail.From = new MailAddress(fromaddress);
                        mail.To.Add("webingate@gmail.com");
                        mail.Subject = "Test Mail";
                        mail.Body = "<h3>Congratulations!!</h3> <br/><br/>You have been successfully registered with INTERBUS website. Please use below email verification to verify the email address.<br/><br/>Email verification code: <h4><strong>" + val.ToString() + "</strong></h4>";

                        //SmtpServer.Port = 465;
                        //SmtpServer.Port = 587;
                        SmtpServer.Port = Convert.ToInt32(port);
                        SmtpServer.UseDefaultCredentials = false;

                        SmtpServer.Credentials = new System.Net.NetworkCredential(username, pwd);
                        SmtpServer.EnableSsl = true;
                        //SmtpServer.TargetName = "STARTTLS/smtp.gmail.com";
                        SmtpServer.Send(mail);

                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                    }

                }
               
                
                return Tbl;
            }

            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return Tbl;
            }
        }
        public void Options() { }

    }
    }


  
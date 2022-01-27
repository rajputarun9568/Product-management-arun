using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web.UI;

namespace Product_management_arun.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View();


        }
     

      
        public ActionResult Signup(string FirstName, string Lastname,string OTP, string Password, string Email)
          
        {
            string msg = "";
            if (Session["otp"].ToString() == OTP)
            {
                ViewBag.msg = "You have enter correct OTP.";
                Session["OTP"] = null;
            }
            else
            {
                ViewBag.msg = "Pleae enter correct OTP.";
                return RedirectToAction("Index", "Signup");
            }

            using (DatabaseContext db = new DatabaseContext())
                {
                    var res = db.Database.ExecuteSqlCommand("sp_Signup @Firstname,@Lastname,@Password,@Email,@otp",
                      new SqlParameter("@Firstname", FirstName),
                      new SqlParameter("@Lastname", Lastname),
                      new SqlParameter("@Password", Password),
                      new SqlParameter("@Email", Email),
                      new SqlParameter("@otp", OTP));
              
                }
            
                return View("~/Views/Login/Index.cshtml");
            }

        public JsonResult Sendotp(string Email)

        {

            Random r = new Random();
            string otp = r.Next(10001, 99999).ToString();
            Session["otp"] = otp;
            using (MailMessage mm = new MailMessage("arunrajput1803@gmail.com", Email))
            {
                mm.Subject = "your Ragistration otp";
                string msg = "Your Otp  :" + otp;
                mm.Body = msg.ToString();
                mm.IsBodyHtml = true;
                SmtpClient mySmtpClient = new SmtpClient();
                mySmtpClient.Host = "smtp.gmail.com";
                mySmtpClient.EnableSsl = true;
                // set smtp-client with basicAuthentication
                NetworkCredential NetworkCred = new NetworkCredential("arunrajput1803@gmail.com", "arun@9568");
                mySmtpClient.UseDefaultCredentials = true;
                mySmtpClient.Credentials = NetworkCred;
                mySmtpClient.Port = 587;
                mySmtpClient.Send(mm);
            }
            string output = "Success";

            return Json(output, JsonRequestBehavior.AllowGet);

        }
    }
        }
    

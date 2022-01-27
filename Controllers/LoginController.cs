using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_management_arun.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
       {
            return View();
        }
        public ActionResult Login(string Email, string Password)

        {
            string obj = "";
            var Isvalid = new SqlParameter("@Isvalid", SqlDbType.BigInt);
            Isvalid.Direction = System.Data.ParameterDirection.Output;
            using (DatabaseContext db = new DatabaseContext())
            {
              var   res = db.Database.ExecuteSqlCommand("sp_Login @Email,@Password,@Isvalid out",
                  new SqlParameter("@Email", Email),
                  new SqlParameter("@Password", Password), Isvalid);
                obj = Isvalid.SqlValue.ToString();
            }
            if (obj != "0")
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
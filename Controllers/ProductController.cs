using Product_management_arun.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_management_arun.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View("~/Views/Product/Insert.cshtml");
        }
        public ActionResult Insert(string Title, int? Quantity, int? Price, string Image, string Description, string Category_Id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var res = db.Database.ExecuteSqlCommand("sp_AddProduct @Title,@Quantity,@Price,@image,@Description,@Category_id", 
                  new SqlParameter("@Title", Title),
                  new SqlParameter("@Quantity", Quantity),
                  new SqlParameter("@Price", Price),
                  new SqlParameter("@image", Image),
                  new SqlParameter("@Description", Description),
                  new SqlParameter("@Category_id", Category_Id));

            }
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Show()
        {
            
            List<Product> Products = new List<Product>();
            using (DatabaseContext db = new DatabaseContext())
            {
               db.Database.SqlQuery<Product>("@sp_showlist");
             }
            return View();
        }
    }
}
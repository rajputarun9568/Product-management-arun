using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Product_management_arun.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
       
        public string Description { get; set; }

        public string Category_id { get; set; }

    }
   
   

}
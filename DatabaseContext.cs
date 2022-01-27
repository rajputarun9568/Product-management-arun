using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Product_management_arun.Models;

namespace Product_management_arun
{
    public class DatabaseContext :DbContext
    {
     
        public DatabaseContext()
                : base("name=DatabaseContext")
            {
            }

            public virtual DbSet<SignupUser> SignupUsers { get; set; }
            


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {

            }
        
    }
}
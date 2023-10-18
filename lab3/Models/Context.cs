using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Npgsql;

namespace lab3.Models
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Student> Students { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudOperationPractical.Models
{
    public class CrudContext :DbContext
    {
        public CrudContext() : base("CrudContextDemo")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<AttributeValues> AttributeValues { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
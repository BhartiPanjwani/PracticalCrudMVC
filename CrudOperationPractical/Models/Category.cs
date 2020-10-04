using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudOperationPractical.Models
{
    public class Category
    {
        [DisplayName("Category")]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [Required]
        public string Name { get; set; }
    }
}
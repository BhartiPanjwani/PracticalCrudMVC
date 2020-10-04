using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudOperationPractical.Models
{
    public class Attribute
    {
        [DisplayName("Attribute")]
        public int Id { get; set; }
        [DisplayName("Attribute Name")]
        [Required]
        public string Name { get; set; }

        [ForeignKey("Category")]
        [DisplayName("Attribute")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperationPractical.Models
{
    public class Product
    {
        public Product()
        {
            CategoryList = new List<SelectListItem>();
            AttributeList = new List<SelectListItem>();
            AttributeValuesList = new List<SelectListItem>();
        }
        [DisplayName("Product")]
        public int Id { get; set; }
        [DisplayName("Product")]
        [Required]
        public string Name { get; set; }

        [ForeignKey("Category")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("Attribute")]
        [DisplayName("Attribute")]
        public int AttributeId { get; set; }
        public virtual Attribute Attribute { get; set; }
        [ForeignKey("AttributeValues")]
        [DisplayName("AttributeValues")]
        public int AttributeValuesId { get; set; }
        public virtual AttributeValues AttributeValues { get; set; }


        [NotMapped]
        public List<SelectListItem> CategoryList { get; set; }
        [NotMapped]
        public List<SelectListItem> AttributeList { get; set; }
        [NotMapped]
        public List<SelectListItem> AttributeValuesList { get; set; }

    }
}
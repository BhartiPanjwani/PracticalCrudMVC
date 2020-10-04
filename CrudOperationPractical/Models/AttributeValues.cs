using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudOperationPractical.Models
{
    public class AttributeValues
    {
        [DisplayName("Attribute Value")]
        public int Id { get; set; }
        [DisplayName("Attribute Value")]
        [Required]
        public string Name { get; set; }

        [ForeignKey("Attribute")]
        [DisplayName("Attribute")]
        public int AttributeId { get; set; }
        public virtual Attribute Attribute { get; set; }
    }
}
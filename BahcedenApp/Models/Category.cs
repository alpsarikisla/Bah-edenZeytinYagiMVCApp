using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BahcedenApp.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Zorunlu alan")]
        [StringLength(maximumLength:75, ErrorMessage ="Maksimum 75 karakter olmalıdır")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 500, ErrorMessage = "Maksimum 500 karakter olmalıdır")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual List<Product> Products { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BahcedenApp.Models
{
    public class Product
    {
        public int ID { get; set; }
        
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(maximumLength: 75, ErrorMessage = "Maksimum 75 karakter olmalıdır")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 500, ErrorMessage = "Maksimum 500 karakter olmalıdır")]
        public string Description { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }
    }
}
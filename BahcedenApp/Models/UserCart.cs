using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BahcedenApp.Models
{
    public class UserCart
    {
        public int ID { get; set; }

        public int User_ID { get; set; }

        [ForeignKey("User_ID")]
        public virtual User User { get; set; }

        public int Product_ID { get; set; }

        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice { get; set; }
    }
}
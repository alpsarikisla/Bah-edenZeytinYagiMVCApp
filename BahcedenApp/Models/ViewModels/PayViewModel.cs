using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BahcedenApp.Models.ViewModels
{
    public class PayViewModel
    {
        public string Name { get; set; }
        public string CartNumber { get; set; }
        public string CVV { get; set; }
        public string ReqYear { get; set; }
        public string ReqMonth { get; set; }
        public decimal Price { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BahcedenApp.Areas.AdminPanel.Data
{
    public class ManagerLoginViewModel
    {
        //Bu sınıfın amacı viewdan sadece mail ve şifre bilgisini almak
        //Tüm manager bilgilerine ihtiyacımız yok
        [Required(ErrorMessage = "Mail Zorunludur")]
        [StringLength(maximumLength: 75, MinimumLength = 3, ErrorMessage = "Mail 3-75 karakter arası olmalıdır")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Mail adresi hatalı")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre Zorunlu")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 16, MinimumLength = 8, ErrorMessage = "Mail 8-16 karakter arası olmalıdır")]
        public string Password { get; set; }
    }
}
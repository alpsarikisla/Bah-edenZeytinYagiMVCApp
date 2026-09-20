using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BahcedenApp.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [StringLength(maximumLength: 75, ErrorMessage = "İsim maksimum 75 karakter olmalıdır")]
        public string Name { get; set; }

        [StringLength(maximumLength: 75, ErrorMessage = "Soyad maksimum 75 karakter olmalıdır")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Mail Zorunludur")]
        [StringLength(maximumLength: 75, MinimumLength = 3, ErrorMessage = "Mail 3-75 karakter arası olmalıdır")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Mail adresi hatalı")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre Zorunlu")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 16, MinimumLength = 8, ErrorMessage = "Mail 8-16 karakter arası olmalıdır")]
        public string Password { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual List<UserCart> UserCarts { get; set; }
    }
}
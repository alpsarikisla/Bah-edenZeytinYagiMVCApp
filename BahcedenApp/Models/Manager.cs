using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BahcedenApp.Models
{
    //Yönetici Bilgilerinin tutulduğu tablo
    public class Manager
    {
        //primary key yapmaya gerek yok Adı ID ise otomatik olarak pk yapar identity ekler
        public int ID { get; set; }

        public int ManagerType_ID { get; set; }

        [ForeignKey("ManagerType_ID")]
        public ManagerType ManagerType { get; set; }

        [Required(ErrorMessage ="Boş Bırakılamaz")]
        [StringLength(maximumLength:75,ErrorMessage ="İsim maksimum 75 karakter olmalıdır")]
        public string Name { get; set; }

        [StringLength(maximumLength: 75, ErrorMessage = "Soyad maksimum 75 karakter olmalıdır")]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Mail Zorunludur")]
        [StringLength(maximumLength:75, MinimumLength = 3, ErrorMessage ="Mail 3-75 karakter arası olmalıdır")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Mail adresi hatalı")]
        public string Mail { get; set; }

        [Required(ErrorMessage ="Şifre Zorunlu")]
        [StringLength(maximumLength: 16, MinimumLength = 8, ErrorMessage = "Mail 8-16 karakter arası olmalıdır")]
        public string Password { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
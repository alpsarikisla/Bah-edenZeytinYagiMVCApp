using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BahcedenApp.Models
{
    public class ManagerType
    {
        public int ID { get; set; }

        [StringLength(maximumLength:75)]//Eğer eklenmezse veritabanında bu kolunu ntext yapar şu anda nvarchar(75) yaptı
        public string Name { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
        //Bu türe ait olan managerların listesi burada tutlacak
    }
}
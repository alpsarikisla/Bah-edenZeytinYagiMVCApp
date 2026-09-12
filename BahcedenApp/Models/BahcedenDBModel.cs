using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BahcedenApp.Models
{
    public partial class BahcedenDBModel : DbContext
    {
        public BahcedenDBModel()
            : base("name=BahcedenDBModel")
        {
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<ManagerType> ManagerTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        //Buraya Eklenmeyen sınıfın veritabanında tablosu oluşmaz
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

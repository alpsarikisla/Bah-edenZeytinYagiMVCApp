namespace BahcedenApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BahcedenApp.Models.BahcedenDBModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BahcedenApp.Models.BahcedenDBModel context)
        {
            ////Veri tabanı oluşturulurken varsayılan olarak veritabanına eklenmesini istediğimiz verileri buraya yazıyoruz
            //Seed Kullanımı zorunlu değildir.
            context.ManagerTypes.AddOrUpdate(x => x.ID, new Models.ManagerType() { ID = 1, Name = "Yönetici" });
            context.ManagerTypes.AddOrUpdate(x => x.ID, new Models.ManagerType() { ID = 2, Name = "Moderatör" });

            context.Managers.AddOrUpdate(x => x.ID, new Models.Manager() { ID = 1, Name = "Alp", Surname = "Sarıkışla", Mail = "admin@bahceden.com", Password = "12345678", ManagerType_ID = 1, IsActive = true });
        }
    }
}

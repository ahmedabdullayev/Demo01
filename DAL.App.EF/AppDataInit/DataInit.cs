using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.AppDataInit
{
    public class DataInit
    {
        public static void DropDatabase(AppDbContext ctx)
        {
            ctx.Database.EnsureDeleted();
        }
        public static void MigrateDatabase(AppDbContext ctx)
        {
            ctx.Database.Migrate();
        }
       
        public static void SeedAppData(AppDbContext ctx)
        {
            ctx.Persons.Add(new Person() {FirstName = "Foo", LastName = "Barr"});
            ctx.SaveChanges();
        }
    }
}
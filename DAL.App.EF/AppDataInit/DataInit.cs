using System.Collections.Generic;
using Domain.App;
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
            var ctypeSkype = new ContactType
            {
                ContactTypeValue = "Skype"
            };
            var ctypeEmail = new ContactType
            {
                ContactTypeValue = "Email"
            };
            var person = new Person() {FirstName = "Foo", LastName = "Barr"};
            person.Contacts = new List<Contact>
            {
                new Contact
                {
                    ContactValue = "ahma",
                    ContactType = ctypeSkype
                },
                new Contact
                {
                    ContactValue = "ahma@ahmabrat",
                    ContactType = ctypeEmail
                },
            };
            ctx.Persons.Add(person);
            ctx.SaveChanges();
        }
    }
}
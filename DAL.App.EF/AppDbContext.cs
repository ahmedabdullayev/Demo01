using System;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Contact> Contacts { get; set; } = default!;
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<ContactType> ContactTypes { get; set; } = default!;
        public DbSet<PersonPicture> PersonPictures { get; set; } = default!;
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //disable cascade delete
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            // builder.Entity<Contact>().HasIndex(x => new {x.PersonId, x.ContactTypeId}).IsUnique();

            builder.Entity<ContactType>()
                .HasMany(m => m.Contacts)
                .WithOne(o => o.ContactType!)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
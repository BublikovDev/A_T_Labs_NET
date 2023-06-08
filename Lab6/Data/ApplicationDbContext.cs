using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Lab6.Models;

namespace Lab6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Interest> Interests { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.PhoneNumbers)
                .WithOne(phone => phone.Person)
                .HasForeignKey(phone => phone.PersonId);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Interests)
                .WithMany(i => i.Persons);
        }
    }
}

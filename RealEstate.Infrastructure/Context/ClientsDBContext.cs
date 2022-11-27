﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Data.Identity;
using RealEstate.Infrastructure.Entities.Clients;

namespace RealEstate.Infrastructure.Context
{
    public class ClientsDBContext : IdentityDbContext<ApplicationUser>
    {
        public ClientsDBContext(DbContextOptions<ClientsDBContext> options)
            : base(options) {}

        public DbSet<Client> Clients { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Contact>()
                .HasIndex(c => c.Id)
                .IsUnique();

            modelBuilder
                .Entity<Contact>()
                .HasOne(cl => cl.Client)
                .WithOne(c => c.Contact)
                .HasForeignKey<Client>(cl => cl.Client_Id)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder
                .Entity<Client>()
                .HasIndex(c => c.Id)
                .IsUnique();

            modelBuilder
               .Entity<Client>()
               .HasOne(c => c.Contact)
               .WithOne(cl => cl.Client)
               .HasForeignKey<Contact>(cl => cl.Contact_Details)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
﻿using Cafe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Data
{
    class CafeDbContext:DbContext
    {
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<ClientTable> ClientTables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(Config.Configuration.GetConnectionString("SQLiteConnection"));
            //optionsBuilder.UseNpgsql(Config.Configuration.GetConnectionString("PostgresqlConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<Waiter>(); 
            modelBuilder.Entity<Waiter>().HasData(new Waiter[] { Waiter.Admin });
            modelBuilder.Entity<Role>().HasData(new Role[] { Role.Admin,Role.Manager,Role.User });
            modelBuilder.Entity<UserRole>().HasData(new UserRole[] { new UserRole { Id = 1, RoleId = Role.Admin.Id, WaiterId = Waiter.Admin.Id } });

        }
    }
}

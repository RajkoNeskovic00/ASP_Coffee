using ASP_Coffee.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASP_Coffee.DataAccess
{
    public class Coffee_Context : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Coffee_Project;Integrated Security=True"); 
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Bean> Beans { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Amount> Amounts { get; set; }
        public DbSet<AmountCoffee> AmountCoffees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
    }
}

﻿using Microsoft.EntityFrameworkCore;

namespace courseWork.Entity
{
    public class JewelleryContext : DbContext
    {
        public JewelleryContext(DbContextOptions<JewelleryContext> options) : base(options) { }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Jewellery> Jewelleries { get; set; }
        public DbSet<OrderJewelleries> OrderJewelleries{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderJewelleries>()
                .HasKey(x => new { x.OrderId, x.JewelleryId });

            modelBuilder.Entity<Jewellery>().HasData(new Jewellery()
            {
                Id = 1,
                Name = "Test1",
                Type = "Test1",
                Material = "Test1",
                Gemstones = "Test1",
                Size = 0,
                Price = 0,
            }
            );
        }
    }
}

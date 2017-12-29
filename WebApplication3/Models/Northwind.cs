namespace WebApplication3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Northwind : DbContext
    {
        public Northwind()
            : base("name=Northwind")
        {
        }

        public virtual DbSet<Order_Details> Order_Details { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order_Details>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Products>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.Products)
                .WillCascadeOnDelete(false);
        }
    }
}

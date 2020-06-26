using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Model
{
    public partial class Project0StoreContext : DbContext
    {
        public Project0StoreContext()
        {
        }

        public Project0StoreContext(DbContextOptions<Project0StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Merchandise> Merchandise { get; set; }
        public virtual DbSet<PlacedOrders> PlacedOrders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Purchased> Purchased { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__Customer__C9F284571D4C1110");

                entity.Property(e => e.UserName).HasMaxLength(26);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customerID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.InventoryId).HasColumnName("inventoryID");

                entity.Property(e => e.InStock).HasColumnName("inStock");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Address)
                    .HasName("PK__Location__7D0C3F33B4B28741");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.City).HasMaxLength(200);

                entity.Property(e => e.LocationId)
                    .HasColumnName("locationID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.State).HasMaxLength(200);
            });

            modelBuilder.Entity<Merchandise>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.InventoryId).HasColumnName("inventoryID");

                entity.Property(e => e.LocationAddress)
                    .IsRequired()
                    .HasColumnName("locationAddress")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Inventory)
                    .WithMany()
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Merchandi__inven__5DCAEF64");

                entity.HasOne(d => d.LocationAddressNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.LocationAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Merchandi__locat__5CD6CB2B");
            });

            modelBuilder.Entity<PlacedOrders>(entity =>
            {
                entity.HasKey(e => new { e.TimeOrdered, e.CustomerUsername })
                    .HasName("PK__PlacedOr__A623FB1DB68084A3");

                entity.Property(e => e.CustomerUsername).HasMaxLength(26);

                entity.Property(e => e.LocationAddress)
                    .IsRequired()
                    .HasColumnName("locationAddress")
                    .HasMaxLength(200);

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CustomerUsernameNavigation)
                    .WithMany(p => p.PlacedOrders)
                    .HasForeignKey(d => d.CustomerUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlacedOrd__Custo__5812160E");

                entity.HasOne(d => d.LocationAddressNavigation)
                    .WithMany(p => p.PlacedOrders)
                    .HasForeignKey(d => d.LocationAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlacedOrd__locat__59063A47");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Product__737584F71D99FEE9");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.MaxPerOrder).HasColumnName("maxPerOrder");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Purchased>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CustomerUsername)
                    .IsRequired()
                    .HasMaxLength(26);

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .HasMaxLength(200);

                entity.Property(e => e.TimeOrdered).HasColumnName("timeOrdered");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ProductName)
                    .HasConstraintName("FK__Purchased__produ__68487DD7");

                entity.HasOne(d => d.PlacedOrders)
                    .WithMany()
                    .HasForeignKey(d => new { d.TimeOrdered, d.CustomerUsername })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Purchased__693CA210");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.InventoryId).HasColumnName("inventoryID");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Inventory)
                    .WithMany()
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK__Stock__inventory__6E01572D");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ProductName)
                    .HasConstraintName("FK__Stock__productNa__6EF57B66");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_BoombaMarket.Models
{
    public partial class MarketplaceDBContext : DbContext
    {
        public MarketplaceDBContext()
        {
        }

        public MarketplaceDBContext(DbContextOptions<MarketplaceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<OrderShop> OrderShops { get; set; } = null!;
        public virtual DbSet<PhotoProduct> PhotoProducts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Shop> Shops { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-B4LL5OF\\MYSERVERNAME;Initial Catalog=MarketplaceDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.ToTable("Category");

                entity.Property(e => e.IdCategory).HasColumnName("ID_Category");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_category");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.IdFeedback);

                entity.ToTable("Feedback");

                entity.Property(e => e.IdFeedback).HasColumnName("ID_Feedback");

                entity.Property(e => e.Feedback1).HasColumnName("Feedback");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.ToTable("Order");

                entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.IdOrderItem);

                entity.ToTable("OrderItem");

                entity.Property(e => e.IdOrderItem).HasColumnName("ID_OrderItem");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                
            });

            modelBuilder.Entity<OrderShop>(entity =>
            {
                entity.HasKey(e => e.IdOrderShop);

                entity.ToTable("OrderShop");

                entity.Property(e => e.IdOrderShop).HasColumnName("ID_OrderShop");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.ShopId).HasColumnName("Shop_ID");

                
            });

            modelBuilder.Entity<PhotoProduct>(entity =>
            {
                entity.HasKey(e => e.IdPhotoProducts);

                entity.Property(e => e.IdPhotoProducts).HasColumnName("ID_PhotoProducts");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

               
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct).HasColumnName("ID_Product");

                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.IdProfile);

                entity.ToTable("Profile");

                entity.Property(e => e.IdProfile).HasColumnName("ID_Profile");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("Role");

                entity.Property(e => e.IdRole).HasColumnName("ID_Role");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasKey(e => e.IdShop);

                entity.ToTable("Shop");

                entity.Property(e => e.IdShop).HasColumnName("ID_Shop");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

               
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("Status");

                entity.Property(e => e.IdStatus).HasColumnName("ID_Status");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Order_status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_User");
                entity.ToTable("User");

                entity.HasIndex(e => e.Login, "UQ__User__5E55825B8518455E")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__User__A9D1053431496386")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

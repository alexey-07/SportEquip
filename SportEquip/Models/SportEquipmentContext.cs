using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SportEquip.Models;

public partial class SportEquipmentContext : DbContext
{
    public SportEquipmentContext()
    {
    }

    public SportEquipmentContext(DbContextOptions<SportEquipmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

    public virtual DbSet<ListOfSportingGood> ListOfSportingGoods { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<OrdersHistory> OrdersHistories { get; set; }

    public virtual DbSet<OrdersListOfSportingGood> OrdersListOfSportingGoods { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sport_equipment;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameCategory).HasColumnName("name_category");
        });

        modelBuilder.Entity<DeliveryAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("delivery_address_pkey");

            entity.ToTable("delivery_address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameAddress).HasColumnName("name_address");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<ListOfSportingGood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("list_of_sporting_goods_pkey");

            entity.ToTable("list_of_sporting_goods");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Articul).HasColumnName("articul");
            entity.Property(e => e.CurrentDiscount).HasColumnName("current_discount");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdManufactures).HasColumnName("id_manufactures");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.IdUnit).HasColumnName("id_unit");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.ProductName).HasColumnName("product_name");
            entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.ListOfSportingGoods)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("list_of_sporting_goods_id_category_fkey");

            entity.HasOne(d => d.IdManufacturesNavigation).WithMany(p => p.ListOfSportingGoods)
                .HasForeignKey(d => d.IdManufactures)
                .HasConstraintName("list_of_sporting_goods_id_manufactures_fkey");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.ListOfSportingGoods)
                .HasForeignKey(d => d.IdSupplier)
                .HasConstraintName("list_of_sporting_goods_id_supplier_fkey");

            entity.HasOne(d => d.IdUnitNavigation).WithMany(p => p.ListOfSportingGoods)
                .HasForeignKey(d => d.IdUnit)
                .HasConstraintName("list_of_sporting_goods_id_unit_fkey");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("manufacturers_pkey");

            entity.ToTable("manufacturers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameManufacturer).HasColumnName("name_manufacturer");
        });

        modelBuilder.Entity<OrdersHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_history_pkey");

            entity.ToTable("orders_history");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.IdDeliveryAddress).HasColumnName("id_delivery_address");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");

            entity.HasOne(d => d.IdDeliveryAddressNavigation).WithMany(p => p.OrdersHistories)
                .HasForeignKey(d => d.IdDeliveryAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_history_id_delivery_address_fkey");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.OrdersHistories)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("orders_history_id_status_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.OrdersHistories)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("orders_history_id_user_fkey");
        });

        modelBuilder.Entity<OrdersListOfSportingGood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_list_of_sporting_goods_pkey");

            entity.ToTable("orders_list_of_sporting_goods");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdListOfSportingGoods).HasColumnName("id_list_of_sporting_goods");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdListOfSportingGoodsNavigation).WithMany(p => p.OrdersListOfSportingGoods)
                .HasForeignKey(d => d.IdListOfSportingGoods)
                .HasConstraintName("orders_list_of_sporting_goods_id_list_of_sporting_goods_fkey");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrdersListOfSportingGoods)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("orders_list_of_sporting_goods_id_order_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameStatus).HasColumnName("name_status");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("suppliers_pkey");

            entity.ToTable("suppliers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameSupplier).HasColumnName("name_supplier");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("unit_pkey");

            entity.ToTable("unit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameUnit).HasColumnName("name_unit");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FirsrtName).HasColumnName("firsrt_name");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Surname).HasColumnName("surname");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("users_id_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

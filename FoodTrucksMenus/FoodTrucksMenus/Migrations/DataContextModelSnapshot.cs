﻿// <auto-generated />
using System;
using FoodTrucksMenus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameCat")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NameCat")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool?>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TruckId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClienteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDatetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusType")
                        .HasColumnType("int");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.Property<int?>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.HasIndex("TruckId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IconLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Cant")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ImagenProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("NameProd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceSale")
                        .HasColumnType("money");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("money");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MenuId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GuestNumber")
                        .HasColumnType("int");

                    b.Property<Guid?>("ImagenQR")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameTable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TruckId");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("Delivery")
                        .HasColumnType("bit");

                    b.Property<string>("ImagenLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nametruck")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TablesNumbers")
                        .HasColumnType("int");

                    b.Property<bool?>("Whatsapp")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Truck");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.TruckCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TruckId");

                    b.ToTable("TruckCategory");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.TruckPlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("PlatformId")
                        .HasColumnType("int");

                    b.Property<int?>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.HasIndex("TruckId");

                    b.ToTable("TruckPlatform");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.TruckSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int?>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("TruckId");

                    b.ToTable("TruckSchedule");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Menu", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Truck", "Truck")
                        .WithMany("Menus")
                        .HasForeignKey("TruckId");

                    b.Navigation("Category");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Order", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("TableId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Truck", "Truck")
                        .WithMany("Orders")
                        .HasForeignKey("TruckId");

                    b.Navigation("Table");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Order", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Product", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Menu", "Menu")
                        .WithMany("Products")
                        .HasForeignKey("MenuId");

                    b.Navigation("Category");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Table", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Truck", "Truck")
                        .WithMany("Tables")
                        .HasForeignKey("TruckId");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.TruckCategory", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Category", "Category")
                        .WithMany("TruckCategories")
                        .HasForeignKey("CategoryId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Truck", "Truck")
                        .WithMany("TruckCategories")
                        .HasForeignKey("TruckId");

                    b.Navigation("Category");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.TruckPlatform", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Platform", "Platform")
                        .WithMany("TruckPlatforms")
                        .HasForeignKey("PlatformId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Truck", "Truck")
                        .WithMany("TruckPlatforms")
                        .HasForeignKey("TruckId");

                    b.Navigation("Platform");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.TruckSchedule", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Schedule", "Schedule")
                        .WithMany("TruckSchedules")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Truck", "Truck")
                        .WithMany("TruckSchedules")
                        .HasForeignKey("TruckId");

                    b.Navigation("Schedule");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Category", b =>
                {
                    b.Navigation("TruckCategories");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Menu", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Platform", b =>
                {
                    b.Navigation("TruckPlatforms");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Schedule", b =>
                {
                    b.Navigation("TruckSchedules");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Table", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Truck", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("Orders");

                    b.Navigation("Tables");

                    b.Navigation("TruckCategories");

                    b.Navigation("TruckPlatforms");

                    b.Navigation("TruckSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}

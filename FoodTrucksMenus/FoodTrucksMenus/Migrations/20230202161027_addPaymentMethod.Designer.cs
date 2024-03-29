﻿// <auto-generated />
using System;
using FoodTrucksMenus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodTrucksMenus.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230202161027_addPaymentMethod")]
    partial class addPaymentMethod
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("NameBranch")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TablesNumbers")
                        .HasColumnType("int");

                    b.Property<int>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("TruckId");

                    b.HasIndex("NameBranch", "TruckId")
                        .IsUnique();

                    b.ToTable("Branches");
                });

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

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.HasIndex("Name", "StateId")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool?>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TruckId");

                    b.HasIndex("Name", "BranchId", "CategoryId")
                        .IsUnique()
                        .HasFilter("[BranchId] IS NOT NULL AND [CategoryId] IS NOT NULL");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.MenuBranchs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuBranchs");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.MenuProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("MenuId", "ProductId")
                        .IsUnique();

                    b.ToTable("MenuProducts");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("ClienteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDatetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("StatusType")
                        .HasColumnType("int");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.Property<int?>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

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

                    b.Property<bool>("Delivered")
                        .HasColumnType("bit");

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
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Platforms");
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

                    b.Property<bool>("InOfert")
                        .HasColumnType("bit");

                    b.Property<string>("NameProd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrepTime")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceOfert")
                        .HasColumnType("money");

                    b.Property<decimal>("PriceSale")
                        .HasColumnType("money");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("money");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TruckId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImagenProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
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

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Name", "CountryId")
                        .IsUnique();

                    b.ToTable("States");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("GuestNumber")
                        .HasColumnType("int");

                    b.Property<Guid?>("ImagenQR")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameTable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("TruckId");

                    b.ToTable("Tables");
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("Whatsapp")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Nametruck")
                        .IsUnique()
                        .HasFilter("[Nametruck] IS NOT NULL");

                    b.ToTable("Trucks");
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

                    b.HasIndex("TruckId", "PlatformId")
                        .IsUnique()
                        .HasFilter("[TruckId] IS NOT NULL AND [PlatformId] IS NOT NULL");

                    b.ToTable("TruckPlatforms");
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

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Branch", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodTrucksMenus.Data.Entities.Truck", "Truck")
                        .WithMany("Branch")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.City", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Menu", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Branch", null)
                        .WithMany("Menus")
                        .HasForeignKey("BranchId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Truck", "Truck")
                        .WithMany("Menu")
                        .HasForeignKey("TruckId");

                    b.Navigation("Category");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.MenuBranchs", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodTrucksMenus.Data.Entities.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.MenuProducts", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Menu", "Menu")
                        .WithMany("MenuProducts")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodTrucksMenus.Data.Entities.Product", "Product")
                        .WithMany("MenuProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Order", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Branch", null)
                        .WithMany("Orders")
                        .HasForeignKey("BranchId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("TableId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckId");

                    b.Navigation("Table");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Product", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Truck", "Truck")
                        .WithMany("Product")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.ProductImage", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.State", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Table", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.Branch", "Branch")
                        .WithMany("Tables")
                        .HasForeignKey("BranchId");

                    b.HasOne("FoodTrucksMenus.Data.Entities.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckId");

                    b.Navigation("Branch");

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

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.User", b =>
                {
                    b.HasOne("FoodTrucksMenus.Data.Entities.City", null)
                        .WithMany("Users")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Branch", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("Orders");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Category", b =>
                {
                    b.Navigation("TruckCategories");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.City", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Menu", b =>
                {
                    b.Navigation("MenuProducts");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Platform", b =>
                {
                    b.Navigation("TruckPlatforms");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Product", b =>
                {
                    b.Navigation("MenuProducts");

                    b.Navigation("ProductImages");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Schedule", b =>
                {
                    b.Navigation("TruckSchedules");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.State", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Table", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FoodTrucksMenus.Data.Entities.Truck", b =>
                {
                    b.Navigation("Branch");

                    b.Navigation("Menu");

                    b.Navigation("Product");

                    b.Navigation("TruckCategories");

                    b.Navigation("TruckPlatforms");

                    b.Navigation("TruckSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}

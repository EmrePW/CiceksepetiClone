﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

#nullable disable

namespace CiceksepetiApp.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20231225172855_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.CartLine", b =>
                {
                    b.Property<int>("CartlineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartlineID"), 1L, 1);

                    b.Property<int?>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("DeliverCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliverDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliverTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsReady")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsShipped")
                        .HasColumnType("bit");

                    b.Property<long?>("OrderID")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("CartlineID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuperCategory")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Flower",
                            SuperCategory = 0
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Fresh Flowers",
                            SuperCategory = 1
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Potted Flowers",
                            SuperCategory = 1
                        },
                        new
                        {
                            CategoryID = 5,
                            CategoryName = "Bouqets",
                            SuperCategory = 1
                        },
                        new
                        {
                            CategoryID = 6,
                            CategoryName = "Daisies",
                            SuperCategory = 1
                        },
                        new
                        {
                            CategoryID = 7,
                            CategoryName = "Orchids",
                            SuperCategory = 1
                        },
                        new
                        {
                            CategoryID = 8,
                            CategoryName = "Lilliums",
                            SuperCategory = 1
                        },
                        new
                        {
                            CategoryID = 9,
                            CategoryName = "Bonsai",
                            SuperCategory = 1
                        },
                        new
                        {
                            CategoryID = 10,
                            CategoryName = "Lavender",
                            SuperCategory = 1
                        },
                        new
                        {
                            CategoryID = 11,
                            CategoryName = "bruh",
                            SuperCategory = 1
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Bonnyfood",
                            SuperCategory = 0
                        },
                        new
                        {
                            CategoryID = 12,
                            CategoryName = "Cakes & Cookies",
                            SuperCategory = 2
                        },
                        new
                        {
                            CategoryID = 13,
                            CategoryName = "Chocolate",
                            SuperCategory = 2
                        },
                        new
                        {
                            CategoryID = 14,
                            CategoryName = "Lotus",
                            SuperCategory = 2
                        },
                        new
                        {
                            CategoryID = 15,
                            CategoryName = "Oreo",
                            SuperCategory = 2
                        },
                        new
                        {
                            CategoryID = 16,
                            CategoryName = "Kitkat",
                            SuperCategory = 2
                        });
                });

            modelBuilder.Entity("Entities.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ApplicationAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyOwner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyTradeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KEPAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MERSISNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxProvince")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VirtualCompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyID");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyID = 1,
                            Address = "",
                            ApplicationAccepted = false,
                            City = "",
                            CompanyName = "DefaultCompany",
                            CompanyType = "",
                            ContactName = "",
                            Country = "Turkey",
                            Email = "",
                            IdNumber = "",
                            KEPAddress = "",
                            PhoneNumber = "",
                            SellCategory = "",
                            TaxProvince = "Ankara",
                            UserID = "DefaultUserID"
                        },
                        new
                        {
                            CompanyID = 2,
                            Address = "",
                            ApplicationAccepted = false,
                            City = "",
                            CompanyName = "DefaultCompany2",
                            CompanyType = "",
                            ContactName = "",
                            Country = "Turkey",
                            Email = "",
                            IdNumber = "",
                            KEPAddress = "",
                            PhoneNumber = "",
                            SellCategory = "",
                            TaxProvince = "Ankara",
                            UserID = "DefaultUserID2"
                        });
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.Property<long>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrderID"), 1L, 1);

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.Property<int>("CardCVC")
                        .HasColumnType("int");

                    b.Property<string>("CardExpirationMonth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardExpirationYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyID")
                        .HasColumnType("int");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InvoiceAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Received")
                        .HasColumnType("bit");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Shipped")
                        .HasColumnType("bit");

                    b.Property<int?>("ShipperID")
                        .HasColumnType("int");

                    b.Property<int>("trackingNumber")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShipperID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<decimal?>("DiscountedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("FreeShip")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RatingCount")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuperCategory")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 3,
                            CompanyID = 1,
                            DiscountedPrice = 800m,
                            FreeShip = false,
                            ProductName = "lorem",
                            SuperCategory = 1,
                            UnitPrice = 1000m
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 5,
                            CompanyID = 1,
                            FreeShip = false,
                            ProductName = "ipsum",
                            SuperCategory = 2,
                            UnitPrice = 5000m
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 4,
                            CompanyID = 1,
                            DiscountedPrice = 230m,
                            FreeShip = false,
                            ProductName = "dolor",
                            SuperCategory = 1,
                            UnitPrice = 400m
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryID = 5,
                            CompanyID = 1,
                            FreeShip = false,
                            ProductName = "sit",
                            SuperCategory = 1,
                            UnitPrice = 400m
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryID = 4,
                            CompanyID = 1,
                            FreeShip = false,
                            ProductName = "amet",
                            SuperCategory = 1,
                            UnitPrice = 400m
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryID = 8,
                            CompanyID = 1,
                            DiscountedPrice = 1678m,
                            FreeShip = false,
                            ProductName = "contactour",
                            SuperCategory = 1,
                            UnitPrice = 2000m
                        },
                        new
                        {
                            ProductID = 7,
                            CategoryID = 12,
                            CompanyID = 1,
                            FreeShip = false,
                            ProductName = "lavender",
                            SuperCategory = 1,
                            UnitPrice = 400m
                        },
                        new
                        {
                            ProductID = 8,
                            CategoryID = 11,
                            CompanyID = 1,
                            DiscountedPrice = 543m,
                            FreeShip = false,
                            ProductName = "Test1",
                            SuperCategory = 2,
                            UnitPrice = 1255m
                        },
                        new
                        {
                            ProductID = 9,
                            CategoryID = 3,
                            CompanyID = 1,
                            DiscountedPrice = 856m,
                            FreeShip = false,
                            ProductName = "Test2",
                            SuperCategory = 2,
                            UnitPrice = 1000m
                        },
                        new
                        {
                            ProductID = 10,
                            CategoryID = 3,
                            CompanyID = 1,
                            FreeShip = false,
                            ProductName = "Test3",
                            SuperCategory = 1,
                            UnitPrice = 543m
                        },
                        new
                        {
                            ProductID = 11,
                            CategoryID = 4,
                            CompanyID = 1,
                            FreeShip = false,
                            ProductName = "Test4",
                            SuperCategory = 1,
                            UnitPrice = 100m
                        },
                        new
                        {
                            ProductID = 12,
                            CategoryID = 5,
                            CompanyID = 1,
                            FreeShip = false,
                            ProductName = "Test5",
                            SuperCategory = 2,
                            UnitPrice = 50m
                        },
                        new
                        {
                            ProductID = 13,
                            CategoryID = 4,
                            CompanyID = 1,
                            DiscountedPrice = 35m,
                            FreeShip = false,
                            ProductName = "Test6",
                            SuperCategory = 1,
                            UnitPrice = 40m
                        },
                        new
                        {
                            ProductID = 14,
                            CategoryID = 5,
                            CompanyID = 1,
                            FreeShip = false,
                            ProductName = "Test7",
                            SuperCategory = 2,
                            UnitPrice = 290m
                        },
                        new
                        {
                            ProductID = 15,
                            CategoryID = 6,
                            CompanyID = 1,
                            DiscountedPrice = 825m,
                            FreeShip = false,
                            ProductName = "Test8",
                            SuperCategory = 1,
                            UnitPrice = 954m
                        },
                        new
                        {
                            ProductID = 16,
                            CategoryID = 3,
                            CompanyID = 1,
                            DiscountedPrice = 250m,
                            FreeShip = false,
                            ProductName = "CardTest1",
                            SuperCategory = 1,
                            UnitPrice = 850m
                        },
                        new
                        {
                            ProductID = 17,
                            CategoryID = 3,
                            CompanyID = 1,
                            FreeShip = false,
                            ProductName = "CardTest2",
                            SuperCategory = 1,
                            UnitPrice = 850m
                        });
                });

            modelBuilder.Entity("Entities.Models.Rating", b =>
                {
                    b.Property<long>("RatingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RatingID"), 1L, 1);

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("IsFavourite")
                        .HasColumnType("bit");

                    b.Property<string>("Opinion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("RatingValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RatingID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductID");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Entities.Models.Shipper", b =>
                {
                    b.Property<int>("ShipperID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipperID"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipperName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShipperID");

                    b.ToTable("Shippers");

                    b.HasData(
                        new
                        {
                            ShipperID = 1,
                            PhoneNumber = "5555551234",
                            ShipperName = "Yurtici"
                        },
                        new
                        {
                            ShipperID = 2,
                            PhoneNumber = "5555556789",
                            ShipperName = "MNG"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "0d8d1d8a-6c21-4fdb-80eb-797637489609",
                            ConcurrencyStamp = "447e75a1-2059-45cf-a56c-3f20f32333b3",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "a5fe5e3b-1b64-410b-b089-74cc198bed53",
                            ConcurrencyStamp = "aba1baa4-706d-4537-ae5b-b702e261e714",
                            Name = "Corporate",
                            NormalizedName = "CORPORATE"
                        },
                        new
                        {
                            Id = "16343e77-f505-4ff1-bcf0-833f799bd5e1",
                            ConcurrencyStamp = "a7860be5-cde7-4b9e-bab4-24a70e90cf93",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Models.CartLine", b =>
                {
                    b.HasOne("Entities.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID");

                    b.HasOne("Entities.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderID");

                    b.HasOne("Entities.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.HasOne("Entities.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Entities.Models.Shipper", "Shipper")
                        .WithMany()
                        .HasForeignKey("ShipperID");

                    b.Navigation("Company");

                    b.Navigation("Customer");

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Entities.Models.Rating", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Entities.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Models.Company", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using ECommerce.InfaStructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.InfaStructure.Migrations
{
    [DbContext(typeof(WebSiteContext))]
    partial class WebSiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Security")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories", "DB");

                    b.HasData(
                        new
                        {
                            Id = new Guid("71707f88-4722-4df1-b34f-8df6341e806c"),
                            Description = "Description",
                            Name = "Category 1"
                        },
                        new
                        {
                            Id = new Guid("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"),
                            Description = "Description",
                            Name = "Category 2"
                        },
                        new
                        {
                            Id = new Guid("b41b2ba0-b99b-41d2-83b7-744dd943fc91"),
                            Description = "Description",
                            Name = "Category 3"
                        });
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Identity.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Addresses", "DB");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Identity.WebSiteUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ImageProfile")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", "Security");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders", "Security");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("PriceOfItem")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems", "Security");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double?>("Discound")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("OriginalPrice")
                        .HasColumnType("float");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quentity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", "DB");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f508d83d-0d42-49f4-8d73-c238332b8d53"),
                            CategoryId = new Guid("71707f88-4722-4df1-b34f-8df6341e806c"),
                            Name = "Product 1",
                            Price = 300.0,
                            Quentity = 27
                        },
                        new
                        {
                            Id = new Guid("ec113c17-0d52-4b86-a98b-ba2e6135b639"),
                            CategoryId = new Guid("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"),
                            Name = "Product 2",
                            Price = 150.0,
                            Quentity = 10
                        },
                        new
                        {
                            Id = new Guid("f088a3ea-6085-4ffd-9082-2a1cd45e742c"),
                            CategoryId = new Guid("b41b2ba0-b99b-41d2-83b7-744dd943fc91"),
                            Name = "Product 3",
                            Price = 150.5,
                            Quentity = 50
                        },
                        new
                        {
                            Id = new Guid("0cdb9ac8-d1e4-436e-9039-2ee6bd6647a9"),
                            CategoryId = new Guid("b41b2ba0-b99b-41d2-83b7-744dd943fc91"),
                            Name = "Product 4",
                            Price = 300.0,
                            Quentity = 100
                        },
                        new
                        {
                            Id = new Guid("2f8206af-bc7f-4edf-8688-75cee9448329"),
                            CategoryId = new Guid("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"),
                            Name = "Product 5",
                            Price = 150.90000000000001,
                            Quentity = 20
                        },
                        new
                        {
                            Id = new Guid("83680c33-bd20-4401-b553-44e2fcc072ee"),
                            CategoryId = new Guid("71707f88-4722-4df1-b34f-8df6341e806c"),
                            Name = "Product 6",
                            Price = 200.0,
                            Quentity = 5
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

                    b.ToTable("AspNetRoles", "Security");

                    b.HasData(
                        new
                        {
                            Id = "89cb02aa-154a-4ccf-92fd-981434b6ef31",
                            ConcurrencyStamp = "9752d138-83b6-4478-9d57-b186b38954ce",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "9752d138-83b6-4478-9d57-b186b38954ce",
                            ConcurrencyStamp = "89cb02aa-154a-4ccf-92fd-981434b6ef31",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", "Security");
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

                    b.ToTable("AspNetUserLogins", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "Security");
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

                    b.ToTable("AspNetUserTokens", "Security");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Identity.WebSiteUser", b =>
                {
                    b.HasOne("ECommerce.Core.Entities.Identity.Address", "Address")
                        .WithOne("User")
                        .HasForeignKey("ECommerce.Core.Entities.Identity.WebSiteUser", "AddressId");

                    b.OwnsMany("ECommerce.Core.Entities.Identity.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<string>("WebSiteUserId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime>("CreatedOn")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("ExpiredOn")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime?>("RevokedOn")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Token")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("WebSiteUserId", "Id");

                            b1.ToTable("RefreshToken", "Security");

                            b1.WithOwner()
                                .HasForeignKey("WebSiteUserId");
                        });

                    b.Navigation("Address");

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Order", b =>
                {
                    b.OwnsOne("ECommerce.Core.Entities.BusketEntities.AddressDto", "Address", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "Security");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.Core.Entities.OrderItem", b =>
                {
                    b.HasOne("ECommerce.Core.Entities.Order", null)
                        .WithMany("items")
                        .HasForeignKey("OrderId");

                    b.HasOne("ECommerce.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Product", b =>
                {
                    b.HasOne("ECommerce.Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
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
                    b.HasOne("ECommerce.Core.Entities.Identity.WebSiteUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ECommerce.Core.Entities.Identity.WebSiteUser", null)
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

                    b.HasOne("ECommerce.Core.Entities.Identity.WebSiteUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ECommerce.Core.Entities.Identity.WebSiteUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Identity.Address", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Order", b =>
                {
                    b.Navigation("items");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Furni.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Furni.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Furni.Entities.Blog", b =>
                {
                    b.Property<string>("BlogId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Blog Id");

                    b.Property<string>("BlogName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Blog Name");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("Create At");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("Update At");

                    b.Property<string>("UserIdCreated")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("User Id Created");

                    b.HasKey("BlogId");

                    b.HasIndex("UserIdCreated");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("Furni.Entities.Cart", b =>
                {
                    b.Property<string>("CartId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Cart Id");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CartId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Furni.Entities.Item", b =>
                {
                    b.Property<string>("ItemId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Item Id");

                    b.Property<string>("CartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Cart Id");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Product Id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Furni.Entities.Member", b =>
                {
                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Member Id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("First Name");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Full Name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Last Name");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Middle Name");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("URL Image");

                    b.HasKey("MemberId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Furni.Entities.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Product Id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("Is Active");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Product Name");

                    b.Property<string>("URLImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("URL Image");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Furni.Entities.Blog", b =>
                {
                    b.HasOne("Furni.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("UserIdCreated")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Furni.Entities.Item", b =>
                {
                    b.HasOne("Furni.Entities.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Furni.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryApi.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20221015165716_addprice")]
    partial class addprice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryModel.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LibraryModel.DetailsReceipt", b =>
                {
                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("receiptId")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<double>("qty")
                        .HasColumnType("float");

                    b.HasKey("productId", "receiptId");

                    b.HasIndex("receiptId");

                    b.ToTable("DetailsReceipts");
                });

            modelBuilder.Entity("LibraryModel.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LibraryModel.Receipt", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("receiptDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("receiptPrice")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("LibraryModel.DetailsReceipt", b =>
                {
                    b.HasOne("LibraryModel.Product", "Product")
                        .WithMany("Detailsreceipts")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryModel.Receipt", "Receipt")
                        .WithMany("Detailsreceipts")
                        .HasForeignKey("receiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("LibraryModel.Product", b =>
                {
                    b.HasOne("LibraryModel.Category", "Category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LibraryModel.Product", b =>
                {
                    b.Navigation("Detailsreceipts");
                });

            modelBuilder.Entity("LibraryModel.Receipt", b =>
                {
                    b.Navigation("Detailsreceipts");
                });
#pragma warning restore 612, 618
        }
    }
}
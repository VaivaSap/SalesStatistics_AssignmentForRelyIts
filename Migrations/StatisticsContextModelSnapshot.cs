﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesStatistics;

#nullable disable

namespace SalesStatistics.Migrations
{
    [DbContext(typeof(StatisticsContext))]
    partial class StatisticsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SalesStatistics.Models.SummaryOfTheDay", b =>
                {
                    b.Property<Guid>("SummaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoreID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalItems")
                        .HasColumnType("int");

                    b.Property<int>("TotalReceipts")
                        .HasColumnType("int");

                    b.HasKey("SummaryId");

                    b.ToTable("SummaryOfTheDay");
                });

            modelBuilder.Entity("SalesStatistics.Receipt", b =>
                {
                    b.Property<string>("TransactionNr")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Items")
                        .HasColumnType("int");

                    b.Property<int>("StoreID")
                        .HasColumnType("int");

                    b.HasKey("TransactionNr");

                    b.ToTable("Receipt");
                });
#pragma warning restore 612, 618
        }
    }
}

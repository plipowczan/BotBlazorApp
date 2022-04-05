﻿// <auto-generated />
using System;
using BotBlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BotBlazorApp.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BotBlazorApp.Data.BotChartDataEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("EMA200")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EmaInDown")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EmaInUp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EmaOutDown")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EmaOutUp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("EntryPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ExitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("HighPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LastPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("TimeStamp")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("BotChartData");
                });
#pragma warning restore 612, 618
        }
    }
}

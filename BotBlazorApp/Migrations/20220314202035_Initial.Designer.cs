﻿// <auto-generated />
using System;
using BotBlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BotBlazorApp.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20220314202035_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BotBlazorApp.Data.BotChartData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("EMA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EntryPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ExitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HighPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LastPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SuperTrend")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VWAP")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("BotChartDatas");
                });
#pragma warning restore 612, 618
        }
    }
}

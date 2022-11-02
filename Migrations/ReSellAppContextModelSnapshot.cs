﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReSell.Models;

namespace ReSellApp.Migrations
{
    [DbContext(typeof(ReSellAppContext))]
    partial class ReSellAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReSell.Models.GarageSales", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("Date")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("SellersID")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("Zipcode")
                        .HasColumnType("int")
                        .HasMaxLength(5);

                    b.HasKey("ID");

                    b.HasIndex("SellersID");

                    b.ToTable("GarageSales");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "555 Bounty Blvd.",
                            City = "Traverse City",
                            Date = 0,
                            Description = "We have womens, mens, and childrens clothes.  Used Furniture, pet crate, lawn equipment, dvds, kitchenware, lamps, wall decor, and more knick knacks.",
                            SellersID = 1,
                            Time = -100,
                            Zipcode = 49684
                        });
                });

            modelBuilder.Entity("ReSell.Models.Sellers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sellers");

                    b.HasData(
                        new
                        {
                            ID = 1
                        },
                        new
                        {
                            ID = 2
                        });
                });

            modelBuilder.Entity("ReSell.Models.Trade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("SellersID")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("TradeItem")
                        .IsRequired()
                        .HasColumnName("Trade Item")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Zipcode")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SellersID");

                    b.ToTable("Trades");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Traverse City",
                            Description = "I would like to trade my 2018 Kubota ZD1211 Lawn Mower, which I paid $18,900 for in 2018, only used at home, and is worth around $13,500 used.  I sold my home and no longer need this.I am in need of a pickup truck or suv for the winter season.",
                            SellersID = 1,
                            State = "MI",
                            TradeItem = "Lawn Mower",
                            Zipcode = 49686
                        });
                });

            modelBuilder.Entity("ReSellApp.Models.ForSale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SaleItem")
                        .IsRequired()
                        .HasColumnName("Sale Item")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("SellersID")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<int>("Zipcode")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SellersID");

                    b.ToTable("ForSale");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Malibu Point",
                            Description = " ARC reactor miniaturized into a small electromagnet with an energy output of 8 gigajoules per second.",
                            Email = "ironman@jarvis.com",
                            Price = 36000000,
                            SaleItem = "ARC reactor",
                            SellersID = 2,
                            State = "CA",
                            Zipcode = 90265
                        });
                });

            modelBuilder.Entity("ReSell.Models.GarageSales", b =>
                {
                    b.HasOne("ReSell.Models.Sellers", "Sellers")
                        .WithMany()
                        .HasForeignKey("SellersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReSell.Models.Trade", b =>
                {
                    b.HasOne("ReSell.Models.Sellers", "Sellers")
                        .WithMany()
                        .HasForeignKey("SellersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReSellApp.Models.ForSale", b =>
                {
                    b.HasOne("ReSell.Models.Sellers", "Sellers")
                        .WithMany()
                        .HasForeignKey("SellersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

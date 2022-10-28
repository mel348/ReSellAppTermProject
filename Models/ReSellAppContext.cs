using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using ReSellApp.Models;

namespace ReSell.Models
{
    public class ReSellAppContext : DbContext
    {
        public ReSellAppContext(DbContextOptions<ReSellAppContext> options) : base(options) { }
        public DbSet<Sellers> Sellers { get; set; }
        public DbSet<GarageSales> GarageSales { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<ForSale> ForSale { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sellers>().HasData(
                new Sellers { ID = 1},
                new Sellers { ID = 2}
                );
            modelBuilder.Entity<GarageSales>().HasData(
                new GarageSales
                {
                    ID = 1,
                    PostingTitle = "Misc. Items",
                    Date = 01 / 01 / 2023,
                    Time = 100 - 200,
                    Address = "555 Bounty Blvd.",
                    City = "Traverse City",
                    Zipcode = 49684,
                    Description = "We have womens, mens, and childrens clothes.  Used Furniture, pet crate, lawn equipment, dvds, kitchenware, lamps, wall decor, and more knick knacks.",
                    SellersID = 1
                }
                ); 
            modelBuilder.Entity<Trade>().HasData(
                new Trade
                {
                    ID = 1,
                    TradeItem = "Lawn Mower",
                    City = "Traverse City",
                    Zipcode = 49686,
                    State = "MI",
                    Description = "I would like to trade my 2018 Kubota ZD1211 Lawn Mower, " +
                    "which I paid $18,900 for in 2018, only used at home, and is worth around $13,500 used.  I sold my home and no longer need this." +
                    "I am in need of a pickup truck or suv for the winter season.",
                    SellersID = 1
                }
                );
            modelBuilder.Entity<ForSale>().HasData(
                new ForSale
                {
                    ID = 1,
                    SaleItem = "ARC reactor",
                    City = "Malibu Point",
                    State = "CA",
                    Zipcode = 90265,
                    Price = 36000000,
                    Description = " ARC reactor miniaturized into a small electromagnet with an energy output of 8 gigajoules per second.",
                    Email = "ironman@jarvis.com",
                    SellersID = 2
                }
                );
        }
    }
}
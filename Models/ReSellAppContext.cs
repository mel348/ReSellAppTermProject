using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace ReSell.Models
{
    public class ReSellAppContext : DbContext
    {
        public ReSellAppContext(DbContextOptions<ReSellAppContext> options) : base(options) { }
        public DbSet<Sellers> Sellers { get; set; }
        public DbSet<GarageSales> GarageSales { get; set; }
        public DbSet<Trade> Trades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sellers>().HasData(
                new Sellers
                {
                    ID = 1
                }
                );
            modelBuilder.Entity<GarageSales>().HasData(
                new GarageSales
                {
                    ID = 1,
                    PostingTitle = "",
                    Date = 01/01/2023,
                    Time = 100-200,
                    Address = "555 Bounty Blvd.",
                    City = "Traverse City",
                    Zipcode = 49684,
                    Description = "We have womens, mens, and childrens clothes.  Used Furniture, pet crate, lawn equipment, dvds, kitchenware, lamps, wall decor, and more knick knacks.",
                    SellersID = 1
                }
                ); ;
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
        }
    }
}
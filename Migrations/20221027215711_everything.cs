using Microsoft.EntityFrameworkCore.Migrations;

namespace ReSellApp.Migrations
{
    public partial class everything : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    City = table.Column<string>(maxLength: 10, nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    Zipcode = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ForSale",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleItem = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    Zipcode = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    SellersID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForSale", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ForSale_Sellers_SellersID",
                        column: x => x.SellersID,
                        principalTable: "Sellers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GarageSales",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostingTitle = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    Zipcode = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Date = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    SellersID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageSales", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GarageSales_Sellers_SellersID",
                        column: x => x.SellersID,
                        principalTable: "Sellers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeItem = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    Zipcode = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    SellersID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trades_Sellers_SellersID",
                        column: x => x.SellersID,
                        principalTable: "Sellers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "ID", "City", "Email", "Name", "State", "Zipcode" },
                values: new object[] { 1, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "ID", "City", "Email", "Name", "State", "Zipcode" },
                values: new object[] { 2, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "ForSale",
                columns: new[] { "ID", "City", "Description", "Email", "Price", "SaleItem", "SellersID", "State", "Zipcode" },
                values: new object[] { 1, "Malibu Point", " ARC reactor miniaturized into a small electromagnet with an energy output of 8 gigajoules per second.", "ironman@jarvis.com", 36000000, "ARC reactor", 2, "CA", 90265 });

            migrationBuilder.InsertData(
                table: "GarageSales",
                columns: new[] { "ID", "Address", "City", "Date", "Description", "PostingTitle", "SellersID", "State", "Time", "Zipcode" },
                values: new object[] { 1, "555 Bounty Blvd.", "Traverse City", 0, "We have womens, mens, and childrens clothes.  Used Furniture, pet crate, lawn equipment, dvds, kitchenware, lamps, wall decor, and more knick knacks.", "Misc. Items", 1, null, -100, 49684 });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "ID", "City", "Description", "SellersID", "State", "TradeItem", "Zipcode" },
                values: new object[] { 1, "Traverse City", "I would like to trade my 2018 Kubota ZD1211 Lawn Mower, which I paid $18,900 for in 2018, only used at home, and is worth around $13,500 used.  I sold my home and no longer need this.I am in need of a pickup truck or suv for the winter season.", 1, "MI", "Lawn Mower", 49686 });

            migrationBuilder.CreateIndex(
                name: "IX_ForSale_SellersID",
                table: "ForSale",
                column: "SellersID");

            migrationBuilder.CreateIndex(
                name: "IX_GarageSales_SellersID",
                table: "GarageSales",
                column: "SellersID");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_SellersID",
                table: "Trades",
                column: "SellersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForSale");

            migrationBuilder.DropTable(
                name: "GarageSales");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}

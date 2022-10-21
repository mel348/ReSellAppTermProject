using Microsoft.EntityFrameworkCore.Migrations;

namespace ReSellApp.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "ID", "City", "Description", "SellersID", "State", "TradeItem", "Zipcode" },
                values: new object[] { 1, "Traverse City", "I would like to trade my 2018 Kubota ZD1211 Lawn Mower, which I paid $18,900 for in 2018, only used at home, and is worth around $13,500 used.  I sold my home and no longer need this.I am in need of a pickup truck or suv for the winter season.", 1, "MI", "Lawn Mower", 49686 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "ID", "City", "Email", "Name", "State", "Zipcode" },
                values: new object[] { 3, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "ID",
                keyValue: 1,
                column: "SellersID",
                value: 3);
        }
    }
}

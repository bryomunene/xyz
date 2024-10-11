using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyz.Migrations
{
    public partial class SeedPaymentNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PaymentNotifications",
                columns: new[] { "Id", "Amount", "Currency", "CustomerId", "PaymentMethod", "Status", "Timestamp", "TransactionId" },
                values: new object[,]
                {
                    { 1, 100.00m, "USD", "cust_001", "Credit Card", "Completed", new DateTime(2024, 10, 11, 15, 20, 45, 702, DateTimeKind.Utc).AddTicks(138), "txn_001" },
                    { 2, 200.00m, "EUR", "cust_002", "PayPal", "Pending", new DateTime(2024, 10, 11, 15, 20, 45, 702, DateTimeKind.Utc).AddTicks(141), "txn_002" }
                });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 11, 15, 20, 45, 701, DateTimeKind.Utc).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 11, 15, 20, 45, 701, DateTimeKind.Utc).AddTicks(9792));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentNotifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentNotifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 11, 15, 18, 12, 706, DateTimeKind.Utc).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 11, 15, 18, 12, 706, DateTimeKind.Utc).AddTicks(8428));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryDomain.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Billitems",
                table: "Billitems");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "BillDate",
                table: "Bills",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Billitems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billitems",
                table: "Billitems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Billitems_BillId",
                table: "Billitems",
                column: "BillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Billitems",
                table: "Billitems");

            migrationBuilder.DropIndex(
                name: "IX_Billitems_BillId",
                table: "Billitems");

            migrationBuilder.DropColumn(
                name: "BillDate",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Billitems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billitems",
                table: "Billitems",
                columns: new[] { "BillId", "ItemId" });
        }
    }
}

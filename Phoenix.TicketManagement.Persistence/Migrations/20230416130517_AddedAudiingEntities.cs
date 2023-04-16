using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.TicketManagement.Persistence.Migrations
{
    public partial class AddedAudiingEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("8c65344a-450a-40b8-9c07-77a0713845ac"),
                column: "Date",
                value: new DateTime(2023, 8, 16, 9, 5, 17, 419, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("9a6d5e78-f41f-4b6a-b293-334af471fe43"),
                column: "Date",
                value: new DateTime(2023, 7, 16, 9, 5, 17, 419, DateTimeKind.Local).AddTicks(614));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e2c5a011-5bf2-48d8-9865-60f78439eee2"),
                column: "Date",
                value: new DateTime(2023, 8, 16, 9, 5, 17, 419, DateTimeKind.Local).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("f2b17009-8a66-489a-a0a8-70afcf57e4dd"),
                column: "Date",
                value: new DateTime(2023, 10, 16, 9, 5, 17, 419, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7b88a61e-a89d-4205-aa2c-a99bef759c7c"),
                column: "DatePlaced",
                value: new DateTime(2023, 4, 16, 9, 5, 17, 419, DateTimeKind.Local).AddTicks(658));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("d66f6719-543a-4632-84d5-dd513c55eab1"),
                column: "DatePlaced",
                value: new DateTime(2023, 4, 16, 9, 5, 17, 419, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ffa495fa-06d9-41aa-b701-6776b26dbe1b"),
                column: "DatePlaced",
                value: new DateTime(2023, 4, 16, 9, 5, 17, 419, DateTimeKind.Local).AddTicks(648));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("8c65344a-450a-40b8-9c07-77a0713845ac"),
                column: "Date",
                value: new DateTime(2023, 8, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("9a6d5e78-f41f-4b6a-b293-334af471fe43"),
                column: "Date",
                value: new DateTime(2023, 7, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e2c5a011-5bf2-48d8-9865-60f78439eee2"),
                column: "Date",
                value: new DateTime(2023, 8, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7242));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("f2b17009-8a66-489a-a0a8-70afcf57e4dd"),
                column: "Date",
                value: new DateTime(2023, 10, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7191));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7b88a61e-a89d-4205-aa2c-a99bef759c7c"),
                column: "DatePlaced",
                value: new DateTime(2023, 4, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("d66f6719-543a-4632-84d5-dd513c55eab1"),
                column: "DatePlaced",
                value: new DateTime(2023, 4, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ffa495fa-06d9-41aa-b701-6776b26dbe1b"),
                column: "DatePlaced",
                value: new DateTime(2023, 4, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7292));
        }
    }
}

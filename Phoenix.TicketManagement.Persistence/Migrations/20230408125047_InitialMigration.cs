using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Phoenix.TicketManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderTotal = table.Column<int>(type: "int", nullable: false),
                    DatePlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPaid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("6aa56663-47d2-4e38-a5bd-376f2e05cdb1"), "Musicals" },
                    { new Guid("9983a002-ed2d-4754-821a-bba7414eaf56"), "Concerts" },
                    { new Guid("b836b3d4-4057-41e6-a41d-ab078cb3383e"), "Plays" },
                    { new Guid("d076ec67-8e10-4a27-92b1-125f74834ee3"), "Converences" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "CreatedDate", "DatePlaced", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderTotal", "UserId" },
                values: new object[,]
                {
                    { new Guid("7b88a61e-a89d-4205-aa2c-a99bef759c7c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7302), null, null, true, 135, new Guid("9337c530-ea04-43ca-bbe2-23947f80b53f") },
                    { new Guid("d66f6719-543a-4632-84d5-dd513c55eab1"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7279), null, null, true, 400, new Guid("6fa95748-c491-4d78-9c6c-915af51445ae") },
                    { new Guid("ffa495fa-06d9-41aa-b701-6776b26dbe1b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7292), null, null, true, 180, new Guid("6eeb8afc-0660-4008-a4de-a74744c49183") }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("8c65344a-450a-40b8-9c07-77a0713845ac"), "Mike Doe", new Guid("9983a002-ed2d-4754-821a-bba7414eaf56"), new DateTime(2023, 8, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7252), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "https://mmo.aiircdn.com/248/611aae2ddb3ff.jpg", "The DJ: Mike", 150 },
                    { new Guid("9a6d5e78-f41f-4b6a-b293-334af471fe43"), "James Bond", new Guid("9983a002-ed2d-4754-821a-bba7414eaf56"), new DateTime(2023, 7, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7262), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "https://static.lpnt.fr/images/2021/05/29/21769500lpw-21769504-article-concert-covid19-indochine-jpg_7994906_660x281.jpg", "Clash of the DJ Clanes", 90 },
                    { new Guid("e2c5a011-5bf2-48d8-9865-60f78439eee2"), "Micheal Jordan", new Guid("9983a002-ed2d-4754-821a-bba7414eaf56"), new DateTime(2023, 8, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7242), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "https://cdn.vox-cdn.com/thumbor/nuohEKEEjxBm3nj4VUUwvmloOhg=/1400x788/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/15795164/concert.0.1462605431.jpg", "The Artist: Michel Jordan", 100 },
                    { new Guid("f2b17009-8a66-489a-a0a8-70afcf57e4dd"), "John Eienstine", new Guid("9983a002-ed2d-4754-821a-bba7414eaf56"), new DateTime(2023, 10, 8, 8, 50, 47, 514, DateTimeKind.Local).AddTicks(7191), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "https://www.billboard.com/wp-content/uploads/2021/08/Princess-Nokia-by-Roger-Ho-for-Lollapalooza-2021-billboard-1548-1628011374.jpg", "J B E Live", 65 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courseWork.Migrations
{
    /// <inheritdoc />
    public partial class JewelleryBasketOrderClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketEntityJewelleryEntity",
                columns: table => new
                {
                    BasketsId = table.Column<int>(type: "int", nullable: false),
                    JewelleriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketEntityJewelleryEntity", x => new { x.BasketsId, x.JewelleriesId });
                    table.ForeignKey(
                        name: "FK_BasketEntityJewelleryEntity_BasketDB_BasketsId",
                        column: x => x.BasketsId,
                        principalTable: "BasketDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketEntityJewelleryEntity_JewelleryDB_JewelleriesId",
                        column: x => x.JewelleriesId,
                        principalTable: "JewelleryDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderEntity_ClientDB_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketEntityOrderEntity",
                columns: table => new
                {
                    BasketsId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketEntityOrderEntity", x => new { x.BasketsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_BasketEntityOrderEntity_BasketDB_BasketsId",
                        column: x => x.BasketsId,
                        principalTable: "BasketDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketEntityOrderEntity_OrderEntity_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "OrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketEntityJewelleryEntity_JewelleriesId",
                table: "BasketEntityJewelleryEntity",
                column: "JewelleriesId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketEntityOrderEntity_OrdersId",
                table: "BasketEntityOrderEntity",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_ClientId",
                table: "OrderEntity",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketEntityJewelleryEntity");

            migrationBuilder.DropTable(
                name: "BasketEntityOrderEntity");

            migrationBuilder.DropTable(
                name: "BasketDB");

            migrationBuilder.DropTable(
                name: "OrderEntity");

            migrationBuilder.DropTable(
                name: "ClientDB");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp1.Migrations
{
    public partial class InitM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addres",
                columns: table => new
                {
                    AddresID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HomeNumber = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    FlatNumber = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addres", x => x.AddresID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    ClientLName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClientFName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ClientPatronumic = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ClientPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    IngredientName = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientID);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaID = table.Column<int>(type: "int", nullable: false),
                    PizzaName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaID);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false),
                    SizeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "ClientAddres",
                columns: table => new
                {
                    ClientAddresID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    AddresID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddres", x => x.ClientAddresID);
                    table.ForeignKey(
                        name: "FK_ClientAddres_Addres",
                        column: x => x.AddresID,
                        principalTable: "Addres",
                        principalColumn: "AddresID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddres_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngredient",
                columns: table => new
                {
                    PizzaIngredientID = table.Column<int>(type: "int", nullable: false),
                    PizzaID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngredient", x => x.PizzaIngredientID);
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Ingredient",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Pizza",
                        column: x => x.PizzaID,
                        principalTable: "Pizza",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PizzaAssortiment",
                columns: table => new
                {
                    PizzaAssortimentID = table.Column<int>(type: "int", nullable: false),
                    PizzaID = table.Column<int>(type: "int", nullable: false),
                    PizzaSizeID = table.Column<int>(type: "int", nullable: false),
                    PizzaWeight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaAssortiment", x => x.PizzaAssortimentID);
                    table.ForeignKey(
                        name: "FK_PizzaAssortiment_Pizza",
                        column: x => x.PizzaID,
                        principalTable: "Pizza",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PizzaAssortiment_Size",
                        column: x => x.PizzaSizeID,
                        principalTable: "Size",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PizzaOrder",
                columns: table => new
                {
                    PizzaOrderID = table.Column<int>(type: "int", nullable: false),
                    PizzaAssortimentID = table.Column<int>(type: "int", nullable: false),
                    PizzaCount = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    ClientAddresID = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrder", x => x.PizzaOrderID);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_ClientAddres",
                        column: x => x.ClientAddresID,
                        principalTable: "ClientAddres",
                        principalColumn: "ClientAddresID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_PizzaAssortiment",
                        column: x => x.PizzaAssortimentID,
                        principalTable: "PizzaAssortiment",
                        principalColumn: "PizzaAssortimentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddres_AddresID",
                table: "ClientAddres",
                column: "AddresID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddres_ClientID",
                table: "ClientAddres",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaAssortiment_PizzaID",
                table: "PizzaAssortiment",
                column: "PizzaID");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaAssortiment_PizzaSizeID",
                table: "PizzaAssortiment",
                column: "PizzaSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredient_IngredientID",
                table: "PizzaIngredient",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredient_PizzaID",
                table: "PizzaIngredient",
                column: "PizzaID");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_ClientAddresID",
                table: "PizzaOrder",
                column: "ClientAddresID");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_PizzaAssortimentID",
                table: "PizzaOrder",
                column: "PizzaAssortimentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaIngredient");

            migrationBuilder.DropTable(
                name: "PizzaOrder");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "ClientAddres");

            migrationBuilder.DropTable(
                name: "PizzaAssortiment");

            migrationBuilder.DropTable(
                name: "Addres");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}

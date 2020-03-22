using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class CreateBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    brand_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.store_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(nullable: true),
                    model_year = table.Column<int>(nullable: false),
                    list_price = table.Column<decimal>(nullable: false),
                    brand_id = table.Column<int>(nullable: false),
                    category_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_brands_brand_id",
                        column: x => x.brand_id,
                        principalTable: "brands",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                columns: table => new
                {
                    staff_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    manager_id = table.Column<int>(nullable: true),
                    store_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffs", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK_staffs_stores_store_id",
                        column: x => x.store_id,
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks", x => new { x.store_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_stocks_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stocks_stores_store_id",
                        column: x => x.store_id,
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_status = table.Column<string>(nullable: true),
                    order_date = table.Column<DateTime>(nullable: true),
                    required_date = table.Column<DateTime>(nullable: true),
                    shipped_date = table.Column<DateTime>(nullable: true),
                    customer_id = table.Column<int>(nullable: false),
                    store_id = table.Column<int>(nullable: false),
                    staff_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_order_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_staffs_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staffs",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_stores_store_id",
                        column: x => x.store_id,
                        principalTable: "stores",
                        principalColumn: "store_id");
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false),
                    order_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    list_price = table.Column<decimal>(nullable: false),
                    discount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_order_items_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_items_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "brand_id", "brand_name" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Audi" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { 1, "Car" },
                    { 2, "Bicycle" }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "customer_id", "city", "email", "first_name", "last_name", "phone", "state", "street", "zip_code" },
                values: new object[,]
                {
                    { 1, "Kharkiv", "ivan@i.van", "Ivan", "Ivanov", "0987654", "UK", "23 Seprnya", "8976" },
                    { 2, "Kharkiv", "pet@r.ov", "Petr", "Petrov", "0987654", "UK", "23 Seprnya", "8976" }
                });

            migrationBuilder.InsertData(
                table: "stores",
                columns: new[] { "store_id", "city", "email", "store_name", "phone", "state", "street", "zip_code" },
                values: new object[,]
                {
                    { 1, "Kharkiv", "klass.com", "Klass", "0987654", "UK", "23 Seprnya", "8976" },
                    { 2, "Kharkiv", "rost.com", "Rost", "0578u56767", "UK", "23 Seprnya", "0986" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "product_id", "brand_id", "category_id", "list_price", "model_year", "product_name" },
                values: new object[,]
                {
                    { 1, 2, 1, 20m, 2015, "TT" },
                    { 2, 1, 2, 20m, 2020, "GS750" }
                });

            migrationBuilder.InsertData(
                table: "staffs",
                columns: new[] { "staff_id", "active", "email", "first_name", "last_name", "manager_id", "phone", "store_id" },
                values: new object[,]
                {
                    { 1, true, "e.zub", "Elena", "Zub", null, "0987577586245", 1 },
                    { 2, false, "e.reshetilo", "Oleg", "Reshetilo", null, "7756996595", 2 },
                    { 3, false, "e.borisov", "Boris", "Borisov", null, "098756344245", 2 }
                });

            migrationBuilder.InsertData(
                table: "order",
                columns: new[] { "order_id", "customer_id", "order_date", "required_date", "shipped_date", "staff_id", "order_status", "store_id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 3, 21, 20, 55, 3, 194, DateTimeKind.Local).AddTicks(5159), new DateTime(2020, 3, 21, 20, 55, 3, 196, DateTimeKind.Local).AddTicks(8206), new DateTime(2020, 3, 21, 20, 55, 3, 196, DateTimeKind.Local).AddTicks(8779), 1, "Wait delivery", 1 },
                    { 4, 2, new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(956), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(958), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(961), 1, "In processing", 2 },
                    { 9, 2, new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(999), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(1001), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(1004), 1, "Wait delivery", 2 },
                    { 2, 2, new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(876), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(898), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(910), 2, "Delivered", 2 },
                    { 3, 1, new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(946), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(949), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(952), 2, "In processing", 2 },
                    { 5, 1, new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(965), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(967), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(970), 2, "Delivered", 2 },
                    { 6, 2, new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(973), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(976), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(978), 2, "In processing", 2 },
                    { 7, 2, new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(981), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(984), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(987), 2, "done", 2 },
                    { 8, 2, new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(990), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(993), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(996), 2, "done", 2 },
                    { 10, 2, new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(1007), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(1009), new DateTime(2020, 3, 21, 20, 55, 3, 197, DateTimeKind.Local).AddTicks(1012), 2, "Wait delivery", 1 }
                });

            migrationBuilder.InsertData(
                table: "stocks",
                columns: new[] { "store_id", "product_id", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 1, 14 },
                    { 1, 2, 12 },
                    { 2, 2, 7 }
                });

            migrationBuilder.InsertData(
                table: "order_items",
                columns: new[] { "order_id", "product_id", "discount", "list_price", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 120m, 20m, 5 },
                    { 4, 1, 3m, 30m, 10 },
                    { 9, 2, 17m, 30m, 10 },
                    { 2, 2, 3m, 30m, 10 },
                    { 3, 2, 3m, 30m, 10 },
                    { 5, 2, 39m, 30m, 10 },
                    { 6, 1, 3m, 30m, 10 },
                    { 7, 2, 31m, 27m, 10 },
                    { 8, 2, 32m, 30m, 10 },
                    { 10, 2, 10m, 30m, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_customer_id",
                table: "order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_staff_id",
                table: "order",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_store_id",
                table: "order",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_product_id",
                table: "order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_brand_id",
                table: "products",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_store_id",
                table: "staffs",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_product_id",
                table: "stocks",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "staffs");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "stores");
        }
    }
}

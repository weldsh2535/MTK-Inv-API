using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MTK_Delivery.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phonenumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    balance = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "functionality",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    compName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_functionality", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    picture = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: true),
                    parentcategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LookupCatagory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    picture = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: true),
                    remark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupCatagory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    balance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    agreement = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    commission = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    registeredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    active = table.Column<bool>(type: "bool", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vendorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phonenumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    website = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    balance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lookup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lookup", x => x.id);
                    table.ForeignKey(
                        name: "FK_lookup_LookupCatagory_type",
                        column: x => x.type,
                        principalTable: "LookupCatagory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userRole",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    funId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRole", x => x.id);
                    table.ForeignKey(
                        name: "FK_userRole_functionality_funId",
                        column: x => x.funId,
                        principalTable: "functionality",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRole_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdSetting",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voucherTypeId = table.Column<int>(type: "int", nullable: false),
                    prefix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    length = table.Column<int>(type: "int", nullable: false),
                    suffix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    currentId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdSetting", x => x.id);
                    table.ForeignKey(
                        name: "FK_IdSetting_lookup_voucherTypeId",
                        column: x => x.voucherTypeId,
                        principalTable: "lookup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemCode = table.Column<string>(type: "nvarchar(50)",maxLength:50,nullable:false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AmaricName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    cost = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CatagoryId = table.Column<int>(type: "int", nullable: false),
                    discrption = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    picture = table.Column<string>(type: "nvarchar(max)", maxLength: 5000000, nullable: true),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    storeid = table.Column<int>(type: "int", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Items_ItemCategory_CatagoryId",
                        column: x => x.CatagoryId,
                        principalTable: "ItemCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_lookup_storeid",
                        column: x => x.storeid,
                        principalTable: "lookup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vocher",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vocherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    subTotal = table.Column<double>(type: "float", nullable: false),
                    taxAmount = table.Column<double>(type: "float", nullable: false),
                    grandTotal = table.Column<double>(type: "float", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vocherTypeId = table.Column<int>(type: "int", nullable: false),
                    vendorId = table.Column<int>(type: "int",  nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocher", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vocher_lookup_vocherTypeId",
                        column: x => x.vocherTypeId,
                        principalTable: "lookup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddStock",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(type: "int", nullable: false),
                    NewQuantity = table.Column<int>(type: "int", nullable: false),
                    addStockNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddStock", x => x.id);
                    table.ForeignKey(
                        name: "FK_AddStock_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountSheet",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(type: "int", nullable: false),
                    sheetNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    countQty = table.Column<int>(type: "int", nullable: false),
                    storeId = table.Column<int>(type: "int", nullable: false),
                    systemQty = table.Column<int>(type: "int", nullable: false),
                    differenceQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountSheet", x => x.id);
                    table.ForeignKey(
                        name: "FK_CountSheet_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountSheet_lookup_storeId",
                        column: x => x.storeId,
                        principalTable: "lookup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemLocation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<int>(type: "int)",nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLocation", x => x.id);
                    table.ForeignKey(
                        name: "FK_ItemLocation_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemStoreBalance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(type: "int", nullable: false),
                    beginingQuantity = table.Column<int>(type: "int", nullable: false),
                    currentQuantity = table.Column<int>(type: "int", nullable: false),
                    storeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStoreBalance", x => x.id);
                    table.ForeignKey(
                        name: "FK_ItemStoreBalance_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemStoreBalance_lookup_storeId",
                        column: x => x.storeId,
                        principalTable: "lookup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockAdjustment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transactionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    transactionNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    itemId = table.Column<int>(type: "int", nullable: false),
                    store = table.Column<int>(type: "int", nullable: false),
                    QuantityBefore = table.Column<int>(type: "int", nullable: false),
                    QuantityAfter = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustment", x => x.id);
                    table.ForeignKey(
                        name: "FK_StockAdjustment_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockAdjustment_lookup_store",
                        column: x => x.store,
                        principalTable: "lookup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "storeTransfer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(type: "int", nullable: false),
                    storeTransferId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    toStoreId = table.Column<int>(type: "int", nullable: false),
                    fromStoreId = table.Column<int>(type: "int", nullable: false),
                    AssignTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storeTransfer", x => x.id);
                    table.ForeignKey(
                        name: "FK_storeTransfer_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_storeTransfer_lookup_fromStoreId",
                        column: x => x.fromStoreId,
                        principalTable: "lookup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_storeTransfer_lookup_toStoreId",
                        column: x => x.toStoreId,
                        principalTable: "lookup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vocherStoreTransation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(type: "int", nullable: false),
                    vocherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fromStoreId = table.Column<int>(type: "int", nullable: false),
                    toStoreId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vocherStoreTransation", x => x.id);
                    table.ForeignKey(
                        name: "FK_vocherStoreTransation_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paymentHistories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vocherId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    vendorId = table.Column<int>(type: "int", nullable: false),
                    paymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    amountPaid = table.Column<double>(type: "float", nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    balance = table.Column<int>(type: "int", nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentHistories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vocherId = table.Column<int>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    itemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    taxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_LineItem_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1,1"),
                    To = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Email", x => x.id);
                 });
       

            migrationBuilder.CreateIndex(
                name: "IX_AddStock_itemId",
                table: "AddStock",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_CountSheet_itemId",
                table: "CountSheet",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_CountSheet_storeId",
                table: "CountSheet",
                column: "storeId");

            migrationBuilder.CreateIndex(
                name: "IX_IdSetting_voucherTypeId",
                table: "IdSetting",
                column: "voucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocation_itemId",
                table: "ItemLocation",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CatagoryId",
                table: "Items",
                column: "CatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_storeid",
                table: "Items",
                column: "storeid");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStoreBalance_itemId",
                table: "ItemStoreBalance",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStoreBalance_storeId",
                table: "ItemStoreBalance",
                column: "storeId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_itemId",
                table: "LineItem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_vocherId",
                table: "LineItem",
                column: "vocherId");

            migrationBuilder.CreateIndex(
                name: "IX_lookup_type",
                table: "lookup",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustment_itemId",
                table: "StockAdjustment",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustment_store",
                table: "StockAdjustment",
                column: "store");

            migrationBuilder.CreateIndex(
                name: "IX_storeTransfer_fromStoreId",
                table: "storeTransfer",
                column: "fromStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_storeTransfer_itemId",
                table: "storeTransfer",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_storeTransfer_toStoreId",
                table: "storeTransfer",
                column: "toStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_userRole_funId",
                table: "userRole",
                column: "funId");

            migrationBuilder.CreateIndex(
                name: "IX_userRole_userId",
                table: "userRole",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocher_userId",
                table: "Vocher",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocher_vocherTypeId",
                table: "Vocher",
                column: "vocherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_vocherStoreTransation_fromStoreId",
                table: "vocherStoreTransation",
                column: "fromStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_vocherStoreTransation_itemId",
                table: "vocherStoreTransation",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_vocherStoreTransation_toStoreId",
                table: "vocherStoreTransation",
                column: "toStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddStock");

            migrationBuilder.DropTable(
                name: "CountSheet");

            migrationBuilder.DropTable(
                name: "IdSetting");

            migrationBuilder.DropTable(
                name: "ItemLocation");

            migrationBuilder.DropTable(
                name: "ItemStoreBalance");

            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "StockAdjustment");

            migrationBuilder.DropTable(
                name: "storeTransfer");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "userRole");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "vocherStoreTransation");

            migrationBuilder.DropTable(
                name: "Vocher");

            migrationBuilder.DropTable(
                name: "functionality");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "ItemCategory");

            migrationBuilder.DropTable(
                name: "lookup");

            migrationBuilder.DropTable(
                name: "LookupCatagory");

            migrationBuilder.DropTable(
                name: "Email");
            migrationBuilder.DropTable(
               name: "paymentHistories");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_messageCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageCategoryID",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MessageCategorys",
                columns: table => new
                {
                    MessageCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCategorys", x => x.MessageCategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MessageCategoryID",
                table: "Contacts",
                column: "MessageCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_MessageCategorys_MessageCategoryID",
                table: "Contacts",
                column: "MessageCategoryID",
                principalTable: "MessageCategorys",
                principalColumn: "MessageCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MessageCategorys_MessageCategoryID",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "MessageCategorys");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_MessageCategoryID",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "MessageCategoryID",
                table: "Contacts");
        }
    }
}

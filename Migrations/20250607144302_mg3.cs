using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRSurprise.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivateCode",
                table: "Proverbs");

            migrationBuilder.DropColumn(
                name: "ActivateCode",
                table: "Images");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Proverbs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Proverbs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Proverbs");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Proverbs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ActivateCode",
                table: "Proverbs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivateCode",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

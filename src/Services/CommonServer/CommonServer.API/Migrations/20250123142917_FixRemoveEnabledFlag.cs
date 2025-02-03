using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonServer.API.Migrations
{
    /// <inheritdoc />
    public partial class FixRemoveEnabledFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnabledFlag",
                table: "OwnerEmployee");

            migrationBuilder.DropColumn(
                name: "EnabledFlag",
                table: "OwnerDepartment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnabledFlag",
                table: "OwnerEmployee",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "是否启用");

            migrationBuilder.AddColumn<bool>(
                name: "EnabledFlag",
                table: "OwnerDepartment",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "是否启用");
        }
    }
}

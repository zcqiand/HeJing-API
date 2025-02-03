using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonServer.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveResourceId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnerRoleFunction_AppResource_ResourceId",
                table: "OwnerRoleFunction");

            migrationBuilder.DropIndex(
                name: "IX_OwnerRoleFunction_ResourceId",
                table: "OwnerRoleFunction");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "OwnerRoleFunction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ResourceId",
                table: "OwnerRoleFunction",
                type: "uuid",
                nullable: true,
                comment: "资源标识");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRoleFunction_ResourceId",
                table: "OwnerRoleFunction",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerRoleFunction_AppResource_ResourceId",
                table: "OwnerRoleFunction",
                column: "ResourceId",
                principalTable: "AppResource",
                principalColumn: "Id");
        }
    }
}

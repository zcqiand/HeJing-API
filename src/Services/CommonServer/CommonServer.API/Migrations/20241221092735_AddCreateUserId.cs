using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonServer.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "OwnerRoleResource",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "OwnerRoleResource",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "OwnerRoleFunction",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "OwnerRoleFunction",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "OwnerRoleData",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "OwnerRoleData",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "OwnerRole",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "OwnerRole",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "OwnerEntity",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "OwnerEntity",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "OwnerEmployeeRole",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "OwnerEmployeeRole",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "OwnerEmployee",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "OwnerEmployee",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "OwnerDepartment",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "OwnerDepartment",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "AppResource",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "AppResource",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "AppOperationLog",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "AppOperationLog",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "AppFunction",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "AppFunction",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "AppEntity",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "AppEntity",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateUserId",
                table: "AppData",
                type: "uuid",
                nullable: true,
                comment: "创建人标识");

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifyUserId",
                table: "AppData",
                type: "uuid",
                nullable: true,
                comment: "最后更新人标识");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "OwnerRoleResource");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "OwnerRoleResource");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "OwnerRoleFunction");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "OwnerRoleFunction");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "OwnerRoleData");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "OwnerRoleData");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "OwnerRole");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "OwnerRole");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "OwnerEntity");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "OwnerEntity");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "OwnerEmployeeRole");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "OwnerEmployeeRole");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "OwnerEmployee");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "OwnerEmployee");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "OwnerDepartment");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "OwnerDepartment");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "AppResource");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "AppResource");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "AppOperationLog");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "AppOperationLog");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "AppFunction");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "AppFunction");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "AppEntity");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "AppEntity");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "AppData");

            migrationBuilder.DropColumn(
                name: "LastModifyUserId",
                table: "AppData");
        }
    }
}

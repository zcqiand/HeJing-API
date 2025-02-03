using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonServer.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAppAuditLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    Event = table.Column<string>(type: "text", nullable: true, comment: "事件"),
                    Source = table.Column<string>(type: "text", nullable: true, comment: "来源"),
                    Category = table.Column<string>(type: "text", nullable: true, comment: "分类"),
                    UserId = table.Column<string>(type: "text", nullable: true, comment: "用户标识"),
                    UserName = table.Column<string>(type: "text", nullable: true, comment: "用户名称"),
                    Action = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    CreateUserId = table.Column<Guid>(type: "uuid", nullable: true, comment: "创建人标识"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间"),
                    LastModifyUserId = table.Column<Guid>(type: "uuid", nullable: true, comment: "最后更新人标识")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAuditLog", x => x.Id);
                },
                comment: "审计日志");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAuditLog");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonServer.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "名称"),
                    Remark = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    SortNo = table.Column<int>(type: "integer", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppData", x => x.Id);
                },
                comment: "数据");

            migrationBuilder.CreateTable(
                name: "AppEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "名称"),
                    Remark = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    EnabledFlag = table.Column<bool>(type: "boolean", nullable: false, comment: "是否启用"),
                    SortNo = table.Column<int>(type: "integer", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppEntity", x => x.Id);
                },
                comment: "应用");

            migrationBuilder.CreateTable(
                name: "AppFunction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "名称"),
                    Remark = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    SortNo = table.Column<int>(type: "integer", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFunction", x => x.Id);
                },
                comment: "功能");

            migrationBuilder.CreateTable(
                name: "AppOperationLog",
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
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOperationLog", x => x.Id);
                },
                comment: "操作日志");

            migrationBuilder.CreateTable(
                name: "AppResource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    ResourceType = table.Column<int>(type: "integer", nullable: false, comment: "资源类型"),
                    Path = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "路径"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "名称"),
                    Component = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "组件"),
                    Icon = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "图标"),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "标题"),
                    IsLink = table.Column<bool>(type: "boolean", nullable: true, comment: "是否外链"),
                    IsHide = table.Column<bool>(type: "boolean", nullable: true, comment: "是否隐藏"),
                    IsFull = table.Column<bool>(type: "boolean", nullable: true, comment: "是否全屏"),
                    IsAffix = table.Column<bool>(type: "boolean", nullable: true, comment: "是否固定"),
                    IsKeepAlive = table.Column<bool>(type: "boolean", nullable: true, comment: "是否缓存"),
                    Remark = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    SortNo = table.Column<int>(type: "integer", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间"),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true, comment: "父级标识")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppResource_AppResource_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AppResource",
                        principalColumn: "Id");
                },
                comment: "资源");

            migrationBuilder.CreateTable(
                name: "OwnerEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "名称"),
                    ShortName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "简称"),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "联系地址"),
                    ZipCode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "邮政编码"),
                    Tel = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "联系电话"),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "电子邮箱"),
                    ContactPerson = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "联系人"),
                    ContactPersonTel = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "联系人电话"),
                    Remark = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    EnabledFlag = table.Column<bool>(type: "boolean", nullable: false, comment: "是否启用"),
                    SortNo = table.Column<int>(type: "integer", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerEntity", x => x.Id);
                },
                comment: "机构");

            migrationBuilder.CreateTable(
                name: "OwnerDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false, comment: "机构标识"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "名称"),
                    Remark = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    EnabledFlag = table.Column<bool>(type: "boolean", nullable: false, comment: "是否启用"),
                    SortNo = table.Column<int>(type: "integer", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间"),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true, comment: "父级标识")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerDepartment_OwnerDepartment_ParentId",
                        column: x => x.ParentId,
                        principalTable: "OwnerDepartment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OwnerDepartment_OwnerEntity_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "OwnerEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "部门");

            migrationBuilder.CreateTable(
                name: "OwnerRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false, comment: "机构标识"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "名称"),
                    SortNo = table.Column<int>(type: "integer", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerRole_OwnerEntity_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "OwnerEntity",
                        principalColumn: "Id");
                },
                comment: "角色");

            migrationBuilder.CreateTable(
                name: "OwnerEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false, comment: "部门标识"),
                    UserId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true, comment: "用户标识"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "姓名"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Gender = table.Column<int>(type: "integer", maxLength: 200, nullable: false, comment: "性别"),
                    NickName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "昵称"),
                    Tel = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "联系电话"),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "电子邮箱"),
                    Remark = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    EnabledFlag = table.Column<bool>(type: "boolean", nullable: false, comment: "是否启用"),
                    SortNo = table.Column<int>(type: "integer", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerEmployee_OwnerDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "OwnerDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "员工");

            migrationBuilder.CreateTable(
                name: "OwnerRoleData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    RoleId = table.Column<Guid>(type: "uuid", maxLength: 50, nullable: false, comment: "角色标识"),
                    DataId = table.Column<Guid>(type: "uuid", nullable: true, comment: "数据标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerRoleData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerRoleData_AppData_DataId",
                        column: x => x.DataId,
                        principalTable: "AppData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OwnerRoleData_OwnerRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OwnerRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色数据");

            migrationBuilder.CreateTable(
                name: "OwnerRoleFunction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    RoleId = table.Column<Guid>(type: "uuid", maxLength: 50, nullable: false, comment: "角色标识"),
                    ResourceId = table.Column<Guid>(type: "uuid", nullable: true, comment: "资源标识"),
                    FunctionId = table.Column<Guid>(type: "uuid", nullable: false, comment: "功能标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerRoleFunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerRoleFunction_AppFunction_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "AppFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerRoleFunction_AppResource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "AppResource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OwnerRoleFunction_OwnerRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OwnerRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色功能");

            migrationBuilder.CreateTable(
                name: "OwnerRoleResource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    RoleId = table.Column<Guid>(type: "uuid", maxLength: 50, nullable: false, comment: "角色标识"),
                    ResourceId = table.Column<Guid>(type: "uuid", nullable: false, comment: "资源标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerRoleResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerRoleResource_AppResource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "AppResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerRoleResource_OwnerRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OwnerRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色资源");

            migrationBuilder.CreateTable(
                name: "OwnerEmployeeRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false, comment: "用户标识"),
                    RoleId = table.Column<Guid>(type: "uuid", maxLength: 50, nullable: false, comment: "角色标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerEmployeeRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerEmployeeRole_OwnerEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "OwnerEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerEmployeeRole_OwnerRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OwnerRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "员工角色");

            migrationBuilder.CreateIndex(
                name: "IX_AppResource_ParentId",
                table: "AppResource",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerDepartment_OwnerId",
                table: "OwnerDepartment",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerDepartment_ParentId",
                table: "OwnerDepartment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerEmployee_DepartmentId",
                table: "OwnerEmployee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerEmployeeRole_EmployeeId",
                table: "OwnerEmployeeRole",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerEmployeeRole_RoleId",
                table: "OwnerEmployeeRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRole_OwnerId",
                table: "OwnerRole",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRoleData_DataId",
                table: "OwnerRoleData",
                column: "DataId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRoleData_RoleId",
                table: "OwnerRoleData",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRoleFunction_FunctionId",
                table: "OwnerRoleFunction",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRoleFunction_ResourceId",
                table: "OwnerRoleFunction",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRoleFunction_RoleId",
                table: "OwnerRoleFunction",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRoleResource_ResourceId",
                table: "OwnerRoleResource",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRoleResource_RoleId",
                table: "OwnerRoleResource",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppEntity");

            migrationBuilder.DropTable(
                name: "AppOperationLog");

            migrationBuilder.DropTable(
                name: "OwnerEmployeeRole");

            migrationBuilder.DropTable(
                name: "OwnerRoleData");

            migrationBuilder.DropTable(
                name: "OwnerRoleFunction");

            migrationBuilder.DropTable(
                name: "OwnerRoleResource");

            migrationBuilder.DropTable(
                name: "OwnerEmployee");

            migrationBuilder.DropTable(
                name: "AppData");

            migrationBuilder.DropTable(
                name: "AppFunction");

            migrationBuilder.DropTable(
                name: "AppResource");

            migrationBuilder.DropTable(
                name: "OwnerRole");

            migrationBuilder.DropTable(
                name: "OwnerDepartment");

            migrationBuilder.DropTable(
                name: "OwnerEntity");
        }
    }
}

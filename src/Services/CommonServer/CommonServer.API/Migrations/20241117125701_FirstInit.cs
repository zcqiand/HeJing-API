using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonServer.API.Migrations
{
    /// <inheritdoc />
    public partial class FirstInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseApp",
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
                    table.PrimaryKey("PK_BaseApp", x => x.Id);
                },
                comment: "应用");

            migrationBuilder.CreateTable(
                name: "BaseAppData",
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
                    table.PrimaryKey("PK_BaseAppData", x => x.Id);
                },
                comment: "数据");

            migrationBuilder.CreateTable(
                name: "BaseAppFunction",
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
                    table.PrimaryKey("PK_BaseAppFunction", x => x.Id);
                },
                comment: "功能");

            migrationBuilder.CreateTable(
                name: "BaseAppResource",
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
                    table.PrimaryKey("PK_BaseAppResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseAppResource_BaseAppResource_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BaseAppResource",
                        principalColumn: "Id");
                },
                comment: "资源");

            migrationBuilder.CreateTable(
                name: "BaseOrgan",
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
                    table.PrimaryKey("PK_BaseOrgan", x => x.Id);
                },
                comment: "机构");

            migrationBuilder.CreateTable(
                name: "RunOperationLog",
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
                    table.PrimaryKey("PK_RunOperationLog", x => x.Id);
                },
                comment: "操作日志");

            migrationBuilder.CreateTable(
                name: "BaseOrganDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    OrganId = table.Column<Guid>(type: "uuid", nullable: false, comment: "机构标识"),
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
                    table.PrimaryKey("PK_BaseOrganDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseOrganDepartment_BaseOrganDepartment_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BaseOrganDepartment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseOrganDepartment_BaseOrgan_OrganId",
                        column: x => x.OrganId,
                        principalTable: "BaseOrgan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "部门");

            migrationBuilder.CreateTable(
                name: "BaseOrganRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    OrganId = table.Column<Guid>(type: "uuid", nullable: false, comment: "机构标识"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编号"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "名称"),
                    SortNo = table.Column<int>(type: "integer", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseOrganRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseOrganRole_BaseOrgan_OrganId",
                        column: x => x.OrganId,
                        principalTable: "BaseOrgan",
                        principalColumn: "Id");
                },
                comment: "角色");

            migrationBuilder.CreateTable(
                name: "BaseOrganEmployee",
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
                    table.PrimaryKey("PK_BaseOrganEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseOrganEmployee_BaseOrganDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "BaseOrganDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "员工");

            migrationBuilder.CreateTable(
                name: "BaseOrganRoleData",
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
                    table.PrimaryKey("PK_BaseOrganRoleData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseOrganRoleData_BaseAppData_DataId",
                        column: x => x.DataId,
                        principalTable: "BaseAppData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseOrganRoleData_BaseOrganRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "BaseOrganRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色数据");

            migrationBuilder.CreateTable(
                name: "BaseOrganRoleFunction",
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
                    table.PrimaryKey("PK_BaseOrganRoleFunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseOrganRoleFunction_BaseAppFunction_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "BaseAppFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseOrganRoleFunction_BaseAppResource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "BaseAppResource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseOrganRoleFunction_BaseOrganRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "BaseOrganRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色功能");

            migrationBuilder.CreateTable(
                name: "BaseOrganRoleResource",
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
                    table.PrimaryKey("PK_BaseOrganRoleResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseOrganRoleResource_BaseAppResource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "BaseAppResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseOrganRoleResource_BaseOrganRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "BaseOrganRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色资源");

            migrationBuilder.CreateTable(
                name: "BaseOrganEmployeeRole",
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
                    table.PrimaryKey("PK_BaseOrganEmployeeRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseOrganEmployeeRole_BaseOrganEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "BaseOrganEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseOrganEmployeeRole_BaseOrganRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "BaseOrganRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "员工角色");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAppResource_ParentId",
                table: "BaseAppResource",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganDepartment_OrganId",
                table: "BaseOrganDepartment",
                column: "OrganId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganDepartment_ParentId",
                table: "BaseOrganDepartment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganEmployee_DepartmentId",
                table: "BaseOrganEmployee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganEmployeeRole_EmployeeId",
                table: "BaseOrganEmployeeRole",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganEmployeeRole_RoleId",
                table: "BaseOrganEmployeeRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganRole_OrganId",
                table: "BaseOrganRole",
                column: "OrganId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganRoleData_DataId",
                table: "BaseOrganRoleData",
                column: "DataId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganRoleData_RoleId",
                table: "BaseOrganRoleData",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganRoleFunction_FunctionId",
                table: "BaseOrganRoleFunction",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganRoleFunction_ResourceId",
                table: "BaseOrganRoleFunction",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganRoleFunction_RoleId",
                table: "BaseOrganRoleFunction",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganRoleResource_ResourceId",
                table: "BaseOrganRoleResource",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseOrganRoleResource_RoleId",
                table: "BaseOrganRoleResource",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseApp");

            migrationBuilder.DropTable(
                name: "BaseOrganEmployeeRole");

            migrationBuilder.DropTable(
                name: "BaseOrganRoleData");

            migrationBuilder.DropTable(
                name: "BaseOrganRoleFunction");

            migrationBuilder.DropTable(
                name: "BaseOrganRoleResource");

            migrationBuilder.DropTable(
                name: "RunOperationLog");

            migrationBuilder.DropTable(
                name: "BaseOrganEmployee");

            migrationBuilder.DropTable(
                name: "BaseAppData");

            migrationBuilder.DropTable(
                name: "BaseAppFunction");

            migrationBuilder.DropTable(
                name: "BaseAppResource");

            migrationBuilder.DropTable(
                name: "BaseOrganRole");

            migrationBuilder.DropTable(
                name: "BaseOrganDepartment");

            migrationBuilder.DropTable(
                name: "BaseOrgan");
        }
    }
}

﻿// <auto-generated />
using System;
using CommonServer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CommonServer.API.Migrations
{
    [DbContext(typeof(CommonServerDbContext))]
    partial class CommonServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CommonServer.Domain.Model.AppData", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.ToTable("AppData", t =>
                        {
                            t.HasComment("数据");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.AppFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.ToTable("AppFunction", t =>
                        {
                            t.HasComment("功能");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.AppOperationLog", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("分类");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("事件");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("来源");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("用户标识");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("用户名称");

                    b.HasKey("Id");

                    b.ToTable("AppOperationLog", t =>
                        {
                            t.HasComment("操作日志");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.AppResource", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Component")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("组件");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<string>("Icon")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("图标");

                    b.Property<bool?>("IsAffix")
                        .HasColumnType("bit")
                        .HasComment("是否固定");

                    b.Property<bool?>("IsFull")
                        .HasColumnType("bit")
                        .HasComment("是否全屏");

                    b.Property<bool?>("IsHide")
                        .HasColumnType("bit")
                        .HasComment("是否隐藏");

                    b.Property<bool?>("IsKeepAlive")
                        .HasColumnType("bit")
                        .HasComment("是否缓存");

                    b.Property<bool?>("IsLink")
                        .HasColumnType("bit")
                        .HasComment("是否外链");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("父级标识");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("路径");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("ResourceType")
                        .HasColumnType("int")
                        .HasComment("资源类型");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("AppResource", t =>
                        {
                            t.HasComment("资源");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.Apps", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("bit")
                        .HasComment("是否启用");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.ToTable("Apps", t =>
                        {
                            t.HasComment("应用");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganDepartment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("bit")
                        .HasComment("是否启用");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<Guid>("OrganId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("机构标识");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("父级标识");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.HasIndex("OrganId");

                    b.HasIndex("ParentId");

                    b.ToTable("OrganDepartment", t =>
                        {
                            t.HasComment("部门");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganEmployee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("部门标识");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("电子邮箱");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("bit")
                        .HasComment("是否启用");

                    b.Property<int>("Gender")
                        .HasMaxLength(200)
                        .HasColumnType("int")
                        .HasComment("性别");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("姓名");

                    b.Property<string>("NickName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("昵称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.Property<string>("Tel")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系电话");

                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasComment("用户标识");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("OrganEmployee", t =>
                        {
                            t.HasComment("员工");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganEmployeeRole", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("用户标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasComment("角色标识");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("OrganEmployeeRole", t =>
                        {
                            t.HasComment("员工角色");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganRole", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<Guid>("OrganId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("机构标识");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.HasIndex("OrganId");

                    b.ToTable("OrganRole", t =>
                        {
                            t.HasComment("角色");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganRoleData", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid?>("DataId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("数据标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasComment("角色标识");

                    b.HasKey("Id");

                    b.HasIndex("DataId");

                    b.HasIndex("RoleId");

                    b.ToTable("OrganRoleData", t =>
                        {
                            t.HasComment("角色数据");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganRoleFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid>("FunctionId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("功能标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("ResourceId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("资源标识");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasComment("角色标识");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("RoleId");

                    b.ToTable("OrganRoleFunction", t =>
                        {
                            t.HasComment("角色功能");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganRoleResource", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("资源标识");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasComment("角色标识");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.HasIndex("RoleId");

                    b.ToTable("OrganRoleResource", t =>
                        {
                            t.HasComment("角色资源");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.Organs", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系地址");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("编号");

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系人");

                    b.Property<string>("ContactPersonTel")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系人电话");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("电子邮箱");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("bit")
                        .HasComment("是否启用");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<string>("ShortName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("简称");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.Property<string>("Tel")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系电话");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("邮政编码");

                    b.HasKey("Id");

                    b.ToTable("Organs", t =>
                        {
                            t.HasComment("机构");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.AppResource", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.AppResource", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganDepartment", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.Organs", "Organ")
                        .WithMany("Departments")
                        .HasForeignKey("OrganId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonServer.Domain.Model.OrganDepartment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Organ");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganEmployee", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.OrganDepartment", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganEmployeeRole", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.OrganEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonServer.Domain.Model.OrganRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganRole", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.Organs", "Organ")
                        .WithMany("Roles")
                        .HasForeignKey("OrganId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Organ");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganRoleData", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.AppData", "Data")
                        .WithMany()
                        .HasForeignKey("DataId");

                    b.HasOne("CommonServer.Domain.Model.OrganRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Data");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganRoleFunction", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.AppFunction", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonServer.Domain.Model.AppResource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId");

                    b.HasOne("CommonServer.Domain.Model.OrganRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Function");

                    b.Navigation("Resource");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganRoleResource", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.AppResource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonServer.Domain.Model.OrganRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.AppResource", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OrganDepartment", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.Organs", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}

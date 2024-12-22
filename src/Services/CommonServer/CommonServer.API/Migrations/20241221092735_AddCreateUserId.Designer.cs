﻿// <auto-generated />
using System;
using CommonServer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CommonServer.API.Migrations
{
    [DbContext(typeof(CommonServerDbContext))]
    [Migration("20241221092735_AddCreateUserId")]
    partial class AddCreateUserId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CommonServer.Domain.Model.AppData", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("integer")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.ToTable("AppData", t =>
                        {
                            t.HasComment("数据");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.AppEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("boolean")
                        .HasComment("是否启用");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("integer")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.ToTable("AppEntity", t =>
                        {
                            t.HasComment("应用");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.AppFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("integer")
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
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .HasColumnType("text")
                        .HasComment("分类");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<string>("Event")
                        .HasColumnType("text")
                        .HasComment("事件");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<string>("Source")
                        .HasColumnType("text")
                        .HasComment("来源");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasComment("用户标识");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
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
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<string>("Component")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("组件");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<string>("Icon")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("图标");

                    b.Property<bool?>("IsAffix")
                        .HasColumnType("boolean")
                        .HasComment("是否固定");

                    b.Property<bool?>("IsFull")
                        .HasColumnType("boolean")
                        .HasComment("是否全屏");

                    b.Property<bool?>("IsHide")
                        .HasColumnType("boolean")
                        .HasComment("是否隐藏");

                    b.Property<bool?>("IsKeepAlive")
                        .HasColumnType("boolean")
                        .HasComment("是否缓存");

                    b.Property<bool?>("IsLink")
                        .HasColumnType("boolean")
                        .HasComment("是否外链");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("名称");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid")
                        .HasComment("父级标识");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("路径");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasComment("备注");

                    b.Property<int>("ResourceType")
                        .HasColumnType("integer")
                        .HasComment("资源类型");

                    b.Property<int>("SortNo")
                        .HasColumnType("integer")
                        .HasComment("排序号");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("AppResource", t =>
                        {
                            t.HasComment("资源");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerDepartment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("boolean")
                        .HasComment("是否启用");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("名称");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasComment("机构标识");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid")
                        .HasComment("父级标识");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("integer")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParentId");

                    b.ToTable("OwnerDepartment", t =>
                        {
                            t.HasComment("部门");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerEmployee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid")
                        .HasComment("部门标识");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("电子邮箱");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("boolean")
                        .HasComment("是否启用");

                    b.Property<int>("Gender")
                        .HasMaxLength(200)
                        .HasColumnType("integer")
                        .HasComment("性别");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("姓名");

                    b.Property<string>("NickName")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("昵称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasComment("备注");

                    b.Property<int>("SortNo")
                        .HasColumnType("integer")
                        .HasComment("排序号");

                    b.Property<string>("Tel")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("联系电话");

                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("character varying(450)")
                        .HasComment("用户标识");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("OwnerEmployee", t =>
                        {
                            t.HasComment("员工");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerEmployeeRole", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid")
                        .HasComment("用户标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uuid")
                        .HasComment("角色标识");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("OwnerEmployeeRole", t =>
                        {
                            t.HasComment("员工角色");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("联系地址");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasComment("编号");

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("联系人");

                    b.Property<string>("ContactPersonTel")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("联系人电话");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("电子邮箱");

                    b.Property<bool>("EnabledFlag")
                        .HasColumnType("boolean")
                        .HasComment("是否启用");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasComment("备注");

                    b.Property<string>("ShortName")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("简称");

                    b.Property<int>("SortNo")
                        .HasColumnType("integer")
                        .HasComment("排序号");

                    b.Property<string>("Tel")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("联系电话");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("邮政编码");

                    b.HasKey("Id");

                    b.ToTable("OwnerEntity", t =>
                        {
                            t.HasComment("机构");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerRole", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasComment("编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasComment("名称");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasComment("机构标识");

                    b.Property<int>("SortNo")
                        .HasColumnType("integer")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("OwnerRole", t =>
                        {
                            t.HasComment("角色");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerRoleData", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<Guid?>("DataId")
                        .HasColumnType("uuid")
                        .HasComment("数据标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uuid")
                        .HasComment("角色标识");

                    b.HasKey("Id");

                    b.HasIndex("DataId");

                    b.HasIndex("RoleId");

                    b.ToTable("OwnerRoleData", t =>
                        {
                            t.HasComment("角色数据");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerRoleFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<Guid>("FunctionId")
                        .HasColumnType("uuid")
                        .HasComment("功能标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<Guid?>("ResourceId")
                        .HasColumnType("uuid")
                        .HasComment("资源标识");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uuid")
                        .HasComment("角色标识");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("RoleId");

                    b.ToTable("OwnerRoleFunction", t =>
                        {
                            t.HasComment("角色功能");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerRoleResource", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid")
                        .HasComment("创建人标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("最后更新时间");

                    b.Property<Guid?>("LastModifyUserId")
                        .HasColumnType("uuid")
                        .HasComment("最后更新人标识");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uuid")
                        .HasComment("资源标识");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("uuid")
                        .HasComment("角色标识");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.HasIndex("RoleId");

                    b.ToTable("OwnerRoleResource", t =>
                        {
                            t.HasComment("角色资源");
                        });
                });

            modelBuilder.Entity("CommonServer.Domain.Model.AppResource", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.AppResource", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerDepartment", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.OwnerEntity", "Owner")
                        .WithMany("Departments")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonServer.Domain.Model.OwnerDepartment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Owner");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerEmployee", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.OwnerDepartment", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerEmployeeRole", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.OwnerEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonServer.Domain.Model.OwnerRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerRole", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.OwnerEntity", "Owner")
                        .WithMany("Roles")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerRoleData", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.AppData", "Data")
                        .WithMany()
                        .HasForeignKey("DataId");

                    b.HasOne("CommonServer.Domain.Model.OwnerRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Data");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerRoleFunction", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.AppFunction", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonServer.Domain.Model.AppResource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId");

                    b.HasOne("CommonServer.Domain.Model.OwnerRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Function");

                    b.Navigation("Resource");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerRoleResource", b =>
                {
                    b.HasOne("CommonServer.Domain.Model.AppResource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonServer.Domain.Model.OwnerRole", "Role")
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

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerDepartment", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("CommonServer.Domain.Model.OwnerEntity", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}

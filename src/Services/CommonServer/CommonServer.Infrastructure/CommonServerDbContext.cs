using CommonServer.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static MassTransit.MessageHeaders;

namespace CommonServer.Infrastructure;

public partial class CommonServerDbContext : DbContext
{
    public CommonServerDbContext(DbContextOptions<CommonServerDbContext> options)
        : base(options)
    {
    }

    #region 实体
    public virtual DbSet<AppEntity> Appses { get; set; } = null!;
    public virtual DbSet<AppResource> AppResources { get; set; } = null!;
    public virtual DbSet<AppFunction> AppFunctions { get; set; } = null!;
    public virtual DbSet<BaseAppData> AppDatas { get; set; } = null!;
    public virtual DbSet<AppOperationLog> AppOperationLogs { get; set; } = null!;
    public virtual DbSet<OwnerEntity> Organses { get; set; } = null!;
    public virtual DbSet<OwnerRole> OrganRoles { get; set; } = null!;
    public virtual DbSet<OwnerRoleResource> OrganRoleResources { get; set; } = null!;
    public virtual DbSet<OwnerRoleFunction> OrganRoleFunctions { get; set; } = null!;
    public virtual DbSet<OwnerRoleData> OrganRoleDatas { get; set; } = null!;
    public virtual DbSet<OwnerDepartment> OrganDepartments { get; set; } = null!;
    public virtual DbSet<OwnerEmployee> OrganEmployees { get; set; } = null!;
    public virtual DbSet<OwnerEmployeeRole> OrganEmployeeRoles { get; set; } = null!;
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OwnerRole>()
            .HasOne(e => e.Organ)
            .WithMany(e => e.Roles)
            .HasForeignKey(e => e.OrganId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}
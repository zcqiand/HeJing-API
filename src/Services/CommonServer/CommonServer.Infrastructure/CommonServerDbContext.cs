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
    public virtual DbSet<AppEntity> AppEntities { get; set; } = null!;
    public virtual DbSet<AppData> AppDatas { get; set; } = null!;
    public virtual DbSet<AppResource> AppResources { get; set; } = null!;
    public virtual DbSet<AppFunction> AppFunctions { get; set; } = null!;
    public virtual DbSet<AppOperationLog> AppOperationLogs { get; set; } = null!;
    public virtual DbSet<OwnerEntity> OwnerEntities { get; set; } = null!;
    public virtual DbSet<OwnerRole> OwnerRoles { get; set; } = null!;
    public virtual DbSet<OwnerRoleResource> OwnerRoleResources { get; set; } = null!;
    public virtual DbSet<OwnerRoleFunction> OwnerRoleFunctions { get; set; } = null!;
    public virtual DbSet<OwnerRoleData> OwnerRoleDatas { get; set; } = null!;
    public virtual DbSet<OwnerDepartment> OwnerDepartments { get; set; } = null!;
    public virtual DbSet<OwnerEmployee> OwnerEmployees { get; set; } = null!;
    public virtual DbSet<OwnerEmployeeRole> OwnerEmployeeRoles { get; set; } = null!;
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OwnerRole>()
            .HasOne(e => e.Owner)
            .WithMany(e => e.Roles)
            .HasForeignKey(e => e.OwnerId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}
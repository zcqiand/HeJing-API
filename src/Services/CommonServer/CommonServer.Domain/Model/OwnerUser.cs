using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 用户
/// </summary>
[Table("OwnerUser")]
[Comment("用户")]
public partial class OwnerUser : Entity
{
    /// <summary>
    /// 机构标识
    /// </summary>
    [Comment("机构标识")]
    public Guid OwnerId { get; set; }
    public OwnerEntity? Owner { get; set; }
    /// <summary>
    /// 用户名
    /// </summary>
    [StringLength(50)]
    [Comment("用户名")]
    public string UserName { get; set; } = null!;
    /// <summary>
    /// 密码
    /// </summary>
    [StringLength(50)]
    [Comment("密码")]
    public string Password { get; set; } = null!;
}
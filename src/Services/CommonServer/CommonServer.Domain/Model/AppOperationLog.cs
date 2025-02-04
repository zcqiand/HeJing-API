using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 审计日志
/// </summary>
[Table("AppAuditLog")]
[Comment("审计日志")]
public partial class AppAuditLog : Entity
{
    /// <summary>
    /// 事件
    /// </summary>
    [StringLength(50)]
    [Comment("事件")]
    public string? Event { get; set; }
    /// <summary>
    /// 来源
    /// </summary>
    [StringLength(50)]
    [Comment("来源")]
    public string? Source { get; set; }
    /// <summary>
    /// 分类
    /// </summary>
    [StringLength(50)]
    [Comment("分类")]
    public string? Category { get; set; }
    /// <summary>
    /// 用户标识
    /// </summary>
    [StringLength(50)]
    [Comment("用户标识")]
    public string? UserId { get; set; }
    /// <summary>
    /// 用户名称
    /// </summary>
    [StringLength(50)]
    [Comment("用户名称")]
    public string? UserName { get; set; }
    /// <summary>
    /// 操作
    /// </summary>
    [StringLength(50)]
    [Comment("操作")]
    public string? Action { get; set; }
    /// <summary>
    /// 数据
    /// </summary>
    [StringLength(500)]
    [Comment("数据")]
    public string? Data { get; set; }
}
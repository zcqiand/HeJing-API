﻿using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 角色功能
/// </summary>
[Table("OwnerRoleFunction")]
[Comment("角色功能")]
public partial class OwnerRoleFunction : Entity
{
    /// <summary>
    /// 角色标识
    /// </summary>
    [StringLength(50)]
    [Comment("角色标识")]
    public Guid RoleId { get; set; }
    public OwnerRole? Role { get; set; }
    /// <summary>
    /// 功能标识
    /// </summary>
    [Comment("功能标识")]
    public Guid FunctionId { get; set; }
    public AppFunction? Function { get; set; }
}
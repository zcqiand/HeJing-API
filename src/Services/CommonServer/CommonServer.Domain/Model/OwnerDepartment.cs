﻿using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServer.Domain.Model;

/// <summary>
/// 部门
/// </summary>
[Table("OwnerDepartment")]
[Comment("部门")]
public partial class OwnerDepartment : TreeEntity<OwnerDepartment>
{
    /// <summary>
    /// 机构标识
    /// </summary>
    [Comment("机构标识")]
    public Guid OwnerId { get; set; }
    public OwnerEntity? Owner { get; set; }
    /// <summary>
    /// 编号
    /// </summary>
    [StringLength(50)]
    [Comment("编号")]
    public string Code { get; set; } = null!;
    /// <summary>
    /// 名称
    /// </summary>
    [StringLength(200)]
    [Comment("名称")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
    /// <summary>
    /// 排序号
    /// </summary>
    [Comment("排序号")]
    public int SortNo { get; set; }
}
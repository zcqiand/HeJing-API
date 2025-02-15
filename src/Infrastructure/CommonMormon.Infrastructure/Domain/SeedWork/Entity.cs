﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonMormon.Infrastructure.Domain.SeedWork;

public abstract class Entity
{
    /// <summary>
    /// 标识
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Comment("标识")]
    public Guid Id { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    [Comment("创建时间")]
    public DateTimeOffset CreateTime { get; set; } = DateTimeOffset.UtcNow;
    /// <summary>
    /// 创建人标识
    /// </summary>
    [Comment("创建人标识")]
    public Guid? CreateUserId { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    [Comment("最后更新时间")]
    public DateTimeOffset LastModifyTime { get; set; } = DateTimeOffset.UtcNow;
    /// <summary>
    /// 最后更新人标识
    /// </summary>
    [Comment("最后更新人标识")]
    public Guid? LastModifyUserId { get; set; }
}
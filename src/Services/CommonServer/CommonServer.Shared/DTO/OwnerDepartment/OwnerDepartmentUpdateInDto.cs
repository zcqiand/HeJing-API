﻿namespace CommonServer.Shared.DTO.OwnerDepartment;

/// <summary>
/// 部门
/// </summary>
public class OwnerDepartmentUpdateInDto : UpdateInBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 机构标识
    /// </summary>
    public Guid? OwnerId { get; set; }
    /// <summary>
    /// 编号
    /// </summary>
    public string Code { get; set; } = null!;
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
    /// <summary>
    /// 排序号
    /// </summary>
    public int SortNo { get; set; }
    /// <summary>
    /// 父级标识
    /// </summary>
    public Guid? ParentId { get; set; }
}


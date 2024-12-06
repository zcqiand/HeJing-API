﻿using CommonServer.Shared.Enums;

namespace CommonServer.Shared.DTO.OrganEmployee;

/// <summary>
/// 员工
/// </summary>
public class OrganEmployeeCreateInDto : CreateInBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 部门标识
    /// </summary>
    public Guid DepartmentId { get; set; }
    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 编号
    /// </summary>
    public string Code { get; set; } = null!;
    /// <summary>
    /// 性别
    /// </summary>
    public GenderEnum Gender { get; set; }
    /// <summary>
    /// 昵称
    /// </summary>
    public string? NickName { get; set; }
    /// <summary>
    /// 联系电话
    /// </summary>
    public string? Tel { get; set; }
    /// <summary>
    /// 电子邮箱
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
    /// <summary>
    /// 排序号
    /// </summary>
    public int SortNo { get; set; }
}

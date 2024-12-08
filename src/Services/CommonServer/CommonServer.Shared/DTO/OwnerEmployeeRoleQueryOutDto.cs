namespace CommonServer.Shared.DTO.OwnerEmployeeRole;

/// <summary>
/// 员工角色
/// </summary>
public class OwnerEmployeeRoleQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 用户标识
    /// </summary>
    public Guid? EmployeeId { get; set; }
    /// <summary>
    /// 角色标识
    /// </summary>
    public Guid? RoleId { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public DateTime LastModifyTime { get; set; }
}


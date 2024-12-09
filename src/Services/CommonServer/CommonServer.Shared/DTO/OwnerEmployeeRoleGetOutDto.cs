namespace CommonServer.Shared.DTO.OwnerEmployeeRole;

/// <summary>
/// 员工角色
/// </summary>
public class OwnerEmployeeRoleGetOutDto : GetOutBase
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
}


namespace CommonServer.Shared.DTO.OwnerRole;

/// <summary>
/// 角色
/// </summary>
public class OwnerRoleUpdateEmployeeInDto : UpdateInBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 成员标识集合
    /// </summary>
    public IList<Guid> EmployeeIds { get; set; } = new List<Guid>();
}


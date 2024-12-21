namespace CommonServer.Shared.DTO.OwnerEmployeeRole;

/// <summary>
/// 员工角色
/// </summary>
public class OwnerEmployeeRoleBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


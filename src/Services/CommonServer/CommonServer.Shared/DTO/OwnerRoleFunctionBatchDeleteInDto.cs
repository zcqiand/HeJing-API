namespace CommonServer.Shared.DTO.OwnerRoleFunction;

/// <summary>
/// 角色功能
/// </summary>
public class OwnerRoleFunctionBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


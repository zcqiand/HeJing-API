namespace CommonServer.Shared.DTO.OwnerRole;

/// <summary>
/// 角色
/// </summary>
public class OwnerRoleBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


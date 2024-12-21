namespace CommonServer.Shared.DTO.OwnerRoleResource;

/// <summary>
/// 角色资源
/// </summary>
public class OwnerRoleResourceBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


namespace CommonServer.Shared.DTO.OwnerRole;

/// <summary>
/// 角色
/// </summary>
public class OwnerRoleUpdateResourceInDto : UpdateInBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 资源标识集合
    /// </summary>
    public IList<Guid> ResourceIds { get; set; } = new List<Guid>();
}


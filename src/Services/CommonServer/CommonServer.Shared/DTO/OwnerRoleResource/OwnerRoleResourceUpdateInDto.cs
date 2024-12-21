namespace CommonServer.Shared.DTO.OwnerRoleResource;

/// <summary>
/// 角色资源
/// </summary>
public class OwnerRoleResourceUpdateInDto : UpdateInBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 角色标识
    /// </summary>
    public Guid? RoleId { get; set; }
    /// <summary>
    /// 资源标识
    /// </summary>
    public Guid? ResourceId { get; set; }
}


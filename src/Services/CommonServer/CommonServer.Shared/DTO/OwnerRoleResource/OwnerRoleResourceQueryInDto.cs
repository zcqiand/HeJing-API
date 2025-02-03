namespace CommonServer.Shared.DTO.OwnerRoleResource;

/// <summary>
/// 角色资源
/// </summary>
public class OwnerRoleResourceQueryInDto : PagingInBase
{
    /// <summary>
    /// 角色标识
    /// </summary>
    public Guid? RoleId { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; }
}


namespace CommonServer.Shared.DTO.OwnerRoleFunction;

/// <summary>
/// 角色功能
/// </summary>
public class OwnerRoleFunctionQueryInDto : PagingInBase
{

    /// <summary>
    /// 角色标识
    /// </summary>
    public Guid? RoleId { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }
}


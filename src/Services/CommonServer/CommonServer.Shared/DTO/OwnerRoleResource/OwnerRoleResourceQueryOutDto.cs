using CommonServer.Shared.DTO.AppResource;

namespace CommonServer.Shared.DTO.OwnerRoleResource;

/// <summary>
/// 角色资源
/// </summary>
public class OwnerRoleResourceQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid? Id { get; set; }
    /// <summary>
    /// 角色标识
    /// </summary>
    public Guid? RoleId { get; set; }
    /// <summary>
    /// 是否有角色
    /// </summary>
    public bool IsRole
    {
        set { }
        get
        {
            return RoleId.HasValue;
        }
    }
    /// <summary>
    /// 资源标识
    /// </summary>
    public Guid? ResourceId { get; set; }
    /// <summary>
    /// 资源父标识
    /// </summary>
    public Guid? ParentResourceId { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; } = null!;
    /// <summary>
    /// 子集合
    /// </summary>
    public List<OwnerRoleResourceQueryOutDto>? Children { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTimeOffset? CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public DateTimeOffset? LastModifyTime { get; set; }
}


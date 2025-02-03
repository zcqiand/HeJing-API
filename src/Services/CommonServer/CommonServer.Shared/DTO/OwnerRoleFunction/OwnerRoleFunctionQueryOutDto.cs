namespace CommonServer.Shared.DTO.OwnerRoleFunction;

/// <summary>
/// 角色功能
/// </summary>
public class OwnerRoleFunctionQueryOutDto
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
    /// 功能标识
    /// </summary>
    public Guid? FunctionId { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTimeOffset? CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public DateTimeOffset? LastModifyTime { get; set; }
}


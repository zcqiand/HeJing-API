namespace CommonServer.Shared.DTO.OwnerRole;

/// <summary>
/// 角色
/// </summary>
public class OwnerRoleGetOutDto : GetOutBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 机构标识
    /// </summary>
    public Guid? OwnerId { get; set; }
    /// <summary>
    /// 编号
    /// </summary>
    public string Code { get; set; } = null!;
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 排序号
    /// </summary>
    public int SortNo { get; set; }
}


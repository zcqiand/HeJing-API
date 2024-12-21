namespace CommonMormon.Infrastructure.Shared.DTO;

/// <summary>
/// 基类
/// </summary>
public class GetOutBase
{
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTimeOffset? CreateTime { get; set; }
    /// <summary>
    /// 创建人标识
    /// </summary>
    public Guid? CreateUserId { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public DateTimeOffset? LastModifyTime { get; set; }
    /// <summary>
    /// 最后更新人标识
    /// </summary>
    public Guid? LastModifyUserId { get; set; }
}

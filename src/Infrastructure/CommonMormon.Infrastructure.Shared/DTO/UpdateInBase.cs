namespace CommonMormon.Infrastructure.Shared.DTO;

/// <summary>
/// 基类
/// </summary>
public class UpdateInBase
{
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public DateTimeOffset LastModifyTime { get; set; } = DateTimeOffset.UtcNow;
    /// <summary>
    /// 最后更新人标识
    /// </summary>
    public Guid? LastModifyUserId { get; set; }
}

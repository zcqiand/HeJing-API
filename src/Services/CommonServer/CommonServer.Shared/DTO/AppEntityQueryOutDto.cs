namespace CommonServer.Shared.DTO.AppEntity;

/// <summary>
/// 应用
/// </summary>
public class AppEntityQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 编号
    /// </summary>
    public string Code { get; set; } = null!;
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    public string EnabledFlag { get; set; } = null!;
    /// <summary>
    /// 排序号
    /// </summary>
    public int SortNo { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public DateTime LastModifyTime { get; set; }
}


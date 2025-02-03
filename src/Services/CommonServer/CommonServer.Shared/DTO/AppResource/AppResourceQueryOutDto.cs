namespace CommonServer.Shared.DTO.AppResource;

/// <summary>
/// 资源
/// </summary>
public class AppResourceQueryOutDto
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int ResourceType { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Path { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string? Component { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Icon { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool? IsLink { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool? IsHide { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool? IsFull { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool? IsAffix { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool? IsKeepAlive { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Remark { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int SortNo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset LastModifyTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid? ParentId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid? CreateUserId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid? LastModifyUserId { get; set; }
}


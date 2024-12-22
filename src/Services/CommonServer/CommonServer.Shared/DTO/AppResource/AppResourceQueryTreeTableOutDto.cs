namespace CommonServer.Shared.DTO.AppResource;

/// <summary>
/// 资源
/// </summary>
public class AppResourceQueryTreeTableOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string Path { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 子集合
    /// </summary>
    public IList<AppResourceQueryTreeTableOutDto>? Children { get; set; }
}

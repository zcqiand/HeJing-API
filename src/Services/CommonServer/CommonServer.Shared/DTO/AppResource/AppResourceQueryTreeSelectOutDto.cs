namespace CommonServer.Shared.DTO.AppResource;

/// <summary>
/// 资源
/// </summary>
public class AppResourceQueryTreeSelectOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    [JsonProperty("value")]
    public Guid Id { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    [JsonProperty("label")]
    public string Title { get; set; } = null!;
    /// <summary>
    /// 子集合
    /// </summary>
    public IList<AppResourceQueryTreeSelectOutDto>? Children { get; set; }
}

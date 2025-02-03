namespace CommonServer.Shared.DTO.OwnerDepartment;

/// <summary>
/// 部门
/// </summary>
public class OwnerDepartmentQueryTreeSelectOutDto
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
    public string Name { get; set; } = null!;
    /// <summary>
    /// 子集合
    /// </summary>
    public IList<OwnerDepartmentQueryTreeSelectOutDto>? Children { get; set; }
}

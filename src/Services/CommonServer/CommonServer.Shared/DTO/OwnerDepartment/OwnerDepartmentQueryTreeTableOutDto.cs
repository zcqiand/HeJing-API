namespace CommonServer.Shared.DTO.OwnerDepartment;

/// <summary>
/// 部门
/// </summary>
public class OwnerDepartmentQueryTreeTableOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 子集合
    /// </summary>
    public IList<OwnerDepartmentQueryTreeTableOutDto>? Children { get; set; }
}

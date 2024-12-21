namespace CommonServer.Shared.DTO.OwnerDepartment;

/// <summary>
/// 部门
/// </summary>
public class OwnerDepartmentBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


namespace CommonServer.Shared.DTO.OwnerEmployee;

/// <summary>
/// 员工
/// </summary>
public class OwnerEmployeeBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


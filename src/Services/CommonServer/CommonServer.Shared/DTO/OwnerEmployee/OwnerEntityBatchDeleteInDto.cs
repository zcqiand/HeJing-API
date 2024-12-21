namespace CommonServer.Shared.DTO.OwnerEmployee;

/// <summary>
/// 机构
/// </summary>
public class OwnerEntityBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


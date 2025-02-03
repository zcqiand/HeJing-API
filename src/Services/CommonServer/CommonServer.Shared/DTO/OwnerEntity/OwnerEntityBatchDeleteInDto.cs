namespace CommonServer.Shared.DTO.OwnerEntity;

/// <summary>
/// 机构
/// </summary>
public class OwnerEntityBatchDeleteInDto
{
    /// <summary>
    /// 
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


namespace CommonServer.Shared.DTO.AppEntity;

/// <summary>
/// 应用
/// </summary>
public class AppEntityBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


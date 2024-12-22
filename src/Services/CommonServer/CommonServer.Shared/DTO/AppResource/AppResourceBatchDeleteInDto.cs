namespace CommonServer.Shared.DTO.AppResource;

/// <summary>
/// 资源
/// </summary>
public class AppResourceBatchDeleteInDto
{
    /// <summary>
    /// 
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


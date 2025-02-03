namespace CommonServer.Shared.DTO.OwnerRoleData;

/// <summary>
/// 角色数据
/// </summary>
public class OwnerRoleDataBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}


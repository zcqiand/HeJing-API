namespace CommonServer.Shared.DTO.OwnerRoleData;

/// <summary>
/// 角色数据
/// </summary>
public class OwnerRoleDataUpdateInDto : UpdateInBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 角色标识
    /// </summary>
    public Guid? RoleId { get; set; }
    /// <summary>
    /// 数据标识
    /// </summary>
    public Guid? DataId { get; set; }
}


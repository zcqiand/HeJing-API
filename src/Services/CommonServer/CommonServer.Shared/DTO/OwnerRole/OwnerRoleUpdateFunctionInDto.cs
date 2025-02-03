namespace CommonServer.Shared.DTO.OwnerRole;

/// <summary>
/// 角色
/// </summary>
public class OwnerRoleUpdateFunctionInDto : UpdateInBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 功能标识集合
    /// </summary>
    public IList<Guid> FunctionIds { get; set; } = new List<Guid>();
}


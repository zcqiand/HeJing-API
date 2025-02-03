namespace CommonServer.Shared.DTO.OwnerEntity;

/// <summary>
/// 机构
/// </summary>
public class OwnerEntityCreateInDto : CreateInBase
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Code { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string? ShortName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Address { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? ZipCode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Tel { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? ContactPerson { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? ContactPersonTel { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Remark { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool EnabledFlag { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int SortNo { get; set; }
}

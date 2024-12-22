using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CommonMormon.Infrastructure.Shared.DTO;

/// <summary>
/// 基类
/// </summary>
public class CreateInBase
{
    /// <summary>
    /// 创建时间
    /// </summary>
    [JsonIgnore]
    public DateTimeOffset CreateTime { get; set; } = DateTimeOffset.UtcNow;
    /// <summary>
    /// 创建人标识
    /// </summary>
    [JsonIgnore]
    public Guid? CreateUserId { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    [JsonIgnore]
    public DateTimeOffset LastModifyTime { get; set; } = DateTimeOffset.UtcNow;
    /// <summary>
    /// 最后更新人标识
    /// </summary>
    [JsonIgnore]
    public Guid? LastModifyUserId { get; set; }
}

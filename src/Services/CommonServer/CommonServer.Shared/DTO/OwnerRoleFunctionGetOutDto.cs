﻿namespace CommonServer.Shared.DTO.OwnerRoleFunction;

/// <summary>
/// 角色功能
/// </summary>
public class OwnerRoleFunctionGetOutDto : GetOutBase
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
    /// 资源标识
    /// </summary>
    public Guid? ResourceId { get; set; }
    /// <summary>
    /// 功能标识
    /// </summary>
    public Guid? FunctionId { get; set; }
}


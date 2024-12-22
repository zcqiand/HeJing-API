using CommonServer.Shared.DTO.OwnerEmployeeRole;

namespace CommonServer.API.Services;

/// <summary>
/// 员工角色
/// </summary>
public class OwnerEmployeeRoleService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OwnerEmployeeRoleService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OwnerEmployeeRoleCreateInDto input)
    {
        var model = Mapper.Map<OwnerEmployeeRole>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.OwnerEmployeeRoles.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OwnerEmployeeRoleUpdateInDto input)
    {
        var model = await DefaultDbContext.OwnerEmployeeRoles.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        model.LastModifyTime = DateTimeOffset.UtcNow;

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(OwnerEmployeeRoleDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerEmployeeRoles.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.OwnerEmployeeRoles.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OwnerEmployeeRoleBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerEmployeeRoles.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.OwnerEmployeeRoles.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<OwnerEmployeeRoleQueryOutDto>> Query(OwnerEmployeeRoleQueryInDto input)
    {
        var query = from a in DefaultDbContext.OwnerEmployeeRoles.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OwnerEmployeeRoleQueryOutDto>>(items);

        return new PagingOutBase<OwnerEmployeeRoleQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OwnerEmployeeRoleGetOutDto> Get(OwnerEmployeeRoleGetInDto input)
    {
        var query = from a in DefaultDbContext.OwnerEmployeeRoles.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OwnerEmployeeRoleGetOutDto>(items);
    }
}

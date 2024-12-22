using CommonServer.Shared.DTO.OwnerRole;

namespace CommonServer.API.Services;

/// <summary>
/// 角色
/// </summary>
public class OwnerRoleService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OwnerRoleService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OwnerRoleCreateInDto input)
    {
        var model = Mapper.Map<OwnerRole>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.OwnerRoles.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OwnerRoleUpdateInDto input)
    {
        var model = await DefaultDbContext.OwnerRoles.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OwnerRoleDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerRoles.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.OwnerRoles.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OwnerRoleBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerRoles.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.OwnerRoles.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<OwnerRoleQueryOutDto>> Query(OwnerRoleQueryInDto input)
    {
        var query = from a in DefaultDbContext.OwnerRoles.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OwnerRoleQueryOutDto>>(items);

        return new PagingOutBase<OwnerRoleQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OwnerRoleGetOutDto> Get(OwnerRoleGetInDto input)
    {
        var query = from a in DefaultDbContext.OwnerRoles.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OwnerRoleGetOutDto>(items);
    }
}

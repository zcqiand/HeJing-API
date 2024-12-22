using CommonServer.Shared.DTO.OwnerRoleFunction;

namespace CommonServer.API.Services;

/// <summary>
/// 角色功能
/// </summary>
public class OwnerRoleFunctionService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OwnerRoleFunctionService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OwnerRoleFunctionCreateInDto input)
    {
        var model = Mapper.Map<OwnerRoleFunction>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.OwnerRoleFunctions.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OwnerRoleFunctionUpdateInDto input)
    {
        var model = await DefaultDbContext.OwnerRoleFunctions.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OwnerRoleFunctionDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerRoleFunctions.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.OwnerRoleFunctions.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OwnerRoleFunctionBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerRoleFunctions.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.OwnerRoleFunctions.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<OwnerRoleFunctionQueryOutDto>> Query(OwnerRoleFunctionQueryInDto input)
    {
        var query = from a in DefaultDbContext.OwnerRoleFunctions.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OwnerRoleFunctionQueryOutDto>>(items);

        return new PagingOutBase<OwnerRoleFunctionQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OwnerRoleFunctionGetOutDto> Get(OwnerRoleFunctionGetInDto input)
    {
        var query = from a in DefaultDbContext.OwnerRoleFunctions.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OwnerRoleFunctionGetOutDto>(items);
    }
}

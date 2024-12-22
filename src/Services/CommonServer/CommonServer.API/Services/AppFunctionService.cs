using CommonServer.Shared.DTO.AppFunction;

namespace CommonServer.API.Services;

/// <summary>
/// 功能
/// </summary>
public class AppFunctionService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AppFunctionService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(AppFunctionCreateInDto input)
    {
        var model = Mapper.Map<AppFunction>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.AppFunctions.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(AppFunctionUpdateInDto input)
    {
        var model = await DefaultDbContext.AppFunctions.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(AppFunctionDeleteInDto input)
    {
        var model = await DefaultDbContext.AppFunctions.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.AppFunctions.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(AppFunctionBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.AppFunctions.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.AppFunctions.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<AppFunctionQueryOutDto>> Query(AppFunctionQueryInDto input)
    {
        var query = from a in DefaultDbContext.AppFunctions.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderBy(x=>x.SortNo)
            .ThenByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<AppFunctionQueryOutDto>>(items);

        return new PagingOutBase<AppFunctionQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<AppFunctionGetOutDto> Get(AppFunctionGetInDto input)
    {
        var query = from a in DefaultDbContext.AppFunctions.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<AppFunctionGetOutDto>(items);
    }
}

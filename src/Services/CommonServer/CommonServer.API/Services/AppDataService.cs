using CommonServer.Shared.DTO.AppData;

namespace CommonServer.API.Services;

/// <summary>
/// 数据
/// </summary>
public class AppDataService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AppDataService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(AppDataCreateInDto input)
    {
        var model = Mapper.Map<AppData>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.AppDatas.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(AppDataUpdateInDto input)
    {
        var model = await DefaultDbContext.AppDatas.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(AppDataDeleteInDto input)
    {
        var model = await DefaultDbContext.AppDatas.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.AppDatas.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(AppDataBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.AppDatas.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.AppDatas.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<AppDataQueryOutDto>> Query(AppDataQueryInDto input)
    {
        var query = from a in DefaultDbContext.AppDatas.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderBy(x => x.SortNo)
            .ThenByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<AppDataQueryOutDto>>(items);

        return new PagingOutBase<AppDataQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<AppDataGetOutDto> Get(AppDataGetInDto input)
    {
        var query = from a in DefaultDbContext.AppDatas.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<AppDataGetOutDto>(items);
    }
}

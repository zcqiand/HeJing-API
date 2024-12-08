using CommonServer.Shared.DTO.AppEntity;

namespace CommonServer.API.Services;

/// <summary>
/// 应用
/// </summary>
public class AppEntityService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AppEntityService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(AppEntityCreateInDto input)
    {
        var model = Mapper.Map<AppEntity>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.AppEntities.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(AppEntityUpdateInDto input)
    {
        var model = await DefaultDbContext.AppEntities.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        model.LastModifyTime = DateTimeOffset.Now;

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(AppEntityDeleteInDto input)
    {
        var model = await DefaultDbContext.AppEntities.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.AppEntities.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(AppEntityBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.AppEntities.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.AppEntities.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<AppEntityQueryOutDto>> Query(AppEntityQueryInDto input)
    {
        var query = from a in DefaultDbContext.AppEntities.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<AppEntityQueryOutDto>>(items);

        return new PagingOutBase<AppEntityQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<AppEntityGetOutDto> Get(AppEntityGetInDto input)
    {
        var query = from a in DefaultDbContext.AppEntities.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<AppEntityGetOutDto>(items);
    }
}

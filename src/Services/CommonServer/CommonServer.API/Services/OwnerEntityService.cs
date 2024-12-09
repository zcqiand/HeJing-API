using CommonServer.Shared.DTO.OwnerEntity;

namespace CommonServer.API.Services;

/// <summary>
/// 机构
/// </summary>
public class OwnerEntityService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OwnerEntityService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OwnerEntityCreateInDto input)
    {
        var model = Mapper.Map<OwnerEntity>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.OwnerEntities.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OwnerEntityUpdateInDto input)
    {
        var model = await DefaultDbContext.OwnerEntities.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OwnerEntityDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerEntities.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.OwnerEntities.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OwnerEntityBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerEntities.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.OwnerEntities.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<OwnerEntityQueryOutDto>> Query(OwnerEntityQueryInDto input)
    {
        var query = from a in DefaultDbContext.OwnerEntities.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OwnerEntityQueryOutDto>>(items);

        return new PagingOutBase<OwnerEntityQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OwnerEntityGetOutDto> Get(OwnerEntityGetInDto input)
    {
        var query = from a in DefaultDbContext.OwnerEntities.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OwnerEntityGetOutDto>(items);
    }
}

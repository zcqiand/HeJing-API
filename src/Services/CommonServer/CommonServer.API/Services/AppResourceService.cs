using CommonServer.Shared.DTO.AppResource;

namespace CommonServer.API.Services;

/// <summary>
/// 资源
/// </summary>
public class AppResourceService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AppResourceService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(AppResourceCreateInDto input)
    {
        var model = Mapper.Map<AppResource>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.AppResources.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(AppResourceUpdateInDto input)
    {
        var model = await DefaultDbContext.AppResources.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(AppResourceDeleteInDto input)
    {
        var model = await DefaultDbContext.AppResources.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.AppResources.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(AppResourceBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.AppResources.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.AppResources.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<AppResourceQueryOutDto>> Query(AppResourceQueryInDto input)
    {
        var query = from a in DefaultDbContext.AppResources.AsNoTracking()
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

        var itemDtos = Mapper.Map<IList<AppResourceQueryOutDto>>(items);

        return new PagingOutBase<AppResourceQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<AppResourceGetOutDto> Get(AppResourceGetInDto input)
    {
        var query = from a in DefaultDbContext.AppResources.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<AppResourceGetOutDto>(items);
    }

    /// <summary>
    /// 获取树清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<IList<AppResourceQueryTreeSelectOutDto>> QueryTreeSelect(AppResourceQueryInDto input)
    {
        var query = from a in DefaultDbContext.AppResources.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var items = await query
            .OrderBy(x => x.SortNo)
            .ToListAsync();

        var treeItems = items.ToTree<AppResource>(
            (r, c) =>
            {
                return c.ParentId == null;
            },
            (r, c) =>
            {
                return r.Id == c.ParentId;
            },
            (r, dataList) =>
            {
                r.Children ??= new List<AppResource>();
                r.Children.AddRange(dataList);
            });

        var itemDtos = Mapper.Map<IList<AppResourceQueryTreeSelectOutDto>>(treeItems);

        return itemDtos;
    }

    /// <summary>
    /// 获取树表格清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<IList<AppResourceQueryTreeTableOutDto>> QueryTreeTable(AppResourceQueryInDto input)
    {
        var query = from a in DefaultDbContext.AppResources.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var items = await query
            .OrderBy(x => x.SortNo)
            .ToListAsync();

        var treeItems = items.ToTree<AppResource>(
            (r, c) =>
            {
                return c.ParentId == null;
            },
            (r, c) =>
            {
                return r.Id == c.ParentId;
            },
            (r, dataList) =>
            {
                r.Children ??= new List<AppResource>();
                r.Children.AddRange(dataList);
            });

        var itemDtos = Mapper.Map<IList<AppResourceQueryTreeTableOutDto>>(treeItems);

        return itemDtos;
    }
}

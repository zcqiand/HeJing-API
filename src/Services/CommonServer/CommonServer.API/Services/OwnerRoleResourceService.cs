using CommonServer.Shared.DTO.OwnerRoleResource;

namespace CommonServer.API.Services;

/// <summary>
/// 角色资源
/// </summary>
public class OwnerRoleResourceService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OwnerRoleResourceService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OwnerRoleResourceCreateInDto input)
    {
        var model = Mapper.Map<OwnerRoleResource>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.OwnerRoleResources.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OwnerRoleResourceUpdateInDto input)
    {
        var model = await DefaultDbContext.OwnerRoleResources.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OwnerRoleResourceDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerRoleResources.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.OwnerRoleResources.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OwnerRoleResourceBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerRoleResources.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.OwnerRoleResources.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<OwnerRoleResourceQueryOutDto>> Query(OwnerRoleResourceQueryInDto input)
    {
        var query = from a in DefaultDbContext.OwnerRoleResources.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OwnerRoleResourceQueryOutDto>>(items);

        return new PagingOutBase<OwnerRoleResourceQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OwnerRoleResourceGetOutDto> Get(OwnerRoleResourceGetInDto input)
    {
        var query = from a in DefaultDbContext.OwnerRoleResources.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OwnerRoleResourceGetOutDto>(items);
    }
}

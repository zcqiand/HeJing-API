using CommonServer.Shared.DTO.OwnerRoleData;

namespace CommonServer.API.Services;

/// <summary>
/// 角色数据
/// </summary>
public class OwnerRoleDataService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OwnerRoleDataService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OwnerRoleDataCreateInDto input)
    {
        var model = Mapper.Map<OwnerRoleData>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.OwnerRoleDatas.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OwnerRoleDataUpdateInDto input)
    {
        var model = await DefaultDbContext.OwnerRoleDatas.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OwnerRoleDataDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerRoleDatas.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.OwnerRoleDatas.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OwnerRoleDataBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerRoleDatas.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.OwnerRoleDatas.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<OwnerRoleDataQueryOutDto>> Query(OwnerRoleDataQueryInDto input)
    {
        var query = from a in DefaultDbContext.OwnerRoleDatas.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OwnerRoleDataQueryOutDto>>(items);

        return new PagingOutBase<OwnerRoleDataQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OwnerRoleDataGetOutDto> Get(OwnerRoleDataGetInDto input)
    {
        var query = from a in DefaultDbContext.OwnerRoleDatas.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OwnerRoleDataGetOutDto>(items);
    }
}

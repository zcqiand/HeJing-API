using CommonServer.Shared.DTO.OwnerEmployee;

namespace CommonServer.API.Services;

/// <summary>
/// 员工
/// </summary>
public class OwnerEmployeeService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OwnerEmployeeService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OwnerEmployeeCreateInDto input)
    {
        var model = Mapper.Map<OwnerEmployee>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.OwnerEmployees.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OwnerEmployeeUpdateInDto input)
    {
        var model = await DefaultDbContext.OwnerEmployees.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OwnerEmployeeDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerEmployees.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.OwnerEmployees.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OwnerEmployeeBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerEmployees.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.OwnerEmployees.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<OwnerEmployeeQueryOutDto>> Query(OwnerEmployeeQueryInDto input)
    {
        var query = from a in DefaultDbContext.OwnerEmployees.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OwnerEmployeeQueryOutDto>>(items);

        return new PagingOutBase<OwnerEmployeeQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OwnerEmployeeGetOutDto> Get(OwnerEmployeeGetInDto input)
    {
        var query = from a in DefaultDbContext.OwnerEmployees.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OwnerEmployeeGetOutDto>(items);
    }
}

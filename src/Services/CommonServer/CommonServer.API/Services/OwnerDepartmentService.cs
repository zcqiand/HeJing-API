using CommonServer.Shared.DTO.OwnerDepartment;

namespace CommonServer.API.Services;

/// <summary>
/// 部门
/// </summary>
public class OwnerDepartmentService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OwnerDepartmentService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OwnerDepartmentCreateInDto input)
    {
        var model = Mapper.Map<OwnerDepartment>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.OwnerDepartments.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OwnerDepartmentUpdateInDto input)
    {
        var model = await DefaultDbContext.OwnerDepartments.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(OwnerDepartmentDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerDepartments.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.OwnerDepartments.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OwnerDepartmentBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerDepartments.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.OwnerDepartments.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<OwnerDepartmentQueryOutDto>> Query(OwnerDepartmentQueryInDto input)
    {
        var query = from a in DefaultDbContext.OwnerDepartments.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OwnerDepartmentQueryOutDto>>(items);

        return new PagingOutBase<OwnerDepartmentQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OwnerDepartmentGetOutDto> Get(OwnerDepartmentGetInDto input)
    {
        var query = from a in DefaultDbContext.OwnerDepartments.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OwnerDepartmentGetOutDto>(items);
    }
}

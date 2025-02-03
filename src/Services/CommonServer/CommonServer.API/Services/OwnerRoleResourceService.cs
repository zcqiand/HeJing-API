using CommonMormon.Infrastructure.Core.Extensions;
using CommonServer.Shared.DTO.OwnerRoleFunction;
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

        model.LastModifyTime = DateTimeOffset.UtcNow;

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
        var query = from a in DefaultDbContext.AppResources.AsNoTracking()
                    join b in DefaultDbContext.OwnerRoleResources.Where(x => x.RoleId == input.RoleId).AsNoTracking() on a.Id equals b.ResourceId into outJoin
                    from b in outJoin.DefaultIfEmpty()
                    select new { a, b };

        #region filter
        query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Title), x => x.a.Title.Contains(input.Title!));
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderBy(x => x.a.SortNo)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        List<OwnerRoleResourceQueryOutDto> itemDtos;
        if (items != null && items.Count > 0)
        {
            itemDtos = (from x in items
                       select new OwnerRoleResourceQueryOutDto
                       {
                           RoleId = x.b?.RoleId,
                           ResourceId = x.a.Id,
                           ParentResourceId = x.a.ParentId,
                           Title = x.a.Title,
                           Id = x.b?.Id,
                           CreateTime = x.b?.CreateTime,
                           LastModifyTime = x.b?.LastModifyTime
                       }).ToList();
        }
        else
        {
            itemDtos = [];
        }

        var treeItemDtos = itemDtos.ToTree<OwnerRoleResourceQueryOutDto>(
            (r, c) =>
            {
                return c.ParentResourceId == null;
            },
            (r, c) =>
            {
                return r.ResourceId == c.ParentResourceId;
            },
            (r, dataList) =>
            {
                r.Children ??= new List<OwnerRoleResourceQueryOutDto>();
                r.Children.AddRange(dataList);
            });

        return new PagingOutBase<OwnerRoleResourceQueryOutDto>(total, treeItemDtos);
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

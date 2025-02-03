using CommonServer.Shared.DTO.OwnerRole;

namespace CommonServer.API.Services;

/// <summary>
/// 角色
/// </summary>
public class OwnerRoleService : ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public OwnerRoleService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(OwnerRoleCreateInDto input)
    {
        var model = Mapper.Map<OwnerRole>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await DefaultDbContext.OwnerRoles.AddAsync(model);

        await DefaultDbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(OwnerRoleUpdateInDto input)
    {
        var model = await DefaultDbContext.OwnerRoles.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        model.LastModifyTime = DateTimeOffset.UtcNow;

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 维护成员
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> UpdateEmployee(OwnerRoleUpdateEmployeeInDto input)
    {
        // 1. 获取表中已有的数据
        var existingEmployees = await DefaultDbContext.OwnerEmployeeRoles
            .Where(x => x.RoleId == input.Id)
            .ToListAsync();

        // 2. 找出需要插入的数据
        var employeesToAdd = input.EmployeeIds
            .Where(employeeId => !existingEmployees.Any(x => x.EmployeeId == employeeId))
            .Select(employeeId => new OwnerEmployeeRole
            {
                Id = NewId.NextSequentialGuid(),
                EmployeeId = employeeId,
                RoleId = input.Id
            })
            .ToList();

        // 3. 找出需要删除的数据
        var employeesToRemove = existingEmployees
            .Where(x => !input.EmployeeIds.Contains(x.EmployeeId))
            .ToList();

        // 4. 执行数据库操作
        if (employeesToAdd.Any())
        {
            await DefaultDbContext.OwnerEmployeeRoles.AddRangeAsync(employeesToAdd);
        }

        if (employeesToRemove.Any())
        {
            DefaultDbContext.OwnerEmployeeRoles.RemoveRange(employeesToRemove);
        }

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 功能授权
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> UpdateFunction(OwnerRoleUpdateFunctionInDto input)
    {
        // 1. 获取表中已有的数据
        var existingFunctions = await DefaultDbContext.OwnerRoleFunctions
            .Where(x => x.RoleId == input.Id)
            .ToListAsync();

        // 2. 找出需要插入的数据
        var functionsToAdd = input.FunctionIds
            .Where(functionId => !existingFunctions.Any(x => x.FunctionId == functionId))
            .Select(functionId => new OwnerRoleFunction
            {
                Id = NewId.NextSequentialGuid(),
                FunctionId = functionId,
                RoleId = input.Id
            })
            .ToList();

        // 3. 找出需要删除的数据
        var functionsToRemove = existingFunctions
            .Where(x => !input.FunctionIds.Contains(x.FunctionId))
            .ToList();

        // 4. 执行数据库操作
        if (functionsToAdd.Any())
        {
            await DefaultDbContext.OwnerRoleFunctions.AddRangeAsync(functionsToAdd);
        }

        if (functionsToRemove.Any())
        {
            DefaultDbContext.OwnerRoleFunctions.RemoveRange(functionsToRemove);
        }

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 资源授权
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> UpdateResource(OwnerRoleUpdateResourceInDto input)
    {
        // 1. 获取表中已有的数据
        var existingResources = await DefaultDbContext.OwnerRoleResources
            .Where(x => x.RoleId == input.Id)
            .ToListAsync();

        // 2. 找出需要插入的数据
        var resourcesToAdd = input.ResourceIds
            .Where(resourceId => !existingResources.Any(x => x.ResourceId == resourceId))
            .Select(resourceId => new OwnerRoleResource
            {
                Id = NewId.NextSequentialGuid(),
                ResourceId = resourceId,
                RoleId = input.Id
            })
            .ToList();

        // 3. 找出需要删除的数据
        var resourcesToRemove = existingResources
            .Where(x => !input.ResourceIds.Contains(x.ResourceId))
            .ToList();

        // 4. 执行数据库操作
        if (resourcesToAdd.Any())
        {
            await DefaultDbContext.OwnerRoleResources.AddRangeAsync(resourcesToAdd);
        }

        if (resourcesToRemove.Any())
        {
            DefaultDbContext.OwnerRoleResources.RemoveRange(resourcesToRemove);
        }

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(OwnerRoleDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerRoles.SingleAsync(x => x.Id.Equals(input.Id));

        DefaultDbContext.OwnerRoles.Remove(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(OwnerRoleBatchDeleteInDto input)
    {
        var model = await DefaultDbContext.OwnerRoles.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        DefaultDbContext.OwnerRoles.RemoveRange(model);

        await DefaultDbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<OwnerRoleQueryOutDto>> Query(OwnerRoleQueryInDto input)
    {
        var query = from a in DefaultDbContext.OwnerRoles.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<OwnerRoleQueryOutDto>>(items);

        return new PagingOutBase<OwnerRoleQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<OwnerRoleGetOutDto> Get(OwnerRoleGetInDto input)
    {
        var query = from a in DefaultDbContext.OwnerRoles.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<OwnerRoleGetOutDto>(items);
    }
}

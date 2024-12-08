using CommonServer.API.Services;
using CommonServer.Shared.DTO.OwnerRoleResource;

namespace CommonServer.API.Controllers;

/// <summary>
/// 角色资源
/// </summary>
public class OwnerRoleResourceController : AppControllerBase
{
    private readonly OwnerRoleResourceService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public OwnerRoleResourceController(IServiceProvider serviceProvider, OwnerRoleResourceService service) :
        base(serviceProvider)
    {
        _service = service;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<Guid>> Create(OwnerRoleResourceCreateInDto input)
    {
        var result = await _service.Create(input);
        return Success(result);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<bool>> Update(OwnerRoleResourceUpdateInDto input)
    {
        var result = await _service.Update(input);
        return Success(result);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<bool>> Delete(OwnerRoleResourceDeleteInDto input)
    {
        var result = await _service.Delete(input);
        return Success(result);
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<bool>> BatchDelete(OwnerRoleResourceBatchDeleteInDto input)
    {
        var result = await _service.BatchDelete(input);
        return Success(result);
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<PagingOutBase<OwnerRoleResourceQueryOutDto>>> Query([FromQuery] OwnerRoleResourceQueryInDto input)
    {
        var result = await _service.Query(input);
        return Success(result);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<OwnerRoleResourceGetOutDto>> Get([FromQuery] OwnerRoleResourceGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }
}
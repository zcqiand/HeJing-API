using CommonServer.API.Services;
using CommonServer.Shared.DTO.OwnerDepartment;

namespace CommonServer.API.Controllers;

/// <summary>
/// 部门
/// </summary>
public class OwnerDepartmentController : AppControllerBase
{
    private readonly OwnerDepartmentService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public OwnerDepartmentController(IServiceProvider serviceProvider, OwnerDepartmentService service) :
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
    public async Task<ApiResult<Guid>> Create(OwnerDepartmentCreateInDto input)
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
    public async Task<ApiResult<bool>> Update(OwnerDepartmentUpdateInDto input)
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
    public async Task<ApiResult<bool>> Delete(OwnerDepartmentDeleteInDto input)
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
    public async Task<ApiResult<bool>> BatchDelete(OwnerDepartmentBatchDeleteInDto input)
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
    public async Task<ApiResult<PagingOutBase<OwnerDepartmentQueryOutDto>>> Query([FromQuery] OwnerDepartmentQueryInDto input)
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
    public async Task<ApiResult<OwnerDepartmentGetOutDto>> Get([FromQuery] OwnerDepartmentGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }



    /// <summary>
    /// 获取树下拉框清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<IList<OwnerDepartmentQueryTreeSelectOutDto>>> QueryTreeSelect([FromQuery] OwnerDepartmentQueryInDto input)
    {
        var data = await _service.QueryTreeSelect(input);
        return Success(data);
    }

    /// <summary>
    /// 获取树表格清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<IList<OwnerDepartmentQueryTreeTableOutDto>>> QueryTreeTable([FromQuery] OwnerDepartmentQueryInDto input)
    {
        var data = await _service.QueryTreeTable(input);
        return Success(data);
    }
}
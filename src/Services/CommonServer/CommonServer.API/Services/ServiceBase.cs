namespace CommonServer.API.Services;

/// <summary>
/// 服务基类
/// </summary>
public class ServiceBase : CommonMormon.Infrastructure.API.Services.ServiceBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ServiceBase(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        DefaultDbContext = serviceProvider.GetRequiredService<CommonServerDbContext>();
    }

    /// <summary>
    /// 数据库上下文
    /// </summary>
    protected CommonServerDbContext DefaultDbContext { get; }
}

﻿namespace CommonServer.API.Options;

/// <summary>
/// 应用设置
/// </summary>
public class CommonServerApiConfiguration
{
    public string ApiName { get; set; } = null!;

    public string ApiVersion { get; set; } = null!;

    public string CommonServerBaseUrl { get; set; } = null!;

    public string ApiBaseUrl { get; set; } = null!;

    public string OidcSwaggerUIClientId { get; set; } = null!;

    public bool RequireHttpsMetadata { get; set; }

    public string OidcApiName { get; set; } = null!;

    public string AdministrationRole { get; set; } = null!;

    public bool CorsAllowAnyOrigin { get; set; }

    public string[]? CorsAllowOrigins { get; set; }
}

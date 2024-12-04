using CommonServer.Shared.DTO.AppData;
using CommonServer.Shared.DTO.AppFunction;
using CommonServer.Shared.DTO.AppOperationLog;
using CommonServer.Shared.DTO.AppResource;
using CommonServer.Shared.DTO.Apps;
using CommonServer.Shared.DTO.OrganDepartment;
using CommonServer.Shared.DTO.OrganEmployee;
using CommonServer.Shared.DTO.OrganRole;
using CommonServer.Shared.DTO.OrganRoleData;
using CommonServer.Shared.DTO.OrganRoleFunction;
using CommonServer.Shared.DTO.OrganRoleResource;
using CommonServer.Shared.DTO.Organs;
using CommonServer.Shared.DTO.OrganEmployeeRole;

namespace CommonServer.API.Mappers;

/// <summary>
/// 
/// </summary>
public class DtoToDomainProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public DtoToDomainProfile()
    {
        #region Apps
        CreateMap<AppsCreateInDto, AppEntity>();
        CreateMap<AppsUpdateInDto, AppEntity>();
        CreateMap<AppEntity, AppsQueryOutDto>();
        CreateMap<AppEntity, AppsGetOutDto>();
        #endregion

        #region AppResource
        CreateMap<AppResourceCreateInDto, AppResource>();
        CreateMap<AppResourceUpdateInDto, AppResource>();
        CreateMap<AppResource, AppResourceQueryOutDto>();
        CreateMap<AppResource, AppResourceQueryTreeSelectOutDto>();
        CreateMap<AppResource, AppResourceGetOutDto>();
        #endregion

        #region AppFunction
        CreateMap<AppFunctionCreateInDto, AppFunction>();
        CreateMap<AppFunctionUpdateInDto, AppFunction>();
        CreateMap<AppFunction, AppFunctionQueryOutDto>();
        CreateMap<AppFunction, AppFunctionGetOutDto>();
        #endregion

        #region AppData
        CreateMap<AppsDataCreateInDto, AppData>();
        CreateMap<AppDataUpdateInDto, AppData>();
        CreateMap<AppData, AppDataQueryOutDto>();
        CreateMap<AppData, AppDataGetOutDto>();
        #endregion

        #region AppOperationLog
        CreateMap<AppOperationLogCreateInDto, AppOperationLog>();
        CreateMap<AppOperationLogUpdateInDto, AppOperationLog>();
        CreateMap<AppOperationLog, AppOperationLogQueryOutDto>();
        CreateMap<AppOperationLog, AppOperationLogGetOutDto>();
        #endregion

        #region Organs
        CreateMap<OrgansCreateInDto, OwnerEntity>();
        CreateMap<OrgansUpdateInDto, OwnerEntity>();
        CreateMap<OwnerEntity, OrgansQueryOutDto>();
        CreateMap<OwnerEntity, OrgansGetOutDto>();
        #endregion

        #region OrganEmployeeRole
        CreateMap<OrganEmployeeRoleCreateInDto, OwnerEmployeeRole>();
        CreateMap<OrganEmployeeRoleUpdateInDto, OwnerEmployeeRole>();
        CreateMap<OwnerEmployeeRole, OrganEmployeeRoleQueryOutDto>();
        CreateMap<OwnerEmployeeRole, OrganEmployeeRoleGetOutDto>();
        #endregion

        #region OrganRole
        CreateMap<OrganRoleCreateInDto, OwnerRole>();
        CreateMap<OrganRoleUpdateInDto, OwnerRole>();
        CreateMap<OwnerRole, OrganRoleQueryOutDto>();
        CreateMap<OwnerRole, OrganRoleGetOutDto>();
        #endregion

        #region OrganRoleResource
        CreateMap<OrganRoleResourceCreateInDto, OwnerRoleResource>();
        CreateMap<OrganRoleResourceUpdateInDto, OwnerRoleResource>();
        CreateMap<OwnerRoleResource, OrganRoleResourceQueryOutDto>();
        CreateMap<OwnerRoleResource, OrganRoleResourceGetOutDto>();
        #endregion

        #region OrganRoleFunction
        CreateMap<OrganRoleFunctionCreateInDto, OwnerRoleFunction>();
        CreateMap<OrganRoleFunctionUpdateInDto, OwnerRoleFunction>();
        CreateMap<OwnerRoleFunction, OrganRoleFunctionQueryOutDto>();
        CreateMap<OwnerRoleFunction, OrganRoleFunctionGetOutDto>();
        #endregion

        #region OrganRoleData
        CreateMap<OrganRoleDataCreateInDto, OwnerRoleData>();
        CreateMap<OrganRoleDataUpdateInDto, OwnerRoleData>();
        CreateMap<OwnerRoleData, OrganRoleDataQueryOutDto>();
        CreateMap<OwnerRoleData, OrganRoleDataGetOutDto>();
        #endregion

        #region OrganDepartment
        CreateMap<OrganDepartmentCreateInDto, OwnerDepartment>();
        CreateMap<OrganDepartmentUpdateInDto, OwnerDepartment>();
        CreateMap<OwnerDepartment, OrganDepartmentQueryOutDto>();
        CreateMap<OwnerDepartment, OrganDepartmentQueryTreeSelectOutDto>();
        CreateMap<OwnerDepartment, OrganDepartmentGetOutDto>();
        #endregion

        #region OrganEmployee
        CreateMap<OrganEmployeeCreateInDto, OwnerEmployee>();
        CreateMap<OrganEmployeeUpdateInDto, OwnerEmployee>();
        CreateMap<OwnerEmployee, OrganEmployeeQueryOutDto>();
        CreateMap<OwnerEmployee, OrganEmployeeGetOutDto>();
        #endregion
    }
}
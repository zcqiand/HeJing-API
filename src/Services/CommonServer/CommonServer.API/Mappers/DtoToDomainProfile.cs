using CommonServer.Shared.DTO.AppData;
using CommonServer.Shared.DTO.AppEntity;
using CommonServer.Shared.DTO.AppFunction;
using CommonServer.Shared.DTO.AppOperationLog;
using CommonServer.Shared.DTO.AppResource;
using CommonServer.Shared.DTO.OwnerDepartment;
using CommonServer.Shared.DTO.OwnerEmployee;
using CommonServer.Shared.DTO.OwnerEmployeeRole;
using CommonServer.Shared.DTO.OwnerEntity;
using CommonServer.Shared.DTO.OwnerRole;
using CommonServer.Shared.DTO.OwnerRoleData;
using CommonServer.Shared.DTO.OwnerRoleFunction;
using CommonServer.Shared.DTO.OwnerRoleResource;

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

        #region AppEntity
        CreateMap<AppEntityCreateInDto, AppEntity>();
        CreateMap<AppEntityUpdateInDto, AppEntity>();
        CreateMap<AppEntity, AppEntityQueryOutDto>();
        CreateMap<AppEntity, AppEntityGetOutDto>();
        #endregion

        #region AppResource
        CreateMap<AppResourceCreateInDto, AppResource>();
        CreateMap<AppResourceUpdateInDto, AppResource>();
        CreateMap<AppResource, AppResourceQueryOutDto>();
        CreateMap<AppResource, AppResourceGetOutDto>();
        CreateMap<AppResource, AppResourceQueryTreeSelectOutDto>();
        CreateMap<AppResource, AppResourceQueryTreeTableOutDto>();
        #endregion

        #region AppFunction
        CreateMap<AppFunctionCreateInDto, AppFunction>();
        CreateMap<AppFunctionUpdateInDto, AppFunction>();
        CreateMap<AppFunction, AppFunctionQueryOutDto>();
        CreateMap<AppFunction, AppFunctionGetOutDto>();
        #endregion

        #region AppData
        CreateMap<AppDataCreateInDto, AppData>();
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

        #region OwnerEntity
        CreateMap<OwnerEntityCreateInDto, OwnerEntity>();
        CreateMap<OwnerEntityUpdateInDto, OwnerEntity>();
        CreateMap<OwnerEntity, OwnerEntityQueryOutDto>();
        CreateMap<OwnerEntity, OwnerEntityGetOutDto>();
        #endregion

        #region OwnerDepartment
        CreateMap<OwnerDepartmentCreateInDto, OwnerDepartment>();
        CreateMap<OwnerDepartmentUpdateInDto, OwnerDepartment>();
        CreateMap<OwnerDepartment, OwnerDepartmentQueryOutDto>();
        CreateMap<OwnerDepartment, OwnerDepartmentGetOutDto>();
        CreateMap<OwnerDepartment, OwnerDepartmentQueryTreeSelectOutDto>();
        CreateMap<OwnerDepartment, OwnerDepartmentQueryTreeTableOutDto>();
        #endregion

        #region OwnerEmployee
        CreateMap<OwnerEmployeeCreateInDto, OwnerEmployee>();
        CreateMap<OwnerEmployeeUpdateInDto, OwnerEmployee>();
        CreateMap<OwnerEmployee, OwnerEmployeeQueryOutDto>();
        CreateMap<OwnerEmployee, OwnerEmployeeGetOutDto>();
        #endregion

        #region OwnerEmployeeRole
        CreateMap<OwnerEmployeeRoleCreateInDto, OwnerEmployeeRole>();
        CreateMap<OwnerEmployeeRoleUpdateInDto, OwnerEmployeeRole>();
        CreateMap<OwnerEmployeeRole, OwnerEmployeeRoleQueryOutDto>();
        CreateMap<OwnerEmployeeRole, OwnerEmployeeRoleGetOutDto>();
        #endregion

        #region OwnerRole
        CreateMap<OwnerRoleCreateInDto, OwnerRole>();
        CreateMap<OwnerRoleUpdateInDto, OwnerRole>();
        CreateMap<OwnerRole, OwnerRoleQueryOutDto>();
        CreateMap<OwnerRole, OwnerRoleGetOutDto>();
        #endregion

        #region OwnerRoleResource
        CreateMap<OwnerRoleResourceCreateInDto, OwnerRoleResource>();
        CreateMap<OwnerRoleResourceUpdateInDto, OwnerRoleResource>();
        CreateMap<OwnerRoleResource, OwnerRoleResourceQueryOutDto>();
        CreateMap<OwnerRoleResource, OwnerRoleResourceGetOutDto>();
        #endregion

        #region OwnerRoleFunction
        CreateMap<OwnerRoleFunctionCreateInDto, OwnerRoleFunction>();
        CreateMap<OwnerRoleFunctionUpdateInDto, OwnerRoleFunction>();
        CreateMap<OwnerRoleFunction, OwnerRoleFunctionQueryOutDto>();
        CreateMap<OwnerRoleFunction, OwnerRoleFunctionGetOutDto>();
        #endregion

        #region OwnerRoleData
        CreateMap<OwnerRoleDataCreateInDto, OwnerRoleData>();
        CreateMap<OwnerRoleDataUpdateInDto, OwnerRoleData>();
        CreateMap<OwnerRoleData, OwnerRoleDataQueryOutDto>();
        CreateMap<OwnerRoleData, OwnerRoleDataGetOutDto>();
        #endregion
    }
}
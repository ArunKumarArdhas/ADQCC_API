using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MODELS.COMMON;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IMasterRepository:IGenericRepository<GET_LOCATION_MASTER>
    {
        //NATIONALITY MASTER
        Task<IReadOnlyList<NATIONALITY_MASTER>> GetNationalityDetails();
        //LOCATION MASTER
        Task<RETURN_MESSAGE> AddAsync(GET_LOCATION_MASTER entity);
        Task<IReadOnlyList<GET_LOCATION_MASTER>> GetAllAsync();
        //BUILDINGMASTER
        Task<RETURN_MESSAGE> Add_Building(ADD_BUILDING_MASTER entity);
        Task<IReadOnlyList<GET_BUILDING_MASTER>> GetAll_Buildings();
        //DEPARTMENT_MASTER
        Task<IReadOnlyList<GET_DEPARTMENT_MASTER>> GetAll_Department();
        Task<RETURN_MESSAGE> AddDepartment(ADD_DEPARTMENT_MASTER DEPT);
        Task<GET_DEPARTMENT_MASTER> GetDepartmentById(GET_DEPARTMENT_MASTER model);
        //DESIGNATION
        Task<IReadOnlyList<GET_DESIGNATION_DETAILS>> GetDesignationDetails();
        Task<RETURN_MESSAGE> AddDesignationDetails(DesignationModel model);
        Task<DesignationModel> GetDesignationById(DesignationModel model);
        //SECTION_LAB_MASTER
        Task<RETURN_MESSAGE> AddSectionLab(ADD_SECTION_LAB_MASTER entity);
        Task<IReadOnlyList<GET_SECTION_LAB_MASTER>> GetSectionLabMaster();
        //EMERGENCY_TYPE_MASTER
        Task<IReadOnlyList<GET_EMR_TYPE_MASTER>> GetEmergTypeMaster();
        Task<RETURN_MESSAGE> AddEmergTypeMaster(ADD_EMR_TYPE_MASTER entity);
        //SECTOR
        Task<RETURN_MESSAGE> AddSectorDetails(SectorModel model);
        Task<IReadOnlyList<GET_SECTOR_DETAILS>> GetAll_Sector();
        //SECTOR_TYPE
        Task<RETURN_MESSAGE> AddSectorTypeDetails(SectorTypeModel model);
        Task<IReadOnlyList<SectorTypeModel>> GetSectorTypeDetails();
    }
}

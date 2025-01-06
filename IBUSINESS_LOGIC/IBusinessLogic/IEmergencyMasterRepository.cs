using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADQCC_New.Models.Emergency;
using MODELS;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IEmergencyMasterRepository  : IGenericRepository<M_EmergencyModel>
    {
        Task<M_EmergencyModel> GetByIdAsync(M_EmergencyModel entity);
        Task<RETURN_MESSAGE> DeleteAsync(M_EmergencyModel entity);
        Task<RETURN_MESSAGE> UpdateAsync(M_EmergencyModel entity);


        Task<RETURN_MESSAGE> Add_UnSafeCond(UNSAFECONDITION_MASTER entity);
        Task<UNSAFECONDITION_MASTER> GetUnSafeCondById(UNSAFECONDITION_MASTER IM_UNSAFE_ID);
        Task<IReadOnlyList<UNSAFECONDITION_MASTER>> GetAllUnSafeCond();
        Task<RETURN_MESSAGE> DeleteUnSafeCond(UNSAFECONDITION_MASTER IM_UNSAFE_ID);


        Task<RETURN_MESSAGE> AddRootPersonal(ROOT_CAUSE_PERSONAL_MASTER entity);
        Task<ROOT_CAUSE_PERSONAL_MASTER> GetPersonalById(ROOT_CAUSE_PERSONAL_MASTER ROOT_CAUSE_ID);
        Task<IReadOnlyList<ROOT_CAUSE_PERSONAL_MASTER>> GetAllRootPersonal();
        Task<RETURN_MESSAGE> DeletePersonal(ROOT_CAUSE_PERSONAL_MASTER ROOT_CAUSE_ID);


        Task<RETURN_MESSAGE> AddRootSystem(ROOT_CAUSE_SYSTEM_MASTER entity);
        Task<ROOT_CAUSE_SYSTEM_MASTER> GetSystemById(ROOT_CAUSE_SYSTEM_MASTER RC_SF_ID);
        Task<IReadOnlyList<ROOT_CAUSE_SYSTEM_MASTER>> GetAllRootSystem();
        Task<RETURN_MESSAGE> DeleteSystem(ROOT_CAUSE_SYSTEM_MASTER RC_SF_ID);


        Task<RETURN_MESSAGE> AddRootMethod(ROOT_CAUSE_METHOD_MASTER entity);
        Task<ROOT_CAUSE_METHOD_MASTER> GetMethodById(ROOT_CAUSE_METHOD_MASTER RC_METHOD_ID);
        Task<IReadOnlyList<ROOT_CAUSE_METHOD_MASTER>> GetAllRootMethod();
        Task<RETURN_MESSAGE> DeleteMethod(ROOT_CAUSE_METHOD_MASTER RC_METHOD_ID);


        Task<IReadOnlyList<ROOT_CAUSE_ENVIRONMENT_MASTER>> GetEMRRCEnvironment();
        Task<ROOT_CAUSE_ENVIRONMENT_MASTER> GetCauseById(ROOT_CAUSE_ENVIRONMENT_MASTER RC_ENVIRONMENT_ID);
        Task<RETURN_MESSAGE> AddEEMRRCEnvironment(ROOT_CAUSE_ENVIRONMENT_MASTER entity);
        Task<RETURN_MESSAGE> DeleteEnvironment(ROOT_CAUSE_ENVIRONMENT_MASTER RC_ENVIRONMENT_ID);


        Task<IReadOnlyList<ROOT_CAUSE_MATERIAL_MASTER>> GetEMRRCMaterial();
        Task<ROOT_CAUSE_MATERIAL_MASTER> GetCauseMaterialById(ROOT_CAUSE_MATERIAL_MASTER RC_MATERIAL_ID);
        Task<RETURN_MESSAGE> AddEEMRRCMaterial(ROOT_CAUSE_MATERIAL_MASTER entity);
        Task<RETURN_MESSAGE> DeleteMaterial(ROOT_CAUSE_MATERIAL_MASTER RC_MATERIAL_ID);


        Task<NATURE_INJURY_DETAILS> GetNatureById(NATURE_INJURY_DETAILS NATURE_INJURY_ID);
        Task<IReadOnlyList<NATURE_INJURY_DETAILS>> GetEMRNIIDetails();
        Task<RETURN_MESSAGE> AddEMRNII(NATURE_INJURY_DETAILS entity);
        Task<RETURN_MESSAGE> DeleteNature(NATURE_INJURY_DETAILS NATURE_INJURY_ID);


        Task<IReadOnlyList<MECH_INJURY_DETAILS>> GetEMRMIIDetails();
        Task<MECH_INJURY_DETAILS> GetInjuryById(MECH_INJURY_DETAILS MECH_INJURY_ID);
        Task<RETURN_MESSAGE> AddEMRMII(MECH_INJURY_DETAILS entity);
        Task<RETURN_MESSAGE> DeleteMechanism(MECH_INJURY_DETAILS MECH_INJURY_ID);


        Task<IReadOnlyList<AGENCY_INJURY_DETAILS>> GetEMRAIIDetails();
        Task<AGENCY_INJURY_DETAILS> GetAgencyInjuryById(AGENCY_INJURY_DETAILS AGENCY_INJURY_ID);
        Task<RETURN_MESSAGE> AddEMRAII(AGENCY_INJURY_DETAILS entity);
        Task<RETURN_MESSAGE> DeleteAgency(AGENCY_INJURY_DETAILS AGENCY_INJURY_ID);


        Task<IReadOnlyList<INCIDENT_DETAILS>> GetemrINCDTCAdetails();
        Task<INCIDENT_DETAILS> GetIncidentCauseById(INCIDENT_DETAILS INCDT_CAS_ID);
        Task<RETURN_MESSAGE> AddemrINCDTCA(INCIDENT_DETAILS _AddEMRINCDTCA);
        Task<RETURN_MESSAGE> DeleteIncidentCause(INCIDENT_DETAILS INCDT_CAS_ID);


        Task<IReadOnlyList<INCIDENT_CATEGORY_DETAILS>> GetIncidentCategory();
        Task<INCIDENT_CATEGORY_DETAILS> GetIncidentById(INCIDENT_CATEGORY_DETAILS INC_ID);
        Task<RETURN_MESSAGE> AddIncidentCategory(INCIDENT_CATEGORY_DETAILS _INC_CAT_MASTER);
        Task<RETURN_MESSAGE> DeleteIncidentCategory(INCIDENT_CATEGORY_DETAILS INC_CAT_ID);


        //Task<IReadOnlyList<GET_DRILL_TYPE>> GetDrill_Management_Type();
        //Task<GET_DRILL_TYPE> GetDrillTypeById(GET_DRILL_TYPE DRILL_TYPE_ID);
        //Task<RETURN_MESSAGE> Add_Drill_Management_Type(ADD_DRILL_TYPE _AddDrillType);
        //Task<IReadOnlyList<GET_DRILL_CHECKLIST>> Get_Drill_Checklist();
        //Task<GET_DRILL_CHECKLIST> GetDrillChecklistById(GET_DRILL_CHECKLIST DRILL_TYPE_ID);
        //Task<RETURN_MESSAGE> Add_Drill_CheckList(ADD_DRILL_CHECKLIST _DRILL_CHECKLIST);


        Task<RETURN_MESSAGE> AddDiasterType(DISASTER_TYPE_MASTER entity);
        Task<DISASTER_TYPE_MASTER> GetDiasterTypeById(DISASTER_TYPE_MASTER DISASTER_ID);
        Task<IReadOnlyList<DISASTER_TYPE_MASTER>> GetAllDiasterType();
        Task<RETURN_MESSAGE> DeleteDisasterType(DISASTER_TYPE_MASTER DISASTER_ID);


        //Task<RETURN_MESSAGE> AddEMRMaster(ADD_EMERGENCY_TYPE_MASTER_SELECT entity);
        //Task<IReadOnlyList<GET_EMERGENCY_TYPE_MASTER_SELECT>> GetAll_EMRMaster();
        //Task<RETURN_MESSAGE> AddEMRCorrective(ADD_EMERGENCY_TYPE_CORRECTIVE_ACTION entity);
        //Task<IReadOnlyList<Get_EMERGENCY_TYPE_CORRECTIVE_ACTION>> GetAll_EMRCorrective();


    }
}

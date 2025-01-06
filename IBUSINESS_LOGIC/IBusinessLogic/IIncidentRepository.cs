using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IIncidentRepository
    {
        Task<IReadOnlyList<GET_INCIDENT_CATEGORY_DETAILS>> GetIncidentCategory();
        Task<GET_INCIDENT_CATEGORY_DETAILS> GetIncidentById(GET_INCIDENT_CATEGORY_DETAILS INC_ID);
        Task<RETURN_MESSAGE> AddIncidentCategory(IncidentCategoryModel _INC_CAT_MASTER);
        Task<List<GET_INCIDENT_DETAILS>> GetIncident(string EMP_LOGIN_ID, string DESI_NAME);
        Task<RETURN_MESSAGE> AddIncident(IncidentModel _INC_DETAILS);
        Task<IReadOnlyList<GET_EMR_INCDT_CA_DETAILS>> GetemrINCDTCAdetails();
        Task<GET_EMR_INCDT_CA_DETAILS> GetIncidentCauseById(GET_EMR_INCDT_CA_DETAILS INCDT_CAS_ID);
        Task<RETURN_MESSAGE> AddemrINCDTCA(ADD_EMR_INCDT_CA_MASTER _AddEMRINCDTCA);
        Task<List<GET_INCIDENT_DETAILS>> GetInvestigationList(string INC_STATUS_ID, string EMP_LOGIN_ID, string DESI_NAME);
        Task<List<GET_INCIDENT_DETAILS>> GetEHSAlertIncident();
        Task<List<GET_INVE_CORRECTIVE_ACTION>> GetCorrectiveInvestList(string LOGIN_ID, string DESIG_NAME);
        Task<VIEW_INCIDENT_DETAILS_LIST> ViewIncident(string INCID);
        Task<IReadOnlyList<GET_EMPLOYEE_DETAILS_REPORTABLE>> GetReporterBy();
        Task<RETURN_MESSAGE> UpdateIncidentStatus(UPDATE_INCIDENT_STATUS updateIncidentStatus);
        Task<IReadOnlyList<GET_EMR_NATURE_INJURY_DETAILS>> GetEMRNIIDetails();
        Task<IReadOnlyList<GET_EMR_MECH_INJURY_DETAILS>> GetEMRMIIDetails();
        Task<IReadOnlyList<GET_EMR_AGENCY_INJURY_DETAILS>> GetEMRAIIDetails();
        Task<IReadOnlyList<GET_EMR_BODY_LOC_CAT_DETAILS>> GetemrBODYLOCCATdetails();
        Task<IReadOnlyList<GET_EMR_IC_ACT_DETAILS>> GetEMRICActDetails();
        Task<IReadOnlyList<GET_EMR_IC_UC_DETAILS>> GetEMRICUCDetails();
        Task<IReadOnlyList<GET_EMR_RC_PF_DETAILS>> GetEMRRCPFDetails();
        Task<IReadOnlyList<GET_EMR_RC_SF_DETAILS>> GetEMRRCSFDetails();
        Task<RETURN_MESSAGE> ADD_INVESTIGATION(INVESTCATION_DETAILS investigationDetails);
        Task<RETURN_MESSAGE> AddSitePhotoUpload(List<SITE_INSPECTION_PHOTO_LIST> siteInspectionPhotoList);
        Task<GET_EMR_INCDT_CA_DETAILS> GET_VIEW_INVE_REVIEW_AND_APPROVALS(string INC_ID);
        Task<GET_INVE_EHS_ALERT> GetAlertList(string INC_ID);
        Task<GET_EMR_IC_ACT_DETAILS> GET_INVE_IM_CASUSE_ACT(string INC_ID);
        Task<GET_EMR_IC_UC_DETAILS> GET_INVE_IM_UC_LIST(string INC_ID);
        Task<GET_EMR_RC_PF_DETAILS> GET_INVE_ROOT_PF_LIST(string INC_ID);
        Task<GET_EMR_RC_SF_DETAILS> GET_INVE_ROOT_SF_LIST(string INC_ID);
        Task<GET_VIEW_INVE_IM_METHOD> GET_INVE_IM_METHOD(string INC_ID);
        Task<GET_VIEW_INVE_IM_ENVIRONMENT> GET_INVE_IM_ENVI(string INC_ID);
        Task<GET_VIEW_INVE_IM_MATERIAL> GET_INVE_IM_MATERIAL(string INC_ID);
        Task<GET_EMR_NATURE_INJURY_DETAILS> GET_INVE_NATUREOFINJURY_LIST(string INC_ID);
        Task<GET_EMR_MECH_INJURY_DETAILS> GET_INVE_MECHANISMOFINJURY_LIST(string INC_ID);
        Task<GET_EMR_AGENCY_INJURY_DETAILS> GET_INVE_SOURCEOFINJURY_LIST(string INC_ID);
        Task<GET_EMR_BODY_LOC_DETAILS> GET_INVE_BODYLOCATION_LIST(string INC_ID);
        Task<GET_EMR_INCDT_COST_ANALYSIS> GET_COST_ANALYSIS(string INC_ID);
        Task<ACTION_TAKEN_IMMEDIATELY> GET_VIEW_ACTION_TAKEN(string INC_ID);
        Task<INCIDENT_ROOT_CAUSE> GET_VIEW_INCIDENT_ROOT_CAUSE(string INC_ID);
        Task<CORRECTIVE_ACTION> GET_VIEW_CORRECTIVE_ACTION(string INC_ID);
        Task<INJURED_PERSONAL_DETAILS> VIEW_INJURED_PERSON_DETAILS(string INC_ID);
        Task<MEDICAL_REPORT> GET_MEDICAL_REPORT(string INC_ID);
        Task<GET_EMR_SEQUENCE_EVENT> GET_VIEW_INVE_SEQUENCE_EVENT_LIST(string INC_ID);
        Task<GET_EMR_INTERVIEW_DETAILS> GET_VIEW_INVE_INTERVIEW_DETAILS(string INC_ID);
        Task<GET_EMR_DOCUMENT_DETAILS> GET_VIEW_INVE_DOCUMENT_DETAILS(string INC_ID);
        Task<GET_EMR_NEW_SITE_INSPECTION> GET_VIEW_INVE_NEW_SITE_INSPECTION(string INC_ID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    #region [ImmediateCause_UnsafeAct]
    public class GET_EMR_IC_ACT_DETAILS
    {
        public string? CAUSE_ID { get; set; }
        public string? CAUSENAME { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? CAUSE_NAME_AR { get; set; }

    }
    public class ADD_EMRICAct_MASTER
    {
        public string? CAUSE_ID { get; set; }
        public string? CAUSENAME { get; set; }
        public string? CAUSE_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? STATUS_CODE { get; set; }
        public string? UNIQUE_ID { get; set; }


    }

    #endregion

    #region [ImmediateCause_UnsafeConditions]

    public class GET_EMR_IC_UC_DETAILS
    {
        public string? IM_UNSAFE_ID { get; set; }
        public string? IM_UNSAFENAME { get; set; }
        public string? IM_UNSAFE_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
        public string? UNIQUE_ID { get; set; }


    }

    public class ADD_EMR_IC_UC_MASTER
    {
        public string? IM_UNSAFE_ID { get; set; }
        public string? IM_UNSAFENAME { get; set; }
        public string? IM_UNSAFE_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? STATUS_CODE { get; set; }
        public string UNIQUE_ID { get; set; }


    }

    #endregion

    #region [Root Causes (Personal factor)]

    public class GET_EMR_RC_PF_DETAILS
    {
        public string? ROOT_CAUSE_ID { get; set; }
        public string? ROOT_CAUSE_NAME { get; set; }
        public string? ROOT_CAUSE_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
        public string? UNIQUE_ID { get; set; }


    }

    public class ADD_EMR_RC_PF_MASTER
    {
        public string? ROOT_CAUSE_ID { get; set; }
        public string? ROOT_CAUSE_NAME { get; set; }
        public string? ROOT_CAUSE_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? STATUS_CODE { get; set; }
        public string? UNIQUE_ID { get; set; }


    }

    #endregion

    #region [Root Causes (System factor)]

    public class GET_EMR_RC_SF_DETAILS
    {
        public string? RC_SF_ID { get; set; }
        public string? RC_SF_NAME { get; set; }
        public string? RC_SF_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
        public string? UNIQUE_ID { get; set; }

    }

    public class ADD_EMR_RC_SF_MASTER
    {
        public string? RC_SF_ID { get; set; }
        public string? RC_SF_NAME { get; set; }
        public string? RC_SF_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? STATUS_CODE { get; set; }
        public string UNIQUE_ID { get; set; }


    }

    #endregion

    #region [Root Cause (Method)]
    public class GET_EMR_RC_METHOD
    {
        public string? RC_METHOD_ID { get; set; }
        public string? RC_METHOD_NAME { get; set; }
        public string? RC_METHOD_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
        public string? UNIQUE_ID { get; set; }
    }

    public class ADD_EMR_RC_METHOD_MASTER
    {
        public string? RC_METHOD_ID { get; set; }
        public string? RC_METHOD_NAME { get; set; }
        public string? RC_METHOD_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? STATUS_CODE { get; set; }
        public string UNIQUE_ID { get; set; }
    }
    #endregion

    #region [Root Cause(Environment)]
    public class GET_EMR_RC_ENVIRONMENT : M_COMMON_FIELDS
    {
        public string? RC_ENVIRONMENT_ID { get; set; }
        public string? RC_ENVIRONMENT_NAME { get; set; }
        public string? RC_ENVIRONMENT_NAME_AR { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
    }
    public class ADD_EMR_RC_ENVIRONMENT_MASTER : M_COMMON_FIELDS
    {
        public string? RC_ENVIRONMENT_ID { get; set; }
        public string? RC_ENVIRONMENT_NAME { get; set; }
        public string? RC_ENVIRONMENT_NAME_AR { get; set; }
    }
    #endregion

    #region [Root Cause(Material)]
    public class GET_EMR_RC_MATERIAL : M_COMMON_FIELDS
    {
        public string? RC_MATERIAL_ID { get; set; }
        public string? RC_MATERIAL_NAME { get; set; }
        public string? RC_MATERIAL_NAME_AR { get; set; }

        public string? STATUS { get; set; }
        public string? INVE_OTHER_NAME { get; set; }

    }
    public class ADD_EMR_RC_MATERIAL_MASTER : M_COMMON_FIELDS
    {
        public string? RC_MATERIAL_ID { get; set; }
        public string? RC_MATERIAL_NAME { get; set; }
        public string? RC_MATERIAL_NAME_AR { get; set; }

        public string? STATUS { get; set; }

    }
    #endregion

    #region [Nature of Injury / Illness]
    public class GET_EMR_NATURE_INJURY_DETAILS : M_COMMON_FIELDS
    {
        public string? NATURE_INJURY_ID { get; set; }
        public string? NATURE_INJURY_NAME { get; set; }
        public string? NATURE_INJURY_NAME_AR { get; set; }

        public string? STATUS { get; set; }
        public string? INVE_OTHER_NAME { get; set; }


    }
    public class ADD_EMR_NATURE_INJURY_MASTER : M_COMMON_FIELDS
    {
        public string? NATURE_INJURY_ID { get; set; }
        public string? NATURE_INJURY_NAME { get; set; }
        public string? NATURE_INJURY_NAME_AR { get; set; }

        public string? STATUS { get; set; }
    }
    #endregion

    #region [Mechanism of Injury / Illness]
    public class GET_EMR_MECH_INJURY_DETAILS : M_COMMON_FIELDS
    {
        public string? MECH_INJURY_ID { get; set; }
        public string? MECH_INJURY_NAME { get; set; }
        public string? MECH_INJURY_NAME_AR { get; set; }

        public string? STATUS { get; set; }
        public string? INVE_OTHER_NAME { get; set; }


    }
    public class ADD_EMR_MECH_INJURY_MASTER : M_COMMON_FIELDS
    {
        public string? MECH_INJURY_ID { get; set; }
        public string? MECH_INJURY_NAME { get; set; }
        public string? MECH_INJURY_NAME_AR { get; set; }

        public string? STATUS { get; set; }
    }
    #endregion

    #region [Agency / Source of Injury / Illness]
    public class GET_EMR_AGENCY_INJURY_DETAILS : M_COMMON_FIELDS
    {
        public string? AGENCY_INJURY_ID { get; set; }
        public string? AGENCY_INJURY_NAME { get; set; }
        public string? AGENCY_INJURY_NAME_AR { get; set; }

        public string? STATUS { get; set; }
        public string? INVE_OTHER_NAME { get; set; }

    }
    public class ADD_EMR_AGENCY_INJURY_MASTER : M_COMMON_FIELDS
    {
        public string? AGENCY_INJURY_ID { get; set; }
        public string? AGENCY_INJURY_NAME { get; set; }
        public string? AGENCY_INJURY_NAME_AR { get; set; }

        public string? STATUS { get; set; }

    }
    #endregion

   // #region[Incident Cause Analysis]
   //public class GET_EMR_INCDT_CA_DETAILS : M_COMMON_FIELDS
   // {
   //     public string? INCDT_CAS_ID { get; set; }
   //     public string? INCDT_CAS_NAME { get; set; }
   //     public string? INCDT_CAS_NAME_AR { get; set; }

   //     public string? STATUS { get; set; }



   // }
   // public class ADD_EMR_INCDT_CA_MASTER : M_COMMON_FIELDS
   // {
   //     public string? INCDT_CAS_ID { get; set; }
   //     public string? INCDT_CAS_NAME { get; set; }
   //     public string? INCDT_CAS_NAME_AR { get; set; }

   //     public string? STATUS { get; set; }


   // }
   // #endregion

   // #region[Incident Category]
   // public class IncidentCategoryModel : M_COMMON_FIELDS
   // {
   //     public long? INCCATID { get; set; }
   //     public string? INCCATNAME { get; set; }
   //     public string? INCCATNAMEAR { get; set; }
   //     public bool? STATUS { get; set; }
   //     public string? MESSAGE { get; set; }

   // }

   // public class GET_INCIDENT_CATEGORY_DETAILS : M_COMMON_FIELDS
   // {
   //     public string? INC_ID { get; set; }
   //     public long? INCCATID { get; set; }
   //     public string? INCCATNAME { get; set; }
   //     public string? INCCATNAMEAR { get; set; }

   // }
   // #endregion

    //#region [Drill Type]
    //public class GET_DRILL_TYPE : M_COMMON_FIELDS
    //{
    //    public string? DRILL_TYPE_ID { get; set; }
    //    public string? DRILL_TYPE_NAME { get; set; }
    //    public string? DRILL_TYPE_NAME_AR { get; set; }
    //    public string? STATUS { get; set; }
    //}
    //public class ADD_DRILL_TYPE : M_COMMON_FIELDS
    //{
    //    public string? DRILL_TYPE_ID { get; set; }
    //    public string? DRILL_TYPE_NAME { get; set; }
    //    public string? DRILL_TYPE_NAME_AR { get; set; }
    //    public string? STATUS { get; set; }
    //}
    //#endregion

    //#region [Drill Management Checklist]
    //public class GET_DRILL_CHECKLIST : M_COMMON_FIELDS
    //{
    //    public string? DRILL_CHECKLIST_ID { get; set; }
    //    public string? DRILL_TYPE_ID { get; set; }

    //    public string? STATUS { get; set; }
    //    public string? LANG_ID { get; set; }
    //    public List<ADD_DRILL_SUB_CHECKLIST> ADD_DRILL_SUB_CHECKLIST_LIST { get; set; }
    //}
    //public class ADD_DRILL_SUB_CHECKLIST : M_COMMON_FIELDS
    //{
    //    public string? DRILL_SUBCHECKLIST_ID { get; set; }
    //    public string? DRILL_TYPE_ID { get; set; }
    //    public string? DRILL_CHECKLIST_ID { get; set; }
    //    public string? DRILL_CHECKLIST_NAME { get; set; }
    //    public string? DRILL_CHECKLIST_NAME_AR { get; set; }

    //}
    //public class ADD_DRILL_CHECKLIST : M_COMMON_FIELDS
    //{
    //    public string? DRILL_CHECKLIST_ID { get; set; }
    //    public string? DRILL_TYPE_ID { get; set; }
    //    public string? DRILL_CHECKLIST_NAME { get; set; }
    //    public string? DRILL_CHECKLIST_NAME_AR { get; set; }
    //}
    //#endregion

    #region [DISASTER_TYPE]
    public class GET_EMR_DISASTER_TYPE
    {
        public string? DISASTER_ID { get; set; }
        public string? DISASTER_NAME { get; set; }
        public string? DISASTER_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? UNIQUE_ID { get; set; }
    }

    public class ADD_EMR_DISASTER_TYPE
    {
        public string? DISASTER_ID { get; set; }
        public string? DISASTER_NAME { get; set; }
        public string? DISASTER_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? STATUS_CODE { get; set; }
        public string? UNIQUE_ID { get; set; }
    }
    #endregion

    #region[EMERGENCY_TEAM_ACTIVATE]
    public class GET_EMERGENCY_TYPE_MASTER_SELECT
    {
        public string? EMP_ACTIVE_ID { get; set; }
        public string? EMR_TEAM_TYPE { get; set; }
        public string? LEAD_MANAGER { get; set; }
        public string? LOCATION { get; set; }
        public string? BUILDING { get; set; }
        public string? SECTOR { get; set; }
        public string? DEPARTMENT { get; set; }
        public string? SECTIONLAB { get; set; }
        public string? LOCATION_NAME { get; set; }
        public string? BUILDING_NAME { get; set; }
        public string? SECTOR_NAME { get; set; }
        public string? DEPARTMENT_NAME { get; set; }
        public string? SECTION_LAB_NAME { get; set; }
        public string? CREATED_BY_NAME { get; set; }
        public string? EMERG_TYPE_NAME { get; set; }
        public string? SCHEDULE { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? ActiveDeactive { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? ACCEPT_REJECT_STATUS { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? EMERG_TYPE_NAME_AR { get; set; }

        public string? FLOOR { get; set; }

    }
    public class ADD_EMERGENCY_TYPE_MASTER_SELECT
    {
        public string? EMP_ACTIVE_ID { get; set; }
        public string? EMR_TEAM_TYPE { get; set; }
        public string? LEAD_MANAGER { get; set; }
        public string? LOCATION { get; set; }
        public string? BUILDING { get; set; }
        public string? SECTOR { get; set; }
        public string? DEPARTMENT { get; set; }
        public string? SECTIONLAB { get; set; }
        public string? SCHEDULE { get; set; }
        public string? STATUS { get; set; }
        public string? FLOOR { get; set; }

    }
    public class ADD_EMERGENCY_TYPE_CORRECTIVE_ACTION
    {
        public string? EMR_CORRECTIVE_ID { get; set; }
        public string? EMP_ACTIVE_ID { get; set; }
        public string? REMARKS { get; set; }
        public string? DESCRIPTION { get; set; }
        public string? IMAGE_PATH { get; set; }
        public string? IMAGE_NAME { get; set; }
        public string? IMAGE_SIZE { get; set; }
        public string? STATUS { get; set; }
        public string? EMP_ID { get; set; }
        public string? REVIEW_DATE { get; set; }

    }
    public class Get_EMERGENCY_TYPE_CORRECTIVE_ACTION
    {
        public string? EMR_CORRECTIVE_ID { get; set; }
        public string? EMP_ACTIVE_ID { get; set; }
        public string? REMARKS { get; set; }
        public string? DESCRIPTION { get; set; }
        public string? IMAGE_PATH { get; set; }
        public string? IMAGE_NAME { get; set; }
        public string? IMAGE_SIZE { get; set; }
        public string? STATUS { get; set; }
        public string? EMP_ID { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? REVIEW_DATE { get; set; }
    }
    #endregion
    #region [Added aditional]
    public class UPLOAD_DOCUMENT
    {
        public long? EMR_DOC_ID { get; set; }
        //public string EMP_ACTIVE_ID { get; set; }
        public string? EMP_EMERG_TYPE_ID { get; set; }
        public string? EMR_FILE_NAME { get; set; }
        public string? EMR_FILE_PATH { get; set; }
        public string? EMR_FILE_SIZE { get; set; }
        public string? EMR_FILE_TYPE { get; set; }
        public string? EMR_FILE_STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
    }
    public class GET_EMERGENCY_TYPE_TEAM
    {
        public string? EMERG_TYPE_MAS_ID { get; set; }
        //public string EMP_ACTIVE_ID { get; set; }
        public string? EMP_EMERG_TYPE_ID { get; set; }
        public string? EMR_DOC_ID { get; set; }
        public string? EMERG_TYPE_MAS { get; set; }
        public string? EMERG_TYPE_MAS_AR { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? BOTH { get; set; }
        public List<GET_EMPLOYEE_EMERG_TYPE_TEAM>? _EMPLOYEE_EMERG_TYPE_TEAM_LIST { get; set; }
        public List<UPLOAD_DOCUMENT>? UPLOAD_DOCUMENT { get; set; }

    }

    public class GET_EMPLOYEE_EMERG_TYPE_TEAM
    {
        public string? EMP_EMERG_TYPE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? EMERG_TYPE_MAS_ID { get; set; }
        public string? EMP_STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? IS_ACTIVE { get; set; }
        public string? EMERG_TYPE_MAS { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_UNIQUEID { get; set; }
        public string? DESI_NAME_EN { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? DESI_NAME_ARB { get; set; }
        public string? LOC_NAME { get; set; }
        public string? BUIL_NAME { get; set; }
        public string? LEVEL { get; set; }
        public string? EMP_BOTH_NAME { get; set; }
        public string? DESI_BOTH_NAME { get; set; }
        public string? LOC_BOTH_NAME { get; set; }
        public string? BUIL_BOTH_NAME { get; set; }
        public string? LOC_NAME_AR { get; set; }
        public string? BUIL_NAME_AR { get; set; }
    }

    //public class GET_EMPLOYEE_DETAILS
    //{
    //    public string? EMPLOYEE_ID { get; set; }
    //    public string? EMPLOYEE_NAME { get; set; }
    //    public string? DESIGNATION { get; set; }
    //    public string? STATUS { get; set; }
    //    public string? CREATED_DATE { get; set; }
    //    public string? UNIQUE_ID { get; set; }
    //    public string? EMP_NAME_AR { get; set; }
    //}
    #endregion
}
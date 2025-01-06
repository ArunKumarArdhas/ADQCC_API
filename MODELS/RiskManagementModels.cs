using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class RiskManagementModels
    {
    }


    #region [Hazard Master]
    public class GET_RM_HAZARD_MASTER : COMMEN
    {
        public string HAZARD_MAS_ID { get; set; }
        public string HAZ_RISK_CAT_MAS_ID { get; set; }
        public string HAZARD_MAS_NAME { get; set; }
        public string HAZARD_MAS_NAME_AR { get; set; }
        public string RISK_CAT_MAS_NAME { get; set; }
        public string RISK_CAT_MAS_NAME_AR { get; set; }
        public string STATUS { get; set; }

    }

    public class ADD_RM_HAZARD_MASTER : COMMEN
    {
        public string? HAZARD_MAS_ID { get; set; }
        public string? HAZ_RISK_CAT_MAS_ID { get; set; }
        public string? HAZARD_MAS_NAME { get; set; }
        public string? HAZARD_MAS_NAME_AR { get; set; }
        public string? STATUS { get; set; }
    }
    #endregion

    #region[RISKS_OTHER_RISKS]
    public class GET_RM_RISKS_OTHER_RISKS : COMMEN
    {
        public string RISKS_OTHER_RISKS_ID { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }
        public string RISKS_HAZARD_MAS_ID { get; set; }
        public string RISKS_OTHER_RISKS_NAME { get; set; }
        public string RISKS_OTHER_RISKS_NAME_AR { get; set; }
        public string RISK_CAT_MAS_NAME { get; set; }
        public string HAZARD_MAS_NAME { get; set; }
        public string RISK_CAT_MAS_NAME_AR { get; set; }
        public string HAZARD_MAS_NAME_AR { get; set; }
        public string STATUS { get; set; }

    }
    public class ADD_RM_RISKS_OTHER_RISKS : COMMEN
    {
        public string RISKS_OTHER_RISKS_ID { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }
        public string RISKS_HAZARD_MAS_ID { get; set; }
        public string RISKS_OTHER_RISKS_NAME { get; set; }
        public string RISKS_OTHER_RISKS_NAME_AR { get; set; }
        public string STATUS { get; set; }

    }
    #endregion

    #region [Risk Category Master]
    public class GET_RM_RISK_CAT_MASTER
    {
        public string RISK_CAT_MAS_ID { get; set; }
        public string RISK_CAT_MAS_NAME { get; set; }
        public string RISK_CAT_MAS_NAME_AR { get; set; }
        public string CREATED_DATE { get; set; }
        public string STATUS { get; set; }
    }

    public class ADD_RM_RISK_CAT_MASTER
    {
        public string RISK_CAT_MAS_ID { get; set; }
        public string RISK_CAT_MAS_NAME { get; set; }
        public string RISK_CAT_MAS_NAME_AR { get; set; }
        public string CREATED_DATE { get; set; }
        public string STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public string STATUS_CODE { get; set; }


    }

    #endregion

    #region[PERSONS_GROUPS]
    public class GET_RM_PERSONS_GROUPS
    {
        public string PERSON_GROUP_ID { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }
        public string PG_HAZARD_MAS_ID { get; set; }
        public string PERSON_GROUP_NAME { get; set; }
        public string PERSON_GROUP_NAME_AR { get; set; }
        public string RISK_CAT_MAS_NAME { get; set; }
        public string HAZARD_MAS_NAME { get; set; }
        public string STATUS { get; set; }
    }
    public class ADD_RM_PERSONS_GROUPS
    {
        public string PERSON_GROUP_ID { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }
        public string PG_HAZARD_MAS_ID { get; set; }
        public string PERSON_GROUP_NAME { get; set; }
        public string PERSON_GROUP_NAME_AR { get; set; }
        public string STATUS { get; set; }
    }
    #endregion


    #region [Details of any Existing Controls]
    public class GET_RM_DETAILS_EXIST_CONT : COMMEN
    {
        public string DETAILS_EXIST_CONT_ID { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }
        public string DEC_HAZARD_MAS_ID { get; set; }
        public string DETAILS_EXIST_CONT_NAME { get; set; }
        public string DETAILS_EXIST_CONT_NAME_AR { get; set; }
        public string RISK_CAT_MAS_NAME { get; set; }
        public string HAZARD_MAS_NAME { get; set; }
        public string STATUS { get; set; }
    }

    public class ADD_RM_DETAILS_EXIST_CONT : COMMEN
    {
        public string DETAILS_EXIST_CONT_ID { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }
        public string DEC_HAZARD_MAS_ID { get; set; }
        public string DETAILS_EXIST_CONT_NAME { get; set; }
        public string DETAILS_EXIST_CONT_NAME_AR { get; set; }
        public string STATUS { get; set; }

    }

    #endregion

    #region [Additional Control Measures]
    public class GET_RM_ADD_CONT_MEAS : COMMEN
    {
        public string ADD_CONT_MEAS_ID { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }
        public string ACM_HAZARD_MAS_ID { get; set; }
        public string ADD_CONT_MEAS_NAME { get; set; }
        public string ADD_CONT_MEAS_NAME_AR { get; set; }
        public string RISK_CAT_MAS_NAME { get; set; }
        public string HAZARD_MAS_NAME { get; set; }
        public string STATUS { get; set; }
    }

    public class ADD_RM_ADD_CONT_MEAS : COMMEN
    {
        public string ADD_CONT_MEAS_ID { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }
        public string ACM_HAZARD_MAS_ID { get; set; }
        public string ADD_CONT_MEAS_NAME { get; set; }
        public string ADD_CONT_MEAS_NAME_AR { get; set; }
        public string STATUS { get; set; }
    }

    #endregion

    #region [Opportunities and other opportunities]
    public class GET_RM_OPPORTUNITIES
    {
        public string OPPORTUNITIES_ID { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }
        public string OPTY_HAZARD_MAS_ID { get; set; }
        public string OPPORTUNITIES_NAME { get; set; }
        public string OPPORTUNITIES_NAME_AR { get; set; }
        public string RISK_CAT_MAS_NAME { get; set; }
        public string HAZARD_MAS_NAME { get; set; }
        public string STATUS { get; set; }
    }

    public class ADD_RM_OPPORTUNITIES
    {
        public string OPPORTUNITIES_ID { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }
        public string OPTY_HAZARD_MAS_ID { get; set; }
        public string OPPORTUNITIES_NAME { get; set; }
        public string OPPORTUNITIES_NAME_AR { get; set; }
        public string STATUS { get; set; }

    }

    #endregion

    #region [Critical Hazard Master]
    public class GET_RM_CRIT_HAZARD_MASTER
    {
        public string CRIT_HAZARD_MAS_ID { get; set; }
        public string CRIT_HAZARD_MAS_NAME { get; set; }
        public string CRIT_HAZARD_MAS_NAME_AR { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }

        public string STATUS { get; set; }
    }

    public class ADD_RM_CRIT_HAZARD_MASTER
    {
        public string CRIT_HAZARD_MAS_ID { get; set; }
        public string CRIT_HAZARD_MAS_NAME { get; set; }
        public string CRIT_HAZARD_MAS_NAME_AR { get; set; }
        public string RISK_CAT_MAS_ID { get; set; }
        public string STATUS { get; set; }
    }

    #endregion


   

    #region [Risk Cover]
    public class GET_RISK_COVER_BCM
    {
        public string? RM_COVER_ID { get; set; }
        public string? RM_CATEGORY_ID { get; set; }
        public string? RM_CATEGORY_NAME { get; set; }
        public string? RM_CATEGORY_NAME_AR { get; set; }
        public string? RM_COVER_NAME { get; set; }
        public string? RM_COVER_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? UNIQUE_ID { get; set; }
    }

    public class ADD_RISK_COVER_BCM
    {
        public string? RM_COVER_ID { get; set; }
        public string? RM_CATEGORY_ID { get; set; }
        public string? RM_COVER_NAME { get; set; }
        public string? RM_COVER_NAME_AR { get; set; }
        public string? STATUS { get; set; }
        public string? LANG_ID { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? STATUS_CODE { get; set; }
    }
    #endregion

    #region [RISK_PROCESS_ACTIVITY_BCM]
    public class GET_RISK_PROCESS_ACTIVITY_BCM
    {
        public string? RM_PROCESS_ACT_ID { get; set; }
        public string? RM_PROCESS_ACT_NAME { get; set; }
        public string? RM_PROCESS_ACT_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? UNIQUE_ID { get; set; }
    }

    public class ADD_RISK_PROCESS_ACTIVITY_BCM
    {
        public string? RM_PROCESS_ACT_ID { get; set; }
        public string? RM_PROCESS_ACT_NAME { get; set; }
        public string? RM_PROCESS_ACT_NAME_AR { get; set; }
        public string? STATUS { get; set; }
        public string? LANG_ID { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? STATUS_CODE { get; set; }
    }
    #endregion

    #region [EXISTING_CONTROL]
    public class GET_EXISTING_CONTROL_MASTER
    {
        public string? RM_EXIST_CON_ID { get; set; }
        public string? RM_EXIST_CON_NAME { get; set; }
        public string? RM_EXIST_CON_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? UNIQUE_ID { get; set; }
    }

    public class ADD_EXISTING_CONTROL_MASTER
    {
        public string? RM_EXIST_CON_ID { get; set; }
        public string? RM_EXIST_CON_NAME { get; set; }
        public string? RM_EXIST_CON_NAME_AR { get; set; }
        public string? STATUS { get; set; }
        public string? LANG_ID { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? STATUS_CODE { get; set; }
    }
    #endregion

    #region [BCM TREATMENT]
    public class GET_TREATMENT_MASTER
    {
        public string? RM_TREATMENT_ID { get; set; }
        public string? RM_TREATMENT_NAME { get; set; }
        public string? RM_TREATMENT_NAME_AR { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? STATUS { get; set; }
        public string? UNIQUE_ID { get; set; }
    }

    public class ADD_TREATMENT_MASTER
    {
        public string? RM_TREATMENT_ID { get; set; }
        public string? RM_TREATMENT_NAME { get; set; }
        public string? RM_TREATMENT_NAME_AR { get; set; }
        public string? STATUS { get; set; }
        public string? LANG_ID { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? STATUS_CODE { get; set; }
    }
    #endregion

  

    #region [Non Critical Hazard Master]
    public class GET_RM_NON_CRIT_HAZ_MASTER : COMMEN
    {
        public string NON_CRIT_HAZ_MAS_ID { get; set; }
        public string NON_CRIT_HAZ_MAS_NAME { get; set; }
        public string NON_CRIT_HAZ_MAS_NAME_AR { get; set; }

        public string STATUS { get; set; }

    }

    public class ADD_RM_NON_CRIT_HAZ_MASTER : COMMEN
    {
        public string NON_CRIT_HAZ_MAS_ID { get; set; }
        public string NON_CRIT_HAZ_MAS_NAME { get; set; }
        public string NON_CRIT_HAZ_MAS_NAME_AR { get; set; }

        public string STATUS { get; set; }

    }

    #endregion

    #region [Non-Routine and Emergencies]
    public class GET_RM_NON_ROUT_EMERG_MASTER : COMMEN
    {
        public string NON_ROUT_EMERG_ID { get; set; }
        public string NON_ROUT_EMERG_NAME { get; set; }
        public string NON_ROUT_EMERG_NAME_AR { get; set; }

        public string STATUS { get; set; }

    }

    public class ADD_RM_NON_ROUT_EMERG_MASTER : COMMEN
    {
        public string NON_ROUT_EMERG_ID { get; set; }
        public string NON_ROUT_EMERG_NAME { get; set; }
        public string NON_ROUT_EMERG_NAME_AR { get; set; }

        public string STATUS { get; set; }

    }

    #endregion


    #region [Existing control measures for identified hazard]
    public class GET_RM_EXISTING_CMIH_MASTER : COMMEN
    {
        public string EXISTING_CMIH_MAS_ID { get; set; }
        public string EXISTING_CMIH_MAS_NAME { get; set; }
        public string EXISTING_CMIH_MAS_NAME_AR { get; set; }

        public string STATUS { get; set; }
    }

    public class ADD_RM_EXISTING_CMIH_MASTER : COMMEN
    {
        public string EXISTING_CMIH_MAS_ID { get; set; }
        public string EXISTING_CMIH_MAS_NAME { get; set; }
        public string EXISTING_CMIH_MAS_NAME_AR { get; set; }
        public string STATUS { get; set; }

    }

    #endregion


    #region [RISK_CATEGORY_BCM]

    public class GET_RISK_CATEGORY_BCM : COMMEN
    {
        public string RM_CATEGORY_ID { get; set; }
        public string RM_CATEGORY_NAME { get; set; }
        public string RM_CATEGORY_NAME_AR { get; set; }

        public string STATUS { get; set; }

    }

    public class ADD_RISK_CATEGORY_BCM : COMMEN
    {
        public string RM_CATEGORY_ID { get; set; }
        public string RM_CATEGORY_NAME { get; set; }
        public string RM_CATEGORY_NAME_AR { get; set; }
        public string STATUS { get; set; }
        public string LANG_ID { get; set; }

    }
    #endregion


}

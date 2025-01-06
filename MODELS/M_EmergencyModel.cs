using MODELS;

namespace ADQCC_New.Models.Emergency
{
   

    #region [ImmediateCause_UnsafeAct]
    public class M_EmergencyModel : M_COMMON_FIELDS
    {
        public string? CAUSE_ID { get; set; }
        public string? CAUSENAME { get; set; }
        public string? CAUSE_NAME_AR { get; set; }
       
    }

    #endregion

    #region [ImmediateCause_UnsafeConditions]

    public class UNSAFECONDITION_MASTER : M_COMMON_FIELDS
    {
        public string? IM_UNSAFE_ID { get; set; }
        public string? IM_UNSAFENAME { get; set; }
        public string? IM_UNSAFE_NAME_AR { get; set; }
        
    }

    #endregion

    #region [Root Causes (Personal factor)]

    public class ROOT_CAUSE_PERSONAL_MASTER : M_COMMON_FIELDS
    {
        public string? ROOT_CAUSE_ID { get; set; }
        public string? ROOT_CAUSE_NAME { get; set; }
        public string? ROOT_CAUSE_NAME_AR { get; set; }
       
    }
    #endregion

    #region [Root Causes (System factor)]

    public class ROOT_CAUSE_SYSTEM_MASTER : M_COMMON_FIELDS
    {
        public string? RC_SF_ID { get; set; }
        public string? RC_SF_NAME { get; set; }
        public string? RC_SF_NAME_AR { get; set; }
       
    }
    #endregion

    #region [Root Cause (Method)]
    public class ROOT_CAUSE_METHOD_MASTER : M_COMMON_FIELDS
    {
        public string? RC_METHOD_ID { get; set; }
        public string? RC_METHOD_NAME { get; set; }
        public string? RC_METHOD_NAME_AR { get; set; }
    }
    #endregion

    #region [Root Cause(Environment)]
    public class ROOT_CAUSE_ENVIRONMENT_MASTER : M_COMMON_FIELDS
    {
        public string? RC_ENVIRONMENT_ID { get; set; }
        public string? RC_ENVIRONMENT_NAME { get; set; }
        public string? RC_ENVIRONMENT_NAME_AR { get; set; }
       
    }
    #endregion

    #region [Root Cause(Material)]
    public class ROOT_CAUSE_MATERIAL_MASTER : M_COMMON_FIELDS
    {
        public string? RC_MATERIAL_ID { get; set; }
        public string? RC_MATERIAL_NAME { get; set; }
        public string? RC_MATERIAL_NAME_AR { get; set; }
       
    }
    #endregion

    #region [Nature of Injury / Illness]
    public class NATURE_INJURY_DETAILS : M_COMMON_FIELDS
    {
        public string? NATURE_INJURY_ID { get; set; }
        public string? NATURE_INJURY_NAME { get; set; }
        public string? NATURE_INJURY_NAME_AR { get; set; }
    }
    #endregion

    #region [Mechanism of Injury / Illness]
    public class MECH_INJURY_DETAILS : M_COMMON_FIELDS
    {
        public string? MECH_INJURY_ID { get; set; }
        public string? MECH_INJURY_NAME { get; set; }
        public string? MECH_INJURY_NAME_AR { get; set; }
    }
    #endregion

    #region [Agency / Source of Injury / Illness]
    public class AGENCY_INJURY_DETAILS : M_COMMON_FIELDS
    {
        public string? AGENCY_INJURY_ID { get; set; }
        public string? AGENCY_INJURY_NAME { get; set; }
        public string? AGENCY_INJURY_NAME_AR { get; set; }
      
    }
    #endregion

    #region[Incident Cause Analysis]
    public class INCIDENT_DETAILS : M_COMMON_FIELDS
    {
        public string? INCDT_CAS_ID { get; set; }
        public string? INCDT_CAS_NAME { get; set; }
        public string? INCDT_CAS_NAME_AR { get; set; }
    }
    #endregion

    #region[Incident Category]
    public class INCIDENT_CATEGORY_DETAILS : M_COMMON_FIELDS
    {
        public string? INC_CAT_ID { get; set; }
        public string? INC_CAT_NAME { get; set; }
        public string? INC_CAT_NAME_AR { get; set; }
        public string? INC_CAT_STATUS { get; set; }

    }
    #endregion

    #region [DISASTER_TYPE]
    public class DISASTER_TYPE_MASTER : M_COMMON_FIELDS
    {
        public string? DISASTER_ID { get; set; }
        public string? DISASTER_NAME { get; set; }
        public string? DISASTER_NAME_AR { get; set; }
       
    }
    #endregion
}

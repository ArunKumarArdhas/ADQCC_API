using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    //public class RETURN_MESSAGE
    //{
    //    public string? STATUS_CODE { get; set; }
    //    public string? STATUS { get; set; }
    //    public string? MESSAGE { get; set; }
    //    public string? UNIQUE_ID { get; set; } 
    //    public string? Return_Status { get; set; } 
    //    public string? RecordsTotal { get; set; } 
    //    public string? RecordsFiltered { get; set; } 
    //}
    #region[NATIONALITY_MASTER]
    public class NATIONALITY_MASTER : M_COMMON_FIELDS
    {
        public string? NATIONALITY_ID { get; set; }
        public string? NATIONALITY_NAME { get; set; }
    }
    #endregion
    #region[LOCATION_MASTER]
    public class GET_LOCATION_MASTER :COMMON
    {
        public string? LOC_ID { get; set; }
        public string? LOC_NAME { get; set; }
        public string? LOC_NAME_AR { get; set; }
    }

    public class COMMON
    {
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? STATUS_CODE { get; set; }
        public string? STATUS { get; set; }

        #endregion

        #region [BUILDING_MASTER]
        public class GET_BUILDING_MASTER: COMMON
        {
            public string? BUIL_ID { get; set; }
            public string? LOC_ID { get; set; }
            public string? LOC_NAME { get; set; }
            public string? LOC_NAME_AR { get; set; }
            public string? BUIL_NAME { get; set; }
            public string? BUIL_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
        }

        public class ADD_BUILDING_MASTER: COMMON
        {
            public string? BUIL_ID { get; set; }
            public string? LOC_ID { get; set; }
            public string? BUIL_NAME { get; set; }
            public string? BUIL_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }
        }
        #endregion

        #region[DEPARTMENT_MASTER]
        public class ADD_DEPARTMENT_MASTER
        {
            public string? DEP_ID { get; set; }
            public string? SEC_ID { get; set; }
            public string? DEP_NAME { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? DEP_NAME_AR { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }

        }
        public class GET_DEPARTMENT_MASTER
        {
            public string? DEP_ID { get; set; }
            public string? SEC_NAME_EN { get; set; }
            public string? SEC_NAME_ARB { get; set; }
            public string? DEP_NAME { get; set; }
            public string? DEP_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
        }
        #endregion

        #region[DESIGNATION]
        public class DesignationModel
        {
            public long DESI_ID { get; set; }
            public string? DESI_NAME_EN { get; set; }
            public string? DESI_NAME_ARB { get; set; }
            public DateTime CREATED_DATE { get; set; }
            public string? CREATED_BY { get; set; }
            public DateTime UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public bool STATUS { get; set; }
            public int LANG_ID { get; set; }
            public long DESI_IDENTITY { get; set; }
            public string? MESSAGE { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }
        }

        public class GET_DESIGNATION_DETAILS
        {
            public long DESI_ID { get; set; }
            public string? DESI_NAME_EN { get; set; }
            public string? DESI_NAME_ARB { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? UNIQUE_ID { get; set; }
        }
        #endregion

        #region[SECTION_LAB_MASTER]
        public class ADD_SECTION_LAB_MASTER : M_COMMON_FIELDS

        {
            public string? SEC_LAB_ID { get; set; }
            public string? SEC_LAB_TYPE { get; set; }
            public string? DEP_ID { get; set; }
            public string? SEC_LAB_NAME { get; set; }
            public string? SEC_LAB_NAME_AR { get; set; }

        }
        public class GET_SECTION_LAB_MASTER : M_COMMON_FIELDS
        {
            public string? SEC_LAB_ID { get; set; }
            public string? SEC_LAB_TYPE { get; set; }
            public string? DEP_NAME { get; set; }
            public string? DEP_NAME_AR { get; set; }
            public string? SEC_NAME_ARB { get; set; }
            public string? SEC_LAB_NAME { get; set; }
            public string? SEC_LAB_NAME_AR { get; set; }

        }
        #endregion

        #region[EMERGENCY_TYPE_MASTER]
        public class GET_EMR_TYPE_MASTER : M_COMMON_FIELDS
        {
            public string? EMERG_TYPE_MAS_ID { get; set; }
            public string? EMERG_TYPE_MAS { get; set; }
            public string? EMERG_TYPE_MAS_AR { get; set; }

        }
        public class ADD_EMR_TYPE_MASTER : M_COMMON_FIELDS
        {
            public string? EMERG_TYPE_MAS_ID { get; set; }
            public string? EMERG_TYPE_MAS { get; set; }
            public string? EMERG_TYPE_MAS_AR { get; set; }
        }
        #endregion

        #region[SECTOR]
        public class SectorModel : M_COMMON_FIELDS
        {
            public int SEC_ID { get; set; }
            public int BUIL_ID { get; set; }
            public string? SEC_TYPE { get; set; }
            public string? SEC_NAME_EN { get; set; }
            public string? SEC_NAME_ARB { get; set; }
        }
        public class GET_SECTOR_DETAILS : M_COMMON_FIELDS
        {
            public string? SEC_ID { get; set; }
            public string? BUIL_NAME_EN { get; set; }
            public string? BUIL_NAME_AR { get; set; }
            public string? SEC_NAME_EN { get; set; }
            public string? SEC_NAME_ARB { get; set; }

        }
        #endregion

        #region[SECTOR_TYPE]
        public class SectorTypeModel : M_COMMON_FIELDS
        {
            public int SEC_TYPE_ID { get; set; }
            public string? SEC_TYPE_NAME_EN { get; set; }
            public string? SEC_TYPE_NAME_ARB { get; set; }
        }
        public class GET_SECTORTYPE_DETAILS
        {
            public string? SEC_TYPE_ID { get; set; }
            public string? SEC_TYPE_NAME_EN { get; set; }
            public string? SEC_TYPE_NAME_ARB { get; set; }

        }
        #endregion

        #region[EMPLOYEE DETAILS]
        public class EmployeeDetails : M_COMMON_FIELDS
        {
            public string? EMP_ID { get; set; }
            public string? EMP_NAME { get; set; }
            public string? INSP_PLAN_ID { get; set; }
            public string? INSP_PLAN_SUB_ID { get; set; }
            public string? EMP_NAME_AR { get; set; }
            public string? SECTION_HEAD { get; set; }
            public string? LINE_MANAGER { get; set; }
        }
        public class M_Employee_Master_Filter
        {
            public string? Loc_id { set; get; }
            public string? Build_id { set; get; }
            public string? EMR_Type { set; get; }
        }
        #endregion

    }
}

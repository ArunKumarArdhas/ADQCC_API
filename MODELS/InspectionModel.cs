using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MODELS
{
    public class InspectionModel
    {

    }
    #region[INSPECTION]
    public class Get_Inspection : M_COMMON_FIELDS
    {
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_TYPE { get; set; }
        public string? CHECKLIST_TYPE_AR { get; set; }
    }
    public class Add_Inspection : M_COMMON_FIELDS
    {
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_TYPE { get; set; }
        public string? CHECKLIST_TYPE_AR { get; set; }
    }
    #endregion

    #region[Sub_Insepection]
    public class Get_Sub_Inspection : M_COMMON_FIELDS
    {
        public string? CHECKLIST_SUB_TYPE_ID { get; set; }
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_SUB_TYPE { get; set; }
        public string? CHECKLIST_SUB_TYPE_AR { get; set; }
    }

    public class Add_Sub_Inspection : M_COMMON_FIELDS
    {
        public string? CHECKLIST_SUB_TYPE_ID { get; set; }
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_SUB_TYPE { get; set; }
        public string? CHECKLIST_SUB_TYPE_AR { get; set; }
    }
    #endregion

    #region[Sub_Data_Insepection]
    public class Get_Sub_Data_Inspection : M_COMMON_FIELDS
    {
        public string? CHECKLIST_SUB_TYPE_ID { get; set; }
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_SUB_TYPE { get; set; }

    }
    public class Add_Sub_Data_Inspection : M_COMMON_FIELDS
    {
        public string? CHECKLIST_SUB_TYPE_DATA_ID { get; set; }
        public string? CHECKLIST_SUB_TYPE_ID { get; set; }
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_SUB_TYPE_DATA { get; set; }
        public string? CHECKLIST_SUB_TYPE_DATA_AR { get; set; }
        public string? LANG_ID { get; set; }

    }
    public class Get_By_ID_Sub_Data_Inspection_List
    {
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_SUB_TYPE_ID { get; set; }
        public List<Get_By_ID_Sub_Data_Inspection>? Get_By_ID_Sub_Data_Inspection { get; set; }
    }
        public class Get_By_ID_Sub_Data_Inspection
        {
            public string? CHECKLIST_SUB_TYPE_DATA_ID { get; set; }
            public string? CHECKLIST_SUB_TYPE_ID { get; set; }
            public string? CHECKLIST_TYPE_ID { get; set; }
            public string? CHECKLIST_SUB_TYPE_DATA { get; set; }
            public string? CHECKLIST_SUB_TYPE_DATA_AR { get; set; }
            public string? CREATED_BY_NAME { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? STATUS { get; set; }
            public string? CHECKLIST_TYPE { get; set; }
            public string? CREATED_BY { get; set; }
            public string? CHECKLIST_SUB_TYPE { get; set; }
        }
        #endregion

    }

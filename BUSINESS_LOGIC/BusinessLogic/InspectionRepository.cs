using Microsoft.Extensions.Configuration;
using MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IBUSINESS_LOGIC.IBusinessLogic;
using System.Reflection.Metadata;
using System.Collections;
using System.Collections.Immutable;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class InspectionRepository : IInspectionRepository
    {
        private readonly IConfiguration configuration;
        RETURN_MESSAGE message;
        public InspectionRepository(IConfiguration configuration, RETURN_MESSAGE message)
        {
            this.configuration = configuration;
            this.message = message;
        }



        #region [CheckList]
        //checklist type get
        public async Task<IReadOnlyList<Get_Inspection>> GetCheckList()
        {

            try
            {
                string procedure = "USP_INSP_INSPECTION_CHECKLIST_GET";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<Get_Inspection>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetCheckList";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        //CHECKLIST ---- ADD
        public async Task<RETURN_MESSAGE> AddCheckList(Add_Inspection objAdd)
        {
            try
            {
                var query = "USP_INSP_INSPECTION_CHECKLIST_ADD";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        CHECKLIST_TYPE_ID = objAdd.CHECKLIST_TYPE_ID,
                        CHECKLIST_TYPE = objAdd.CHECKLIST_TYPE,
                        CHECKLIST_TYPE_AR = objAdd.CHECKLIST_TYPE_AR,
                        CREATED_BY = objAdd.CREATED_BY

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Get_Inspection> GetCheckListByID(Get_Inspection model)
        {
            try
            {

                var query = "USP_INSP_INSPECTION_CHECKLIST_BY_ID";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        CHECKLIST_TYPE_ID = model.CHECKLIST_TYPE_ID

                    };
                    return (await connection.QueryAsync<Get_Inspection>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region[CheckListSub]
        //GetCheckListSub --- GET
        public async Task<IReadOnlyList<Get_Sub_Inspection>> GetCheckListSub()
        {

            try
            {
                string procedure = "USP_INSP_INSPECTION_CHECKLIST_SUB_GET";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<Get_Sub_Inspection>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetCheckListSub";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //GetCheckListSub --- ADD

        public async Task<RETURN_MESSAGE> AddCheckListSub(Add_Sub_Inspection objAdd)
        {
            try
            {
                var query = "USP_INSP_INSPECTION_CHECKLIST_SUB_ADD";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        CHECKLIST_SUB_TYPE_ID = objAdd.CHECKLIST_SUB_TYPE_ID,
                        CHECKLIST_TYPE_ID = objAdd.CHECKLIST_TYPE_ID,
                        CHECKLIST_SUB_TYPE = objAdd.CHECKLIST_SUB_TYPE,
                        CHECKLIST_SUB_TYPE_AR = objAdd.CHECKLIST_SUB_TYPE_AR,
                        CREATED_BY = objAdd.CREATED_BY

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Get_Sub_Inspection> GetCheckListSubByID(Get_Sub_Inspection model)
        {
            try
            {

                var query = "USP_INSP_INSPECTION_CHECKLIST_SUB_BY_ID";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        CHECKLIST_SUB_TYPE_ID = model.CHECKLIST_SUB_TYPE_ID

                    };
                    return (await connection.QueryAsync<Get_Sub_Inspection>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region[CheckListSubData]
        //Get -- CheckListSubData

        public async Task<IReadOnlyList<Get_Sub_Data_Inspection>> GetCheckListSubData()
        {

            try
            {
                string procedure = "USP_INSP_CHECKLIST_SUB_DATA_GET";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<Get_Sub_Data_Inspection>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetCheckListSubData";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        //CheckListSubdata --- ADD

        public async Task<RETURN_MESSAGE> AddCheckListSubData(Add_Sub_Data_Inspection objAdd)
        {
            try
            {
                var query = "USP_INSP_CHECKLIST_SUB_DATA_ADD";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        CHECKLIST_SUB_TYPE_DATA_ID = objAdd.CHECKLIST_SUB_TYPE_DATA_ID,
                        CHECKLIST_SUB_TYPE_ID = objAdd.CHECKLIST_SUB_TYPE_ID,
                        CHECKLIST_TYPE_ID = objAdd.CHECKLIST_TYPE_ID,
                        CHECKLIST_SUB_TYPE_DATA = objAdd.CHECKLIST_SUB_TYPE_DATA,
                        CHECKLIST_SUB_TYPE_DATA_AR = objAdd.CHECKLIST_SUB_TYPE_DATA_AR,
                        CREATED_BY = objAdd.CREATED_BY,
                        LANG_ID = objAdd.LANG_ID

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task< Get_By_ID_Sub_Data_Inspection_List> GetByIDCheckListSubData(Get_By_ID_Sub_Data_Inspection_List model)
        {
            try
            {
                var parameter = new 
                {
                    CHECKLIST_SUB_TYPE_ID = model.CHECKLIST_SUB_TYPE_ID

                };
                
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = "[USP_INSP_CHECKLIST_SUB_DATA_BY_ID]";
                    var objUserList = await connection.QueryAsync<Get_By_ID_Sub_Data_Inspection_List>(query, parameter, commandType: CommandType.StoredProcedure);

                    var SubQuery = "[USP_INSP_CHECKLIST_SUB_DATA_BY_SUB_ID]";
                    var SubUserList = await connection.QueryAsync<Get_By_ID_Sub_Data_Inspection>(SubQuery, parameter, commandType: CommandType.StoredProcedure);
                    var result = objUserList.FirstOrDefault();
                    if(result != null)
                    {
                        result.Get_By_ID_Sub_Data_Inspection = SubUserList.ToList();
                    }
                    
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MODELS;
using IBUSINESS_LOGIC.IBusinessLogic;
using Dapper;
using ADQCC_New.Models.Emergency;
using static Dapper.SqlMapper;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class EmergencyMasterRepository : IEmergencyMasterRepository
    {
        private readonly IConfiguration configuration;
        RETURN_MESSAGE message;

        public EmergencyMasterRepository(IConfiguration configuration, RETURN_MESSAGE message)
        {
            this.configuration = configuration;
            this.message = message;
        }

        #region [ImmediateCause_UnsafeAct]
        public async Task<RETURN_MESSAGE> AddAsync(M_EmergencyModel entity)
        {
            try
            {
                var query = "[USP_ADD_EMRICAct_Master]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CAUSE_ID = entity.CAUSE_ID,
                        CAUSENAME = entity.CAUSENAME,
                        CAUSE_NAME_AR = entity.CAUSE_NAME_AR,
                        STATUS = entity.STATUS
                        

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<M_EmergencyModel> GetByIdAsync(M_EmergencyModel CAUSE_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_IC_ACT]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CAUSE_ID = CAUSE_ID.CAUSE_ID
                    };

                    return (await connection.QueryAsync<M_EmergencyModel>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetByIdAsync";
                throw;
            }
        }

        public async Task<IReadOnlyList<M_EmergencyModel>> GetAllAsync()
        {
            try
            {
                string procedure = "[USP_GET_EMR_IC_ACT_DETAILS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_EmergencyModel>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllAsync";
                // ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

         public async Task<RETURN_MESSAGE> UpdateAsync(M_EmergencyModel entity)
         {
            throw new NotImplementedException();
        }

        public async Task<RETURN_MESSAGE> DeleteAsync(M_EmergencyModel CAUSE_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMRICAct_Master]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CAUSE_ID = CAUSE_ID.CAUSE_ID
                    };

                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteAsync";
                throw;
            }
        }
        #endregion

        #region [ImmediateCause_UnsafeConditions]

        public async Task<RETURN_MESSAGE> Add_UnSafeCond(UNSAFECONDITION_MASTER entity)
        {
            try
            {
                var query = "[USP_ADD_EMRICUC]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        IM_UNSAFE_ID = entity.IM_UNSAFE_ID,
                        IM_UNSAFENAME = entity.IM_UNSAFENAME,
                        IM_UNSAFE_NAME_AR = entity.IM_UNSAFE_NAME_AR,
                        STATUS = entity.STATUS

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UNSAFECONDITION_MASTER> GetUnSafeCondById(UNSAFECONDITION_MASTER IM_UNSAFE_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_IC_UC]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        IM_UNSAFE_ID = IM_UNSAFE_ID.IM_UNSAFE_ID
                    };

                    return (await connection.QueryAsync<UNSAFECONDITION_MASTER>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetUnSafeCondById";
                throw;
            }
        }

        public async Task<IReadOnlyList<UNSAFECONDITION_MASTER>> GetAllUnSafeCond()
        {
            try
            {
                string procedure = "[USP_GET_EMR_IC_UC_DETAILS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<UNSAFECONDITION_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllUnSafeCond";
                // ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }


        public async Task<RETURN_MESSAGE> DeleteUnSafeCond(UNSAFECONDITION_MASTER IM_UNSAFE_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMRICUC_Master]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        IM_UNSAFE_ID = IM_UNSAFE_ID.IM_UNSAFE_ID
                    };

                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteUnSafeCond";
                throw;
            }
        }
        #endregion

        #region [Root Causes (Personal factor)]

        public async Task<RETURN_MESSAGE> AddRootPersonal(ROOT_CAUSE_PERSONAL_MASTER entity)
        {
            try
            {
                var query = "[USP_ADD_EMRRCPF]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        ROOT_CAUSE_ID = entity.ROOT_CAUSE_ID,
                        ROOT_CAUSE_NAME = entity.ROOT_CAUSE_NAME,
                        ROOT_CAUSE_NAME_AR = entity.ROOT_CAUSE_NAME_AR,
                        STATUS = entity.STATUS

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ROOT_CAUSE_PERSONAL_MASTER> GetPersonalById(ROOT_CAUSE_PERSONAL_MASTER ROOT_CAUSE_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_RC_PF]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        ROOT_CAUSE_ID = ROOT_CAUSE_ID.ROOT_CAUSE_ID
                    };

                    return (await connection.QueryAsync<ROOT_CAUSE_PERSONAL_MASTER>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetPersonalById";
                throw;
            }
        }


        public async Task<IReadOnlyList<ROOT_CAUSE_PERSONAL_MASTER>> GetAllRootPersonal()
        {
            try
            {
                string procedure = "[USP_GET_EMR_RC_PF_DETAILS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<ROOT_CAUSE_PERSONAL_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllRootPersonal";
                // ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<RETURN_MESSAGE> DeletePersonal(ROOT_CAUSE_PERSONAL_MASTER ROOT_CAUSE_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMR_RC_PF]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        ROOT_CAUSE_ID = ROOT_CAUSE_ID.ROOT_CAUSE_ID

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeletePersonal";
                throw;
            }
        }
        #endregion

        #region [Root Causes (System factor)]

        public async Task<RETURN_MESSAGE> AddRootSystem(ROOT_CAUSE_SYSTEM_MASTER entity)
        {
            try
            {
                var query = "[USP_ADD_EMR_RC_SF]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RC_SF_ID = entity.RC_SF_ID,
                        RC_SF_NAME = entity.RC_SF_NAME,
                        RC_SF_NAME_AR = entity.RC_SF_NAME_AR,
                        STATUS = entity.STATUS

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ROOT_CAUSE_SYSTEM_MASTER> GetSystemById(ROOT_CAUSE_SYSTEM_MASTER RC_SF_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_RC_SF]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RC_SF_ID = RC_SF_ID.RC_SF_ID
                    };

                    return (await connection.QueryAsync<ROOT_CAUSE_SYSTEM_MASTER>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetSystemById";
                throw;
            }
        }

        public async Task<IReadOnlyList<ROOT_CAUSE_SYSTEM_MASTER>> GetAllRootSystem()
        {
            try
            {
                string procedure = "[USP_GET_EMR_RC_SF_DETAILS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<ROOT_CAUSE_SYSTEM_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllRootSystem";
                // ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<RETURN_MESSAGE> DeleteSystem(ROOT_CAUSE_SYSTEM_MASTER RC_SF_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMR_RC_SF]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RC_SF_ID = RC_SF_ID.RC_SF_ID
                    };

                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteSystem";
                throw;
            }
        }
        #endregion

        #region [Root Cause (Method)]
        public async Task<RETURN_MESSAGE> AddRootMethod(ROOT_CAUSE_METHOD_MASTER entity)
        {
            try
            {
                var query = "[USP_ADD_EMR_RC_METHOD]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RC_METHOD_ID = entity.RC_METHOD_ID,
                        RC_METHOD_NAME = entity.RC_METHOD_NAME,
                        RC_METHOD_NAME_AR = entity.RC_METHOD_NAME_AR,
                        STATUS = entity.STATUS

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ROOT_CAUSE_METHOD_MASTER> GetMethodById(ROOT_CAUSE_METHOD_MASTER RC_METHOD_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_RC_METHOD]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RC_METHOD_ID = RC_METHOD_ID.RC_METHOD_ID
                    };

                    return (await connection.QueryAsync<ROOT_CAUSE_METHOD_MASTER>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetMethodById";
                throw;
            }
        }


        public async Task<IReadOnlyList<ROOT_CAUSE_METHOD_MASTER>> GetAllRootMethod()
        {
            try
            {
                string procedure = "[USP_GET_EMR_RC_METHOD]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<ROOT_CAUSE_METHOD_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllRootMethod";
                // ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }


        public async Task<RETURN_MESSAGE> DeleteMethod(ROOT_CAUSE_METHOD_MASTER RC_METHOD_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMR_RC_METHOD]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RC_METHOD_ID = RC_METHOD_ID.RC_METHOD_ID
                    };

                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteMethod";
                throw;
            }
        }
        #endregion

        #region [Root Cause(Environment)]
        public async Task<IReadOnlyList<ROOT_CAUSE_ENVIRONMENT_MASTER>> GetEMRRCEnvironment()
        {

            try
            {
                string procedure = "USP_GET_EMR_RC_ENVIRONMENT";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<ROOT_CAUSE_ENVIRONMENT_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRRCEnvironment";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<ROOT_CAUSE_ENVIRONMENT_MASTER> GetCauseById(ROOT_CAUSE_ENVIRONMENT_MASTER RC_ENVIRONMENT_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_RC_ENVIRONMENT]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RC_ENVIRONMENT_ID = RC_ENVIRONMENT_ID.RC_ENVIRONMENT_ID
                    };

                    return (await connection.QueryAsync<ROOT_CAUSE_ENVIRONMENT_MASTER>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetCauseById";
                throw;
            }
        }
        public async Task<RETURN_MESSAGE> AddEEMRRCEnvironment(ROOT_CAUSE_ENVIRONMENT_MASTER entity)
        {
            try
            {
                var query = "USP_ADD_EMR_RC_ENVIRONMENT";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        RC_ENVIRONMENT_ID = entity.RC_ENVIRONMENT_ID,
                        RC_ENVIRONMENT_NAME = entity.RC_ENVIRONMENT_NAME,
                        RC_ENVIRONMENT_NAME_AR = entity.RC_ENVIRONMENT_NAME_AR,
                        STATUS = entity.STATUS

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<RETURN_MESSAGE> DeleteEnvironment(ROOT_CAUSE_ENVIRONMENT_MASTER RC_ENVIRONMENT_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMR_RC_ENVIRONMENT]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RC_ENVIRONMENT_ID = RC_ENVIRONMENT_ID.RC_ENVIRONMENT_ID
                    };

                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteEnvironment";
                throw;
            }
        }
        #endregion

        #region [Root Cause(Material)]
        public async Task<IReadOnlyList<ROOT_CAUSE_MATERIAL_MASTER>> GetEMRRCMaterial()
        {

            try
            {
                string procedure = "USP_GET_EMR_RC_MATERIAL";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<ROOT_CAUSE_MATERIAL_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRRCMaterial";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<ROOT_CAUSE_MATERIAL_MASTER> GetCauseMaterialById(ROOT_CAUSE_MATERIAL_MASTER RC_MATERIAL_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_RC_MATERIAL]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RC_MATERIAL_ID = RC_MATERIAL_ID.RC_MATERIAL_ID
                    };

                    return (await connection.QueryAsync<ROOT_CAUSE_MATERIAL_MASTER>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetCauseMaterialById";
                throw;
            }
        }
        public async Task<RETURN_MESSAGE> AddEEMRRCMaterial(ROOT_CAUSE_MATERIAL_MASTER entity)
        {
            try
            {
                var query = "USP_ADD_EMR_RC_MATERIAL";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        RC_MATERIAL_ID = entity.RC_MATERIAL_ID,
                        RC_MATERIAL_NAME = entity.RC_MATERIAL_NAME,
                        RC_MATERIAL_NAME_AR = entity.RC_MATERIAL_NAME_AR,
                        STATUS = entity.STATUS

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<RETURN_MESSAGE> DeleteMaterial(ROOT_CAUSE_MATERIAL_MASTER RC_MATERIAL_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMR_RC_MATERIAL]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RC_MATERIAL_ID = RC_MATERIAL_ID.RC_MATERIAL_ID
                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteUnSafeCond";
                throw;
            }
        }
        #endregion

        #region [Nature of Injury / Illness]
        public async Task<IReadOnlyList<NATURE_INJURY_DETAILS>> GetEMRNIIDetails()
        {

            try
            {
                string procedure = "USP_GET_EMR_NII_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<NATURE_INJURY_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRNIIDetails";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<NATURE_INJURY_DETAILS> GetNatureById(NATURE_INJURY_DETAILS NATURE_INJURY_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_NII]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        NATURE_INJURY_ID = NATURE_INJURY_ID.NATURE_INJURY_ID
                    };

                    return (await connection.QueryAsync<NATURE_INJURY_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetNatureById";
                throw;
            }
        }
        public async Task<RETURN_MESSAGE> AddEMRNII(NATURE_INJURY_DETAILS entity)
        {
            try
            {
                var query = "USP_ADD_EMR_NII";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        NATURE_INJURY_ID = entity.NATURE_INJURY_ID,
                        NATURE_INJURY_NAME = entity.NATURE_INJURY_NAME,
                        NATURE_INJURY_NAME_AR = entity.NATURE_INJURY_NAME_AR,
                        STATUS = entity.STATUS

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<RETURN_MESSAGE> DeleteNature(NATURE_INJURY_DETAILS NATURE_INJURY_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMR_NII]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        NATURE_INJURY_ID = NATURE_INJURY_ID.NATURE_INJURY_ID
                    };

                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteNature";
                throw;
            }
        }
        #endregion

        #region [Mechanism of Injury / Illness]
        public async Task<IReadOnlyList<MECH_INJURY_DETAILS>> GetEMRMIIDetails()
        {

            try
            {
                string procedure = "USP_GET_EMR_MII_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<MECH_INJURY_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRMIIDetails";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<MECH_INJURY_DETAILS> GetInjuryById(MECH_INJURY_DETAILS MECH_INJURY_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_MII]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        MECH_INJURY_ID = MECH_INJURY_ID.MECH_INJURY_ID
                    };

                    return (await connection.QueryAsync<MECH_INJURY_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetInjuryById";
                throw;
            }
        }

        public async Task<RETURN_MESSAGE> AddEMRMII(MECH_INJURY_DETAILS entity)
        {
            try
            {
                var query = "USP_ADD_EMR_MII";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        MECH_INJURY_ID = entity.MECH_INJURY_ID,
                        MECH_INJURY_NAME = entity.MECH_INJURY_NAME,
                        MECH_INJURY_NAME_AR = entity.MECH_INJURY_NAME_AR,
                        STATUS = entity.STATUS
                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RETURN_MESSAGE> DeleteMechanism(MECH_INJURY_DETAILS MECH_INJURY_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMR_MII]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        MECH_INJURY_ID = MECH_INJURY_ID.MECH_INJURY_ID
                    };

                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteMechanism";
                throw;
            }
        }
        #endregion

        #region [Agency / Source of Injury / Illness]
        public async Task<IReadOnlyList<AGENCY_INJURY_DETAILS>> GetEMRAIIDetails()
        {

            try
            {
                string procedure = "USP_GET_EMR_AII_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<AGENCY_INJURY_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRAIIDetails";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<AGENCY_INJURY_DETAILS> GetAgencyInjuryById(AGENCY_INJURY_DETAILS AGENCY_INJURY_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_AII]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        AGENCY_INJURY_ID = AGENCY_INJURY_ID.AGENCY_INJURY_ID
                    };

                    return (await connection.QueryAsync<AGENCY_INJURY_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetAgencyInjuryById";
                throw;
            }
        }


        public async Task<RETURN_MESSAGE> AddEMRAII(AGENCY_INJURY_DETAILS entity)
        {
            try
            {
                var query = "USP_ADD_EMR_AII";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        AGENCY_INJURY_ID = entity.AGENCY_INJURY_ID,
                        AGENCY_INJURY_NAME = entity.AGENCY_INJURY_NAME,
                        AGENCY_INJURY_NAME_AR = entity.AGENCY_INJURY_NAME_AR,
                        STATUS = entity.STATUS
                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<RETURN_MESSAGE> DeleteAgency(AGENCY_INJURY_DETAILS AGENCY_INJURY_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMR_AII]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        AGENCY_INJURY_ID = AGENCY_INJURY_ID.AGENCY_INJURY_ID
                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteAgency";
                throw;
            }
        }
        #endregion


        #region[Incident Cause Analysis]
        public async Task<IReadOnlyList<INCIDENT_DETAILS>> GetemrINCDTCAdetails()
        {

            try
            {
                string procedure = "USP_GET_INCDT_CA_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<INCIDENT_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetemrINCDTCAdetails";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<INCIDENT_DETAILS> GetIncidentCauseById(INCIDENT_DETAILS INCDT_CAS_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_INCDT_CA]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INCDT_CAS_ID = INCDT_CAS_ID.INCDT_CAS_ID
                    };

                    return (await connection.QueryAsync<INCIDENT_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetIncidentCauseById";
                throw;
            }
        }
        public async Task<RETURN_MESSAGE> AddemrINCDTCA(INCIDENT_DETAILS _AddEMRINCDTCA)
        {
            try
            {
                var query = "USP_ADD_EMR_INCDT_CA ";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        INCDT_CAS_ID = _AddEMRINCDTCA.INCDT_CAS_ID,
                        INCDT_CAS_NAME = _AddEMRINCDTCA.INCDT_CAS_NAME,
                        INCDT_CAS_NAME_AR = _AddEMRINCDTCA.INCDT_CAS_NAME_AR,
                        STATUS = _AddEMRINCDTCA.STATUS
                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RETURN_MESSAGE> DeleteIncidentCause(INCIDENT_DETAILS INCDT_CAS_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMR_INCDT_CA]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INCDT_CAS_ID = INCDT_CAS_ID.INCDT_CAS_ID
                    };

                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteIncidentCause";
                throw;
            }
        }

        #endregion

        #region[Incident Category]
        public async Task<IReadOnlyList<INCIDENT_CATEGORY_DETAILS>> GetIncidentCategory()
        {

            try
            {
                string procedure = "USP_GET_INCCATEGORY_MASTER"; 
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<INCIDENT_CATEGORY_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetIncidentCategory";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<INCIDENT_CATEGORY_DETAILS> GetIncidentById(INCIDENT_CATEGORY_DETAILS INC_CAT_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_INCCATEGORY]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                       INC_CAT_ID = INC_CAT_ID.INC_CAT_ID
                    };

                    return (await connection.QueryAsync<INCIDENT_CATEGORY_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetIncidentById";
                throw;
            }
        }
        public async Task<RETURN_MESSAGE> AddIncidentCategory(INCIDENT_CATEGORY_DETAILS _INC_CAT_MASTER)
        {
            try
            {
                var query = "USP_ADD_INCCATEGORY ";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        INC_CAT_ID = _INC_CAT_MASTER.INC_CAT_ID,
                        INC_CAT_NAME = _INC_CAT_MASTER.INC_CAT_NAME,
                        INC_CAT_NAME_AR = _INC_CAT_MASTER.INC_CAT_NAME_AR,
                        INC_CAT_STATUS = _INC_CAT_MASTER.INC_CAT_STATUS
                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<RETURN_MESSAGE> DeleteIncidentCategory(INCIDENT_CATEGORY_DETAILS INC_CAT_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_INCCATEGORY]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_CAT_ID = INC_CAT_ID.INC_CAT_ID
                    };

                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteIncidentCategory";
                throw;
            }
        }
        #endregion

        //#region[Drill Type]
        //public async Task<IReadOnlyList<GET_DRILL_TYPE>> GetDrill_Management_Type()
        //{

        //    try
        //    {
        //        string procedure = "USP_GET_DR_DRILLTYPE";
        //        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //        {

        //            return (await connection.QueryAsync<GET_DRILL_TYPE>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string Repo = "GetDrill_Management_Type";
        //        //ErrorLog.ErrorLogs(ex, Repo);
        //        throw;
        //    }
        //}

        //public async Task<GET_DRILL_TYPE> GetDrillTypeById(GET_DRILL_TYPE DRILL_TYPE_ID)
        //{
        //    try
        //    {
        //        string procedure = "[USP_EDIT_DR_DRILLTYPE]";
        //        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            var parameters = new
        //            {
        //                DRILL_TYPE_ID = DRILL_TYPE_ID.DRILL_TYPE_ID
        //            };

        //            return (await connection.QueryAsync<GET_DRILL_TYPE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string repo = "GetDrillTypeById";
        //        throw;
        //    }
        //}
        //public async Task<RETURN_MESSAGE> Add_Drill_Management_Type(ADD_DRILL_TYPE _AddDrillType)
        //{
        //    try
        //    {
        //        var query = "USP_ADD_DR_DRILLTYPE ";
        //        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            var Paramater = new
        //            {
        //                DRILL_TYPE_ID = _AddDrillType.DRILL_TYPE_ID,
        //                DRILL_TYPE_NAME = _AddDrillType.DRILL_TYPE_NAME,
        //                DRILL_TYPE_NAME_AR = _AddDrillType.DRILL_TYPE_NAME_AR,
        //                STATUS = _AddDrillType.STATUS
        //            };
        //            return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //#endregion

        //#region[Drill Type Checklist]
        //public async Task<IReadOnlyList<GET_DRILL_CHECKLIST>> Get_Drill_Checklist()
        //{

        //    try
        //    {
        //        string procedure = "USP_GET_DRM_DRILL_CHECKLIST";
        //        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //        {

        //            return (await connection.QueryAsync<GET_DRILL_CHECKLIST>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string Repo = "Get_Drill_Checklist";
        //        //ErrorLog.ErrorLogs(ex, Repo);
        //        throw;
        //    }
        //}

        //public async Task<GET_DRILL_CHECKLIST> GetDrillChecklistById(GET_DRILL_CHECKLIST DRILL_TYPE_ID)
        //{
        //    try
        //    {
        //        string procedure = "[USP_EDIT_DRM_DRILL_SUBCHECKLIST]";
        //        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            var parameters = new
        //            {
        //                DRILL_TYPE_ID = DRILL_TYPE_ID.DRILL_TYPE_ID
        //            };

        //            return (await connection.QueryAsync<GET_DRILL_CHECKLIST>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string repo = "GetDrillChecklistById";
        //        throw;
        //    }
        //}
        //public async Task<RETURN_MESSAGE> Add_Drill_CheckList(ADD_DRILL_CHECKLIST _DRILL_CHECKLIST)
        //{
        //    try
        //    {
        //        var query = "USP_ADD_DRM_DRILL_SUBCHECKLIST ";
        //        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            var Paramater = new
        //            {
        //                DRILL_CHECKLIST_ID = _DRILL_CHECKLIST.DRILL_CHECKLIST_ID,
        //                DRILL_TYPE_ID = _DRILL_CHECKLIST.DRILL_TYPE_ID,
        //                CREATED_BY = _DRILL_CHECKLIST.CREATED_BY,
        //                DRILL_CHECKLIST_NAME = _DRILL_CHECKLIST.DRILL_CHECKLIST_NAME,
        //                DRILL_CHECKLIST_NAME_AR = _DRILL_CHECKLIST.DRILL_CHECKLIST_NAME_AR,
        //            };
        //            return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //#endregion

        #region [DISASTER_TYPE]
        public async Task<RETURN_MESSAGE> AddDiasterType(DISASTER_TYPE_MASTER entity)
        {
            try
            {
                var query = "[USP_ADD_EMR_DISASTER_TYPE]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        DISASTER_ID = entity.DISASTER_ID,
                        DISASTER_NAME = entity.DISASTER_NAME,
                        DISASTER_NAME_AR = entity.DISASTER_NAME_AR,
                        STATUS = entity.STATUS

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DISASTER_TYPE_MASTER> GetDiasterTypeById(DISASTER_TYPE_MASTER DISASTER_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_EMR_DISASTER_TYPE]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        DISASTER_ID = DISASTER_ID.DISASTER_ID
                    };

                    return (await connection.QueryAsync<DISASTER_TYPE_MASTER>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetDiasterTypeById";
                throw;
            }
        }
        public async Task<IReadOnlyList<DISASTER_TYPE_MASTER>> GetAllDiasterType()
        {
            try
            {
                string procedure = "[USP_GET_EMR_DISASTER_TYPE]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<DISASTER_TYPE_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllDiasterType";
                // ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<RETURN_MESSAGE> DeleteDisasterType(DISASTER_TYPE_MASTER DISASTER_ID)
        {
            try
            {
                string procedure = "[USP_DELETE_EMR_DISASTER_TYPE]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        DISASTER_ID = DISASTER_ID.DISASTER_ID
                    };

                    return (await connection.QueryAsync<RETURN_MESSAGE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "DeleteDisasterType";
                throw;
            }
        }

        


        #endregion

        //#region[EMERGENCY_TEAM_ACTIVATE]
        //public async Task<IReadOnlyList<GET_EMERGENCY_TYPE_MASTER_SELECT>> GetAll_EMRMaster()
        //{
        //    try
        //    {
        //        string procedure = "[USP_GET_EMR_TEAM_ACTIVE_TYPE]";
        //        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            return (await connection.QueryAsync<GET_EMERGENCY_TYPE_MASTER_SELECT>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string Repo = "GetAll_EMRMaster";
        //        // ErrorLog.ErrorLogs(ex, Repo);
        //        throw;
        //    }
        //}

        //public async Task<RETURN_MESSAGE> AddEMRMaster(ADD_EMERGENCY_TYPE_MASTER_SELECT entity)
        //{
        //    try
        //    {
        //        var query = "[USP_ADD_EMR_TEAM_ACTIVE_TYPE]";
        //        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            var parameters = new
        //            {
        //                EMP_ACTIVE_ID = entity.EMP_ACTIVE_ID,
        //                EMR_TEAM_TYPE = entity.EMR_TEAM_TYPE,
        //                LEAD_MANAGER = entity.LEAD_MANAGER,
        //                LOCATION = entity.LOCATION,
        //                BUILDING = entity.BUILDING,
        //                SECTOR = entity.SECTOR,
        //                DEPARTMENT = entity.DEPARTMENT,
        //                SECTIONLAB = entity.SECTIONLAB,
        //                SCHEDULE = entity.SCHEDULE,
        //                STATUS = entity.STATUS,
        //                FLOOR = entity.FLOOR


        //            };
        //            return (await connection.QueryAsync<RETURN_MESSAGE>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<IReadOnlyList<Get_EMERGENCY_TYPE_CORRECTIVE_ACTION>> GetAll_EMRCorrective()
        //{
        //    try
        //    {
        //        string procedure = "[USP_GET_EMR_TEAM_CORRECTIVE_ACTION]";
        //        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            return (await connection.QueryAsync<Get_EMERGENCY_TYPE_CORRECTIVE_ACTION>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string Repo = "GetAll_EMRCorrective";
        //        // ErrorLog.ErrorLogs(ex, Repo);
        //        throw;
        //    }
        //}

        //public async Task<RETURN_MESSAGE> AddEMRCorrective(ADD_EMERGENCY_TYPE_CORRECTIVE_ACTION entity)
        //{
        //    try
        //    {
        //        var query = "USP_ADD_EMR_TEAM_CORRECTIVE_ACTION";
        //        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            var parameters = new
        //            {
        //                EMR_CORRECTIVE_ID = entity.EMR_CORRECTIVE_ID,
        //                EMP_ACTIVE_ID = entity.EMP_ACTIVE_ID,
        //                REMARKS = entity.REMARKS,
        //                DESCRIPTION = entity.DESCRIPTION,
        //                IMAGE_PATH = entity.IMAGE_PATH,
        //                IMAGE_NAME = entity.IMAGE_NAME,
        //                IMAGE_SIZE = entity.IMAGE_SIZE,
        //                STATUS = entity.STATUS,
        //                EMP_ID = entity.EMP_ID,
        //                REVIEW_DATE = entity.REVIEW_DATE
        //            };
        //            return (await connection.QueryAsync<RETURN_MESSAGE>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //#endregion
    }

}
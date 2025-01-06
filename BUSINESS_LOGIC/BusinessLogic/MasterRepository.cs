using IBUSINESS_LOGIC.IBusinessLogic;
using MODELS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using static MODELS.COMMON;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class MasterRepository : IMasterRepository
    {
        private readonly IConfiguration configuration;
        RETURN_MESSAGE message;
        public MasterRepository(IConfiguration configuration, RETURN_MESSAGE message)
        {
            this.configuration = configuration;
            this.message = message;
        }
        public async Task<IReadOnlyList<NATIONALITY_MASTER>> GetNationalityDetails()
        {

            try
            {
                string procedure = "[USP_GET_NATIONALITY_MASTER]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<NATIONALITY_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetNationalityDetails";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #region[LOCATION_MASTER]
        public async Task<RETURN_MESSAGE> AddAsync(GET_LOCATION_MASTER entity)
        {
            try
            {
                var query = "USP_ADD_LOCATION";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        LOC_ID = entity.LOC_ID,
                        LOC_NAME = entity.LOC_NAME,
                        LOC_NAME_AR = entity.LOC_NAME_AR,

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<RETURN_MESSAGE> DeleteAsync(GET_LOCATION_MASTER entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<GET_LOCATION_MASTER>> GetAllAsync()
        {

            try
            {
                string procedure = "USP_GET_LOCATION_MASTER";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_LOCATION_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllAsync";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }



        public Task<GET_LOCATION_MASTER> GetByIdAsync(GET_LOCATION_MASTER entity)
        {
            throw new NotImplementedException();
        }

        public Task<RETURN_MESSAGE> UpdateAsync(GET_LOCATION_MASTER entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region[BUILDING_MASTER]
        public async Task<RETURN_MESSAGE> Add_Building(ADD_BUILDING_MASTER entity)
        {
            try
            {
                var query = "USP_ADD_BUILDING";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        LOC_ID = entity.LOC_ID,
                        BUIL_ID = entity.BUIL_ID,
                        BUIL_NAME = entity.BUIL_NAME,
                        BUIL_NAME_AR = entity.BUIL_NAME_AR,
                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IReadOnlyList<GET_BUILDING_MASTER>> GetAll_Buildings()
        {
            try
            {
                string procedure = "USP_GET_BUILDING_MASTER";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_BUILDING_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAll_Buildings";
                // ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region[DEPARTMENT]
        public async Task<IReadOnlyList<GET_DEPARTMENT_MASTER>> GetAll_Department()
        {

            try
            {
                string procedure = "USP_GET_DEPARTMENT_MASTER";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_DEPARTMENT_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAll";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<GET_DEPARTMENT_MASTER> GetDepartmentById(GET_DEPARTMENT_MASTER model)
        {
            try
            {

                var query = "USP_EDIT_DEPRATMENT";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        DEP_ID = model.DEP_ID

                    };
                    return (await connection.QueryAsync<GET_DEPARTMENT_MASTER>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RETURN_MESSAGE> AddDepartment(ADD_DEPARTMENT_MASTER DEPT)
        {
            try
            {
                var query = "USP_ADD_DEPARTMENT";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        DEP_ID = DEPT.DEP_ID,
                        SEC_ID = DEPT.SEC_ID,
                        DEP_NAME = DEPT.DEP_NAME,
                        DEP_NAME_AR = DEPT.DEP_NAME_AR

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region[DESIGNATION]
        public async Task<IReadOnlyList<GET_DESIGNATION_DETAILS>> GetDesignationDetails()
        {
            try
            {

                string query = "USP_GET_DESIGNATION";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_DESIGNATION_DETAILS>(query, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RETURN_MESSAGE> AddDesignationDetails(DesignationModel model)
        {
            try
            {
                var query = "USP_ADD_DESIGNATION";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var param = new
                    {
                        DESIID = model.DESI_ID,
                        DESINAMEEN = model.DESI_NAME_EN,
                        DESINAMEARB = model.DESI_NAME_ARB
                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DesignationModel> GetDesignationById(DesignationModel model)
        {
            try
            {

                var query = "USP_EDIT_DESIGNATION";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        DESIID = model.DESI_ID

                    };
                    return (await connection.QueryAsync<DesignationModel>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region[SECTION_LAB_MASTER]
        public async Task<RETURN_MESSAGE> AddSectionLab(ADD_SECTION_LAB_MASTER entity)
        {
            try
            {
                var query = "USP_ADD_SECTION_LAB";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        SEC_LAB_ID = entity.SEC_LAB_ID,
                        SEC_LAB_NAME = entity.SEC_LAB_NAME,
                        SEC_LAB_NAME_AR = entity.SEC_LAB_NAME_AR,
                        DEP_ID = entity.DEP_ID

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IReadOnlyList<GET_SECTION_LAB_MASTER>> GetSectionLabMaster()
        {

            try
            {
                string procedure = "USP_GET_SECTION_LAB_MASTER";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_SECTION_LAB_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetSectionLabMaster";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region[EMERGENCY_TYPE_MASTER]
        public async Task<IReadOnlyList<GET_EMR_TYPE_MASTER>> GetEmergTypeMaster()
        {

            try
            {
                string procedure = "USP_EMR_EMERGENCY_TYPE_MASTER_GET";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_EMR_TYPE_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEmergTypeMaster";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<RETURN_MESSAGE> AddEmergTypeMaster(ADD_EMR_TYPE_MASTER entity)
        {
            try
            {
                var query = "USP_EMR_EMERGENCY_TYPE_MASTER_ADD";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        EMERG_TYPE_MAS_ID = entity.EMERG_TYPE_MAS_ID,
                        EMERG_TYPE_MAS = entity.EMERG_TYPE_MAS,
                        EMERG_TYPE_MAS_AR = entity.EMERG_TYPE_MAS_AR,


                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [SECTOR]
        //sector model add
        public async Task<RETURN_MESSAGE> AddSectorDetails(SectorModel model)
        {
            try
            {
                var query = "USP_ADD_SECTOR";
                using (var connection = new


                    SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        SECID = model.SEC_ID,
                        BUILID = model.BUIL_ID,
                        SECTYPEID = model.SEC_TYPE,
                        SECNAMEEN = model.SEC_NAME_EN,
                        SECNAMEARB = model.SEC_NAME_ARB,
                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GET_SECTOR_DETAILS get
        public async Task<IReadOnlyList<GET_SECTOR_DETAILS>> GetAll_Sector()
        {
            try
            {
                string procedure = "USP_GET_SECTOR";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_SECTOR_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetSectorDetails";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [SECTOR_TYPE]
        // SectorTypeModel add
        public async Task<RETURN_MESSAGE> AddSectorTypeDetails(SectorTypeModel model)
        {
            try
            {
                var query = "USP_ADD_SECTORTYPE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        SECTYPEID = model.SEC_TYPE_ID,
                        SECTYPENAMEEN = model.SEC_TYPE_NAME_EN,
                        SECTYPENAMEARB = model.SEC_TYPE_NAME_ARB,
                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //GetSectorTypeDetails GET
        public async Task<IReadOnlyList<SectorTypeModel>> GetSectorTypeDetails()
        {

            try
            {
                string procedure = "[USP_GET_SECTORTYPE]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<SectorTypeModel>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetSectorTypeDetails";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion


    }
}

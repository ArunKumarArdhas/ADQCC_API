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

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class AuditManagementRepository: IAuditManagementRepository
    {
        private readonly IConfiguration configuration;
        RETURN_MESSAGE message;
        public AuditManagementRepository(IConfiguration configuration, RETURN_MESSAGE message)
        {
            this.configuration = configuration;
            this.message = message;
        }
        #region [AUDIT_TYPE_MASTER]
        public async Task<IReadOnlyList<AUDIT_TYPE_MASTER>> GetAuditType()
        {

            try
            {
                string procedure = "USP_GET_AUDIT_TYPE_MASTER";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<AUDIT_TYPE_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAuditType";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<RETURN_MESSAGE> AddAuditType(AUDIT_TYPE_MASTER entity)
        {
            try
            {
                var query = "USP_ADD_AUDIT_TYPE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        AUDIT_TYPE_ID = entity.AUDIT_TYPE_ID,
                        AUDIT_TYPE_NAME = entity.AUDIT_TYPE_NAME,
                        AUDIT_TYPE_NAME_AR = entity.AUDIT_TYPE_NAME_AR,
                        CREATED_BY = entity.CREATED_BY

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<AUDIT_TYPE_MASTER> GetAuditTypeEdit(AUDIT_TYPE_MASTER model)
        {
            try
            {

                var query = "USP_EDIT_AUDIT_TYPE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        AUDIT_TYPE_ID = model.AUDIT_TYPE_ID

                    };
                    return (await connection.QueryAsync<AUDIT_TYPE_MASTER>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region [AUDIT_STANDARD_MASTER]

        public async Task<IReadOnlyList<AUDIT_STANDARD_MASTER>> GetStandard()
        {

            try
            {
                string procedure = "USP_GET_STANDARD_MASTER";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<AUDIT_STANDARD_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetStandard";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<RETURN_MESSAGE> AddStandard(AUDIT_STANDARD_MASTER entity)
        {
            try
            {
                var query = "USP_ADD_STANDARD";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        STANDARD_ID = entity.STANDARD_ID,
                        STANDARD_NAME = entity.STANDARD_NAME,
                        STANDARD_NAME_AR = entity.STANDARD_NAME_AR,
                        CREATED_BY = entity.CREATED_BY

                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<AUDIT_STANDARD_MASTER> GetStandardEdit(AUDIT_STANDARD_MASTER model)
        {
            try
            {

                var query = "USP_EDIT_STANDARD";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        STANDARD_ID = model.STANDARD_ID

                    };
                    return (await connection.QueryAsync<AUDIT_STANDARD_MASTER>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        public Task<AUDIT_TYPE_MASTER> GetByIdAsync(AUDIT_TYPE_MASTER entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<AUDIT_TYPE_MASTER>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RETURN_MESSAGE> AddAsync(AUDIT_TYPE_MASTER entity)
        {
            throw new NotImplementedException();
        }

        public Task<RETURN_MESSAGE> UpdateAsync(AUDIT_TYPE_MASTER entity)
        {
            throw new NotImplementedException();
        }

        public Task<RETURN_MESSAGE> DeleteAsync(AUDIT_TYPE_MASTER entity)
        {
            throw new NotImplementedException();
        }
    }
    
       
}

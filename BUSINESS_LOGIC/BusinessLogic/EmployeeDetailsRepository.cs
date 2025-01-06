using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBUSINESS_LOGIC.IBusinessLogic;
using System.Data;
using Microsoft.Extensions.Configuration;
using Dapper;
using MODELS;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;
using System.Data.Common;

namespace BUSINESS_LOGIC.BusinessLogic
{
    internal class EmployeeDetailsRepository : IEmployeeDetailsRepository
    {

        private readonly IConfiguration configuration;
        RETURN_MESSAGE message;

        private readonly string _noImage;

        public EmployeeDetailsRepository(IConfiguration configuration, RETURN_MESSAGE message)
        {
            this.configuration = configuration;
            this.message = message;
            _noImage = configuration["NoImage"] ?? "~/images/default-no-image.png";

        }


        public async Task<IEnumerable<GET_EMPLOYEE_DETAILS>> GetEmployeeDetails(string EMP_ID, string EMP_NAME, string EMP_DESI)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EMP_ID", EMP_ID);
                param.Add("@EMP_NAME", EMP_NAME);
                param.Add("@EMP_DESI", EMP_DESI);

                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync();
                    var query = "[USP_GET_EMPLOYEE_DETAILS]";
                    var objUserList = await con.QueryAsync<GET_EMPLOYEE_DETAILS>(query, param, commandType: CommandType.StoredProcedure);
                    return objUserList.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the error before rethrowing (optional, if a logger is available)
                // _logger.LogError(ex, "Error occurred while fetching employee details");
                throw;
            }
        }

        public async Task<ADD_EMPLOYEE_DETAILS> AddEmployeeDetails(ADD_EMPLOYEE_DETAILS _EMPLOYEE_DETAILS)
        {
            try
            {
                // Decrypt the employee encrypt ID
                //var Dec = Decrypt(_EMPLOYEE_DETAILS.EMP_ENCRYPT_ID);
                //if (Dec != "10414")
                //{
                //    return new ADD_EMPLOYEE_DETAILS
                //    {
                //        STATUS_CODE = "401",
                //        MESSAGE = "Error Unauthorized"
                //    };
                //}

                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync();

                    // Prepare parameters
                    var param = new DynamicParameters();
                    param.Add("@EMP_ID", _EMPLOYEE_DETAILS.EMP_ID);
                    param.Add("@EMP_FIRSTNAME", _EMPLOYEE_DETAILS.EMP_FIRSTNAME);
                    param.Add("@EMP_LASTNAME", _EMPLOYEE_DETAILS.EMP_LASTNAME);
                    param.Add("@EMP_GENDER", _EMPLOYEE_DETAILS.EMP_GENDER);
                    param.Add("@EMP_NATIONALITY_ID", _EMPLOYEE_DETAILS.EMP_NATIONALITY_ID);
                    param.Add("@EMP_DESIGNATION_ID", _EMPLOYEE_DETAILS.EMP_DESIGNATION_ID);
                    param.Add("@EMP_LOCATION_ID", _EMPLOYEE_DETAILS.EMP_LOCATION_ID);
                    param.Add("@EMP_BUILDING_ID", _EMPLOYEE_DETAILS.EMP_BUILDING_ID);
                    param.Add("@EMP_SECTOR_ID", _EMPLOYEE_DETAILS.EMP_SECTOR_ID);
                    param.Add("@EMP_DEPARTMENT_ID", _EMPLOYEE_DETAILS.EMP_DEPARTMENT_ID);
                    param.Add("@EMP_SECTION_ID", _EMPLOYEE_DETAILS.EMP_SECTION_ID);
                    param.Add("@EMP_EMAIL", _EMPLOYEE_DETAILS.EMP_EMAIL);
                    param.Add("@EMP_PHONE_NO", _EMPLOYEE_DETAILS.EMP_PHONE_NO);
                    param.Add("@EMP_TEL_NO", _EMPLOYEE_DETAILS.EMP_TEL_NO);
                    param.Add("@EMP_STATUS", _EMPLOYEE_DETAILS.EMP_STATUS);
                    param.Add("@EMP_NAME_AR", _EMPLOYEE_DETAILS.EMP_NAME_AR);
                    param.Add("@OCCUPATION", _EMPLOYEE_DETAILS.OCCUPATION);
                    param.Add("@PASSPORT_NUMBER", _EMPLOYEE_DETAILS.PASSPORT_NUMBER);
                    param.Add("@DOB", _EMPLOYEE_DETAILS.DOB);
                    param.Add("@LENGTH_OF_SERVICE", _EMPLOYEE_DETAILS.LENGTH_OF_SERVICE);
                    param.Add("@EMPLOYEE_CATEGORY", _EMPLOYEE_DETAILS.EMPLOYEE_CATEGORY);
                    param.Add("@SECTION_HEAD", _EMPLOYEE_DETAILS.SECTION_HEAD);
                    param.Add("@EHS_MANAGER", _EMPLOYEE_DETAILS.EHS_MANAGER);
                    param.Add("@HSSE_MANAGER", _EMPLOYEE_DETAILS.HSSE_MANAGER);
                    param.Add("@EMP_USERNAME", _EMPLOYEE_DETAILS.EMP_USERNAME);
                    param.Add("@EMP_PASSWORD", _EMPLOYEE_DETAILS.EMP_PASSWORD);
                    param.Add("@IMAGE_PATH", string.IsNullOrEmpty(_EMPLOYEE_DETAILS.IMAGE_PATH) ? _noImage : _EMPLOYEE_DETAILS.IMAGE_PATH);

                    // Call stored procedure
                    var query = "[USP_ADD_EMPLOYEE_DETAILS]";
                    var objUserList = await con.QuerySingleOrDefaultAsync<ADD_EMPLOYEE_DETAILS>(
                        query, param, commandType: CommandType.StoredProcedure);

                    // Encrypt the STATUS_CODE and update
                    var encryptedId = Encrypt(objUserList.STATUS_CODE);
                    var updateParam = new DynamicParameters();
                    updateParam.Add("@EMP_ID", objUserList.STATUS_CODE);
                    updateParam.Add("@EMP_ENCRYPT_ID", encryptedId);
                    await con.ExecuteAsync("[USP_UPDATE_ENCRYPT_EMPLOYEE_DETAILS]", updateParam, commandType: CommandType.StoredProcedure);

                    // Handle emergency type selection
                    if (_EMPLOYEE_DETAILS._EMERG_TYPE_SELECT_LIST != null)
                    {
                        foreach (var emergType in _EMPLOYEE_DETAILS._EMERG_TYPE_SELECT_LIST)
                        {
                            emergType.EMP_ID = objUserList.STATUS_CODE;
                            var emergParam = new DynamicParameters();
                            emergParam.Add("@EMP_EMERG_TYPE_ID", emergType.EMP_EMERG_TYPE_ID);
                            emergParam.Add("@EMP_ID", emergType.EMP_ID);
                            emergParam.Add("@EMERG_TYPE_MAS_ID", emergType.EMERG_TYPE_MAS_ID);
                            emergParam.Add("@CREATED_BY", emergType.CREATED_BY);

                            await con.ExecuteAsync("[USP_EMPLOYEE_EMERG_TYPE_ADD]", emergParam, commandType: CommandType.StoredProcedure);
                        }
                    }

                    return objUserList;
                }
            }
            catch (Exception ex)
            {
                return new ADD_EMPLOYEE_DETAILS
                {
                    STATUS_CODE = "500",
                    MESSAGE = "An error occurred while processing the request."
                };
            }
        }

        #region [ Decrypt and Encrypt]
        public string Encrypt(string clearText)
        {
            string encryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
            using (Aes aes = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = pdb.GetBytes(32);
                aes.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string Decrypt(string cipherText)
        {
            string encryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = pdb.GetBytes(32);
                aes.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }

        #endregion

        public async Task<List<RETURN_MESSAGE>> GetEmp_Dir_BySector(string SECTOR_ID, string BUILDING_ID)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@SECTOR_ID", SECTOR_ID);
                param.Add("@BUILDING_ID", BUILDING_ID);

                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync(); // Open connection asynchronously
                    var query = "[USP_GET_EMP_DIR_BY_SECTOR]";
                    var objUserList = await con.QueryAsync<RETURN_MESSAGE>(
                        query,
                        param,
                        commandType: CommandType.StoredProcedure
                    );
                    return objUserList.ToList(); // Return the result as a list
                }
            }
            catch (Exception)
            {
                throw; // Rethrow the exception
            }
        }

        public async Task<List<EMPLOYEE_PREVIEW>> GetEmployee_Preview()
        {
            try
            {
                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync(); // Open connection asynchronously
                    var query = "[USP_BULKUPLOAD_GET_PREVIEWLIST]";

                    // Execute the query asynchronously and map the result to EMPLOYEE_PREVIEW
                    var objUserList = await con.QueryAsync<EMPLOYEE_PREVIEW>(
                        query,
                        commandType: CommandType.StoredProcedure
                    );

                    return objUserList.ToList(); // Return the result as a list
                }
            }
            catch (Exception)
            {
                throw; // Rethrow the exception
            }
        }

        public async Task<List<HEALTH_VITAL_LIST>> GetHealthVitalsDetails(string EMP_ID)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@EMP_ID", EMP_ID);

                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync(); // Open connection asynchronously
                    var query = "[USP_GET_HEALTH_VITALS]";

                    // Execute the query asynchronously and map the result to HEALTH_VITAL_LIST
                    var objUserList = await con.QueryAsync<HEALTH_VITAL_LIST>(
                        query,
                        param,
                        commandType: CommandType.StoredProcedure
                    );

                    return objUserList.ToList(); // Return the result as a list
                }
            }
            catch (Exception)
            {
                throw; // Rethrow the exception
            }
        }

        public async Task<List<GET_EMPLOYEE_DETAILS>> GetEmployeeFilter()
        {
            try
            {
                var param = new DynamicParameters();

                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync(); // Open connection asynchronously
                    var query = "[USP_GET_EMPLOYEE_DETAILS_BY_FILTER]";

                    // Execute the query asynchronously and map the result to GET_EMPLOYEE_DETAILS
                    var objUserList = await con.QueryAsync<GET_EMPLOYEE_DETAILS>(
                        query,
                        param,
                        commandType: CommandType.StoredProcedure
                    );

                    return objUserList.ToList(); // Return the result as a list
                }
            }
            catch (Exception)
            {
                throw; // Rethrow the exception
            }
        }

        public async Task<List<EMPLOYEE_MANAGER_LIST>> GetEmployee_EHSList()
        {
            try
            {
                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync(); // Open connection asynchronously
                    var query = "[USP_EMP_GET_EHS_LIST]";

                    // Execute the query asynchronously and map the result to EMPLOYEE_MANAGER_LIST
                    var objUserList = await con.QueryAsync<EMPLOYEE_MANAGER_LIST>(
                        query,
                        commandType: CommandType.StoredProcedure
                    );

                    return objUserList.ToList(); // Return the result as a list
                }
            }
            catch (Exception)
            {
                throw; // Rethrow the exception
            }
        }

        public async Task<List<EMPLOYEE_MANAGER_LIST>> GetEmployee_SECTION_HEAD_List()
        {
            try
            {
                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync(); // Open connection asynchronously
                    var query = "[USP_EMP_GET_SECTION_HEAD_LIST]";

                    // Execute the query asynchronously and map the result to EMPLOYEE_MANAGER_LIST
                    var objUserList = await con.QueryAsync<EMPLOYEE_MANAGER_LIST>(
                        query,
                        commandType: CommandType.StoredProcedure
                    );

                    return objUserList.ToList(); // Return the result as a list
                }
            }
            catch (Exception)
            {
                throw; // Rethrow the exception
            }
        }

        public async Task<List<EMPLOYEE_MANAGER_LIST>> GetEmployee_HSSE_List()
        {
            try
            {
                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync(); // Open connection asynchronously
                    var query = "[USP_EMP_GET_HSSE_LIST]";

                    // Execute the query asynchronously and map the result to EMPLOYEE_MANAGER_LIST
                    var objUserList = await con.QueryAsync<EMPLOYEE_MANAGER_LIST>(
                        query,
                        commandType: CommandType.StoredProcedure
                    );

                    return objUserList.ToList(); // Return the result as a list
                }
            }
            catch (Exception)
            {
                throw; // Rethrow the exception
            }
        }

        public async Task<RETURN_MESSAGE> GetActiveDeactiveStatus(string EMP_ID, string STATUS, string PASSWORD, string USERNAME)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@EMP_ID", EMP_ID);
                param.Add("@STATUS", STATUS);
                param.Add("@PASSWORD", PASSWORD);
                param.Add("@USERNAME", USERNAME);

                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync(); // Open connection asynchronously
                    var query = "[USP_UPDATE_ACTIVE_DEACTIVE]";

                    // Execute the query asynchronously and map the result to RETURN_MESSAGE
                    var objUserList = await con.QueryAsync<RETURN_MESSAGE>(
                        query,
                        param,
                        commandType: CommandType.StoredProcedure
                    );

                    return objUserList.SingleOrDefault(); // Return the single result or null
                }
            }
            catch (Exception)
            {
                throw; // Rethrow the exception
            }
        }

        public async Task<RETURN_MESSAGE> DeleteEmployeeDetails(string EMP_ID)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@EMP_ID", EMP_ID);

                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync(); // Open connection asynchronously
                    var query = "[USP_DELETE_EMPLOYEE_DETAILS]";

                    // Execute the query asynchronously and map the result to RETURN_MESSAGE
                    var objUserList = await con.QueryAsync<RETURN_MESSAGE>(
                        query,
                        param,
                        commandType: CommandType.StoredProcedure
                    );

                    return objUserList.SingleOrDefault(); // Return the single result or null
                }
            }
            catch (Exception)
            {
                throw; // Rethrow the exception
            }
        }

        public async Task<ADD_EMPLOYEE_DETAILS> EditEmployeeDetails(string EMP_ID)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@EMP_ID", EMP_ID);

                using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await con.OpenAsync(); // Open the connection asynchronously
                    var query = "[USP_EDIT_EMPLOYEE_DETAILS]";

                    // Execute the query asynchronously and map the result to ADD_EMPLOYEE_DETAILS
                    var objUserList = await con.QueryAsync<ADD_EMPLOYEE_DETAILS>(
                        query,
                        param,
                        commandType: CommandType.StoredProcedure
                    );

                    return objUserList.SingleOrDefault(); // Return the single result or null
                }
            }
            catch (Exception)
            {
                throw; // Rethrow the exception
            }
        }


    }
}

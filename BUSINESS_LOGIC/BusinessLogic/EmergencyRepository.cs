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

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class EmergencyRepository : IEmergencyRepository
    {

        private readonly IConfiguration configuration;
        RETURN_MESSAGE message;

        public EmergencyRepository(IConfiguration configuration, RETURN_MESSAGE message)
        {
            this.configuration = configuration;
            this.message = message;
        }

        #region

        public async Task<IEnumerable<GET_EMERGENCY_TYPE_MASTER_SELECT>> _GetEmrTeamActivate()
        {
            try
            {
                string procedure = "[USP_GET_EMR_TEAM_ACTIVE_TYPE]";

                //// Using the configuration to get the connection string
                //using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                //{
                //    // Ensure the connection is open asynchronously
                //    await connection.OpenAsync().ConfigureAwait(false);

                //    // Execute the stored procedure asynchronously and return the result as a list
                //    var result = await connection.QueryAsync<GET_EMERGENCY_TYPE_MASTER_SELECT>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                //    // Return the result as a list
                //    return result.ToList();
                //}

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    // Ensure the connection is open asynchronously
                    await connection.OpenAsync().ConfigureAwait(false);

                    // Execute the stored procedure asynchronously and return the result as a list
                    var result = (await connection.QueryAsync<GET_EMERGENCY_TYPE_MASTER_SELECT>(
                        procedure,
                        commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false)).ToList();

                    //// Check if the list is empty
                    //if (!result.Any())
                    //{
                    //    // Add a hardcoded row
                    //    result.Add(new GET_EMERGENCY_TYPE_MASTER_SELECT
                    //    {
                    //        EMP_ACTIVE_ID = "1",
                    //        EMR_TEAM_TYPE = "Default_Team_Type",
                    //        LEAD_MANAGER = "Default_Manager",
                    //        LOCATION = "Default_Location",
                    //        BUILDING = "Default_Building",
                    //        SECTOR = "Default_Sector",
                    //        DEPARTMENT = "Default_Department",
                    //        SECTIONLAB = "Default_SectionLab",
                    //        LOCATION_NAME = "Default_Location_Name",
                    //        BUILDING_NAME = "Default_Building_Name",
                    //        SECTOR_NAME = "Default_Sector_Name",
                    //        DEPARTMENT_NAME = "Default_Department_Name",
                    //        SECTION_LAB_NAME = "Default_Section_Lab_Name",
                    //        CREATED_BY_NAME = "Default_Creator",
                    //        EMERG_TYPE_NAME = "Default_Emergency_Type",
                    //        SCHEDULE = "Default_Schedule",
                    //        UNIQUE_ID = "1",
                    //        CREATED_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    //        STATUS = "Default_Status",
                    //        ActiveDeactive = "1",
                    //        CREATED_BY = "Default_Creator_ID",
                    //        UPDATED_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    //        UPDATED_BY = "Default_Updater_ID",
                    //        ACCEPT_REJECT_STATUS = "Default_Status",
                    //        EMP_NAME_AR = "Default_Employee_Arabic_Name",
                    //        EMERG_TYPE_NAME_AR = "Default_Emergency_Type_Arabic_Name",
                    //        FLOOR = "Default_Floor"
                    //    });
                    //}

                    // Return the result as a list
                    return result;
                }


            }
            catch (Exception ex)
            {
                // Log the error if needed
                string repo = "_GetEmrTeamActivate";
                // Uncomment if you have a logging mechanism
                // ErrorLog.ErrorLogs(ex, repo); 

                // Rethrow the exception with additional context
                throw new Exception($"An error occurred in {repo}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<GET_EMPLOYEE_DETAILS>> _GetSelectEmployeeLoad()
        {
            try
            {
                // Use the 'using' statement for connection management to ensure it is properly disposed
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await connection.OpenAsync().ConfigureAwait(false); // Asynchronously open the connection

                    var query = "[USP_GET_EMPLOYEE_DETAILS_BY_FILTER_TM]";
                    var param = new DynamicParameters();

                    // Execute the stored procedure asynchronously
                    var employeeDetails = await connection.QueryAsync<GET_EMPLOYEE_DETAILS>(query, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                    // Return the result as a list
                    return employeeDetails.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the error if needed
                string repo = "_GetSelectEmployeeLoad";
                // Uncomment if you have a logging mechanism
                // ErrorLog.ErrorLogs(ex, repo); 

                // Rethrow the exception with additional context
                throw new Exception($"An error occurred in {repo}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<GET_EMERGENCY_TYPE_TEAM>> _GetEmergencyTypeTeamList()
        {
            try
            {
                // Use the 'using' statement for connection management to ensure proper disposal
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    await connection.OpenAsync().ConfigureAwait(false); // Asynchronously open the connection

                    var query = "[USP_EMR_EMERGENCY_TYPE_TEAM_GET]";

                    // Execute the stored procedure asynchronously
                    var emergencyTypeTeams = await connection.QueryAsync<GET_EMERGENCY_TYPE_TEAM>(query, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                    foreach (var item in emergencyTypeTeams)
                    {
                        // Prepare parameters for sub-query
                        var paramSub = new DynamicParameters();
                        paramSub.Add("@EMERG_TYPE_MAS_ID", item.EMERG_TYPE_MAS_ID);

                        var subQuery = "[USP_EMR_EMPLOYEE_EMERG_TYPE_TEAM_GET]";

                        // Fetch related data for each team
                        var subData = await connection.QueryAsync<GET_EMPLOYEE_EMERG_TYPE_TEAM>(subQuery, paramSub, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                        if (subData != null && subData.Any())
                        {
                            item._EMPLOYEE_EMERG_TYPE_TEAM_LIST = subData.ToList();
                        }
                    }

                    // Return the final result
                    return emergencyTypeTeams.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the error if needed
                string repo = "_GetEmergencyTypeTeamList";
                // Uncomment if you have a logging mechanism
                // ErrorLog.ErrorLogs(ex, repo); 

                // Rethrow the exception with additional context
                throw new Exception($"An error occurred in {repo}: {ex.Message}", ex);
            }
        }


        #endregion

    }
}

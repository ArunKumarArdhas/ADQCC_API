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
using System.Collections;
using Microsoft.Extensions.Logging;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly IConfiguration configuration;
        RETURN_MESSAGE message;

        public IncidentRepository(IConfiguration configuration, RETURN_MESSAGE message)
        {
            this.configuration = configuration;
            this.message = message;
        }

        private async Task<SqlConnection> GetConnectionAsync()
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }

        #region[Incident Category]

        public async Task<List<GET_INCIDENT_DETAILS>> GetIncident(string EMP_LOGIN_ID, string DESI_NAME)
        {
            try
            {
                string query = "USP_GET_INCIDENT_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var param = new DynamicParameters();
                    param.Add("@EMP_LOGIN_ID", EMP_LOGIN_ID);
                    param.Add("@DESI_NAME", DESI_NAME);
                    List<GET_INCIDENT_DETAILS> objUserList = SqlMapper.Query<GET_INCIDENT_DETAILS>(connection, query, param, commandType: CommandType.StoredProcedure).ToList();

                    foreach (var item in objUserList)
                    {
                        switch (item.INC_STATUS)
                        {
                            case "1":
                                item.INC_STATUS_NAME = "HSSE Team Approval Pending";
                                break;
                            case "2":
                                item.INC_STATUS_NAME = "Investigation Closed";
                                break;
                            case "3":
                                item.INC_STATUS_NAME = "Investigation Pending";
                                break;
                            case "4":
                                item.INC_STATUS_NAME = "Waiting for EHS Manager Approval";
                                break;
                            case "5":
                                item.INC_STATUS_NAME = "Waiting for Department Manager";
                                break;
                            case "6":
                                item.INC_STATUS_NAME = "Waiting for Exec. Director of Sector Approval";
                                break;
                            case "7":
                            case "8":
                                item.INC_STATUS_NAME = "Investigation Complete";
                                break;
                            case "9":
                                item.INC_STATUS_NAME = "Investigation Pending";
                                break;
                            default:
                                item.INC_STATUS_NAME = "Unknown Status";
                                break;
                        }
                    }

                    return objUserList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<IReadOnlyList<GET_INCIDENT_CATEGORY_DETAILS>> GetIncidentCategory()
        {

            try
            {
                string procedure = "USP_GET_INCCATEGORY_MASTER";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_INCIDENT_CATEGORY_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetIncidentCategory";
                throw;
            }
        }
        public async Task<GET_INCIDENT_CATEGORY_DETAILS> GetIncidentById(GET_INCIDENT_CATEGORY_DETAILS INC_ID)
        {
            try
            {
                string procedure = "USP_EDIT_INCIDENT_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID.INC_ID
                    };
                    return (await connection.QueryAsync<GET_INCIDENT_CATEGORY_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GetIncidentById";
                throw;
            }
        }
        public async Task<RETURN_MESSAGE> AddIncidentCategory(IncidentCategoryModel _INC_CAT_MASTER)
        {
            try
            {
                var query = "USP_ADD_INCCATEGORY ";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        INCCATID = _INC_CAT_MASTER.INC_CAT_ID,
                        INCCATNAME = _INC_CAT_MASTER.INC_CAT_NAME,
                        INCCATNAMEAR = _INC_CAT_MASTER.INC_CAT_NAME_AR
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

        #region [Incident Details]

        public async Task<RETURN_MESSAGE> AddIncident(IncidentModel _INC_DETAILS)
        {
            try
            {
                var query = "USP_ADD_INCIDENT_DETAILS";
                var notificationQuery = "USP_ADD_BELL_NOTIFICATION_COMMON";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = _INC_DETAILS.INC_ID,
                        INC_CATEGORY = _INC_DETAILS.INC_CATEGORY,
                        INC_DATE_TIME = _INC_DETAILS.INC_DATE_TIME,
                        INC_NOTIFY_BY = _INC_DETAILS.INC_NOTIFY_BY,
                        INC_DEPART_ID = _INC_DETAILS.INC_DEPART_ID,
                        INC_LOC_ID = _INC_DETAILS.INC_LOC_ID,
                        INC_SEC_ID = _INC_DETAILS.INC_SEC_ID,
                        INC_SEC_LAB_ID = _INC_DETAILS.INC_SEC_LAB_ID,
                        INC_BUIL_ID = _INC_DETAILS.INC_BUIL_ID,
                        IS_PERSON_INVOLVED = _INC_DETAILS.IS_PERSON_INVOLVED,
                        IS_FATALITY = _INC_DETAILS.IS_FATALITY,
                        DESCRIPTION = _INC_DETAILS.DESCRIPTION,
                        INC_TYPE = _INC_DETAILS.INC_TYPE,
                        REPORTED_BY = _INC_DETAILS.REPORTED_BY,
                        OTHER_NAME = _INC_DETAILS.OTHER_NAME
                    };

                    var objUserList = (await connection.QueryAsync<RETURN_MESSAGE>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (_INC_DETAILS.INCIDENT_TYPE_DETAILS != null)
                    {
                        foreach (var item in _INC_DETAILS.INCIDENT_TYPE_DETAILS)
                        {
                            if (item.INCIDENT_TYPE_ID != "Safety_Property_Damage")
                            {
                                item.SAFETY_EQUIPMENT_ID = string.Empty;
                            }
                            if (item.INCIDENT_TYPE_ID != "Property_Damage")
                            {
                                item.EN_EQUIPMENT_ID = string.Empty;
                            }
                            item.INC_ID = objUserList.STATUS_CODE;
                        }

                        await connection.ExecuteAsync("USP_ADD_INCIDENT_TYPE_DETAILS", _INC_DETAILS.INCIDENT_TYPE_DETAILS, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                    }

                    var notificationParameters = new
                    {
                        ANS_CONTENT_TITLE = "Emergency Preparedness",
                        ANS_CONTENT_TITLE_AR = "التأهب للطوارئ",
                        EMP_ID = string.Empty,
                        DESIGNATION = "HSSE Manager",
                        ANS_CONTENT_TITLE_DISCRIPTION = "Incident Approval Pending",
                        ANS_CONTENT_TITLE_DISCRIPTION_AR = "في انتظار الموافقة على الحادث ",
                        HYPER_LINK = "Emergency/IncidentDetails?LanguageAbbrevation=",
                        ANS_NOTIFICATIONTYPE = "2"
                    };

                    await connection.QueryAsync<RETURN_MESSAGE>(notificationQuery, notificationParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                    return objUserList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #endregion

        #region[Incident Cause Analysis]
        public async Task<IReadOnlyList<GET_EMR_INCDT_CA_DETAILS>> GetemrINCDTCAdetails()
        {
            try
            {
                string procedure = "USP_GET_INCDT_CA_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_EMR_INCDT_CA_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetemrINCDTCAdetails";
                throw;
            }
        }

        public async Task<GET_EMR_INCDT_CA_DETAILS> GetIncidentCauseById(GET_EMR_INCDT_CA_DETAILS INCDT_CAS_ID)
        {
            try
            {
                string procedure = "USP_EDIT_EMR_INCDT_CA";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INCDT_CAS_ID = INCDT_CAS_ID.INCDT_CAS_ID
                    };

                    return (await connection.QueryAsync<GET_EMR_INCDT_CA_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GetIncidentCauseById";
                throw;
            }
        }
        public async Task<RETURN_MESSAGE> AddemrINCDTCA(ADD_EMR_INCDT_CA_MASTER _AddEMRINCDTCA)
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
        #endregion

        #region [NOTIFICATION]
        public async Task<VIEW_INCIDENT_DETAILS_LIST> ViewIncident(string INCID)
        {
            if (string.IsNullOrWhiteSpace(INCID))
                throw new ArgumentException("Incident ID cannot be null or empty.", nameof(INCID));
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var param = new
                    {
                        INC_ID = INCID
                    };
                    const string viewIncidentTypeProc = "USP_VIEW_INCIDENT_TYPE_DETAILS";
                    const string viewPhotosProc = "USP_VIEW_INCIDENT_UPLOAD_PHOTOS";
                    const string viewVideosProc = "USP_VIEW_INCIDENT_UPLOAD_VIDEOS";
                    const string viewIncidentProc = "USP_VIEW_INCIDENT_DETAILS";
                    var objUserListTypeTask = con.QueryAsync<ADQ_INCIDENT_TYPE_DETAILS>(viewIncidentTypeProc, param, commandType: CommandType.StoredProcedure);
                    var objUserPhotosTask = con.QueryAsync<UPLOAD_PHOTO_LIST>(viewPhotosProc, param, commandType: CommandType.StoredProcedure);
                    var objUserVideosTask = con.QueryAsync<UPLOAD_INC_VIDEO_LIST>(viewVideosProc, param, commandType: CommandType.StoredProcedure);
                    var objUserListTask = con.QueryAsync<VIEW_INCIDENT_DETAILS>(viewIncidentProc, param, commandType: CommandType.StoredProcedure);
                    var objUserListType = (await objUserListTypeTask).ToList();
                    var objUserPhotos = (await objUserPhotosTask).ToList();
                    var objUserVideos = (await objUserVideosTask).ToList();
                    var objUserList = (await objUserListTask).ToList();
                    return new VIEW_INCIDENT_DETAILS_LIST
                    {
                        VIEW_INCIDENT_DETAILS = objUserList,
                        UPLOAD_PHOTO_LIST = objUserPhotos,
                        INCIDENT_TYPE_DETAILS = objUserListType,
                        UPLOAD_INC_VIDEO_LIST = objUserVideos,
                        MESSAGE = "Success",
                        STATUS = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new VIEW_INCIDENT_DETAILS_LIST
                {
                    MESSAGE = "Internal Server Error occurred.",
                    STATUS = false
                };
            }
        }

        public async Task<RETURN_MESSAGE> UpdateIncidentStatus(UPDATE_INCIDENT_STATUS updateIncidentStatus)
        {
            if (updateIncidentStatus == null)
                throw new ArgumentNullException(nameof(updateIncidentStatus), "UpdateIncidentStatus object cannot be null.");
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var updateStatusParam = new
                    {
                        INC_ID = updateIncidentStatus.INC_ID,
                        INC_STATUS = updateIncidentStatus.INC_STATUS,
                        REPORTER_BY = updateIncidentStatus.REPORTER_BY
                    };
                    const string updateStatusProc = "USP_UPDATE_STATUS_INCIDENT_DETAILS";
                    const string getEmpDesignationProc = "USP_GET_EMP_DESIGNATION_EMPID";
                    const string addNotificationProc = "USP_ADD_BELL_NOTIFICATION_COMMON";
                    var updateResultTask = con.QueryAsync<RETURN_MESSAGE>(updateStatusProc, updateStatusParam, commandType: CommandType.StoredProcedure);
                    var updateResult = (await updateResultTask).SingleOrDefault();

                    if (updateResult == null)
                    {
                        throw new InvalidOperationException("Failed to update incident status.");
                    }

                    if (updateIncidentStatus.REPORTER_BY != null)
                    {
                        var empParam = new { EMP_ID = updateIncidentStatus.REPORTER_BY };
                        var empDesignationTask = con.QueryAsync<GET_DESIGNATION_EMPID>(getEmpDesignationProc, empParam, commandType: CommandType.StoredProcedure);
                        var empDesignation = (await empDesignationTask).SingleOrDefault();

                        if (empDesignation == null)
                            throw new InvalidOperationException("Failed to fetch employee designation.");

                        var notificationParams = new DynamicParameters();
                        notificationParams.Add("@ANS_CONTENT_TITLE", "Emergency Preparedness");
                        notificationParams.Add("@ANS_CONTENT_TITLE_AR", "التأهب للطوارئ");
                        notificationParams.Add("@EMP_ID", updateIncidentStatus.REPORTER_BY);
                        notificationParams.Add("@HYPER_LINK", "Emergency/IncidentDetails?LanguageAbbrevation=");
                        notificationParams.Add("@ANS_NOTIFICATIONTYPE", "2");

                        switch (updateIncidentStatus.INC_STATUS)
                        {
                            case "2": // Incident Closed
                                notificationParams.Add("@DESIGNATION", "HSSE Team");
                                notificationParams.Add("@ANS_CONTENT_TITLE_DISCRIPTION", "Incident Closed");
                                notificationParams.Add("@ANS_CONTENT_TITLE_DISCRIPTION_AR", "تم إغلاق الحادث");
                                break;

                            case "7": // Investigation Completed
                                notificationParams.Add("@DESIGNATION", "HSSE Manager");
                                notificationParams.Add("@ANS_CONTENT_TITLE_DISCRIPTION", "Investigation Completed");
                                notificationParams.Add("@ANS_CONTENT_TITLE_DISCRIPTION_AR", "اكتمل التحقيق");
                                break;

                            case "3": // Custom Designation
                                notificationParams.Add("@DESIGNATION", empDesignation.DESI_NAME_EN);
                                notificationParams.Add("@ANS_CONTENT_TITLE_DISCRIPTION", "Investigation Completed");
                                notificationParams.Add("@ANS_CONTENT_TITLE_DISCRIPTION_AR", "اكتمل التحقيق");
                                break;

                            default: // Investigation Pending
                                notificationParams.Add("@DESIGNATION", "HSSE Team");
                                notificationParams.Add("@ANS_CONTENT_TITLE_DISCRIPTION", "Investigation Pending");
                                notificationParams.Add("@ANS_CONTENT_TITLE_DISCRIPTION_AR", "التحقيق معلق");
                                notificationParams.Add("@HYPER_LINK", "Investigation/IncidentIvestigation?LanguageAbbrevation=");
                                break;
                        }
                        var notificationResultTask = con.QueryAsync<RETURN_MESSAGE>(addNotificationProc, notificationParams, commandType: CommandType.StoredProcedure);
                        await notificationResultTask;
                    }
                    return updateResult;
                }
            }
            catch (Exception ex)
            {
                return new RETURN_MESSAGE
                {
                    MESSAGE = "Internal Server Error occurred.",
                    STATUS = "false"
                };
            }
        }


        #endregion

        #region [INCIDENT INVESTIGATION]
        public async Task<List<GET_INCIDENT_DETAILS>> GetInvestigationList(string INC_STATUS_ID, string EMP_LOGIN_ID, string DESI_NAME)
        {
            try
            {
                string query = "USP_GET_INCIDENT_INVESTIGATION_DETAILS";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@INC_STATUS", INC_STATUS_ID);
                    parameters.Add("@EMP_LOGIN_ID", EMP_LOGIN_ID);
                    parameters.Add("@DESI_NAME", DESI_NAME);

                    var objUserList = await connection.QueryAsync<GET_INCIDENT_DETAILS>(
                        query,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);

                    Console.WriteLine($"Fetched Records Count: {objUserList.Count()}");

                    return objUserList.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IReadOnlyList<GET_EMPLOYEE_DETAILS_REPORTABLE>> GetReporterBy()
        {
            try
            {
                string procedure = "USP_GET_REPORTER_BY_EMPLOYEE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_EMPLOYEE_DETAILS_REPORTABLE>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetemrINCDTCAdetails";
                throw;
            }
        }

        #endregion

        #region [EHS INCIDENT ALERT]
        public async Task<List<GET_INCIDENT_DETAILS>> GetEHSAlertIncident()
        {
            try
            {
                string query = "USP_GET_EHS_ALERT_INCIDENT_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_INCIDENT_DETAILS>(query, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEHSAlertIncident";
                throw;
            }
        }
        #endregion

        #region [Corrective Invest]
        public async Task<List<GET_INVE_CORRECTIVE_ACTION>> GetCorrectiveInvestList(string LOGIN_ID, string DESIG_NAME)
        {
            try
            {
                string query = "USP_GET_INVE_CORRECTION_ACTION";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@LOGIN_ID", LOGIN_ID);
                    parameters.Add("@DESIG_NAME", DESIG_NAME);
                    var objUserList = await connection.QueryAsync<GET_INVE_CORRECTIVE_ACTION>(
                        query,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);
                    Console.WriteLine($"Fetched Records Count: {objUserList.Count()}");
                    return objUserList.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region [InvestigationForm]

        public async Task<IReadOnlyList<GET_EMR_NATURE_INJURY_DETAILS>> GetEMRNIIDetails()
        {
            try
            {
                string procedure = "USP_GET_EMR_NII_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_EMR_NATURE_INJURY_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRNIIDetails";
                throw;
            }
        }

        public async Task<IReadOnlyList<GET_EMR_MECH_INJURY_DETAILS>> GetEMRMIIDetails()
        {
            try
            {
                string procedure = "USP_GET_EMR_MII_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_EMR_MECH_INJURY_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRMIIDetails";
                throw;
            }
        }

        public async Task<IReadOnlyList<GET_EMR_AGENCY_INJURY_DETAILS>> GetEMRAIIDetails()
        {
            try
            {
                string procedure = "USP_GET_EMR_AII_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_EMR_AGENCY_INJURY_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRAIIDetails";
                throw;
            }
        }

        public async Task<IReadOnlyList<GET_EMR_BODY_LOC_CAT_DETAILS>> GetemrBODYLOCCATdetails()
        {
            try
            {
                string procedure = "USP_GET_EMR_BODY_LOC_CAT_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_EMR_BODY_LOC_CAT_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetemrBODYLOCCATdetails";
                throw;
            }
        }

        public async Task<IReadOnlyList<GET_EMR_IC_ACT_DETAILS>> GetEMRICActDetails()
        {
            try
            {
                string procedure = "USP_GET_EMR_IC_ACT_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_EMR_IC_ACT_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRICActDetails";
                throw;
            }
        }

        public async Task<IReadOnlyList<GET_EMR_IC_UC_DETAILS>> GetEMRICUCDetails()
        {
            try
            {
                string procedure = "USP_GET_EMR_IC_UC_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_EMR_IC_UC_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRICUCDetails";
                throw;
            }
        }

        public async Task<IReadOnlyList<GET_EMR_RC_PF_DETAILS>> GetEMRRCPFDetails()
        {
            try
            {
                string procedure = "USP_GET_EMR_RC_PF_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_EMR_RC_PF_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRRCPFDetails";
                throw;
            }
        }

        public async Task<IReadOnlyList<GET_EMR_RC_SF_DETAILS>> GetEMRRCSFDetails()
        {
            try
            {
                string procedure = "USP_GET_EMR_RC_SF_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_EMR_RC_SF_DETAILS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetEMRRCPFDetails";
                throw;
            }
        }
        #endregion

        #region [ADD_INVESTIGATION]
        public async Task<RETURN_MESSAGE> ADD_INVESTIGATION(INVESTCATION_DETAILS investigationDetails)
        {
            try
            {
                await using var con = await GetConnectionAsync();
                await con.ExecuteAsync("USP_ADD_INVE_IM_CASUSE_ACT", investigationDetails.INVE_IM_CASUE_ACT, commandType: CommandType.StoredProcedure);
                await con.ExecuteAsync("USP_ADD_INVE_IM_CASUSE_UNC", investigationDetails.INVE_IM_CASUE_UNC, commandType: CommandType.StoredProcedure);
                await con.ExecuteAsync("USP_ADD_INVE_ROOT_PF_CAUSE", investigationDetails.INVE_IM_ROOT_PF, commandType: CommandType.StoredProcedure);
                await con.ExecuteAsync("USP_ADD_INVE_ROOT_SF_CAUSE", investigationDetails.INVE_IM_ROOT_SF, commandType: CommandType.StoredProcedure);
                if (investigationDetails.INVE_IM_ROOT_METHOD != null)
                    await con.ExecuteAsync("USP_ADD_INVE_IM_METHOD", investigationDetails.INVE_IM_ROOT_METHOD, commandType: CommandType.StoredProcedure);
                if (investigationDetails.INVE_IM_ROOT_ENIV != null)
                    await con.ExecuteAsync("USP_ADD_INVE_IM_ENVI", investigationDetails.INVE_IM_ROOT_ENIV, commandType: CommandType.StoredProcedure);
                if (investigationDetails.INVE_IM_ROOT_MATERIAL != null)
                    await con.ExecuteAsync("USP_ADD_INVE_IM_MATERIAL", investigationDetails.INVE_IM_ROOT_MATERIAL, commandType: CommandType.StoredProcedure);
                if (investigationDetails.INVE_NATURE_OF_INJURY != null)
                    await con.ExecuteAsync("USP_ADD_INVE_NATURE_INJURY_CAUSE", investigationDetails.INVE_NATURE_OF_INJURY, commandType: CommandType.StoredProcedure);
                if (investigationDetails.INVE_MECHANISM_OF_INJURY != null)
                    await con.ExecuteAsync("USP_ADD_INVE_MECH_INJURY_CAUSE", investigationDetails.INVE_MECHANISM_OF_INJURY, commandType: CommandType.StoredProcedure);
                if (investigationDetails.INVE_SOURCE_OF_INJURY != null)
                    await con.ExecuteAsync("USP_ADD_INVE_SOURCE_INJURY_CAUSE", investigationDetails.INVE_SOURCE_OF_INJURY, commandType: CommandType.StoredProcedure);
                if (investigationDetails.INVE_BODY_LOC_CASUE != null)
                    await con.ExecuteAsync("USP_ADD_INVE_BODY_LOC_CAUSE", investigationDetails.INVE_BODY_LOC_CASUE, commandType: CommandType.StoredProcedure);
                await con.ExecuteAsync("USP_ADD_INVE_ACTION_TAKEN_IMMEDIATELY", investigationDetails.ACTION_TAKEN_IMMEDIATELY, commandType: CommandType.StoredProcedure);
                await con.ExecuteAsync("USP_ADD_INVE_INCIDENT_ROOT_CAUSE", investigationDetails.INCIDENT_ROOT_CAUSE, commandType: CommandType.StoredProcedure);
                await con.ExecuteAsync("USP_ADD_INVE_CORRECTIVE_ACTION", investigationDetails.CORRECTIVE_ACTION, commandType: CommandType.StoredProcedure);
                await con.ExecuteAsync("USP_ADD_INVE_INCIDENT_COST_ANALYSIS", investigationDetails.INCIDENT_COST_ANALYSIS, commandType: CommandType.StoredProcedure);
                if (investigationDetails.INJURED_PERSONAL_DETAILS != null)
                    await con.ExecuteAsync("USP_ADD_INVE_INJURED_PERSONAL_DETAILS", investigationDetails.INJURED_PERSONAL_DETAILS, commandType: CommandType.StoredProcedure);
                if (investigationDetails.DECLARATION_INJURED_PERSON != null)
                    await con.ExecuteAsync("USP_ADD_INVE_DECLARATION_INJURED_PERSON", investigationDetails.DECLARATION_INJURED_PERSON, commandType: CommandType.StoredProcedure);
                if (investigationDetails.MEDICAL_REPORT != null)
                    await con.ExecuteAsync("USP_ADD_INVE_MEDICAL_REPORT", investigationDetails.MEDICAL_REPORT, commandType: CommandType.StoredProcedure);
                await con.ExecuteAsync("USP_ADD_INVE_SEQUENCE_EVENT", investigationDetails.INVE_SEQUENCE_EVENT, commandType: CommandType.StoredProcedure);
                await con.ExecuteAsync("USP_ADD_INVE_SITE_INSPECTION", investigationDetails.SITE_INSPECTION, commandType: CommandType.StoredProcedure);
                await con.ExecuteAsync("USP_ADD_INVE_INTERVIEW_DETAILS", investigationDetails.INTERVIEW_DETAILS, commandType: CommandType.StoredProcedure);
                await con.ExecuteAsync("USP_ADD_INVE_NEW_SITE_INSPECTION", investigationDetails.NEW_SITE_INSPECTION, commandType: CommandType.StoredProcedure);
                var incId = investigationDetails.INTERVIEW_DETAILS.FirstOrDefault()?.INC_ID;
                var createdBy = investigationDetails.INTERVIEW_DETAILS.FirstOrDefault()?.CREATED_BY;
                if (incId != null && createdBy != null)
                {
                    var paramStatus = new DynamicParameters();
                    paramStatus.Add("@INC_ID", incId);
                    paramStatus.Add("@INC_STATUS", "4");
                    paramStatus.Add("@REPORTER_BY", createdBy);
                    await con.ExecuteAsync("USP_UPDATE_STATUS_INCIDENT_DETAILS", paramStatus, commandType: CommandType.StoredProcedure);
                }
                var paramBell = new DynamicParameters();
                paramBell.Add("@ANS_CONTENT_TITLE", "Emergency Preparedness");
                paramBell.Add("@ANS_CONTENT_TITLE_AR", "التأهب للطوارئ");
                paramBell.Add("@EMP_ID", "");
                paramBell.Add("@DESIGNATION", "HSSE Manager");
                paramBell.Add("@ANS_CONTENT_TITLE_DISCRIPTION", "INVESTIGATION APPROVAL PENDING");
                paramBell.Add("@ANS_CONTENT_TITLE_DISCRIPTION_AR", "قيد الموافقة على التحقيق");
                paramBell.Add("@HYPER_LINK", "Investigation/IncidentIvestigation?LanguageAbbrevation=");
                paramBell.Add("@ANS_NOTIFICATIONTYPE", "2");
                await con.ExecuteAsync("USP_ADD_BELL_NOTIFICATION_COMMON", paramBell, commandType: CommandType.StoredProcedure);
                return new RETURN_MESSAGE
                {
                    STATUS_CODE = "200",
                    STATUS = "true",
                    MESSAGE = "Incident Investigation Added Successful"
                };
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the investigation.", ex);
            }
        }
        #endregion

        #region [ADD_SITE_PHOTO_UPLOAD]
        public async Task<RETURN_MESSAGE> AddSitePhotoUpload(List<SITE_INSPECTION_PHOTO_LIST> siteInspectionPhotoList)
        {
            try
            {
                await using var con = await GetConnectionAsync();
                await con.ExecuteAsync("USP_ADD_SITE_INSP_PHOTOS", siteInspectionPhotoList, commandType: CommandType.StoredProcedure);

                return new RETURN_MESSAGE
                {
                    STATUS_CODE = "200",
                    MESSAGE = "Photo Added Successfully"
                };
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while uploading the site photos.", ex);
            }
        }
        #endregion

        #region [VIEW_INVESTIGATION_DETAILS]

        public async Task<GET_EMR_INCDT_CA_DETAILS> GET_VIEW_INVE_REVIEW_AND_APPROVALS(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_REVIEW_AND_APPROVALS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_INCDT_CA_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_VIEW_INVE_REVIEW_AND_APPROVALS";
                throw;
            }
        }

        public async Task<GET_INVE_EHS_ALERT> GetAlertList(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_EHS_ALERT";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_INVE_EHS_ALERT>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GetAlertList";
                throw;
            }
        }

        public async Task<GET_EMR_IC_ACT_DETAILS> GET_INVE_IM_CASUSE_ACT(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_IM_CASUSE_ACT";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_IC_ACT_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_INVE_IM_CASUSE_ACT";
                throw;
            }
        }

        public async Task<GET_EMR_IC_UC_DETAILS> GET_INVE_IM_UC_LIST(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_IM_CASUSE_UNC";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_IC_UC_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_INVE_IM_UC_LIST";
                throw;
            }
        }

        public async Task<GET_EMR_RC_PF_DETAILS> GET_INVE_ROOT_PF_LIST(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_ROOT_PF_CAUSE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_RC_PF_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_INVE_ROOT_PF_LIST";
                throw;
            }
        }

        public async Task<GET_EMR_RC_SF_DETAILS> GET_INVE_ROOT_SF_LIST(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_ROOT_SF_CAUSE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_RC_SF_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_INVE_ROOT_SF_LIST";
                throw;
            }
        }

        public async Task<GET_VIEW_INVE_IM_METHOD> GET_INVE_IM_METHOD(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_IM_METHOD";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_VIEW_INVE_IM_METHOD>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_INVE_IM_METHOD";
                throw;
            }
        }

        public async Task<GET_VIEW_INVE_IM_ENVIRONMENT> GET_INVE_IM_ENVI(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_IM_ENVIRONMENT";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_VIEW_INVE_IM_ENVIRONMENT>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_INVE_IM_ENVI";
                throw;
            }
        }

        public async Task<GET_VIEW_INVE_IM_MATERIAL> GET_INVE_IM_MATERIAL(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_IM_MATERIAL";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_VIEW_INVE_IM_MATERIAL>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_INVE_IM_MATERIAL";
                throw;
            }
        }

        public async Task<GET_EMR_NATURE_INJURY_DETAILS> GET_INVE_NATUREOFINJURY_LIST(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_NATURE_INJURY_CAUSE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_NATURE_INJURY_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_INVE_NATUREOFINJURY_LIST";
                throw;
            }
        }

        public async Task<GET_EMR_MECH_INJURY_DETAILS> GET_INVE_MECHANISMOFINJURY_LIST(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_MECH_INJURY_CAUSE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_MECH_INJURY_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_INVE_MECHANISMOFINJURY_LIST";
                throw;
            }
        }

        public async Task<GET_EMR_AGENCY_INJURY_DETAILS> GET_INVE_SOURCEOFINJURY_LIST(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_SOURCE_INJURY_CAUSE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_AGENCY_INJURY_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_INVE_SOURCEOFINJURY_LIST";
                throw;
            }
        }

        public async Task<GET_EMR_BODY_LOC_DETAILS> GET_INVE_BODYLOCATION_LIST(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_BODY_LOC_CAUSE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_BODY_LOC_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_INVE_BODYLOCATION_LIST";
                throw;
            }
        }

        public async Task<GET_EMR_INCDT_COST_ANALYSIS> GET_COST_ANALYSIS(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_INCIDENT_COST_ANALYSIS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_INCDT_COST_ANALYSIS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_COST_ANALYSIS";
                throw;
            }
        }


        public async Task<ACTION_TAKEN_IMMEDIATELY> GET_VIEW_ACTION_TAKEN(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_ACTION_TAKEN_IM";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<ACTION_TAKEN_IMMEDIATELY>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_VIEW_ACTION_TAKEN";
                throw;
            }
        }

        public async Task<INCIDENT_ROOT_CAUSE> GET_VIEW_INCIDENT_ROOT_CAUSE(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_INCIDENT_ROOT_CAUSE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<INCIDENT_ROOT_CAUSE>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_VIEW_INCIDENT_ROOT_CAUSE";
                throw;
            }
        }

        public async Task<CORRECTIVE_ACTION> GET_VIEW_CORRECTIVE_ACTION(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_CORRECTIVE_ACTION";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<CORRECTIVE_ACTION>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_VIEW_CORRECTIVE_ACTION";
                throw;
            }
        }


        public async Task<INJURED_PERSONAL_DETAILS> VIEW_INJURED_PERSON_DETAILS(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INJURED_PERSON_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<INJURED_PERSONAL_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "VIEW_INJURED_PERSON_DETAILS";
                throw;
            }
        }

        public async Task<MEDICAL_REPORT> GET_MEDICAL_REPORT(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_MEDICAL_REPORT";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<MEDICAL_REPORT>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_MEDICAL_REPORT";
                throw;
            }
        }

        public async Task<GET_EMR_SEQUENCE_EVENT> GET_VIEW_INVE_SEQUENCE_EVENT_LIST(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_SEQUENCE_EVENT";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_SEQUENCE_EVENT>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_VIEW_INVE_SEQUENCE_EVENT_LIST";
                throw;
            }
        }

        public async Task<GET_EMR_INTERVIEW_DETAILS> GET_VIEW_INVE_INTERVIEW_DETAILS(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_INTERVIEW_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_INTERVIEW_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_VIEW_INVE_INTERVIEW_DETAILS";
                throw;
            }
        }

        public async Task<GET_EMR_DOCUMENT_DETAILS> GET_VIEW_INVE_DOCUMENT_DETAILS(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_DOCUMENT_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_DOCUMENT_DETAILS>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_VIEW_INVE_DOCUMENT_DETAILS";
                throw;
            }
        }

        public async Task<GET_EMR_NEW_SITE_INSPECTION> GET_VIEW_INVE_NEW_SITE_INSPECTION(string INC_ID)
        {
            try
            {
                string procedure = "USP_VIEW_INVE_NEW_SITE_INSPECTION";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        INC_ID = INC_ID
                    };
                    return (await connection.QueryAsync<GET_EMR_NEW_SITE_INSPECTION>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string repo = "GET_VIEW_INVE_NEW_SITE_INSPECTION";
                throw;
            }
        }
        #endregion
    }
}
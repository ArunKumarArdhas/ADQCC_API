

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
    public class RiskManagementRepository : IRiskManagementRepository
    {
        private readonly IConfiguration configuration;
        RETURN_MESSAGE message;
        public RiskManagementRepository(IConfiguration configuration, RETURN_MESSAGE message)
        {
            this.configuration = configuration;
            this.message = message;
        }

        #region [HAZARD MASTER]
        //get
        public async Task<IReadOnlyList<GET_RM_HAZARD_MASTER>> GETRMHAZARDMASREPO()
        {

            try
            {
                string procedure = "[USP_RM_GET_HAZARD_MAS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RM_HAZARD_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GETRMHAZARDMASREPO";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //GET BY ID --- HAZARD MASTER
        public async Task<GET_RM_HAZARD_MASTER> GETEDITRMHAZARDMASREPO(GET_RM_HAZARD_MASTER model)
        {
            try
            {

                var query = "USP_RM_EDIT_HAZARD_MAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        HAZARD_MAS_ID = model.HAZARD_MAS_ID

                    };
                    return (await connection.QueryAsync<GET_RM_HAZARD_MASTER>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //HAZARD---- ADD

        public async Task<RETURN_MESSAGE> ADDRMHAZARDMASREPO(ADD_RM_HAZARD_MASTER _ADDRMHAZARDMASTER)
        {
            try
            {
                var query = "[USP_RM_ADD_HAZARD_MAS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        HAZARD_MAS_ID = _ADDRMHAZARDMASTER.HAZARD_MAS_ID,
                        HAZ_RISK_CAT_MAS_ID = _ADDRMHAZARDMASTER.HAZ_RISK_CAT_MAS_ID,
                        HAZARD_MAS_NAME = _ADDRMHAZARDMASTER.HAZARD_MAS_NAME,
                        HAZARD_MAS_NAME_AR = _ADDRMHAZARDMASTER.HAZARD_MAS_NAME_AR,
                        STATUS = _ADDRMHAZARDMASTER.STATUS
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

        #region[RISKS_OTHER_RISKS]
        //get
        public async Task<IReadOnlyList<GET_RM_RISKS_OTHER_RISKS>> GETHAZARDSELECTREPO()
        {

            try
            {
                string procedure = "[USP_RM_GET_RISKS_OTHER_RISKS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RM_RISKS_OTHER_RISKS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GETHAZARDSELECTREPO";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //GET BY ID --- RISKS_OTHER_RISKS
        public async Task<GET_RM_RISKS_OTHER_RISKS> GETBYIDRISKREPO(GET_RM_RISKS_OTHER_RISKS RISKS_OTHER_RISKS_ID)
        {
            try
            {

                var query = "USP_RM_EDIT_RISKS_OTHER_RISKS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        RISKS_OTHER_RISKS_ID = RISKS_OTHER_RISKS_ID.RISKS_OTHER_RISKS_ID

                    };
                    return (await connection.QueryAsync<GET_RM_RISKS_OTHER_RISKS>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //add
        public async Task<RETURN_MESSAGE> ADDRMRISKOTHERRISKREPO(ADD_RM_RISKS_OTHER_RISKS _ADDRMRISKOTHERRISK)
        {
            try
            {
                var query = "[USP_RM_ADD_RISKS_OTHER_RISKS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        RISKS_OTHER_RISKS_ID = _ADDRMRISKOTHERRISK.RISKS_OTHER_RISKS_ID,
                        RISK_CAT_MAS_ID = _ADDRMRISKOTHERRISK.RISK_CAT_MAS_ID,
                        RISKS_HAZARD_MAS_ID = _ADDRMRISKOTHERRISK.RISKS_HAZARD_MAS_ID,
                        RISKS_OTHER_RISKS_NAME = _ADDRMRISKOTHERRISK.RISKS_OTHER_RISKS_NAME,
                        RISKS_OTHER_RISKS_NAME_AR = _ADDRMRISKOTHERRISK.RISKS_OTHER_RISKS_NAME_AR,
                        STATUS = _ADDRMRISKOTHERRISK.STATUS

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

        #region [Risk Category Master]
       //get
        public async Task<IReadOnlyList<GET_RM_RISK_CAT_MASTER>> GETRMRISKCATMAS()
        {

            try
            {
                string procedure = "[USP_RM_GET_RISK_CAT_MAS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RM_RISK_CAT_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GETRMRISKCATMAS";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //GET BY ID --
        public async Task<GET_RM_RISK_CAT_MASTER> GETBYIDRISKCATMAS(GET_RM_RISK_CAT_MASTER RISK_CAT_MAS_ID)
        {
            try
            {

                var query = "USP_RM_EDIT_RISK_CAT_MAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        RISK_CAT_MAS_ID = RISK_CAT_MAS_ID.RISK_CAT_MAS_ID

                    };
                    return (await connection.QueryAsync<GET_RM_RISK_CAT_MASTER>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ADD
        public async Task<RETURN_MESSAGE> ADDRMRISKCATMAS(ADD_RM_RISK_CAT_MASTER _ADDRMRISKCATMASTER)
        {
            try
            {
                var query = "[USP_RM_ADD_RISK_CAT_MAS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        RISK_CAT_MAS_ID = _ADDRMRISKCATMASTER.RISK_CAT_MAS_ID,
                        RISK_CAT_MAS_NAME = _ADDRMRISKCATMASTER.RISK_CAT_MAS_NAME,
                        RISK_CAT_MAS_NAME_AR = _ADDRMRISKCATMASTER.RISK_CAT_MAS_NAME_AR,
                        STATUS = _ADDRMRISKCATMASTER.STATUS

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


        #region[PERSONS_GROUPS]
        //PERSON GET
        public async Task<IReadOnlyList<GET_RM_PERSONS_GROUPS>> GETRMPERSONSGROUPSREPO()
        {

            try
            {
                string procedure = "[USP_RM_GET_PERSONS_GROUPS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RM_PERSONS_GROUPS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GETRMPERSONSGROUPSREPO";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //GET BY ID --- person group
        public async Task<GET_RM_PERSONS_GROUPS> GETEDITRMPERSONSGROUPSREPO(GET_RM_PERSONS_GROUPS PERSON_GROUP_ID)
        {
            try
            {

                var query = "USP_RM_EDIT_PERSONS_GROUPS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        PERSON_GROUP_ID = PERSON_GROUP_ID.PERSON_GROUP_ID

                    };
                    return (await connection.QueryAsync<GET_RM_PERSONS_GROUPS>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //PERSON ADD
        public async Task<RETURN_MESSAGE> ADDRMPERSONSGROUPSREPO(ADD_RM_PERSONS_GROUPS _ADDRMPERSONSGROUPS)
        {
            try
            {
                var query = "[USP_RM_ADD_PERSONS_GROUPS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        PERSON_GROUP_ID = _ADDRMPERSONSGROUPS.PERSON_GROUP_ID,
                        RISK_CAT_MAS_ID = _ADDRMPERSONSGROUPS.RISK_CAT_MAS_ID,
                        PG_HAZARD_MAS_ID = _ADDRMPERSONSGROUPS.PG_HAZARD_MAS_ID,
                        PERSON_GROUP_NAME = _ADDRMPERSONSGROUPS.PERSON_GROUP_NAME,
                        PERSON_GROUP_NAME_AR = _ADDRMPERSONSGROUPS.PERSON_GROUP_NAME_AR,
                        STATUS = _ADDRMPERSONSGROUPS.STATUS



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

        #region [Details of any Existing Controls]
        //Details of any Existing Controls  ---   GET
        public async Task<IReadOnlyList<GET_RM_DETAILS_EXIST_CONT>> GETDECREPO()
        {

            try
            {
                string procedure = "[USP_RM_GET_DETAILS_EXIST_CONT]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RM_DETAILS_EXIST_CONT>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GETDECREPO";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //GET BY ID --- details exist
        public async Task<GET_RM_DETAILS_EXIST_CONT> GETEDITDECREPO(GET_RM_DETAILS_EXIST_CONT DETAILS_EXIST_CONT_ID)
        {
            try
            {

                var query = "USP_RM_EDIT_DETAILS_EXIST_CONT";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        DETAILS_EXIST_CONT_ID = DETAILS_EXIST_CONT_ID.DETAILS_EXIST_CONT_ID

                    };
                    return (await connection.QueryAsync<GET_RM_DETAILS_EXIST_CONT>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //PERSON ADD
        public async Task<RETURN_MESSAGE> ADDDECREPO(ADD_RM_DETAILS_EXIST_CONT _ADDDEC)
        {
            try
            {
                var query = "[USP_RM_ADD_DETAILS_EXIST_CONT]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        DETAILS_EXIST_CONT_ID = _ADDDEC.DETAILS_EXIST_CONT_ID,
                        RISK_CAT_MAS_ID = _ADDDEC.RISK_CAT_MAS_ID,
                        DEC_HAZARD_MAS_ID = _ADDDEC.DEC_HAZARD_MAS_ID,
                        DETAILS_EXIST_CONT_NAME = _ADDDEC.DETAILS_EXIST_CONT_NAME,
                        DETAILS_EXIST_CONT_NAME_AR = _ADDDEC.DETAILS_EXIST_CONT_NAME_AR,
                        STATUS = _ADDDEC.STATUS


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

        #region [Additional Control Measures]
        //get
        public async Task<IReadOnlyList<GET_RM_ADD_CONT_MEAS>> GETADDTCONTMEASREPO()
        {

            try
            {
                string procedure = "[USP_RM_GET_ADDT_CONT_MEAS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RM_ADD_CONT_MEAS>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GETADDTCONTMEASREPO";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //GET BY ID --- addition control measures
        public async Task<GET_RM_ADD_CONT_MEAS> GETEDITADDCONTMEASREPO(GET_RM_ADD_CONT_MEAS ADD_CONT_MEAS_ID)
        {
            try
            {

                var query = "USP_RM_EDIT_ADDT_CONT_MEAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        ADD_CONT_MEAS_ID = ADD_CONT_MEAS_ID.ADD_CONT_MEAS_ID

                    };
                    return (await connection.QueryAsync<GET_RM_ADD_CONT_MEAS>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // ADD
        public async Task<RETURN_MESSAGE> ADDCONTMEASREPO(ADD_RM_ADD_CONT_MEAS _ADDCONTMEAS)
        {
            try
            {
                var query = "[USP_RM_ADD_ADDT_CONT_MEAS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        ADD_CONT_MEAS_ID = _ADDCONTMEAS.ADD_CONT_MEAS_ID,
                        RISK_CAT_MAS_ID = _ADDCONTMEAS.RISK_CAT_MAS_ID,
                        ACM_HAZARD_MAS_ID = _ADDCONTMEAS.ACM_HAZARD_MAS_ID,
                        ADD_CONT_MEAS_NAME = _ADDCONTMEAS.ADD_CONT_MEAS_NAME,
                        ADD_CONT_MEAS_NAME_AR = _ADDCONTMEAS.ADD_CONT_MEAS_NAME_AR,
                        STATUS = _ADDCONTMEAS.STATUS
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

        #region [Opportunities and other opportunities]

        //get

        public async Task<IReadOnlyList<GET_RM_OPPORTUNITIES>> GETOPPORTUNITIESREPO()
        {

            try
            {
                string procedure = "[USP_RM_GET_OPPORTUNITIES]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RM_OPPORTUNITIES>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GETOPPORTUNITIESREPO";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //GET BY ID --- addition control measures
        public async Task<GET_RM_OPPORTUNITIES> GETEDITOPPORTUNITIESREPO(GET_RM_OPPORTUNITIES OPPORTUNITIES_ID)
        {
            try
            {

                var query = "USP_RM_EDIT_OPPORTUNITIES";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        OPPORTUNITIES_ID = OPPORTUNITIES_ID.OPPORTUNITIES_ID

                    };
                    return (await connection.QueryAsync<GET_RM_OPPORTUNITIES>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ADD
        public async Task<RETURN_MESSAGE> ADDOPPORTUNITIESREPO(ADD_RM_OPPORTUNITIES _ADDOPPORTUNITIES)
        {
            try
            {
                var query = "[USP_RM_ADD_OPPORTUNITIES]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        OPPORTUNITIES_ID = _ADDOPPORTUNITIES.OPPORTUNITIES_ID,
                        RISK_CAT_MAS_ID = _ADDOPPORTUNITIES.RISK_CAT_MAS_ID,
                        OPTY_HAZARD_MAS_ID = _ADDOPPORTUNITIES.OPTY_HAZARD_MAS_ID,
                        OPPORTUNITIES_NAME = _ADDOPPORTUNITIES.OPPORTUNITIES_NAME,
                        OPPORTUNITIES_NAME_AR = _ADDOPPORTUNITIES.OPPORTUNITIES_NAME_AR,
                        STATUS = _ADDOPPORTUNITIES.STATUS
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

        #region [Critical Hazard Master]

        //get

        public async Task<IReadOnlyList<GET_RM_CRIT_HAZARD_MASTER>> GETRMCRITHAZARDMASREPO()
        {

            try
            {
                string procedure = "[USP_RM_GET_CRIT_HAZARD_MAS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RM_CRIT_HAZARD_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GETRMCRITHAZARDMASREPO";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //get by id
        public async Task<GET_RM_CRIT_HAZARD_MASTER> GETEDITRMCRITHAZARDMASREPO(GET_RM_CRIT_HAZARD_MASTER CRIT_HAZARD_MAS_ID)
        {
            try
            {
                string procedure = "[USP_RM_EDIT_CRIT_HAZARD_MAS]"; ;
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CRIT_HAZARD_MAS_ID = CRIT_HAZARD_MAS_ID.CRIT_HAZARD_MAS_ID
                    };

                    return (await connection.QueryAsync<GET_RM_CRIT_HAZARD_MASTER>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetByIdRiskBCM";
                throw;
            }
        }

        // ADD
        public async Task<RETURN_MESSAGE> ADDRMCRITHAZARDMASREPO(ADD_RM_CRIT_HAZARD_MASTER _ADDRMCRITHAZARDMASTER)
        {
            try
            {
                var query = "[USP_RM_ADD_CRIT_HAZARD_MAS]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        CRIT_HAZARD_MAS_ID = _ADDRMCRITHAZARDMASTER.CRIT_HAZARD_MAS_ID,
                        CRIT_HAZARD_MAS_NAME = _ADDRMCRITHAZARDMASTER.CRIT_HAZARD_MAS_NAME,
                        CRIT_HAZARD_MAS_NAME_AR = _ADDRMCRITHAZARDMASTER.CRIT_HAZARD_MAS_NAME_AR,
                        RISK_CAT_MAS_ID = _ADDRMCRITHAZARDMASTER.RISK_CAT_MAS_ID,
                        STATUS = _ADDRMCRITHAZARDMASTER.STATUS
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


        //SAM
        #region [Risk Cover]
        //add
        public async Task<RETURN_MESSAGE> AddRiskBCM(ADD_RISK_COVER_BCM entity)
        {
            try
            {
                var query = "[USP_ADD_RM_COVER_BCM]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RM_COVER_ID = entity.RM_COVER_ID,
                        RM_CATEGORY_ID = entity.RM_CATEGORY_ID,
                        RM_COVER_NAME = entity.RM_COVER_NAME,
                        RM_COVER_NAME_AR = entity.RM_COVER_NAME_AR,
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

        //get by id
        public async Task<GET_RISK_COVER_BCM> GetByIdRiskBCM(GET_RISK_COVER_BCM RM_COVER_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_RM_COVER_BCM]"; ;
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RM_COVER_ID = RM_COVER_ID.RM_COVER_ID
                    };

                    return (await connection.QueryAsync<GET_RISK_COVER_BCM>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetByIdRiskBCM";
                throw;
            }
        }

        //get
        public async Task<IReadOnlyList<GET_RISK_COVER_BCM>> GetAll_RiskBCM()
        {
            try
            {
                string procedure = "[USP_GET_RM_COVER_BCM]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_RISK_COVER_BCM>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllRiskBCM";
                // ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [RISK_PROCESS_ACTIVITY_BCM]

        //add
        public async Task<RETURN_MESSAGE> AddRiskProcess(ADD_RISK_PROCESS_ACTIVITY_BCM entity)
        {
            try
            {
                var query = "[USP_ADD_RM_PROCESS_ACT_BCM]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RM_PROCESS_ACT_ID = entity.RM_PROCESS_ACT_ID,
                        RM_PROCESS_ACT_NAME = entity.RM_PROCESS_ACT_NAME,
                        RM_PROCESS_ACT_NAME_AR = entity.RM_PROCESS_ACT_NAME_AR,
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

        //get by id
        public async Task<GET_RISK_PROCESS_ACTIVITY_BCM> GetByIdRiskProcess(GET_RISK_PROCESS_ACTIVITY_BCM RM_PROCESS_ACT_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_RM_PROCESS_ACT_BCM]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RM_PROCESS_ACT_ID = RM_PROCESS_ACT_ID.RM_PROCESS_ACT_ID
                    };

                    return (await connection.QueryAsync<GET_RISK_PROCESS_ACTIVITY_BCM>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetByIdRiskProcess";
                throw;
            }
        }


        //get
        public async Task<IReadOnlyList<GET_RISK_PROCESS_ACTIVITY_BCM>> GetAll_RiskProcess()
        {
            try
            {
                string procedure = "[USP_GET_RM_PROCESS_ACT_BCM]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_RISK_PROCESS_ACTIVITY_BCM>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllRiskProcess";
                // ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [EXISTING_CONTROL]

        //add
        public async Task<RETURN_MESSAGE> AddRiskExistBCM(ADD_EXISTING_CONTROL_MASTER entity)
        {
            try
            {
                var query = "[USP_ADD_RM_EXIST_BCM]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RM_EXIST_CON_ID = entity.RM_EXIST_CON_ID,
                        RM_EXIST_CON_NAME = entity.RM_EXIST_CON_NAME,
                        RM_EXIST_CON_NAME_AR = entity.RM_EXIST_CON_NAME_AR,
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


        //get by id

        public async Task<GET_EXISTING_CONTROL_MASTER> GetByIdRiskExistBCM(GET_EXISTING_CONTROL_MASTER RM_EXIST_CON_ID)
        {
            try
            {
                string procedure = "[USP_EDIT_RM_EXIST_BCM]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RM_EXIST_CON_ID = RM_EXIST_CON_ID.RM_EXIST_CON_ID
                    };

                    return (await connection.QueryAsync<GET_EXISTING_CONTROL_MASTER>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetByIdRiskExistBCM";
                throw;
            }
        }




        //get
        public async Task<IReadOnlyList<GET_EXISTING_CONTROL_MASTER>> GetAll_ExistBCM()
        {
            try
            {
                string procedure = "[USP_GET_RM_EXIST_BCM]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_EXISTING_CONTROL_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllExistBCM";
                // ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [BCM TREATMENT]

        //add
        public async Task<RETURN_MESSAGE> AddRiskTreatment(ADD_TREATMENT_MASTER entity)
        {
            try
            {
                var query = "[USP_RM_ADD_RISK_TREATMENT]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RM_TREATMENT_ID = entity.RM_TREATMENT_ID,
                        RM_TREATMENT_NAME = entity.RM_TREATMENT_NAME,
                        RM_TREATMENT_NAME_AR = entity.RM_TREATMENT_NAME_AR,
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

        //get by id

        public async Task<GET_TREATMENT_MASTER> GetByIdRiskTreatment(GET_TREATMENT_MASTER RM_TREATMENT_ID)
        {
            try
            {
                string procedure = "[USP_RM_EDIT_RISK_TREATMENT]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        RM_TREATMENT_ID = RM_TREATMENT_ID.RM_TREATMENT_ID
                    };

                    return (await connection.QueryAsync<GET_TREATMENT_MASTER>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }

            }
            catch (Exception ex)
            {
                string repo = "GetByIdRiskTreatment";
                throw;
            }
        }


        //get
        public async Task<IReadOnlyList<GET_TREATMENT_MASTER>> GetAll_RiskTreatment()
        {
            try
            {
                string procedure = "[USP_RM_GET_RISK_TREATMENT]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<GET_TREATMENT_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllAsync";
                // ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        //THARA

        #region[Non Critical Hazard Master]

        //GET
        public async Task<IReadOnlyList<GET_RM_NON_CRIT_HAZ_MASTER>> GETRMNONCRITHAZMASREPO()
        {

            try
            {
                string procedure = "USP_RM_GET_NON_CRIT_HAZ_MAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RM_NON_CRIT_HAZ_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GETRMNONCRITHAZMASREPO";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //GET BY ID
        public async Task<ADD_RM_NON_CRIT_HAZ_MASTER> GETEDITRMNONCRITHAZMASREPO(ADD_RM_NON_CRIT_HAZ_MASTER model)
        {
            try
            {

                var query = "USP_RM_EDIT_NON_CRIT_HAZ_MAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        NON_CRIT_HAZ_MAS_ID = model.NON_CRIT_HAZ_MAS_ID

                    };
                    return (await connection.QueryAsync<ADD_RM_NON_CRIT_HAZ_MASTER>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //ADD
        public async Task<RETURN_MESSAGE> ADDRMNONCRITHAZMASREPO(ADD_RM_NON_CRIT_HAZ_MASTER entity)
        {
            try
            {
                var query = "USP_RM_ADD_NON_CRIT_HAZ_MAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        NON_CRIT_HAZ_MAS_ID = entity.NON_CRIT_HAZ_MAS_ID,
                        NON_CRIT_HAZ_MAS_NAME = entity.NON_CRIT_HAZ_MAS_NAME,
                        NON_CRIT_HAZ_MAS_NAME_AR = entity.NON_CRIT_HAZ_MAS_NAME_AR,
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

        #endregion

        #region[Non-Routine and Emergencies]
        public async Task<IReadOnlyList<GET_RM_NON_ROUT_EMERG_MASTER>> GETRMNONROUTEMERGMASREPO()
        {

            try
            {
                string procedure = "USP_RM_GET_NON_ROUT_EMERG_MAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RM_NON_ROUT_EMERG_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GETRMNONROUTEMERGMASREPO";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        //GET BY ID
        public async Task<ADD_RM_NON_ROUT_EMERG_MASTER> GETEDITRMNONROUTEMERGMASREPO(ADD_RM_NON_ROUT_EMERG_MASTER model)
        {
            try
            {

                var query = "USP_RM_EDIT_NON_ROUT_EMERG_MAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        NON_ROUT_EMERG_ID = model.NON_ROUT_EMERG_ID

                    };
                    return (await connection.QueryAsync<ADD_RM_NON_ROUT_EMERG_MASTER>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ADD
        public async Task<RETURN_MESSAGE> ADDRMNONROUTEMERGMASREPO(ADD_RM_NON_ROUT_EMERG_MASTER entity)
        {
            try
            {
                var query = "USP_RM_ADD_NON_ROUT_EMERG_MAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        NON_ROUT_EMERG_ID = entity.NON_ROUT_EMERG_ID,
                        NON_ROUT_EMERG_NAME = entity.NON_ROUT_EMERG_NAME,
                        NON_ROUT_EMERG_NAME_AR = entity.NON_ROUT_EMERG_NAME_AR,
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

        #endregion

        #region [Existing control measures for identified hazard]
        public async Task<IReadOnlyList<GET_RM_EXISTING_CMIH_MASTER>> GETRMEXISTINGCMIHMASREPO()
        {

            try
            {
                string procedure = "USP_RM_GET_EXISTING_CMIH_MAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RM_EXISTING_CMIH_MASTER>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GETRMEXISTINGCMIHMASREPO";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //GET BY ID
        public async Task<ADD_RM_EXISTING_CMIH_MASTER> GETEDITRMEXISTINGCMIHMASREPO(ADD_RM_EXISTING_CMIH_MASTER model)
        {
            try
            {

                var query = "USP_RM_EDIT_EXISTING_CMIH_MAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        EXISTING_CMIH_MAS_ID = model.EXISTING_CMIH_MAS_ID

                    };
                    return (await connection.QueryAsync<ADD_RM_EXISTING_CMIH_MASTER>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RETURN_MESSAGE> ADDRMEXISTINGCMIHMASREPO(ADD_RM_EXISTING_CMIH_MASTER entity)
        {
            try
            {
                var query = "USP_RM_ADD_EXISTING_CMIH_MAS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        EXISTING_CMIH_MAS_ID = entity.EXISTING_CMIH_MAS_ID,
                        EXISTING_CMIH_MAS_NAME = entity.EXISTING_CMIH_MAS_NAME,
                        EXISTING_CMIH_MAS_NAME_AR = entity.EXISTING_CMIH_MAS_NAME_AR,
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
        #endregion

        #region [RISK_CATEGORY_BCM]
        public async Task<IReadOnlyList<GET_RISK_CATEGORY_BCM>> GetRMCategory()
        {

            try
            {
                string procedure = "USP_GET_RM_CATEGORY_BCM";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<GET_RISK_CATEGORY_BCM>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetRMCategory";
                //ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //GET BY ID
        public async Task<ADD_RISK_CATEGORY_BCM> GetRM_CATEGORY_Edit(ADD_RISK_CATEGORY_BCM model)
        {
            try
            {

                var query = "USP_EDIT_RM_CATEGORY_BCM";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        RM_CATEGORY_ID = model.RM_CATEGORY_ID

                    };
                    return (await connection.QueryAsync<ADD_RISK_CATEGORY_BCM>(query, Paramater, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //ADD
        public async Task<RETURN_MESSAGE> AddRMCATEGORY(ADD_RISK_CATEGORY_BCM entity)
        {
            try
            {
                var query = "USP_ADD_RM_CATEGORY_BCM";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Paramater = new
                    {
                        RM_CATEGORY_ID = entity.RM_CATEGORY_ID,
                        RM_CATEGORY_NAME = entity.RM_CATEGORY_NAME,
                        RM_CATEGORY_NAME_AR = entity.RM_CATEGORY_NAME_AR,
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
        #endregion

        //interface
        public Task<GET_RM_CRIT_HAZARD_MASTER> GetByIdAsync(GET_RM_CRIT_HAZARD_MASTER entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<GET_RM_CRIT_HAZARD_MASTER>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RETURN_MESSAGE> AddAsync(GET_RM_CRIT_HAZARD_MASTER entity)
        {
            throw new NotImplementedException();
        }

        public Task<RETURN_MESSAGE> UpdateAsync(GET_RM_CRIT_HAZARD_MASTER entity)
        {
            throw new NotImplementedException();
        }

        public Task<RETURN_MESSAGE> DeleteAsync(GET_RM_CRIT_HAZARD_MASTER entity)
        {
            throw new NotImplementedException();
        }

        public Task<GET_RM_HAZARD_MASTER> GetByIdAsync(GET_RM_HAZARD_MASTER entity)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<GET_RM_HAZARD_MASTER>> IGenericRepository<GET_RM_HAZARD_MASTER>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RETURN_MESSAGE> AddAsync(GET_RM_HAZARD_MASTER entity)
        {
            throw new NotImplementedException();
        }

        public Task<RETURN_MESSAGE> UpdateAsync(GET_RM_HAZARD_MASTER entity)
        {
            throw new NotImplementedException();
        }

        public Task<RETURN_MESSAGE> DeleteAsync(GET_RM_HAZARD_MASTER entity)
        {
            throw new NotImplementedException();
        }




    }
}

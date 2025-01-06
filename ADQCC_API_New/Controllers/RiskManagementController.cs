
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using IBUSINESS_LOGIC;
using BUSINESS_LOGIC;
using IBUSINESS_LOGIC.IBusinessLogic;
using Dapper;
using System.Data;
using BUSINESS_LOGIC.BusinessLogic;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System;
namespace ADQCC_API_New.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RiskManagementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment hostingEnvironment;
        private RETURN_MESSAGE message;

        public RiskManagementController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }

        #region[Hazard Master]
        //Get --- Hazard Master
        [HttpGet]
        public async Task<IActionResult> GETRMHAZARDMASREPO()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETRMHAZARDMASREPO();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        //GETBYID --- HAZARDMASTER
        [HttpPost]
        public async Task<IActionResult> GETEDITRMHAZARDMASREPO(GET_RM_HAZARD_MASTER HAZARD_MAS_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETEDITRMHAZARDMASREPO(HAZARD_MAS_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }
        //Add --- HAZARDMASTER
        [HttpPost]
        public async Task<IActionResult> ADDRMHAZARDMASREPO(ADD_RM_HAZARD_MASTER _ADDRMHAZARDMASTER)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.ADDRMHAZARDMASREPO(_ADDRMHAZARDMASTER);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion

        #region[risk and other risks]
        //Get - risk and other risks

        [HttpGet]
        public async Task<IActionResult> GETHAZARDSELECTREPO()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETHAZARDSELECTREPO();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        //GETBYID --RISKS_OTHER_RISKS
        [HttpPost]
        public async Task<IActionResult> GETBYIDRISKREPO(GET_RM_RISKS_OTHER_RISKS HAZ_RISK_CAT_MAS_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETBYIDRISKREPO(HAZ_RISK_CAT_MAS_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }


        //ADD --- risk and other risks --- risk management
        [HttpPost]
        public async Task<IActionResult> ADDRMRISKOTHERRISKREPO(ADD_RM_RISKS_OTHER_RISKS __ADDRMRISKOTHERRISKREPO)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.ADDRMRISKOTHERRISKREPO(__ADDRMRISKOTHERRISKREPO);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion

        #region[Risk Category Master]
       
      
        [HttpGet]
        public async Task<IActionResult> GETRMRISKCATMAS()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETRMRISKCATMAS();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        //get by id

        [HttpPost]
        public async Task<IActionResult> GETBYIDRISKCATMAS(GET_RM_RISK_CAT_MASTER RISK_CAT_MAS_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETBYIDRISKCATMAS(RISK_CAT_MAS_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        //ADD

        [HttpPost]
        public async Task<IActionResult> ADDRMRISKCATMAS(ADD_RM_RISK_CAT_MASTER _ADDRMRISKCATMASTER)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.ADDRMRISKCATMAS(_ADDRMRISKCATMASTER);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion

        #region[PERSONSGROUPS]
        //GET
        [HttpGet]
        public async Task<IActionResult> GETRMPERSONSGROUPSREPO()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETRMPERSONSGROUPSREPO();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }
       


        //GETBYID --person group
        [HttpPost]
        public async Task<IActionResult> GETEDITRMPERSONSGROUPSREPO(GET_RM_PERSONS_GROUPS PERSON_GROUP_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETEDITRMPERSONSGROUPSREPO(PERSON_GROUP_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        //ADD

        [HttpPost]
        public async Task<IActionResult> ADDRMPERSONSGROUPSREPO(ADD_RM_PERSONS_GROUPS __ADDRMRISKOTHERRISKREPO)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.ADDRMPERSONSGROUPSREPO(__ADDRMRISKOTHERRISKREPO);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion

        #region [Details of any Existing Controls]
        //GET
        [HttpGet]
        public async Task<IActionResult> GETDECREPO()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETDECREPO();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }
        //GETBYID -- details exist
        [HttpPost]
        public async Task<IActionResult> GETEDITDECREPO(GET_RM_DETAILS_EXIST_CONT DETAILS_EXIST_CONT_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETEDITDECREPO(DETAILS_EXIST_CONT_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        //ADD

        [HttpPost]
        public async Task<IActionResult> ADDDEC(ADD_RM_DETAILS_EXIST_CONT _ADDDEC)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.ADDDECREPO(_ADDDEC);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion

        #region[Additional Control Measures]
        //GET
        [HttpGet]
        public async Task<IActionResult> GETADDTCONTMEASREPO()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETADDTCONTMEASREPO();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }


        //GETBYID -- 
        [HttpPost]
        public async Task<IActionResult> GETEDITADDCONTMEASREPO(GET_RM_ADD_CONT_MEAS ADD_CONT_MEAS_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETEDITADDCONTMEASREPO(ADD_CONT_MEAS_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }


        //ADD

        [HttpPost]
        public async Task<IActionResult> ADDCONTMEASREPO(ADD_RM_ADD_CONT_MEAS _ADDCONTMEAS)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.ADDCONTMEASREPO(_ADDCONTMEAS);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion

        #region [Opportunities and other opportunities]
        //GET
        [HttpGet]
        public async Task<IActionResult> GETOPPORTUNITIESREPO()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETOPPORTUNITIESREPO();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        //GETBYID -- op
        [HttpPost]
        public async Task<IActionResult> GETEDITOPPORTUNITIESREPO(GET_RM_OPPORTUNITIES OPPORTUNITIES_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETEDITOPPORTUNITIESREPO(OPPORTUNITIES_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        //ADD

        [HttpPost]
        public async Task<IActionResult> ADDOPPORTUNITIESREPO(ADD_RM_OPPORTUNITIES _ADDOPPORTUNITIES)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.ADDOPPORTUNITIESREPO(_ADDOPPORTUNITIES);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion

        #region[Critical Hazard Master]
        //GET
        [HttpGet]
        public async Task<IActionResult> GETRMCRITHAZARDMASREPO()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETRMCRITHAZARDMASREPO();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        //GETBYID -- critical 
        [HttpPost]
        public async Task<IActionResult> GETEDITRMCRITHAZARDMASREPO(GET_RM_CRIT_HAZARD_MASTER CRIT_HAZARD_MAS_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETEDITRMCRITHAZARDMASREPO(CRIT_HAZARD_MAS_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        //ADD

        [HttpPost]
        public async Task<IActionResult> ADDRMCRITHAZARDMASREPO(ADD_RM_CRIT_HAZARD_MASTER _ADDRMCRITHAZARDMASTER)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.ADDRMCRITHAZARDMASREPO(_ADDRMCRITHAZARDMASTER);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion


        //SAM

        #region [Risk Cover]

        //GET
        [HttpGet]
        public async Task<IActionResult> GetRiskBCM()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GetAll_RiskBCM();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }
        }

        //GET BY ID
        [HttpPost]
        public async Task<IActionResult> GetByIdRiskBCM(GET_RISK_COVER_BCM coverId)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GetByIdRiskBCM(coverId);
            if (data != null)
            {
                var response = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };

                return Ok(response);
            }
            else
            {
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);

            }
        }

        //ADD
        [HttpPost]
        public async Task<IActionResult> AddRiskBCM(ADD_RISK_COVER_BCM _addRisk)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.AddRiskBCM(_addRisk);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {
                    MESSAGE = "Failed",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }
        }
        #endregion

        #region [RISK_PROCESS_ACTIVITY_BCM]
        [HttpGet]
        public async Task<IActionResult> GetRiskProcess()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GetAll_RiskProcess();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }
        }

        //GET BY ID
        [HttpPost]
        public async Task<IActionResult> GetByIdRiskProcess(GET_RISK_PROCESS_ACTIVITY_BCM activityId)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GetByIdRiskProcess(activityId);
            if (data != null)
            {
                var response = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };

                return Ok(response);
            }
            else
            {
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);

            }
        }

        //ADD
        [HttpPost]
        public async Task<IActionResult> AddRiskProcess(ADD_RISK_PROCESS_ACTIVITY_BCM _addProcess)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.AddRiskProcess(_addProcess);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {
                    MESSAGE = "Failed",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }
        }
        #endregion

        #region [EXISTING_CONTROL]
        //GET
        [HttpGet]
        public async Task<IActionResult> GetExistBCM()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GetAll_ExistBCM();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }
        }

        //GET BY ID

        [HttpPost]
        public async Task<IActionResult> GetByIdRiskExistBCM(GET_EXISTING_CONTROL_MASTER controlId)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GetByIdRiskExistBCM(controlId);
            if (data != null)
            {
                var response = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };

                return Ok(response);
            }
            else
            {
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);

            }
        }

        //ADD
        [HttpPost]
        public async Task<IActionResult> AddRiskExistBCM(ADD_EXISTING_CONTROL_MASTER _addExist)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.AddRiskExistBCM(_addExist);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {
                    MESSAGE = "Failed",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }
        }
        #endregion

        #region [BCM TREATMENT]
        //ADD
        [HttpPost]
        public async Task<IActionResult> AddRiskTreatment(ADD_TREATMENT_MASTER _addTreatment)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.AddRiskTreatment(_addTreatment);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {
                    MESSAGE = "Failed",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }
        }
        //GET BY ID
        [HttpPost]
        public async Task<IActionResult> GetByIdRiskTreatment(GET_TREATMENT_MASTER treatmentId)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GetByIdRiskTreatment(treatmentId);
            if (data != null)
            {
                var response = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };

                return Ok(response);
            }
            else
            {
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);

            }
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> GetRiskTreatment()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GetAll_RiskTreatment();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }
        }
        #endregion


        //THARA
        #region[Non Critical Hazard Master]
        //GET
        [HttpGet]

        public async Task<IActionResult> GETRMNONCRITHAZMASREPO()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETRMNONCRITHAZMASREPO();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }
        //GET BY ID
        [HttpPost]
        public async Task<IActionResult> GETEDITRMNONCRITHAZMASREPO(ADD_RM_NON_CRIT_HAZ_MASTER NON_CRIT_HAZ_MAS_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETEDITRMNONCRITHAZMASREPO(NON_CRIT_HAZ_MAS_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }


        }
        //ADD
        [HttpPost]
        public async Task<IActionResult> ADDRMNONCRITHAZMASREPO(ADD_RM_NON_CRIT_HAZ_MASTER _ADDADDRMNONCRITHAZMASTER)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.ADDRMNONCRITHAZMASREPO(_ADDADDRMNONCRITHAZMASTER);
            if (data != null)
            {
                var b = new
                {

                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion

        #region[Non-Routine and Emergencies]
        //GET
        [HttpGet]

        public async Task<IActionResult> GETRMNONROUTEMERGMASREPO()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETRMNONROUTEMERGMASREPO();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }
        //GET BY ID
        [HttpPost]
        public async Task<IActionResult> GETEDITRMNONROUTEMERGMASREPO(ADD_RM_NON_ROUT_EMERG_MASTER NON_ROUT_EMERG_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETEDITRMNONROUTEMERGMASREPO(NON_ROUT_EMERG_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }


        }
        //ADD
        [HttpPost]
        public async Task<IActionResult> ADDRMNONROUTEMERGMASREPO(ADD_RM_NON_ROUT_EMERG_MASTER _ADDRMNONROUTEMERGMASTER)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.ADDRMNONROUTEMERGMASREPO(_ADDRMNONROUTEMERGMASTER);
            if (data != null)
            {
                var b = new
                {

                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion

        #region [Existing control measures for identified hazard]
        [HttpGet]

        public async Task<IActionResult> GETRMEXISTINGCMIHMASREPO()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETRMEXISTINGCMIHMASREPO();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }
        //GET BY ID
        [HttpPost]
        public async Task<IActionResult> GETEDITRMEXISTINGCMIHMASREPO(ADD_RM_EXISTING_CMIH_MASTER EXISTING_CMIH_MAS_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GETEDITRMEXISTINGCMIHMASREPO(EXISTING_CMIH_MAS_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }


        }
        //ADD
        [HttpPost]
        public async Task<IActionResult> ADDRMEXISTINGCMIHMASREPO(ADD_RM_EXISTING_CMIH_MASTER _ADDRMEXISTINGCMIHMASTER)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.ADDRMEXISTINGCMIHMASREPO(_ADDRMEXISTINGCMIHMASTER);
            if (data != null)
            {
                var b = new
                {

                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion

        #region [RISK_CATEGORY_BCM]
        [HttpGet]

        public async Task<IActionResult> GetRMCategory()
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GetRMCategory();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }
        //GET BY ID
        [HttpPost]
        public async Task<IActionResult> GetRM_CATEGORY_Edit(ADD_RISK_CATEGORY_BCM RM_CATEGORY_ID)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.GetRM_CATEGORY_Edit(RM_CATEGORY_ID);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }


        }
        //ADD
        [HttpPost]
        public async Task<IActionResult> AddRMCATEGORY(ADD_RISK_CATEGORY_BCM _AddRiskBCM)
        {
            var data = await _unitOfWork.GET_LOCATION_RISK.AddRMCATEGORY(_AddRiskBCM);
            if (data != null)
            {
                var b = new
                {

                    MESSAGE = "Added Successfully",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                var b = new
                {

                    MESSAGE = "Failled",
                    STATUS = false,
                    STATUS_CODE = "400"
                };
                return Ok(b);
            }

        }
        #endregion



    }
}
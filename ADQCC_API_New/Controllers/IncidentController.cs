using BUSINESS_LOGIC.BusinessLogic;
using Dapper;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MODELS;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ADQCC_API_New.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IncidentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment hostingEnvironment;
        private RETURN_MESSAGE message;

        public IncidentController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> AddIncident(IncidentModel _INC_DETAILS)
        {
            var data = await _unitOfWork.Incident.AddIncident(_INC_DETAILS);
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


        #region[Incident Category]
        [HttpGet]
        public async Task<IActionResult> GetIncident(string EMP_LOGIN_ID, string DESI_NAME)
        {
            var data = await _unitOfWork.Incident.GetIncident(EMP_LOGIN_ID, DESI_NAME);

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

        [HttpGet]
        public async Task<IActionResult> GetIncidentCategory()
        {
            var data = await _unitOfWork.Incident.GetIncidentCategory();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(data);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> GetIncidentById(GET_INCIDENT_CATEGORY_DETAILS getId)
        {
            var data = await _unitOfWork.Incident.GetIncidentById(getId);
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
        [HttpPost]
        public async Task<IActionResult> AddIncidentCategory(IncidentCategoryModel _INC_CAT_MASTER)
        {
            var data = await _unitOfWork.Incident.AddIncidentCategory(_INC_CAT_MASTER);
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

        #region[Incident Cause Analysis]
        [HttpGet]
        public async Task<IActionResult> GetemrINCDTCAdetails()
        {
            var data = await _unitOfWork.Incident.GetemrINCDTCAdetails();
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpPost]
        public async Task<IActionResult> GetIncidentCauseById(GET_EMR_INCDT_CA_DETAILS getId)
        {
            var data = await _unitOfWork.Incident.GetIncidentCauseById(getId);
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

        [HttpPost]
        public async Task<IActionResult> AddemrINCDTCA(ADD_EMR_INCDT_CA_MASTER _AddEMRINCDTCA)
        {
            var data = await _unitOfWork.Incident.AddemrINCDTCA(_AddEMRINCDTCA);
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

        #region [NOTIFICATION]
        [HttpGet]
        public async Task<IActionResult> GetIncidentView(string INCID)
        {
            var data = await _unitOfWork.Incident.ViewIncident(INCID);

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

        #region [INCIDENT INVESTIGATION]

        [HttpGet]
        public async Task<IActionResult> GetInvestigationList(string STATUS_ID, string EMP_LOGIN_ID, string DESI_NAME)
        {
            //STATUS_ID = "3";
            //EMP_LOGIN_ID = "50";
            //DESI_NAME = "Director";
            var data = await _unitOfWork.Incident.GetInvestigationList(STATUS_ID, EMP_LOGIN_ID, DESI_NAME);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetReporterBy()
        {
            var data = await _unitOfWork.Incident.GetReporterBy();

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

        [HttpPut]
        public async Task<IActionResult> UpdateIncidentStatus(UPDATE_INCIDENT_STATUS _UPDATE_INCIDENT_STATUS)
        {
            var data = await _unitOfWork.Incident.UpdateIncidentStatus(_UPDATE_INCIDENT_STATUS);

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

        #region [EHS INCIDENT ALERT]

        [HttpGet]
        public async Task<IActionResult> GetEHSAlertIncident()
        {
            var data = await _unitOfWork.Incident.GetEHSAlertIncident();
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        #endregion

        #region [Corrective Invest]
        [HttpGet]
        public async Task<IActionResult> GetCorrectiveInvestList(string LOGIN_ID, string DESIG_NAME)
        {
            var data = await _unitOfWork.Incident.GetCorrectiveInvestList(LOGIN_ID, DESIG_NAME);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        #endregion

        #region [InvestigationForm]
        [HttpGet]
        public async Task<IActionResult> GetEMRNIIDetails()
        {
            var data = await _unitOfWork.Incident.GetEMRNIIDetails();
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

        [HttpGet]
        public async Task<IActionResult> GetEMRMIIDetails()
        {
            var data = await _unitOfWork.Incident.GetEMRMIIDetails();
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

        [HttpGet]
        public async Task<IActionResult> GetEMRAIIDetails()
        {
            var data = await _unitOfWork.Incident.GetEMRAIIDetails();
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

        [HttpGet]
        public async Task<IActionResult> GetemrBODYLOCCATdetails()
        {
            var data = await _unitOfWork.Incident.GetemrBODYLOCCATdetails();
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

        [HttpGet]
        public async Task<IActionResult> GetEMRICActDetails()
        {
            var data = await _unitOfWork.Incident.GetEMRICActDetails();
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

        [HttpGet]
        public async Task<IActionResult> GetEMRICUCDetails()
        {
            var data = await _unitOfWork.Incident.GetEMRICUCDetails();
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

        [HttpGet]
        public async Task<IActionResult> GetEMRRCPFDetails()
        {
            var data = await _unitOfWork.Incident.GetEMRRCPFDetails();
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

        [HttpGet]
        public async Task<IActionResult> GetEMRRCSFDetails()
        {
            var data = await _unitOfWork.Incident.GetEMRRCSFDetails();
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

        [HttpPut]
        public async Task<IActionResult> ADD_INVESTIGATION(INVESTCATION_DETAILS _INVESTIGATION_DETAILS)
        {
            var data = await _unitOfWork.Incident.ADD_INVESTIGATION(_INVESTIGATION_DETAILS);
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

        [HttpPut]
        public async Task<IActionResult> AddSitePhotoUpload(List<SITE_INSPECTION_PHOTO_LIST> SITE_INSPECTION_PHOTO_LIST)
        {
            var data = await _unitOfWork.Incident.AddSitePhotoUpload(SITE_INSPECTION_PHOTO_LIST);
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

        #region [VIEW_INVESTIGATION_DETAILS]

        [HttpGet]
        public async Task<IActionResult> GET_VIEW_INVE_REVIEW_AND_APPROVALS(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_VIEW_INVE_REVIEW_AND_APPROVALS(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAlertList(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GetAlertList(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }


        [HttpGet]
        public async Task<IActionResult> GET_INVE_IM_CASUSE_ACT(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_INVE_IM_CASUSE_ACT(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_INVE_IM_UC_LIST(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_INVE_IM_UC_LIST(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_INVE_ROOT_PF_LIST(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_INVE_ROOT_PF_LIST(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_INVE_ROOT_SF_LIST(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_INVE_ROOT_SF_LIST(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_INVE_IM_METHOD(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_INVE_IM_METHOD(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_INVE_IM_ENVI(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_INVE_IM_ENVI(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_INVE_IM_MATERIAL(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_INVE_IM_MATERIAL(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_INVE_NATUREOFINJURY_LIST(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_INVE_NATUREOFINJURY_LIST(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_INVE_MECHANISMOFINJURY_LIST(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_INVE_MECHANISMOFINJURY_LIST(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_INVE_SOURCEOFINJURY_LIST(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_INVE_SOURCEOFINJURY_LIST(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_INVE_BODYLOCATION_LIST(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_INVE_BODYLOCATION_LIST(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_COST_ANALYSIS(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_COST_ANALYSIS(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_VIEW_ACTION_TAKEN(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_VIEW_ACTION_TAKEN(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_VIEW_INCIDENT_ROOT_CAUSE(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_VIEW_INCIDENT_ROOT_CAUSE(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_VIEW_CORRECTIVE_ACTION(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_VIEW_CORRECTIVE_ACTION(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }


        [HttpGet]
        public async Task<IActionResult> GET_VIEW_INJURED_PERSON_DETAILS(string INC_ID)
        {
            var data = await _unitOfWork.Incident.VIEW_INJURED_PERSON_DETAILS(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_MEDICAL_REPORT(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_MEDICAL_REPORT(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_VIEW_INVE_SEQUENCE_EVENT_LIST(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_VIEW_INVE_SEQUENCE_EVENT_LIST(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_VIEW_INVE_INTERVIEW_DETAILS(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_VIEW_INVE_INTERVIEW_DETAILS(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_VIEW_INVE_DOCUMENT_DETAILS(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_VIEW_INVE_DOCUMENT_DETAILS(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GET_VIEW_INVE_NEW_SITE_INSPECTION(string INC_ID)
        {
            var data = await _unitOfWork.Incident.GET_VIEW_INVE_NEW_SITE_INSPECTION(INC_ID);
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
                var response = new
                {
                    MESSAGE = "No Records Found",
                    STATUS = false,
                    STATUS_CODE = "404"
                };

                return Ok(response);
            }

        }
        #endregion
    }
}

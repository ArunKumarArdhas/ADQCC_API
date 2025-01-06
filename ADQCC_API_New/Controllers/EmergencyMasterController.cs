using System.Data.SqlClient;
using System.Data;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MODELS;
using ADQCC_New.Models.Emergency;
using Dapper;

namespace ADQCC_API_New.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmergencyMasterController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment hostingEnvironment;
        private RETURN_MESSAGE message;
        

        public EmergencyMasterController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }

        #region [ImmediateCause_UnsafeAct]
        [HttpPost]
        public async Task<IActionResult> AddUnSafeAct(M_EmergencyModel _EMRICAct_MASTER)
        {
            var data = await _unitOfWork.EmergencyMaster.AddAsync(_EMRICAct_MASTER);
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


        [HttpPost]
        public async Task<IActionResult> GetUnSafeById(M_EmergencyModel getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetByIdAsync(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_UnSafeAct = data,
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


        [HttpGet]
        public async Task<IActionResult> GetUnSafeActMaster()
        {
            var data = await _unitOfWork.EmergencyMaster.GetAllAsync();
            if (data != null) 
            {
                var b = new
                {
                    Get_All_UnSafeAct = data,
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



        [HttpPost]
        public async Task<IActionResult> DeleteUnSafeAct(M_EmergencyModel actId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteAsync(actId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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


        #endregion

        #region [ImmediateCause_UnsafeConditions]

        [HttpPost]
        public async Task<IActionResult> AddUnSafeCond(UNSAFECONDITION_MASTER _addunsafe)
        {
            var data = await _unitOfWork.EmergencyMaster.Add_UnSafeCond(_addunsafe);
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

        [HttpPost]
        public async Task<IActionResult> GetById(UNSAFECONDITION_MASTER getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetUnSafeCondById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_Condition = data,
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

        [HttpGet]
        public async Task<IActionResult> GetAllUnSafeCond()
        {
            var data = await _unitOfWork.EmergencyMaster.GetAllUnSafeCond();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Condition = data,
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


        [HttpPost]
        public async Task<IActionResult> DeleteUnSafeCond(UNSAFECONDITION_MASTER safeId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteUnSafeCond(safeId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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

        #endregion

        #region [Root Causes (Personal factor)]

        [HttpPost]
        public async Task<IActionResult> AddRootPersonal(ROOT_CAUSE_PERSONAL_MASTER _AddEEMRRCPF)
        {
            var data = await _unitOfWork.EmergencyMaster.AddRootPersonal(_AddEEMRRCPF);
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

        [HttpPost]
        public async Task<IActionResult> GetPersonalById(ROOT_CAUSE_PERSONAL_MASTER getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetPersonalById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_Personal = data,
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

        [HttpGet]
        public async Task<IActionResult> GetRootPersonal()
        {
            var data = await _unitOfWork.EmergencyMaster.GetAllRootPersonal();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Personal = data,
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


        [HttpPost]
        public async Task<IActionResult> DeletePersonal(ROOT_CAUSE_PERSONAL_MASTER perId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeletePersonal(perId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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

        #endregion

        #region [Root Causes (System factor)]

        [HttpPost]
        public async Task<IActionResult> AddRootSystem(ROOT_CAUSE_SYSTEM_MASTER _addRoot)
        {
            var data = await _unitOfWork.EmergencyMaster.AddRootSystem(_addRoot);
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

        [HttpPost]
        public async Task<IActionResult> GetSystemById(ROOT_CAUSE_SYSTEM_MASTER getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetSystemById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_System = data,
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

        [HttpGet]
        public async Task<IActionResult> GetRootSystem()
        {
            var data = await _unitOfWork.EmergencyMaster.GetAllRootSystem();
            if (data != null)
            {
                var b = new
                {
                    Get_All_System = data,
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


        [HttpPost]
        public async Task<IActionResult> DeleteSystem(ROOT_CAUSE_SYSTEM_MASTER sysId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteSystem(sysId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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


        #endregion

        #region [Root Cause (Method)]
        [HttpPost]
        public async Task<IActionResult> AddRootMethod(ROOT_CAUSE_METHOD_MASTER _AddEMRRCMethod)
        {
            var data = await _unitOfWork.EmergencyMaster.AddRootMethod(_AddEMRRCMethod);
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

        [HttpPost]
        public async Task<IActionResult> GetMethodById(ROOT_CAUSE_METHOD_MASTER getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetMethodById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_Method = data,
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

        [HttpGet]
        public async Task<IActionResult> GetRootMethod()
        {
            var data = await _unitOfWork.EmergencyMaster.GetAllRootMethod();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Method = data,
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


        [HttpPost]
        public async Task<IActionResult> DeleteMethod(ROOT_CAUSE_METHOD_MASTER metId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteMethod(metId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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

        #endregion

        #region [Root Cause(Environment)]
        [HttpGet]

        public async Task<IActionResult> GetEMRRCEnvironment()
        {
            var data = await _unitOfWork.EmergencyMaster.GetEMRRCEnvironment();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Environment = data,
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

        [HttpPost]
        public async Task<IActionResult> GetCauseById(ROOT_CAUSE_ENVIRONMENT_MASTER getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetCauseById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_Environment = data,
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
        public async Task<IActionResult> AddEEMRRCEnvironment(ROOT_CAUSE_ENVIRONMENT_MASTER _AddEMRENVIRONMENT)
        {
            var data = await _unitOfWork.EmergencyMaster.AddEEMRRCEnvironment(_AddEMRENVIRONMENT);
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


        [HttpPost]
        public async Task<IActionResult> DeleteEnvironment(ROOT_CAUSE_ENVIRONMENT_MASTER enId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteEnvironment(enId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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

        #endregion

        #region [Root Cause(Material)]
        [HttpGet]

        public async Task<IActionResult> GetEMRRCMaterial()
        {
            var data = await _unitOfWork.EmergencyMaster.GetEMRRCMaterial();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Material = data,
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

        [HttpPost]
        public async Task<IActionResult> GetCauseMaterialById(ROOT_CAUSE_MATERIAL_MASTER getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetCauseMaterialById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_Material = data,
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
        public async Task<IActionResult> AddEEMRRCMaterial(ROOT_CAUSE_MATERIAL_MASTER _AddEMRMATERIAL)
        {
            var data = await _unitOfWork.EmergencyMaster.AddEEMRRCMaterial(_AddEMRMATERIAL);
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


        [HttpPost]
        public async Task<IActionResult> DeleteMaterial(ROOT_CAUSE_MATERIAL_MASTER matId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteMaterial(matId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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

        #endregion

        #region [Nature of Injury / Illness]
        [HttpGet]

        public async Task<IActionResult> GetEMRNIIDetails()
        {
            var data = await _unitOfWork.EmergencyMaster.GetEMRNIIDetails();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Nature = data,
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

        [HttpPost]
        public async Task<IActionResult> GetNatureById(NATURE_INJURY_DETAILS getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetNatureById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_Nature = data,
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
        public async Task<IActionResult> AddEMRNII(NATURE_INJURY_DETAILS _AddEMRNII)
        {
            var data = await _unitOfWork.EmergencyMaster.AddEMRNII(_AddEMRNII);
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


        [HttpPost]
        public async Task<IActionResult> DeleteNature(NATURE_INJURY_DETAILS natId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteNature(natId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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

        #endregion

        #region [Mechanism of Injury / Illness]
        [HttpGet]

        public async Task<IActionResult> GetEMRMIIDetails()
        {
            var data = await _unitOfWork.EmergencyMaster.GetEMRMIIDetails();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Mechanism = data,
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

        [HttpPost]
        public async Task<IActionResult> GetInjuryById(MECH_INJURY_DETAILS getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetInjuryById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_Mechanism = data,
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
        public async Task<IActionResult> AddEMRMII(MECH_INJURY_DETAILS _AddEMRMII)
        {
            var data = await _unitOfWork.EmergencyMaster.AddEMRMII(_AddEMRMII);
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


        [HttpPost]
        public async Task<IActionResult> DeleteMechanism(MECH_INJURY_DETAILS mechId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteMechanism(mechId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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

        #endregion

        #region [Agency / Source of Injury / Illness]
        [HttpGet]

        public async Task<IActionResult> GetEMRAIIDetails()
        {
            var data = await _unitOfWork.EmergencyMaster.GetEMRAIIDetails();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Agency = data,
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

        [HttpPost]
        public async Task<IActionResult> GetAgencyInjuryById(AGENCY_INJURY_DETAILS getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetAgencyInjuryById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_Agency = data,
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
        public async Task<IActionResult> AddEMRAII(AGENCY_INJURY_DETAILS _AddEMRAII)
        {
            var data = await _unitOfWork.EmergencyMaster.AddEMRAII(_AddEMRAII);
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


        [HttpPost]
        public async Task<IActionResult> DeleteAgency(AGENCY_INJURY_DETAILS ageId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteAgency(ageId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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

        #endregion

        #region[Incident Cause Analysis]
        [HttpGet]

        public async Task<IActionResult> GetemrINCDTCAdetails()
        {
            var data = await _unitOfWork.EmergencyMaster.GetemrINCDTCAdetails();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Incident = data,
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

        [HttpPost]
        public async Task<IActionResult> GetIncidentCauseById(INCIDENT_DETAILS getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetIncidentCauseById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_Incident = data,
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
        public async Task<IActionResult> AddemrINCDTCA(INCIDENT_DETAILS _AddEMRINCDTCA)
        {
            var data = await _unitOfWork.EmergencyMaster.AddemrINCDTCA(_AddEMRINCDTCA);
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


        [HttpPost]
        public async Task<IActionResult> DeleteIncidentCause(INCIDENT_DETAILS causeId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteIncidentCause(causeId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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

        #endregion

        #region[Incident Category]
        [HttpGet]

        public async Task<IActionResult> GetIncidentCategory()
        {
            var data = await _unitOfWork.EmergencyMaster.GetIncidentCategory();
            if (data != null)
            {
                var b = new
                {
                    Get_All_IncidentDet = data,
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

        [HttpPost]
        public async Task<IActionResult> GetIncidentById(INCIDENT_CATEGORY_DETAILS getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetIncidentById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_IncidentDet = data,
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
        public async Task<IActionResult> AddIncidentCategory(INCIDENT_CATEGORY_DETAILS _INC_CAT_MASTER)
        {
            var data = await _unitOfWork.EmergencyMaster.AddIncidentCategory(_INC_CAT_MASTER);
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


        [HttpPost]
        public async Task<IActionResult> DeleteIncidentCategory(INCIDENT_CATEGORY_DETAILS catId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteIncidentCategory(catId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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

        #endregion

        //#region[Drill Type]
        //[HttpGet]

        //public async Task<IActionResult> GetDrill_Management_Type()
        //{
        //    var data = await _unitOfWork.EmergencyMaster.GetDrill_Management_Type();
        //    if (data != null)
        //    {
        //        var b = new
        //        {
        //            Get_All = data,
        //            MESSAGE = "Success",
        //            STATUS = true,
        //            STATUS_CODE = "200"
        //        };
        //        return Ok(b);

        //    }
        //    else
        //    {
        //        message.MESSAGE = "No Records Found";
        //        return Ok(message);
        //    }

        //}

        //[HttpPost]
        //public async Task<IActionResult> GetDrillTypeById(GET_DRILL_TYPE getId)
        //{
        //    var data = await _unitOfWork.EmergencyMaster.GetDrillTypeById(getId);
        //    if (data != null)
        //    {
        //        var response = new
        //        {
        //            Get_All = data,
        //            MESSAGE = "Success",
        //            STATUS = true,
        //            STATUS_CODE = "200"
        //        };

        //        return Ok(response);
        //    }
        //    else
        //    {
        //        var response = new
        //        {
        //            MESSAGE = "No Records Found",
        //            STATUS = false,
        //            STATUS_CODE = "404"
        //        };

        //        return Ok(response);

        //    }
        //}
        //[HttpPost]
        //public async Task<IActionResult> Add_Drill_Management_Type(ADD_DRILL_TYPE _AddDrillType)
        //{
        //    var data = await _unitOfWork.EmergencyMaster.Add_Drill_Management_Type(_AddDrillType);
        //    if (data != null)
        //    {
        //        var b = new
        //        {

        //            MESSAGE = "Added Successfully",
        //            STATUS = true,
        //            STATUS_CODE = "200"
        //        };
        //        return Ok(b);
        //    }
        //    else
        //    {
        //        var b = new
        //        {

        //            MESSAGE = "Failled",
        //            STATUS = false,
        //            STATUS_CODE = "400"
        //        };
        //        return Ok(b);
        //    }

        //}
        //#endregion

        //#region[Drill Type Checklist]
        //[HttpGet]

        //public async Task<IActionResult> Get_Drill_Checklist()
        //{
        //    var data = await _unitOfWork.EmergencyMaster.Get_Drill_Checklist();
        //    if (data != null)
        //    {
        //        var b = new
        //        {
        //            Get_All = data,
        //            MESSAGE = "Success",
        //            STATUS = true,
        //            STATUS_CODE = "200"
        //        };
        //        return Ok(b);

        //    }
        //    else
        //    {
        //        message.MESSAGE = "No Records Found";
        //        return Ok(message);
        //    }

        //}

        //[HttpPost]
        //public async Task<IActionResult> GetDrillChecklistById(GET_DRILL_CHECKLIST getId)
        //{
        //    var data = await _unitOfWork.EmergencyMaster.GetDrillChecklistById(getId);
        //    if (data != null)
        //    {
        //        var response = new
        //        {
        //            Get_All = data,
        //            MESSAGE = "Success",
        //            STATUS = true,
        //            STATUS_CODE = "200"
        //        };

        //        return Ok(response);
        //    }
        //    else
        //    {
        //        var response = new
        //        {
        //            MESSAGE = "No Records Found",
        //            STATUS = false,
        //            STATUS_CODE = "404"
        //        };

        //        return Ok(response);

        //    }
        //}
        //[HttpPost]
        //public async Task<IActionResult> Add_Drill_CheckList(ADD_DRILL_CHECKLIST _DRILL_CHECKLIST)
        //{
        //    var data = await _unitOfWork.EmergencyMaster.Add_Drill_CheckList(_DRILL_CHECKLIST);
        //    if (data != null)
        //    {
        //        var b = new
        //        {

        //            MESSAGE = "Added Successfully",
        //            STATUS = true,
        //            STATUS_CODE = "200"
        //        };
        //        return Ok(b);
        //    }
        //    else
        //    {
        //        var b = new
        //        {

        //            MESSAGE = "Failled",
        //            STATUS = false,
        //            STATUS_CODE = "400"
        //        };
        //        return Ok(b);
        //    }

        //}
        //#endregion

        #region [DISASTER_TYPE]
        [HttpPost]
        public async Task<IActionResult> AddDiasterType(DISASTER_TYPE_MASTER _diASTER_MASTER)
        {
            var data = await _unitOfWork.EmergencyMaster.AddDiasterType(_diASTER_MASTER);
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
        [HttpPost]
        public async Task<IActionResult> GetDiasterTypeById(DISASTER_TYPE_MASTER getId)
        {
            var data = await _unitOfWork.EmergencyMaster.GetDiasterTypeById(getId);
            if (data != null)
            {
                var response = new
                {
                    Get_ById_Disaster = data,
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

        [HttpGet]
        public async Task<IActionResult> GetDiasterType()
        {
            var data = await _unitOfWork.EmergencyMaster.GetAllDiasterType();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Disaster = data,
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


        [HttpPost]
        public async Task<IActionResult> DeleteDisasterType(DISASTER_TYPE_MASTER disId)
        {
            var data = await _unitOfWork.EmergencyMaster.DeleteDisasterType(disId);
            if (data != null)
            {
                var response = new
                {
                    MESSAGE = "Deleted successfully.",
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
        #endregion

        //#region[EMERGENCY_TEAM_ACTIVATE]
        //[HttpGet]
        //public async Task<IActionResult> GetEMRMaster()
        //{
        //    var data = await _unitOfWork.EmergencyMaster.GetAll_EMRMaster();
        //    if (data != null)
        //    {
        //        var b = new
        //        {
        //            Get_All = data,
        //            MESSAGE = "Success",
        //            STATUS = true,
        //            STATUS_CODE = "200"
        //        };
        //        return Ok(b);
        //    }
        //    else
        //    {
        //        message.MESSAGE = "No Records Found";
        //        return Ok(message);
        //    }
        //}


        //[HttpPost]
        //public async Task<IActionResult> AddEMRMaster(ADD_EMERGENCY_TYPE_MASTER_SELECT _emrMaster)
        //{
        //    var data = await _unitOfWork.EmergencyMaster.AddEMRMaster(_emrMaster);
        //    if (data != null)
        //    {
        //        var b = new
        //        {
        //            MESSAGE = "Added Successfully",
        //            STATUS = true,
        //            STATUS_CODE = "200"
        //        };
        //        return Ok(b);
        //    }
        //    else
        //    {
        //        var b = new
        //        {
        //            MESSAGE = "Failed",
        //            STATUS = false,
        //            STATUS_CODE = "400"
        //        };
        //        return Ok(b);
        //    }
        //}



        //[HttpGet]
        //public async Task<IActionResult> GetEMRCorrective()
        //{
        //    var data = await _unitOfWork.EmergencyMaster.GetAll_EMRCorrective();
        //    if (data != null)
        //    {
        //        var b = new
        //        {
        //            Get_All = data,
        //            MESSAGE = "Success",
        //            STATUS = true,
        //            STATUS_CODE = "200"
        //        };
        //        return Ok(b);
        //    }
        //    else
        //    {
        //        message.MESSAGE = "No Records Found";
        //        return Ok(message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddEMRCorrective(ADD_EMERGENCY_TYPE_CORRECTIVE_ACTION _addEmr)
        //{
        //    var data = await _unitOfWork.EmergencyMaster.AddEMRCorrective(_addEmr);
        //    if (data != null)
        //    {
        //        var b = new
        //        {
        //            MESSAGE = "Added Successfully",
        //            STATUS = true,
        //            STATUS_CODE = "200"
        //        };
        //        return Ok(b);
        //    }
        //    else
        //    {
        //        var b = new
        //        {
        //            MESSAGE = "Failed",
        //            STATUS = false,
        //            STATUS_CODE = "400"
        //        };
        //        return Ok(b);
        //    }
        //}

        //#endregion
    }
}



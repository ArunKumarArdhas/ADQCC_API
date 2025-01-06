using Microsoft.AspNetCore.Mvc;
using MODELS;
using IBUSINESS_LOGIC.IBusinessLogic;
using Dapper;
using System.Data;
using BUSINESS_LOGIC.BusinessLogic;
using static MODELS.COMMON;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
namespace ADQCC_API_New.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment hostingEnvironment;
        private RETURN_MESSAGE message;

        public MasterController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }
        #region [Nationality]
        [HttpGet]
        public async Task<IActionResult> GetNationalityDetails()
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.GetNationalityDetails();
            if (data != null)
            {
                var b = new
                {
                    Get_All_National = data,
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
        #region [LOCATION]
        [HttpGet]

        public async Task<IActionResult> GetLocationMaster()
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.GetAllAsync();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Location = data,
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
        public async Task<IActionResult> AddLocation(GET_LOCATION_MASTER _LOCATION_MASTER)
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.AddAsync(_LOCATION_MASTER);
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

        #region [BUILDING]
        [HttpGet]
        public async Task<IActionResult> GetBuildingMaster()
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.GetAll_Buildings();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Building = data,
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
        public async Task<IActionResult> AddBuilding(ADD_BUILDING_MASTER _BUILDING_MASTER)
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.Add_Building(_BUILDING_MASTER);
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

        #region[DEPARTMENT]

        [HttpPost]
        public async Task<IActionResult> AddDepartment(ADD_DEPARTMENT_MASTER _DEPARTMENT_MASTER)
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.AddDepartment(_DEPARTMENT_MASTER);
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
        [HttpGet]
        public async Task<IActionResult> GetDepartmentMaster()
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.GetAll_Department();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Depart = data,
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
        public async Task<IActionResult> GetDepartemntById(GET_DEPARTMENT_MASTER model)
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.GetDepartmentById(model);
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

        #region[DESIGNATION]
        [HttpGet]
        public async Task<IActionResult> GetDesignationMaster()
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.GetDesignationDetails();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Design = data,
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
        public async Task<IActionResult> AddDesignation(DesignationModel model)
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.AddDesignationDetails(model);
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
        public async Task<IActionResult> GetDesignationById(DesignationModel model)
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.GetDesignationById(model);
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

        #region[SECTION_LAB_MASTER]
        [HttpGet]

        public async Task<IActionResult> GetSectionLabMaster()
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.GetSectionLabMaster();
            if (data != null)
            {
                var b = new
                {
                    Get_All_SecLab = data,
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
        public async Task<IActionResult> AddSectionLab(ADD_SECTION_LAB_MASTER _SECTION_LAB_MASTER)
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.AddSectionLab(_SECTION_LAB_MASTER);
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

        #region[EMERGENCY_TYPE_MASTER]
        [HttpGet]

        public async Task<IActionResult> GetEmergTypeMaster()
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.GetEmergTypeMaster();
            if (data != null)
            {
                var b = new
                {
                    Get_All_ET = data,
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
        public async Task<IActionResult> AddEmergTypeMaster(ADD_EMR_TYPE_MASTER _AddEmergTypeMaster)
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.AddEmergTypeMaster(_AddEmergTypeMaster);
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

        #region[SECTOR]
        //sector master post
        [HttpPost]
        public async Task<IActionResult> AddSectorDetails(SectorModel SECTOR_MASTER)
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.AddSectorDetails(SECTOR_MASTER);
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
        //sector master get
        [HttpGet]
        public async Task<IActionResult> GetSectorDetails()
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.GetAll_Sector();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Sector = data,
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

        #region[SECTOR_TYPE]
        //sector type model - get
        [HttpGet]
        public async Task<IActionResult> GetSectorTypeDetails()
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.GetSectorTypeDetails();
            if (data != null)
            {
                var b = new
                {
                    Get_All_Sect_Type = data,
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
        //SECTOR TYPE MODEL - POST
        [HttpPost]
        public async Task<IActionResult> AddSectorTypeDetails(SectorTypeModel model)
        {
            var data = await _unitOfWork.GET_LOCATION_MASTER.AddSectorTypeDetails(model);
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

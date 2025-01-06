using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace ADQCC_API_New.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrillManagementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment hostingEnvironment;
        private RETURN_MESSAGE message;

        public DrillManagementController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> Add_DrillType(ADD_DRILL_TYPE _AddDrill)
        {
            var data = await _unitOfWork.mDrillManagement.Add_DrillType(_AddDrill);
            if (data != null)
            {
                var b = new
                {
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
        public async Task<IActionResult> GetAll_Drill()
        {
            var data = await _unitOfWork.mDrillManagement.GetAll_Drill();
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
        public async Task<IActionResult> Edit_Drill(string TYPE_ID)
        {
            var data = await _unitOfWork.mDrillManagement.Edit_Drill(TYPE_ID);
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
        [HttpPost]
        public async Task<IActionResult> Delete_Drill(string Dr_TYPE_ID)
        {
            var data = await _unitOfWork.mDrillManagement.Delete_Drill(Dr_TYPE_ID);
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

    }
}

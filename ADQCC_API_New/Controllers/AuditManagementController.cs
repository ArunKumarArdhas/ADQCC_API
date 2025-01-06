using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using IBUSINESS_LOGIC;
using BUSINESS_LOGIC;
using IBUSINESS_LOGIC.IBusinessLogic;
using Dapper;
using System.Data;
using BUSINESS_LOGIC.BusinessLogic;
namespace ADQCC_API_New.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuditManagementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment hostingEnvironment;
        private RETURN_MESSAGE message;

        public AuditManagementController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]

        public async Task<IActionResult> GetAuditType()
        {
            var data = await _unitOfWork.Audit_Management.GetAuditType();
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
        public async Task<IActionResult> AddAuditType(AUDIT_TYPE_MASTER _AUDIT_TYPE_MASTER)
        {
            var data = await _unitOfWork.Audit_Management.AddAuditType(_AUDIT_TYPE_MASTER);
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
        public async Task<IActionResult> GetAuditTypeEdit(AUDIT_TYPE_MASTER AUDIT_TYPE_ID)
        {
            var data = await _unitOfWork.Audit_Management.GetAuditTypeEdit(AUDIT_TYPE_ID);
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

        public async Task<IActionResult> GetStandard()
        {
            var data = await _unitOfWork.Audit_Management.GetStandard();
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
        public async Task<IActionResult> AddStandard(AUDIT_STANDARD_MASTER _AUDIT_STANDARD_MASTER)
        {
            var data = await _unitOfWork.Audit_Management.AddStandard(_AUDIT_STANDARD_MASTER);
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
        public async Task<IActionResult> GetStandardEdit(AUDIT_STANDARD_MASTER STANDARD_ID)
        {
            var data = await _unitOfWork.Audit_Management.GetStandardEdit(STANDARD_ID);
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

using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace ADQCC_API_New.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EmergencyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment hostingEnvironment;
        private RETURN_MESSAGE message;

        public EmergencyController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }

        #region [EMERGENCY TEAM ACTIVE]

        [HttpGet]
        public async Task<IActionResult> GetEmrTeamActivate()
        {
            try
            {
                // Calling the asynchronous method from the repository
                var result = await _unitOfWork.Emergency._GetEmrTeamActivate();

                if (result != null && result.Any())
                {
                    return Ok(result); // Return the list directly
                }
                else
                {
                    // Return an empty list or a meaningful response if no data is found
                    return Ok(new List<GET_EMERGENCY_TYPE_MASTER_SELECT>());
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "An error occurred while fetching data.");

                // Return a 500 internal server error response
                return StatusCode(500, "Internal server error");
            }
        }

        //[JwtAuthentication]
        [HttpGet]
        // GET: api/UserDetails
        public async Task<IActionResult> GetSelectEmployeeLoad()
        {
            try
            {
                // Calling the asynchronous method from the repository
                var result = await _unitOfWork.Emergency._GetSelectEmployeeLoad();

                if (result != null && result.Any())
                {
                    return Ok(result); // Returning the employee details if found
                }
                else
                {
                    var response = new
                    {
                        MESSAGE = "No employees found.",
                        STATUS = false,
                        STATUS_CODE = "404"
                    };
                    return NotFound(response); // Return 404 if no data is found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "An error occurred while fetching employee details.");

                // Return a 500 internal server error response
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEmergencyTypeTeamList()
        {
            try
            {
                // Calling the asynchronous method from the repository
                var result = await _unitOfWork.Emergency._GetEmergencyTypeTeamList();

                if (result != null && result.Any())
                {
                    return Ok(result); // Returning the emergency type team list if found
                }
                else
                {
                    var response = new
                    {
                        MESSAGE = "No emergency type teams found.",
                        STATUS = false,
                        STATUS_CODE = "404"
                    };
                    return NotFound(response); // Return 404 if no data is found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "An error occurred while fetching emergency type team list.");

                // Return a 500 internal server error response
                return StatusCode(500, "Internal server error");
            }
        }

    }

    #endregion


}

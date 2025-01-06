using BUSINESS_LOGIC.BusinessLogic;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace ADQCC_API_New.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EmployeeDetailsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment hostingEnvironment;
        private RETURN_MESSAGE message;

        public EmployeeDetailsController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }

        #region [Employee List]

        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails(string? EMP_ID, string? EMP_NAME, string? EMP_DESI)
        {
            try
            {
                // Fetch the employee details from the repository
                var result = await Task.Run(() => _unitOfWork.EmployeeDetails.GetEmployeeDetails(EMP_ID, EMP_NAME, EMP_DESI));

                if (result != null && result.Any())
                {
                    return Ok(result); // Return the employee details
                }
                else
                {
                    // Return an empty list if no data is found
                    return Ok(new List<GET_EMPLOYEE_DETAILS>());
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional, if a logger is available)
                // _logger.LogError(ex, "An error occurred while fetching employee details.");

                // Return a 500 internal server error response
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        //[Route("AddEmployeeDetails")]
        public async Task<IActionResult> AddEmployeeDetails([FromBody] ADD_EMPLOYEE_DETAILS _EMPLOYEE_DETAILS)
        {
            try
            {
                if (_EMPLOYEE_DETAILS == null)
                {
                    return BadRequest("Employee details cannot be null.");
                }

                // Call the repository asynchronously
                var result = await _unitOfWork.EmployeeDetails.AddEmployeeDetails(_EMPLOYEE_DETAILS);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(500, "Failed to add employee details.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An internal server error occurred.");
            }
        }



        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeDetails([FromBody] ADD_EMPLOYEE_DETAILS employeeDetails)
        {
            try
            {
                if (employeeDetails == null)
                {
                    return BadRequest("Employee details cannot be null.");
                }

                var result = await _unitOfWork.EmployeeDetails.AddEmployeeDetails(employeeDetails);

                if (result != null)
                {
                    if (result.STATUS_CODE == "401") // Example for an unauthorized status
                    {
                        return Unauthorized(new { result.MESSAGE });
                    }

                    return Ok(result);
                }
                else
                {
                    return StatusCode(500, "Failed to update employee details.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog or NLog)
                return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message });
            }
        }

        //[JwtAuthentication]
        //[Route("GetEmp_Dir_BySector")]
        [HttpGet]
        public async Task<IActionResult> GetEmp_Dir_BySector(string SECTOR_ID, string BUILDING_ID)
        {
            try
            {
                if (string.IsNullOrEmpty(SECTOR_ID) || string.IsNullOrEmpty(BUILDING_ID))
                {
                    return BadRequest("Sector ID and Building ID cannot be null or empty.");
                }

                var result = await _unitOfWork.EmployeeDetails.GetEmp_Dir_BySector(SECTOR_ID, BUILDING_ID);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("No employees found for the given sector and building.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog or NLog)
                return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message });
            }
        }

        //[JwtAuthentication]
        //[Route("GetPreviewDetails")]
        [HttpGet]
        public async Task<IActionResult> GetEmployee_Preview()
        {
            try
            {
                var result = await _unitOfWork.EmployeeDetails.GetEmployee_Preview();

                if (result != null)
                {
                    return Ok(result); // Return the result with a 200 OK status
                }
                else
                {
                    return NotFound("No employee preview details found."); // 404 Not Found if no data is found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog or NLog)
                return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message }); // 500 Internal Server Error
            }
        }

        //[JwtAuthentication]
        //[Route("GetHealthVitalsDetails")]
        [HttpGet]
        public async Task<IActionResult> GetHealthVitalsDetails(string EMP_ID)
        {
            try
            {
                // Validate the input to ensure EMP_ID is not null or empty
                if (string.IsNullOrEmpty(EMP_ID))
                {
                    return BadRequest("Employee ID cannot be null or empty.");
                }

                var result = await _unitOfWork.EmployeeDetails.GetHealthVitalsDetails(EMP_ID);

                if (result != null && result.Any()) // Check if results are found
                {
                    return Ok(result); // Return the result with a 200 OK status
                }
                else
                {
                    return NotFound("No health vitals details found for the provided employee ID."); // 404 Not Found if no data is found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog or NLog)
                return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message }); // 500 Internal Server Error
            }
        }

        //[Route("GetEmployeeFilter")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeFilter()
        {
            try
            {
                var result = await _unitOfWork.EmployeeDetails.GetEmployeeFilter();

                if (result != null && result.Any()) // Check if results are found
                {
                    return Ok(result); // Return the result with a 200 OK status
                }
                else
                {
                    return NotFound("No employee data found."); // 404 Not Found if no data is found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog or NLog)
                return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message }); // 500 Internal Server Error
            }
        }

        //[JwtAuthentication]
        //[Route("GetEmployee_EHSList")]
        [HttpGet]
        public async Task<IActionResult> GetEmployee_EHSList()
        {
            try
            {
                var result = await _unitOfWork.EmployeeDetails.GetEmployee_EHSList();

                if (result != null && result.Any()) // Check if results are found
                {
                    return Ok(result); // Return the result with a 200 OK status
                }
                else
                {
                    return NotFound("No EHS list data found."); // 404 Not Found if no data is found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog or NLog)
                return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message }); // 500 Internal Server Error
            }
        }

        //[JwtAuthentication]
        //[Route("GetEmployee_SECTION_HEAD_List")]
        [HttpGet]
        public async Task<IActionResult> GetEmployee_SECTION_HEAD_List()
        {
            try
            {
                var result = await _unitOfWork.EmployeeDetails.GetEmployee_SECTION_HEAD_List();

                if (result != null && result.Any()) // Check if results are found
                {
                    return Ok(result); // Return the result with a 200 OK status
                }
                else
                {
                    return NotFound("No section head data found."); // 404 Not Found if no data is found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog or NLog)
                return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message }); // 500 Internal Server Error
            }
        }

        //[JwtAuthentication]
        //[Route("GetEmployee_HSSE_List")]
        [HttpGet]
        public async Task<IActionResult> GetEmployee_HSSE_List()
        {
            try
            {
                var result = await _unitOfWork.EmployeeDetails.GetEmployee_HSSE_List();

                if (result != null && result.Any()) // Check if results are found
                {
                    return Ok(result); // Return the result with a 200 OK status
                }
                else
                {
                    return NotFound("No HSSE list data found."); // 404 Not Found if no data is found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog or NLog)
                return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message }); // 500 Internal Server Error
            }
        }

        //[JwtAuthentication]
        //[Route("GetActiveDeactiveStatus")]
        [HttpGet]
        public async Task<IActionResult> GetActiveDeactiveStatus(string EMP_ID, string STATUS, string PASSWORD, string USERNAME)
        {
            try
            {
                var result = await _unitOfWork.EmployeeDetails.GetActiveDeactiveStatus(EMP_ID, STATUS, PASSWORD, USERNAME);

                if (result != null)
                {
                    return Ok(result); // Return the result with a 200 OK status
                }
                else
                {
                    return NotFound("No status data found."); // 404 Not Found if no data is found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog or NLog)
                return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message }); // 500 Internal Server Error
            }
        }

        //[JwtAuthentication]
        //[Route("DeleteEmployeeDetails")]
        [HttpDelete]  // Using DELETE instead of GET for delete operations
        public async Task<IActionResult> DeleteEmployeeDetails(string EMP_ID)
        {
            try
            {
                var result = await _unitOfWork.EmployeeDetails.DeleteEmployeeDetails(EMP_ID);

                if (result != null)
                {
                    return Ok(result);  // Return 200 OK status with the result
                }
                else
                {
                    return NotFound("Employee details not found.");  // Return 404 if employee is not found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog or NLog)
                return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message });  // Return 500 Internal Server Error
            }
        }

        //[JwtAuthentication]
        //[Route("GetEmployeeEditDetails")]
        [HttpGet]  // Use GET method for retrieving data
        public async Task<IActionResult> GetEmployeeEditDetails(string EMP_ID)
        {
            try
            {
                var result = await _unitOfWork.EmployeeDetails.EditEmployeeDetails(EMP_ID);

                if (result != null)  // Check if employee details are found
                {
                    return Ok(result);  // Return 200 OK with the employee details
                }
                else
                {
                    return NotFound("Employee details not found.");  // Return 404 if employee details are not found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework like Serilog or NLog)
                return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message });  // Return 500 Internal Server Error
            }
        }


        #endregion

    }
}

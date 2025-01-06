using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using MODELS;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ADQCC_API_New.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private IWebHostEnvironment hostingEnvironment;
        private RETURN_MESSAGE message;
        public AccountController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
           // this.hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> Send_OTP(LOGIN _Login)
        {
            var data = await _unitOfWork.MAccountsRepo.VerifyOTP(_Login);
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
        public async Task<IActionResult> LOGIN(LOGIN _Login)
        {
            var data = await _unitOfWork.MAccountsRepo.Get_User_Details(_Login);
            if (data != null)
            {
                data.JWT_Token = CreateToken(data.EMP_EMAIL!, data.DESI_NAME!);
                var b = new
                {
                    USER_DETAILS = data,
                    MESSAGE = "Login Successfully",
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
        private string CreateToken(string username, string role)
        {
            try
            {
                role = "1";
                List<Claim> claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name,username),
                    new Claim(ClaimTypes.Role, role)
                };

                //var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                //    _configuration.GetSection("ConnectionStrings:Token").Value!));
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        _configuration.GetSection("ConnectionStrings:Token").Value!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(15),
                    signingCredentials: creds);

                var jwt = "ADQCC97431Dlf";
                //var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            catch (Exception)
            {

                throw;
            }

        }
        //[HttpPost]
        //[Route("SEND_OTP")]
        //public async Task<IHttpActionResult> SendOTP([FromBody] LOGIN login)
        //{
        //    try
        //    {
        //        Account_Repository userRepo = new Account_Repository();
        //        var result = userRepo.VerifyOTP(login);
        //        if (result.STATUS_CODE == "200")
        //        {
        //            var isMailSent = await SendMail_OTP(result.UNIQUE_ID, result.EMP_NAME);
        //            if (isMailSent)
        //            {
        //                var response = new
        //                {
        //                    MESSAGE = "Success",
        //                    STATUS_CODE = "200",
        //                    STATUS = true
        //                };
        //                return Ok(response);
        //            }
        //            else
        //            {
        //                var errorMsg = new RETURN_MESSAGE
        //                {
        //                    MESSAGE = "Error while sending Mail",
        //                    STATUS_CODE = "400",
        //                    STATUS = false
        //                };
        //                return Ok(errorMsg);
        //            }
        //        }
        //        else
        //        {
        //            var errorMessage = new RETURN_MESSAGE
        //            {
        //                MESSAGE = "No Records Found",
        //                STATUS_CODE = "400",
        //                STATUS = false
        //            };
        //            return Ok(errorMessage);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common common = new Common();
        //        common.writeData(ex.Message, "SendOTP");
        //        var errorMessage = new RETURN_MESSAGE
        //        {
        //            MESSAGE = "Error Occured",
        //            STATUS_CODE = "400",
        //            STATUS = false
        //        };
        //        return Ok(errorMessage);
        //    }
        //}

    }
}

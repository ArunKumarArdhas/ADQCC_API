using Microsoft.Extensions.Configuration;
using MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBUSINESS_LOGIC.IBusinessLogic;
using Dapper;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class AccountRepository: IAccountRepository
    {
        private readonly IConfiguration configuration;
        RETURN_MESSAGE message;
        public AccountRepository(IConfiguration configuration, RETURN_MESSAGE message)
        {
            this.configuration = configuration;
            this.message = message;
        }
        public async Task<RETURN_MESSAGE> VerifyOTP(LOGIN _Login)
        {
            try
            {
                var query = "USP_EMPLOYEE_VERIFY";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Params = new
                    {
                        Action = 1,
                        Login_User = _Login.UserName,
                        //UserName = _Login.UserName,
                        Password = _Login.Password
                    };
                    return (await connection.QueryAsync<RETURN_MESSAGE>(query, Params, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<GET_USER_DETAILS>  Get_User_Details(LOGIN _Login)
        {
            try
            {
                var query = "USP_EMPLOYEE_LOGIN";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Params = new
                    {
                        Login_User = _Login.UserName,
                        Password = _Login.Password,
                        Lang_Id = _Login.OTP
                    };
                    return (await connection.QueryAsync<GET_USER_DETAILS>(query, Params, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

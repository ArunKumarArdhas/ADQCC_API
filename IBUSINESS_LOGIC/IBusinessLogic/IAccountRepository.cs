using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IAccountRepository 
    {
        public Task<RETURN_MESSAGE> VerifyOTP(LOGIN _Login);
        public Task<GET_USER_DETAILS> Get_User_Details(LOGIN _Login);
    }
}

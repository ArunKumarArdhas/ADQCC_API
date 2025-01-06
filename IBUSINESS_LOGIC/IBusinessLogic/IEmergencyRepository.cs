using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IEmergencyRepository
    {
        Task<IEnumerable<GET_EMERGENCY_TYPE_MASTER_SELECT>> _GetEmrTeamActivate();
        Task<IEnumerable<GET_EMPLOYEE_DETAILS>> _GetSelectEmployeeLoad();
        Task<IEnumerable<GET_EMERGENCY_TYPE_TEAM>> _GetEmergencyTypeTeamList();
    }
}

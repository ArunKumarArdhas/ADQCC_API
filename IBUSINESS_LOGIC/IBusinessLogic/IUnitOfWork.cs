using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IUnitOfWork
    {
        IMasterRepository GET_LOCATION_MASTER { get; }
        IAccountRepository MAccountsRepo { get; }
        IRiskManagementRepository GET_LOCATION_RISK { get; }
        IAuditManagementRepository Audit_Management { get; }
        IEmergencyMasterRepository EmergencyMaster { get; }
        IInspectionRepository GET_INSPECT_MASTER { get; }
        IEmergencyRepository Emergency { get; }
        IEmployeeDetailsRepository EmployeeDetails { get; }
        IDrillManagementRepository mDrillManagement { get; }
        IIncidentRepository Incident { get; }
    }
}

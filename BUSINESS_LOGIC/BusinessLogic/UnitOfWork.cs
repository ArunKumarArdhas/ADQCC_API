using IBUSINESS_LOGIC.IBusinessLogic;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IMasterRepository MastersRepository
            , IAccountRepository mAccountRepository
            , IRiskManagementRepository riskManagementRepository
            , IAuditManagementRepository auditManagementRepository
            , IEmergencyMasterRepository Emergency_Master
            , IInspectionRepository InspectRepository
            , IEmergencyRepository EmergencyRepository
            , IEmployeeDetailsRepository EmployeeDetailsRepository
            , IDrillManagementRepository DrillManagement_Repository
            , IIncidentRepository IncidentRepository)
        {
            GET_LOCATION_MASTER = MastersRepository;
            MAccountsRepo = mAccountRepository;
            GET_LOCATION_RISK = riskManagementRepository;
            Audit_Management = auditManagementRepository;
            EmergencyMaster = Emergency_Master;
            GET_INSPECT_MASTER = InspectRepository;
            Emergency = EmergencyRepository;
            EmployeeDetails = EmployeeDetailsRepository;
            mDrillManagement = DrillManagement_Repository;
            Incident = IncidentRepository;
        }
        public IMasterRepository GET_LOCATION_MASTER { get; }
        public IAccountRepository MAccountsRepo { get; }
      //public IMasterRepository GET_SECTOR_DETAILS { get; }
        public IRiskManagementRepository GET_LOCATION_RISK { get; }
        public IAuditManagementRepository Audit_Management { get; }
        public IEmergencyMasterRepository EmergencyMaster { get; set; }
        public IInspectionRepository GET_INSPECT_MASTER { get; }
        public IEmergencyRepository Emergency { get; set; }
        public IEmployeeDetailsRepository EmployeeDetails { get; set; }
        public IDrillManagementRepository mDrillManagement { get; set; }
        public IIncidentRepository Incident { get; set; }
    }
}
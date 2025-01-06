using BUSINESS_LOGIC.BusinessLogic;
using IBUSINESS_LOGIC.IBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BUSINESS_LOGIC
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMasterRepository, MasterRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IRiskManagementRepository, RiskManagementRepository>();
            services.AddTransient<IAuditManagementRepository, AuditManagementRepository>();
            services.AddTransient<IEmergencyMasterRepository, EmergencyMasterRepository>();
            services.AddTransient<IInspectionRepository, InspectionRepository>();
            services.AddTransient<IEmergencyRepository, EmergencyRepository>();
            services.AddTransient<IEmployeeDetailsRepository, EmployeeDetailsRepository>();
            services.AddTransient<IDrillManagementRepository, DrillManagement_Repository>();
            services.AddTransient<IIncidentRepository, IncidentRepository>();
        }
    }
}

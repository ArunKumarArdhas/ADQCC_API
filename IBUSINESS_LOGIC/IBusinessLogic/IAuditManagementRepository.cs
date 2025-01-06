using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IAuditManagementRepository: IGenericRepository<AUDIT_TYPE_MASTER>

    {
        Task<IReadOnlyList<AUDIT_TYPE_MASTER>> GetAuditType();
        Task<RETURN_MESSAGE> AddAuditType(AUDIT_TYPE_MASTER entity);
        Task<IReadOnlyList<AUDIT_STANDARD_MASTER>> GetStandard();
        Task<RETURN_MESSAGE> AddStandard(AUDIT_STANDARD_MASTER entity);
        Task<AUDIT_TYPE_MASTER> GetAuditTypeEdit(AUDIT_TYPE_MASTER model);
        Task<AUDIT_STANDARD_MASTER> GetStandardEdit(AUDIT_STANDARD_MASTER model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IEmployeeDetailsRepository
    {
        Task<IEnumerable<GET_EMPLOYEE_DETAILS>> GetEmployeeDetails(string EMP_ID, string EMP_NAME, string EMP_DESI);
        Task<ADD_EMPLOYEE_DETAILS> AddEmployeeDetails(ADD_EMPLOYEE_DETAILS _EMPLOYEE_DETAILS);
        string Encrypt(string clearText);
        string Decrypt(string cipherText);
        Task<List<RETURN_MESSAGE>> GetEmp_Dir_BySector(string SECTOR_ID, string BUILDING_ID);
        Task<List<EMPLOYEE_PREVIEW>> GetEmployee_Preview();
        Task<List<HEALTH_VITAL_LIST>> GetHealthVitalsDetails(string EMP_ID);
        Task<List<GET_EMPLOYEE_DETAILS>> GetEmployeeFilter();
        Task<List<EMPLOYEE_MANAGER_LIST>> GetEmployee_EHSList();
        Task<List<EMPLOYEE_MANAGER_LIST>> GetEmployee_SECTION_HEAD_List();
        Task<List<EMPLOYEE_MANAGER_LIST>> GetEmployee_HSSE_List();
        Task<RETURN_MESSAGE> GetActiveDeactiveStatus(string EMP_ID, string STATUS, string PASSWORD, string USERNAME);
        Task<RETURN_MESSAGE> DeleteEmployeeDetails(string EMP_ID);
        Task<ADD_EMPLOYEE_DETAILS> EditEmployeeDetails(string EMP_ID);
    }
}

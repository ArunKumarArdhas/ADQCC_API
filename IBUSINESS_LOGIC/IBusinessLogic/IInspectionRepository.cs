using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
   public interface IInspectionRepository
    {
        #region[CHECKLIST]
        Task<IReadOnlyList<Get_Inspection>> GetCheckList();
        Task<RETURN_MESSAGE> AddCheckList(Add_Inspection objAdd);
        Task<Get_Inspection> GetCheckListByID(Get_Inspection model);

        Task<IReadOnlyList<Get_Sub_Inspection>> GetCheckListSub();
        Task<RETURN_MESSAGE> AddCheckListSub(Add_Sub_Inspection objAdd);
        Task<Get_Sub_Inspection> GetCheckListSubByID(Get_Sub_Inspection model);

        Task<IReadOnlyList<Get_Sub_Data_Inspection>> GetCheckListSubData();
        Task<RETURN_MESSAGE> AddCheckListSubData(Add_Sub_Data_Inspection objAdd);
        Task<Get_By_ID_Sub_Data_Inspection_List> GetByIDCheckListSubData(Get_By_ID_Sub_Data_Inspection_List model);
        #endregion
    }
}

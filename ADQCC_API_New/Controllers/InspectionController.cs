using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace ADQCC_API_New.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InspectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment hostingEnvironment;
        private RETURN_MESSAGE message;

        public InspectionController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }
        #region[GetCheckList]
        //GetCheckList -- GET

        [HttpGet]

        public async Task<IActionResult> GetCheckList()
        {
            var data = await _unitOfWork.GET_INSPECT_MASTER.GetCheckList();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        //checklist --- ADD
        [HttpPost]
        public async Task<IActionResult> AddCheckList(Add_Inspection objAdd)
        {
            var data = await _unitOfWork.GET_INSPECT_MASTER.AddCheckList(objAdd);
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
        public async Task<IActionResult> GetCheckListByID(Get_Inspection model)
        {
            var data = await _unitOfWork.GET_INSPECT_MASTER.GetCheckListByID(model);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        #endregion

        #region[Get_Sub_Inspection]
      
        [HttpGet]

        public async Task<IActionResult> GetCheckListSub()
        {
            var data = await _unitOfWork.GET_INSPECT_MASTER.GetCheckListSub();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }


        //Sub_Inspection -- ADD

        [HttpPost]
        public async Task<IActionResult> AddCheckListSub(Add_Sub_Inspection objAdd)
        {
            var data = await _unitOfWork.GET_INSPECT_MASTER.AddCheckListSub(objAdd);
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
        public async Task<IActionResult> GetCheckListSubByID(Get_Sub_Inspection model)
        {
            var data = await _unitOfWork.GET_INSPECT_MASTER.GetCheckListSubByID(model);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }
        #endregion

        #region[CheckListSubData]
        //Get --- CheckListSubData
        [HttpGet]
        public async Task<IActionResult> GetCheckListSubData()
        {
            var data = await _unitOfWork.GET_INSPECT_MASTER.GetCheckListSubData();
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }
        //Add --- CheckListSubData
        [HttpPost]
        public async Task<IActionResult> AddCheckListSubData(Add_Sub_Data_Inspection objAdd)
        {
            var data = await _unitOfWork.GET_INSPECT_MASTER.AddCheckListSubData(objAdd);
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
        public async Task<IActionResult> GetByIDCheckListSubData(Get_By_ID_Sub_Data_Inspection_List model)
        {
            var data = await _unitOfWork.GET_INSPECT_MASTER.GetByIDCheckListSubData(model);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);

            }
            else
            {
                message.MESSAGE = "No Records Found";
                return Ok(message);
            }

        }

        #endregion
    }
}

using CategoryLoadData.Repositories;
using CategoryLoadData.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CategoryLoadData.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoadDataController : ControllerBase
    {
        public readonly ILoadDataRepo _loadDataRepo;
        public LoadDataController(ILoadDataRepo loadDataRepo) 
        {
            _loadDataRepo = loadDataRepo;
        }

        [HttpGet]
        public async Task<IActionResult> LoadData()
        {
            var res = new ServiceResponses<LoadData_VM>();
            try
            { 
                var _ = await _loadDataRepo.LoadDataCategory();
                if (!_.status)
                {
                    res.Code = -1;
                    res.Message = _.msg;
                    res.Data = _.data;
                }
                else
                {
                    res.Code = 1;
                    res.Message = _.msg;
                    res.Data = _.data;
                }
            }
            catch (Exception ex)
            {
                res.Code = -1;
                res.Message = ex.Message.ToString();
                res.Data = new List<LoadData_VM>();
            }
            return new OkObjectResult(res);
        }
    }
}

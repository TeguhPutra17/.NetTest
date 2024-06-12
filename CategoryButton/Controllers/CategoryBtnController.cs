using CategoryButton.Repositories;
using CategoryButton.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CategoryButton.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryBtnController : ControllerBase
    {
        public readonly ICategoryButtonRepo _categoryButtonRepo;

        public CategoryBtnController(ICategoryButtonRepo categoryButtonRepo)
        {
            _categoryButtonRepo = categoryButtonRepo;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] RequestCreateCategory create) 
        {
            var res = new ServiceResponseOutput();
            try
            {
                var _ = await _categoryButtonRepo.CreateCategory(create);
                if (!_.Status)
                {
                    res.Code = _.Code;
                    res.Message = _.Message;
                    res.Status = _.Status;
                }
                else
                {
                    res.Code = _.Code;
                    res.Message = _.Message;
                    res.Status = _.Status;
                }
            }catch (Exception ex)
            {
                res.Code = 1;
                res.Message = ex.Message;
                res.Status = false;
            }
            return new OkObjectResult(res);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory([FromBody] RequestDeleteCategory delete)
        {
            var res = new ServiceResponseOutput();
            try
            {
                var _ = await _categoryButtonRepo.DeleteCategory(delete);
                if (!_.Status)
                {
                    res.Code = _.Code;
                    res.Message = _.Message;
                    res.Status = _.Status;
                }
                else
                {
                    res.Code = _.Code;
                    res.Message = _.Message;
                    res.Status = _.Status;
                }
            }
            catch (Exception ex)
            {
                res.Code = 1;
                res.Message = ex.Message;
                res.Status = false;
            }
            return new OkObjectResult(res);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory([FromBody] RequestUpdateCategory update)
        {
            var res = new ServiceResponseOutput();
            try
            {
                var _ = await _categoryButtonRepo.UpdateCategory(update);
                if (!_.Status)
                {
                    res.Code = _.Code;
                    res.Message = _.Message;
                    res.Status = _.Status;
                }
                else
                {
                    res.Code = _.Code;
                    res.Message = _.Message;
                    res.Status = _.Status;
                }
            }
            catch (Exception ex)
            {
                res.Code = 1;
                res.Message = ex.Message;
                res.Status = false;
            }
            return new OkObjectResult(res);
        }

    }
}

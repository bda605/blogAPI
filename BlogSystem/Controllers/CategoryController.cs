using BlogSystem.Model.ResponseViewModel;
using BlogSystem.Repository.Interface;
using BlogSystem.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ResponseVM<List<ResponseCategoryVM>> GetCategorys()
            => _categoryService.GetCategorys();
    }
}

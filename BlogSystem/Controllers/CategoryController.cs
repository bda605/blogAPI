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
        /// <summary>
        ///  取類別清單
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseVM<List<CategoryResponseVM>> GetCategorys()
            => _categoryService.GetCategorys();
       
        /// <summary>
        /// 新增類別
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseVM<string> AddCategory(int id,int subId,string name)
            => _categoryService.AddCategory( id,subId,name);
        /// <summary>
        /// 修改類別
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseVM<string> UpdateCategory(int id,int subId,string name)
            => _categoryService.UpdateCategory(id,subId,name);
        /// <summary>
        /// 刪除類別
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseVM<string> DeleteCategory(int id,int subId)
            => _categoryService.DeleteCategory(id,subId);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Common;
using BlogSystem.Model.ResponseViewModel;
using BlogSystem.Repository.Interface;
using BlogSystem.Service.Interface;

namespace BlogSystem.Service
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public ResponseVM<List<ResponseCategoryVM>> GetCategorys()
        {
            var response = new ResponseVM<List<ResponseCategoryVM>>();
            var result = _categoryRepository.GetAll();
            if (!result.Any())
               return response.Fail(ResponseCode.NotFound);
          
            var categorys = result.Select(x => new ResponseCategoryVM()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return response.Success(categorys);
        }
    }
}

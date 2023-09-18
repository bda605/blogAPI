using BlogSystem.Common;
using BlogSystem.Model.Entitie;
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

        public ResponseVM<string> AddCategory(string name)
        {
             var category = new Category()
             {
                 Name = name
             };
             _categoryRepository.Insert(category);
             var result = _categoryRepository.SaveChanges();
             if (result > 0)
                 return new ResponseVM<string>().Success("新增成功");
          
             return new ResponseVM<string>().Fail(ResponseCode.WriteError);
        }

        public ResponseVM<string> UpdateCategory(int id, string name)
        {
            var category = _categoryRepository.Get(x => x.Id == id).FirstOrDefault();
            if(category == null)
                return new ResponseVM<string>().Fail(ResponseCode.NotFound);

            category.Name = name;
            _categoryRepository.Update(category);
            var result = _categoryRepository.SaveChanges();
            if (result > 0)
                return new ResponseVM<string>().Success("修改成功");

            return new ResponseVM<string>().Fail(ResponseCode.WriteError);
        }

        public ResponseVM<string> DeleteCategory(int id)
        {
            var category = _categoryRepository.Get(x => x.Id == id).FirstOrDefault();
            if (category == null)
                return new ResponseVM<string>().Fail(ResponseCode.NotFound);

            _categoryRepository.Delete(category);
            var result = _categoryRepository.SaveChanges();
            if (result > 0)
                return new ResponseVM<string>().Success("刪除成功");

            return new ResponseVM<string>().Fail(ResponseCode.WriteError);
        }
    }
}

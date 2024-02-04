using System;
using System.Dynamic;
using BlogSystem.Common;
using BlogSystem.Model.Entitie;
using BlogSystem.Model.ResponseViewModel;
using BlogSystem.Repository.Interface;
using BlogSystem.Service.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace BlogSystem.Service
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMemoryCache _memoryCache;

        public CategoryService(ICategoryRepository categoryRepository, IMemoryCache memoryCache)
        {
            _categoryRepository = categoryRepository;
            _memoryCache = memoryCache;
        }

        public ResponseVM<List<CategoryResponseVM>> GetCategorys()
        {
            var response = new ResponseVM<List<CategoryResponseVM>>();
            var cacheCategorys = _memoryCache.Get<List<CategoryResponseVM>>("categorys");
            if (cacheCategorys == null)
            {
                var result = _categoryRepository.GetAll();
                if (!result.Any())
                    return response.Fail(ResponseCode.NotFound);
            
                cacheCategorys = result.Select(x => new CategoryResponseVM()
                {
                    Id = x.Id,
                    SubId = x.SubId,
                    Name = x.Name
                }).ToList();
                _memoryCache.Set("categorys", cacheCategorys, TimeSpan.FromMinutes(2));
            }
            //
            //var result = _categoryRepository.GetAll();
            //if (!result.Any())
            //   return response.Fail(ResponseCode.NotFound);

            //var categorys = result.Select(x => new CategoryResponseVM()
            //{
            //    Id = x.Id,
            //    SubId = x.SubId,
            //    Name = x.Name
            //}).ToList();

            return response.Success(cacheCategorys);
        }

        public ResponseVM<string> AddCategory(int id,int subId,string name)
        {
            var category = new Category();
            if (id > 0 && subId == 0)
            {
                var qryCategory = _categoryRepository.Get(x => x.Id == id)
                    .OrderByDescending(x => Convert.ToInt32(x.SubId)).FirstOrDefault();
                if (qryCategory != null)
                {
                    category.Id = qryCategory.Id;
                    category.SubId = qryCategory.SubId + 1;
            
                }
            }

            if (id == 0 && subId == 0)
            {
                var qryCategory = _categoryRepository.Get(x => x.SubId == 0)
                    .OrderByDescending(x=>Convert .ToInt32(x.Id)).FirstOrDefault();
                category.Id = 1;
                category.SubId = subId;
                category.Name = name;
                if (qryCategory != null)
                {
                    category.Id = qryCategory.Id +1;
                    category.SubId = subId;
                }
            }
            category.Name = name;
            category.CreatedDate= DateTime.Now;
            category.UpdatedDate = DateTime.Now;
            _categoryRepository.Insert(category);
             var result = _categoryRepository.SaveChanges();
             if (result > 0)
                 return new ResponseVM<string>().Success("新增成功");
          
             return new ResponseVM<string>().Fail(ResponseCode.WriteError);
        }

        public ResponseVM<string> UpdateCategory(int id, int subId, string name)
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

        public ResponseVM<string> DeleteCategory(int id,int subId)
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

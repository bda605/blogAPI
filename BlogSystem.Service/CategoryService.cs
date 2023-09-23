﻿using System.Dynamic;
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

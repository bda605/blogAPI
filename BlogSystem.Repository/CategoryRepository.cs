using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Model;
using BlogSystem.Model.Entitie;
using BlogSystem.Repository.Interface;

namespace BlogSystem.Repository
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(BlogContext context) : base(context)
        {
                
        }


    }
}

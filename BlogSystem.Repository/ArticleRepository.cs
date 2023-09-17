using BlogSystem.Model.Entitie;
using BlogSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Model;

namespace BlogSystem.Repository
{
    public class ArticleRepository: GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(BlogContext context) : base(context)
        {
        }
    }
}

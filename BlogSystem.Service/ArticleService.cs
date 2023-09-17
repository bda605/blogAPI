using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Model.ResponseViewModel;
using BlogSystem.Repository.Interface;
using BlogSystem.Service.Interface;

namespace BlogSystem.Service
{
    public class ArticleService:IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


    }
}

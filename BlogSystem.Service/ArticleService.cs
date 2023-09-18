using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Common;
using BlogSystem.Model.RequestViewModel;
using BlogSystem.Model.ResponseViewModel;
using BlogSystem.Repository;
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

        public ResponseVM<string> AddArticle(RequestArticleVM requestArticle)
        {
            var response = new ResponseVM<string>();
            return response.Success();
        }

        public ResponseVM<string> DeleteArticle(int id)
        {
            var article = _articleRepository.Get(x => x.Id == id).FirstOrDefault();
            if (article == null)
            {
                return new ResponseVM<string>().Fail(ResponseCode.NotFound);
            }
            _articleRepository.Delete(article);
            var result = _articleRepository.SaveChanges();
            if (result > 0)
                return new ResponseVM<string>().Success("刪除成功");

            return new ResponseVM<string>().Fail(ResponseCode.WriteError);
        }
    }
}

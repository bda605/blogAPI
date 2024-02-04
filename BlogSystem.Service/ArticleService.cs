using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using BlogSystem.Common;
using BlogSystem.Model.Entitie;
using BlogSystem.Model.RequestViewModel;
using BlogSystem.Model.ResponseViewModel;
using BlogSystem.Repository;
using BlogSystem.Repository.Interface;
using BlogSystem.Service.Interface;

namespace BlogSystem.Service
{
    public class ArticleService:IArticleService
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;
        
        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public ResponseVM<List<ArticleResponseVM>> GetArticles()
        {
            var responseArticles = _articleRepository.GetAll().Select(x => new ArticleResponseVM()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content
            }).ToList();
            
            if(responseArticles.Any())
                return new ResponseVM<List<ArticleResponseVM>>().Fail(ResponseCode.NotFound);

            return new ResponseVM<List<ArticleResponseVM>>().Success(responseArticles);
        }

        public ResponseVM<ArticleResponseVM> GetArticle(int id)
        {
            var responseArticle = _articleRepository.Get(x => x.Id == id).Select(x => new ArticleResponseVM()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content
            }).FirstOrDefault();

            if (responseArticle == null)
                return new ResponseVM<ArticleResponseVM>().Fail(ResponseCode.NotFound);
             
            return new ResponseVM<ArticleResponseVM>().Success();
        }

        public ResponseVM<string> AddArticle(ArticleRequestVM articleRequest)
        {
            var article = _mapper.Map<Article>(articleRequest);
            article.CreatedDate = DateTime.Now;
            article.UpdatedDate = DateTime.Now;
            _articleRepository.Insert(article);
            var result = _articleRepository.SaveChanges();

            if (result > 0)
                return new ResponseVM<string>().Success("新增成功");

            return new ResponseVM<string>().Fail(ResponseCode.WriteError);
        }

        public ResponseVM<string> UpdateArticle(ArticleRequestVM articleRequest)
        {
            var response = new ResponseVM<string>();
            var data = _articleRepository.Get(x => x.Id == articleRequest.Id).FirstOrDefault();
            if(data == null)
                return new ResponseVM<string>().Fail(ResponseCode.NotFound);
            var article = _mapper.Map<Article>(articleRequest);
            _articleRepository.Update(article);
            var result = _articleRepository.SaveChanges();
            if (result > 0)
                return new ResponseVM<string>().Success("修改成功");

            return new ResponseVM<string>().Fail(ResponseCode.WriteError);
        }

        public ResponseVM<string> DeleteArticle(int id)
        {
            var article = _articleRepository.Get(x => x.Id == id).FirstOrDefault();
            
            if (article == null)
                return new ResponseVM<string>().Fail(ResponseCode.NotFound);
            
            _articleRepository.Delete(article);
            var result = _articleRepository.SaveChanges();
            if (result > 0)
                return new ResponseVM<string>().Success("刪除成功");

            return new ResponseVM<string>().Fail(ResponseCode.WriteError);
        }
    }
}

using BlogSystem.Model.ResponseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Model;
using BlogSystem.Model.RequestViewModel;

namespace BlogSystem.Service.Interface
{
    public interface IArticleService
    {
        ResponseVM<List<ArticleResponseVM>> GetArticles();

        ResponseVM<ArticleResponseVM> GetArticle(int id);
        ResponseVM<string> AddArticle(ArticleRequestVM articleRequest);

        ResponseVM<string> UpdateArticle(ArticleRequestVM articleRequest);

        ResponseVM<string> DeleteArticle(int id);
    }
}

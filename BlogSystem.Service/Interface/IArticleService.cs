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
        //ResponseVM<List<ResponseCategoryVM>> GetArticles();

        ResponseVM<string> AddArticle(RequestArticleVM requestArticle);

        ResponseVM<string> UpdateArticle(RequestArticleVM requestArticle);

        ResponseVM<string> DeleteArticle(int id);
    }
}

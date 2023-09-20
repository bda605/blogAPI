using BlogSystem.Model.RequestViewModel;
using BlogSystem.Model.ResponseViewModel;
using BlogSystem.Service;
using BlogSystem.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly  IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseVM<string> AddArticle(RequestArticleVM requestArticle)
            => _articleService.AddArticle(requestArticle);
        /// <summary>
        /// 修改類別
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseVM<string> UpdateArticle(RequestArticleVM requestArticle)
            => _articleService.UpdateArticle(requestArticle);
        /// <summary>
        /// 刪除類別
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseVM<string> DeleteArticle(int id)
            => _articleService.DeleteArticle(id);
    }
}

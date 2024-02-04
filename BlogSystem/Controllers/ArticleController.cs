using BlogSystem.Model.RequestViewModel;
using BlogSystem.Model.ResponseViewModel;
using BlogSystem.Service.Interface;
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
        /// <param name="articleRequestVmArticle"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseVM<string> AddArticle(ArticleRequestVM articleRequestVmArticle)
            => _articleService.AddArticle(articleRequestVmArticle);
        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="articleRequestVmArticle"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseVM<string> UpdateArticle(ArticleRequestVM articleRequestVmArticle)
            => _articleService.UpdateArticle(articleRequestVmArticle);

        /// <summary>
        /// 刪除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseVM<string> DeleteArticle(int id)
            => _articleService.DeleteArticle(id);
    }
}

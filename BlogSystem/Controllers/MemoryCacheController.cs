using BlogSystem.Model.ResponseViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BlogSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemoryCacheController : ControllerBase
    {
        private IMemoryCache _memoryCache { get; set; }

        public MemoryCacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public ResponseVM<Dictionary<string, string>> GetDateTime()
        {
            var response = new ResponseVM<Dictionary<string, string>>();
            DateTime cacheEntry;
            if (!_memoryCache.TryGetValue("CachKey", out cacheEntry))
            {
                cacheEntry = DateTime.Now;
                // 設定Cache選項
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // 設定Cache保存時間，如果有存取到就會刷新保存時間
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60));
                // 把資料除存進Cache中
                _memoryCache.Set("CachKey", cacheEntry, cacheEntryOptions);
            }
            return response.Success(new Dictionary<string, string>()
            {
                {"現在時間", DateTime.Now.ToString()},
                {"快取內容", cacheEntry.ToString()}
            });
        }
    }
}

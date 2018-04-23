using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SampleCoreWebApi.Cache;

namespace SampleCoreWebApi.Controllers
{
    public class BaseController : Controller
    {
        private readonly IMemoryCache _cache;
        public BaseController() { }
        public BaseController(IMemoryCache cache)
        {
            _cache = cache;
        }


        [NonAction]
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallBack)
        {
            var item = _cache.Get<T>(cacheKey);
            if (item == null)
            {
                item = getItemCallBack();
                _cache.Set(cacheKey, item, CacheKeysWithOption.CacheOption);
            }
            return item;
        }
    }
}
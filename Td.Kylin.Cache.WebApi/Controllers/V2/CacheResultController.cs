using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Td.Kylin.Cache.WebApi.Core;
using Td.Kylin.Cache.WebApi.Models;
using Td.Kylin.WebApi;

namespace Td.Kylin.Cache.WebApi.Controllers
{
    public class CacheResultController : BaseController
    {
        public IActionResult Result<T>(CacheType cacheType, IEnumerable<T> data) where T : class, new()
        {
            var result = new CacheResult<T>();

            var config = CacheConfigs.GetConfig(cacheType);

            result.CacheMinutes = config.Minutes;
            result.Level = config.Level;

            result.Data = data;

            return Success(result);
        }
    }
}

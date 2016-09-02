using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Td.Kylin.Cache.WebApi.Models;
using Td.Kylin.DataCache;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.WebApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Td.Kylin.Cache.WebApi.Controllers.V1
{
    /// <summary>
    /// 商家行业接口
    /// </summary>
    [Route("api/merchantindustry")]
    [ApiAuthorization(Code = Role.Use)]
    public class MerchantIndustryController : BaseController
    {
        /// <summary>
        /// 获取商家行业
        /// </summary>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values()
        {
            var data = CacheCollection.MerchantIndustryCache.Value();

            List<MerchantIndustry> list = new List<MerchantIndustry>();

            if (null != data)
            {
                list = (from p in data
                        select new MerchantIndustry
                        {
                            IndustryID = p.IndustryID,
                            ParentID = p.ParentID,
                            Icon = p.Icon,
                            Name = p.Name
                        }).ToList();
            }

            return Success(list);
        }
    }
}

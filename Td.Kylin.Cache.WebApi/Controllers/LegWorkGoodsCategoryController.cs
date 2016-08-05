using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Td.Kylin.Cache.WebApi.Models;
using Td.Kylin.DataCache;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.WebApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Td.Kylin.Cache.WebApi.Controllers
{
    /// <summary>
    /// 跑腿物品类型接口
    /// </summary>
    [Route("api/legworkgoodscategory")]
    [ApiAuthorization(Code = Role.Use)]
    public class LegWorkGoodsCategoryController : BaseController
    {
        /// <summary>
        /// 获取所有跑腿物品类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values()
        {
            var data = CacheCollection.LegworkGoodsCategoryCache.Value();

            List<LegworkGoodsCategory> list = new List<LegworkGoodsCategory>();

            if (null != data)
            {
                list = (from p in data
                        select new LegworkGoodsCategory
                        {
                            CategoryID = p.CategoryID,
                            Name = p.Name
                        }).ToList();
            }

            return Success(list);
        }
    }
}

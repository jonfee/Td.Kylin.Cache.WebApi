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
    /// 区域推荐行业接口
    /// </summary>
    [Route("api/arearecommendindustry")]
    [ApiAuthorization(Code = Role.Use)]
    public class AreaRecommendIndustryController : BaseController
    {
        /// <summary>
        /// 获取区域开通推荐的行业
        /// </summary>
        /// <param name="allArea">是否全部区域数据</param>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values(bool allArea = true)
        {
            var data = CacheCollection.AreaRecommendIndustryCache.Value();

            List<AreaRecommendIndustry> list = new List<AreaRecommendIndustry>();

            if (null != data)
            {
                var query = from p in data
                            select new AreaRecommendIndustry
                            {
                                AreaID = p.AreaID,
                                IndustryID = p.IndustryID,
                                OrderNo = p.OrderNo,
                                RecommendType = p.RecommendType
                            };

                if (!allArea)
                {
                    query = query.Where(p => p.AreaID == Location.OperatorArea);
                }

                list = query.ToList();
            }

            return Success(list);
        }
    }
}

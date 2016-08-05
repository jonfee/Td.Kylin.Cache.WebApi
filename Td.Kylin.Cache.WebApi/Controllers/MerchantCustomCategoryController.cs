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
    /// 商家自定义分类接口
    /// </summary>
    [Route("api/merchantcustomcategory")]
    [ApiAuthorization(Code = Role.Use)]
    public class MerchantCustomCategoryController : BaseController
    {
        /// <summary>
        /// 获取商家自定义分类
        /// </summary>
        /// <param name="merchantID">指定商家的自定义分类</param>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values(long? merchantID)
        {
            var data = CacheCollection.MerchantCustomCategoryCache.Value();

            List<MerchantCustomCategory> list = new List<MerchantCustomCategory>();

            if (null != data)
            {
                var query = from p in data
                            select new MerchantCustomCategory
                            {
                                CategoryID = p.CategoryID,
                                MerchantID = p.MerchantID,
                                Name = p.Name,
                                OrderNo = p.OrderNo
                            };

                if (merchantID.HasValue && merchantID.Value > 0)
                {
                    query = query.Where(p => merchantID == merchantID.Value);
                }

                list = query.ToList();
            }

            return Success(list);
        }
    }
}

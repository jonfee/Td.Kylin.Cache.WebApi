using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Td.Kylin.Cache.WebApi.Models;
using Td.Kylin.DataCache;
using Td.Kylin.WebApi;
using Td.Kylin.WebApi.Filters;
using Td.Kylin.WebApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Td.Kylin.Cache.WebApi.Controllers.V2
{
    /// <summary>
    /// 商家商品系统分类接口
    /// </summary>
    [Route("v2/merchantproductsyscategory")]
    [ApiAuthorization(Code = Role.Use)]
    public class MerchantProductSysCategoryController : CacheResultController
    {
        /// <summary>
        /// 获取商家商品系统分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values()
        {
            var data = CacheCollection.MerchantProductSystemCategoryCache.Value();

            List<MerchantProductSysCategory> list = new List<MerchantProductSysCategory>();

            if (null != data)
            {
                list = (from p in data
                        select new MerchantProductSysCategory
                        {
                            CategoryID = p.CategoryID,
                            ParentID = p.ParentCategoryID,
                            Icon = p.Icon,
                            Name = p.Name
                        }).ToList();
            }

            return Result(Core.CacheType.MerchantProductSysCategory, list);
        }
    }
}

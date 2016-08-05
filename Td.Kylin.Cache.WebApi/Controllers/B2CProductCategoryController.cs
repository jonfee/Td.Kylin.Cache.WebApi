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
    /// 精品汇商品分类
    /// </summary>
    [Route("api/b2cproductcategory")]
    [ApiAuthorization(Code = Role.Use)]
    public class B2CProductCategoryController : BaseController
    {
        /// <summary>
        /// 获取精品汇商品分类
        /// </summary>
        /// <param name="allArea">是否全部区域数据</param>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values(bool allArea = true)
        {
            var data = CacheCollection.B2CProductCategoryCache.Value();

            List<B2CProductCategory> list = new List<B2CProductCategory>();

            if (null != data)
            {
                var query = from p in data
                            select new B2CProductCategory
                            {
                                AreaID = p.AreaID,
                                CategoryID = p.CategoryID,
                                Icon = p.Ico,
                                Name = p.Name,
                                OrderNo = p.OrderNo
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

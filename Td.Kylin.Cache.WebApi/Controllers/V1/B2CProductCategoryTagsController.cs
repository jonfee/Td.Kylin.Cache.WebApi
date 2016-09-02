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
    /// 精品汇商品分类标签接口
    /// </summary>
    [Route("api/b2cproductcategorytags")]
    [ApiAuthorization(Code = Role.Use)]
    public class B2CProductCategoryTagsController : BaseController
    {
        /// <summary>
        /// 获取精品汇商品分类标签
        /// </summary>
        /// <param name="allArea">是否全部区域数据</param>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values(bool allArea = true)
        {
            var data = CacheCollection.B2CProductCategoryTagCache.Value();

            List<B2CProductCategoryTags> list = new List<B2CProductCategoryTags>();

            if (null != data)
            {
                var query = from p in data
                            select new B2CProductCategoryTags
                            {
                                CategoryID = p.CategoryID,
                                TagID = p.TagID,
                                TagName = p.TagName,
                                OrderNo = p.OrderNo
                            };

                if (!allArea)
                {
                    //找出当前区域的所有分类ID
                    var cateIds = CacheCollection.B2CProductCategoryCache.Value().Where(p => p.AreaID == Location.OperatorArea).Select(p => p.CategoryID).ToArray();

                    query = query.Where(p => cateIds.Contains(p.CategoryID));
                }

                list = query.ToList();
            }

            return Success(list);
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
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
    /// 社区圈子分类接口
    /// </summary>
    [Route("v2/forumcategory")]
    [ApiAuthorization(Code = Role.Use)]
    public class ForumCategoryController : CacheResultController
    {
        /// <summary>
        /// 获取所有圈子分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values()
        {
            var data = CacheCollection.ForumCategoryCache.Value();

            List<ForumCategory> list = new List<ForumCategory>();

            if (null != data)
            {
                list = (from p in data
                        select new ForumCategory
                        {
                            CategoryID = p.CategoryID,
                            Name = p.Name,
                            OrderNo = p.OrderNo
                        }).ToList();
            }

            return Result(Core.CacheType.ForumCategory, list);
        }
    }
}

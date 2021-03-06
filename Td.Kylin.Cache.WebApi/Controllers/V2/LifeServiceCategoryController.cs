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
    /// 生活服务分类接口
    /// </summary>
    [Route("v2/lifeservicecategory")]
    [ApiAuthorization(Code = Role.Use)]
    public class LifeServiceCategoryController : CacheResultController
    {
        /// <summary>
        /// 获取生活服务分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values()
        {
            var data = CacheCollection.LifeServiceSystemCategoryCache.Value();

            List<LifeServiceCategory> list = new List<LifeServiceCategory>();

            if (null != data)
            {
                list = (from p in data
                        select new LifeServiceCategory
                        {
                            CategoryID = p.CategoryID,
                            ParentID = p.ParentCategoryID,
                            Name = p.Name
                        }).ToList();
            }

            return Result(Core.CacheType.LifeServiceCategory, list);
        }
    }
}

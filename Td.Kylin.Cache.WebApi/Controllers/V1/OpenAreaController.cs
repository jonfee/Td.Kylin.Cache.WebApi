﻿using Microsoft.AspNetCore.Mvc;
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
    /// 开通区域接口
    /// </summary>
    [Route("api/openarea")]
    [ApiAuthorization(Code = Role.Use)]
    public class OpenAreaController : BaseController
    {
        /// <summary>
        /// 获取所有开通区域
        /// </summary>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values()
        {
            var data = CacheCollection.OpenAreaCache.Value();

            List<OpenArea> list = new List<OpenArea>();

            if (null != data)
            {
                list = (from p in data
                        where p.Status == true
                        select new OpenArea
                        {
                            AreaID = p.AreaID,
                            AreaName = p.AreaName
                        }).ToList();
            }

            return Success(list);
        }
    }
}

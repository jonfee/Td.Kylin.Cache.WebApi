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
    /// 职位类别接口
    /// </summary>
    [Route("v2/jobcategory")]
    [ApiAuthorization(Code = Role.Use)]
    public class JobCategoryController : CacheResultController
    {
        /// <summary>
        /// 获取所有职位类别
        /// </summary>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values()
        {
            var data = CacheCollection.JobCategoryCache.Value();

            List<JobCategory> list = new List<JobCategory>();

            if (null != data)
            {
                list = (from p in data
                        select new JobCategory
                        {
                            CategoryID = p.CategoryID,
                            Name = p.Name,
                            OrderNo = p.OrderNo,
                            ParentID = p.ParentID,
                            TagStatus = p.TagStatus
                        }).ToList();
            }

            return Result(Core.CacheType.JobCategory, list);
        }
    }
}

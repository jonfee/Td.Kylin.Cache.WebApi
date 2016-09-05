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
    /// 区域圈子接口
    /// </summary>
    [Route("api/areaforum")]
    [ApiAuthorization(Code = Role.Use)]
    public class AreaForumController : BaseController
    {
        /// <summary>
        /// 获取区域圈子
        /// </summary>
        /// <param name="allArea">是否全部区域数据</param>
        /// <returns></returns>
        [HttpGet("values")]
        public IActionResult Values(bool allArea = true)
        {
            var data = CacheCollection.AreaForumCache.Value();

            List<AreaForum> list = new List<AreaForum>();

            if (null != data)
            {
                var query = from p in data
                            select new AreaForum
                            {
                                AreaID = p.AreaID,
                                AreaForumID = p.AreaForumID,
                                ForumName = p.AliasName,
                                CategoryID = p.CategoryID,
                                Description = p.Description,
                                ForumID = p.ForumID,
                                Logo = p.Logo,
                                OrderNo = p.OrderNo,
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

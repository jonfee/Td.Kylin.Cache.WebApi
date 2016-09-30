using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Td.Kylin.WebApi;
using System.Linq;
using System;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Td.Kylin.Cache.WebApi.Controllers
{
    [Route("api/checkversion")]
    public class CheckVersionController : BaseController
    {
        /// <summary>
        /// 检测APP是否需要强制更新
        /// </summary>
        /// <param name="appcode">APP编号</param>
        /// <param name="version">当前版本</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CheckVersion(string appcode, string version)
        {
            if (string.IsNullOrWhiteSpace(appcode)) appcode = string.Empty;
            if (string.IsNullOrWhiteSpace(version)) version = string.Empty;

            appcode = appcode.ToLower();

            AppVersion item = null;

            try
            {
                if (AppVersionCache.AllVersion.ContainsKey(appcode))
                {
                    Version currentVersion = new Version(version);

                    var data = AppVersionCache.AllVersion[appcode]?.Where(p => new Version(p.Version) > currentVersion).ToList();

                    if (data != null && data.Count > 0)
                    {
                        //是否有需要强制更新的版本
                        bool isForcedUpgrade = data.Any(p => p.IsForcedUpgrade);

                        //最高的版本号
                        var lastVersion = data.OrderByDescending(p => new Version(p.Version)).FirstOrDefault();

                        item = new AppVersion
                        {
                            Version = lastVersion.Version,
                            Url = lastVersion.Url,
                            IsForcedUpgrade = isForcedUpgrade,
                            Log = lastVersion.Log
                        };
                    }
                }
            }
            catch
            {
                item = null;
            }

            if (item == null)
            {
                item = new AppVersion
                {
                    Version = version,
                    IsForcedUpgrade = false,
                    Url = "",
                    Log = ""
                };
            }

            return Success(item);
        }
    }
}

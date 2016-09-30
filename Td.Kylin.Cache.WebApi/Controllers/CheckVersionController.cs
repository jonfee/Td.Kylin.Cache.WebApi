using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Td.Kylin.WebApi;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Td.Kylin.Cache.WebApi.Controllers
{
    [Route("api/checkversion")]
    public class CheckVersionController : BaseController
    {
        [HttpGet]
        public IActionResult CheckVersion(string appcode)
        {
            if (string.IsNullOrWhiteSpace(appcode)) appcode = string.Empty;

            appcode = appcode.ToLower();

            List<AppVersion> data = new List<AppVersion>();

            try
            {
                if (AppVersionCache.AllVersion.ContainsKey(appcode))
                {
                    data = AppVersionCache.AllVersion[appcode];
                }
            }
            catch
            {
                data = null;
            }

            return Success(data);
        }
    }
}

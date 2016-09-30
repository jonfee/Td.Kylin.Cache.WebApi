using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Td.Kylin.Cache.WebApi
{
    public static class AppVersionCache
    {
        private static Dictionary<string, List<AppVersion>> _allVersion;

        private readonly static object _locker = new object();

        private static DateTime LastUpdateTime = DateTime.Now.AddYears(-1);

        public static Dictionary<string, List<AppVersion>> AllVersion
        {
            get
            {
                if (_allVersion == null || LastUpdateTime.AddMinutes(30) < DateTime.Now)
                {
                    lock (_locker)
                    {
                        if (_allVersion == null || LastUpdateTime.AddMinutes(30) < DateTime.Now)
                        {
                            _allVersion = GetVersion();

                            LastUpdateTime = DateTime.Now;
                        }
                    }
                }

                return _allVersion;
            }
        }

        private static Dictionary<string, List<AppVersion>> GetVersion()
        {
            Dictionary<string, List<AppVersion>> dic = new Dictionary<string, List<AppVersion>>();

            try
            {
                string xmlPath = Path.Combine(AppContext.BaseDirectory, "appversion.xml");

                XElement xe = XElement.Load(xmlPath);

                //获取客户端
                IEnumerable<XElement> apps = from em in xe.Elements("app")
                                             select em;

                foreach (var app in apps)
                {
                    string appCode = app.Attribute("code").Value;

                    List<AppVersion> versionList = new List<AppVersion>();

                    foreach (var vs in app.Elements("version"))
                    {
                        var version = vs.Attribute("code").Value;

                        bool isForcedUpgrade = Convert.ToBoolean(vs.Attribute("isForcedUpgrade").Value);

                        string url = vs.Attribute("url").Value;

                        string log = vs.Value;

                        versionList.Add(new AppVersion
                        {
                            Version = version,
                            IsForcedUpgrade = isForcedUpgrade,
                            Url = url,
                            Log = log
                        });
                    }

                    dic.Add(appCode.ToLower(), versionList);
                }
            }
            catch
            {
                dic = new Dictionary<string, List<AppVersion>>();
            }

            return dic;
        }
    }

    public class AppVersion
    {
        public string Version { get; set; }

        public bool IsForcedUpgrade { get; set; }

        public string Url { get; set; }

        public string Log { get; set; }
    }
}

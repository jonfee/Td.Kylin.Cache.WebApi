using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Td.Kylin.Cache.WebApi.Core
{
    public class CacheConfigs
    {
        /// <summary>
        /// 单个缓存配置项
        /// </summary>
        public class ItemConfig
        {
            /// <summary>
            /// 缓存等级
            /// </summary>
            public int Level { get; set; }

            /// <summary>
            /// 缓存时间
            /// </summary>
            public int Minutes { get; set; }
        }

        /// <summary>
        /// 缓存数据类型名称及配置键值集合
        /// </summary>
        private static readonly IDictionary<string, ItemConfig> Configs;

        static CacheConfigs()
        {
            Configs = new ConcurrentDictionary<string, ItemConfig>();

            foreach (var name in Enum.GetNames(typeof(CacheType)))
            {
                string levelKey = string.Format(@"Cache:{0}:Level", name);
                string minutesKey = string.Format(@"Cache:{0}:Minutes", name);

                var minutes = int.Parse(Startup.Configuration[minutesKey]);
                var level = int.Parse(Startup.Configuration[levelKey]);

                Configs.Add(name, new ItemConfig { Level = level, Minutes = minutes });
            }
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="cacheType"><see cref="CacheType"/>枚举</param>
        /// <returns></returns>
        public static ItemConfig GetConfig(CacheType cacheType)
        {
            var name = cacheType.ToString();

            if (Configs.ContainsKey(name))
            {
                return Configs[name];
            }

            return new ItemConfig { Level = 0, Minutes = 1 };
        }
    }
}

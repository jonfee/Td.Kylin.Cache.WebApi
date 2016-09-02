using System.Collections.Generic;

namespace Td.Kylin.Cache.WebApi.Models
{
    /// <summary>
    /// 缓存结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CacheResult<T> where T : class, new()
    {
        /// <summary>
        /// 缓存级别
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 缓存时间
        /// </summary>
        public int CacheMinutes { get; set; }

        /// <summary>
        /// 缓存数据
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }
}

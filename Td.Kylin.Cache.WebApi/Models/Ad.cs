using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Td.Kylin.Cache.WebApi.Models
{
    /// <summary>
    /// 广告
    /// </summary>
    public class Ad
    {
        /// <summary>
        ///  广告位展示类型 （枚举)
        /// </summary>
        public int ADDisplayType { get; set; }
        /// <summary>
        /// 广告位编码
        /// </summary>
        public string AdCode { get; set; }
        /// <summary>
        /// 链接到的数据或外链地址
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 广告数据文件
        /// </summary>
        public string AdFile { get; set; }
        /// <summary>
        /// 广告数据类型（枚举：ADType）
        /// </summary>
        public int ADType { get; set; }
        /// <summary>
        ///  链接类型（枚举：AdLinkType）
        /// </summary>
        public int Type { get; set; }
    }
}

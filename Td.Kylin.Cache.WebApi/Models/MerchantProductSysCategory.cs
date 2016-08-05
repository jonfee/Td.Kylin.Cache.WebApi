namespace Td.Kylin.Cache.WebApi.Models
{
    /// <summary>
    /// 商家商品系统分类
    /// </summary>
    public class MerchantProductSysCategory
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        public long CategoryID { get; set; }
        /// <summary>
        /// 父ID（1级为0）
        /// </summary>
        public long ParentID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
    }
}

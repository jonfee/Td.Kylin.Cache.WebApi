namespace Td.Kylin.Cache.WebApi.Models
{
    /// <summary>
    /// 商家商品自定义分类
    /// </summary>
    public class MerchantCustomCategory
    {
        /// <summary>
        /// 自定义分类ID
        /// </summary>
        public long CategoryID { get; set; }
        /// <summary>
        /// 自定义商品分类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public long MerchantID { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int OrderNo { get; set; }
    }
}

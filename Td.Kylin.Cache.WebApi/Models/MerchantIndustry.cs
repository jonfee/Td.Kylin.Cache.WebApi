namespace Td.Kylin.Cache.WebApi.Models
{
    /// <summary>
    /// 商家行业
    /// </summary>
    public class MerchantIndustry
    {
        /// <summary>
        /// 行业ID
        /// </summary>
        public long IndustryID { get; set; }
        /// <summary>
        /// 行业名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public long ParentID { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
    }
}

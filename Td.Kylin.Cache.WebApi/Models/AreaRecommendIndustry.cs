namespace Td.Kylin.Cache.WebApi.Models
{
    /// <summary>
    /// 区域行业推荐(热门)
    /// </summary>
    public class AreaRecommendIndustry
    {
        /// <summary>
        /// 区域ID
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 行业ID
        /// </summary>
        public long IndustryID { get; set; }
        /// <summary>
        /// 推荐状态（枚举：AreaIndustryRecommend，以2的N次方值和存储）
        /// </summary>
        public int RecommendType { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int OrderNo { get; set; }
    }
}

namespace Td.Kylin.Cache.WebApi.Models
{
    /// <summary>
    /// 区域精品汇商品分类
    /// </summary>
    public class B2CProductCategory
    {
        /// <summary>
        /// 区域ID
        /// </summary>
        public long AreaID { get; set; }
        /// <summary>
        /// 商品分类ID
        /// </summary>
        public long CategoryID { get; set; }
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 分类图标路径地址
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int OrderNo { get; set; }
    }
}

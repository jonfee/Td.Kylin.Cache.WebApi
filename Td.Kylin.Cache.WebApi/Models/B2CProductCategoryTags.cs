namespace Td.Kylin.Cache.WebApi.Models
{
    /// <summary>
    /// 区域精品汇商品分类标签
    /// </summary>
    public class B2CProductCategoryTags
    {
        ///<summary>
        ///标签ID
        ///</summary>
        public long TagID { get; set; }

        ///<summary>
        ///商品类目ID
        ///</summary>
        public long CategoryID { get; set; }

        ///<summary>
        ///商品标签名称
        ///</summary>
        public string TagName { get; set; }

        ///<summary>
        ///排序值
        ///</summary>
        public int OrderNo { get; set; }
    }
}

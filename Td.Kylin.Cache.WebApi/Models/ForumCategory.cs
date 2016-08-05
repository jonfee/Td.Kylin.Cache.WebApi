namespace Td.Kylin.Cache.WebApi.Models
{
    /// <summary>
    /// 圈子分类
    /// </summary>
    public class ForumCategory
    {
        ///<summary>
        ///论坛分类ID
        ///</summary>
        public long CategoryID { get; set; }

        ///<summary>
        ///论坛分类名称
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///论坛分类排序
        ///</summary>
        public int OrderNo { get; set; }
    }
}

namespace Td.Kylin.Cache.WebApi.Models
{
    /// <summary>
    /// 岗位类别
    /// </summary>
    public class JobCategory
    {
        /// <summary>
        /// 岗位分类ID
        /// </summary>
        public long CategoryID { get; set; }
        /// <summary>
        /// 岗位分类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public long ParentID { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public long OrderNo { get; set; }
        /// <summary>
        /// 标识状态集
        /// </summary>
        public int TagStatus { get; set; }
    }
}

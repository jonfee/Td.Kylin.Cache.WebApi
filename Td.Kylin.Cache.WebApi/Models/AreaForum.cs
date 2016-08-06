namespace Td.Kylin.Cache.WebApi.Models
{
    /// <summary>
    /// 区域圈子
    /// </summary>
    public class AreaForum
    {
        /// <summary>
        /// 区域ID
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 区域圈子ID
        /// </summary>
        public long AreaForumID { get; set; }
        /// <summary>
        /// 圈子名称
        /// </summary>
        public string ForumName { get; set; }
        /// <summary>
        /// 所属类目ID
        /// </summary>
        public long CategoryID { get; set; }
        /// <summary>
        /// 系统圈子ID
        /// </summary>
        public long ForumID { get; set; }
        /// <summary>
        /// 圈子Logo地址
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// 圈子描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int OrderNo { get; set; }
    }

}

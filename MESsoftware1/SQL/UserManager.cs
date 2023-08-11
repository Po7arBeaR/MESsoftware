using SqlSugar;
using System;

namespace EntityOfSql
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Serializable]
    public class UserManagerment
    {
        #region 实体属性

        /// <summary>
        /// 编号
        /// </summary>
        /// 
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int? ID { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardId { get; set; }


        /// <summary>
        /// 权限登记
        /// </summary>

        public string Character { get; set; }

        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }

    
      

        #endregion
    }
}
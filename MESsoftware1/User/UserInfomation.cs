using EntityOfSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MouseKeyboardActivityMonitor.WinApi;
using MouseKeyboardActivityMonitor;
using System.Diagnostics;
using System.Threading;
using MESsoftware1.SQL;
using System.ComponentModel;

namespace ConfigInfomation
{

    /// <summary>
    /// 扩展项处理，用于操作时间，以及超时分钟数【10分钟不操作就锁屏】等
    /// </summary>
    public class ExtensionGlobalUtil
    {
        /// <summary>
        /// 当前用户信息
        /// </summary>
        public static UserManagerment CurrentUserInfo { get; set; }
        /// <summary>
        /// 最近一次操作时间
        /// </summary>
        public static DateTime LastOperateTime { get; set; }

        /// <summary>
        /// 超时分钟数【10分钟不操作就锁屏】
        /// 如果小于等于0，则忽略该项
        /// </summary>
        public  static double  AdminTimeoutMinute { get; set; }
        /// <summary>
        /// 超时分钟数【10分钟不操作就锁屏】
        /// 如果小于等于0，则忽略该项
        /// </summary>
        public  static bool LoggingStatus { get; set; }

        public static RoleManage RoleManage { get; set; }
        
    }

    public enum CharacterType
    {
        [Description("管理员")]
        管理员=5,
        [Description("PE")]
        PE=4,
        [Description("ME")]
        ME=3,
        [Description("OPN技师")]
        OPN技师 = 2,
        [Description("OPN操作员")]
        OPN操作员 = 1
    }

}
    
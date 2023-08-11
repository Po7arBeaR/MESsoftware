using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventType
{
    public class EventBindPara
    {
        /// <summary>
        /// 触发
        /// </summary>
        public string Trig { get; set; }
        /// <summary>
        /// 回复，反馈
        /// </summary>
        public string Feedback { get; set; }
        /// <summary>
        /// 事件编号，第几组【触发-反馈】信号，从1开始
        /// </summary>
        public int EventNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace ProcessPLC
    {
        /// <summary>
        /// 数据信号地址配置
        /// </summary>
        public class DataSignalAddressConfig
        {
            /// <summary>
            /// 序号
            /// </summary>
            public int Sequence { get; set; }

            /// <summary>
            /// 设备名称
            /// </summary>
            public string EquipmentName { get; set; }

            /// <summary>
            /// 中文名称
            /// </summary>
            public string ChineseName { get; set; }

            /// <summary>
            /// 英文名称【字典键名】，必须唯一
            /// </summary>
            public string EnglishName { get; set; }

            /// <summary>
            /// DB块号或M区，数据源，如 DB200，M区只用输入标识M即可
            /// </summary>
            public string DataSourceNumber { get; set; }

            /// <summary>
            /// 偏移量【地址】DB块按照字节【Byte】为单位，M区偏移按字【Word】为单位
            /// </summary>
            public ushort OffsetAddress { get; set; }

            /// <summary>
            /// 西门子PLC数据类型
            /// </summary>
            public PlcDataType DataType { get; set; }

            /// <summary>
            /// 数据长度【一般为占用的字节数】，类型为字符串时 代表字符串长度【占用字节数+2】
            /// 字节数组时，也需要制定字节数组长度
            /// </summary>
            public int DataLength { get; set; }

            /// <summary>
            /// 当前值
            /// </summary>
            public object CurrentValue { get; set; }

            /// <summary>
            /// 信号类型,分心跳信号、触发信号、反馈信号、数值项、字符串项等
            /// </summary>
            public SignalCategory SignalCategory { get; set; }

            /// <summary>
            /// 事件编号，同一事件编号代表一个业务逻辑方法
            /// </summary>
            public int EventNumber { get; set; }

            /// <summary>
            /// 启用数值校验，1为启用
            /// </summary>
            public int EnabledNumericValid { get; set; }

            /// <summary>
            /// 最小值，启用数值校验【EnabledNumericValid=1】时有效
            /// </summary>
            public object MinValue { get; set; }

            /// <summary>
            /// 最大值，启用数值校验【EnabledNumericValid=1】时有效
            /// </summary>
            public object MaxValue { get; set; }

            /// <summary>
            /// 中文描述
            /// </summary>
            public string ChineseDescription { get; set; }
        }
        public class ParamMonitorConfig
    {
        public int ID { get; set; }
        public string DB { get; set; }
        public ushort Address { get; set; }

        public PlcDataType DataType { get; set; }
    }
        /// <summary>
        /// 信号类型
        /// </summary>
        public enum SignalCategory
        {
            /// <summary>
            /// 心跳信号
            /// </summary>
            [Description("心跳信号")]
            HeartBeat = 0,
            /// <summary>
            /// 触发信号
            /// </summary>
            [Description("触发信号")]
            Trig = 1,
            /// <summary>
            /// 反馈信号
            /// </summary>
            [Description("反馈信号")]
            Feedback = 2,
            /// <summary>
            /// 数值项,Byte、Word、Int、DInt、DWord、Real等都属于此项
            /// </summary>
            [Description("数值项")]
            Numerical = 3,
            /// <summary>
            /// 字符串项
            /// </summary>
            [Description("字符串项")]
            String = 4,
            /// <summary>
            /// 设备状态
            /// </summary>
            [Description("设备状态")]
            EquipmentStatus = 5,
            /// <summary>
            /// 报警信号
            /// </summary>
            [Description("报警信号")]
            Alarm = 6,
       
        }

        /// <summary>
        /// 西门子PLC中的数据类型
        /// </summary>
        public enum PlcDataType
        {
            /// <summary>
            /// 布尔类型，true=1或false=0
            /// </summary>
            [Description("布尔")]
            Bool = 0,
            /// <summary>
            /// 字节，无符号8位整数,范围【0~255】
            /// </summary>
            [Description("字节，无符号8位整数")]
            Byte = 1,
            /// <summary>
            /// 短整型,Int16
            /// </summary>
            [Description("整数，16位整数")]
            Int = 2,
            /// <summary>
            /// 字，无符号短整型,UInt16
            /// </summary>
            [Description("字，无符号16位整数")]
            Word = 3,
            /// <summary>
            /// 整形，Int32
            /// </summary>
            [Description("双整数，32位整数")]
            DInt = 4,
            /// <summary>
            /// 双字，无符号整型,UInt32
            /// </summary>
            [Description("双字，无符号32位整数")]
            DWord = 5,
            /// <summary>
            /// 32位实数，Float
            /// </summary>
            [Description("浮点数，32位")]
            Real = 6,
            /// <summary>
            /// 双精度浮点数，64位，Double
            /// </summary>
            [Description("双精度浮点数，64位")]
            LReal = 7,
            /// <summary>
            /// 字符串，必须指定字符串长度,西门子PLC中字符串占用字节数=长度+2
            /// 目前 字符串仅支持ASCII码组成的字符串，不支持WString
            /// </summary>
            [Description("字符串")]
            String = 8,
            /// <summary>
            /// 字节数组，必须指定数组长度
            /// </summary>
            [Description("字节数组")]
            ByteArray = 9
        }
    }



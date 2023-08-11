using MESsoftware1.sfcBatchPack;
using MESsoftware1.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesInterface
{
    public class GlobalUtil
    {
        /// <summary>
        /// 进站校验接口
        /// </summary>
        public static MesRequestPara CheckBranch = new MesRequestPara();
        /// <summary>
        /// 出站数据收集接口
        /// </summary>
        public static MesRequestPara BatchPackMark1 = new MesRequestPara();
        
        public static MesRequestPara BatchPackMark2=new MesRequestPara();
    }
    /// <summary>
    /// MES调用通用请求参数
    /// </summary>
    public class MesRequestPara
    {
        /// <summary>
        /// 将列表等集合初始化为0个元素
        /// </summary>
        public MesRequestPara()
        {
            InterfaceName = "未配置的接口";
            TimeOut = 10000;
            RequestParameterList = new List<RequestParameter>();
            //  DataCollectList = new List<DataCollectItem>();
        }

        /// <summary>
        /// 接口名称
        /// </summary>
        public string InterfaceName { get; set; }
        /// <summary>
        /// 是否启用该接口：基本参数
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 接口WebService地址：基本参数
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 超时时间(毫秒)：基本参数
        /// </summary>
        public int TimeOut { get; set; }
        /// <summary>
        /// 连接服务器_接口用户名：基本参数
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 连接服务器_接口密码：基本参数
        /// </summary>
        public string Password { get; set; }
    
        public int TimeOutReConnectTime { get; set; }
        /// <summary>
        /// 站点Site、操作工位Operation、资源号Resource等配置
        /// </summary>
        /// 
        public int sfcLengthVerify { get; set; }

        public string sfcHeadVerify { get; set; }

        public int ReConnectWaitTime { get; set; }
        public List<RequestParameter> RequestParameterList { get; set; }
        /// <summary>
        /// 接口数据收集项配置，一般用于出站数据收集、首件数据收集接口
        /// </summary>
       // public List<DataCollectItem> DataCollectList { get; set; }
    }

    /// <summary>
    /// 记录请求参数，比如站点Site、操作工位Operation、资源号Resource等配置
    /// </summary>
    public class RequestParameter
    {
        /// <summary>
        /// MES参数名称
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 配置的具体值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 参数描述
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// 数据收集项配置
    /// </summary>
    public class DataCollectItem
    {
        /// <summary>
        /// 是否启用上传
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// 本地名称，一般为数据库表的字段名
        /// </summary>
        public string LocalName { get; set; }
        /// <summary>
        /// MES名称
        /// </summary>
        public string MesName { get; set; }
        /// <summary>
        ///数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 本地描述
        /// </summary>
        public string LocalDescription { get; set; }
        /// <summary>
        /// 工位标记,多工位时使用该标识
        /// </summary>
        public string StationFlag { get; set; }
        /// <summary>
        /// 数据类别 常量Constant、变量Variable
        /// </summary>
        public string DataCategory { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 上传的数据值
        /// </summary>
        public object Value { get; set; }
    }
    /*   private int codeField;
        
        private bool codeFieldSpecified;
        
        private string messageField;
        
        private string sfcField;
        
        private string groupCodeField;
        
        private string groupBasisField;
        
        private string labelRemarksField;*/
    public class ResponseResult
    {
        /// <summary>
        /// 响应结果的构造函数，默认错误号为-1
        /// </summary>
        public ResponseResult()
        {
            Code = -1;
            Message = "无法连接到服务端";
            PNCode = "";
            ReturnPN = "";
            Sfc = "";
            SfcArray = new List<string>();
            StartTime = DateTime.Now;
            EndTime = DateTime.Now.AddSeconds(1);
            GropBasis = "";
            GroupCode = "";
            lableRemarks = "";
            JgeMarkBrach = -1;
        }
        /// <summary>
        /// 返回的错误号。0表示无异常，接口返回成功
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 接口调用返回的错误信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 模组类型，如：3P8S
        /// </summary>
        public string PNCode { get; set; }
        /// <summary>
        /// 返回的PN批次码,如：830106-00872
        /// </summary>
        public string ReturnPN { get; set; }
        /// <summary>
        /// 接口系统中虚拟sfc码，一般是返回的模组条码
        /// </summary>
        public string Sfc { get; set; }
        /// <summary>
        /// 释放的模组码集合。在组件涂胶中，调用一次接口，可以释放多个用于装配的模组条码
        /// 【也用于获取客户的自定义条码集合】
        /// </summary>
        public List<string> SfcArray { get; set; }
        //分组代码
        public string GroupCode { get; set; }
        //分组依据
        public string GropBasis { get; set; }
        //外箱标识
        public string lableRemarks { get; set; }
        
        public int JgeMarkBrach { get; set; }
        /// <summary>
        /// 调用接口开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 调用接口结束时间,即：获取到接口的响应结果时间
        /// </summary>
        public DateTime EndTime { get; set; }

        public List<responseSfcDetail> RetSfcList { get;set; }
        /// <summary>
        /// 耗时，单位：毫秒(ms)
        /// </summary>
        public double SpendTime
        {
            get
            {
                return EndTime.Subtract(StartTime).TotalMilliseconds;
            }
        }

        /// <summary>
        /// 请求Json参数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("请求Json")]
        [Newtonsoft.Json.JsonIgnore]
        public string RequestJson { get; set; }
    }

   
   
}
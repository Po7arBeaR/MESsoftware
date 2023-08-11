using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESsoftware1.SQL
{
    [Serializable]
    public class HistoryData
    {
        public HistoryData() {
            sfc = "Unknown";
            InterFaceName = "Unknown";
            GroupBasis = "Unknown";
            GroupCode = "Unknown";
            labelRemarks = "Unknown";
            Count = -1;
            CreateTime = DateTime.Now;
            Message = "Unknown";
            Code = -999;
        }
        public string sfc;

        public string InterFaceName;

        public string GroupBasis;

        public string GroupCode;

        public string labelRemarks;

        public int? Count;

        public DateTime CreateTime;

        public string Message;

        public int Code;
    }
}

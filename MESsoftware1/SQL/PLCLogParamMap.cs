using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESsoftware1.SQL
{
    [Serializable]
    public class plclogparammap
    {
    
         [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
         public int? ID { get; set; }
         public string DB { get; set; }
         public int Address { get; set; }
         
         public string Type { get; set; }
         public string Description { get; set; }

         public string CurrentValue { get; set; }

         public string LastValue { get; set; }

         public  DateTime? ChangeTime { get; set; }
    }
}

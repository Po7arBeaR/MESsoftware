using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESsoftware1.SQL
{
    [Serializable]
    public class RoleManage
    {
        public string RoleName { get; set; }
        public int MainFormPermissions { get; set; }
        public int UserManageFormPermissions { get; set; }
        public int GeneralSettingFormPermissions { get; set; }
        public int InterFaceSettingFormPermissions { get;set; }
        public int PLCVariableFormPermissions { get; set; }
        
        public int ParameterMonitor { get; set; }

        public int CheckPermissions { get;set; }

    }
}

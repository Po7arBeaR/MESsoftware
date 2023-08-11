using LogSerilog;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfig
{
    public class AppConfigUtil
    {
    
        /// <summary>
        /// appSettings节点的键值对集合，StringDictionary键名不区分大小写
        /// </summary>
        public static StringDictionary dictAppSetting = new StringDictionary();
        /// <summary>
        /// connectionStrings【连接字符串】节点的集合：
        /// 元组的第一个元素代表连接字符串名称，第二个元素代表提供程序名称，第三个元素代表具体的连接字符串
        /// </summary>
        public static List<Tuple<string, string, string>> tupleConnectionStrings = new List<Tuple<string, string, string>>();
        /// <summary>
        /// 读取应用程序配置Xml文件，一般文件名为App.exe.config。将其保存到字典中
        /// </summary>
        public static void ReadAppConfig()
        {
            dictAppSetting.Clear();
            tupleConnectionStrings.Clear();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //读取配置AppSetting节点:键名不区分大小写，同一键名下只保留最后一次的键值对记录。类似于System.Collections.Specialized.StringDictionary
            KeyValueConfigurationCollection keyValueCollection = config.AppSettings.Settings;
            foreach (KeyValueConfigurationElement keyValueElement in keyValueCollection)
            {
                ElementInformation elemInfo = keyValueElement.ElementInformation;
                if (!elemInfo.IsPresent)
                {
                    //考虑到部分配置不是在App.exe.config配置文件中，此时不做处理
                    continue;
                }
                dictAppSetting.Add(keyValueElement.Key, keyValueElement.Value);
            }
            //读取连接字符串ConnectionStrings节点
            ConnectionStringSettingsCollection connectionCollection = config.ConnectionStrings.ConnectionStrings;
            foreach (ConnectionStringSettings connectElement in connectionCollection)
            {
                ElementInformation elemInfo = connectElement.ElementInformation;
                if (!elemInfo.IsPresent)
                {
                    //考虑到连接字符串有系统默认配置，不在配置文件中【IsPresent=false】，因此过滤掉,如下面两个
                    //LocalSqlServer、LocalMySqlServer
                    continue;
                }
                tupleConnectionStrings.Add(Tuple.Create(connectElement.Name, connectElement.ProviderName, connectElement.ConnectionString));
            }
        }
        public static void WriteAppConfig(string key ,string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
           
                if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                {
                    //如果当前节点存在，则更新当前节点
                    config.AppSettings.Settings[key].Value = value;
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    LogSerilog.SerilogHelper.RuntimeInformationAsync("当前节点不存在");
                }
            

        }
        /// <summary>
        /// 以不包含大小写的键名读取配置文件，获取键值对的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppConfigValue(string key)
        {
            if (!dictAppSetting.ContainsKey(key))
            {
                throw new Exception($"应用程序配置appSettings节点中不包含指定的键【{key}】");
            }
            return dictAppSetting[key];
        }
    }
}

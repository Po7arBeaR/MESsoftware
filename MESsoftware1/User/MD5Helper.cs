using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Vanara.PInvoke.User32;

namespace MESsoftware1.User
{
    public class MD5Helper
    {
     public  static string EnCode(string SourceCode)
        {
            byte[] sor = Encoding.UTF8.GetBytes(SourceCode);
            MD5 md5 = MD5.Create();
            byte[] result =md5.ComputeHash(sor);
            StringBuilder sb = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                //加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
                sb.Append(result[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}

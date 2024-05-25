using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VMCreator.Utility
{
    public enum VmAppType
    {
        [StringValue("Hyper-V")]
        HyperV,
    }
    public class ApplicationIniFileInfo
    {
        public string Provider { get; set; } = string.Empty;
    }
    internal class IniFileReader
    {

        public static ApplicationIniFileInfo AppInfo = new ApplicationIniFileInfo();

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedstring,
            int nSize,
            string lpFileName);

        public static string GetIniValue(string path, string section, string key)
        {
            StringBuilder sb = new StringBuilder(256);
            GetPrivateProfileString(section, key, string.Empty, sb, sb.Capacity, path);
            return sb.ToString();
        }

        public static string GetName<T>(Expression<Func<T>> e)
        {
            var member = (MemberExpression)e.Body;
            return member.Member.Name;
        }

        public static void ReadIniFile(string vmApp)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 1; i++)
            {
                AppInfo.Provider = GetIniValue("./Application.ini", vmApp, GetName(() => AppInfo.Provider));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMCreator.Utility;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VMCreator.Vagrant
{
    public class VagrantBoxInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
    }

    public class Vagrant
    {
        public static List<VagrantBoxInfo> GetBoxInfo()
        {
            var boxInfos = new List<VagrantBoxInfo>();

            var boxlist = CommandExecutor.Execute("Vagrant box list");
            var baseArray = boxlist.Split("\r\n");

            foreach (var strInfo in baseArray)
            {
                if (string.IsNullOrEmpty(strInfo))
                {
                    continue;
                }
                var info = new VagrantBoxInfo();
                var work = strInfo.Split("(");
                info.Name = work[0].Replace(" ","");
                work = work[1].Split(",");
                info.Provider = work[0];
                work = work[1].Split(")");
                info.Version = work[0];
                boxInfos.Add(info);
            }
            return boxInfos;
        }

        public static void GetVM()
        {
            var vmStatuslist = CommandExecutor.Execute("Vagrant global-status");
            var baseArray = vmStatuslist.Split("\r\n");
            
            for ( int startIndex = 2; startIndex < baseArray.Count(); startIndex++)
            {
                var strInfo = baseArray[startIndex];
                strInfo = strInfo.Replace("  ", " ");
                if(strInfo.StartsWith(" ") )
                {
                    break;
                }
                var infoArray = strInfo.Split(" ");
            }
        }

        public static void DestoryVM(string vmId)
        {
            CommandExecutor.Execute($"Vagrant destroy -f {vmId}");
        }
    }
}

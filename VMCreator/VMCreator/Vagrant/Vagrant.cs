using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMCreator.Utility;

namespace VMCreator.Vagrant
{
    public class VagrantBoxInfo
    {
        public string Name { get; set; }
        public string Provider { get; set; }
        public string Version { get; set; }
    }

    public class Vagrant
    {
        public static List<VagrantBoxInfo> InitializeBoxInfo()
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMCreator.Utility;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VMCreator.Vagrant
{
    /// <summary>
    /// ボックス情報クラス
    /// </summary>
    public class VagrantBoxInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string VagrantfilePath { get; set; } = string.Empty;
    }

    public class Vagrant
    {
        public static string BoxBaseDirectory {get; set;} = string.Empty;

        /// <summary>
        /// ボックス情報の取得
        /// </summary>
        /// <returns></returns>
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
                var info = AnalayzeBoxListString(strInfo);
                boxInfos.Add(info);
            }
            return boxInfos;
        }

        /// <summary>
        /// ボックスリストの文字列情報を解析
        /// </summary>
        /// <param name="strInfo"></param>
        /// <returns></returns>
        private static VagrantBoxInfo AnalayzeBoxListString(string strInfo)
        {
            var info = new VagrantBoxInfo();
            var work = strInfo.Split("(");
            info.Name = work[0].Replace(" ", "");
            work = work[1].Split(",");
            info.Provider = work[0];
            work = work[1].Split(")");
            info.Version = work[0];

            info.VagrantfilePath = SearchBoxVagrantFilePath(info.Name);
            return info;
        }

        /// <summary>
        /// VagrantFileの検索
        /// </summary>
        /// <param name="boxName"></param>
        /// <returns></returns>
        private static string SearchBoxVagrantFilePath(string boxName)
        {
            boxName = boxName.Replace("/", "-VAGRANTSLASH-");
            string[] files = Directory.GetFiles($"{BoxBaseDirectory}\\boxes\\{boxName}", "Vagrantfile", SearchOption.AllDirectories);
            return files[0];
        }

        /// <summary>
        /// Boxのワーキングディレクトリの設定
        /// </summary>
        /// <returns></returns>
        public static string InitializeBoxWorkingDirectory()
        {
            var command = $"echo %VAGRANT_HOME%";
            var response = CommandExecutor.Execute(command);
            if (response.Contains("%VAGRANT_HOME%"))
            {
                // 環境変数が設定されていない為、ユーザーpath設定
                Console.WriteLine("Not Exists Environment VAGRANT_HOME");
                Console.WriteLine("Check Environment UserName");
                command = $"echo %username%";
                response = CommandExecutor.Execute(command);
                response = response.Replace("\r\n", "");
                BoxBaseDirectory = $"C:\\Users\\{response}\\.vagrant.d";
            }
            else
            {
                BoxBaseDirectory = response;
            }
            return BoxBaseDirectory;
        }


        /// <summary>
        /// VM情報の取得
        /// </summary>
        public static List<List<string>> GetVMInfo()
        {
            var vmStatuslist = CommandExecutor.Execute("Vagrant global-status --prune");
            var baseArray = vmStatuslist.Split("\r\n");
            var resultList = new List<List<string>>();

            for ( int startIndex = 2; startIndex < baseArray.Count(); startIndex++)
            {
                var strInfo = baseArray[startIndex];

                // 複数の空行を1つに変更
                while (strInfo.Contains("  "))
                {
                    strInfo = strInfo.Replace("  ", " ");
                }
                
                if (strInfo.StartsWith(" ") )
                {
                    break;
                }
                var infoArray = strInfo.Split(" ");
                resultList.Add(infoArray.ToList());
            }

            return resultList;
        }

        /// <summary>
        /// VMの起動
        /// </summary>
        /// <param name="vmId"></param>
        public static void StartVM(string vmId)
        {
            Console.WriteLine($"Start VM {vmId}");
            CommandExecutor.Execute($"Vagrant up {vmId}");
        }

        /// <summary>
        /// VMの削除
        /// </summary>
        /// <param name="vmId"></param>
        public static void DestoryVM(string vmId)
        {
            Console.WriteLine($"Destory VM {vmId}");
            CommandExecutor.Execute($"Vagrant destroy -f {vmId}");
        }

        /// <summary>
        /// VMの再起動
        /// </summary>
        /// <param name="vmId"></param>
        public static void ReloadVM(string vmId)
        {
            Console.WriteLine($"Reload VM {vmId}");
            CommandExecutor.Execute($"Vagrant reload {vmId}");
        }

        /// <summary>
        /// VMの停止
        /// </summary>
        /// <param name="vmId"></param>
        public static void HaltVM(string vmId)
        {
            Console.WriteLine($"Halt VM {vmId}");
            CommandExecutor.Execute($"Vagrant halt {vmId}");
        }

        /// <summary>
        /// VMの再開
        /// </summary>
        /// <param name="vmId"></param>
        public static void ResumeVM(string vmId)
        {
            Console.WriteLine($"Resume VM {vmId}");
            CommandExecutor.Execute($"Vagrant resume {vmId}");
        }

        public static void SuspendVM(string vmId)
        {
            Console.WriteLine($"Suspend VM {vmId}");
            CommandExecutor.Execute($"Vagrant suspend {vmId}");
        }
    }
}

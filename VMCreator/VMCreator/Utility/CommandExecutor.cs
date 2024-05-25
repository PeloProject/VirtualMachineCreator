using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMCreator.Utility
{
    public class CommandExecutor
    {

        public CommandExecutor() { }

        public static string Execute(string command)
        {
            var processStartInfo = new ProcessStartInfo();

            processStartInfo.FileName = "cmd";

            // /cは実行後閉じるために必要
            processStartInfo.Arguments = "/c " + command;

            //コンソール開かない。
            processStartInfo.CreateNoWindow = true;

            //シェル機能使用しない。
            processStartInfo.UseShellExecute = false;

            //標準出力をリダイレクト。
            processStartInfo.RedirectStandardOutput = true;

            Process process = Process.Start(processStartInfo);

            if(process == null)
            {
                return "";
            }
            //標準出力を全て取得。
            string res = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
            process.Close();

            return res;
        }
    }
}

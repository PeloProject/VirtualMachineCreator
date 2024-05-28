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

        public static string Execute(string command, bool createWindow = false, string workingDirectory ="")
        {
            var processStartInfo = new ProcessStartInfo();

            processStartInfo.FileName = "cmd";

            // /cは実行後閉じるために必要
            processStartInfo.Arguments = "/c " + command;

            //コンソール開かない。
            processStartInfo.CreateNoWindow = !createWindow;

            //シェル機能使用しない。
            processStartInfo.UseShellExecute = false;

            //標準出力をリダイレクト。
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardError = true;

            processStartInfo.WorkingDirectory = workingDirectory;

            Process? process = Process.Start(processStartInfo);

            if(process == null)
            {
                return "";
            }
            //標準出力を全て取得。
            string res = process.StandardOutput.ReadToEnd();
            res += process.StandardError.ReadToEnd();
            
            process.WaitForExit();
            process.Close();

            return res;
        }
    }
}

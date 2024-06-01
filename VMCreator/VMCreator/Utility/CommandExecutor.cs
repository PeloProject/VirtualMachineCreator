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
            output = new StringBuilder();
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



            Process process = new Process();
            process.StartInfo = processStartInfo;
            // イベント・ハンドラ設定
            process.OutputDataReceived += OutputHandler;
            process.Start();
            process.BeginOutputReadLine(); // 子プロセスの出力読み込み開始
            //Process? process = Process.Start(processStartInfo);

            //標準出力を全て取得。
            //string res = process.StandardOutput.ReadToEnd();
            //res += process.StandardError.ReadToEnd();
            
            process.WaitForExit();
            process.Close();

            return output.ToString();
        }

        // 子プロセスが標準出力に出力したときに呼び出されるメソッド
        static StringBuilder output = new StringBuilder();
        static void OutputHandler(object o, DataReceivedEventArgs args)
        {
            // https://qiita.com/murasuke/items/ddfc75493e1d4749836f
            // コンソール表示に変更する
            output.AppendLine(args.Data); // 出力されたデータを保存
        }
    }
}

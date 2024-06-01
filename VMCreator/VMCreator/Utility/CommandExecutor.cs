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
        // 子プロセスが標準出力に出力したときに呼び出されるメソッド
        static StringBuilder output = new StringBuilder();
        public CommandExecutor() { }

        public static string Execute(string command, string workingDirectory ="")
        {
            output = new StringBuilder();
            var processStartInfo = new ProcessStartInfo();

            processStartInfo.FileName = "cmd";

            // /cは実行後閉じるために必要
            processStartInfo.Arguments = "/c " + command;

            //コンソール開かない。
            processStartInfo.CreateNoWindow = false;

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
            process.ErrorDataReceived += ErrorHandler;
            process.Start();
            process.BeginOutputReadLine(); // 子プロセスの出力読み込み開始
            process.BeginErrorReadLine();
            
            process.WaitForExit();
            process.Close();

            return output.ToString();
        }

        /// <summary>
        /// コンソール出力（通常ログ）
        /// </summary>
        /// <param name="o"></param>
        /// <param name="args"></param>
        static void OutputHandler(object o, DataReceivedEventArgs args)
        {
            if (args.Data == null)
            {
                return;
            }
            // https://qiita.com/murasuke/items/ddfc75493e1d4749836f
            // コンソール表示に変更する
            output.AppendLine(args.Data); // 出力されたデータを保存
            Console.WriteLine(args.Data);
        }

        /// <summary>
        /// エラー出力の表示
        /// </summary>
        /// <param name="o"></param>
        /// <param name="args"></param>
        static void ErrorHandler(object o, DataReceivedEventArgs args)
        {
            if (args.Data == null) 
            {
                return;
            }
            Console.WriteLine(args.Data);
        }
    }
}

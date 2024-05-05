using System.Diagnostics;

namespace QuickCodeTest
{
    internal class Module
    {
        /// <summary>
        /// プロセスを実行し、ログを出力します。
        /// プロセスが終了するまで待機します。
        /// 実行したプロセスの標準入力には対応していません。
        /// </summary>
        /// <param name="execFile">実行するファイル</param>
        /// <param name="args">起動引数</param>
        public static int RunProcess(string execFile, params string[] args)
        {
            /*
            パスが通っている物を実行する場合もあるので、ここでファイル存在確認をしないでください。
            */


            // プロセス用意
            var process = new Process()
            {
                StartInfo = new(execFile, args)
                {
                    // CreateNoWindowをtrueにするとフリーズします。
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                }
            };

            // ログ受け取りイベント登録
            static void LogWrite(object sender, DataReceivedEventArgs e)
            {
                if (string.IsNullOrEmpty(e.Data)) { return; }
                Console.WriteLine(e.Data);
            }
            process.OutputDataReceived += LogWrite;
            process. ErrorDataReceived += LogWrite;

            // 開始
            process.Start();

            // 出力の読み取り開始
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            // 終了
            process.WaitForExit();
            var exitCode = process.ExitCode;
            process.Close();
            return exitCode;
        }
    }
}

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
        /// <param name="fileName">実行するファイル</param>
        /// <param name="args">起動引数</param>
        public static void RunProcess(string fileName, params string[] args)
        {
            // ログ処理
            static void LogWrite(object sender, DataReceivedEventArgs e)
            {
                if (string.IsNullOrEmpty(e.Data)) { return; }
                Console.WriteLine(e.Data);
            }


            var process = new Process()
            {
                StartInfo = new(fileName, args)
                {
                    // CreateNoWindowをtrueにするとフリーズします。
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                }
            };

            // ログ受け取りイベント登録
            process.OutputDataReceived += LogWrite;
            process. ErrorDataReceived += LogWrite;

            // 開始
            process.Start();

            // 出力の読み取り開始
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            // 終了
            process.WaitForExit();
            process.Close();
        }
    }
}

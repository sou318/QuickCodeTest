using System.Diagnostics;
using System.Reflection;

namespace QuickCodeTest
{
    internal class QuickCodeTest
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                var appver = Assembly.GetExecutingAssembly().GetName().Version;
                Console.WriteLine($"QuickCodeTest {appver} (C) 2024 sou");
                return;
            }


            var file = args[0];
            if (!File.Exists(file))
            {
                Console.WriteLine("File not found.");
                return;
            }


            var exeArgs  = args[1..]; // 実行ファイルに渡す引数


            // ドットも付いてくるのでスライス
            var ext = Path.GetExtension(file).ToLower()[1..];
            var runFile = Guid.NewGuid().ToString() + ".exe";


            // コンパイル
            switch (ext)
            {
                case "cs":
                    Module.RunProcess("csc", file, "/langversion:latest", "/nologo", $"-out:{runFile}");
                    break;
                default:
                    Console.WriteLine("This extension i s not supported.");
                    break;
            }


            // コンパイルに成功していれば実行
            if (File.Exists(runFile))
            {
                Module.RunProcess(runFile, exeArgs);
                File.Delete(runFile);
            }
        }
    }
}

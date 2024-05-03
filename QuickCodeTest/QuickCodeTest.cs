using QuickCodeTest.CodeFile;
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


            var execArgs  = args[1..]; // 実行ファイルに渡す引数


            // ドットも付いてくるのでスライス
            var ext = Path.GetExtension(file).ToLower()[1..];


            // コンパイル
            var codeFile = ext switch
            {
                "cs" => new CSharp(file),
                _    => null
            };


            // 非対応ファイル
            if (codeFile is null)
            {
                Console.WriteLine("This extension is not supported.");
                return;
            }


            // コンパイルと実行
            codeFile.Compile();
            if (codeFile.ExistsExecFile())
            {
                codeFile.Run(execArgs);
                codeFile.DeleteExecFile();
            }
        }
    }
}

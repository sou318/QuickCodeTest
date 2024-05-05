namespace QuickCodeTest.CodeFile
{
    internal class Java(string file) : CodeFileBase("java", file, "class", Util.GetPathWithoutExtension(file))
    {
        public override void Compile()
        {
            Module.RunProcess("javac", codeFile);
        }


        public override void Run(string[] args)
        {
            string[] execArgs = [Path.GetFileNameWithoutExtension(execFile), ..args];

            // 別ディレクトリから実行した場合に実行できないのでClassPathを通す
            var classPath = Path.GetDirectoryName(execFile);
            if (classPath is not null)
            {
                execArgs = ["-cp", classPath, ..execArgs];
            }

            Module.RunProcess("java", execArgs);
        }
    }
}

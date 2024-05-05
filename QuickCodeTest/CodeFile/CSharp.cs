namespace QuickCodeTest.CodeFile
{
    internal class CSharp(string file) : CodeFileBase("cs", file, "exe")
    {
        public override void Compile()
        {
            Module.RunProcess("csc", codeFile, "/langversion:latest", "/nologo", $"-out:{execFile}");
        }
    }
}

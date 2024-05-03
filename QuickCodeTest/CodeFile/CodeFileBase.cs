namespace QuickCodeTest.CodeFile
{
    internal class InvalidFileExtensionException(string message) : ArgumentException(message);


    internal abstract class CodeFileBase
    {
        /// <summary>
        /// 言語のコンパイルと実行を簡易化する為のクラス
        /// </summary>
        /// <param name="ext">この言語の拡張子(ドットなし)</param>
        /// <param name="execExt">実行ファイルの拡張子</param>
        /// <param name="file">ソースコードファイル</param>
        /// <exception cref="InvalidFileExtensionException">fileの拡張子がextと違った場合スローされます。</exception>
        public CodeFileBase(string ext, string execExt, string file)
        {
            if (!Path.GetExtension(file)[1..].EqualsIgnoreCase(ext))
            {
                throw new InvalidFileExtensionException("Required file extension: " + ext);
            }


            codeFile = file;
            execFile = Module.CreateGuidFileName(execExt);
        }


        protected readonly string codeFile;
        protected readonly string execFile;


        // 成功,失敗のbool返すようにしたい
        // コンパイル時のファイル名指定できるようにして、コンパイラ的な感じで使えるようにもしたい
        /// <summary>
        /// ソースコードをコンパイルします。
        /// </summary>
        public abstract void Compile();


        /// <summary>
        /// 実行ファイルを起動させます。
        /// </summary>
        /// <param name="args">実行ファイルに渡す引数</param>
        public virtual void Run(string[] args)
        {
            Module.RunProcess(execFile, args);
        }


        /// <summary>
        /// 実行ファイルの存在を確認します。
        /// </summary>
        /// <returns>存在していればtrue</returns>
        public bool ExistsExecFile()
        {
            return File.Exists(execFile);
        }


        /// <summary>
        /// 実行ファイルを削除します。
        /// </summary>
        public void DeleteExecFile()
        {
            File.Delete(execFile);
        }
    }
}

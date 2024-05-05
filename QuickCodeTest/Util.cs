namespace QuickCodeTest
{
    internal static class Util
    {
        /// <summary>
        /// 大文字、小文字を区別せずに比較します。
        /// </summary>
        /// <returns>一致していればtrue</returns>
        public static bool EqualsIgnoreCase(this string text, string check)
        {
            return text.Equals(check, StringComparison.OrdinalIgnoreCase);
        }


        /// <summary>
        /// 拡張子以外のパスを取得します。
        /// </summary>
        /// <param name="path">取得するパス</param>
        /// <returns>取得したパス</returns>
        public static string GetPathWithoutExtension(string path)
        {
            return path[..(path.Length-Path.GetExtension(path).Length)];
        }
    }
}

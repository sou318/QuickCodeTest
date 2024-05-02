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
    }
}

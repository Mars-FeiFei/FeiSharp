namespace FeiSharpStudio
{
    public static class Util
    {
        public static void Show(this RichTextBox tbx, string text)
        {
            tbx.Text += text + Environment.NewLine;
        }
        public static bool IgnoreContains(this string str,string str1)
        {
            string a = str.ToUpperInvariant();
            string b = str.ToUpperInvariant();
            return a.Contains(b);
        }
    }
}

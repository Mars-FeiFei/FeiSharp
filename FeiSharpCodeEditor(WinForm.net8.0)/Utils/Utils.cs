namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    public static class Util
    {
        public static void Show(this RichTextBox tbx, string text)
        {
            tbx.Text += text + Environment.NewLine;
        }
    }
}

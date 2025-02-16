using Microsoft.Web.WebView2.WinForms;

namespace FeiSharpStudio.CodeCore
{
    public partial class SourceCode : Form
    {
        public SourceCode()
        {
            InitializeComponent();
        }

        private void SourceCode_Load(object sender, EventArgs e)
        {
            WebView2 webView2 = new WebView2();
            webView2.Dock = DockStyle.Fill;
            webView2.Source = new Uri("https://github.com/Mars-FeiFei/FeiSharp/blob/WinFormDotnet8/FeiSharpCodeEditor(WinForm.net8.0)/MainForm.cs");
            this.Controls.Add(webView2);
        }
    }
}

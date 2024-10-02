using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    public partial class Learn : Form
    {
        public Learn()
        {
            InitializeComponent();
            Microsoft.Web.WebView2.WinForms.WebView2 webView = new();
            webView.Dock = (DockStyle)5;
            webView.EnsureCoreWebView2Async(null);
            this.Controls.Add(webView);
            webView.Source = new Uri($"https://leetcode.cn/");
        }
    }
}

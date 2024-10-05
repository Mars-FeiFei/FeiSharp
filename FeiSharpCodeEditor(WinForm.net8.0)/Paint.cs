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
    public partial class Paint : Form
    {
        public Paint()
        {
            InitializeComponent();
        }

        private void PaintBtn_Click(object sender, EventArgs e)
        {
            Graphics graphics = Graphics.FromHwnd(this.Handle);
            string[] sizeArray = txtCode.Text.Split(';');
            PointF[] pointFs = new PointF[sizeArray.Length];
            for (int i = 0; i < sizeArray.Length; i++)
            {
                pointFs[i] = new PointF(Convert.ToInt32(sizeArray[i].Split(',')[0]), Convert.ToInt32(sizeArray[i].Split(',')[1]));
            }
            graphics.DrawLines(new Pen(Color.Black,15),pointFs);
        }
    }
}

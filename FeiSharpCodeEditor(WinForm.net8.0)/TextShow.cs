﻿using System;
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
    public partial class TextShow : Form
    {
        public TextShow()
        {
            InitializeComponent();
        }
        public void Show(object a)
        {
            textBox1.Text = a.ToString();
            ShowDialog();
        }
    }
}

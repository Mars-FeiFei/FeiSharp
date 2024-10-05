using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            console.FlatStyle = FlatStyle.Flat;
            console.FlatAppearance.BorderSize = 0;
            ficJson.FlatStyle = FlatStyle.Flat;
            ficJson.FlatAppearance.BorderSize = 0;
            devoCmd.FlatStyle = FlatStyle.Flat;
            devoCmd.FlatAppearance.BorderSize = 0;
            learn.FlatStyle = FlatStyle.Flat;
            learn.FlatAppearance.BorderSize = 0;
            Paint.FlatStyle = FlatStyle.Flat;
            Paint.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FicJson ficJson = new FicJson();
            ficJson.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Fei__Item item = new Fei__Item();
            item.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = Assembly.GetExecutingAssembly().Location;
            path = Path.Combine(Path.GetDirectoryName(path), @"Develper Cmd\Develper Cmd\bin\Debug\net8.0");
            path += @"\Develper Cmd.exe";
            Process.Start(path);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Learn().Show();
        }

        private void Paint_Click(object sender, EventArgs e)
        {
            new Paint().Show();
        }
    }
}

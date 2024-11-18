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

namespace FeiSharpStudio
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            console.FlatStyle = FlatStyle.Flat;
            console.FlatAppearance.BorderSize = 0;
            devoCmd.FlatStyle = FlatStyle.Flat;
            devoCmd.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm f = new MainForm();
            f.Show();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Loading......");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Fei__Item item = new Fei__Item();
            item.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("powershell.exe");
        }
    }
}

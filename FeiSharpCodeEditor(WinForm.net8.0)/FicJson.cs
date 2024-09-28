using FeiSharp;
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
    public partial class FicJson : Form
    {
        public FicJson()
        {
            InitializeComponent();
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = new Parser(new List<Token>()).Run(textBox1.Text, 1);
            string b = "{";
            foreach (var item in a)
            {
                if (item.Key != "true" && item.Key != "false")
                {
                    if (item.Value is string)
                    {
                        b += $"\"{item.Key}\":\"{item.Value}\",";
                    }
                    else if (item.Value is bool)
                    {

                        if (bool.Parse(item.Value.ToString())) { b += $"\"{item.Key}\":true,"; }
                        else
                        {
                            b += $"\"{item.Key}\":false,";
                        }
                    }
                    else
                    {
                        b += $"\"{item.Key}\":{item.Value},";
                    }
                }
            }
            char[] c = b.ToCharArray();
            c[c.Length - 1] = '}';
            b = new string(c);
            textBox2.Text = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new();
            sfd.Filter = "Json File|.json";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter sw = new(sfd.FileName, false, encoding: System.Text.Encoding.UTF8);
                sw.Write(textBox2.Text);
            }
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool a = false;
            if (e.KeyChar == '(')
            {
                int start = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, "()");
                textBox1.SelectionStart = start + 1;
                e.Handled = true;
            }
            else if (e.KeyChar == '{')
            {
                int start = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, "\r\n{\r\n\r\n}");
                textBox1.SelectionStart = start + 2;
                e.Handled = true;
            }
            else if (e.KeyChar == '"')
            {
                int start = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, "\"\"");
                textBox1.SelectionStart = start + 1;
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Enter && textBox1.Text[textBox1.SelectionStart - 1] != ']')
            {
                a = true;
                int start = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, ";\r\n");
                textBox1.Text += Environment.NewLine;
                textBox1.SelectionStart = start + 3;
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Enter && textBox1.Text[textBox1.SelectionStart - 1] != '}' && !a)
            {
                int start = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, ";\r\n");
                textBox1.Text += Environment.NewLine;
                textBox1.SelectionStart = start + 3;
                e.Handled = true;
            }
            else if (e.KeyChar == ';')
            {
                int start = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, ";\r\n");
                textBox1.Text += Environment.NewLine;
                textBox1.SelectionStart = start + 3;
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, comboBox1.SelectedItem.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new();
            sfd.Filter = "Fei# Source Code File|.fsc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(sfd.FileName);
            }
        }
        private void FicJson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) {
                var a = new Parser(new List<Token>()).Run(textBox1.Text, 1);
                string b = "{";
                foreach (var item in a)
                {
                    if (item.Key != "true" && item.Key != "false")
                    {
                        if (item.Value is string)
                        {
                            b += $"\"{item.Key}\":\"{item.Value}\",";
                        }
                        else if (item.Value is bool)
                        {

                            if (bool.Parse(item.Value.ToString())) { b += $"\"{item.Key}\":true,"; }
                            else
                            {
                                b += $"\"{item.Key}\":false,";
                            }
                        }
                        else
                        {
                            b += $"\"{item.Key}\":{item.Value},";
                        }
                    }
                }
                char[] c = b.ToCharArray();
                c[c.Length - 1] = '}';
                b = new string(c);
                textBox2.Text = b;
            }
            else if(e.Control && e.KeyCode == Keys.S){
                SaveFileDialog sfd = new()
                {
                    Filter = "Json File|.json"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using StreamWriter sw = new(sfd.FileName, false, encoding: System.Text.Encoding.UTF8);
                    sw.Write(textBox2.Text);
                }
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                OpenFileDialog sfd = new()
                {
                    Filter = "Fei# Source Code File|.fsc"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = File.ReadAllText(sfd.FileName);
                }
            }
        }

    }
}

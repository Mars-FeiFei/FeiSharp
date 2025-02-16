using FeiSharpStudio.Utils;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace FeiSharpStudio.CodeCore
{
    public partial class AdvancedProperties : Form
    {
        public string ProgarmLanguage {  get; internal set; }
        public AdvancedProperties()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            input.Visible = false;
            output.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
            comboBox2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            input.Visible = true;
            output.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
            comboBox2.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            comboBox2.Visible = true;
            input.Visible = false;
            output.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = $"using System;using System.Runtime.InteropServices;using System.Diagnostics;using System.Reflection;using System.Collections.Generic;using System.IO;using System.Linq;using System.Net.Http;string os=RuntimeInformation.OSDescription;public class Tools\r\n        {{\r\n            public static string[] GetSpaceSplit(string a)\r\n            {{\r\n                 return a.Split(' ');\r\n            }}\r\n            public static string GetCenter(string str,string leftSplit,string rightsplit)\r\n            {{\r\n                return str.Split(leftSplit)[1].Split(rightsplit)[0];\r\n            }}\r\n        }}string progarmLanguage = \"{ProgarmLanguage}\";string properties = \"view:normal;lang:FeiSharp-WinFormEdition 8.0.1\";string version=\"v1.22.1\";const ushort HANDLE = 0x18; return " + input.Text + ";";
            try
            {
                var options = ScriptOptions.Default.AddReferences(typeof(AdvancedProperties).Assembly);
                var script = CSharpScript.Create(code, options);
                var result = script.RunAsync().Result;
                if (result.ReturnValue != null)
                {
                    output.Text += result.ReturnValue.ToString() + Environment.NewLine;
                }
                else
                {
                    output.Text += "Code executed successfully without a return value." + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                output.Text += "Error: " + ex.Message + Environment.NewLine;
            }
        }

        private void AdvancedProperties_Load(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(400);
            if (comboBox2.SelectedItem == (object)"normal")
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.MaximizeBox = false;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MaximizeBox = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(400);
            ProgarmLanguage = comboBox1.SelectedItem.ToString();
            if (comboBox1.SelectedIndex == 0) {
                Tab.Version = "8.5";
            }
            else
            {
                Tab.Version = "8.0";
            }
        }
    }
}

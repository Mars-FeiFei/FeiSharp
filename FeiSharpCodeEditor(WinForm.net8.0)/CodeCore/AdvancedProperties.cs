using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace FeiSharpCodeEditor_WinForm.net8._0_.CodeCore
{
    public partial class AdvancedProperties : Form
    {
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
            string code = $"using System;using System.Diagnostics;using System.Reflection;using System.Collections.Generic;using System.IO;using System.Linq;using System.Net.Http;string properties = \"view:normal;lang:FeiSharp-WinFormEdition 8.0.1\";string version=\"v1.22.1\";string code=\"{input.Text}\";return " + input.Text + ";";
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
                output.Text = "Error: " + ex.Message + Environment.NewLine;
            }
        }

        private void AdvancedProperties_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
    }
}

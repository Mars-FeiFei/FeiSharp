using FeiSharp;
using IWshRuntimeLibrary;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;
using T = System.Windows.Forms.Timer;

namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    public partial class Form1 : Form
    {
        Image gifImage;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            RunBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            RunBtn.FlatAppearance.BorderSize = 0;
            SaveAsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SaveAsBtn.FlatAppearance.BorderSize = 0;
            Menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Menu.FlatAppearance.BorderSize = 0;
            OpenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            OpenBtn.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.SendToBack();
        }
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Run();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                SaveAs();
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                Start();
            }
        }
        private void Start()
        {
            OpenFileDialog ofd = new();
            ofd.Filter = "FeiSharp Source Code File|*.fsc";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Run(System.IO.File.ReadAllText(ofd.FileName));
            }
        }
        private void SaveAs()
        {
            SaveFileDialog sfd = new();
            sfd.Filter = "FeiSharp Source Code File|*.fsc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter sw = new(sfd.FileName, false, encoding: System.Text.Encoding.UTF8);
                sw.Write(textBox1.Text);
            }
        }
        private void BtnRunClick(object sender, EventArgs e)
        {
            Run();
        }
        private void Run()
        {
            string code = "";
            string sourceCode = textBox1.Text;
            Lexer lexer = new(sourceCode);
            List<Token> tokens = [];
            Token token;
            do
            {
                token = lexer.NextToken();

                tokens.Add(token);
            } while (token.Type != TokenType.EndOfFile);

            Parser parser = new(tokens);
            parser.OutputEvent += (s, e) =>
            {
                outputBox.Show(e.Message);
            };
            try
            {
                parser.ParseStatements();
            }
            catch (Exception ex)
            {
                outputBox.Show("Parsing error: " + ex.Message);
            }
            return;
        }
        private void Run(string _code)
        {
            string code = "";
            string sourceCode = _code;
            Lexer lexer = new(sourceCode);
            List<Token> tokens = [];
            Token token;
            do
            {
                token = lexer.NextToken();
                tokens.Add(token);
            } while (token.Type != TokenType.EndOfFile);

            Parser parser = new(tokens);
            parser.OutputEvent += (s, e) =>
            {
                outputBox.Show(e.Message);
            };
            try
            {
                parser.ParseStatements();
            }
            catch (Exception ex)
            {
                outputBox.Show("Parsing error: " + ex.Message);
            }
            return;
        }
        private List<Token> Build()
        {
            string code = "";
            string sourceCode = textBox1.Text;
            Lexer lexer = new(sourceCode);
            List<Token> tokens = [];
            Token token;
            do
            {
                token = lexer.NextToken();
                tokens.Add(token);
            } while (token.Type != TokenType.EndOfFile);
            return tokens;
        }
       
        private void BtnSaveAsClick(object sender, EventArgs e)
        {
            SaveAs();
        }
        private void RunAsException()
        {
            string code = "";
            string sourceCode = textBox1.Text;
            Lexer lexer = new(sourceCode);
            List<Token> tokens = [];
            Token token;
            do
            {
                token = lexer.NextToken();
                tokens.Add(token);
            } while (token.Type != TokenType.EndOfFile);

            Parser parser = new(tokens);
            parser.OutputEvent += (s, e) =>
            {
                outputBox.Show(e.Message);
            };
            parser.OutputEvent += (s, e) =>
            {
                outputBox.Show(e.Message);
            };
            parser.ParseStatements();
            return;
        }
        private void Check()
        {
            List<Token> tokens = Build();
            bool isValid = true;
            foreach (var item in tokens)
            {
                if (item.Type == TokenType.Identifier && char.IsUpper(item.Value[0]))
                {
                    outputBox.Show("The var \"" + item.Value + "\" isn't a valid varname, \r\n but it doesn't affect operation.");
                    isValid = false;
                }
            }
            try
            {
                RunAsException();
            }
            catch (Exception ex)
            {
                outputBox.Show("Something went wrong:" + "\r\n" + ex.Message);
                isValid = false;
            }
            if (isValid)
            {
                outputBox.Show("Nothing wrong.");
            }
        }
        private void BtnOpenFileClick(object sender, EventArgs e)
        {
            Start();
        }

        private void CodeEditor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FeiSharpForm_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Loading......");
        }

        private void CbxKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, comboBox1.SelectedItem.ToString());
        }

        private void CbxStatement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() != "func")
            {
                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, comboBox2.SelectedItem.ToString() + "()\r\n{\r\n\r\n}");
            }
            else
            {
                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, comboBox2.SelectedItem.ToString() + " FunctionName()\r\n[\r\n\r\n]");
            }
        }

        private void BtnMenuClick(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }

        private void BtnShortcutClick(object sender, EventArgs e)
        {
            var executingPath = Assembly.GetExecutingAssembly().Location;
            var currentFolder = Path.GetDirectoryName(executingPath);

            var filename = Path.GetFileName(executingPath);
            var executingFilename = Path.ChangeExtension(filename, "exe");

            WshShell shell = new();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FeiSharpStudio.lnk");
            shortcut.TargetPath = Path.Combine(currentFolder, executingFilename);
            shortcut.WorkingDirectory = currentFolder;
            shortcut.Description = "FeiSharpStudio's shortcut.";
            shortcut.Save();
        }
    }
    public static class Util
    {
        public static void Show(this TextBox tbx,string text)
        {
            tbx.Text += Environment.NewLine+text;
        }
    }
}

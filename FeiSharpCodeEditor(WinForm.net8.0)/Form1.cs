using FeiSharp;
using System.Diagnostics;
using T = System.Windows.Forms.Timer;

namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    public partial class Form1 : Form
    {
        T timer = new();
        Image gifImage;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            timer.Interval = 10;
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop();
            this.pictureBox1.Visible = true;
            Thread.Sleep(Random.Shared.Next(3000,4001));
            this.pictureBox1.Visible = false;
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
                Run(File.ReadAllText(ofd.FileName));
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
        private void button1_Click(object sender, EventArgs e)
        {
            Run();
        }
        TextShow t = new TextShow();
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
            try
            {
                parser.ParseStatements();
            }
            catch (Exception ex)
            {
                t.Show("Parsing error: " + ex.Message);
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
            try
            {
                parser.ParseStatements();
            }
            catch (Exception ex)
            {
                t.Show("Parsing error: " + ex.Message);
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
        private void Form1_Resize(object sender, EventArgs e)
        {
            textBox1.Width = this.ClientSize.Width - 20;
            textBox1.Height = this.ClientSize.Height - button1.Height - 30;
        }
        private void button2_Click(object sender, EventArgs e)
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
                    t.Show("The var \"" + item.Value + "\" isn't a valid varname, \r\n but it doesn't affect operation.");
                    isValid = false;
                }
            }
            try
            {
                RunAsException();
            }
            catch (Exception ex)
            {
                t.Show("Something went wrong:" + "\r\n" + ex.Message);
                isValid = false;
            }
            if (isValid)
            {
                t.Show("Nothing wrong.");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Loading......");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, comboBox1.SelectedItem.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}

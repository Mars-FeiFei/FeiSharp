using FeiSharp;

namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
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
            ofd.Filter = "FeiSharp Code File|*.fs";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Run(File.ReadAllText(ofd.FileName));
            }
        }
        private void SaveAs()
        {
            SaveFileDialog sfd = new();
            sfd.Filter = "FeiSharp Code File|*.fs";
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
            else if (e.KeyChar == (char)Keys.Enter)
            {
                int start = textBox1.SelectionStart;
                if (textBox1.Text[start-1] != ';') {
                    textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, ";\r\n");
                }
                else
                {
                    textBox1.Text += Environment.NewLine;
                }
                textBox1.SelectionStart = start+3;
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

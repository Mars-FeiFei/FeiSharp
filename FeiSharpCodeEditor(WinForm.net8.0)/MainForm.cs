
using EnvDTE;
using EnvDTE80;
using IWshRuntimeLibrary;
using System.Diagnostics;
using System.IO.Packaging;
using System.Reflection;

namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    public partial class MainForm : Form
    {
        Log logForm = new Log();
        List<string> keywords = new List<string>()
        {
            "var", "print", "init", "set", "import", "export", "start", "stop", "wait", "watchstart", "watchend", "abe", "helper", "if", "while", "func", "return", "gethtml", "getVarsFromJsonFilePath"
        };
        private readonly static string delimiter = "                    ";

        public MainForm()
        {
            AddText(EventName.Ctor, "type=Method", "Form1", "ctor Form1()");
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
            ShortCutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ShortCutBtn.FlatAppearance.BorderSize = 0;
            CheckBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CheckBtn.FlatAppearance.BorderSize = 0;
            log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            log.FlatAppearance.BorderSize = 0;
            exit.Text = "exit";
            exit.BackColor = Color.LightYellow;
            exit.ShortcutKeys = Keys.Control | Keys.Alt|Keys.F4;
            exit.Click += (s, e) => { 
                Application.Exit();
            };
            properties.Text = "properties";
            properties.BackColor = Color.LightYellow;
            properties.ShortcutKeys = Keys.P | Keys.Control | Keys.Shift;
            properties.Click += (s, e) => { 
                new CodeCore.AdvancedProperties().ShowDialog();
            };
            contextMenuStrip1.Items.AddRange([exit,properties]);
            ShortCutBtn.SendToBack();
            this.FormClosing += MainForm_FormClosing;
        }
       
        bool isclose = false;
        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !isclose)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            AddText(EventName.KeyDown, "type=Form(this)", "Form1", "this");

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
            AddText(EventName.Method, "type=Method", "Form1", "void Start()");

            OpenFileDialog ofd = new();
            ofd.Filter = "FeiSharp Source Code File|*.fsc";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtCode.Text = System.IO.File.ReadAllText(ofd.FileName);
            }
        }

        private void SaveAs()
        {
            AddText(EventName.Method, "type=Method", "Form1", "void SaveAs()");

            SaveFileDialog sfd = new();
            sfd.Filter = "FeiSharp Source Code File|*.fsc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter sw = new(sfd.FileName, false, encoding: System.Text.Encoding.UTF8);
                sw.Write(txtCode.Text);
            }
        }

        private void BtnRunClick(object sender, EventArgs e)
        {
            AddText(EventName.Click, "type=Button", "Form1", "btnRun");

            Run();
        }

        private void Run()
        {
            AddText(EventName.Method, "type=Method", "Form1", "void Run()[2 references]");

            string code = "";
            string sourceCode = txtCode.Text;
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
            AddText(EventName.Method, "type=Method", "Form1", "List<Token> Build()");

            string code = "";
            string sourceCode = txtCode.Text;
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
            AddText(EventName.Click, "type=Button", "Form1", "btnSaveAs");

            SaveAs();
        }

        private void RunAsException()
        {
            AddText(EventName.Method, "type=Method", "Form1", "void RunAsException()");

            string code = "";
            string sourceCode = txtCode.Text;
            Lexer lexer = new(sourceCode);
            List<Token> tokens = [];
            Token token;
            do
            {
                token = lexer.NextToken();
                tokens.Add(token);
            } while (token.Type != TokenType.EndOfFile);

            Parser parser = new(tokens);
            Debug.WriteLine("test run value:");
            parser.OutputEvent += (s, e) =>
            {
                Debug.WriteLine(e.Message);
            };
            parser.ParseStatements();
            return;
        }

        private void FeiSharpForm_Resize(object sender, EventArgs e)
        {
            AddText(EventName.Resize, "type=Form(this)", "Form1", "this");

            if (ClientSize.Width <= 1900 && ClientSize.Height <= 2000)
            {
                Width = 1900;
                Height = 2000;
            }
            txtCode.Width = outputBox.ClientSize.Width;
        }

        private void Check()
        {
            AddText(EventName.Method, "type=Method", "Form1", "void Check()");
            List<Token> tokens = Build();
            bool isValid = true;
            foreach (var item in tokens)
            {
                if (item.Type == TokenType.Identifier && char.IsUpper(item.Value[0]))
                {
                    outputBox.Show("The var or func \"" + item.Value + "\" isn't a valid var or func name, \r\n but it doesn't affect operation.");
                    isValid = false;
                }
            }
            try
            {
                RunAsException();
            }
            catch (Exception ex)
            {
                outputBox.Show("Runtime exception:" + "\r\n in " + ex.Source + $" Namespace's  {ex.Data}.");
                isValid = false;
            }
            if (isValid)
            {
                outputBox.Show("Nothing wrong.");
            }
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem closeMenuItem = new ToolStripMenuItem("Close");
                ToolStripMenuItem minMenuItem = new ToolStripMenuItem("Minimize");
                ToolStripMenuItem maxMenuItem = new ToolStripMenuItem("Maximize");
                ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Open File");
                ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("Save As");
                ToolStripMenuItem codeMenuItem = new ToolStripMenuItem("View Source Code");
                ToolStripMenuItem propertiesItem = new ToolStripMenuItem("Advanced Properties");
                codeMenuItem.Click += (s, e) => new CodeCore.SourceCode().Show();
                closeMenuItem.Click += (s, e) => this.Close();
                minMenuItem.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
                maxMenuItem.Click += (s, e) => this.WindowState = FormWindowState.Maximized;
                openMenuItem.Click += (s, e) => Start();
                saveMenuItem.Click += (s, e) => SaveAs();
                propertiesItem.Click += (s, e) => new CodeCore.AdvancedProperties().ShowDialog();
                closeMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.C;
                minMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.I;
                maxMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.A;
                openMenuItem.ShortcutKeys = Keys.Control | Keys.F;
                saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
                codeMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.V;
                propertiesItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.P;
                contextMenuStrip.Items.Add(codeMenuItem);
                contextMenuStrip.Items.Add(closeMenuItem);
                contextMenuStrip.Items.Add(minMenuItem);
                contextMenuStrip.Items.Add(maxMenuItem);
                contextMenuStrip.Items.Add(openMenuItem);
                contextMenuStrip.Items.Add(saveMenuItem);
                contextMenuStrip.Items.Add(propertiesItem);
                contextMenuStrip.Show(e.Location);
            }
        }
        private void BtnOpenFileClick(object sender, EventArgs e)
        {
            AddText(EventName.Click, "type=Button", "Form1", "btnOpenFile");
            Start();
        }

        private void CodeEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddText(EventName.KeyPress, "type=RichTextBox", "Form1", "txtCode");
            if (e.KeyChar == '(')
            {
                int start = txtCode.SelectionStart;
                txtCode.Text = txtCode.Text.Insert(txtCode.SelectionStart, "()");
                txtCode.SelectionStart = start + 1;
                e.Handled = true;
            }
            else if (e.KeyChar == '"')
            {
                int start = txtCode.SelectionStart;
                txtCode.Text = txtCode.Text.Insert(txtCode.SelectionStart, "\"\"");
                txtCode.SelectionStart = start + 1;
                e.Handled = true;
            }
            if (e.KeyChar == '#')
            {
                Point cursorPosition = txtCode.GetPositionFromCharIndex(txtCode.SelectionStart);
                lstbIntelligence.Left = txtCode.Left + cursorPosition.X;
                lstbIntelligence.Top = txtCode.Top + cursorPosition.Y + txtCode.Font.Height;
                lstbIntelligence.Visible = true;
                lstbIntelligence.BringToFront();
            }
        }

        private void FeiSharpForm_Load(object sender, EventArgs e)
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.WriteLine("'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: DefaultDomain): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Private.CoreLib.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'D:\\Source Code\\FeiSharp\\FeiSharpCodeEditor(WinForm.net8.0)\\bin\\Debug\\net8.0-windows\\FeiSharpCodeEditor(WinForm.net8.0).dll'. Symbols loaded.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Runtime.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'c:\\program files\\microsoft visual studio\\2022\\community\\common7\\ide\\commonextensions\\microsoft\\hotreload\\Microsoft.Extensions.DotNetDeltaApplier.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.IO.Pipes.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Linq.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Collections.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Console.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Threading.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Runtime.InteropServices.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Threading.Overlapped.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Security.AccessControl.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Security.Principal.Windows.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Security.Claims.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Runtime.Loader.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.WindowsDesktop.App\\8.0.8\\System.Windows.Forms.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Collections.Concurrent.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.ComponentModel.Primitives.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.WindowsDesktop.App\\8.0.8\\System.Windows.Forms.Primitives.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Drawing.Primitives.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Collections.Specialized.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Diagnostics.TraceSource.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.WindowsDesktop.App\\8.0.8\\System.Drawing.Common.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\Microsoft.Win32.Primitives.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.ComponentModel.EventBasedAsync.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Threading.Thread.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.WindowsDesktop.App\\8.0.8\\Accessibility.dll'. Module was built without symbols.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.ComponentModel.TypeConverter.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Numerics.Vectors.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.WindowsDesktop.App\\8.0.8\\Microsoft.Win32.SystemEvents.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.ComponentModel.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.WindowsDesktop.App\\8.0.8\\System.Resources.Extensions.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Memory.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.WindowsDesktop.App\\8.0.8\\System.Drawing.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.ObjectModel.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Diagnostics.FileVersionInfo.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.WindowsDesktop.App\\8.0.8\\zh-Hans\\System.Windows.Forms.resources.dll'. Module was built without symbols.\r\n'FeiSharpCodeEditor(WinForm.net8.0).exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.8\\System.Collections.NonGeneric.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.");
            string output = stringWriter.ToString();
            AddText(eventName:EventName.Load,"type=Form(this)",output);
            AddText(EventName.Load, "type=Form(this)", "Form1", "this");
        }

        private void BtnMenuClick(object sender, EventArgs e)
        {
            AddText(EventName.Click, "type=Button", "Form1", "btnMenu");
            Menu menu = new();
            menu.Show();
        }

        private void BtnShortcutClick(object sender, EventArgs e)
        {
            AddText(EventName.Click, "type=Button", "Form1", "btnShortCut");
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

        private void BtnCheckClick(object sender, EventArgs e)
        {
            AddText(EventName.Click, "type=Button", "Form1", "btnCheck");
            Check();
        }

        private void ShowIntelligenceIfNecessary(string segment)
        {
            object[] objectKeywords = keywords.Where(i => i.Contains(segment)).ToArray();
            lstbIntelligence.Items.Clear();
            lstbIntelligence.Items.AddRange(objectKeywords);
            int index = -1;
            for (int i = 0; i < lstbIntelligence.Items.Count; i++)
            {
                string currentItem = lstbIntelligence?.Items[i]?.ToString();
                if (segment != "" && currentItem.StartsWith(segment, StringComparison.InvariantCultureIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                lstbIntelligence.SelectedIndex = index;
                Point cursorPosition = txtCode.GetPositionFromCharIndex(txtCode.SelectionStart);
                lstbIntelligence.Left = txtCode.Left + cursorPosition.X;
                lstbIntelligence.Top = txtCode.Top + cursorPosition.Y + txtCode.Font.Height;
                lstbIntelligence.Tag = segment;
                lstbIntelligence.Visible = true;
                lstbIntelligence.BringToFront();
                lstbIntelligence.Focus();
            }
            else
            {
                lstbIntelligence.Visible = false;
                txtCode.Focus();
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddText(EventName.KeyPress, "type=Form(this)", "Form1", "this");
            if (e.KeyChar == (char)Keys.Escape)
            {
                lstbIntelligence.Visible = false;
            }
        }
        private void Form1_KeyDown1(object sender, KeyEventArgs e)
        {
            AddText(EventName.KeyDown, "type=Form(this)", "Form1", "this");
            if (e.KeyCode == Keys.B && e.Control)
            {
                if (txtCode.Focused)
                {
                    txtCode.Text = "";
                }
                else if (outputBox.Focused)
                {
                    outputBox.Text = "";
                }
            }
            else if (e.KeyCode == Keys.C && (e.Control && e.Alt))
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.I && (e.Control && e.Alt))
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (e.KeyCode == Keys.A && (e.Control && e.Alt))
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (e.KeyCode == Keys.O && (e.Control && e.Alt))
            {
                System.Diagnostics.Process.Start("cmd.exe");
            }
            else if (e.KeyCode == Keys.V && (e.Control && e.Shift))
            {
                new CodeCore.SourceCode().Show();
            }
            else if (e.KeyCode == Keys.P && (e.Control && e.Shift))
            {
                new CodeCore.AdvancedProperties().ShowDialog();
            }
            else if (e.KeyCode == Keys.F4 && (e.Control && e.Alt))
            {
                Application.Exit();
            }
        }
        private void TxtCode_MouseDown(object sender, MouseEventArgs e)
        {
            AddText(EventName.MouseDown, "type=RichTextBox", "Form1", "txtCode");
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem ClearMenuItem = new ToolStripMenuItem("Clear");
                ToolStripMenuItem PasteMenuItem = new ToolStripMenuItem("Paste");
                ToolStripMenuItem CopyMenuItem = new ToolStripMenuItem("Copy");
                ToolStripMenuItem CutMenuItem = new ToolStripMenuItem("Cut");
                ToolStripMenuItem SelectAllMenuItem = new ToolStripMenuItem("Select All");
                ToolStripMenuItem DeleteMenuItem = new ToolStripMenuItem($"Delete{delimiter}Backspace");
                ClearMenuItem.Click += (s, g) => { txtCode.Text = ""; };
                PasteMenuItem.Click += (s, g) => { txtCode.Paste(); };
                CopyMenuItem.Click += (s, g) => txtCode.Copy();
                CutMenuItem.Click += (s, g) => txtCode.Cut();
                SelectAllMenuItem.Click += (s, g) => txtCode.SelectAll();
                DeleteMenuItem.Click += (s, g) => txtCode.SelectedText = "";
                CutMenuItem.ShortcutKeys = Keys.Control | Keys.X;
                CopyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
                ClearMenuItem.ShortcutKeys = Keys.Control | Keys.B;
                PasteMenuItem.ShortcutKeys = Keys.Control | Keys.V;
                SelectAllMenuItem.ShortcutKeys = Keys.Control | Keys.A;
                contextMenuStrip.Items.Add(ClearMenuItem);
                contextMenuStrip.Items.Add(PasteMenuItem);
                contextMenuStrip.Items.Add(CopyMenuItem);
                contextMenuStrip.Items.Add(CutMenuItem);
                contextMenuStrip.Items.Add(SelectAllMenuItem);
                contextMenuStrip.Items.Add(DeleteMenuItem);
                contextMenuStrip.Show(txtCode, e.Location);
            }
        }
        private void OutputBox_MouseDown(object sender, MouseEventArgs e)
        {
            AddText(EventName.MouseDown, "type=RichTextBox", "Form1", "outputBox");
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem ClearMenuItem = new ToolStripMenuItem("Clear");
                ToolStripMenuItem CopyMenuItem = new ToolStripMenuItem("Copy");
                ToolStripMenuItem SelectAllMenuItem = new ToolStripMenuItem("Select All");
                ClearMenuItem.Click += (s, g) => { outputBox.Text = ""; };
                CopyMenuItem.Click += (s, g) => outputBox.Copy();
                SelectAllMenuItem.Click += (s, g) => outputBox.SelectAll();
                CopyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
                ClearMenuItem.ShortcutKeys = Keys.Control | Keys.B;
                SelectAllMenuItem.ShortcutKeys = Keys.Control | Keys.A;
                contextMenuStrip.Items.Add(ClearMenuItem);
                contextMenuStrip.Items.Add(CopyMenuItem);
                contextMenuStrip.Items.Add(SelectAllMenuItem);
                contextMenuStrip.Show(outputBox, e.Location);
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            AddText(EventName.TextChanged, "type=RichTextBox", "Form1", "txtCode");
            Debug.WriteLine(txtCode.SelectionStart);
            var index = txtCode.SelectionStart - 1;
            if (index >= 0 && txtCode.Text.Length > index)
            {
                string cha = txtCode.Text[index].ToString();
                while (cha != " " && cha != "\n")
                {
                    index--;
                    if (index < 0)
                    {
                        index = -1;
                        break;
                    }
                    cha = txtCode.Text[index].ToString();
                }
                var segment = txtCode.Text.Substring(index + 1, txtCode.SelectionStart - index - 1);
                Debug.WriteLine(segment);
                ShowIntelligenceIfNecessary(segment);
            }
        }

        private void lstbIntelligence_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddText(EventName.KeyPress, "type=ListBox", "Form1", "lstbIntelligence");
            try
            {
                int index1 = txtCode.SelectionStart;
                List<char> list = new List<char>
            {
                (char)Keys.Enter, (char)Keys.Up, (char)Keys.Down
            };
                if (!list.Contains(e.KeyChar))
                {
                    e.Handled = true;
                    txtCode.Text.Insert(index1, e.KeyChar.ToString());
                    txtCode.Focus();
                }
                //if (lstbIntelligence.Visible && e.KeyChar == (char)Keys.Up)
                //{
                //    lstbIntelligence.SelectedIndex += 1;
                //    return;
                //}
                //if (lstbIntelligence.Visible && e.KeyChar == (char)Keys.Down)
                //{
                //    lstbIntelligence.SelectedIndex -= 1;
                //    return;
                //}
                if (lstbIntelligence.Visible && e.KeyChar == (char)Keys.Enter)
                {
                    int index = txtCode.SelectionStart;
                    string keyword = lstbIntelligence.SelectedItem.ToString();
                    int segmentLength = lstbIntelligence.Tag.ToString().Length;
                    var oldKeyword = keyword;
                    keyword = keyword.Remove(0, segmentLength);
                    txtCode.Text = txtCode.Text.Insert(index, keyword);
                    lstbIntelligence.Visible = false;
                    txtCode.SelectionStart = index + (oldKeyword.Length - segmentLength);
                    txtCode.Focus();
                }
            }
            catch
            {
                return;
            }
        }
        private void txtCode_MouseClick(object sender, MouseEventArgs e)
        {
            lstbIntelligence.Visible = false;
            AddText(EventName.MouseClick, "type=RichTextBox", "Form1", "txtCode");
        }
        private enum EventName
        {
            MouseClick,
            MouseDoubleClick,
            KeyPress,
            KeyDown,
            Load,
            TextChanged,
            MouseDown,
            Click,
            Method,
            Ctor,
            Resize,
            DrawItem
        }
        private void AddText(EventName eventName, string moreInfomation, params string[] expression)
        {
            string expressionStr = "";
            foreach (var item in expression)
            {
                expressionStr += item + ".";
            }
            char[] chars = expressionStr.ToCharArray();
            chars[chars.Length - 1] = '[';
            expressionStr = new string(chars);
            logForm.textBox1.Text += $"[{DateTime.Now}] {Enum.GetName(typeof(EventName), eventName) + "Event"} at {expressionStr}{moreInfomation}]{Environment.NewLine}";
        }
        private void lstbIntelligence_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstbIntelligence.Visible)
            {
                try
                {
                    int index = txtCode.SelectionStart;
                    string keyword = lstbIntelligence.SelectedItem.ToString();
                    int segmentLength = lstbIntelligence.Tag.ToString().Length;
                    var oldKeyword = keyword;
                    keyword = keyword.Remove(0, segmentLength);
                    txtCode.Text = txtCode.Text.Insert(index, keyword);
                    lstbIntelligence.Visible = false;
                    txtCode.SelectionStart = index + (oldKeyword.Length - segmentLength);
                    txtCode.Focus();
                }
                catch
                {
                    return;
                }
            }
        }
        private void log_Click(object sender, EventArgs e)
        {
            AddText(EventName.Click, "type=Button", "Form1", "log");
            if (logForm.Visible)
            {
                logForm.Hide();
            }
            else
            {
                try
                {
                    logForm.Show();
                }
                catch
                {
                    logForm = new();
                    logForm.Show();
                }
            }
        }

        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }
    }
}

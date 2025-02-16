using FeiSharpStudio.Utils;
using IWshRuntimeLibrary;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using While = System.Windows.Forms.Timer;

namespace FeiSharpStudio
{
    public partial class MainForm : Form
    {
        Log logForm = new Log();
        List<string> keywords = new List<string>()
        {
            "var", "print", "init", "set", "import", "export", "start", "stop", "wait", "watchstart", "watchend", "abe", "helper", "if", "while", "dowhile", "throw", "class","func", "return", "gethtml", "getVarsFromJsonFilePath","invoke","read","anno","define","readline","readkey","ctype","cstr","astextbox","createData","addData","delData","replaceData","saceDataChanges","invokeData","getData","createInstance","setClassVar","setBaseClass","printMethod"
        };
        private readonly static string delimiter = "                    ";
        While @while = new While();
        public MainForm()
        {
            AddText(EventName.Ctor, "type=Method", "Form1", "ctor Form1()");
            InitializeComponent();
            string codeText = "using System;\npublic class Program\n{\n    public static void Main()\n    {\n        Console.WriteLine(\"Hello, World!\");\n    }\n}";
            this.DoubleBuffered = true;
            this.KeyDown += Form1_KeyDown;
            this.WindowState = FormWindowState.Maximized;
            lineNumberListBox.Font = txtCode.Font;
            lineNumberListBox.ItemHeight = txtCode.Font.Height;
            txtCode.VScroll += TxtCode_VScroll;

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
            ShortCutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ShortCutBtn.FlatAppearance.BorderSize = 0;
            CheckBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CheckBtn.FlatAppearance.BorderSize = 0;
            log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            log.FlatAppearance.BorderSize = 0;
            developer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            developer.FlatAppearance.BorderSize = 0;
            exit.Text = "exit";
            exit.BackColor = Color.LightYellow;
            exit.ShortcutKeys = Keys.Control | Keys.Alt | Keys.F4;
            exit.Click += (s, e) =>
            {
                Application.Exit();
            };
            properties.Text = "properties";
            properties.BackColor = Color.LightYellow;
            properties.ShortcutKeys = Keys.P | Keys.Control | Keys.Shift;
            properties.Click += (s, e) =>
            {
                new CodeCore.AdvancedProperties().ShowDialog();
            };
            lineNumberListBox.DataSource = ints;
            lineNumberListBox.DisplayMember = "Name";
            @while.Interval = 250;
            @while.Start();
            @while.Tick += @while_Tick;
            contextMenuStrip1.Items.AddRange([exit, properties]);
            ShortCutBtn.SendToBack();
            this.FormClosing += MainForm_FormClosing;
        }
        private void TxtCode_VScroll(object sender, EventArgs e)
        {
            lineNumberListBox.TopIndex = txtCode.GetFirstCharIndexFromLine(txtCode.GetLineFromCharIndex(txtCode.GetCharIndexFromPosition(new Point(0, 0))));
        }
        BindingList<Number> ints = new BindingList<Number>() { new Number() { Name = "1" } };
        private void LineNumberListBox_VScroll(object sender, MouseEventArgs e)
        {
            int visibleItemCount = lineNumberListBox.ClientSize.Height / lineNumberListBox.ItemHeight;

            int newTopIndex = lineNumberListBox.TopIndex - (e.Delta / 120);
            if (newTopIndex < 0) newTopIndex = 0;
            if (newTopIndex > ints.Count - visibleItemCount)
            {
                newTopIndex = ints.Count - visibleItemCount;
            }
            lineNumberListBox.TopIndex = newTopIndex;

            txtCode.SelectionStart = txtCode.GetFirstCharIndexFromLine(lineNumberListBox.TopIndex);
            txtCode.ScrollToCaret();
        }

        private void UpdateLineNumbers()
        {
            ints.Clear();
            int lineCount = txtCode.Lines.Length;
            for (int i = 1; i <= lineCount; i++)
            {
                ints.Add(new Number() { Name = i.ToString() });
            }
            if (ints.Count == 0)
            {
                ints.Add(new Number() { Name = "1" });
            }
        }

        private void LineNumberListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                string lineNumber = ints[e.Index].ToString();
                e.Graphics.DrawString(lineNumber, e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            }
            e.DrawFocusRectangle();
        }
        private string GetCurrentLineText(RichTextBox rtb)
        {
            int start = rtb.SelectionStart;
            int line = rtb.GetLineFromCharIndex(start);
            int lineStart = rtb.GetFirstCharIndexFromLine(line);
            int lineEnd = rtb.GetFirstCharIndexFromLine(line + 1);
            if (lineEnd < 0)
                lineEnd = rtb.Text.Length;
            return rtb.Text.Substring(lineStart, lineEnd - lineStart);
        }
        private void DeleteCurrentLine(RichTextBox rtb)
        {
            int start = rtb.SelectionStart;
            int line = rtb.GetLineFromCharIndex(start);
            int lineStart = rtb.GetFirstCharIndexFromLine(line);
            int lineEnd = rtb.GetFirstCharIndexFromLine(line + 1);
            if (lineEnd < 0)
                lineEnd = rtb.Text.Length;
            rtb.Text = rtb.Text.Remove(lineStart, lineEnd - lineStart);
            rtb.SelectionStart = lineStart;
        }
        private void ReplaceLineWithText(RichTextBox rtb, int lineNumber, string replacementText)
        {
            if (lineNumber > 0 && lineNumber <= rtb.Lines.Length)
            {
                int startIndex = rtb.GetFirstCharIndexFromLine(lineNumber - 1);
                int endIndex;
                if (lineNumber < rtb.Lines.Length)
                {
                    endIndex = rtb.GetFirstCharIndexFromLine(lineNumber);
                }
                else
                {
                    endIndex = rtb.Text.Length;
                }
                rtb.Select(startIndex, endIndex - startIndex);
                rtb.SelectedText = $"{replacementText}{rtb.SelectedText}";
            }
        }

        string version = Tab.version8_5;
        private void @while_Tick(object? sender, EventArgs e)
        {
            if (Tab.Version != version)
            {
                version = Tab.Version;
                if (Tab.Version == Tab.version8)
                {
                    this.CheckBtn.Text = "Properties";
                    this.CheckBtn.Click -= BtnCheckClick;
                    this.CheckBtn.Click += ShowProperty;
                    return;
                }
                else if (Tab.Version == Tab.version8_5)
                {
                    this.CheckBtn.Text = "Check";
                    this.CheckBtn.Click -= ShowProperty;
                    this.CheckBtn.Click += BtnCheckClick;
                    return;
                }
                else
                {
                    return;
                }
            }
        }
        private void ShowProperty(object sender, EventArgs e)
        {
            if (Tab.Version != Tab.version8_5)
                new CodeCore.AdvancedProperties().ShowDialog();

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
        private Process externalProcess;
        private void Run()
        {
            AddText(EventName.Method, "type=Method", "Form1", "void Run()[2 references]");
            if (checkBox3.Checked)
            {
                System.IO.File.WriteAllText(@"C:\Users\benba\OneDrive\Documents\a.txt", txtCode.Text);
                Process.Start("WindowsPUI.exe");
            }
            else
            {
                if (checkBox2.Checked)
                {
                    outputBox.Text = string.Empty;
                }
                else
                {
                    outputBox.Text += "Build started......" + Environment.NewLine+ "(CoreCLR: clrhost): Loaded source code......" + Environment.NewLine;
                    outputBox.Text += "Input file then press enter and input ~code.fsc then also press enter to run this application."+Environment.NewLine;
                }
                System.IO.File.WriteAllText("~code.fsc", txtCode.Text);
                Process.Start("feisharp.exe");
            }
        }
        private void ExternalProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    outputBox.Text += e.Data + Environment.NewLine;
                });
            }
        }


        private void BtnSaveAsClick(object sender, EventArgs e)
        {
            AddText(EventName.Click, "type=Button", "Form1", "btnSaveAs");

            SaveAs();
        }



        private void FeiSharpForm_Resize(object sender, EventArgs e)
        {
            AddText(EventName.Resize, "type=Form(this)", "Form1", "this");
            txtCode.Width = outputBox.ClientSize.Width;
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
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string filePath = args[1];
                try
                {
                    string text = System.IO.File.ReadAllText(filePath);
                    txtCode.Text = text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }
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
            if (Tab.Version != Tab.version8)
            {
                AddText(EventName.Click, "type=Button", "Form1", "btnCheck");
                outputBox.Text += "Nothings unvalid."+Environment.NewLine;
            }
        }

        private void ShowIntelligenceIfNecessary(string segment)
        {
            if(checkBox4.Checked)
            {
                lstbIntelligence.Visible = false;
            }
            else
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
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddText(EventName.KeyPress, "type=Form(this)", "Form1", "this");

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
                ToolStripMenuItem UndoMenuItem = new ToolStripMenuItem("Undo");
                ToolStripMenuItem DeleteMenuItem = new ToolStripMenuItem($"Delete{delimiter}Backspace");
                ClearMenuItem.Click += (s, g) => { txtCode.Text = ""; };
                PasteMenuItem.Click += (s, g) => { txtCode.Paste(); };
                CopyMenuItem.Click += (s, g) => txtCode.Copy();
                CutMenuItem.Click += (s, g) => txtCode.Cut();
                SelectAllMenuItem.Click += (s, g) => txtCode.SelectAll();
                UndoMenuItem.Click += (s, g) =>
                {
                    if (txtCode.CanUndo)
                    {
                        txtCode.Undo();
                        txtCode.ClearUndo();
                    }
                };
                DeleteMenuItem.Click += (s, g) => txtCode.SelectedText = "";
                CutMenuItem.ShortcutKeys = Keys.Control | Keys.X;
                CopyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
                ClearMenuItem.ShortcutKeys = Keys.Control | Keys.B;
                PasteMenuItem.ShortcutKeys = Keys.Control | Keys.V;
                SelectAllMenuItem.ShortcutKeys = Keys.Control | Keys.A;
                UndoMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
                contextMenuStrip.Items.Add(ClearMenuItem);
                contextMenuStrip.Items.Add(PasteMenuItem);
                contextMenuStrip.Items.Add(CopyMenuItem);
                contextMenuStrip.Items.Add(CutMenuItem);
                contextMenuStrip.Items.Add(SelectAllMenuItem);
                contextMenuStrip.Items.Add(DeleteMenuItem);
                contextMenuStrip.Items.Add(UndoMenuItem);
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
            UpdateLineNumbers();
            List<string> args = new(txtCode.Text.Split(' '));
            foreach (string arg in args)
            {
                if (!keywords.Contains(arg) && (!arg.Contains('{') && !arg.Contains('[') && !arg.Contains(']') && !arg.Contains('}')))
                {
                    bool isValid = true;
                    foreach (string keyword in keywords)
                    {
                        if (arg.Contains(keyword))
                        {
                            isValid = false;
                        }
                    }
                    if (isValid)
                    {
                        keywords.Add(arg);
                    }
                }
            }
            var indexc = txtCode.SelectionStart;
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
            txtCode.Text = txtCode.Text.Replace("\b", "");
            txtCode.SelectionStart = indexc;
        }
        private void lstbIntelligence_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddText(EventName.KeyPress, "type=ListBox", "Form1", "lstbIntelligence");
            try
            {
                int index1 = txtCode.SelectionStart;
                if (e.KeyChar != (char)Keys.Enter)
                {
                    if (e.KeyChar == (char)Keys.Back)
                    {
                        e.Handled = true;
                        lstbIntelligence.Visible = false;
                        txtCode.Text = txtCode.Text.Substring(0, txtCode.TextLength - 1);
                        txtCode.SelectionStart = index1 - 1;
                        txtCode.Focus();
                    }
                    else if (e.KeyChar == (char)Keys.Escape)
                    {
                        int start = txtCode.SelectionStart;
                        string txtCodeText = txtCode.Text;
                        lstbIntelligence.Visible = false;
                        txtCode.SelectionStart = (start + (txtCode.TextLength - txtCodeText.Length)) == 0 ? start : (start + (txtCode.TextLength - txtCodeText.Length));
                        txtCode.Focus();
                    }
                    else if (e.KeyChar == '(')
                    {
                        int start = txtCode.SelectionStart;
                        txtCode.Text = txtCode.Text.Insert(txtCode.SelectionStart, "()");
                        txtCode.SelectionStart = start + 1;
                        e.Handled = true;
                        lstbIntelligence.Visible = false;
                    }
                    else if (e.KeyChar == '"')
                    {
                        int start = txtCode.SelectionStart;
                        txtCode.Text = txtCode.Text.Insert(txtCode.SelectionStart, "\"\"");
                        txtCode.SelectionStart = start + 1;
                        e.Handled = true;
                        lstbIntelligence.Visible = false;
                    }
                    else if (!char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                        lstbIntelligence.Visible = false;
                        txtCode.Text = txtCode.Text.Insert(index1, e.KeyChar.ToString());
                        txtCode.Focus();
                        txtCode.SelectionStart = index1 + 1;
                    }
                }
                if (lstbIntelligence.Visible && e.KeyChar == (char)Keys.Enter)
                {
                    int index = txtCode.SelectionStart;
                    string keyword = lstbIntelligence.SelectedItem.ToString();
                    int segmentLength = lstbIntelligence.Tag.ToString().Length;
                    txtCode.Text = ReplaceNearestTarget(txtCode.Text, index, lstbIntelligence.Tag.ToString(), keyword);
                    lstbIntelligence.Visible = false;
                    txtCode.SelectionStart = index + keyword.Length;
                    txtCode.Focus();
                }
            }
            catch
            {
                return;
            }
        }
        string ReplaceNearestTarget(string str, int index, string target, string newStr)
        {
            int forwardIndex = str.IndexOf(target, index);
            int backwardIndex = str.LastIndexOf(target, index);
            if (forwardIndex == -1 && backwardIndex == -1)
            {
                return str;
            }
            if (forwardIndex != -1 && backwardIndex == -1)
            {
                return str.Remove(forwardIndex, target.Length).Insert(forwardIndex, newStr);
            }
            if (forwardIndex == -1 && backwardIndex != -1)
            {
                return str.Remove(backwardIndex, target.Length).Insert(backwardIndex, newStr);
            }
            int forwardDistance = Math.Abs(forwardIndex - index);
            int backwardDistance = Math.Abs(backwardIndex - index);
            if (forwardDistance <= backwardDistance)
            {
                return str.Remove(forwardIndex, target.Length).Insert(forwardIndex, newStr);
            }
            else
            {
                return str.Remove(backwardIndex, target.Length).Insert(backwardIndex, newStr);
            }
        }
        private void txtCode_MouseClick(object sender, MouseEventArgs e)
        {
            lstbIntelligence.Visible = false;
            AddText(EventName.MouseClick, "type=RichTextBox", "Form1", "txtCode");
        }
        private void TxtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.X)
            {
                if (txtCode.SelectionLength == 0)
                {
                    DeleteCurrentLine(txtCode);
                }
                else
                {
                    txtCode.Cut();
                }
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                if (txtCode.SelectionLength == 0)
                {
                    Clipboard.SetText(GetCurrentLineText(txtCode));
                }
                else
                {
                    txtCode.Copy();
                }
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                if (txtCode.CanUndo)
                {
                    txtCode.Undo();
                    txtCode.ClearUndo();
                }
            }
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
                    txtCode.Text = txtCode.Text.Replace(lstbIntelligence.Tag.ToString(), keyword);
                    lstbIntelligence.Visible = false;
                    txtCode.SelectionStart = index + keyword.Length;
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

        private void developer_Click(object sender, EventArgs e)
        {
            Process.Start("feisharp.exe");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void LineNumberListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem CutMenuItem = new ToolStripMenuItem("Add breakpoint");
                CutMenuItem.Click += (s, g) =>
                {
                    ReplaceLineWithText(txtCode, lineNumberListBox.SelectedIndex + 1, "stop;");
                };
                contextMenuStrip.Items.Add(CutMenuItem);
                contextMenuStrip.Show(lineNumberListBox, e.Location);
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                keywords = ["form-backcolor: ", "form-text: ", "form-opacity: ", "form-windowstate: ", "Maximized", "Minimized", "Normal", "form-event: ", "load", "resize", "shake", "type: ", "button", "label", "textbox", "name: ", "text: ", "location: ", "x: ", "y: ", "size: ", "width: ", "height: ", "event: ", "click", "double-click", "mouse-double-click", "form-size: ", "{}", "->", ": ", "mouse-move", "mouse-down", "mouse-up"];
            }
            else
            {
                keywords = ["var", "print", "init", "set", "import", "export", "start", "stop", "wait", "watchstart", "watchend", "abe", "helper", "if", "while", "dowhile", "throw", "class", "func", "return", "gethtml", "getVarsFromJsonFilePath", "invoke", "read", "anno", "define", "readline", "readkey", "ctype", "cstr", "astextbox", "createData", "addData", "delData", "replaceData", "saceDataChanges", "invokeData", "getData", "createInstance", "setClassVar", "setBaseClass", "printMethod"];
            }
        }

        private void lineNumberListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lineNumber = lineNumberListBox.SelectedIndex;
            if (lineNumber > 0 && lineNumber <= txtCode.Lines.Length)
            {
                int charIndex = txtCode.GetFirstCharIndexFromLine(lineNumber);
                txtCode.SelectionStart = charIndex;
                txtCode.SelectionLength = 0;
                txtCode.ScrollToCaret();
            }
            txtCode.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            this.Refresh();
        }
    }
    public class Number : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

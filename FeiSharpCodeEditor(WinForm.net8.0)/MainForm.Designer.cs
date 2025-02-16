using FastColoredTextBoxNS;
using FeiSharpStudio;

namespace FeiSharpStudio
{
  
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            RunBtn = new Button();
            SaveAsBtn = new Button();
            OpenBtn = new Button();
            Menu = new Button();
            ShortCutBtn = new Button();
            outputBox = new RichTextBox();
            CheckBtn = new Button();
            txtCode = new RichTextBox();
            lstbIntelligence = new ListBox();
            log = new Button();
            toolStripMenuItem1 = new ToolStripMenuItem();
            notify = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            exit = new ToolStripMenuItem();
            properties = new ToolStripMenuItem();
            developer = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            lineNumberListBox = new ListBox();
            button1 = new Button();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            SuspendLayout();
            // 
            // RunBtn
            // 
            RunBtn.Location = new Point(92, 2);
            RunBtn.Margin = new Padding(1, 2, 1, 2);
            RunBtn.Name = "RunBtn";
            RunBtn.Size = new Size(111, 46);
            RunBtn.TabIndex = 0;
            RunBtn.Text = "Run(F5)";
            RunBtn.UseVisualStyleBackColor = true;
            RunBtn.Click += BtnRunClick;
            // 
            // SaveAsBtn
            // 
            SaveAsBtn.Location = new Point(205, 2);
            SaveAsBtn.Margin = new Padding(1, 2, 1, 2);
            SaveAsBtn.Name = "SaveAsBtn";
            SaveAsBtn.Size = new Size(151, 46);
            SaveAsBtn.TabIndex = 1;
            SaveAsBtn.Text = "Save As(CTRL+S)";
            SaveAsBtn.UseVisualStyleBackColor = true;
            SaveAsBtn.Click += BtnSaveAsClick;
            // 
            // OpenBtn
            // 
            OpenBtn.Location = new Point(359, 2);
            OpenBtn.Margin = new Padding(1, 2, 1, 2);
            OpenBtn.Name = "OpenBtn";
            OpenBtn.Size = new Size(180, 46);
            OpenBtn.TabIndex = 2;
            OpenBtn.Text = "Open File(CTRL+F)";
            OpenBtn.UseVisualStyleBackColor = true;
            OpenBtn.Click += BtnOpenFileClick;
            // 
            // Menu
            // 
            Menu.Location = new Point(2, 2);
            Menu.Margin = new Padding(1, 2, 1, 2);
            Menu.Name = "Menu";
            Menu.Size = new Size(88, 46);
            Menu.TabIndex = 6;
            Menu.Text = "Menu";
            Menu.UseVisualStyleBackColor = true;
            Menu.Click += BtnMenuClick;
            // 
            // ShortCutBtn
            // 
            ShortCutBtn.Location = new Point(542, 2);
            ShortCutBtn.Margin = new Padding(1, 2, 1, 2);
            ShortCutBtn.Name = "ShortCutBtn";
            ShortCutBtn.Size = new Size(237, 46);
            ShortCutBtn.TabIndex = 8;
            ShortCutBtn.Text = "Create Desktop Shortcut";
            ShortCutBtn.UseVisualStyleBackColor = true;
            ShortCutBtn.Click += BtnShortcutClick;
            // 
            // outputBox
            // 
            outputBox.BackColor = Color.FromArgb(30, 30, 30);
            outputBox.BorderStyle = BorderStyle.FixedSingle;
            outputBox.Dock = DockStyle.Bottom;
            outputBox.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            outputBox.ForeColor = Color.FromArgb(86, 156, 214);
            outputBox.Location = new Point(0, 1913);
            outputBox.Margin = new Padding(1, 2, 1, 2);
            outputBox.Name = "outputBox";
            outputBox.ReadOnly = true;
            outputBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            outputBox.Size = new Size(2508, 217);
            outputBox.TabIndex = 10;
            outputBox.Text = "";
            outputBox.MouseDown += OutputBox_MouseDown;
            // 
            // CheckBtn
            // 
            CheckBtn.Location = new Point(781, 2);
            CheckBtn.Margin = new Padding(1, 2, 1, 2);
            CheckBtn.Name = "CheckBtn";
            CheckBtn.Size = new Size(108, 46);
            CheckBtn.TabIndex = 11;
            CheckBtn.Text = "Check";
            CheckBtn.UseVisualStyleBackColor = true;
            CheckBtn.Click += BtnCheckClick;
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.FromArgb(30, 30, 30);
            txtCode.BorderStyle = BorderStyle.FixedSingle;
            txtCode.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCode.ForeColor = Color.FromArgb(86, 156, 214);
            txtCode.Location = new Point(57, 131);
            txtCode.Margin = new Padding(1, 2, 1, 2);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(2451, 1609);
            txtCode.TabIndex = 13;
            txtCode.Text = "";
            txtCode.MouseClick += txtCode_MouseClick;
            txtCode.TextChanged += txtCode_TextChanged;
            txtCode.KeyDown += TxtCode_KeyDown;
            txtCode.KeyPress += CodeEditor_KeyPress;
            txtCode.MouseDown += TxtCode_MouseDown;
            // 
            // lstbIntelligence
            // 
            lstbIntelligence.BackColor = Color.Black;
            lstbIntelligence.ForeColor = Color.Blue;
            lstbIntelligence.FormattingEnabled = true;
            lstbIntelligence.Items.AddRange(new object[] { "var", "print", "init", "set", "import", "export", "start", "stop", "wait", "watchstart", "watchend", "abe", "helper", "if", "while", "func", "return", "gethtml", "getVarsFromJsonFilePath" });
            lstbIntelligence.Location = new Point(57, 52);
            lstbIntelligence.Margin = new Padding(1, 2, 1, 2);
            lstbIntelligence.Name = "lstbIntelligence";
            lstbIntelligence.Size = new Size(216, 148);
            lstbIntelligence.TabIndex = 14;
            lstbIntelligence.Visible = false;
            lstbIntelligence.KeyPress += lstbIntelligence_KeyPress;
            lstbIntelligence.MouseDoubleClick += lstbIntelligence_MouseDoubleClick;
            // 
            // log
            // 
            log.Location = new Point(892, 2);
            log.Margin = new Padding(1, 2, 1, 2);
            log.Name = "log";
            log.Size = new Size(98, 46);
            log.TabIndex = 15;
            log.Text = "log";
            log.UseVisualStyleBackColor = true;
            log.Click += log_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(32, 19);
            // 
            // notify
            // 
            notify.ContextMenuStrip = contextMenuStrip1;
            notify.Icon = (Icon)resources.GetObject("notify.Icon");
            notify.Text = "FeiSharpStudio";
            notify.Visible = true;
            notify.MouseDoubleClick += notify_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(48, 48);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // exit
            // 
            exit.Name = "exit";
            exit.Size = new Size(420, 54);
            exit.Text = "exit";
            // 
            // properties
            // 
            properties.Name = "properties";
            properties.Size = new Size(420, 54);
            properties.Text = "properties";
            // 
            // developer
            // 
            developer.Location = new Point(992, 2);
            developer.Margin = new Padding(1, 2, 1, 2);
            developer.Name = "developer";
            developer.Size = new Size(175, 46);
            developer.TabIndex = 16;
            developer.Text = "Developer Cmd";
            developer.UseVisualStyleBackColor = true;
            developer.Click += developer_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(1946, 12);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(221, 28);
            checkBox1.TabIndex = 17;
            checkBox1.Text = "use performance mode";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(2173, 12);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(323, 28);
            checkBox2.TabIndex = 18;
            checkBox2.Text = "remove output intelligence message\r\n";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(1751, 12);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(189, 28);
            checkBox3.TabIndex = 19;
            checkBox3.Text = "WindowsPUI Mode";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // lineNumberListBox
            // 
            lineNumberListBox.FormattingEnabled = true;
            lineNumberListBox.Location = new Point(2, 128);
            lineNumberListBox.Name = "lineNumberListBox";
            lineNumberListBox.Size = new Size(56, 1612);
            lineNumberListBox.TabIndex = 20;
            lineNumberListBox.DoubleClick += lineNumberListBox_SelectedIndexChanged;
            lineNumberListBox.MouseDown += LineNumberListBox_MouseDown;
            // 
            // button1
            // 
            button1.Location = new Point(1169, 2);
            button1.Margin = new Padding(1, 2, 1, 2);
            button1.Name = "button1";
            button1.Size = new Size(175, 46);
            button1.TabIndex = 21;
            button1.Text = "New";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(1348, 12);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(154, 28);
            checkBox4.TabIndex = 22;
            checkBox4.Text = "do not use IDE";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Enabled = false;
            checkBox5.Location = new Point(1523, 12);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(222, 28);
            checkBox5.TabIndex = 23;
            checkBox5.Text = "build with [feisharp.exe]";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(2508, 2130);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(button1);
            Controls.Add(lineNumberListBox);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(developer);
            Controls.Add(log);
            Controls.Add(lstbIntelligence);
            Controls.Add(txtCode);
            Controls.Add(CheckBtn);
            Controls.Add(outputBox);
            Controls.Add(ShortCutBtn);
            Controls.Add(Menu);
            Controls.Add(OpenBtn);
            Controls.Add(SaveAsBtn);
            Controls.Add(RunBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(1, 2, 1, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FeiSharpStudio-Console";
            Load += FeiSharpForm_Load;
            KeyDown += Form1_KeyDown1;
            KeyPress += Form1_KeyPress;
            MouseDown += MainForm_MouseDown;
            Resize += FeiSharpForm_Resize;
            ResumeLayout(false);
            PerformLayout();
        }








        #endregion
        private Button RunBtn;
        private Button SaveAsBtn;
        private Button OpenBtn;
        private Button Menu;
        private Button ShortCutBtn;
        internal RichTextBox outputBox;
        private Button CheckBtn;
        private ListBox lstbIntelligence;
        private Button log;
        private ToolStripMenuItem toolStripMenuItem1;
        private NotifyIcon notify;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exit;
        private ToolStripMenuItem properties;
        private Button developer;
        internal RichTextBox txtCode;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private ListBox lineNumberListBox;
        private Button button1;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
    }
}

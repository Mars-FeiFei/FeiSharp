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
            label1 = new Label();
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
            SuspendLayout();
            // 
            // RunBtn
            // 
            RunBtn.Location = new Point(199, 3);
            RunBtn.Name = "RunBtn";
            RunBtn.Size = new Size(245, 88);
            RunBtn.TabIndex = 0;
            RunBtn.Text = "Run(F5)";
            RunBtn.UseVisualStyleBackColor = true;
            RunBtn.Click += BtnRunClick;
            // 
            // SaveAsBtn
            // 
            SaveAsBtn.Location = new Point(450, 3);
            SaveAsBtn.Name = "SaveAsBtn";
            SaveAsBtn.Size = new Size(333, 88);
            SaveAsBtn.TabIndex = 1;
            SaveAsBtn.Text = "Save As(CTRL+S)";
            SaveAsBtn.UseVisualStyleBackColor = true;
            SaveAsBtn.Click += BtnSaveAsClick;
            // 
            // OpenBtn
            // 
            OpenBtn.Location = new Point(789, 3);
            OpenBtn.Name = "OpenBtn";
            OpenBtn.Size = new Size(397, 88);
            OpenBtn.TabIndex = 2;
            OpenBtn.Text = "Open File(CTRL+F)";
            OpenBtn.UseVisualStyleBackColor = true;
            OpenBtn.Click += BtnOpenFileClick;
            // 
            // Menu
            // 
            Menu.Location = new Point(5, 3);
            Menu.Name = "Menu";
            Menu.Size = new Size(188, 88);
            Menu.TabIndex = 6;
            Menu.Text = "Menu";
            Menu.UseVisualStyleBackColor = true;
            Menu.Click += BtnMenuClick;
            // 
            // ShortCutBtn
            // 
            ShortCutBtn.Location = new Point(1192, 3);
            ShortCutBtn.Name = "ShortCutBtn";
            ShortCutBtn.Size = new Size(521, 88);
            ShortCutBtn.TabIndex = 8;
            ShortCutBtn.Text = "Create Desktop Shortcut";
            ShortCutBtn.UseVisualStyleBackColor = true;
            ShortCutBtn.Click += BtnShortcutClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 1390);
            label1.Name = "label1";
            label1.Size = new Size(142, 46);
            label1.TabIndex = 9;
            label1.Text = "Output";
            // 
            // outputBox
            // 
            outputBox.BackColor = Color.FromArgb(64, 64, 64);
            outputBox.BorderStyle = BorderStyle.FixedSingle;
            outputBox.Dock = DockStyle.Bottom;
            outputBox.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            outputBox.ForeColor = Color.White;
            outputBox.Location = new Point(0, 1453);
            outputBox.Name = "outputBox";
            outputBox.ReadOnly = true;
            outputBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            outputBox.Size = new Size(2532, 417);
            outputBox.TabIndex = 10;
            outputBox.Text = "";
            outputBox.MouseDown += OutputBox_MouseDown;
            // 
            // CheckBtn
            // 
            CheckBtn.Location = new Point(1719, 3);
            CheckBtn.Name = "CheckBtn";
            CheckBtn.Size = new Size(237, 88);
            CheckBtn.TabIndex = 11;
            CheckBtn.Text = "Check";
            CheckBtn.UseVisualStyleBackColor = true;
            CheckBtn.Click += BtnCheckClick;
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.FromArgb(64, 64, 64);
            txtCode.BorderStyle = BorderStyle.FixedSingle;
            txtCode.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCode.ForeColor = Color.White;
            txtCode.Location = new Point(7, 251);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(2525, 1139);
            txtCode.TabIndex = 13;
            txtCode.Text = "";
            txtCode.MouseClick += txtCode_MouseClick;
            txtCode.TextChanged += txtCode_TextChanged;
            txtCode.KeyPress += CodeEditor_KeyPress;
            txtCode.MouseDown += TxtCode_MouseDown;
            txtCode.KeyDown += TxtCode_KeyDown;
            // 
            // lstbIntelligence
            // 
            lstbIntelligence.BackColor = Color.Black;
            lstbIntelligence.ForeColor = Color.Blue;
            lstbIntelligence.FormattingEnabled = true;
            lstbIntelligence.Items.AddRange(new object[] { "var", "print", "init", "set", "import", "export", "start", "stop", "wait", "watchstart", "watchend", "abe", "helper", "if", "while", "func", "return", "gethtml", "getVarsFromJsonFilePath" });
            lstbIntelligence.Location = new Point(125, 146);
            lstbIntelligence.Name = "lstbIntelligence";
            lstbIntelligence.Size = new Size(470, 280);
            lstbIntelligence.TabIndex = 14;
            lstbIntelligence.Visible = false;
            lstbIntelligence.KeyPress += lstbIntelligence_KeyPress;
            lstbIntelligence.MouseDoubleClick += lstbIntelligence_MouseDoubleClick;
            // 
            // log
            // 
            log.Location = new Point(1962, 3);
            log.Name = "log";
            log.Size = new Size(215, 88);
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
            developer.Location = new Point(2183, 3);
            developer.Name = "developer";
            developer.Size = new Size(337, 88);
            developer.TabIndex = 16;
            developer.Text = "Developer Cmd";
            developer.UseVisualStyleBackColor = true;
            developer.Click += developer_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(22F, 46F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(2532, 1870);
            Controls.Add(developer);
            Controls.Add(log);
            Controls.Add(lstbIntelligence);
            Controls.Add(txtCode);
            Controls.Add(CheckBtn);
            Controls.Add(outputBox);
            Controls.Add(label1);
            Controls.Add(ShortCutBtn);
            Controls.Add(Menu);
            Controls.Add(OpenBtn);
            Controls.Add(SaveAsBtn);
            Controls.Add(RunBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
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
        private Label label1;
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
    }
}

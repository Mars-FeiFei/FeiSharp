namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            RunBtn = new Button();
            SaveAsBtn = new Button();
            OpenBtn = new Button();
            comboKeywords = new ComboBox();
            comboBoxStatement = new ComboBox();
            Menu = new Button();
            ShortCutBtn = new Button();
            label1 = new Label();
            outputBox = new TextBox();
            CheckBtn = new Button();
            comboBoxClear = new ComboBox();
            txtCode = new RichTextBox();
            lstbIntelligence = new ListBox();
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
            SaveAsBtn.Location = new Point(450, -6);
            SaveAsBtn.Name = "SaveAsBtn";
            SaveAsBtn.Size = new Size(333, 97);
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
            // comboKeywords
            // 
            comboKeywords.FlatStyle = FlatStyle.Popup;
            comboKeywords.FormattingEnabled = true;
            comboKeywords.Items.AddRange(new object[] { "var", "print", "init", "set", "import", "export", "start", "stop", "wait", "watchstart", "watchend", "abe", "helper" });
            comboKeywords.Location = new Point(1869, 12);
            comboKeywords.Name = "comboKeywords";
            comboKeywords.Size = new Size(329, 54);
            comboKeywords.TabIndex = 4;
            comboKeywords.Visible = false;
            comboKeywords.SelectedIndexChanged += CbxKeywords_SelectedIndexChanged;
            // 
            // comboBoxStatement
            // 
            comboBoxStatement.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatement.FormattingEnabled = true;
            comboBoxStatement.Items.AddRange(new object[] { "if", "while", "func" });
            comboBoxStatement.Location = new Point(1869, 82);
            comboBoxStatement.Name = "comboBoxStatement";
            comboBoxStatement.Size = new Size(334, 54);
            comboBoxStatement.TabIndex = 5;
            comboBoxStatement.Visible = false;
            comboBoxStatement.SelectedIndexChanged += CbxStatement_SelectedIndexChanged;
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
            label1.Size = new Size(136, 46);
            label1.TabIndex = 9;
            label1.Text = "output";
            // 
            // outputBox
            // 
            outputBox.BackColor = Color.FromArgb(64, 64, 64);
            outputBox.Dock = DockStyle.Bottom;
            outputBox.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            outputBox.ForeColor = Color.White;
            outputBox.Location = new Point(0, 1453);
            outputBox.Multiline = true;
            outputBox.Name = "outputBox";
            outputBox.ReadOnly = true;
            outputBox.ScrollBars = ScrollBars.Vertical;
            outputBox.Size = new Size(2401, 417);
            outputBox.TabIndex = 10;
            // 
            // CheckBtn
            // 
            CheckBtn.Location = new Point(1719, 3);
            CheckBtn.Name = "CheckBtn";
            CheckBtn.Size = new Size(136, 88);
            CheckBtn.TabIndex = 11;
            CheckBtn.Text = "Check";
            CheckBtn.UseVisualStyleBackColor = true;
            CheckBtn.Click += BtnCheckClick;
            // 
            // comboBoxClear
            // 
            comboBoxClear.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClear.FormattingEnabled = true;
            comboBoxClear.Items.AddRange(new object[] { "clear codes", "clear output" });
            comboBoxClear.Location = new Point(1877, 165);
            comboBoxClear.Name = "comboBoxClear";
            comboBoxClear.Size = new Size(329, 54);
            comboBoxClear.TabIndex = 12;
            comboBoxClear.SelectedIndexChanged += cbxClear_SelectedIndexChanged;
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.FromArgb(64, 64, 64);
            txtCode.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCode.ForeColor = Color.White;
            txtCode.Location = new Point(7, 251);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(2382, 1139);
            txtCode.TabIndex = 13;
            txtCode.Text = "";
            txtCode.TextChanged += txtCode_TextChanged;
            txtCode.KeyPress += CodeEditor_KeyPress;
            // 
            // lstbIntelligence
            // 
            lstbIntelligence.FormattingEnabled = true;
            lstbIntelligence.Items.AddRange(new object[] { "var", "print", "init", "set", "import", "export", "start", "stop", "wait", "watchstart", "watchend", "abe", "helper", "if", "while", "func" });
            lstbIntelligence.Location = new Point(124, 152);
            lstbIntelligence.Name = "lstbIntelligence";
            lstbIntelligence.Size = new Size(360, 280);
            lstbIntelligence.TabIndex = 14;
            lstbIntelligence.Visible = false;
            lstbIntelligence.SelectedIndexChanged += lstbIntelligence_SelectedIndexChanged;
            lstbIntelligence.KeyPress += lstbIntelligence_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(22F, 46F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(2401, 1870);
            Controls.Add(lstbIntelligence);
            Controls.Add(txtCode);
            Controls.Add(comboBoxClear);
            Controls.Add(CheckBtn);
            Controls.Add(outputBox);
            Controls.Add(label1);
            Controls.Add(ShortCutBtn);
            Controls.Add(Menu);
            Controls.Add(comboBoxStatement);
            Controls.Add(comboKeywords);
            Controls.Add(OpenBtn);
            Controls.Add(SaveAsBtn);
            Controls.Add(RunBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FeiSharpStudio-Console";
            Load += FeiSharpForm_Load;
            Resize += FeiSharpForm_Resize;
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button RunBtn;
        private Button SaveAsBtn;
        private Button OpenBtn;
        private ComboBox comboKeywords;
        private ComboBox comboBoxStatement;
        private Button Menu;
        private Button ShortCutBtn;
        private Label label1;
        internal TextBox outputBox;
        private Button CheckBtn;
        private ComboBox comboBoxClear;
        private RichTextBox txtCode;
        private ListBox lstbIntelligence;
    }
}

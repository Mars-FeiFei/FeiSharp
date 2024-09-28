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
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            Menu = new Button();
            button1 = new Button();
            label1 = new Label();
            outputBox = new TextBox();
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
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(5, 252);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(2191, 1127);
            textBox1.TabIndex = 3;
            textBox1.KeyPress += CodeEditor_KeyPress;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "var", "print", "init", "set", "import", "export", "start", "stop", "wait", "watchstart", "watchend", "abe", "helper" });
            comboBox1.Location = new Point(1855, 68);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(329, 54);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += CbxKeywords_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "if", "while", "func" });
            comboBox2.Location = new Point(1852, 161);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(334, 54);
            comboBox2.TabIndex = 5;
            comboBox2.SelectedIndexChanged += CbxStatement_SelectedIndexChanged;
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
            // button1
            // 
            button1.Location = new Point(1192, 3);
            button1.Name = "button1";
            button1.Size = new Size(521, 88);
            button1.TabIndex = 8;
            button1.Text = "Create Desktop Shortcut";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnShortcutClick;
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
            outputBox.BackColor = Color.Black;
            outputBox.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            outputBox.ForeColor = Color.White;
            outputBox.Location = new Point(8, 1453);
            outputBox.Multiline = true;
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(2184, 179);
            outputBox.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(22F, 46F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(2198, 1641);
            Controls.Add(outputBox);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(Menu);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(OpenBtn);
            Controls.Add(SaveAsBtn);
            Controls.Add(RunBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FeiSharpStudio-Console";
            Load += FeiSharpForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RunBtn;
        private Button SaveAsBtn;
        private Button OpenBtn;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button Menu;
        private Button button1;
        private Label label1;
        internal TextBox outputBox;
    }
}

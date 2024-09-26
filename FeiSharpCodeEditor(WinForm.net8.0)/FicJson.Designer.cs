namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    partial class FicJson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicJson));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            comboBox1 = new ComboBox();
            button4 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(165, 97);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(600, 747);
            textBox1.TabIndex = 0;
            textBox1.KeyPress += TextBox1_KeyPress;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(64, 64, 64);
            textBox2.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(1062, 97);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(600, 747);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(337, 35);
            label1.Name = "label1";
            label1.Size = new Size(193, 46);
            label1.TabIndex = 2;
            label1.Text = "Fei# Code";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1280, 35);
            label2.Name = "label2";
            label2.Size = new Size(179, 46);
            label2.TabIndex = 3;
            label2.Text = "Json Text";
            // 
            // button1
            // 
            button1.Location = new Point(168, 918);
            button1.Name = "button1";
            button1.Size = new Size(600, 96);
            button1.TabIndex = 4;
            button1.Text = "Convert To Json(F5)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1068, 920);
            button2.Name = "button2";
            button2.Size = new Size(601, 97);
            button2.TabIndex = 5;
            button2.Text = "Save As(Ctrl+S)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(5, 5);
            button3.Name = "button3";
            button3.Size = new Size(173, 95);
            button3.TabIndex = 6;
            button3.Text = "Menu";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "var", "print", "init", "set", "import", "export", "start", "stop", "wait", "watchstart", "watchend", "abe", "helper" });
            comboBox1.Location = new Point(795, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(252, 54);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button4
            // 
            button4.Location = new Point(775, 369);
            button4.Name = "button4";
            button4.Size = new Size(276, 109);
            button4.TabIndex = 8;
            button4.Text = "Open Fei# Code(Ctrl+F)";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // FicJson
            // 
            AutoScaleDimensions = new SizeF(22F, 46F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1817, 1045);
            Controls.Add(button4);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FicJson";
            Text = "FeiSharpStudio-FicJson";
            KeyDown += FicJson_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

       


        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox comboBox1;
        private Button button4;
    }
}
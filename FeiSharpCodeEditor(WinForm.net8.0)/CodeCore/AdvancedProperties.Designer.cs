namespace FeiSharpCodeEditor_WinForm.net8._0_.CodeCore
{
    partial class AdvancedProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedProperties));
            view = new RadioButton();
            inspect = new RadioButton();
            lang = new RadioButton();
            comboBox1 = new ComboBox();
            input = new TextBox();
            output = new RichTextBox();
            label1 = new Label();
            button1 = new Button();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // view
            // 
            view.AutoSize = true;
            view.Location = new Point(27, 44);
            view.Name = "view";
            view.Size = new Size(146, 50);
            view.TabIndex = 0;
            view.TabStop = true;
            view.Text = "View";
            view.UseVisualStyleBackColor = true;
            view.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // inspect
            // 
            inspect.AutoSize = true;
            inspect.Location = new Point(307, 44);
            inspect.Name = "inspect";
            inspect.Size = new Size(188, 50);
            inspect.TabIndex = 1;
            inspect.TabStop = true;
            inspect.Text = "Inspect";
            inspect.UseVisualStyleBackColor = true;
            inspect.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // lang
            // 
            lang.AutoSize = true;
            lang.Location = new Point(605, 44);
            lang.Name = "lang";
            lang.Size = new Size(393, 50);
            lang.TabIndex = 2;
            lang.TabStop = true;
            lang.Text = "Progarm Language";
            lang.UseVisualStyleBackColor = true;
            lang.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "FeiSharp-WinFormEdition 8.0" });
            comboBox1.Location = new Point(221, 417);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(567, 54);
            comboBox1.TabIndex = 3;
            // 
            // input
            // 
            input.Location = new Point(12, 591);
            input.Name = "input";
            input.Size = new Size(1015, 53);
            input.TabIndex = 4;
            // 
            // output
            // 
            output.Location = new Point(15, 739);
            output.Name = "output";
            output.ReadOnly = true;
            output.Size = new Size(991, 513);
            output.TabIndex = 5;
            output.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 681);
            label1.Name = "label1";
            label1.Size = new Size(142, 46);
            label1.TabIndex = 6;
            label1.Text = "Output";
            // 
            // button1
            // 
            button1.Location = new Point(792, 650);
            button1.Name = "button1";
            button1.Size = new Size(225, 69);
            button1.TabIndex = 7;
            button1.Text = "ok";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "normal" });
            comboBox2.Location = new Point(221, 287);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(567, 54);
            comboBox2.TabIndex = 8;
            // 
            // AdvancedProperties
            // 
            AutoScaleDimensions = new SizeF(22F, 46F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 1303);
            Controls.Add(comboBox2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(output);
            Controls.Add(input);
            Controls.Add(comboBox1);
            Controls.Add(lang);
            Controls.Add(inspect);
            Controls.Add(view);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AdvancedProperties";
            Text = "FeiSharpStudio-AdvancedProperties";
            Load += AdvancedProperties_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton view;
        private RadioButton inspect;
        private RadioButton lang;
        private ComboBox comboBox1;
        private TextBox input;
        private RichTextBox output;
        private Label label1;
        private Button button1;
        private ComboBox comboBox2;
    }
}
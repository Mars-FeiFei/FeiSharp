namespace FeiSharpStudio
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            console = new Button();
            linkLabel1 = new LinkLabel();
            devoCmd = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // console
            // 
            console.Location = new Point(577, 12);
            console.Name = "console";
            console.Size = new Size(423, 232);
            console.TabIndex = 0;
            console.Text = "Console";
            console.UseVisualStyleBackColor = true;
            console.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(141, 303);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(181, 46);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Fei# Item";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // devoCmd
            // 
            devoCmd.Location = new Point(577, 510);
            devoCmd.Name = "devoCmd";
            devoCmd.Size = new Size(423, 214);
            devoCmd.TabIndex = 3;
            devoCmd.Text = "Windows Cmd";
            devoCmd.UseVisualStyleBackColor = true;
            devoCmd.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(577, 259);
            button1.Name = "button1";
            button1.Size = new Size(423, 232);
            button1.TabIndex = 4;
            button1.Text = "PowerShell";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(22F, 46F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1171, 756);
            Controls.Add(button1);
            Controls.Add(devoCmd);
            Controls.Add(linkLabel1);
            Controls.Add(console);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Menu";
            Text = "FeiSharpStudio-Menu";
            Load += Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button console;
        private LinkLabel linkLabel1;
        private Button devoCmd;
        private Button button1;
    }
}
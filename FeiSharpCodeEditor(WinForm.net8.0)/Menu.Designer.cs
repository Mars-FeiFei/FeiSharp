﻿namespace FeiSharpCodeEditor_WinForm.net8._0_
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
            ficJson = new Button();
            linkLabel1 = new LinkLabel();
            devoCmd = new Button();
            learn = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            console.Location = new Point(577, 189);
            console.Name = "button1";
            console.Size = new Size(423, 137);
            console.TabIndex = 0;
            console.Text = "Console";
            console.UseVisualStyleBackColor = true;
            console.Click += button1_Click;
            // 
            // button2
            // 
            ficJson.Location = new Point(577, 597);
            ficJson.Name = "button2";
            ficJson.Size = new Size(423, 147);
            ficJson.TabIndex = 1;
            ficJson.Text = "FicJson(Fei#Item convert Json)";
            ficJson.UseVisualStyleBackColor = true;
            ficJson.Click += button2_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(149, 332);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(181, 46);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Fei# Item";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button3
            // 
            devoCmd.Location = new Point(577, 377);
            devoCmd.Name = "button3";
            devoCmd.Size = new Size(423, 149);
            devoCmd.TabIndex = 3;
            devoCmd.Text = "Developer Cmd";
            devoCmd.UseVisualStyleBackColor = true;
            devoCmd.Click += button3_Click;
            // 
            // button4
            // 
            learn.Location = new Point(577, 12);
            learn.Name = "button4";
            learn.Size = new Size(423, 134);
            learn.TabIndex = 4;
            learn.Text = "Learn";
            learn.UseVisualStyleBackColor = true;
            learn.Click += button4_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(22F, 46F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1171, 756);
            Controls.Add(learn);
            Controls.Add(devoCmd);
            Controls.Add(linkLabel1);
            Controls.Add(ficJson);
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
        private Button ficJson;
        private LinkLabel linkLabel1;
        private Button devoCmd;
        private Button learn;
    }
}
namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    partial class OutputBox
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
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(2, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(2158, 1254);
            textBox1.TabIndex = 0;
            // 
            // OutputBox
            // 
            AutoScaleDimensions = new SizeF(22F, 46F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2163, 1265);
            Controls.Add(textBox1);
            Name = "OutputBox";
            Text = "Output";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
    }
}
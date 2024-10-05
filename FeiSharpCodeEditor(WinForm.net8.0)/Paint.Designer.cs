namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    partial class Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            txtCode = new RichTextBox();
            PaintBtn = new Button();
            SuspendLayout();
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.FromArgb(64, 64, 64);
            txtCode.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCode.ForeColor = Color.White;
            txtCode.Location = new Point(5, 193);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(1734, 779);
            txtCode.TabIndex = 0;
            txtCode.Text = "";
            // 
            // PaintBtn
            // 
            PaintBtn.Location = new Point(689, 30);
            PaintBtn.Name = "PaintBtn";
            PaintBtn.Size = new Size(272, 120);
            PaintBtn.TabIndex = 1;
            PaintBtn.Text = "Paint";
            PaintBtn.UseVisualStyleBackColor = true;
            PaintBtn.Click += PaintBtn_Click;
            // 
            // Paint
            // 
            AutoScaleDimensions = new SizeF(22F, 46F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1734, 973);
            Controls.Add(PaintBtn);
            Controls.Add(txtCode);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Paint";
            Text = "FeiSharpStudio-Paint";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox txtCode;
        private Button PaintBtn;
    }
}
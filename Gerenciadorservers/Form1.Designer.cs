namespace Gerenciadorservers
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
            components = new System.ComponentModel.Container();
            lstlog = new ListBox();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lstlog
            // 
            lstlog.FormattingEnabled = true;
            lstlog.Location = new Point(1, 177);
            lstlog.Margin = new Padding(3, 4, 3, 4);
            lstlog.Name = "lstlog";
            lstlog.Size = new Size(899, 444);
            lstlog.TabIndex = 0;
            lstlog.SelectedIndexChanged += lstlog_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 636);
            Controls.Add(lstlog);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Gerenciador de Server";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstlog;
        private System.Windows.Forms.Timer timer1;
    }
}

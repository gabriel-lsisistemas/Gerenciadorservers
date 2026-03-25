namespace Gerenciadorservers
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private ListBox lstlog;
        private System.Windows.Forms.Timer timer1;

        private TextBox txtExe1;
        private TextBox txtExe2;
        private TextBox txtExe3;

        private Button btnExe1;
        private Button btnExe2;
        private Button btnExe3;

        private Button btnStart;
        private Button btnRestart;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lstlog = new ListBox();
            timer1 = new System.Windows.Forms.Timer(components);

            txtExe1 = new TextBox();
            txtExe2 = new TextBox();
            txtExe3 = new TextBox();

            btnExe1 = new Button();
            btnExe2 = new Button();
            btnExe3 = new Button();

            btnStart = new Button();
            btnRestart = new Button();

            SuspendLayout();

            // =====================
            // FORM
            // =====================

            ClientSize = new Size(1000, 600);
            Text = "Gerenciador de Server";

            // =====================
            // TXT 1
            // =====================

            txtExe1.Location = new Point(10, 10);
            txtExe1.Size = new Size(750, 23);

            btnExe1.Text = "Selecionar";
            btnExe1.Location = new Point(770, 10);
            btnExe1.Size = new Size(100, 25);
            btnExe1.Click += btnExe1_Click;

            // =====================
            // TXT 2
            // =====================

            txtExe2.Location = new Point(10, 45);
            txtExe2.Size = new Size(750, 23);

            btnExe2.Text = "Selecionar";
            btnExe2.Location = new Point(770, 45);
            btnExe2.Size = new Size(100, 25);
            btnExe2.Click += btnExe2_Click;

            // =====================
            // TXT 3
            // =====================

            txtExe3.Location = new Point(10, 80);
            txtExe3.Size = new Size(750, 23);

            btnExe3.Text = "Selecionar";
            btnExe3.Location = new Point(770, 80);
            btnExe3.Size = new Size(100, 25);
            btnExe3.Click += btnExe3_Click;

            // =====================
            // BOTÕES
            // =====================

            btnStart.Text = "Iniciar";
            btnStart.Location = new Point(10, 120);
            btnStart.Size = new Size(100, 30);
            btnStart.Click += btnStart_Click;

            btnRestart.Text = "Reiniciar";
            btnRestart.Location = new Point(120, 120);
            btnRestart.Size = new Size(100, 30);
            btnRestart.Click += btnRestart_Click;

            // =====================
            // LOG
            // =====================

            lstlog.Location = new Point(10, 170);
            lstlog.Size = new Size(960, 380);

            // =====================
            // ADD
            // =====================

            Controls.Add(txtExe1);
            Controls.Add(txtExe2);
            Controls.Add(txtExe3);

            Controls.Add(btnExe1);
            Controls.Add(btnExe2);
            Controls.Add(btnExe3);

            Controls.Add(btnStart);
            Controls.Add(btnRestart);

            Controls.Add(lstlog);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
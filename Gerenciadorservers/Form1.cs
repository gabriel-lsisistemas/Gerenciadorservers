using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Gerenciadorservers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigurarTimer();
        }

        private void ConfigurarTimer()
        {
            timer1.Interval = 60000;
            timer1.Tick += Timer_Tick;
            timer1.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;

            if ((now.Hour == 8 || now.Hour == 0) && now.Minute == 0)
            {
                RestartAll();
            }
        }

        // =============================
        // SELECIONAR EXE
        // =============================

        private void SelecionarExe(TextBox txt)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Exe (*.exe)|*.exe";

            if (of.ShowDialog() == DialogResult.OK)
            {
                txt.Text = of.FileName;
            }
        }

        private void btnExe1_Click(object sender, EventArgs e)
        {
            SelecionarExe(txtExe1);
        }

        private void btnExe2_Click(object sender, EventArgs e)
        {
            SelecionarExe(txtExe2);
        }

        private void btnExe3_Click(object sender, EventArgs e)
        {
            SelecionarExe(txtExe3);
        }

        // =============================
        // VERIFICAR AO INICIAR
        // =============================

        private void CheckStart(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return;

            if (!File.Exists(path))
            {
                Log($"Arquivo não encontrado: {path}");
                return;
            }

            string processName = Path.GetFileNameWithoutExtension(path);

            var proc = Process.GetProcessesByName(processName);

            if (proc.Length == 0)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = path;
                psi.WorkingDirectory = Path.GetDirectoryName(path);
                psi.UseShellExecute = true;

                Process.Start(psi);

                Log($"{processName} iniciado");
            }
        }

        private void CheckAll()
        {
            CheckStart(txtExe1.Text);
            CheckStart(txtExe2.Text);
            CheckStart(txtExe3.Text);
        }

        // =============================
        // REINICIAR
        // =============================

        private void RestartExe(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return;

            if (!File.Exists(path))
            {
                Log($"Não existe: {path}");
                return;
            }

            string processName = Path.GetFileNameWithoutExtension(path);

            var processes = Process.GetProcessesByName(processName);

            foreach (var p in processes)
            {
                try
                {
                    p.Kill();
                    p.WaitForExit();
                }
                catch { }
            }

            System.Threading.Thread.Sleep(2000);

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = path;
            psi.WorkingDirectory = Path.GetDirectoryName(path);
            psi.UseShellExecute = true;

            Process.Start(psi);

            Log($"{processName} reiniciado");
        }

        private void RestartAll()
        {
            RestartExe(txtExe1.Text);
            RestartExe(txtExe2.Text);
            RestartExe(txtExe3.Text);
        }

        // =============================
        // LOG
        // =============================

        private void Log(string msg)
        {
            lstlog.Items.Add(
                $"[{DateTime.Now:HH:mm:ss}] {msg}"
            );
        }

        // =============================
        // BOTÃO INICIAR MANUAL
        // =============================

        private void btnStart_Click(object sender, EventArgs e)
        {
            CheckAll();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartAll();
        }
    }
}
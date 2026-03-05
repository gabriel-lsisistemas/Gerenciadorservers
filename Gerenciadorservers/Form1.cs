using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Gerenciadorservers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigurarTimer();
            CheckExecutablesOnStartup();
        }

        private void ConfigurarTimer()
        {
            timer1.Interval = 60000; // 1 minuto
            timer1.Tick += Timer_Tick;
            timer1.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;

            if ((now.Hour == 8 || now.Hour == 0) && now.Minute == 0)
            {
                RestartAllExecutables();
            }
        }

        // ===============================
        // VERIFICAÇÃO AO INICIAR
        // ===============================
        private void CheckExecutablesOnStartup()
        {
            string basePath = Application.StartupPath;

            CheckAndStart("IntegradorCreditos",
                System.IO.Path.Combine(basePath, "IntegradorCreditos.lnk"));

            CheckAndStart("IntegradorRM",
                System.IO.Path.Combine(basePath, "IntegradorRM.lnk"));

            CheckAndStart("ApiLocalSeculos",
                System.IO.Path.Combine(basePath, "Api Local Seculos.exe"));
        }

        private void CheckAndStart(string processName, string fullPath)
        {
            var processes = Process.GetProcessesByName(processName);

            if (processes.Length == 0)
            {
                try
                {
                    if (!System.IO.File.Exists(fullPath))
                    {
                        LogMessage($"Arquivo não encontrado: {fullPath}");
                        return;
                    }

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = fullPath,
                        UseShellExecute = true
                    });

                    LogMessage($"{processName} iniciado com sucesso.");
                }
                catch (Exception ex)
                {
                    LogMessage($"Erro ao iniciar {processName}: {ex.Message}");
                }
            }
            else
            {
                LogMessage($"{processName} já está em execução.");
            }
        }

        // ===============================
        // REINÍCIO PROGRAMADO
        // ===============================
        private void RestartAllExecutables()
        {
            string basePath = Application.StartupPath;

            RestartExecutable("IntegradorCreditos",
                System.IO.Path.Combine(basePath, "IntegradorCreditos.lnk"));

            RestartExecutable("IntegradorRM",
                System.IO.Path.Combine(basePath, "IntegradorRM.lnk"));

            RestartExecutable("ApiLocalSeculos",
                System.IO.Path.Combine(basePath, "Api Local Seculos.exe"));
        }

        private void RestartExecutable(string processName, string fullPath)
        {
            try
            {
                var processes = Process.GetProcessesByName(processName);

                foreach (var process in processes)
                {
                    try
                    {
                        process.CloseMainWindow();

                        if (!process.WaitForExit(5000))
                            process.Kill();

                        LogMessage($"{processName} finalizado com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"Erro ao finalizar {processName}: {ex.Message}");
                    }
                }

                System.Threading.Thread.Sleep(2000);

                Process.Start(new ProcessStartInfo
                {
                    FileName = fullPath,
                    UseShellExecute = true
                });
                LogMessage($"{processName} reiniciado com sucesso.");
            }
            catch (Exception ex)
            {
                LogMessage($"Erro ao reiniciar {processName}: {ex.Message}");
            }
        }

        private void LogMessage(string message)
        {
            lstlog.Items.Add($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
        }
        private void lstlog_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
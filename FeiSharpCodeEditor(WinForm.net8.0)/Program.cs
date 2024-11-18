using System.Diagnostics;
using System.Reflection;

namespace FeiSharpStudio
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            FileAssociation.RegisterFileAssociation(".fsc", Assembly.GetExecutingAssembly().Location.Replace(".dll", ".exe"));
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
            if (processes.Length > 1)
            {
                MessageBox.Show("This application is running......", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                ApplicationConfiguration.Initialize();
                Application.Run(new MainForm());
            }
        }
    }
}
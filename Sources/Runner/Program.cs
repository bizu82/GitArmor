using System;
using System.Windows.Forms;
using Runner.IssueTracker;

namespace Runner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 2)
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new IssueTrackerApplication(new []{ args[1] }, new ControllersFactory()).Run();
        }
    }
}

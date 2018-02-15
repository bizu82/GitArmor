using System;
using System.Windows.Forms;
using Core.Git;

namespace Configurator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new MainViewController(new MainView(), new GitRepositoryFactory(), new ConfiguratorControllersFactory()).Run();
        }
    }
}

using System;
using System.Windows.Forms;
using Core.Git;
using Core.Logging;

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
            var logger = new LoggerFactory().CreateForConfigurator();
            new MainViewController(new MainView(), new GitRepositoryFactory(), 
                new ConfiguratorControllersFactory(logger), logger).Run();
        }
    }
}

using System.Collections;
using System.ComponentModel;
using Core.Logging;

namespace Setup.Operations
{
    [RunInstaller(true)]
    public partial class InstallationOperations : System.Configuration.Install.Installer
    {
        private readonly ILogger m_logger;

        public InstallationOperations()
        {
            InitializeComponent();
            m_logger = new LoggerFactory().CreateForSetup();
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary stateSaver)
        {
            m_logger.Info("Starting install operations...");

            base.Install(stateSaver);
            var appFolder = Context.Parameters["targetdir"].TrimEnd(new char[] { '\\' });
            new EnvVarsOperations().AddFolderToPath(appFolder);
            m_logger.Info($"App folder {appFolder} registered into path");

            m_logger.Info("Install operations completed");
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Setup.Operations
{
    [RunInstaller(true)]
    public partial class InstallationOperations : System.Configuration.Install.Installer
    {
        public InstallationOperations()
        {
            InitializeComponent();
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            RegisterAppPathIntoEnvVar();
        }

        private void RegisterAppPathIntoEnvVar()
        {
            var currentPath = Environment.GetEnvironmentVariable("PATH");
            var appDir = $@"{Context.Parameters["targetdir"]}";
            var target = EnvironmentVariableTarget.Machine;
            System.Environment.SetEnvironmentVariable("PATH", $"{currentPath};{appDir}", target);
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

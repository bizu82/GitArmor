using System;

namespace Setup.Operations
{
    public class EnvVarsOperations
    {
        public void AddFolderToPath(string folder)
        {
            var currentPath = Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
            var target = EnvironmentVariableTarget.Machine;

            if(!currentPath.Contains(folder))
                Environment.SetEnvironmentVariable("PATH", $"{currentPath};{folder}", target);
        }
    }
}

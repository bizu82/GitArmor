using System;
using System.IO;
using Utilities;
using Utilities.FileSystem;
using Utilities.Serialization;

namespace Core.Git
{
    public class GitRepository : IGitRepository
    {
        private readonly string m_repositoryFolder;
        private readonly IFileUtilities m_files;
        private readonly IJsonSerializer m_serializer;
        private readonly IDirectoryUtilities m_dirs;
        private readonly IApplication m_application;

        public ICommitTempMessage CommitTempMessage { get; }

        public bool IsArmed => m_files
            .Exists(Path.Combine(m_repositoryFolder, @".git\gitarmor\config"));

        public void Arm()
        {
            if (IsArmed)
                return;
            
            var preComitHookPath = Path.Combine(m_repositoryFolder, @".git\hooks\pre-commit");

            if(m_files.Exists(preComitHookPath))
                throw new HooksAlreadyExistsException();

            if (!m_dirs.Exists(Path.Combine(m_repositoryFolder, @".git\gitarmor")))
                m_dirs.CreateDirectory(Path.Combine(m_repositoryFolder, @".git\gitarmor"));

            var jsonConfig = m_serializer.Serialize(new GitArmorRepositoryConfig());
            using (var fw = m_files.CreateText(Path.Combine(m_repositoryFolder, @".git\gitarmor\config")))
            {
                fw.WriteLine(jsonConfig);
            }

            var preCommitHookSourcePath = Path.Combine(m_application.GetApplicationDirectory(), @"Hooks\pre-commit");
            m_files.Copy(preCommitHookSourcePath, preComitHookPath);
        }

        public GitRepository(string repositoryFolder, 
            IFileUtilities files, 
            IJsonSerializer serializer,
            IDirectoryUtilities dirs,
            IApplication application)
        {
            m_repositoryFolder = repositoryFolder;
            m_files = files;
            m_serializer = serializer;
            m_dirs = dirs;
            m_application = application;
            CommitTempMessage = new CommitTempMessage(repositoryFolder);
        }
    }

    public interface IGitRepository
    {
        ICommitTempMessage CommitTempMessage { get; }
        bool IsArmed { get; }
        void Arm();
    }

    public interface IGitRepositoryFactory
    {
        IGitRepository Create(string repositoryFolder);
    }

    public class GitRepositoryFactory : IGitRepositoryFactory
    {
        public IGitRepository Create(string repositoryFolder)
        {
            if (!Directory.Exists(Path.Combine(repositoryFolder, ".git")))
                throw new InvalidRepositoryException(".git directory does not exists");

            return new GitRepository(repositoryFolder, new FileUtilities(), new JsonSerializer(), 
                new DirectoryUtilities(), new Application());
        }
    }

    public class InvalidRepositoryException : Exception
    {
        public InvalidRepositoryException(string message) : base(message)
        {
        }
    }

    public class HooksAlreadyExistsException : Exception
    {
        public HooksAlreadyExistsException() : base()
        {
        }
    }
}

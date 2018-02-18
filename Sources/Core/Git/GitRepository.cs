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
        private readonly IApplication m_application;
        private readonly IGitArmorRepositoryConfigFactory m_repoConfigFactory;

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

            m_repoConfigFactory.LoadOrCreate(m_repositoryFolder);

            var preCommitHookSourcePath = Path.Combine(m_application.GetApplicationDirectory(), @"Hooks\pre-commit");
            m_files.Copy(preCommitHookSourcePath, preComitHookPath);
        }

        public GitRepository(string repositoryFolder, 
            IFileUtilities files,
            IApplication application,
            IGitArmorRepositoryConfigFactory repoConfigFactory)
        {
            m_repositoryFolder = repositoryFolder;
            m_files = files;
            m_application = application;
            m_repoConfigFactory = repoConfigFactory;
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

            var fileUtils = new FileUtilities();
            return new GitRepository(repositoryFolder, fileUtils, new Application(), 
                new GitArmorRepositoryConfigFactory(new JsonSerializer(), fileUtils, new DirectoryUtilities()));
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

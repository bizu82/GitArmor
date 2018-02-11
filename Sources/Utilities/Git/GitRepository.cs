using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.FileSystem;

namespace Utilities.Git
{
    public class GitRepository : IGitRepository
    {
        private readonly string m_repositoryFolder;
        private readonly IFileUtilities m_fileSystem;

        public ICommitTempMessage CommitTempMessage { get; }

        public bool IsInitialized => m_fileSystem
            .Exists(Path.Combine(m_repositoryFolder, @".git\gitarmor\config"));

        public GitRepository(string repositoryFolder, IFileUtilities fileSystem)
        {
            m_repositoryFolder = repositoryFolder;
            m_fileSystem = fileSystem;
            CommitTempMessage = new CommitTempMessage(repositoryFolder);
        }
    }

    public interface IGitRepository
    {
        ICommitTempMessage CommitTempMessage { get; }
        bool IsInitialized { get; }
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

            return new GitRepository(repositoryFolder, new FileUtilities());
        }
    }

    public class InvalidRepositoryException : Exception
    {
        public InvalidRepositoryException(string message) : base(message)
        {
        }
    }
}

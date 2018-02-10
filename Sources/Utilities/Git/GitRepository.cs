using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Git
{
    public class GitRepository : IGitRepository
    {
        private readonly string m_repositoryFolder;

        public ICommitTempMessage CommitTempMessage { get; }

        public GitRepository(string repositoryFolder)
        {
            m_repositoryFolder = repositoryFolder;
            CommitTempMessage = new CommitTempMessage(repositoryFolder);
        }
    }

    public interface IGitRepository
    {
        ICommitTempMessage CommitTempMessage { get; }
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

            return new GitRepository(repositoryFolder);
        }
    }

    public class InvalidRepositoryException : Exception
    {
        public InvalidRepositoryException(string message) : base(message)
        {
        }
    }
}

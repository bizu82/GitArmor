using System;
using System.Collections.Generic;
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

    public class InvalidRepositoryException : Exception
    {
    }
}

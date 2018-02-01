using BubbleGit.Runner.IssueTracker;

namespace BubbleGit.Runner
{
    public interface ICommitTempMessage
    {
        string Read();
        void Write(string message);
    }

    public class CommitTempMessage : ICommitTempMessage
    {
        private readonly string m_repositoryDirectory;

        public CommitTempMessage(string repositoryDirectory)
        {
            m_repositoryDirectory = repositoryDirectory;
        }

        public string Read()
        {
            throw new System.NotImplementedException();
        }

        public void Write(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
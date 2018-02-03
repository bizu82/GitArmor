using System.Collections.Generic;

namespace Runner.IssueTracker
{
    public class IssueTrackerApplication
    {
        private readonly IControllersFactory m_controllersFactory;
        private readonly string m_repositoryDirectory;

        public IssueTrackerApplication(IReadOnlyList<string> args, IControllersFactory controllersFactory)
        {
            m_controllersFactory = controllersFactory;
            m_repositoryDirectory = args.Count > 0 ? args[0] : null;
        }

        public void Run()
        {
            if (string.IsNullOrEmpty(m_repositoryDirectory?.Trim()))
                throw new InvalidApplicationArgumentException("Repository Directory");

            m_controllersFactory.CreateInsertIssueController(m_repositoryDirectory)
                .Run();
        }
    }
}
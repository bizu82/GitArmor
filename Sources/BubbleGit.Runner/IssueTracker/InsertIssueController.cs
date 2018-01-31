namespace BubbleGit.Runner.IssueTracker
{
    public class InsertIssueController
    {
        private readonly IInsertIssueView m_view;

        public InsertIssueController(IInsertIssueView view)
        {
            m_view = view;
        }
    }
}

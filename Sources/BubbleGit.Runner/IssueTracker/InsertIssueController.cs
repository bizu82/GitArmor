namespace BubbleGit.Runner.IssueTracker
{
    public class InsertIssueController : IInsertIssueController
    {
        private readonly IInsertIssueView m_view;
        private readonly ICommitTempMessage m_commitTempMessage;

        public InsertIssueController(IInsertIssueView view, ICommitTempMessage commitTempMessage)
        {
            m_view = view;
            m_commitTempMessage = commitTempMessage;
            m_view.SetController(this);
        }

        public void Run()
        {
            m_view.ShowDialog();
        }

        public void ConfirmSelection()
        {
            m_commitTempMessage.Write($"[#{m_view.IssueText}] - {m_commitTempMessage.Read()}");
            m_view.Close();
        }
    }

    public interface IInsertIssueController
    {
        void ConfirmSelection();
        void Run();
    }
}

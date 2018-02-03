namespace Runner.IssueTracker
{
    public class InsertIssueController : IInsertIssueController
    {
        private readonly IInsertIssueView m_view;
        private readonly ICommitTempMessage m_commitTempMessage;
        private readonly ILastIssue m_lastIssue;

        public InsertIssueController(IInsertIssueView view, ICommitTempMessage commitTempMessage,
            ILastIssue lastIssue)
        {
            m_view = view;
            m_commitTempMessage = commitTempMessage;
            m_lastIssue = lastIssue;
            m_view.SetController(this);
        }

        public void Run()
        {
            m_view.IssueText = m_lastIssue.Get();
            m_view.ShowDialog();
        }

        public void ConfirmSelection()
        {
            m_commitTempMessage.Write($"[#{m_view.IssueText}] - {m_commitTempMessage.Read()}");
            m_lastIssue.Save(m_view.IssueText);
            m_view.Close();
        }
    }

    public interface IInsertIssueController
    {
        void ConfirmSelection();
        void Run();
    }
}

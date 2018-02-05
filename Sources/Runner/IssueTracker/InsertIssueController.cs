using System;
using System.Windows.Forms;
using Utilities.Forms;
using Utilities.Git;

namespace Runner.IssueTracker
{
    public class InsertIssueController : IInsertIssueController
    {
        private readonly IInsertIssueView m_view;
        private readonly ICommitTempMessage m_commitTempMessage;
        private readonly ILastIssue m_lastIssue;
        private bool m_issueSelected;

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
            m_issueSelected = false;
            m_view.IssueText = m_lastIssue.Get();
            m_view.ShowDialog();
        }

        public void ConfirmSelection()
        {
            int intIssue;
            if (!int.TryParse(m_view.IssueText, out intIssue))
            {
                m_view.ShowMessageBox(@"Invalid issue number");
                return;
            }

            m_commitTempMessage.Write($"[#{m_view.IssueText}] - {m_commitTempMessage.Read()}");
            m_lastIssue.Save(m_view.IssueText);
            m_issueSelected = true;
            m_view.Close();
        }

        public void OnClosing(IFormClosingEventArgs e)
        {
            if (!m_issueSelected && m_view.ShowMessageBox(@"Are you sure you want to commit without an issue number?", @"WARNING",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel();
        }
    }

    public interface IInsertIssueController
    {
        void OnClosing(IFormClosingEventArgs e);
        void ConfirmSelection();
        void Run();
    }
}

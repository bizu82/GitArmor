using System;
using System.Windows.Forms;
using Utilities.Forms;

namespace Runner.IssueTracker
{
    public partial class InsertIssueView : Form, IInsertIssueView
    {
        private IInsertIssueController m_controller;

        public string IssueText
        {
            get { return txtIssue.Text; }
            set { txtIssue.Text = value; }
        }

        public DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(text, caption, buttons);
        }

        public InsertIssueView()
        {
            InitializeComponent();
        }

        public void SetController(IInsertIssueController controller)
        {
            m_controller = controller;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            m_controller.ConfirmSelection();
        }

        private void InsertIssueView_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_controller.OnClosing(new FormClosingEventArgsWrapper(e));
        }
    }

    public interface IInsertIssueView
    {
        void SetController(IInsertIssueController controller);
        DialogResult ShowDialog();
        void Close();
        string IssueText { get; set; }
        DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons);
    }
}

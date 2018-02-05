using System;
using System.Windows.Forms;
using Utilities.Forms;

namespace Runner.IssueTracker
{
    public partial class InsertIssueView : GitArmorForm, IInsertIssueView
    {
        private IInsertIssueController m_controller;

        public string IssueText
        {
            get { return txtIssue.Text; }
            set { txtIssue.Text = value; }
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
    
    public interface IInsertIssueView : IView
    {
        void SetController(IInsertIssueController controller);
        string IssueText { get; set; }
    }
}

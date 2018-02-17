using System.Windows.Forms;
using Configurator.Repository.General;
using Configurator.Repository.IssueTracker;

namespace Configurator.Repository
{
    public partial class RepositoryView : UserControl, IRepositoryView
    {
        private IRepositoryViewController m_controller;
        private readonly GeneralView m_generalView = new GeneralView();
        private readonly IssueTrackerConfigView m_issueTrackerConfigView = new IssueTrackerConfigView();
        
        public IGeneralView GeneralView => m_generalView;
        public IIssueTrackerConfigView IssueTrackerView => m_issueTrackerConfigView;

        public RepositoryView()
        {
            InitializeComponent();
        }

        public void SetController(IRepositoryViewController controller)
        {
            m_controller = controller;
        }

        private void tvRepositoryTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            UserControl controlToShow = null;

            switch (e.Node.Name)
            {
                case "ndRepositoryGeneral":
                    controlToShow = m_generalView;
                    break;
                case "ndRepositoryIssueTracker":
                    controlToShow = m_issueTrackerConfigView;
                    break;
            }

            if (controlToShow == null)
                return;

            splitContainer1.Panel2.Controls.Add(controlToShow);
            controlToShow.Dock = DockStyle.Fill;
        }
    }

    public interface IRepositoryView
    {
        void SetController(IRepositoryViewController controller);
        IGeneralView GeneralView { get; }
        IIssueTrackerConfigView IssueTrackerView { get; }
    }
}

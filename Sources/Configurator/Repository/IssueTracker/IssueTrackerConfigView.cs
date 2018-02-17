using Utilities.Forms;

namespace Configurator.Repository.IssueTracker
{
    public partial class IssueTrackerConfigView : UserControlView, IIssueTrackerConfigView
    {
        private IIssueTrackerConfigController m_controller;

        public IssueTrackerConfigView()
        {
            InitializeComponent();
        }

        public void SetController(IIssueTrackerConfigController controller)
        {
            m_controller = controller;
        }
    }

    public interface IIssueTrackerConfigView : IUserControlView
    {
        void SetController(IIssueTrackerConfigController controller);
    }
}

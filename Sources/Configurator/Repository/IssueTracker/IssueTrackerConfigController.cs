namespace Configurator.Repository.IssueTracker
{
    public class IssueTrackerConfigController : IIssueTrackerConfigController
    {
        private readonly IIssueTrackerConfigView m_view;

        public IssueTrackerConfigController(IIssueTrackerConfigView view)
        {
            m_view = view;
            m_view.SetController(this);
        }
    }

    public interface IIssueTrackerConfigController
    {
    }
}

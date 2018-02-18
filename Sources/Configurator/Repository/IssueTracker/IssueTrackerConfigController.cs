using Core;
using Core.Git;
using Core.Tests;

namespace Configurator.Repository.IssueTracker
{
    public class IssueTrackerConfigController : IIssueTrackerConfigController
    {
        private readonly IIssueTrackerConfigView m_view;
        private readonly IGitRepository m_repository;

        public IssueTrackerConfigController(IIssueTrackerConfigView view, IGitRepository repository)
        {
            m_view = view;
            m_repository = repository;
            m_view.SetController(this);
        }

        public void OnShow()
        {
            m_view.SetEnable(m_repository.IsArmed);
        }
    }

    public interface IIssueTrackerConfigController : IUserControlController
    {
    }
}

using Configurator.Repository.General;
using Configurator.Repository.IssueTracker;
using Core.Git;
using Core.Logging;

namespace Configurator.Repository
{
    public class RepositoryViewController : IRepositoryViewController
    {
        private readonly IRepositoryView m_view;
        private readonly IGitRepository m_repository;
        private IGeneralViewController m_generalController;
        private IIssueTrackerConfigController m_issueTrackerConfigController;

        public RepositoryViewController(IRepositoryView view, IGitRepository repository, ILogger logger)
        {
            m_view = view;
            m_repository = repository;
            view.SetController(this);

            m_generalController = new GeneralViewController(view.GeneralView, repository, logger);
            m_issueTrackerConfigController = new IssueTrackerConfigController(view.IssueTrackerView);
        }
    }

    public interface IRepositoryViewController
    {
    }
}

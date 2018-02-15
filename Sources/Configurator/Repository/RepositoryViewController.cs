using Configurator.Repository.General;
using Core.Git;

namespace Configurator.Repository
{
    public class RepositoryViewController : IRepositoryViewController
    {
        private readonly IRepositoryView m_view;
        private readonly IGitRepository m_repository;
        private IGeneralViewController m_generalController;

        public RepositoryViewController(IRepositoryView view, IGitRepository repository)
        {
            m_view = view;
            m_repository = repository;
            view.SetController(this);

            m_generalController = new GeneralViewController(view.GeneralView, repository);
        }
    }

    public interface IRepositoryViewController
    {
    }
}

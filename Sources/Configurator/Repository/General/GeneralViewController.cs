using Utilities.Git;

namespace Configurator.Repository.General
{
    public class GeneralViewController : IGeneralViewController
    {
        private readonly IGeneralView m_view;

        public GeneralViewController(IGeneralView view, IGitRepository repository)
        {
            m_view = view;
            m_view.SetController(this);
            m_view.SetRepositoryStatus(repository.IsInitialized);
        }
    }

    public interface IGeneralViewController
    {
    }
}

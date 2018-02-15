using Core.Git;

namespace Configurator.Repository.General
{
    public class GeneralViewController : IGeneralViewController
    {
        private readonly IGeneralView m_view;
        private readonly IGitRepository m_repository;

        public GeneralViewController(IGeneralView view, IGitRepository repository)
        {
            m_view = view;
            m_repository = repository;
            m_view.SetController(this);
            m_view.SetRepositoryStatus(repository.IsArmed);
        }

        public void InitializeRepository()
        {
            if (m_repository.IsArmed)
                return;

            m_repository.Arm();
            m_view.SetRepositoryStatus(true);
        }
    }

    public interface IGeneralViewController
    {
        void InitializeRepository();
    }
}

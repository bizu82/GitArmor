using Core.Git;

namespace Configurator
{
    public class MainViewController : IMainViewController
    {
        private readonly IMainView m_view;
        private readonly IGitRepositoryFactory m_repositoryFactory;
        private readonly IConfiguratorControllersFactory m_controllersFactory;

        public MainViewController(IMainView view, IGitRepositoryFactory repositoryFactory,
            IConfiguratorControllersFactory controllersFactory)
        {
            m_view = view;
            m_repositoryFactory = repositoryFactory;
            m_controllersFactory = controllersFactory;
            m_view.SetController(this);
        }

        public void Run()
        {
            m_view.ShowDialog();
        }

        public void OpenRepository()
        {
            var repositoryFolder = m_view.GetFolderFromDialog("Select a repository folder", false);

            if (repositoryFolder == null)
                return;

            IGitRepository repository;

            try
            {
                repository = m_repositoryFactory.Create(repositoryFolder);
            }
            catch (InvalidRepositoryException)
            {
                m_view.ShowMessageBox("Selected folder is not a valid git repository");
                return;
            }

            var repositoryView = m_view.ShowRepositoryMask();
            m_controllersFactory.CreateRepositoryViewController(repositoryView, repository);
        }
    }

    public interface IMainViewController
    {
        void OpenRepository();
    }
}

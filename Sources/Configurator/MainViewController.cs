using System;
using Core.Git;
using Core.Logging;

namespace Configurator
{
    public class MainViewController : IMainViewController
    {
        private readonly IMainView m_view;
        private readonly IGitRepositoryFactory m_repositoryFactory;
        private readonly IConfiguratorControllersFactory m_controllersFactory;
        private readonly ILogger m_logger;

        public MainViewController(IMainView view, IGitRepositoryFactory repositoryFactory,
            IConfiguratorControllersFactory controllersFactory, ILogger logger)
        {
            m_view = view;
            m_repositoryFactory = repositoryFactory;
            m_controllersFactory = controllersFactory;
            m_logger = logger;
            m_view.SetController(this);
        }

        public void Run()
        {
            m_view.ShowDialog();
        }

        public void OpenRepository()
        {
            try
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
            catch (Exception e)
            {
                m_logger.Error(e);
                throw;
            }
        }
    }

    public interface IMainViewController
    {
        void OpenRepository();
    }
}

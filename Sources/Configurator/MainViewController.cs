using System;
using Utilities.Git;

namespace Configurator
{
    public class MainViewController : IMainViewController
    {
        private readonly IMainView m_view;
        private readonly IGitRepositoryFactory m_repositoryFactory;

        public MainViewController(IMainView view, IGitRepositoryFactory repositoryFactory)
        {
            m_view = view;
            m_repositoryFactory = repositoryFactory;
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

            try
            {
                m_repositoryFactory.Create(repositoryFolder);
            }
            catch (InvalidRepositoryException)
            {
                m_view.ShowMessageBox("Selected folder is not a valid git repository");
            }
        }
    }

    public interface IMainViewController
    {
        void OpenRepository();
    }
}

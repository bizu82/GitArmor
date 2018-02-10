using System;

namespace Configurator
{
    public class MainViewController : IMainViewController
    {
        private readonly IMainView m_view;

        public MainViewController(IMainView view)
        {
            m_view = view;
            m_view.SetController(this);
        }

        public void Run()
        {
            m_view.ShowDialog();
        }

        public void OpenRepository()
        {
            throw new NotImplementedException();
        }
    }

    public interface IMainViewController
    {
        void OpenRepository();
    }
}

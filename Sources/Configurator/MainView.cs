using System;
using System.Windows.Forms;
using Configurator.Repository;
using Utilities.Forms;

namespace Configurator
{
    public partial class MainView : GitArmorForm, IMainView
    {
        private IMainViewController m_controller;

        public MainView()
        {
            InitializeComponent();
        }

        public void SetController(IMainViewController controller)
        {
            m_controller = controller;
        }

        public IRepositoryView ShowRepositoryMask()
        {
            var repositoryView = new RepositoryView {Dock = DockStyle.Fill};
            Controls.Add(repositoryView);
            return repositoryView;
        }

        private void openRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_controller.OpenRepository();
        }
    }

    public interface IMainView : IView
    {
        void SetController(IMainViewController controller);
        IRepositoryView ShowRepositoryMask();
    }
}

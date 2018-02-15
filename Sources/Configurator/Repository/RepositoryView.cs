using System.Windows.Forms;
using Configurator.Repository.General;

namespace Configurator.Repository
{
    public partial class RepositoryView : UserControl, IRepositoryView
    {
        private IRepositoryViewController m_controller;
        private readonly GeneralView m_generalView = new GeneralView();
        
        public IGeneralView GeneralView => m_generalView;

        public RepositoryView()
        {
            InitializeComponent();
        }

        public void SetController(IRepositoryViewController controller)
        {
            m_controller = controller;
        }

        private void tvRepositoryTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            if (e.Node.Name != "ndRepositoryGeneral")
                return;

            splitContainer1.Panel2.Controls.Add(m_generalView);
            m_generalView.Dock = DockStyle.Fill;
        }
    }

    public interface IRepositoryView
    {
        void SetController(IRepositoryViewController controller);
        IGeneralView GeneralView { get; }
    }
}

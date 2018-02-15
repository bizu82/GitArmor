using System.Windows.Forms;

namespace Configurator.Repository.General
{
    public partial class GeneralView : UserControl, IGeneralView
    {
        private IGeneralViewController m_controller;

        public GeneralView()
        {
            InitializeComponent();
        }

        public void SetController(IGeneralViewController controller)
        {
            m_controller = controller;
        }

        public void SetRepositoryStatus(bool initialized)
        {
            btnInitRepository.Enabled = !initialized;
        }

        private void btnInitRepository_Click(object sender, System.EventArgs e)
        {
            m_controller.InitializeRepository();
        }
    }

    public interface IGeneralView
    {
        void SetController(IGeneralViewController controller);
        void SetRepositoryStatus(bool initialized);
    }
}

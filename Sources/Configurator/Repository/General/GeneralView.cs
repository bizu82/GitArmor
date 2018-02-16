using System.Drawing;
using System.Windows.Forms;
using Utilities.Forms;

namespace Configurator.Repository.General
{
    public partial class GeneralView : UserControlView, IGeneralView
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
            lblRepositoryStaus.Text = initialized ? "The repository is armed" : "The repository is not armed";
            lblRepositoryStaus.BackColor = initialized ? Color.LimeGreen : Color.Tomato;
        }

        private void btnInitRepository_Click(object sender, System.EventArgs e)
        {
            m_controller.InitializeRepository();
        }
    }

    public interface IGeneralView : IUserControlView
    {
        void SetController(IGeneralViewController controller);
        void SetRepositoryStatus(bool initialized);
    }
}

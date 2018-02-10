using System.Windows.Forms;

namespace Configurator.Repository
{
    public partial class RepositoryView : UserControl, IRepositoryView
    {
        public RepositoryView()
        {
            InitializeComponent();
        }
    }

    public interface IRepositoryView
    {
    }
}

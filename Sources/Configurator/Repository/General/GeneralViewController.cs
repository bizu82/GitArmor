namespace Configurator.Repository.General
{
    public class GeneralViewController : IGeneralViewController
    {
        private readonly IGeneralView m_view;

        public GeneralViewController(IGeneralView view)
        {
            m_view = view;
            m_view.SetController(this);
        }
    }

    public interface IGeneralViewController
    {
    }
}

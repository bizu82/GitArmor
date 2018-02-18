namespace Core
{
    public abstract class UserControlController : IUserControlController
    {
        public abstract void OnShow();
    }

    public interface IUserControlController
    {
        void OnShow();
    }
}

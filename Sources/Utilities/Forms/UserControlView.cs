using System.Windows.Forms;

namespace Utilities.Forms
{
    public interface IUserControlView
    {
        DialogResult ShowMessageBox(string text);
        DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons);
        string GetFolderFromDialog(string caption, bool showCreateButton);
    }

    public partial class UserControlView : UserControl, IUserControlView
    {
        public DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(text, caption, buttons);
        }

        public string GetFolderFromDialog(string caption, bool showCreateButton)
        {
            var dialog = new FolderBrowserDialog
            {
                Description = caption,
                ShowNewFolderButton = showCreateButton
            };
            var result = dialog.ShowDialog(this);
            return result == DialogResult.OK ? dialog.SelectedPath : null;
        }

        public DialogResult ShowMessageBox(string text)
        {
            return MessageBox.Show(text);
        }
    }
}

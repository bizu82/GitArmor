using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities.Forms
{
    public interface IView
    {
        void Close();
        DialogResult ShowDialog();
        DialogResult ShowMessageBox(string text);
        DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons);
    }

    public partial class GitArmorForm : Form, IView
    {
        public DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(text, caption, buttons);
        }

        public DialogResult ShowMessageBox(string text)
        {
            return MessageBox.Show(text);
        }
    }
}

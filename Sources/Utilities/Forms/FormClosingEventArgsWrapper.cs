using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities.Forms
{
    public interface IFormClosingEventArgs
    {
        void Cancel();
    }

    public class FormClosingEventArgsWrapper : IFormClosingEventArgs
    {
        private readonly FormClosingEventArgs m_e;

        public FormClosingEventArgsWrapper(FormClosingEventArgs e)
        {
            m_e = e;
        }

        public void Cancel()
        {
            m_e.Cancel = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMailSender.Components
{
    public partial class FoldersBrowser : Base.BrowserBase
    {
        FolderBrowserDialog _dialog;
        public FoldersBrowser()
        {
            InitializeComponent();
            _dialog = new FolderBrowserDialog();
        }

        protected override void AfterBrowsing(EventArgs e)
        {
            _dialog.SelectedPath = Path;
            if (_dialog.ShowDialog() == DialogResult.OK)
                Path = _dialog.SelectedPath;
            base.AfterBrowsing(e);
        }

    }
}

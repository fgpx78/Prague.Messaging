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
    public partial class FilesBrowser : Base.BrowserBase
    {
        private OpenFileDialog _dialog;
        public FilesBrowser()
        {
            InitializeComponent();
            _dialog = new OpenFileDialog();
        }

        protected override void AfterBrowsing(EventArgs e)
        {
            _dialog.FileName = Path;
            if (_dialog.ShowDialog() == DialogResult.OK)
                Path = _dialog.FileName;
            base.AfterBrowsing(e);
        }

        [Browsable(true)]
        public string FileFilter
        {
            get
            {
                return _dialog.Filter;
            }
            set
            {
                _dialog.Filter = value;
            }
        }
    }
}

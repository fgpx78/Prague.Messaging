using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMailSender.Base
{
    public partial class BrowserBase : UserControl
    {
        public delegate void PathSelectedEventHandler(object sender, string path);
        public BrowserBase()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public event PathSelectedEventHandler PathSelected;

        [Browsable(true)]
        public string LabelText { 
            get { return lbParameterName.Text; }
            set { lbParameterName.Text = value; }
        }

        [Browsable(true)]
        public string Path
        {
            get { return tbPath.Text; }
            set { tbPath.Text = value; }
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            AfterBrowsing(e);
        }

        protected virtual void AfterBrowsing(EventArgs e)
        {
            
        }

        private void tbPath_TextChanged(object sender, EventArgs e)
        {
            if (PathSelected != null)
                PathSelected(this, Path);
        }
    }
}

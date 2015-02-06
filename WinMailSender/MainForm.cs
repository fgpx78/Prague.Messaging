using Messaging = Prague.Messaging;
using Utils = Prague.Utils;
using Prague.Messaging.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Forms;
using Prague.Messaging;
using Prague.Utils;

namespace WinMailSender
{
    public partial class MainForm : Form
    {
        private Prague.Messaging.BatchMailer _mailer;

        private BackgroundWorker _worker;

        private void SetButtonStates()
        {
            if (_worker.IsBusy)
            {
                btCancel.Enabled = true;
                btStart.Enabled = false;
            }
            else
            {
                btCancel.Enabled = false;
                btStart.Enabled = true;
            }
        }

        private void InitBgWorker()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
        }

        private void InitConfigControls()
        {
            Utils.Configuration.ReadConfiguration();
            Messaging.Configuration.ReadConfiguration();

            flbSmtpServers.Path = Messaging.Configuration.SmtpServerConfigurationXmlFile;
            fdbTemplateFolder.Path = Messaging.Configuration.TemplatesFolder;
            flbRecipients.Path = Messaging.Configuration.RecipientListFile;
            fdbLogs.Path = Utils.Configuration.LogFolder;
        }

        public MainForm()
        {
            InitializeComponent();
            InitConfigControls();
            InitBgWorker();
            SetButtonStates();
        }

        private void ShowMessageBoxResult(bool hasError, bool canceled)
        {
            if (!canceled)
            {
                if (!hasError)
                    MessageBox.Show("All messages has been sent success.");
                else
                    MessageBox.Show("Some messages not has been sent, please see log.");
            }
            else
                MessageBox.Show("Sending process has been canceled, please see log for more info.");
        }

        private BatchMailer StartBulk()
        {
            SmtpServersConfiguration smtpConfiguration;
            List<ExpandoObject> recipients;
            Dictionary<string, Template> templates;
            try
            {
                smtpConfiguration = Messaging.SmtpServersManager.LoadSmtpServers(); //load all smtp servers
                recipients = Messaging.RecipientsManager.LoadRecipients(); //load all recipients
                templates = Messaging.TemplateManager.LoadTemplates(); //load all templates
                //TODO: You can add check method bellow for checking correct parameters in the recipient objects and templates
            }
            catch (Exception ex)
            {
                new FileLogger("MAIN").Write("Sending of mails was not started. Exception: {0}", ex.Message);
                return null;
            }
            _mailer = new BatchMailer();
            _mailer.SendBulkMails(recipients, templates, smtpConfiguration);
            return _mailer;
        }

        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetButtonStates();
            ShowMessageBoxResult(((Dictionary<string, bool>)e.Result)["HasError"], ((Dictionary<string, bool>)e.Result)["Canceled"]);
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var bMailer = StartBulk();
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            result.Add("Canceled", bMailer.Canceled);
            result.Add("HasError", bMailer.HasError);
            e.Result = result;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            _worker.RunWorkerAsync();
            SetButtonStates();
            MessageBox.Show("Bulk mail sending has been started.");
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (_mailer != null)
                _mailer.Cancel();
        }

        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            Utils.Configuration.SaveConfiguration();
            Messaging.Configuration.SaveConfiguration();
        }

        private void fdbTemplateFolder_PathSelected(object sender, string path)
        {
            Messaging.Configuration.TemplatesFolder = path;
        }

        private void flbSmtpServers_PathSelected(object sender, string path)
        {
            Messaging.Configuration.SmtpServerConfigurationXmlFile = path;
        }

        private void flbRecipients_PathSelected(object sender, string path)
        {
            Messaging.Configuration.RecipientListFile = path;
        }

        private void fdbLogs_PathSelected(object sender, string path)
        {
            Utils.Configuration.LogFolder = path;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            if (_worker.IsBusy)
                MessageBox.Show("Please, waiting, while sending is processing");
            else
                this.Close();
        }
    }
}

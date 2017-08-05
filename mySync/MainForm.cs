using System;
using System.Windows.Forms;
using mySync.Properties;

namespace mySync
{
    public partial class MainForm : Form
    {
        private SyncHelper _syncHelper;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _syncHelper = new SyncHelper();
            lblConnInfo_iTunes.Text = Resources.MainFormConnectedToiTunes + new iTunesLinker().Version;
            UpdateDevices();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            btnGo.Enabled = false;
            cbxDevice.Enabled = false;
            txtBitrate.Enabled = false;
            chkForceOverride.Enabled = false;
            btnRefresh.Enabled = false;

            Sync();
        }

        private void Sync()
        {
            var conf = new SyncConfiguration
            {
                BitrateKbps = int.Parse(txtBitrate.Text),
                DeviceId = ((Device)cbxDevice.SelectedItem).Id,
                Force = chkForceOverride.Checked,
                StatusBroadcaster = new StatusBroadcaster(this)
            };
            _syncHelper.CheckSync(conf);
        }

        public class StatusBroadcaster
        {
            private readonly MainForm _form;

            public StatusBroadcaster(MainForm form)
            {
                _form = form;
            }

            public int ProgressMax   { set { _form.Invoke(new Action(() => { _form.progress.Maximum = value; })); } }
            public int ProgressMin   { set { _form.Invoke(new Action(() => { _form.progress.Minimum = value; })); } }
            public int ProgressValue { set { _form.Invoke(new Action(() => { _form.progress.Value   = value; })); } }

            public void IncProgress()
            {
                _form.Invoke(new Action(() => { _form.progress.Value++; }));
            }

            public void ChangeStatus(string text)
            {
                _form.Invoke(new Action(() => {
                    _form.lblStatus.Text = text;
                }));
            }
        }

        [STAThread]
        public static void Main(string[] args)
        {
            AndroidLinker.Init();
            FFmpegConverter.Init();
            Application.Run(new MainForm());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateDevices();
        }

        private void UpdateDevices()
        {
            var devices = AndroidLinker.AvailableDevices;
            if (devices.Count == 0)
            {
                MessageBox.Show(Resources.MainFormNoDevice);
                Application.Exit();
            }
            cbxDevice.DataSource = devices;
            cbxDevice.DisplayMember = "Description";
            cbxDevice.ValueMember = "Id";
        }
    }
}

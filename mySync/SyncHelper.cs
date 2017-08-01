using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using mySync.Properties;

namespace mySync
{
    internal class SyncHelper
    {
        private CountDownLatch _waiter;
        private readonly List<string> _outs = new List<string>();

        public void CheckSync(SyncConfiguration configuration)
        {
            var tempDirectory = Environment.CurrentDirectory + "\\ConvTemp\\";
            if (!Directory.Exists(tempDirectory))
                Directory.CreateDirectory(tempDirectory);
            else if (configuration.Force)
            {
                Directory.Delete(tempDirectory, true);
                Directory.CreateDirectory(tempDirectory);
            }

            var iTunesLinker = new iTunesLinker();
            var androidLinker = new AndroidLinker(configuration.DeviceId);

            iTunesLinker.MakePlaylist(tempDirectory, FileWrote);
            iTunesLinker.CheckSync(CountDown, configuration, tempDirectory, out _waiter);

            new Thread(() => {
                _waiter.Await();

                var broadcaster = configuration.StatusBroadcaster;

                broadcaster.ChangeStatus(Resources.MainFormDeleteing);
                DeleteUnusedFiles(tempDirectory, broadcaster, androidLinker);
                broadcaster.ChangeStatus(Resources.MainFormPushing);
                UploadFiles(broadcaster, androidLinker);

                MessageBox.Show(@"FINISHED!");
            }).Start();
        }

        private void DeleteUnusedFiles(string tempDirectory, MainForm.StatusBroadcaster broadcaster, AndroidLinker androidLinker)
        {
            var dels = (
                from file
                in Directory.EnumerateFiles(tempDirectory)
                where !_outs.Contains(file)
                select file).ToList();
            broadcaster.ProgressMax = dels.Count;
            broadcaster.ProgressValue = 0;

            foreach (var file in dels)
            {
                File.Delete(file);
                androidLinker.Delete("/sdcard/Music/" + Path.GetFileName(file));
                broadcaster.IncProgress();
            }
        }

        private void UploadFiles(MainForm.StatusBroadcaster broadcaster, AndroidLinker androidLinker)
        {
            broadcaster.ProgressMax = _outs.Count;
            broadcaster.ProgressValue = 0;

            foreach (string file in _outs)
            {
                androidLinker.Upload(file, "/sdcard/Music");
                broadcaster.IncProgress();
            }
        }

        private void CountDown(string path)
        {
            _waiter.CountDown();
            _outs.Add(path);
        }

        private void FileWrote(string path)
        {
            _outs.Add(path);
        }
    }

    internal class SyncConfiguration
    {
        public int BitrateKbps { get; set; }
        public bool Force { get; set; }
        public string DeviceId { get; set; }
        public MainForm.StatusBroadcaster StatusBroadcaster { get; set; }
    }

    internal class TrackConvertConfiguration
    {
        public string InPath { get; set; }
        public string OutPath { get; set; }
        public int BitrateKbps { get; set; }
    }
}

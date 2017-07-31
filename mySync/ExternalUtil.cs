using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using mySync.Properties;

namespace mySync
{
    internal class ExternalUtil
    {
        private static readonly OpenFileDialog DlgOpenTool = new OpenFileDialog();

        public static void LoadExternalTool(
            string extToolName,
            ref string path, 
            string pathFilename)
        {
            if (IsRefreshingNotNeeded(ref path, pathFilename)) return;
            DlgOpenTool.Filter = string.Format(Resources.ExternalToolDialogFilter, extToolName);
            DlgOpenTool.Multiselect = false;
            if (DlgOpenTool.ShowDialog() != DialogResult.OK)
                throw new ArgumentException(extToolName + " not selected");
            if (!File.Exists(DlgOpenTool.FileName))
                throw new ArgumentException(extToolName + " not exist");
            path = DlgOpenTool.FileName;
            File.WriteAllText(pathFilename, path);
        }

        private static bool IsRefreshingNotNeeded(ref string path, string pathFilename)
        {
            if (!File.Exists(pathFilename))
                return false;
            if ((path = File.ReadAllText(pathFilename).Trim()) == "")
                return false;
            return File.Exists(path);
        }

        public static int Run(string path, string arg)
        {
            var startInfo = new ProcessStartInfo(path, arg)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };
            var proc = Process.Start(startInfo);
            if (proc == null)
                throw new NullReferenceException("Failed creating new process!!!!!!");
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            return proc.ExitCode;
        }
    }
}

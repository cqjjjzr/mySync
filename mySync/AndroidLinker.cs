using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace mySync
{
    public class AndroidLinker
    {
        private static string _adbPath;
        private readonly string _deviceId;

        public AndroidLinker(string deviceId)
        {
            _deviceId = deviceId;
        }

        public static void Init()
        {
            ExternalUtil.LoadExternalTool("adb", ref _adbPath, "adbPath");
        }

        public void Delete(string path)
        {
            ExternalUtil.Run(_adbPath, "-s " + _deviceId + " shell rm -f \"" + path + "\"");
        }

        public void Upload(string localPath, string remotePath)
        {
            ExternalUtil.Run(_adbPath, "-s " + _deviceId + " push \"" + localPath + "\" \"" + remotePath + "\"");
        }

        public static IList<Device> AvailableDevices
        {
            get
            {
                var devices = new List<Device>();

                var start = new ProcessStartInfo
                {
                    FileName = _adbPath,
                    Arguments = "devices",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                };
                var proc = Process.Start(start);
                if (proc == null)
                    throw new NullReferenceException("Failed creating adb process!");

                proc.OutputDataReceived += (sender, e) =>
                {
                    var data = e.Data;
                    if (IsLineInvalid(data)) return;
                    // Lines like this:
                    // 2794a4b5902c	HTC1s
                    var elements = data.Split(new[] {'\t'}, StringSplitOptions.RemoveEmptyEntries);
                    devices.Add(new Device {Id = elements[0], Description = elements[1]});
                };
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.WaitForExit();
                return devices;
            }
        }

        private static bool IsLineInvalid(string data)
        {
            return data == null
                   || data.Trim().Length == 0
                   || data.StartsWith("List of") // First line: List of devices
                   || data.StartsWith("*") // * daemon started successfully
                ;
        }
    }

    public class Device
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

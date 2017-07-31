using System;
using System.Diagnostics;
using System.IO;

namespace mySync
{
    internal class FFmpegConverter
    {
        private static string _ffmpegPath;
        private static string _neroAacEncPath;

        public static void Init()
        {
            ExternalUtil.LoadExternalTool("ffmpeg", ref _ffmpegPath, "ffmpegPath");
            ExternalUtil.LoadExternalTool("neroAacEnc", ref _neroAacEncPath, "neroAacEncPath");
        }

        public static void Convert(ConvertInfo convertInfo)
        {
            if (File.Exists(convertInfo.OutPath))
                File.Delete(convertInfo.OutPath);

            var startInfoFFmpeg = new ProcessStartInfo
            {
                FileName = _ffmpegPath,
                /*
                 * Input: InPath, Output: STDOUT, Output format: WAV(PCM);
                 * Stream: Audio Only, From track start to track end (set in iTunes);
                 * Clear all metadata (write soon from iTunes Database);
                 */
                Arguments = $"-i \"{convertInfo.InPath}\" -map 0 -map -0:v -ss {convertInfo.Start} -to {convertInfo.End} -map_metadata -1 -f wav -",
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            var procFFmpeg = Process.Start(startInfoFFmpeg);
            if (procFFmpeg == null)
                throw new NullReferenceException("Failed creating FFmpeg process!!!");

            var startInfoNero = new ProcessStartInfo
            {
                FileName = _neroAacEncPath,
                /*
                 * Input: STDIN, Output: OutPath;
                 * Bitrate: Bitrate set in the GUI
                 */
                Arguments = $"-ignorelength -if - -of \"{convertInfo.OutPath}\" -cbr {convertInfo.BitrateKbps * 1024}",
                RedirectStandardInput = true,
                UseShellExecute = false
            };
            var procNero = Process.Start(startInfoNero);
            if (procNero == null)
                throw new NullReferenceException("Failed creating Nero AAC Encoder process!!!");

            // Pipe!
            procFFmpeg.StandardOutput.BaseStream.CopyTo(procNero.StandardInput.BaseStream);

            procNero.StandardInput.Close();

            procFFmpeg.WaitForExit();
            procNero.WaitForExit();
            if (procFFmpeg.ExitCode != 0 || procNero.ExitCode != 0 || !File.Exists(convertInfo.OutPath))
                throw new FFmpegException("FFmpeg failed!");
        }
    }

    [Serializable]
    internal class FFmpegException : Exception
    {
        public FFmpegException(string message) : base(message) { }
    }

    public class ConvertInfo
    {
        public string InPath;
        public string OutPath;
        public int BitrateKbps;
        public long Start;
        public long End;

        public ITagInfo TagInfoProvide;
        public MainForm.StatusBroadcaster StatusBroadcaster { get; set; }

        public interface ITagInfo { }
    }
}

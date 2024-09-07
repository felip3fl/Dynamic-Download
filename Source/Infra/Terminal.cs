using System.Diagnostics;
using System.Text;

namespace Infra
{
    public class Terminal
    {
        readonly string executableAddress = "yt-dlp";
        readonly string parameters = "--check-formats -f \"bestvideo[height<=1440]+bestaudio/best[height<=1440]\" -o \"%(channel)s - %(title)s.%(ext)s\" --all-subs --embed-subs --add-metadata";

        public bool Download(string videoAddress)
        {
            Console.Clear();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName         = executableAddress;
            startInfo.WorkingDirectory = @"D:\Videos\Youtube Temp\";
            startInfo.Arguments        = parameters + " " + videoAddress;
            process.StartInfo          = startInfo;
            process.Start();

            return true;
        }


        public string DownloadWithConsole()
        {
            var process                = new Process();
            var messages               = new StringBuilder();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            var videoAddress = "https://www.youtube.com/watch?v=0TZ1krFdzoQ";

            startInfo.FileName               = executableAddress;
            startInfo.WorkingDirectory       = @"D:\Videos\Youtube Temp\";
            startInfo.Arguments              = parameters + videoAddress;
            startInfo.RedirectStandardError  = true;
            startInfo.RedirectStandardOutput = true;
            process.StartInfo                = startInfo;
            Process someProcess              = Process.Start(startInfo);

            messages.Append(someProcess.StandardOutput.ReadToEnd());
            messages.Append(someProcess.StandardError.ReadToEnd());

            return messages.ToString();
        }
    }
}

using System.Diagnostics;
using System.Text;

namespace Infra
{
    public class Terminal
    {
        readonly string executableAddress = "yt-dlp";
        readonly string parameters = "--check-formats --sponsorblock-remove sponsor,selfpromo -f \"bestvideo[height<=1440]+(ba[format_note*=original]/ba)\" -o \"%(channel)s - %(title)s.%(ext)s\" --all-subs --embed-subs --add-metadata";

        public bool Download(string videoAddress)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo();

            startInfo.FileName         = executableAddress;
            startInfo.WorkingDirectory = @"D:\Videos\Youtube Temp\";
            startInfo.Arguments        = parameters + " " + videoAddress;
            process.StartInfo          = startInfo;

            process.Start();

            return true;
        }

        private void test(Process process)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.ResetColor();
        }

        public void ShowConsoleParameters()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{executableAddress} {parameters} \n");
            Console.ResetColor();
        }

        public string DownloadWithConsole(string videoAddress)
        {
            var process   = new Process();
            var messages  = new StringBuilder();
            var startInfo = new ProcessStartInfo();

            if (videoAddress == "")
            {
                videoAddress = "https://www.youtube.com/watch?v=2Ylc0_g3AKU";    
            }

            startInfo.FileName               = executableAddress;
            startInfo.WorkingDirectory       = @"D:\Videos\Youtube Temp\";
            startInfo.Arguments              = parameters + " " + videoAddress;
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

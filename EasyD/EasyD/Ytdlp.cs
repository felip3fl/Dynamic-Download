using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyD
{
    public class Ytdlp
    {
        readonly string executableAddress = @"C:\Users\felip\OneDrive\APP\yt-dlp\yt-dlp.exe";
        readonly string parameters = "-f \"bestvideo[height<=1440]+bestaudio/best[height<=1440]\" -o \"D:\\Videos\\Youtube Temp\\%(title)s.%(ext)s\" ";

        public async Task<bool> Download()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = executableAddress;
            startInfo.Arguments = parameters + $"https://www.youtube.com/watch?v=n-5Q742y8i4";
            process.StartInfo = startInfo;
            process.Start();

            return true;
        }
    }
}

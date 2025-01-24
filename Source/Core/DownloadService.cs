using Core.Model;
using File;
using Infra;
using System.Text.RegularExpressions;

namespace Core
{
    public class DownloadService
    {
        Terminal terminal = new Terminal();

        public string Download(string url)
        {
            var video = new Video();

            video.Url = RemoveAdditionalParameters(url); 

            var consoleMessage = terminal.Download(video.Url);
            //var listOfMessages = ConvertMessageToList(consoleMessage);
            //video.RealizeDate = CheckReturn("");

            return consoleMessage.ToString();
        }

        public List<string> ConvertMessageToList(string messages)
        {
            var listOfMessages = messages.Split("\n").ToList();
            return listOfMessages;
        }

        private DateTime CheckReturn(string message)
        {
            //message = "This live event will begin in 11 days";
            //message = "ERROR: [youtube] 2Ylc0_g3AKU: Premieres in 52 minutes"

            if (!message.Contains("Premieres in"))
                return default;

            //if (!message.Contains("This live event will"))
            //    return default;

            var futureDate = DateTime.Now;
            var daysRemaining = Regex.Match(message, @"\d+ (minute|day|mounth|hour|second)").Value;

            var values = daysRemaining.Split(" ");
            switch (values[1])
            {
                case "minute":
                    futureDate = futureDate.AddMinutes(int.Parse(values[0]));
                    break;
                case "hour":
                    futureDate = futureDate.AddHours(int.Parse(values[0]));
                    break;
                case "day":
                    futureDate = futureDate.AddDays(int.Parse(values[0]));
                    break;
                case "mounth":
                    futureDate = futureDate.AddMonths(int.Parse(values[0]));
                    break;
                default:
                    break;
            }

            //var dateRealize = dateNow.AddDays(1);

            return futureDate.AddHours(2);
        }

        private string RemoveAdditionalParameters(string url)
        {
            string urlWithNoParameters = "";
            int index = url.IndexOf("&");
            if (index >= 0)
                urlWithNoParameters = url.Substring(0, index);
            else
                return url;

            return urlWithNoParameters;
        }
    }
}

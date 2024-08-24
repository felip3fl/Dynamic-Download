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
            message = "This live event will begin in 11 days";

            if (!message.Contains("This live event will"))
                return default;

            var dateNow = DateTime.Now;
            var daysRemaining = Convert.ToInt16(Regex.Match(message, @"\d+").Value);
            var dateRealize = dateNow.AddDays(daysRemaining);

            return dateRealize;
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

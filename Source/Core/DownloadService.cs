using Infra;

namespace Core
{
    public class DownloadService
    {
        Terminal terminal = new Terminal();

        public string Download(string url)
        {
            var urlWithoutParameters = RemoveAdditionalParameters(url);

            return terminal.DownloadWithErrorMessage();
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

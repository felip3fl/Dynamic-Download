using Infra;

namespace Core
{
    public class DownloadService
    {
        public string Download(string url)
        {
            Terminal terminal = new Terminal();

            //var urlWithoutParameters = RemoveAdditionalParameters(linkToDownload);

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
